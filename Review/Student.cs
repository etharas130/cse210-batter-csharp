using System;

namespace cse210_batter_csharp.Review
{
    class Student : Person
    {
        private double _gpa;

        public void SetGPA(double gpa)
        {
            _gpa = gpa;
        }
        public double GetGPA()
        {
            return _gpa;
        }
    }
}