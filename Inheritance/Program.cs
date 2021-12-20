using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Inheritance
{
    interface IFio
    {
        string GetFio();
    }
    interface IDolsnoct : IFio
    {
        string GetDol();
    }
    interface IGropp : IFio
    {
        string GetGropp();
    }
    interface ICreat : IDolsnoct
    {
        Student CreationStudent(string lastname, string name, string patronymic, string group);
        Teacher CreationTeacher(string lastname, string name, string patronymic, Prepod dolj);
    }
    interface Lessons : IDolsnoct
    {
        string discipline();
    }
    interface DropOutOf : IGropp
    {
        string statement();
    }


    public enum Prepod
    {
        Assistant = 0,
        StLecturer = 1
    }
    public abstract class Person
    {
        public string Lastname { get; set; }
        public string Name { get; set; }
        public string Patronymic { get; set; }
        public Person(string Lastname, string Name, string Patronymic)
        {
            this.Lastname = Lastname;
            this.Name = Name;
            this.Patronymic = Patronymic;

        }
        public string GetFio()
        {
            return Lastname + " " + Name + " " + Patronymic;
        }

    }
    public class Kadrovik : Worker, ICreat
    {
        public Kadrovik(string lastname, string name, string patronymic) : base(lastname, name, patronymic, "Кадровик")
        {

        }
        public Student CreationStudent(string lastname, string name, string patronymic, string group)
        {
            return new Student(lastname, name, patronymic, group);
             
        }
        public Teacher CreationTeacher(string lastname, string name, string patronymic, Prepod dolj)
        {
            return new Teacher(lastname, name, patronymic, dolj);
        }


    }
    public class Worker : Person
    {
        string dolj;
        public Worker(string lastname, string name, string patronymic, string dolj) : base(lastname, name, patronymic)
        {
            this.dolj = dolj;
        }
        public string GetDol()
        {
            return dolj;
        }
    }
    public class Teacher : Worker, Lessons
    {
        static string[] dol = new string[] { "Ассистент", "Старший преподаватель" };
        public string discipline()
        {
            return "Проводит лекцию";
        }
        public Teacher(string Lastname, string Name, string Patronymic, Prepod dolj) : base(Lastname, Name, Patronymic, dol[(int)dolj])
        {
        }
    }

    #region Student
    public class Student : Person, DropOutOf
    {
        public string statement()
        {
            return "Подал заявление на отчисление";
        }
        string Group { get; set; }
        public Student(string Lastname, string Name, string Patronymic, string Group) : base(Lastname, Name, Patronymic)
        {
            this.Group = Group;
        }
        public string GetGropp()
        {
            return Group;
        }
    }

    #endregion

    class Program
    {
        static void Main(string[] args)
        {
            Kadrovik one = new Kadrovik("Боб", "Губка", "Квадратные штаны");
            Student four = one.CreationStudent("Паук", "Человек", "Паутинович", "Членистоногие");
            Teacher five = one.CreationTeacher("Нибиру", "Снова", "Прилетает", Prepod.Assistant);
            Teacher two = new Teacher ("Наталья", "Морская", "Пехота", Prepod.StLecturer);
            Console.WriteLine($"{one.GetFio()} {one.GetDol()}\n" + $"{four.GetFio()} {four.GetGropp()} {four.statement()}\n" +
                $"{five.GetFio()} {five.GetDol()}\n" + $"{two.GetFio()} {two.GetDol()} {two.discipline()}\n");
            Console.ReadLine();
        }
    }
}
