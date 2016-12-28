using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DSTVCodingTask.Models;
using System.Collections.Generic;
using System.Linq;

namespace DSTVCodingTask.Tests
{
    [TestClass]
    public class ValidatorTests
    {
        private List<Element> _elements = new List<Element>();

        [TestInitialize]
        public void TestInitialize()
        {
            var elementList = new List<Element>
            {
                new Element() { ElementName = "Xenon", Symbol = "N" },
                new Element() { ElementName = "Xenon", Symbol = "Nn" },
                new Element() { ElementName = "Spenglerium", Symbol = "Ee" },
                new Element() { ElementName = "Stantzon", Symbol = "Zt" },
                new Element() { ElementName = "Tullium", Symbol = "Ty" },
                new Element() { ElementName = "Tullium", Symbol = "Tt" },
                new Element() { ElementName = "Zanium", Symbol = "za" }
            };

            _elements.AddRange(elementList);
        }

        [TestMethod]
        public void Test_Proper_Symbol_Syntax_Passes()
        {
            IElementValidator validator = new ElementValidator();

            var errorMessages = new List<string>();
            validator.ValidateNumLetters(errorMessages, _elements[1]);

            Assert.IsTrue(errorMessages.FirstOrDefault() == null);
        }

        [TestMethod]
        public void Test_Symbols_Must_Be_Two_Letters()
        {
            IElementValidator validator = new ElementValidator();

            var errorMessages = new List<string>();
            validator.ValidateNumLetters(errorMessages, _elements.FirstOrDefault());

            Assert.IsTrue(errorMessages.FirstOrDefault() == ConstantStrings.ALL_CHEM_SYMB_2_LETTERS);
        }

        [TestMethod]
        public void Test_Both_Letters_Apear_In_Element_Name()
        {
            IElementValidator validator = new ElementValidator();

            var errorMessages = new List<string>();
            validator.ValidateBothLettersApear(errorMessages, _elements.FirstOrDefault(x => x.ElementName == "Tullium"));

            Assert.IsTrue(errorMessages.FirstOrDefault() == ConstantStrings.BOTH_CHEM_SYMB_MUST_APPEAR);
        }

        [TestMethod]
        public void Test_Both_Letters_Apear_In_Correct_Order()
        {
            IElementValidator validator = new ElementValidator();

            var errorMessages = new List<string>();
            validator.ValidateTwoLettersApearInOrder(errorMessages, _elements.FirstOrDefault(x => x.ElementName == "Stantzon"));

            Assert.IsTrue(errorMessages.FirstOrDefault() == ConstantStrings.TWO_LETTERS_IN_ORDER);
        }

        [TestMethod]
        public void Test_Same_Letters_Apear_Twice_In_Element_Name()
        {
            IElementValidator validator = new ElementValidator();

            var errorMessages = new List<string>();
            validator.ValidateTwoLettersApearTwice(errorMessages, _elements.FirstOrDefault(x => x.Symbol == "Tt"));

            Assert.IsTrue(errorMessages.FirstOrDefault() == ConstantStrings.LETTERS_APEAR_TWICE);
        }

        [TestMethod]
        public void Test_First_Letter_Capital()
        {
            IElementValidator validator = new ElementValidator();

            var errorMessages = new List<string>();
            validator.ValidateFirstLetterCapitalised(errorMessages, _elements.LastOrDefault());

            Assert.IsTrue(errorMessages.FirstOrDefault() == ConstantStrings.FIRST_LETTER_CAP);
        }

    }
}
