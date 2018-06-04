using System;
using System.Web.Mvc;
using PremiumCalculator.Service;
using PremiumCalculator.Models;
using PremiumCalculator.Service.Interfaces;

namespace PremiumCalculator.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPremiumCalculator _premiumCalculator;
        private readonly IAgeCalculator _ageCalculator;
        private Config _config;

        public HomeController(IPremiumCalculator premiumCalculator, IAgeCalculator ageCalculator, Config config)
        {
            _premiumCalculator = premiumCalculator;
            _ageCalculator = ageCalculator;
            _config = config;
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CalculatePremium(CustomerModel model)
        {
            //string output = string.Empty;
            try
            {
                if (ModelState.IsValid)
                {
                    int age = _ageCalculator.CalcAge(model.DateOfBirth);
                    int.TryParse(_config.MinAge, out int minAge);
                    int.TryParse(_config.MaxAge, out int maxAge);

                    if (age >= minAge && age <= maxAge)
                    {
                        decimal premium = _premiumCalculator.CalculatePremium(age, model.Gender);
                        //output = $"{model.Name}, your premium is {premium}";
                        model.Premium = premium;
                        model.Result = $"{model.Name}, your premium is ${premium} AUD";
                    }
                    else
                    {
                        model.Result = $"Sorry {model.Name} we only offer our services to person aged b/w 18 and 65.";
                    }
                }
            }
            catch (Exception ex)
            {
                model.Result = $"{model.Name} at the moment, we can not calculate your premium, please try again later.";
            }

            return View("~/Views/Home/Index.cshtml", model);
        }
    }
}
