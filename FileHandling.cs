using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Testing
{
    class FileHandling
    {
        private string filename;
        private string Filename
        {
            get
            {
                return filename;
            }
            set
            {
                filename = value;
            }
        }
        private Book[] books;
        private Book[] Books
        {
            get
            {
                return books;
            }
            set
            {
                books = value;
            }
        }

        //NUMBER OF BOOKS WE HAVE IN FILE
        private int NumberOfBooks()
        {
            string[] lines = File.ReadAllLines(this.filename);
            int numberOfBooks = 0;
            for (int i = 0; i < lines.Length; i++)
            {

                if (lines[i]=="***")
                {
                numberOfBooks++;
                }
            }
            return numberOfBooks;
        }

        //FILE HANDLING
        public FileHandling(string filename)
        {
            this.filename = filename;
            string [] lines = File.ReadAllLines(this.filename);
            int numberOfBooks = this.NumberOfBooks();
            this.books = new Book[numberOfBooks];
            Book currentbook = new Book(0, true);
            int count = 0;
            for (int i = 0; i < lines.Length; i++)
            {
                string[] line = lines[i].Split('#');
                switch (lines[0])
                {
                    case "A":
                        string author = line[1].Trim();
                        currentbook.newAuthor(author);
                        break;

                    case "T":
                        string title = line[1].Trim();
                        currentbook.Title=title;
                        break;

                    case "P":
                        string publisher = line[1].Trim();
                        currentbook.Publisher = publisher;
                        break;

                    case "Y":
                        string yearOfIssue = line[1].Trim();  
                        int yearNumber = int.Parse(yearOfIssue);//Remember to parse the int
                        currentbook.YearOfIssue = yearNumber;
                        break;

                    case "R":
                        string readString = line[1].Trim();
                        bool readBool = readString == "read" ? true : false;
                        currentbook.ReadOrUnread=readBool;
                        break;

                    case "***":
                        this.books[count++] = currentbook;
                        currentbook = new Book(0, true);
                        break;

                    default:
                        Console.WriteLine("Error!");
                        break;
                }
            }
        }

        //NUMBER OF BOOKS IN QUESTIONED YEAR
        public int NumberInYear(int yearQuestioned)
        {
            int count = 0;
            for (int i = 0; i < this.books.Length; i++)
            {
                if (this.books[i].YearOfIssue== yearQuestioned)
                {
                    count++;
                }
            }
            return count;
        }//NUMBER OF UNREAD BOOKS
        private int NumberUnread()
        {
            int count = 0;
            for (int i = 0; i < this.books.Length; i++)
            {
                if (this.books[i].ReadOrUnread==false)
                {
                    count++;
                }
            }
            return count;
        }
        static Random random = new Random();

        //RANDOM UNREAD BOOK!
        public Book RandomUnread()
        {
            int[] unreadBookIndices = new int[this.books.Length];
            int lastBookIndex = 0;
            for (int i = 0; i < this.books.Length; i++)
            {
                if (this.books[i].ReadOrUnread == false)
                {
                    unreadBookIndices[lastBookIndex++] = i;
                }
            }
            int randomsIndex = random.Next(0, lastBookIndex);
            int indexOfUnreadBookRandomized = unreadBookIndices[randomsIndex];
            this.books[indexOfUnreadBookRandomized].ReadOrUnread = true;
            return this.books[indexOfUnreadBookRandomized];
        }
        public void WriteFileFromAuthor(string authorName)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < this.books.Length; i++)
            {
                if (this.books[i].IsAuthor(authorName))
                {
                    sb.Append(this.books[i].Display());
                    sb.Append(Environment.NewLine);
                }
            }
            File.WriteAllText(authorName + " .txt", sb.ToString());
        }

        public void SortYear()
        {
            for (int i = 0; i < this.books.Length; i++)
            {
                for (int j = 0; j < this.books.Length; j++)
                {
                    if (this.books[i].YearOfIssue < books[j].YearOfIssue)
                    {
                        Book temp = books[i];
                        books[i] = books[j];
                        books[j] = temp;
                    }
                }
            }
        }

        // mostAuthors() public Book method: returns a book that has most authors.
        public Book mostAuthors()
        {
            Book mostNumOfAuthors = books[0];
            for (int i = 1; i < books.Length; i++)
            {
                if (mostNumOfAuthors.NumberOfAuthors < books[i].NumberOfAuthors)
                {
                    mostNumOfAuthors = books[i];
                }
            }
            return mostNumOfAuthors;
        }

        public string Listing()
        {
            string toList = "";
            for (int i = 0; i < books.Length; i++)
            {
                toList += books[i].Display() + Environment.NewLine;
            }
            return toList;
        }
    }
}
