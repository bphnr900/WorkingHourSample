using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkingHourSample.WorkModule.Models
{
    class TableProvider
    {
        public List<Person> Member { get; } = temp();

        /*
        public TableProvider()
        {
            var people = new List<Person>(
                Enumerable.Range(1, 100).Select(i => new Person
                {
                    Name = "田中 太郎" + i,
                    Gender = i % 2 == 0 ? Gender.Men : Gender.Women,
                    Age = 20 + i % 50,
                    AuthMember = i % 5 == 0
                }));
            //Member = people;
        }
        */

        static List<Person> temp()
        {
            var people = new List<Person>(
                Enumerable.Range(1, 100).Select(i => new Person
                {
                    Name = "田中 太郎" + i,
                    Gender = i % 2 == 0 ? Gender.Men : Gender.Women,
                    Age = 20 + i % 50,
                    AuthMember = i % 5 == 0
                }));
            return people;
        }
    }

    class Person
    {
        public string Name { get; set; }
        public Gender Gender { get; set; }
        public int Age { get; set; }
        public bool AuthMember { get; set; }
    }
    public enum Gender
    {
        None,
        Men,
        Women
    }
}
