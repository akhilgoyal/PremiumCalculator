using System;
using System.Globalization;
using PremiumCalculator.Service.Interfaces;

namespace PremiumCalculator.Service
{
    public class AgeCalculator : IAgeCalculator
    {
        public int CalcAge(DateTime dateOfBirth)
        {
            int age = 0;
            age = DateTime.Now.Year - dateOfBirth.Year;
            if (DateTime.Now.DayOfYear < dateOfBirth.DayOfYear)
                age = age - 1;

            return age;
        }
    }
}
