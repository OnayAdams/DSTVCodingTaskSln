using DSTVCodingTask.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DSTVCodingTask.Controllers
{
    public class HomeController : Controller
    {
        private List<Element> _elements = new List<Element>();
        private IElementValidator _elementValidator;

        public HomeController(IElementValidator elementValidator)
        {
            this._elementValidator = elementValidator;

            var elementList = new List<Element>
            {
                new Element() { ElementName = "Xenon", Symbol = "No" },
                new Element() { ElementName = "Spenglerium", Symbol = "Ee" },
                new Element() { ElementName = "Stantzon", Symbol = "Zt" },
                new Element() { ElementName = "Tullium", Symbol = "Ty" },
                new Element() { ElementName = "Zanium", Symbol = "za" }
            };

            _elements.AddRange(elementList);
        }

        public ActionResult Index()
        {            
            var validationErrors = _elementValidator.ValidateElements(_elements);

            foreach(var element in _elements)
            {
                element.IsValid = (validationErrors.FirstOrDefault(x => x.ElementName == element.ElementName) == null);
            }

            return View(_elements);
        }

    }
}