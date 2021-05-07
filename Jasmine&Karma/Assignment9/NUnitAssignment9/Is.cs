namespace NUnitAssignment9
{
    public class Is : NUnit.Framework.Is
    {
        public static IsCapitalizeConstraint IsCapitalize(string expected)
        {
            return new IsCapitalizeConstraint(expected);
        }

        public static AlmostEqualToConstraint IsAlmostEqualTo(int expected, int percentageTolerance = 5)
        {
            return new AlmostEqualToConstraint(expected, percentageTolerance);
        }

        public static IsPartOfConstraint IsPartOf(int[] expected)
        {
            return new IsPartOfConstraint(expected);
        }
    }
}
