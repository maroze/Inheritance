using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Inheritance
{
    public interface Post
    {
        string report();
    }
    public interface DropOutOf
    {
        string statement();
    }
    public interface Lessons
    {
        string discipline();
    }
public enum Dolj (){Assistant=0;
Lector = 1;
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
        public abstract string profile();
        
    }
    public class Kadrovik : Person, Post
    {
        public string report()
        {
            return "Кадровик";
        }
        public Kadrovik(string lastname, string name, string patronymic) : base(lastname, name, patronymic)
        {
            Lastname = lastname;
            Name = name;
            Patronymic = patronymic;
        }
        public override string profile()
        {
            return Lastname + " " + Name + " " + Patronymic ;
        }
        public string CreationStudent( string lastname, string name, string patronymic, string group)
        {
            var stud = new Student(lastname, name, patronymic, group);
            return lastname + " " + name + " " + patronymic + " " + group;
        }
        public string CreationTeacher( string lastname, string name, string patronymic, /*string post,*/ int exp)
        {
            string post;
            if (exp >= 3) { post = "Старший преподаватель"; }
            else { post = "Ассистент"; }
            var teach = new Teacher(lastname, name, patronymic);
            return lastname + " " + name + " " + patronymic + " " + post;
        }


    }
    public class Teacher : Person, Lessons
    {
        public string report(int exp)
        {
            string post;
            if (exp >= 3) { post = "Старший преподаватель"; }
            else { post = "Ассистент"; }
            return post;

        }
        public string discipline()
        {
            return "Проводит лекцию";
        }
        public Teacher(string Lastname, string Name, string Patronymic) : base(Lastname, Name, Patronymic)
        {
        }
        public override string profile()
        {
            return Lastname + " " + Name + " " + Patronymic;
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
        public override string profile()
        {
            return Lastname + " " + Name + " " + Patronymic + " " + Group;
        }
    }

    #endregion

    class Program
    {
        static void Main(string[] args)
        {
            var person = new Kadrovik("Антоненко", "Антон", "Антонович");
            Student student1 = new Student("Иванов", "Иван", "Иванович", "3 курс");
            Teacher teacher1 = new Teacher("Учителев", "Учитель", "Учителич");
            Console.WriteLine($"Student: {student1.profile()} {student1.statement()} \n" + $"Teacher: {teacher1.profile()} {teacher1.report(3)} {teacher1.discipline()} \n" + $"Kadrovik: {person.profile()} {person.report()} \n" + $"The Teacher created by the kadrovik: {person.CreationTeacher("Милос", "Рикардо", "Рикардович", 2)} \n" + $"The Student created by the kadrovik: {person.CreationStudent("Валерова", "Валерия", "Валеривна", "4 курс")}");

            Console.ReadLine();
        }
    }
}
