using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Mvc;

using TPLOCAL1.Models;

//Subject is find at the root of the project and the logo in the wwwroot/ressources folders of the solution
//--------------------------------------------------------------------------------------
//Careful, the MVC model is a so-called convention model instead of configuration,
//The controller must imperatively be name with "Controller" at the end !!!
namespace TPLOCAL1.Controllers
{
    public class HomeController : Controller
    {
        //methode "naturally" call by router
        public ActionResult Index(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
                //retourn to the Index view (see routing in Program.cs)
                return View();
            else
            {
                //Call different pages, according to the id pass as parameter
                switch (id)
                {
                    case "OpinionList":
                        //TODO : code reading of the xml files provide
                        OpinionList();
                        return View(id);
                    case "Form":
                        //TODO : call the Form view with data model empty
                        return View(id);
                    default:
                        //retourn to the Index view (see routing in Program.cs)
                        return View();
                }
            }
        }


        //methode to send datas from form to validation page
        [HttpPost]
        public ActionResult ValidationFormulaire(PersonalInformation model)
        {
            //TODO : test if model's fields are set
            //if not, display an error message and stay on the form page
            //else, call ValidationForm with the datas set by the user
            if (model.StartDate > new DateTime(2021, 1, 1))
            {
                ModelState.AddModelError("StartDate", "The date must be before 01/01/2021.");
            }
            if (!ModelState.IsValid)
            {
                // ↪ Affiche les erreurs et revient sur le formulaire
                return View("Form", model);
            }
            return View("ValidationForm", model); 

        }

        public IActionResult OpinionList()
        {
            OpinionList opinionReader = new OpinionList();

            List<Opinion> list = opinionReader.GetAvis("XlmFile\\DataAvis.xml");


            return View(list);
        }
    }
}