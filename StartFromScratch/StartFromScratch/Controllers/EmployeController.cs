using Microsoft.AspNetCore.Mvc;
using StartFromScratch.Models;
using StartFromScratch.ViewModels.Employe;

namespace StartFromScratch.Controllers
{
    // Controller destiné à géréer les fonctionnalités offertes pour les employés
    // Attribut Controller => Identifie une class comme étant un controller
    // Services.AddController le prendra en compte
    [Controller]
 
    public class EmployeController : Controller
    {

        List<Employe> DataEmployes = new List<Employe>()
        {
            new Employe(){Nom="Mauras", Prenom="Dominique", Actif=true, DateEntree=DateTime.Now, Matricule="007", Salaire=1000000000},
            new Employe(){Nom="Gates", Prenom="Bill", Actif=true, DateEntree=DateTime.Now, Matricule="009", Salaire=100000000},
            new Employe(){Nom="Waine", Prenom="John", Actif=false, DateEntree=DateTime.Now, Matricule="005", Salaire=1000000}
        };


        // Créer une action qui affiche dans une page HTML 
        // 1) les employes
        // 2) le montant de charges salariales de l'entreprise
        // GET : /Employe/index
        public IActionResult Index()
        {
            var model = new IndexVM()
            {
                Liste = DataEmployes,
                MasseSalariale = DataEmployes.Where(c => c.Actif).Sum(c => c.Salaire)
            };
            return View(model);
        }


        // GET : Employe/AugmenterSalaires => Augmenter les salaires de 10%
        // Réafficher les employes + masse salariale
        // return View("Index",model)



        // Méthode du controller (public sinon ne fonctionne pas)
        // Get /Employe/Addition
        public IActionResult Addition(int a, int b) {
            // model = les données envoyées à la vue
            var model = new AdditionVM { A = a, B = b, Result = a + b };
            // retour d'un ViewResult => Html généré par la vue
            // La vue utilisée est /Views/Employe/Addition.cshtml
            return View(model);
        }
    }
}
