using LetsCSharp.Common;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LetsCSharp.EqualityComparer
{
    public class StudentComparer : IEqualityComparer<Student>
    {
        public bool Equals(Student? x, Student? y)
        {
            return x.Id == y.Id;
        }

        public int GetHashCode([DisallowNull] Student obj)
        {
            return obj.Id.GetHashCode() ^ obj.Fees.GetHashCode();
        }
    }
    internal static class EqualityComparerCheck
    {
        public static void Test()
        {
            CommonHelper.InitializeData();
            var studentsComparer = CommonHelper.Students.Distinct(new StudentComparer());
        }
    }
}
