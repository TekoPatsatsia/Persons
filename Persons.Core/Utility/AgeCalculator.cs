namespace Persons.Core.Utility;

public static class AgeCalculator
{
    public static int CalculateAge(DateTime birthDate)
    {
        var now = DateTime.Now;
        var age = now.Year - birthDate.Year;
        if (birthDate > now.AddYears(-age))
        {
            age--;
        }

        return age;
    }
}
