using Algorithms.ArraysAndArrayLists;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    class Tester
    {
        static void Main(string[] args)
        {
            //Test(new Ex1GradeTracker());
            Test(new Ex2GradeTracker());
        }
        static void Test(ITesting sut)
        {
            sut.Run();
        }
    }
}
