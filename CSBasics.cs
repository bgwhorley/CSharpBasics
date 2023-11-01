using ConsoleApp3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CSharpBasics
{
    class CSBasics
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

            object[] items = { 1, 2, "Hello!", "World", 'X', true, 2.0, ".NET", 'A' };
            int total = 0;
            string CountType = "System.String";
            foreach (object item in items)
            {
                if (CountTheType(item, CountType))
                {
                    total++;
                }
            }
            Console.WriteLine("items array has " + total + " items of type " + CountType);

            printWithPrefix(prefix: "test", str: "string");

            int sum = 0; int product = 0;

            // not that the out keyword must also be used in the method call
            PlusTimes(1, 2, out sum, out product);

            Console.WriteLine("sum of 1+2 and product of 1*2: " +  sum + ", " +  product);

            // tuples are grouped values
            (int a, int b) tupl1 = (5, 10);
            // modification to the tuple can be done using the . operator
            tupl1.a = 12;
            Console.WriteLine(tupl1);

            // a tuple can be any mixutre of types, up to a maximum of 8 elements
            var tupl2 = ("a string", 55);
            tupl2.Item1 = "a changed string";
            Console.WriteLine(tupl2);

            Console.WriteLine(TupleExample(1, 2));

            IsPalindrome("rotoR");

            Book book = new Book();
            book.PageCount = 100;

            Console.WriteLine(book.PageCount);

            Book2 b2 = new Book2();
            b2.Name = "Test";
            b2.Author = "Ben";
            b2.PageCount = 100;

            Console.WriteLine(b2.getDescription());

            Console.WriteLine("Finished");

            bool IsSuccessful = true;
            // Create the Checking Account with initial balance.
            CheckingAcct checking = new CheckingAcct("John", "Doe", 2500.0m);
            IsSuccessful &= (checking.Balance == 2500.0m);
            IsSuccessful &= (checking.AccountOwner == "John Doe");

            // Create the Savings Account with interest and initial balance.
            SavingsAcct saving = new SavingsAcct("Jane", "Doe", 0.03m, 1000.0m);
            IsSuccessful &= (saving.Balance == 1000.0m);
            IsSuccessful &= (saving.AccountOwner == "Jane Doe");

            // Deposit some money in each account.
            checking.Deposit(200.0m);
            saving.Deposit(150.0m);
            IsSuccessful &= (checking.Balance == 2700.0m);
            IsSuccessful &= (saving.Balance == 1150.0m);

            // Make some withdrawals from each account.
            checking.Withdraw(50.0m);
            saving.Withdraw(125.0m);
            IsSuccessful &= (checking.Balance == 2650.0m);
            IsSuccessful &= (saving.Balance == 1025.0m);

            // Apply the Savings interest.
            saving.ApplyInterest();
            IsSuccessful &= (saving.Balance == 1055.75m);

            // More than three Savings withdrawals should result in $2 charge.
            saving.Withdraw(10.0m);
            saving.Withdraw(20.0m);
            saving.Withdraw(30.0m);
            IsSuccessful &= (saving.Balance == 993.75m);

            // try to overdraw savings - this should be denied
            saving.Withdraw(2000.0m);
            // try to overdraw checking - should be allowed and result in extra charge
            checking.Withdraw(3000.0m);
            IsSuccessful &= (saving.Balance == 993.75m);
            IsSuccessful &= (checking.Balance == -385.00m);

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

        // code challenge for counting data types
        public static bool CountTheType(object Arg, string TypeToCount)
        {
            // Your code goes here. Return true if the type of the Arg is the same
            // as what the TypeToCount parameter says to count.
            string[] TypesList = { "int", "string", "bool", "double", "char" };
            if (Arg.GetType() == null)
            {
                return false;
            }
            if (Arg.GetType().ToString() == TypeToCount)
            {
                return true;
            }
            return false;
        }
        // setting prefix equal to "" in the parameters sets the default value of prefix
        // in the function call you can name the specific parameters in any order, but ALL parameters will need to be named
        public static void printWithPrefix(string str, string prefix = "")
        {
            Console.WriteLine($"{prefix} {str}");
        }

        // out parameters are a mechanism to return multiple values in C#
        // in the following example, the sum and the product passed into the parameter will be computed in the function
        // and set to the variable passed in through the call
        public static void PlusTimes(int arg1, int arg2, out int sum, out int product)
        {
            sum = arg1 + arg2;
            product = arg1 * arg2;
        }

        public static (int, int)TupleExample(int arg1, int arg2)
        {
            return (arg1+1, arg2+2);
        }

        public static bool IsPalindrome(string str)
        {
            try
            {
                string s1 = str.ToUpper();
                s1.Replace(" ", "");
                Regex r = new Regex(@"\W|_");
                string s = r.Replace(s1, "");
                if (s.Length == 0)
                {
                    return false;
                }

                string reverse = "";
                char[] ch = s.ToCharArray();
                for (int i = s.Length - 1; i >= 0; i--)
                {
                    reverse += ch[i];
                }

                Console.WriteLine("testing palindrome on strings: " + s + ", " + reverse);
                if (reverse == s)
                {
                    return true;
                }
                return false;
            } 
            catch (IndexOutOfRangeException e)
            {
                Console.WriteLine("Caught Index out of Range Exception during execution of isPalindrome()");
            }
            catch (Exception e)
            {
                Console.WriteLine("Caught general exception during execution of IsPalindrome()");

            }
            return false;
        }
    }
}
