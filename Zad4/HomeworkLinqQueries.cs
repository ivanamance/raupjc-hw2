using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DZ2;

namespace Zad4
{
    public class HomeworkLinqQueries
    {
        public static string[] Linq1(int[] intArray)
        {
            string[] stringArray = intArray.Distinct().OrderBy(i => i).ToArray()
                                            .Select(i => $"Broj {i} ponavlja se {intArray.Where(j => j == i).ToArray().Length} puta")
                                            .ToArray();

            return stringArray;
        }
        public static University[] Linq2_1(University[] universityArray)
        {
            University[] maleUniversities =
                universityArray.Where(u => u.Students.All(s => s.Gender == Gender.Male)).ToArray();
            return maleUniversities;
        }
        public static University[] Linq2_2(University[] universityArray)
        {
            double avrageNumberStudents = (double)universityArray.Sum(u => u.Students.Length) / universityArray.Length;
            University[] bellowAwrageUniversities =
                universityArray.Where(u => u.Students.Length < avrageNumberStudents).ToArray();
            return bellowAwrageUniversities;
        }
        public static Student[] Linq2_3(University[] universityArray)
        {
            Student[] allStudents = universityArray.SelectMany(u => u.Students).Distinct().ToArray();
            return allStudents;
        }
        public static Student[] Linq2_4(University[] universityArray)
        {
            Student[] arrayStudents = universityArray
                .Where(u => u.Students.All(s => s.Gender == Gender.Male) ||
                            u.Students.All(s => s.Gender == Gender.Female))
                            .SelectMany(u => u.Students).Distinct().ToArray();
            return arrayStudents;
        }
        public static Student[] Linq2_5(University[] universityArray)
        {
            Student[] arrayStudents = universityArray.SelectMany(u => u.Students)
                .GroupBy(s => s.Jmbag).Where(g => g.Count() > 1).SelectMany(g => g).Distinct().ToArray();
            return arrayStudents;
        }
    }

}
