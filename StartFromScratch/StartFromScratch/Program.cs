var builder = WebApplication.CreateBuilder(args);


// Mettre � disposition mes controllers et les vues dans l'injection de d�pendance
builder.Services.AddControllersWithViews();
builder.Services.AddSingleton<string>("toto");

var app = builder.Build();

// Cr�ation d'une route
// Association entre forme url et les m�thodes de controller
// /Employe/Addition => {controller} => Employe , {action} => Addition
app.MapControllerRoute("default", "{controller}/{action}", new {Controller="Employe", Action="Index"});
// Association entre url / et le controller / action souhait�
app.MapControllerRoute("root", "/",new  { Controller="Employe", Action= "Addition" });
//app.MapGet("/", () => "Hello World!");

app.Run();
