using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    internal class StringClass
    {
        //default contructor
        public StringClass() { }

        // in any program you don't need to create a separate class, you can just use the string methods directly
        public int stringLength(string s)
        {
            return s.Length;
        }

        // prints each character of the given string on each line
        public void printCharacters(string s)
        {
            for (int i=0; i<s.Length; i++)
            {
                Console.WriteLine(s[i]);
            }
        }

        public string joinStrings(string[] s)
        {
            Console.WriteLine("\n\n");
            Console.WriteLine("joining the " + s.Length + " strings and printing the output");
            return String.Join('.', s);
        }

        // this method calls the compare() method for strings
        // 0 is a match, < 0  means it comes before the second alphabetically
        // > 0 means it comes after the second alphabetically
        public int compareString(string s1, string s2)
        {
            return s1.CompareTo(s2);
        }

        public string formatString(int num)
        {
            // General format is {index[,alignment]:[format]}
            // Common types are N (Number), G (General), F (Fixed-point),
            // E (Exponential), D (Decimal), P (Percent), X (Hexadecimal),
            // C (Currency in local format)
            // ex: 
            try
            {
                Console.WriteLine("{0:D}, {0:N}, {0:F}, {0:G}", num);

                // You can also add the amount of precision you'd like
                // an input of 4 will display 000004, 4.00, 4.0, 4
                Console.WriteLine("{0:D6}, {0:N2}, {0:F1}, {0:G3}", num);
                Console.WriteLine("{0:D6}, {0:N6}, {0:F6}, {0:G6}", num);
                return "";
            } 
            catch (Exception e)
            {
                Console.WriteLine("Encountered exception in formatString method");
            } 

            return "";

        }

        // example of string interpolation
        public void stringInterpolation(int year, string make, string model, int miles, double price)
        {
            // as shown in the formatString method the format modifiers can also be utilized in string interpolation
            // mathematical expressions can also be written in the enclosed braces, i.e. {miles} can be {miles * 1.6}
            // to print the { character itself, an escape brace needs to be added, so {{{miles}}} should print as {2.4} if you passed in 2.4 for the miles parameter
            Console.WriteLine($"This car is a {year} {make} {model}, with {miles} miles and costs {price:C2}");
        }

        // string builder is useful for the purposes of lowering memory utilization, since regular strings create copies and are immutable
        // string builder is mutable
        public void stringBuilderExample()
        {
            // the second argument is the maximum capacity of the string
            StringBuilder sb = new StringBuilder("Initial string.", 200);
            Console.WriteLine($"Capacity: {sb.Capacity}; Length: {sb.Length}");

            sb.Append(" appending text to string builder");
            Console.WriteLine(sb.ToString());

            // to add a line ending
            sb.AppendLine();

            int times = 2;
            sb.AppendFormat("He did this {0} times ", times);

            string[] animals = {"cat", "dog", "fish", "bird" };
            sb.AppendJoin(',', animals);

            sb.Replace("cat", "fox");
            Console.WriteLine(sb.ToString() );

            sb.Insert(0, "string builder insertion at index zero.  ");

            Console.WriteLine(sb.ToString());
            Console.WriteLine($"Capacity: {sb.Capacity}; Length: {sb.Length}");
        }
    }
}
