namespace A3.Utils;

public static class HelperMethods
{
    /**
     * Code Adaptered from RMIT/WDT
     */
    public static bool HasMoreThanNDecimalPlaces(this decimal value, int n) => decimal.Round(value, n) != value;
    public static bool HasMoreThanTwoDecimalPlaces(this decimal value) => value.HasMoreThanNDecimalPlaces(2);
}

