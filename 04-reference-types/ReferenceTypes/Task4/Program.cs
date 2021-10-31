using System;
using System.Linq;

namespace Task4
{
    class Program
    {
        static void Main(string[] args)
        {
            // test constructors
            string testString = "Hello, dude!";
            char[] testArray = {'H', 'e', 'l', 'l', 'o', ',', ' ', 'd', 'u', 'd', 'e', '!'};

            MyString myStrEmpty = new MyString();
            MyString myStrFromStr = new MyString(testString);
            MyString myStrFromCharArray = new MyString(testArray);

            Console.WriteLine("Test empty: [{0}]", myStrEmpty.ToString());
            Console.WriteLine("Test from string: test [{0}]  result [{1}]", 
                testString, 
                myStrFromStr.ToString());
            Console.WriteLine("Test from char array: test [{0}]  result [{1}]", 
                new string(testArray), 
                myStrFromCharArray.ToString());


            // test operator overload
            char[] testArray1 = { 'H', 'e', 'l', 'l', 'o', ',', ' ' };
            char[] testArray2 = { ',', ' ', 'd', 'u', 'd' };
            MyString testMyString1 = new MyString(testArray1);
            MyString testMyString2 = new MyString(testArray2);

            Console.WriteLine();
            Console.WriteLine("Test add [+]: [{0}] + [{1}] = [{2}]", 
                testMyString1.ToString(), 
                testMyString2.ToString(), 
                (testMyString1 + testMyString2).ToString());

            Console.WriteLine("Test sub [-]: [{0}] - [{1}] = [{2}]",
                myStrFromCharArray.ToString(),
                testMyString2.ToString(),
                (myStrFromCharArray - testMyString2).ToString());

            Console.WriteLine("Test equals [==]: [{0}] == [{1}] = [{2}]",
                testMyString1.ToString(),
                testMyString2.ToString(),
                (testMyString1 == testMyString2).ToString());

            Console.WriteLine("Test equals [==]: [{0}] == [{1}] = [{2}]",
                testMyString1.ToString(),
                testMyString1.ToString(),
                (testMyString1 == testMyString1).ToString());

            if(testMyString1 != null)
            {
                Console.WriteLine("!!!!!!!!!!!!!!");
            }
            else 
            {
                Console.WriteLine("++++++++++++++");
            }


            Console.WriteLine();

            // test null
            char[] testNullArray = null;
            string testNullString = null;

            MyString testMyStringNull1 = new MyString(testNullArray);
            MyString testMyStringNull2 = new MyString(testNullString);

            Console.WriteLine("Test null from array: [{0}]", testMyStringNull1.ToString());
            Console.WriteLine("Test null from string: [{0}]", testMyStringNull2.ToString());
        }
    }

    public class MyString
    {
        public char[] myString;

        public MyString()
        {
            myString = new char[0];
        }

        public MyString(string prototype)
        {
            if(prototype is null)
            {
                myString = new char[0];
                Console.WriteLine("Warning: You are trying to assign a null value to MyString object");
            }
            else
                myString = prototype.ToCharArray();
        }

        public MyString(char[] prototype)
        {
            if(prototype is null)
            {
                myString = new char[0];
                Console.WriteLine("Warning: You are trying to assign a null value to MyString object");
            }
            else
            {
                myString = new char[prototype.Length];

                for (int i = 0; i < myString.Length; i++)
                {
                    myString[i] = prototype[i];
                }
            }
        }

        override public string ToString()
        {
            return new string(myString);
        }

        public static MyString operator + (MyString myStr1, MyString myStr2)
        {
            MyString resMyStr = new MyString();

            if (myStr1 is null || myStr2 is null)
                Console.WriteLine("Incorrect parameter");

            else
            {
                resMyStr.myString = new char[myStr1.myString.Length + myStr2.myString.Length];

                for (int resItr = 0; resItr < resMyStr.myString.Length; resItr++)
                {
                    if (resItr < myStr1.myString.Length)
                    {
                        resMyStr.myString[resItr] = myStr1.myString[resItr];
                    }
                    else
                    {
                        resMyStr.myString[resItr] = myStr2.myString[resItr - myStr1.myString.Length];
                    }
                }
            }

            return resMyStr;
        }

        public static MyString operator - (MyString src, MyString trg)
        {
            MyString res = new MyString();

            if (src is null || trg is null)
            {
                throw new ArgumentNullException();
            }

            else
            {
                res.myString = new char[src.myString.Length - trg.myString.Length];

                bool firstTargetOccurence = false;
                int resultItr = 0;

                for (int srcItr = 0; srcItr < src.myString.Length; srcItr++)
                {
                    char[] tmp = new char[trg.myString.Length]; // tmp buff

                    if (srcItr <= res.myString.Length)
                    {
                        for (int tmpItr = 0; tmpItr < tmp.Length; tmpItr++) // copy to temp
                        {
                            tmp[tmpItr] = src.myString[srcItr + tmpItr];
                        }
                    }

                    if (trg.myString.SequenceEqual(tmp) && firstTargetOccurence == false)
                    {
                        firstTargetOccurence = true; // lock
                        srcItr += tmp.Length - 1; // skip idxs
                    }
                    else
                    {
                        res.myString[resultItr] = src.myString[srcItr]; // save
                        resultItr++;
                    }
                }
            }

            return res;
        }

        public static bool operator ==(MyString myStr1, MyString myStr2)
        {
            if (myStr1 is null || myStr2 is null)
                Console.WriteLine("Incorrect parameter");

            else
            {
                if (myStr1.myString.Length == myStr2.myString.Length)
                {
                    for (int myStrItr = 0; myStrItr < myStr1.myString.Length; myStrItr++)
                    {
                        if (myStr1.myString[myStrItr] != myStr2.myString[myStrItr])
                        {
                            return false;
                        }
                    }
                }
                else
                    return false;
            }
            
            return true;
        }

        public static bool operator !=(MyString myStr1, MyString myStr2)
        {
            return !(myStr1 == myStr2);
        }
    }
}
