using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DSTVCodingTask;
using DSTVCodingTask.Controllers;
using DSTVCodingTask.Models;

namespace DSTVCodingTask.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        public void Index()
        {
            IElementValidator validator = new ElementValidator();
            // Arrange
            HomeController controller = new HomeController(validator);

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);


        }

    }
}
