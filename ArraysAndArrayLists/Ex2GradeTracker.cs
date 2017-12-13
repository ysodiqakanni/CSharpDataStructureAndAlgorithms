using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.ArraysAndArrayLists
{
    public class Ex2GradeTracker : ITesting
    {
        public void Run()
        { 

            int nrow = 5; int ncol = 1000000;
            double[,] grades = new double[nrow, ncol];
            BuildArray(grades, nrow, ncol);
            //Array.
            double timeElapsed = 0;
            double[] averageVals =  Help(GetAverage, grades, nrow, ncol, ref timeElapsed);
            Console.WriteLine($"GetAverage with array returned value {String.Join(",", averageVals)} after {timeElapsed} seconds");

            timeElapsed = 0;
            double[] highestVals = Help(GetHighestGrade, grades, nrow, ncol, ref timeElapsed);
            Console.WriteLine($"GetHighestGrade with array returned value {String.Join(",", highestVals)} after {timeElapsed} seconds");

            timeElapsed = 0;
            double[] lowestVals = Help(GetHighestGrade, grades, nrow, ncol, ref timeElapsed);
            Console.WriteLine($"GetHighestGrade with array returned value {String.Join(",", lowestVals)} after {timeElapsed} seconds");
        }
        private void BuildArray(double[,] grades, int nRow, int ncol)
        {
            for (int r = 0; r < nRow; r++)
            {
                for (int i = 0; i < ncol; i++)
                {
                    grades[r, i] = r + i;
                }
            }
           
        }

        double[] GetAverage(double[,] grades, int nRow, int nCol)
        {
            double[] averages = new double[nRow];
            for (int i = 0; i < nRow; i++)
            {
                double sum = 0;
                for (int j = 0; j < nCol; j++)
                {
                    sum += grades[i, j];
                }
                averages[0] = sum;
            }
            return averages;
        }
        double[] GetHighestGrade(double[,] grades, int nRow, int nCol)
        {
            double[] highests = new double[nRow];
            for (int i = 0; i < nRow; i++)
            {
                double largest = grades[0,0];
                for (int j = 0; j < nCol; j++)
                {
                    if (grades[i, j] > largest)
                        largest = grades[i, j];
                }
                highests[i] = largest;
            }
            return highests;
        }
        double[] GetLowestGrade(double[,] grades, int nRow, int nCol)
        {
            double[] lowestValues = new double[nRow];
            for (int i = 0; i < nRow; i++)
            {
                double lowest = grades[0, 0];
                for (int j = 0; j < nCol; j++)
                {
                    if (grades[i, j] > lowest)
                        lowest = grades[i, j];
                }
                lowestValues[i] = lowest;
            }
            return lowestValues;
        }

        double[] Help(GradeHelper t, double[,] grades, int nrow, int ncol, ref double secondsElapsed)
        {
            Timing timer = new Timing();
            timer.StartTime();

            var result = t(grades, nrow, ncol);
            timer.StopTIme();
            var dur = timer.Result();
            secondsElapsed = dur.TotalMilliseconds / 1000.0;
            return result;
        }

        public delegate double[] GradeHelper(double[,] grades, int nrow, int ncol);
    }
}
