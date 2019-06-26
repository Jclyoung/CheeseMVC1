using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace CheeseMVC.Controllers
{
    public class CheeseController : Controller
    {
        //stactic belongs to any code within my class and doesn't belong to any one instance of the class
        static private List<string> Cheeses = new List<string>();        

        
        // Get: /<controller>/
        public IActionResult Index()
        {
            List<string> cheeses = new List<string>();
            // This only lives within the index method so it is better to put a static 
            //method up top
            cheeses.Add("Cheddar");
            cheeses.Add("Munster");
            cheeses.Add("Parmesan");

            ViewBag.cheeses = Cheeses;

            return View();
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [Route("/Cheese/Add")]
        public IActionResult NewCheese(string name)
        {
            //Add the new cheese to my exsisting cheeses
            // Cheeses looks up the list from the stactic method
            Cheeses.Add(name);
            return Redirect("/Cheese");

        }

        //You can only access from within your folder (Cheese View folder)  or the shared folder
        public IActionResult Index2()
        {
            return View("Error");
        }

        // redirects to the original index or any other view you place in the quotes
        // View must be from shared folder or from it's own folder
        //public IActionResult Index2()
        //{
        //    return View("Index");
        //}
    }
}