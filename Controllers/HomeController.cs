using accesspubnew.Data;
using accesspubnew.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace accesspubnew.Controllers
{
    
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _dbContext;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext applicationDb)
        {
            _logger = logger;
            _dbContext = applicationDb;
        }

        [AllowAnonymous]
        public IActionResult Index()
        {
            rate ratedolar = _dbContext.rate.Where(r => r.rate_code == "USD").SingleOrDefault();
            rate rateeur = _dbContext.rate.Where(r => r.rate_code == "EUR").SingleOrDefault();
            if (ratedolar==null || rateeur==null){
                return View();
            }
            RateViewModel rateView = new RateViewModel()
            {
                rate_code_usd = ratedolar.rate_code,
                rate_achat_usd = ratedolar.rate_achat,
                rate_vente_usd = ratedolar.rate_vente,
                rate_code_eur = rateeur.rate_code,
                rate_achat_eur = rateeur.rate_achat,
                rate_vente_eur = rateeur.rate_vente,
                date_jour = ratedolar.date_jour
            };
            ViewData["rate"] = rateView;
            return View();
        }
        [AllowAnonymous]
        public IActionResult Index_Admin()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
