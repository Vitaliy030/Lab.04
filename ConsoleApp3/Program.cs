using System;
using System.IO;

namespace ConsoleApp3
{
    public class NAME
    {
        private string[] NamE;
        public NAME(int N)
        {
            NamE = new string[N];
        }

        public string this[int Index]
        {
            get
            {
                return NamE[Index];
            }
            set
            {
                NamE[Index] = value;
            }
        }
    }

    public class Selling_Price
    {
        private int[] selling_Price;
        public Selling_Price(int N)
        {
            selling_Price = new int[N];
        }

        public int this[int Index]
        {
            get
            {
                return selling_Price[Index];
            }
            set
            {
                selling_Price[Index] = value;
            }
        }
    }

    public class Product_range
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

        private string Product_number;
        private string Name;
        private int Weight;
        private int Cost_of_production;
        private int Selling_price;

        public string product_number
        {
            get
            {
                return Product_number;
            }
            set
            {
                Product_number = value;
            }
        }
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
        public int weight
        {
            get
            {
                return Weight;
            }
            set
            {
                Weight = value;
            }
        }
        public int cost_of_production
        {
            get
            {
                return Cost_of_production;
            }
            set
            {
                Cost_of_production = value;
            }
        }
        public int selling_price
        {
            get
            {
                return Selling_price;
            }
            set
            {
                Selling_price = value;
            }
        }

        public Product_range() { }
        public Product_range(string product_number, string name, int weight, int cost_of_production, int selling_price)
        {
            this.product_number = product_number;
            this.name = name;
            this.weight = weight;
            this.cost_of_production = cost_of_production;
            this.selling_price = selling_price;
        }

        public void Add()
        {
            Product_range np = new Product_range();
            Console.WriteLine("\nВведiть номер товару(9 чифр): ");
            np.product_number = Console.ReadLine();
            Console.WriteLine("Введiть назву товару: ");
            np.name = Console.ReadLine();
            Console.WriteLine("Введiть вагу товару (в грамах): ");
            np.weight = is_number(Console.ReadLine());
            Console.WriteLine("Введiть собiвартiсть виробництва товару (в гривнях): ");
            np.cost_of_production = is_number(Console.ReadLine());
            Console.WriteLine("Введiть цiну продажу товару (в гривнях): ");
            np.selling_price = is_number(Console.ReadLine());

            Console.WriteLine("\nЯкщо ви бажаєте зберегти змiни то натиснiть Enter, якщо нi, то будь-яку iншу клавiшу.");
            while (true)
            {
                if (Console.ReadKey().Key == ConsoleKey.Enter)
                {
                    using (StreamWriter f = new StreamWriter("D:\\ІТ\\Програмування\\Програми\\Lab.4\\ConsoleApp3\\Product range.txt", true))
                        f.WriteLine("{0}\t\t{1}\t\t{2}\t\t\t{3}\t\t\t\t\t{4}", np.product_number, np.name, np.weight, np.cost_of_production, np.selling_price);
                    Console.WriteLine("Змiни збережено!\n\n");
                    break;
                }
                else
                {
                    Console.WriteLine("\nЗмiни не збережено!\n\n");
                    break;
                }
            }
        }

        public void Edit()
        {
            Product_range ep = new Product_range();
            int count = File.ReadAllLines("D:\\ІТ\\Програмування\\Програми\\Lab.4\\ConsoleApp3\\Product range.txt").Length;
            Console.WriteLine("\nВведiть порядковий новер товару, де ви хочете здiйснити редагування: ");
            int n = is_number(Console.ReadLine());
            while (n > count - 1 || n < 1)
            {
                Console.WriteLine("Ви ввели некоректний порядковий номер, введiть ще раз: ");
                n = is_number(Console.ReadLine());
            }

            string[] s0 = File.ReadAllLines("D:\\ІТ\\Програмування\\Програми\\Lab.4\\ConsoleApp3\\Product range.txt");
            string s = s0[n];
            int u = s.Length;

            int k = 0;
            foreach (char c in s)
            {
                if (Char.IsWhiteSpace(c))
                    break;
                k++;
            }
            ep.product_number = s.Substring(0, k);

            int l = 1;
            for (int i = k + 1; i < u; i++)
            {
                if (Char.IsWhiteSpace(s[i]))
                    k++;
                else
                    break;
            }

            k++;
            for (int i = k + 1; i < u; i++)
            {
                if (Char.IsWhiteSpace(s[i]))
                    break;
                l++;
            }
            ep.name = s.Substring(k, l);

            k += l;
            l = 1;
            for (int i = k; i < u; i++)
            {
                if (Char.IsWhiteSpace(s[i]))
                    k++;
                else
                    break;
            }

            for (int i = k; i < u; i++)
            {
                if (Char.IsWhiteSpace(s[i]))
                    break;
                l++;
            }
            ep.weight = Convert.ToInt32(s.Substring(k, l));

            k = k + l - 1;
            l = 1;
            for (int i = k; i < u; i++)
            {
                if (Char.IsWhiteSpace(s[i]))
                    k++;
                else
                    break;
            }

            for (int i = k; i < u; i++)
            {
                if (Char.IsWhiteSpace(s[i]))
                    break;
                l++;
            }
            ep.cost_of_production = Convert.ToInt32(s.Substring(k, l));

            k = k + l - 1;
            l = 1;
            for (int i = k; i < u; i++)
            {
                if (Char.IsWhiteSpace(s[i]))
                    k++;
                else
                    break;
            }

            for (int i = k; i < u; i++)
            {
                if (Char.IsWhiteSpace(s[i]))
                    break;
                l++;
            }
            ep.selling_price = Convert.ToInt32(s.Substring(k, l - 1));

            Console.WriteLine("Введiть порядковий номер стовпчика, елемент якого хочете виправити: ");
            int n0 = is_number(Console.ReadLine());
            while (n0 > 5 || n0 < 1)
            {
                Console.WriteLine("Ви ввели некоректний порядковий номер, введiть ще раз: ");
                n0 = is_number(Console.ReadLine());
            }

            if (n0 == 1)
            {
                Console.WriteLine("Номер виробу: ");
                ep.product_number = Console.ReadLine();
            }
            else if (n0 == 2)
            {
                Console.WriteLine("Назва: ");
                ep.name = Console.ReadLine();
            }
            else if (n0 == 3)
            {
                Console.WriteLine("Вага(г): ");
                ep.weight = is_number(Console.ReadLine());
            }
            else if (n0 == 4)
            {
                Console.WriteLine("Собiвартiсть виробництва(грн.): ");
                ep.cost_of_production = is_number(Console.ReadLine());
            }
            else if (n0 == 5)
            {
                Console.WriteLine("Цiна продажу(грн.): ");
                ep.selling_price = is_number(Console.ReadLine());
            }

            while (true)
            {
                Console.WriteLine("Якщо ви бажаєте продовжити редагування в даному рядку, то натиснiть на будь-яку клавiшу, якщо нi, то натиснiть Spacebar.");
                if (Console.ReadKey().Key == ConsoleKey.Spacebar)
                    break;
                else
                {
                    Console.WriteLine("\nВведiть порядковий номер стовпчика, елемент якого хочете виправити: ");
                    n0 = is_number(Console.ReadLine());
                    while (n0 > 5 || n0 < 1)
                    {
                        Console.WriteLine("Ви ввели некоректний порядковий номер, введiть ще раз: ");
                        n0 = is_number(Console.ReadLine());
                    }

                    if (n0 == 1)
                    {
                        Console.WriteLine("Номер виробу: ");
                        ep.product_number = Console.ReadLine();
                    }
                    else if (n0 == 2)
                    {
                        Console.WriteLine("Назва: ");
                        ep.name = Console.ReadLine();
                    }
                    else if (n0 == 3)
                    {
                        Console.WriteLine("Вага(г): ");
                        ep.weight = is_number(Console.ReadLine());
                    }
                    else if (n0 == 4)
                    {
                        Console.WriteLine("Собiвартiсть виробництва(грн.): ");
                        ep.cost_of_production = is_number(Console.ReadLine());
                    }
                    else if (n0 == 5)
                    {
                        Console.WriteLine("Цiна продажу(грн.): ");
                        ep.selling_price = is_number(Console.ReadLine());
                    }
                }
            }

            s = ep.product_number + "\t\t" + ep.name + "\t\t" + ep.weight + "\t\t\t" + ep.cost_of_production + "\t\t\t\t\t" + ep.selling_price;

            Console.WriteLine("\nЯкщо ви бажаєте зберегти змiни, то натиснiть Enter, якщо нi, то будь-яку iншу клавiшу.");
            while (true)
            {
                if (Console.ReadKey().Key == ConsoleKey.Enter)
                {
                    s0[n] = s;
                    using (StreamWriter f = new StreamWriter("D:\\ІТ\\Програмування\\Програми\\Lab.4\\ConsoleApp3\\Product range.txt"))
                        for (int i = 0; i < count; i++)
                            f.WriteLine(s0[i]);
                    Console.WriteLine("Змiни збережено!\n\n");
                    break;
                }
                else
                {
                    Console.WriteLine("\nЗмiни не збережено!\n\n");
                    break;
                }
            }
        }

        public void Remove()
        {
            int count = File.ReadAllLines("D:\\ІТ\\Програмування\\Програми\\Lab.4\\ConsoleApp3\\Product range.txt").Length;
            Console.WriteLine("\nВведiть порядковий новер товару, який ви хочете видалити: ");
            int n = is_number(Console.ReadLine());
            while (n > count - 1 || n < 1)
            {
                Console.WriteLine("Ви ввели некоректний порядковий номер, введiть ще раз: ");
                n = is_number(Console.ReadLine());
            }

            string[] s0 = File.ReadAllLines("D:\\ІТ\\Програмування\\Програми\\Lab.4\\ConsoleApp3\\Product range.txt");
            for (int i = n; i < count - 1; i++)
                s0[i] = s0[i + 1];

            Console.WriteLine("\nЯкщо ви бажаєте зберегти змiни то натиснiть Enter, якщо нi, то будь-яку iншу клавiшу.");
            while (true)
            {
                if (Console.ReadKey().Key == ConsoleKey.Enter)
                {
                    using (StreamWriter f = new StreamWriter("D:\\ІТ\\Програмування\\Програми\\Lab.4\\ConsoleApp3\\Product range.txt"))
                        for (int i = 0; i < count - 1; i++)
                            f.WriteLine(s0[i]);
                    Console.WriteLine("Змiни збережено!\n\n");
                    break;
                }
                else
                {
                    Console.WriteLine("\nЗмiни не збережено!\n\n");
                    break;
                }
            }
        }

        public void Output()
        {
            string[] s0 = File.ReadAllLines("D:\\ІТ\\Програмування\\Програми\\Lab.4\\ConsoleApp3\\Product range.txt");
            int count = File.ReadAllLines("D:\\ІТ\\Програмування\\Програми\\Lab.4\\ConsoleApp3\\Product range.txt").Length;

            Console.WriteLine("\nЯкщо ви бажаєте вивести весь список, то натиснiть Enter, якщо тiльки один рядок, то будь-яку iншу клавiшу.\n");
            if (Console.ReadKey().Key == ConsoleKey.Enter)
            {
                for (int i = 0; i < count; i++)
                    Console.WriteLine(s0[i]);
            }
            else
            {
                Console.WriteLine("\nВведiть порядковий новер товару, який ви хочете вивести: ");
                int n = is_number(Console.ReadLine());
                while (n > count - 1 || n < 1)
                {
                    Console.WriteLine("Ви ввели некоректний порядковий номер, введiть ще раз: ");
                    n = is_number(Console.ReadLine());
                }
                string s = s0[n];
                Console.WriteLine("\nProduct number:\t\tName:\t\tWeight (g):\t\tProduction cost (UAH):\t\t\tSale price (UAH):\n" + s);
            }
            Console.WriteLine("\n");
        }

        public void Search()
        {
            string[] s0 = File.ReadAllLines("D:\\ІТ\\Програмування\\Програми\\Lab.4\\ConsoleApp3\\Product range.txt");
            int count = File.ReadAllLines("D:\\ІТ\\Програмування\\Програми\\Lab.4\\ConsoleApp3\\Product range.txt").Length;

            Selling_Price pr = new Selling_Price(count - 1);

            int u;
            int k = 0;
            for (int i = 1; i < count; i++)
            {
                string s = s0[i];
                u = s.Length;
                for (int j = u - 1; j > 0; j--)
                    if (Char.IsWhiteSpace(s[j]))
                    {
                        k = j - 1;
                        break;
                    }
                pr[i - 1] = Convert.ToInt32(s.Substring(k, u - k));
            }

            Console.WriteLine("\nВведiть цiну продажу товару, який бажаєте найти в списку:");
            int n = is_number(Console.ReadLine());

            bool h = false;
            for (int i = 0; i < count - 1; i++)
                if (pr[i] == n)
                {
                    i++;
                    if (h == false)
                        Console.WriteLine("\nProduct number:\t\tName:\t\tWeight (g):\t\tProduction cost (UAH):\t\t\tSale price (UAH):");
                    Console.WriteLine(s0[i]);
                    i--;
                    h = true;
                }
            if (h == false)
                Console.WriteLine("У списку немає товарiв з такою цiною продажу!");
            Console.WriteLine("\n");
        }

        public void Sort()
        {
            string[] s0 = File.ReadAllLines("D:\\ІТ\\Програмування\\Програми\\Lab.4\\ConsoleApp3\\Product range.txt");
            int count = File.ReadAllLines("D:\\ІТ\\Програмування\\Програми\\Lab.4\\ConsoleApp3\\Product range.txt").Length;

            NAME ne = new NAME(count - 1);

            int u;
            int k = 0;
            int l = 1;
            string[] ne0 = new string[count - 1];
            for (int j = 1; j < count; j++)
            {
                string s = s0[j];
                u = s.Length;

                foreach (char c in s)
                {
                    if (Char.IsWhiteSpace(c))
                        break;
                    k++;
                }
                
                for (int i = k + 1; i < u; i++)
                {
                    if (Char.IsWhiteSpace(s[i]))
                        k++;
                    else
                        break;
                }

                k++;
                for (int i = k + 1; i < u; i++)
                {
                    if (Char.IsWhiteSpace(s[i]))
                        break;
                    l++;
                }
                ne[j - 1] = s.Substring(k, l);
                ne0[j - 1] = s.Substring(k, l);
                k = 0;
                l = 1;
            }

            int k1;
            int k2;
            string t0;
            string str = "Aa Bb Cc Dd Ee Ff Gg Hh Ii Jj Kk Ll Mm Nn Oo Pp Qq Rr Ss Tt Uu Vv Ww Xx Yy Zz";
            for (int i0 = 0; i0 < count; i0++)
            {
                for (int i = 0; i < count - 2; i++)
                {
                    k1 = str.Length + 5;
                    k2 = str.Length + 5;
                    string t1 = ne0[i];
                    string t2 = ne0[i + 1];
                    if (t1.Length > t2.Length)
                    {
                        for (int j1 = 0; j1 < t2.Length - 1; j1++)
                        {
                            for (int z = 0; z < str.Length -1; z++)
                                if (t1[j1] == str[z])
                                {
                                    k1 = z;
                                    break;
                                }
                                else if (t2[j1] == str[z])
                                {
                                    k2 = z;
                                    break;
                                }
                            if (k1 > k2)
                            {
                                t0 = t1;
                                t1 = t2;
                                t2 = t0;
                                break;
                            }
                            else
                                break;
                        }

                        ne0[i] = t1;
                        ne0[i + 1] = t2;
                    }
                    else
                    {
                        for (int j2 = 0; j2 < t1.Length - 1; j2++)
                        {
                            for (int z = 0; z < str.Length - 1; z++)
                                if (t1[j2] == str[z])
                                {
                                    k1 = z;
                                    break;
                                }
                                else if (t2[j2] == str[z])
                                {
                                    k2 = z;
                                    break;
                                }
                            if (k1 > k2)
                            {
                                t0 = t1;
                                t1 = t2;
                                t2 = t0;
                                break;
                            }
                            else
                                break;
                        }

                        ne0[i] = t1;
                        ne0[i + 1] = t2;
                    }
                }
            }

            Console.WriteLine("\nЯкщо ви бажаєте зберегти змiни то натиснiть Enter, якщо нi, то будь-яку iншу клавiшу.");
            while (true)
            {
                if (Console.ReadKey().Key == ConsoleKey.Enter)
                {
                    using (StreamWriter f = new StreamWriter("D:\\ІТ\\Програмування\\Програми\\Lab.4\\ConsoleApp3\\Product range.txt"))
                    {
                        f.WriteLine("Product number:\t\tName:\t\tWeight (g):\t\tProduction cost (UAH):\t\t\tSale price (UAH):");
                        for (int i = 0; i < count - 1; i++)
                            for (int j = 0; j < count - 1; j++)
                                if (ne0[i] == ne[j])
                                    f.WriteLine(s0[j + 1]);
                    }
                    Console.WriteLine("Змiни збережено!\n\n");
                    break;
                }
                else
                {
                    Console.WriteLine("\nЗмiни не збережено!\n\n");
                    break;
                }
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Product_range p = new Product_range();

            while (true)
            {
                Console.WriteLine("Натиснiть на одну з вказаних клавiш, щоб вибрати режим роботи: ");
                Console.WriteLine("Додавання записiв - Enter");
                Console.WriteLine("Редагування записiв - E");
                Console.WriteLine("Знищення записiв - R");
                Console.WriteLine("Виведення iнформацiї з файла на екран - O");
                Console.WriteLine("Пошук потрiбної iнформацiї за конкретною ознакою - S");
                Console.WriteLine("Сортування за назвою товару - Tab");
                Console.WriteLine("Вихiд з програми - будь-яка iнша клавiша");

                ConsoleKeyInfo cki;
                cki = Console.ReadKey(true);
                if (cki.Key == ConsoleKey.Enter)
                    p.Add();
                else if (cki.Key == ConsoleKey.E)
                    p.Edit();
                else if (cki.Key == ConsoleKey.R)
                    p.Remove();
                else if (cki.Key == ConsoleKey.O)
                    p.Output();
                else if (cki.Key == ConsoleKey.S)
                    p.Search();
                else if (cki.Key == ConsoleKey.Tab)
                    p.Sort();
                else
                    break;
            }
        }
    }
}