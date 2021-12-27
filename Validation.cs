﻿using System.Linq;

namespace Notebook
{
    public class Validation
    {
        public bool Required { get; set; }
        public int MinLength { get; set; }
        public int MaxLength { get; set; }
        public char[] ValidSymbols { get; set; }



        public Validation(bool isRequare, int minValue, int maxValue, char[] symbols)
        {
            Required = isRequare;
            MinLength = minValue;
            MaxLength = maxValue;
            ValidSymbols = symbols;
        }

        public bool TryValidate(string validation, out string error)
        {


            if (string.IsNullOrWhiteSpace(validation) || string.IsNullOrEmpty(validation))
            {
                if (Required)
                {
                    error = "Это поле является обязательным!";
                    return false;
                }
                else
                {
                    error = null;
                    return true;
                }
            }

            if (validation.Length < MinLength)
            {
                error = "Минимальная длина: " + MinLength + "!";
                return false;
            }

            if (validation.Length > MaxLength)
            {
                error = "Максимальная длина: " + MaxLength + "!";
                return false;
            }

            foreach (var item in validation)
            {
                if (!ValidSymbols.Contains(item))
                {
                    error = "Используйте только: " + new string(ValidSymbols) + "!";
                    return false;
                }
            }
            error = null;
            return true;
        }
    }
}