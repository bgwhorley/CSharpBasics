using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    public class Book
    {
        private string _name;
        protected string _description;
        private string _title;
        private string _author;
        private int _pagecount;

        public Book() {
            _name = string.Empty;
            _description = string.Empty;
            _title = string.Empty;
            _author = string.Empty;
            _pagecount = 0;
            PageCount = _pagecount;
        }


        // c# has Properties to implement data accessors
        //
        public string Name
        {
            get {
                return _name;
            }
            set
            {
                // value is the keyword used to refer to the value passed to the setter
                // so in this case it would be Name.
                _name = value;
            }
        }

        public string Author
        {
            // => is the shorthand notation for setters and getters
            get => _author;
            set => _author = value;
        }

        // declaring a variable as virtual indicates that a child class may redefine a parent attribute or method
        public string Description
        {
            get => $"{_name} is written by {_author}";
        }

        public virtual string getDescription()
        {
            return $"{Name}, {PageCount}";
        }

        public int PageCount
        {
            // get and set will 
            get; set;
        }
    }

    public class Book2 : Book
    {
        // declare the method to be overridden to redefine the method
        public override string getDescription()
        {
            return $"{Name} by {Author}, {PageCount}";
        }

        // C# has an implicit ToString() function for every object, but if you want to tailor it
        // to your own preference you can override it
        public override string ToString()
        {
            return $"Book: {Name} by {Author}";
        }

        // you can also overload the ToString function
        public string ToString(string format)
        {
            if(format == "B")
            {
                return $"Book: {Name}:{Author}";
            }
            if(format == "F")
            {
                return $"Book: {Name} by {Author} is {PageCount} pages";
            }
            return ToString();
        }
    }
}
