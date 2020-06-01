using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lab04_1
{
    
    public class Student
    {
        
        //поля класу
        private string Name;
        private string LastName;
        private string Group;
        private int Year;
        private string Adress;
        private string Passport;
        private int Age;
        private string Telephon;
        private int Rating;
        public Student()
        {
            //конструктор без параметрів
        }
        public int StudentRating(int R)
        {
            int s;
            if(R>=90)
            {
                s = 1;
            }
            else if(R>=75)
            {
                s = 2;
            }
            else
            {
                s = 3;
            }
            return s;
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
        public string adress
        {
            get
            {
                return Adress;
            }
            set
            {
                Adress = value;
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
        public string telephon
        {
            get
            {
                return Telephon;
            }
            set
            {
                Telephon= value;
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
    }
    class Program
    {
        static void Main(string[] args)
        {
            int s;
            Student student = new Student();
            Console.Write("Iм'я: ");
            student.name = Console.ReadLine();
            Console.Write("Прiзвище: ");
            student.lastname = Console.ReadLine();
            Console.Write("Група: ");
            student.group = Console.ReadLine();
            Console.Write("Рiк: ");
            student.year = int.Parse(Console.ReadLine());
            Console.Write("Адрес: ");
            student.adress = Console.ReadLine();
            Console.Write("Паспорт: ");
            student.passport = Console.ReadLine();
            Console.Write("Вiк: ");
            student.age = int.Parse(Console.ReadLine());
            Console.Write("Телефон: ");
            student.telephon = Console.ReadLine();
            Console.Write("Середний бал: ");
            student.rating = int.Parse(Console.ReadLine());
            s=student.StudentRating(student.rating);
            switch(s)
            {
                case 1: Console.WriteLine("\nВiтаємо вiдмiнника");break;
                case 2: Console.WriteLine("\nМожна вчитися краще"); break;
                case 3: Console.WriteLine("\nВарто бiльше уваги придiляти навчанню"); break;
            }
            Console.ReadKey();
        }
    }
}
