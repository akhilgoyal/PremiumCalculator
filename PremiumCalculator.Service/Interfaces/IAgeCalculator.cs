using System;

namespace PremiumCalculator.Service.Interfaces
{
    public interface IAgeCalculator
    {
        int CalcAge(DateTime dateOfBirth);
    }
}
