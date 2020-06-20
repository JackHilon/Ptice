using System;
using System.Collections.Generic;

namespace Ptice
{
    class Program
    {
        static void Main(string[] args)
        {
            // Ptice
            // https://open.kattis.com/problems/ptice
            // 

            var answersNum = EnterNumber();
            var correctAnswers = EnterAnswers(answersNum).ToCharArray();

            int AdrianRes = TwoArrayCompare(AdrianAnswers(answersNum), correctAnswers);
            int BrunoRes = TwoArrayCompare(BrunoAnswers(answersNum), correctAnswers);
            int GoranRes = TwoArrayCompare(GoranAnswers(answersNum), correctAnswers);

            int maxResult = MaxResult(AdrianRes, BrunoRes, GoranRes);
            var bests = TopNames(maxResult, AdrianRes, BrunoRes, GoranRes);

            PrintResult(maxResult, bests);
        }
        private static void PrintResult(int max, List<string> names)
        {
            Console.WriteLine(max);
            for (int i = 0; i < names.Count; i++)
            {
                Console.WriteLine(names[i]);
            }
        }
        private static int MaxResult(int res1, int res2, int res3)
        {
            return Math.Max(res1, Math.Max(res2, res3));
        }

        private static List<string> TopNames(int max, int adrian, int bruno, int goran)
        {
            var res = new List<string>();
            if (max == adrian)
                res.Add("Adrian");
            if (max == bruno)
                res.Add("Bruno");
            if (max == goran)
                res.Add("Goran");
            return res;
        }

        private static char[] AdrianAnswers(int num)
        {
            string Adrian = "A";
            for (int i = 1; i < num; i++)
            {
                if (Adrian[i - 1] == 'A')
                    Adrian = Adrian + "B";
                else if (Adrian[i - 1] == 'B')
                    Adrian = Adrian + "C"; 
                else
                    Adrian = Adrian + "A";
            }
            return Adrian.ToCharArray();
        }
        private static char[] BrunoAnswers(int num)
        {
            string Bruno = "B"; // B, A, B, C, B, A, B, C, B, A, B, C...
            for (int j = 1; j < num; j++)
            {
                if (j == 1)
                    Bruno = Bruno + "A";
                else if (j == 2)
                    Bruno = Bruno + "B";
                else if (Bruno[j - 1] == 'B' && Bruno[j - 2] == 'A')
                    Bruno = Bruno + "C";
                else if (Bruno[j - 1] == 'B' && Bruno[j - 2] == 'C')
                    Bruno = Bruno + "A";
                else if (Bruno[j - 1] == 'A' || Bruno[j - 1] == 'C')
                    Bruno = Bruno + "B";
            }
            return Bruno.ToCharArray();
        }

        private static char[] GoranAnswers(int num)
        {
            string Goran = "C"; // C, C, A, A, B, B, C, C, A, A, B, B ...
            for (int g = 1; g < num; g++)
            {
                if (g == 1)
                    Goran = Goran + "C";
                else if (g == 2)
                    Goran = Goran + "A";
                else if (g == 3)
                    Goran = Goran + "A";




                else if ((Goran[g - 1] == 'C' && Goran[g - 2] == 'C') ||
                    (Goran[g - 1] == 'A' && Goran[g - 2] == 'C' && Goran[g - 3] == 'C'))
                    Goran = Goran + "A";
                else if ((Goran[g - 1] == 'A' && Goran[g - 2] == 'A') ||
                    (Goran[g - 1] == 'B' && Goran[g - 2] == 'A' && Goran[g - 3] == 'A'))
                    Goran = Goran + "B";
                else
                    Goran = Goran + "C";
            }
            return Goran.ToCharArray();
        }

        private static int TwoArrayCompare(char[] a, char[] b)
        {
            int sum = 0;
            if (a.Length != b.Length)
                return 0;
            else
            {
                for (int r = 0; r < a.Length; r++)
                {
                    if (a[r] == b[r])
                        sum = sum + 1;
                }
                return sum;
            }
        }
        private static int EnterNumber()
        {
            string str = "";
            int a = 0;
            str = Console.ReadLine();
            try
            {
                a = int.Parse(str);
                if (a < 1 || a > 100)
                    throw new ArgumentException();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return EnterNumber();
            }
            return a;
        }
        private static string EnterAnswers(int num)
        {
            string str = "";
            try
            {
                str = Console.ReadLine();
                if (str.Length != num)
                    throw new FormatException();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                EnterAnswers(num);
            }
            return str;
        }
    }
}
