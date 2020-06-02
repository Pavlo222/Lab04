using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Drawing;
using System.IO;


namespace Lab04_3
{
    public class TelephonBook
    {
        public string Name { get; set; }

        public string LastName { get; set; }

        public string SurName { get; set; }

        public string Adress { get; set; }

        public double Telephon { get; set; }

        public void lab4_3()
        {
            string path = "";
            List<TelephonBook> telbook = new List<TelephonBook>();
            Console.WriteLine("Ввести шлях до файлу '' або створити новий файл");
            path = Console.ReadLine();
            try
            {
                telbook = ReadData(path);
            }
            catch
            {
                path = "TelephonDovidnic.txt";
            }
            bool True = true;
            while (True)
            {
                Console.Clear();
                Console.WriteLine("Головне меню:\na-додавання записiв;\ne-редагування записiв;\nd– знищення записiв;\np-виведення iнформацiї з файла на екран;\ns-пошук потрiбної iнформацiї за конкретною ознакою (прiзвище);\nb-сортування за рiзними полями (телефон);\nx-вихiд;");
                var press = Console.ReadKey().Key;
                if (press.ToString() == "X")
                {
                    True = false;
                }
                if (press.ToString() == "E")
                {
                    Console.WriteLine();
                    EditData(telbook);
                    SaveData(telbook, path);
                }
                if (press.ToString() == "D")
                {
                    Console.WriteLine();
                    DelData(telbook);
                    SaveData(telbook, path);
                }
                if (press.ToString() == "P")
                {
                    Console.WriteLine();
                    ShowTable(telbook);
                    Console.WriteLine("Натиснiть будьяку кнопку для повернення в головне меню");
                    Console.ReadKey();
                }
                if (press.ToString() == "S")
                {
                    Console.WriteLine();
                    Seach(telbook);
                    SaveData(telbook, path);
                }
                if (press.ToString() == "A")
                {
                    Console.WriteLine();
                    AddNew(telbook);
                    SaveData(telbook, path);
                }
                if (press.ToString() == "B")
                {
                    Console.WriteLine();
                    Sort(telbook);
                    ShowTable(telbook);
                    SaveData(telbook, path);
                    Console.WriteLine("Натиснiть будьяку кнопку для повернення в головне меню");
                    Console.ReadKey();
                }
            }

        }
        static string PS(int count)
        {
            string s = "";
            for (int i = 0; i < count; i++)
            {
                s += " ";
            }
            return s;
        }
        static void ShowTable(List<TelephonBook> Telbook)
        {
            Console.Clear();
            int dg = 0;
            int MaxLN = 15;
            int MaxN = 12;
            int MaxSN = 15;
            int MaxA = 30;
            int MaxT = 12;
            Console.WriteLine("|   №   |   Прiзвище    |    Iм'я    |  По батьковi  |            Адресса           |   Телефон  | ");
            foreach (TelephonBook g in Telbook)
            {
                dg++;
                int nln = MaxLN - Convert.ToString(g.LastName).Length;
                int nn = MaxN - Convert.ToString(g.Name).Length;
                int nsn = MaxSN - Convert.ToString(g.SurName).Length;
                int na = MaxA - Convert.ToString(g.Adress).Length;
                int nt = MaxT - Convert.ToString(g.Telephon).Length;
                Console.Write("| {0,6}", dg);
                Console.WriteLine("|" + Convert.ToString(g.LastName) + PS(nln) + "|" + Convert.ToString(g.Name) + PS(nn) + "|" +
                    Convert.ToString(g.SurName) + PS(nsn) + "|" + Convert.ToString(g.Adress) + PS(na) + "|" + Convert.ToString(g.Telephon) + PS(nt) + "|");
            }

        }
        static List<TelephonBook> ReadData(string path)
        {
            List<TelephonBook> g = new List<TelephonBook>();

            string text = "";
            using (StreamReader sr = new StreamReader(path))
            {
                foreach (char ae in sr.ReadToEnd())
                {
                    if (!char.IsControl(ae))
                    {
                        text = text + ae;
                    }
                }
            }
            string[] Dates = text.Split('│');
            foreach (string s in Dates)
            {
                string[] MetaDete = s.Split('|');
                if (MetaDete.Length > 4)
                {
                    TelephonBook d = new TelephonBook
                    {
                        LastName = MetaDete[0],
                        Name = MetaDete[1],
                        SurName = MetaDete[2],
                        Adress = MetaDete[3],
                        Telephon = Convert.ToInt64(MetaDete[4]),
                    };
                    g.Add(d);
                }
            }
            return g;
        }
        static void SaveData(List<TelephonBook> Data, string path)
        {
            using (StreamWriter sw = new StreamWriter(path, false, System.Text.Encoding.Default))
            {
                foreach (TelephonBook g in Data)
                {

                    sw.WriteLine(g.LastName + "|" + g.Name + "|" + g.SurName + "|" + g.Adress + "|" + g.Telephon + "│");

                }
            }
        }
        static void DelData(List<TelephonBook> Data)
        {
            Console.Clear();
            TelephonBook Choosen = new TelephonBook();
            ShowTable(Data);
            Console.WriteLine("Введiть порятковий номер поля якого ви хочете видалити: ");
            int Num = Convert.ToInt32(Console.ReadLine());
            int hj = 0;

            foreach (TelephonBook g in Data)
            {
                hj++;
                if (hj == Num)
                {
                    Choosen = g;
                }
            }
            if (Choosen.Name != "")
            {
                Console.WriteLine();
                Data.Remove(Choosen);
            }
        }
        static void EditData(List<TelephonBook> Data)
        {
            Console.Clear();
            ShowTable(Data);
            Console.WriteLine("Введiть порятковий номер поля якого ви хочете редагувати: ");
            int Num = Convert.ToInt32(Console.ReadLine());
            int hj = 0;
            TelephonBook Choosen = new TelephonBook();
            foreach (TelephonBook g in Data)
            {
                hj++;
                if (hj == Num)
                {
                    Choosen = g;
                }
            }
            if (Choosen.Name != "")
            {
                Console.WriteLine();
                Console.WriteLine("1)Редагування прiзвище\n2)Редагування iм'я\n3)Редагування по батьковi\n4)Редагування адресси\n5)Редагування номера телефону");
                char key = Console.ReadKey().KeyChar;
                Console.WriteLine("\nВведiть нове значення:");
                try
                {
                    if (key == '1')
                    {

                        Choosen.LastName = Console.ReadLine();
                    }
                    if (key == '2')
                    {

                        Choosen.Name = Console.ReadLine();
                    }
                    if (key == '3')
                    {

                        Choosen.SurName = Console.ReadLine();
                    }
                    if (key == '4')
                    {
                        Choosen.Adress = Console.ReadLine();
                    }
                    if (key == '5')
                    {
                        Choosen.Telephon = Convert.ToInt64(Console.ReadLine());
                    }
                }
                catch
                {
                    Console.WriteLine("Нове значення задано не коректно");
                }

            }
            else
            {
                Console.WriteLine("Не має.");
            }

        }
        static void AddNew(List<TelephonBook> Data)
        {
            Console.Clear();
            Console.WriteLine("Режим додавання: ");
            TelephonBook neww = new TelephonBook();
            Console.WriteLine("Введiть прiзвище");
            neww.LastName = Console.ReadLine();
            Console.WriteLine("Введiть iм'я");
            neww.Name = Console.ReadLine();
            Console.WriteLine("Введiть по батьковi");
            neww.SurName = Console.ReadLine();
            Console.WriteLine("Введiть адресс");
            neww.Adress = Console.ReadLine();
            Console.WriteLine("Введiть номер телефона");
            neww.Telephon = Convert.ToInt64(Console.ReadLine());
            Data.Add(neww);
        }
        static void Seach(List<TelephonBook> Data)
        {
            int MaxLN = 15;
            int MaxN = 12;
            int MaxSN = 15;
            int MaxA = 30;
            int MaxT = 12;
            int dg = 0;
            Console.Clear();
            Console.WriteLine("Введiть прiзвище за яким потрiбно шукати");
            string s = Console.ReadLine();
            foreach (TelephonBook g in Data)
            {
                dg++;
                if (g.LastName == s)
                {
                    Console.WriteLine("|   №   |   Прiзвище    |    Iм'я    |  По батьковi  |            Адресса           |   Телефон  | ");
                    int nln = MaxLN - Convert.ToString(g.LastName).Length;
                    int nn = MaxN - Convert.ToString(g.Name).Length;
                    int nsn = MaxSN - Convert.ToString(g.SurName).Length;
                    int na = MaxA - Convert.ToString(g.Adress).Length;
                    int nt = MaxT - Convert.ToString(g.Telephon).Length;
                    Console.Write("| {0,6}", dg);
                    Console.WriteLine("|" + Convert.ToString(g.LastName) + PS(nln) + "|" + Convert.ToString(g.Name) + PS(nn) + "|" +
                        Convert.ToString(g.SurName) + PS(nsn) + "|" + Convert.ToString(g.Adress) + PS(na) + "|" + Convert.ToString(g.Telephon) + PS(nt) + "|");
                }
            }
            Console.WriteLine("Натиснiть будьяку кнопку для повернення до головного меню");
            Console.ReadLine();
        }
        static void Sort(List<TelephonBook> Data)
        {
            for (int i = 0; i < Data.Count; i++)
            {
                for (int k = 0; k < Data.Count; k++)
                {
                    if (Data[i].Telephon > Data[k].Telephon)
                    {
                        TelephonBook temp = Data[k];
                        Data[k] = Data[i];
                        Data[i] = temp;
                    }
                }
            }
        }
    }
    public class Program
    {
        static public void Main(string[] args)
        {
            TelephonBook telbook = new TelephonBook();
            telbook.lab4_3();
        }
    }
}
