using System;

namespace ConsoleApp2
{
    public class Student
    {

        static public int is_number(string input)
        {
            bool a = true;
            bool a0 = true;
            while (a0)
            {
                while (a)
                {
                    int d = input.Length;
                    foreach (char c in input)
                        if (char.IsNumber(c))
                        {
                            if ((input[0] == '0') && (d != 1))
                            {
                                Console.WriteLine("Ви ввели некоректне значення, введiть нове: ");
                                input = Console.ReadLine();
                                a = true;
                                break;
                            }
                            a = false;
                        }
                        else if ((input[0] == '-') && (d != 1) && (input[1] != '-'))
                            continue;
                        else
                        {
                            Console.WriteLine("Ви ввели некоректне значення, введiть нове: ");
                            input = Console.ReadLine();
                            a = true;
                            break;
                        }
                }

                if (Convert.ToInt32(input) >= 0)
                {
                    a0 = false;
                }
                else
                {
                    Console.WriteLine("Ви ввели некоректне значення, введiть нове: ");
                    input = Console.ReadLine();
                    a = true;
                }
            }
            return Convert.ToInt32(input);
        }

        static public double Average(Math0 math, int j)
        {
            double s = 0;
            for (int i = 0; i < 3; i++)
                s += math[i, j];
            return s / 3;
        }
        static public double Average(Physics physics, int j)
        {
            double s = 0;
            for (int i = 0; i < 3; i++)
                s += physics[i, j];
            return s / 3;
        }
        static public double Average(Chemistry chemistry, int j)
        {
            double s = 0;
            for (int i = 0; i < 3; i++)
                s += chemistry[i, j];
            return s / 3;
        }
        static public double Average(History history, int j)
        {
            double s = 0;
            for (int i = 0; i < 3; i++)
                s += history[i, j];
            return s / 3;
        }
        static public double Average(English english, int j)
        {
            double s = 0;
            for (int i = 0; i < 3; i++)
                s += english[i, j];
            return s / 3;
        }

        public class LastName
        {
            private string[] lastname;
            public LastName(int N)
            {
                lastname = new string[N];
            }

            public string this[int Index]
            {
                get
                {
                    return lastname[Index];
                }
                set
                {
                    lastname[Index] = value;
                }
            }
        }
        public class Math0
        {
            private int[,] math;
            public Math0(int N, int M)
            {
                math = new int[N, M];
            }

            public int this[int Index1, int Index2]
            {
                get
                {
                    return math[Index1, Index2];
                }
                set
                {
                    math[Index1, Index2] = value;
                }
            }
        }
        public class Physics
        {
            private int[,] physics;
            public Physics(int N, int M)
            {
                physics = new int[N, M];
            }

            public int this[int Index1, int Index2]
            {
                get
                {
                    return physics[Index1, Index2];
                }
                set
                {
                    physics[Index1, Index2] = value;
                }
            }
        }
        public class Chemistry
        {
            private int[,] chemistry;
            public Chemistry(int N, int M)
            {
                chemistry = new int[N, M];
            }

            public int this[int Index1, int Index2]
            {
                get
                {
                    return chemistry[Index1, Index2];
                }
                set
                {
                    chemistry[Index1, Index2] = value;
                }
            }
        }
        public class History
        {
            private int[,] history;
            public History(int N, int M)
            {
                history = new int[N, M];
            }

            public int this[int Index1, int Index2]
            {
                get
                {
                    return history[Index1, Index2];
                }
                set
                {
                    history[Index1, Index2] = value;
                }
            }
        }
        public class English
        {
            private int[,] english;
            public English(int N, int M)
            {
                english = new int[N, M];
            }

            public int this[int Index1, int Index2]
            {
                get
                {
                    return english[Index1, Index2];
                }
                set
                {
                    english[Index1, Index2] = value;
                }
            }
        }

        public Student() { }

        public void Print()
        {
            Console.WriteLine("Введiть кiлькiсть студентiв: ");
            string input0 = Console.ReadLine();
            int n = is_number(input0);

            LastName lastname = new LastName(n);
            Math0 math = new Math0(3, n);
            Physics physics = new Physics(3, n);
            Chemistry chemistry = new Chemistry(3, n);
            History history = new History(3, n);
            English english = new English(3, n);

            for (int i = 0; i < n; i++)
            {
                Console.WriteLine("\nВведiть прiзвище " + (i + 1) +" студента: ");
                lastname[i] = Console.ReadLine();
                for (int j = 0; j < 3; j++)
                {
                    Console.WriteLine("Введiть " + (j + 1) + " оцiнку з математики цього студента: ");
                    string input = Console.ReadLine();
                    math[j, i] = is_number(input);
                }
                for (int j = 0; j < 3; j++)
                {
                    Console.WriteLine("Введiть " + (j + 1) + " оцiнку з фiзики цього студента: ");
                    string input = Console.ReadLine();
                    physics[j, i] = is_number(input);
                }
                for (int j = 0; j < 3; j++)
                {
                    Console.WriteLine("Введiть " + (j + 1) + " оцiнку з хiмiї цього студента: ");
                    string input = Console.ReadLine();
                    chemistry[j, i] = is_number(input);
                }
                for (int j = 0; j < 3; j++)
                {
                    Console.WriteLine("Введiть " + (j + 1) + " оцiнку з iсторiї цього студента: ");
                    string input = Console.ReadLine();
                    history[j, i] = is_number(input);
                }
                for (int j = 0; j < 3; j++)
                {
                    Console.WriteLine("Введiть " + (j + 1) + " оцiнку з англiйської мови цього студента: ");
                    string input = Console.ReadLine();
                    english[j, i] = is_number(input);
                }
                Console.WriteLine();
            }

            double[,] a = new double[5, n];
            for (int i = 0; i < n; i++)
            {
                a[0, i] = Average(math, i);
            }
            for (int i = 0; i < n; i++)
            {
                a[1, i] = Average(physics, i);
            }
            for (int i = 0; i < n; i++)
            {
                a[2, i] = Average(chemistry, i);
            }
            for (int i = 0; i < n; i++)
            {
                a[3, i] = Average(history, i);
            }
            for (int i = 0; i < n; i++)
            {
                a[4, i] = Average(english, i);
            }

            for (int i = 0; i < n; i++)
            {
                Console.WriteLine("Прiзвище\tМатематика\t\tФiзика\t\tХiмiя\t\tIсторiя\t\tАнглiйська мова");
                Console.WriteLine("{0}\t\t{1}, {2}, {3}\t\t\t{4}, {5}, {6}\t\t{7}, {8}, {9}\t\t{10}, {11}, {12}\t\t{13}, {14}, {15}", lastname[i], math[0, i], math[1, i], math[2, i], physics[0, i], physics[1, i], physics[2, i], chemistry[0, i], chemistry[1, i], chemistry[2, i], history[0, i], history[1, i], history[2, i], english[0, i], english[1, i], english[2, i]);
                Console.WriteLine("Середнi бали:\t{0:F1}\t\t\t{1:F1}\t\t{2:F1}\t\t{3:F1}\t\t{4:F1}", a[0, i], a[1, i], a[2, i], a[3, i], a[4, i]);
                Console.WriteLine();
            }
        }
    }

   class Program
    {
        static void Main(string[] args)
        {
            Student student = new Student();
            student.Print();
        }
    }
}