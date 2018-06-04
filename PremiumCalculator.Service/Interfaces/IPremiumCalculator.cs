namespace PremiumCalculator.Service.Interfaces
{
    public interface IPremiumCalculator
    {
        decimal CalculatePremium(int age, string gender);
    }
}
