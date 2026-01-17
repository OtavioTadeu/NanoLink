using Microsoft.EntityFrameworkCore;
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite("Data Source=banco.db"));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    db.Database.EnsureCreated();
}

app.UseSwagger();
app.UseSwaggerUI();

app.UseDefaultFiles();
app.UseStaticFiles();

//app.MapGet("/", () => "O servidor NanoLink está ativo!");

app.MapPost("/encurtar", async (UrlDto request, HttpContext httpContext, AppDbContext db) =>
{
    if (!Uri.TryCreate(request.Url, UriKind.Absolute, out _))
        return Results.BadRequest("A URL é inválida.");

    var codigo = GerarCodigo();

    var novoLink = new ShortLink
    {
        UrlOriginal = request.Url,
        Codigo = codigo
    };

    db.Links.Add(novoLink);
    await db.SaveChangesAsync();

    var urlCurta = $"{httpContext.Request.Scheme}://{httpContext.Request.Host}/{codigo}";

    return Results.Ok(new
    {
        UrlOriginal = request.Url,
        Codigo = codigo,
        UrlCurta = urlCurta
    });
});

app.MapGet("/{codigo}", async (string codigo, AppDbContext db) =>
{
    var linkEncontrado = await db.Links.FirstOrDefaultAsync(l => l.Codigo == codigo);

    if (linkEncontrado != null)
    {
        return Results.Redirect(linkEncontrado.UrlOriginal);
    }

    return Results.NotFound();
});

app.Run();

string GerarCodigo()
{
    const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
    var random = new Random();
    return new string(Enumerable.Repeat(chars, 6)
        .Select(s => s[random.Next(s.Length)]).ToArray());
}

public record UrlDto(string Url);

class ShortLink
{
    public int Id { get; set; }
    public string UrlOriginal { get; set; }
    public string Codigo { get; set; }
}

class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<ShortLink> Links { get; set; }
}