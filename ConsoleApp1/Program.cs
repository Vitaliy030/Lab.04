using System;

namespace ConsoleApp1
{
    public class Student
    {
        private string Name;
        private string LastName;
        private string Group;
        private int Year;
        private string Address;
        private string Passport;
        private int Age;
        private string Telephone;
        private int Rating;

        public string name
        {
            get
            {
                return Name;
            }
            set
            {
                Name = value;
            }
        }
        public string lastname
        {
            get
            {
                return LastName;
            }
            set
            {
                LastName = value;
            }
        }
        public string group
        {
            get
            {
                return Group;
            }
            set
            {
                Group = value;
            }
        }
        public int year
        {
            get
            {
                return Year;
            }
            set
            {
                Year = value;
            }
        }
        public string address
        {
            get
            {
                return Address;
            }
            set
            {
                Address = value;
            }
        }
        public string passport
        {
            get
            {
                return Passport;
            }
            set
            {
                Passport = value;
            }
        }
        public int age
        {
            get
            {
                return Age;
            }
            set
            {
                Age = value;
            }
        }
        public string telephone
        {
            get
            {
                return Telephone;
            }
            set
            {
                Telephone = value;
            }
        }
        public int rating
        {
            get
            {
                return Rating;
            }
            set
            {
                Rating = value;
            }
        }

        public Student() { }

        public string StudentRating(int R)
        {
            string s;
            if (R >= 90)
                s = "Congratulations to the excellent student!";
            else if (R >= 75)
                s = "You can learn better!";
            else
                s = "It is worth paying more attention to learning!";

            return s;
        }

        public void Print(int R)
        {
            Console.WriteLine("Name: " + Name);
            Console.WriteLine("Last Name: " + LastName);
            Console.WriteLine("Group: " + Group);
            Console.WriteLine("Year: " + Year);
            Console.WriteLine("Address: " + Address);
            Console.WriteLine("Passport: " + Passport);
            Console.WriteLine("Age: " + Age);
            Console.WriteLine("Telephone: " + Telephone);
            Console.WriteLine("Rating: " + Rating);
            Console.WriteLine();
            Console.WriteLine(StudentRating(R));
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Student s1 = new Student();

            s1.name = "Вiталiй";
            s1.lastname = "Романко";
            s1.group = "IT-11";
            s1.year = 2019;
            s1.address = "208 Columbus St, Hicksville, OH, 43526";
            s1.passport = "9003";
            s1.age = 18;
            s1.telephone = "(419) 542-5484";
            s1.rating = 89;

            s1.Print(s1.rating);
        }
    }
}