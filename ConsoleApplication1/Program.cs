using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("enter two numbers");
            int i = Int32.Parse(Console.ReadLine());
            int j = Int32.Parse(Console.ReadLine());

            int ans = Add(i, j);
            int ans2 = Subtract(i, j);

            Console.WriteLine("result of addition is " + ans);
            Console.WriteLine("result of subtraction is " + ans2); 
            Console.Read();
            
        }

        public static int Add(int i, int j)
        {
            int add = i ^ j;
            int carry = i & j;

            while (carry != 0) 
            {
                int newcarry = carry << 1;

                int newsum = add ^ newcarry;
                carry = add & newcarry;
                //Console.WriteLine(carry);

                add = newsum;
            }
            return add;
        }

        public static int Subtract(int i, int j) 
        {
            int add = ~j ^ 1;
            int carry = ~j & 1;

            while (carry != 0)
            {
                int newcarry = carry << 1;

                int newsum = add ^ newcarry;
                carry = add & newcarry;
                //Console.WriteLine(carry);

                add = newsum;
            }

            int add2 = i ^ add;
            int carry2 = i & add;

            while (carry2 != 0)
            {
                int newcarry2 = carry2 << 1;

                int newsum2 = add2 ^ newcarry2;
                carry2 = add2 & newcarry2;
                //Console.WriteLine(carry2);

                add2 = newsum2;
            }
            return add2;

        }
    }

        
}
