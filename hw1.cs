using System;
using System.Linq;
using System.Windows;

namespace WPFDataManagement
{
    public partial class MainWindow : Window
    {
        private Person[] people = new Person[0];
        private int idCounter = 1;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void AddPerson(string name, int age, string address)
        {
            Array.Resize(ref people, people.Length + 1);
            people[^1] = new Person { Id = idCounter++, Name = name, Age = age, Address = address };
        }

        private void DisplayPeople()
        {
            listBox.Items.Clear();
            foreach (var person in people)
                listBox.Items.Add($"{person.Id}: {person.Name}, {person.Age}, {person.Address}");
        }

        private void SortByAge()
        {
            Array.Sort(people, (x, y) => x.Age.CompareTo(y.Age));
        }

        private void SortByName()
        {
            Array.Sort(people, (x, y) => string.Compare(x.Name, y.Name, StringComparison.Ordinal));
        }

        private Person[] SearchByAge(int age)
        {
            return people.Where(p => p.Age == age).ToArray();
        }

        private Person[] SearchByName(string name)
        {
            return people.Where(p => p.Name.Equals(name, StringComparison.OrdinalIgnoreCase)).ToArray();
        }

        private void RemoveByName(string name)
        {
            people = people.Where(p => !p.Name.Equals(name, StringComparison.OrdinalIgnoreCase)).ToArray();
        }

        private void RemoveByAge(int age)
        {
            people = people.Where(p => p.Age != age).ToArray();
        }
    }

    public struct Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Address { get; set; }
    }
}
