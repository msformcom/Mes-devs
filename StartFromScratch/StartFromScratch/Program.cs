var builder = WebApplication.CreateBuilder(args);


// Mettre à disposition mes controllers et les vues dans l'injection de dépendance
builder.Services.AddControllersWithViews();
builder.Services.AddSingleton<string>("toto");

var app = builder.Build();

// Création d'une route
// Association entre forme url et les méthodes de controller
// /Employe/Addition => {controller} => Employe , {action} => Addition
app.MapControllerRoute("default", "{controller}/{action}", new {Controller="Employe", Action="Index"});
// Association entre url / et le controller / action souhaité
app.MapControllerRoute("root", "/",new  { Controller="Employe", Action= "Addition" });
//app.MapGet("/", () => "Hello World!");

app.Run();
