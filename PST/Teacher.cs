using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PST
    /// <summary>
    /// Блин, короче, вроде правильно, больше не хочу видеть это
    /// </summary>
{

    public class Teacher : Person
    {
        public List<Student> Students { get; set; } = new List<Student>();
        public override string ToString()
        {
            return base.ToString() + $", Студенты: {Students.Count}";
        }
        public Teacher(string name, int age) : base(name, age)
        {
        }
        public override bool Equals(object obj)
        {
            var teacher = obj as Teacher;
            return teacher != null &&
                   base.Equals(obj) &&
                   Students.SequenceEqual(teacher.Students);
        }
        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = base.GetHashCode();
                foreach (var student in Students)
                {
                    hashCode = (hashCode * 397) ^ student.GetHashCode();
                }
                return hashCode;
            }
        }
        public static Teacher RandomTeacher()
        {
            Random rnd = new Random();
            string[] names = new string[] { "Евгений Александрович)))", "Усман Убдалишиша", "Халид Кашимири", "Хидир Карауитта", "Измаиль Ахмад Канабауи" };
            int age = rnd.Next(25, 67);
            Teacher randomTeacher = new Teacher
            (names[rnd.Next(names.Length)], age);
            return randomTeacher;
        }
    }
}
