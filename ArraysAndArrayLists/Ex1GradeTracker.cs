using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Algorithms.ArraysAndArrayLists
{
    public class Ex1GradeTracker : ITesting
    {
        public void Run()
        {
            double[] grades = new double[100000000];
            BuildArray(grades);

            #region comments
            //Timing timer = new Timing();            
            //timer.StartTime();

            //double average = GetAverage(grades);

            //timer.StopTIme();
            //var dur = timer.Result();
            //var secondsElapsed = dur.TotalMilliseconds / 1000.0;
            //Console.WriteLine($"GetAverage with array returned value {average} after {seconds} seconds");

            //var averagePointer = new Transformer(GetAverage);
            //averagePointer.Invoke(grades);
            #endregion

            double secondsElapsed = 0;
            double _average = Help(GetAverage, grades, ref secondsElapsed);
            Console.WriteLine($"GetAverage with array returned value {_average} after {secondsElapsed} seconds");

            secondsElapsed = 0;
            double _highest = Help(GetHighestGrade, grades, ref secondsElapsed);
            Console.WriteLine($"GetHighestGrade with array returned value {_highest} after {secondsElapsed} seconds");

            secondsElapsed = 0;
            double _lowest = Help(GetLowestGrade, grades, ref secondsElapsed);
            Console.WriteLine($"GetLowestGrade with array returned value {_lowest} after {secondsElapsed} seconds");
        }

        private void BuildArray(double[] grades)
        {
            for (int i = 0; i < grades.Length; i++)
            {
                grades[i] = i++;
            }
        }

        private void BuildArray(ArrayList grades)
        {
            for (int i = 0; i < grades.Count; i++)
            {
                grades[i] = i++; 
            }
        }

        double GetAverage(double[] grades)
        {
            //double average = grades.Average();
            double sum = 0;
            for (int i = 0; i < grades.Count(); i++)
            {
                sum += grades[i];
            }
            double average = sum / grades.Count();
            return average;
        }
        double GetAverage(ArrayList grades)
        {
            double sum = 0;
            for (int i = 0; i < grades.Count; i++)
            {
                sum += Convert.ToDouble((grades[i]));
            }
            double average = sum / grades.Count;
            return average;
        }
        double GetHighestGrade(double[] grades)
        {
            double highest = grades.Max();
            return highest;
        }
        double GetHighestGrade(ArrayList grades)
        {
            double highest = grades.Max();
            return highest;
        }
        double GetLowestGrade(double[] grades)
        {
            double lowest = grades.Min();
            return lowest;
        }
        double GetLowestGrade(ArrayList grades)
        {
            double lowest = grades.Min();
            return lowest;
        }

        double Help(GradeHelper t, double[] grades, ref double secondsElapsed)
        {
            Timing timer = new Timing();
            timer.StartTime();

            var result =  t(grades);
            timer.StopTIme();
            var dur = timer.Result();
            secondsElapsed = dur.TotalMilliseconds / 1000.0;
            return result;
        }

        public delegate double GradeHelper(double[] grades);

    }
}
