using BusinessLayer.Concrete;
using EntityLayer.Concrete;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Drawing;

namespace Core_Portfolio_Project.Controllers
{
    [Authorize(Roles = "Admin")]
    public class PortfolioController : Controller
    {
        private readonly PortfolioManager portfolioManager;

        private readonly IValidator<Portfolio> _validator;

        public PortfolioController(PortfolioManager portfolioManager, IValidator<Portfolio> validator)
        {
            this.portfolioManager = portfolioManager;
            _validator = validator;
        }

        public IActionResult Index()
        {
            var values = portfolioManager.TGetList();  
            return View(values);
        }

        [HttpGet]

        public IActionResult CreatePortfolio()
        {
            return View();
        }

        [HttpPost]

        public IActionResult CreatePortfolio(Portfolio portfolio)
        {
            var result = _validator.Validate(portfolio);

            if (result.IsValid)
            {
                portfolioManager.Tadd(portfolio);
                return RedirectToAction("Index");
                
            }
            else
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                }
                return View(portfolio);
            }
        }

        public IActionResult DeletePortfolio(int id)
        {
            var values = portfolioManager.GetByID(id);
            portfolioManager.TDelete(values);
            return RedirectToAction("Index");
        }

        [HttpGet]

        public IActionResult UpdatePortfolio(int id)
        {
            var values = portfolioManager.GetByID(id);
            return View(values);
        }


        [HttpPost]

        public IActionResult UpdatePortfolio(Portfolio portfolio)
        {
            portfolioManager.TUpdate(portfolio);
            return RedirectToAction("Index");
        }

    }
}
