using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace IEnumerableTrain1
{
    class Program
    {
        static void Main(string[] args)
        {
            Library library = new Library();

            foreach (Book b in library)
            {
                Console.WriteLine(b.Name);
            }

            Console.ReadLine();
        }
    }

    class Book
    {
        public Book(string name)
        {
            this.Name = name;
        }
        public string Name { get; set; }
    }

    class Library : IEnumerable
    {
        private Book[] books;

        public Library()
        {
            books = new Book[] { new Book("Отцы и дети"), new Book("Война и мир"),
                new Book("Евгений Онегин") };
        }
        

        public int Length
        {
            get { return books.Length; }
        }

        public Book this[int index]
        {
            get
            {
                return books[index];
            }
            set
            {
                books[index] = value;
            }
        }

        // возвращаем перечислитель
        IEnumerator IEnumerable.GetEnumerator()
        {
            return books.GetEnumerator();
        }
    }
}
