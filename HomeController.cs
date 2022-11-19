using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Tests.Models;

namespace Tests.Controllers
{
    public class HomeController : Controller
    {
        public ContextClass db;
        private int[] correctAnsws = new int[] {4, 1, 2, 3, 4, 2, 1, 3, 3, 4 };

        public HomeController(ContextClass context)
        {
            db = context;
        }

        [Authorize]
        public IActionResult Index()
        {
            List<Question> questions = db.Questions.ToList(); 
            return View(questions);
        }

        [HttpPost]
        public IActionResult Results(Question q, int r_0, int r_1, int r_2, int r_3, int r_4, int r_5, int r_6, int r_7, int r_8, int r_9)
        {
            int mark = 0;
            int wrongAnsws = 0;
            int[] userAnsws = new int[] { r_0, r_1,  r_2,  r_3,  r_4,  r_5,  r_6,  r_7,  r_8,  r_9 };
            for(int i=0; i<userAnsws.Length; i++)
            {
                if (correctAnsws[i] == userAnsws[i]) mark++;
                else wrongAnsws++;
            }
            ViewBag.wr = wrongAnsws;
            ViewBag.cr = mark;
            return View(mark);
        }

        public async Task<IActionResult> SendMessage()
        {
            EmailService emailService = new EmailService();
            await emailService.SendEmailAsync(User.Identity.Name, "Ваш результат", $"Оценка:{ViewBag.cr}");
            return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
