using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSTVCodingTask.Models
{
    public interface IElementValidator
    {
        List<ErrorInfo> ValidateElements(List<Element> elements);

        void ValidateNumLetters(List<string> errorMessages, Element element);

        void ValidateBothLettersApear(List<string> errorMessages, Element element);

        void ValidateTwoLettersApearInOrder(List<string> errorMessages, Element element);

        void ValidateTwoLettersApearTwice(List<string> errorMessages, Element element);

        void ValidateFirstLetterCapitalised(List<string> errorMessages, Element element);

        void ValidateTrailingLetterLowerCase(List<string> errorMessages, Element element);

        void ValidateFirstLetterCap(List<string> errorMessages, Element element);
    }
}
