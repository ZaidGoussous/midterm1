using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace Testing
{
    class Book
    {
        private int numberOfAuthors;
        public int NumberOfAuthors
        {
            get
            {
                return numberOfAuthors;
            }
            private set
            {
                numberOfAuthors = value;
            }
        }
        private string[] authors = new string[5];
        private string[] Authors
        {
            get
            {
                return authors;
            }
            set
            {
                authors = value;
            }
        }
        private string title;
        public string Title
        {
            private get
            {
                return title;
            }
            set
            {
                title = value;
            }
        }
        private string publisher;
        public string Publisher
        {
            private get
            {
                return publisher;
            }
            set
            {
                publisher = value;
            }
        }
        private int yearOfIssue;
        public int YearOfIssue
        {
            get
            {
                return yearOfIssue;
            }
            set
            {
                yearOfIssue = value;
            }
        }
        private bool readOrUnread;
        public bool ReadOrUnread
        {
            get
            {
                return readOrUnread;
            }
            set
            {
                readOrUnread = value;
            }
        }
        public Book (int numberOfAuthors, bool readOrUnread)
        {
            this.numberOfAuthors = numberOfAuthors;
            this.readOrUnread = readOrUnread;
        }
        public void newAuthor(string newAuthor)
        {
            if (numberOfAuthors==5)
            {
                Console.WriteLine("We apologize, we have the maximum number of authors");
                return;
            }
            this.authors[numberOfAuthors++] = newAuthor;
        }
        public bool IsAuthor(string authorToCheck)
        {
            for (int i = 0; i < this.numberOfAuthors; i++)
            {
                if (this.authors[i]==authorToCheck)
                {
                    return true;
                }
            }
            return false;
        }
        public string Display()
        {
            StringBuilder sb = new StringBuilder();
            //checking if we have multiple authors
            for (int i = 0; i < this.numberOfAuthors; i++)
            {
                sb.Append(this.authors[i]);
                if (i + 1 == this.numberOfAuthors)
                {
                    sb.Append(": ");
                }
                else
                {
                    sb.Append(", ");
                }
            }

            //Adding the title
            sb.Append(this.title);
            sb.Append(". ");

            //ADDING THE PUBLISHER :)
            sb.Append(this.publisher);
            sb.Append(", ");

            //ADDING THE YEAR OF ISSUE
            sb.Append(this.yearOfIssue);
            sb.Append(" (");

            string readString;
            if (this.readOrUnread)
            {
                readString = "read";
            }
            else
            {
                readString = "unread";
            }

            sb.Append(readString);
            sb.Append(") ");
            return sb.ToString();
        }
        public string ToFile()
        {
            string toFile = "";
            for (int i = 0; i < numberOfAuthors; i++)
            {
                // A# 1. Author name
                // A# 2. Author name
                toFile += "A# " + (i + 1) + ". " + this.authors[i] + Environment.NewLine;
            }
            toFile += "T# " + this.title + Environment.NewLine;
            toFile += "P# " + this.publisher + Environment.NewLine;
            toFile += "Y# " + this.yearOfIssue + Environment.NewLine;

            if (this.readOrUnread)
            { // true
                toFile += "R# " + "read" + Environment.NewLine;
            }
            else
            { // false
                toFile += "R# " + "unread" + Environment.NewLine;
            }
            toFile += "***" + Environment.NewLine;
            return toFile;
        }
    }
}
