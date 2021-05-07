using NUnit.Framework.Constraints;
using System;

namespace NUnitAssignment9
{
    public class AlmostEqualToConstraint : Constraint
    {
        readonly int _expected;
        readonly double _expectedMin;
        readonly double _expectedMax;
        readonly int _percentageTolerance;


        public AlmostEqualToConstraint(int expected, int percentageTolerance)
        {
            _expected = expected;
            _expectedMin = expected * (1 - (double)percentageTolerance / 100);
            _expectedMax = expected * (1 + (double)percentageTolerance / 100);
            _percentageTolerance = percentageTolerance;
            Description = $"AlmostEqualTo {expected} with a tolerance of {percentageTolerance}%";
        }


        public override ConstraintResult ApplyTo<TActual>(TActual actual)
        {
            if (typeof(TActual) != typeof(int))
                return new ConstraintResult(this, actual, ConstraintStatus.Error);

            var actualInt = Convert.ToInt32(actual);

            if (_expectedMin <= actualInt && actualInt <= _expectedMax)
                return new ConstraintResult(this, actual, ConstraintStatus.Success);
            else
                return new ConstraintResult(this, actual, ConstraintStatus.Failure);
        }
    }

}
