using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Class
{
    interface IDefault
    {
        string Difficult { get; set; }
        int Mark { get; set; }
    }

    public class Test : IDefault
    {
        string difficult;
        int mark;

        public string Difficult { get => difficult; set => difficult = value; }
        public int Mark { get => mark; set => mark = value; }

        public Test(string name, int mark)
        {
            this.Difficult = name;
            this.mark = mark;
        }

        public void PrintBase()
        {
            Console.WriteLine("Difficult:    " + this.Difficult + "\nMark:   " + this.mark);
        }
    }

    public class Exam : Test
    {
        public string Town;
        public Exam(string name, int mark, string town)
            : base(name, mark)
        {
            this.Town = town;
        }
        public void PrintTown()
        {
            Console.WriteLine("Town:    " + this.Town);
        }
    }

    public class FinalExam : Exam
    {
        public int Year;
        public FinalExam(string name, int mark, string town, int year)
            : base(name, mark, town)
        {
            if (year > 0 && year < 2020)
                this.Year = year;
            else
            {
                Console.WriteLine("Error\nYear = 2019");
                this.Year = 2019;
            }
        }
        public void PrintYear()
        {
            Console.WriteLine("Year:    " + this.Year);
        }
    }

    public class Challenge : FinalExam
    {
        public string prize;
        public Challenge(string name, int mark, string town, int year, string prize)
            : base(name, mark, town, year)
        {
            this.prize = prize;
        }
        public void PrintPrize()
        {
            Console.WriteLine("Prize:    " + this.prize);
        }
    }

    class Program
    {
        delegate void Output();
        static void Main(string[] args)
        {
            Test picture = new Test("Easy", 8);
            Exam painting = new Exam("Normal", 9, "Odessa");
            FinalExam remake = new FinalExam("Hard", 10, "Kiliya", 2019);
            Challenge landscape = new Challenge("UnderMind", 11, "Tatarbunary", 1850, "Batman_Toy");
            Output output;
            while (true)
            {
                Console.Clear();
                Console.WriteLine("1. Info about TEST\n2.Info about EXAM\n3.Info about FINAL EXAM\n4.Info about CHALLENGE");
                int selection = 0;
                try
                {
                    selection = Convert.ToInt32(Console.ReadLine());
                }
                catch
                {
                    Console.WriteLine("Unknown command");
                    Console.ReadKey();
                    continue;
                }
                switch (selection)
                {
                    case 1:
                        output = picture.PrintBase;
                        output();
                        Console.ReadKey();
                        break;
                    case 2:
                        output = painting.PrintBase;
                        output += painting.PrintTown;
                        output();
                        Console.ReadKey();
                        break;
                    case 3:
                        output = remake.PrintBase;
                        output += remake.PrintTown;
                        output += remake.PrintYear;
                        output();
                        Console.ReadKey();
                        break;
                    case 4:
                        output = landscape.PrintBase;
                        output += landscape.PrintTown;
                        output += landscape.PrintYear;
                        output += landscape.PrintPrize;
                        output();
                        Console.ReadKey();
                        break;
                    default:
                        Console.WriteLine("Unknown command");
                        Console.ReadKey();
                        break;
                }
            }
        }
    }
}
