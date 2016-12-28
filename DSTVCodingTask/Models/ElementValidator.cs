using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DSTVCodingTask.Models
{
    public  class ElementValidator : IElementValidator
    {
        public  List<ErrorInfo> ValidateElements(List<Element> elements)
        {
            var errors = new List<ErrorInfo>();

            foreach(var element in elements)
            {
                var errorMessages = new List<string>();

                ValidateNumLetters(errorMessages, element);

                ValidateBothLettersApear(errorMessages, element);
                
                ValidateTwoLettersApearInOrder(errorMessages, element);

                ValidateTwoLettersApearTwice(errorMessages, element);

                ValidateFirstLetterCapitalised(errorMessages, element);

                ValidateTrailingLetterLowerCase(errorMessages, element);


                if (errorMessages.Count > 0)
                {
                    errors.Add(new ErrorInfo() { ElementName = element.ElementName, Symbol = element.Symbol, ErrorMessages = errorMessages });
                }             
            }

            return errors;
        }

        private  List<int> PopulateLettersInSymbol(Element element, bool charToLower)
        {
            var letters = new Dictionary<int, char>();
            int num = 1;

            foreach (var character in element.ElementName)
            {
                letters.Add(num, char.ToLower(character));
                num++;
            }

            var ints = CreateIntegerList(element, letters, charToLower);

            return ints;
        }

        private List<int> CreateIntegerList(Element element, Dictionary<int, char> letters, bool charToLower)
        {
            var ints = new List<int>();

            if(!charToLower)
            {
                foreach (var character in element.Symbol)
                {
                    var keyValue = letters.FirstOrDefault(x => x.Value == character).Key;
                    ints.Add(keyValue);
                }
            }
            else
            {
                foreach (var character in element.Symbol)
                {
                    var keyValue = letters.FirstOrDefault(x => x.Value == char.ToLower(character)).Key;
                    ints.Add(keyValue);
                }
            }

            return ints;
        }

        public  void ValidateNumLetters(List<string> errorMessages, Element element)
        {
            if (element.Symbol.Length != 2 )
            {
                errorMessages.Add(ConstantStrings.ALL_CHEM_SYMB_2_LETTERS);
            }
        }

        public  void ValidateBothLettersApear(List<string> errorMessages, Element element)
        {
            foreach (var character in element.Symbol)
            {
                if (!element.ElementName.ToLower().Contains(Char.ToLower(character)))
                {
                    errorMessages.Add(ConstantStrings.BOTH_CHEM_SYMB_MUST_APPEAR);
                }
            }
        }

        public  void ValidateTwoLettersApearInOrder(List<string> errorMessages, Element element)
        {
            var ints = PopulateLettersInSymbol(element, true);

            if (ints.Count > 1 && ints[0] > ints[1])
            {
                errorMessages.Add(ConstantStrings.TWO_LETTERS_IN_ORDER);
            }
        }

        public  void ValidateTwoLettersApearTwice(List<string> errorMessages, Element element)
        {
            var ints = PopulateLettersInSymbol(element, false);

            if (ints.Count > 1 && element.Symbol[0].ToString().ToLower() == element.Symbol[1].ToString().ToLower())
            {
                var character = element.Symbol[0].ToString().ToLower()[0];
                int count = element.ElementName.ToLower().Split(character).Length - 1;

                if (count != 2)
                {
                    errorMessages.Add(ConstantStrings.LETTERS_APEAR_TWICE);
                }
            }
        }

        public  void  ValidateFirstLetterCapitalised(List<string> errorMessages, Element element)
        {
            if (!char.IsUpper(element.ElementName[0]) || !char.IsUpper(element.Symbol[0]))
            {
                errorMessages.Add(ConstantStrings.FIRST_LETTER_CAP);
            }
        }

        public  void ValidateTrailingLetterLowerCase(List<string> errorMessages, Element element)
        {
            for (int i = 1; i < element.ElementName.Length; i++)
            {
                char theChar = element.ElementName[i];

                if (char.IsUpper(theChar))
                {
                    errorMessages.Add(ConstantStrings.FIRST_LETTER_CAP);
                }
            }
        }

    }
}