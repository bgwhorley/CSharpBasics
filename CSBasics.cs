using ConsoleApp3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpBasics
{
    internal class CSBasics
    {
        static void Main(string[] args)
        {

            executeBasics();

            //instantiate the StringClass instance to call its methods
            StringClass str = new StringClass();
            Console.WriteLine("\n\n");
            Console.WriteLine("Printing the string length of the string \"four\"");
            Console.WriteLine(str.stringLength("four"));

            str.printCharacters("test");

            string[] s1 = {"one",  "two", "three",  "four"};
            Console.WriteLine("\n\n");
            Console.WriteLine("joining the four strings and printing the output");
            Console.WriteLine(str.joinStrings(s1));

            str.formatString(4);
            str.stringInterpolation(1999, "Jeep", "Cherokee", 89000, 9000);

            str.stringBuilderExample();
            str.stringParsing();

        }

        public static void executeBasics()
        {
            //Basic console interaction
            //Console.WriteLine("Hello world!");
            //Console.WriteLine("What is your name?");
            //string ex = Console.ReadLine();
            //Console.WriteLine("Why hello there " + ex);

            //primitive types
            int i = 10;
            float f = 1.0f;
            decimal d = 10.0m;
            bool b = true;
            string str = "Hello";
            char c = 'a';

            string s = "a string";

            // implicit variable declaration, types are determined by the compiler like in javascript
            var x = 10;
            var z = "Hello";

            //array
            int[] vals = new int[5];
            string[] strs = { "one", "two", "three" };

            //print the values using a formatting string
            Console.WriteLine("{0},{1},{2}, i, c, b, str", i, c, b, str);

            //null reference will be printed as blank
            object obj = null;
            Console.WriteLine(obj);

            //implicit type conversion, when putting a "smaller" less precise type into a "bigger" type, the conversion is automatic
            long bignum;
            bignum = i;

            //explicit type conversion can be declared directly in the code
            //this conversion means that there can be a loss of precision from a float to an integer
            float i_to_f = (float)i;
            Console.WriteLine(i_to_f);

            double dec = 25.0001;
            int _i = (int)dec;
            Console.WriteLine(_i);

            //operators in C#

            int w = 10; int y = 5;

            // arithmetic operators 
            Console.WriteLine(w + y);
            Console.WriteLine(w - y);
            Console.WriteLine(w * y);
            Console.WriteLine(w / y);
            // modulo operator % will return the remainder
            Console.WriteLine(w % y);

            // logical operators
            if ((w - y) == 5)
            {
                Console.WriteLine("10 - 5 is 5");
            }

            if (true || false)
            {
                Console.WriteLine("true || false is always true");
            }

            if ((true || false) && (true && false))
            {
                Console.WriteLine("Impossible to reach on current conditions");
            }
            else
            {
                Console.WriteLine("Always evaluates to false");
            }

            string str1 = "first"; string str2 = "string";
            // operators are also able to be used for string operations
            Console.WriteLine(str1 + str2);

            str = "testing";
            str2 = null;

            // Null coalescing operators
            // ?? means the left operand will be used if it is not null, if it is then use the right operand
            Console.WriteLine(str ?? "unknown string");
            Console.WriteLine(str2 ?? "unknown string 2");

            // ??= assigns the right operand if the left one is null
            Console.WriteLine(str ??= "newly assigned 1");
            Console.WriteLine(str2 ??= "newly assigned 2");

            // comments are denoted with // for single line and /* */ for multi line comments
            /// XML comments are used to help provide documentation
            /// they start with triple slashes and have a special syntax
            /// <summary>
            /// This is the main sample application function
            /// </summary>
            /// <param name='args'> An array of string arguments from the command line </param> 
            /// <returns>
            /// No return value
            /// </returns>
        }


    }
}
