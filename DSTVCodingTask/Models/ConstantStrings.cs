using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DSTVCodingTask.Models
{
    public static class ConstantStrings
    {
        public const string ALL_CHEM_SYMB_2_LETTERS = "All chemical symbols must be exactly two letters";
        public const string BOTH_CHEM_SYMB_MUST_APPEAR = "Both letters in the symbol must appear in the element name";
        public const string TWO_LETTERS_IN_ORDER = "The two letters must appear in order in the element name";
        public const string LETTERS_APEAR_TWICE = "If the two letters in the symbol are the same, it must appear twice in the element name";
        public const string FIRST_LETTER_CAP = "Both the element name and the symbol will have their first letter capitalised, with the rest lowercase.";
    }
}