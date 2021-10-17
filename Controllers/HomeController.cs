using codeyes.msc.each.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Diagnostics;
using System.IO;

namespace codeyes.msc.each.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Report(CreatePost model)
        {
            model.DateTime = DateTime.Now;

            return View(model);
        }

        public IActionResult Build(CreatePost model)
        {
            if (model.MyImage != null)
            {
                var uniqueFileName = GetUniqueFileName(model.MyImage.FileName);
                model.DateTime = DateTime.Now;

                //ViewData["Message"] = string.Format("Consegui ler o arquivo {0}.\\n Data: {1}", uniqueFileName, DateTime.Now.ToString());
                return RedirectToAction("Report", "Home");
            }
            else {
               // ViewData["Message"] = string.Format("Nenhum arquivo foi selecionado! {0}.\\n Data: {1}", "", DateTime.Now.ToString());
                return View(model);
            }                      
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        private string GetUniqueFileName(string fileName)
        {
            fileName = Path.GetFileName(fileName);
            return Path.GetFileNameWithoutExtension(fileName)
                      + "_"
                      + Guid.NewGuid().ToString().Substring(0, 4)
                      + Path.GetExtension(fileName);
        }
    }
}