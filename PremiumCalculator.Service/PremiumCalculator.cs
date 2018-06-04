using System;
using PremiumCalculator.Service.Interfaces;

namespace PremiumCalculator.Service
{
    public class PremiumCalculator : IPremiumCalculator
    {
        private Config _config;
        public PremiumCalculator(Config config)
        {
            _config = config;
        }
        public decimal CalculatePremium(int age, string gender)
        {
            decimal result = 0;
            try
            {
                //Get the multiplier
                decimal.TryParse(_config.Multiplier, out decimal multiplier);

                //Get genderFactorValue
                string genderFactorValue = (gender.ToLower() == "male" ? _config.MaleGenderFactor : _config.FeMaleGenderFactor);

                decimal.TryParse(genderFactorValue, out decimal genderFactor);

                result = age * genderFactor * multiplier;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return result;
        }

    }
}
