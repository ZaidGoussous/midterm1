using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Testing
{
    class Program
    {
        static void Main(string[] args)
        {
            Book myBook = new Book(0, true); // 0 is important
            myBook.newAuthor("Robert Charette");
            myBook.newAuthor("Ciele Bronx");
            myBook.Title = "Never Deal with a Dragon";
            myBook.Publisher = "Roc Books";
            myBook.YearOfIssue = 1990;
            Console.WriteLine(myBook.IsAuthor("Ciele Bronx"));
            Console.WriteLine(myBook.IsAuthor("Leonardo DaVinci"));
            Console.WriteLine(myBook.Display());

            // testing filehandling class
            FileHandling myFileHandler = new FileHandling("booksfile.txt");

            // Console.WriteLine("#ofbooks:" + myFileHandler.NumberOfBooks());
           
            myFileHandler.WriteFileFromAuthor("Ciele Bronx");


            Console.ReadKey();
            Console.ReadKey();
        }
    }
}
