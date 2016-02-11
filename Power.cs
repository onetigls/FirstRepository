using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace multiply
{
    class Program
    {
        static void Main()
        {
            // Test one///////////////////////////////
            Console.WriteLine("сложение 123456789 + 123456789");

            int[] sum1 = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            int[] sum2 = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            BigNumber sumOne = new BigNumber(sum1);
            BigNumber sumTwo = new BigNumber(sum2);
            BigNumber sumThree = sumOne + sumTwo;

            sumOne.ShowNumber();
            sumTwo.ShowNumber();
            sumThree.ShowNumber();

            Console.WriteLine();
            ///////////////////////////////////////////

           
            
            // Test two///////////////////////////////
            Console.WriteLine("умножение 123456789 * 123456789");

            int[] mul1 = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            int[] mul2 = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            BigNumber mulOne = new BigNumber(sum1);
            BigNumber mulTwo = new BigNumber(sum2);
            BigNumber mulThree = sumOne * sumTwo;

            mulOne.ShowNumber();
            mulTwo.ShowNumber();
            mulThree.ShowNumber();

            Console.WriteLine();
            ///////////////////////////////////////////


            // Test three///////////////////////////////
            Console.WriteLine("возведение 2 в 10 степень");

            int[] num = { 2 };
            
            BigNumber numOne = new BigNumber(num);
            

            numOne.ShowNumber();
            BigNumber.Pow(ref numOne, 10);
            numOne.ShowNumber();
            Console.WriteLine();
            ///////////////////////////////////////////

            // Test four///////////////////////////////
            Console.WriteLine("возведение 123456789 в 10 степень");

            int[] bigNum = { 1,2,3,4,5,6,7,8,9 };

            BigNumber bigNumOne = new BigNumber(bigNum);


            bigNumOne.ShowNumber();
            BigNumber.Pow(ref bigNumOne, 10);
            bigNumOne.ShowNumber();
            Console.WriteLine();
            ///////////////////////////////////////////


            Console.WriteLine();

        }


    }

    class BigNumber
    {
        ArrayList Number = new ArrayList();

        public BigNumber()
        {
       
        }

        public BigNumber(int[] Number)
        {
            foreach (int k in Number)
                this.Number.Add(k);

        }

        public void ShowNumber()
        {

            foreach (int k in Number)
            {
                Console.Write(k);
            }
            Console.WriteLine();

        }

        static public void Pow(  ref BigNumber bigNumber, uint n)
        {
            BigNumber temperNumber = new BigNumber();
            temperNumber = bigNumber * temperNumber;

            for (int i = 0; i < (n - 1); i++)
            {         
                bigNumber = temperNumber * bigNumber;
            }

        }





        public int Length
        {
            get
            {
                return Number.Count;
            }
        }

        static public BigNumber operator +(BigNumber one, BigNumber two)
        {
            BigNumber firstNumber;
            
            BigNumber secondNumber;

            if (one.Length == 0)
                return two;
            if (two.Length == 0)
                return one;

            BigNumber resultNumber = new BigNumber();
            if (one.Length < two.Length)
            {
                firstNumber = two;
                secondNumber = one;
            }
            else
            {
                firstNumber = one;
                secondNumber = two;
            }

            firstNumber.Number.Reverse();
            secondNumber.Number.Reverse();

            for (int i = 0; i < firstNumber.Length; i++)
            {
                for (; i < secondNumber.Length; i++)
                {
                    resultNumber.Number.Add(((int)firstNumber.Number[i] + (int)secondNumber.Number[i]));
                }
                if (firstNumber.Length > secondNumber.Length)
                    resultNumber.Number.Add(firstNumber.Number[i]);
            }

            firstNumber.Number.Reverse();
            secondNumber.Number.Reverse();

            for (int i = 0; i < resultNumber.Length; i++)
            {
                if ((int)resultNumber.Number[i] > 9)
                {
                    resultNumber.Number[i] = (int)resultNumber.Number[i] % 10;
                    try
                    {
                        resultNumber.Number[i + 1] = (int)resultNumber.Number[i + 1] + 1;
                    }
                    catch
                    {
                        resultNumber.Number.Add(1);
                    }
                }
            }

            resultNumber.Number.Reverse();

            return resultNumber;

        }

        static public BigNumber operator *(BigNumber one, BigNumber two)
        {
            BigNumber firstNumber;
            BigNumber secondNumber;

            BigNumber resultNumber = new BigNumber();

            if (one.Length == 0)
                return two;
            if (two.Length == 0)
                return one;

            if (one.Length < two.Length)
            {
                firstNumber = two;
                secondNumber = one;
            }
            else
            {
                firstNumber = one;
                secondNumber = two;
            }

            firstNumber.Number.Reverse();
            secondNumber.Number.Reverse();

            for (int i = 0; i < secondNumber.Length; i++)
            {
                BigNumber temperNumber = new BigNumber();

                for(int j = 0; j < firstNumber.Length; j++)
                {
                    temperNumber.Number.Add((int)firstNumber.Number[j] * (int)secondNumber.Number[i]);

                }

                

                for (int k = 0; k < temperNumber.Length; k++)
                {
                    if ((int)temperNumber.Number[k] > 9)
                    {
                        int temperValue = (int)temperNumber.Number[k];
                        temperNumber.Number[k] = (int)temperNumber.Number[k] % 10;
                        try
                        {
                            temperNumber.Number[k + 1] = (int)temperNumber.Number[k + 1] + (temperValue / 10);
                        }
                        catch
                        {
                            temperNumber.Number.Add(temperValue / 10);
                        }
                    }
                }

                temperNumber.Number.Reverse();

                for(int a = 0; a < i; a++)
                {
                    temperNumber.Number.Add(0);
                }

                resultNumber = resultNumber + temperNumber;

                
            }

            return resultNumber;
        }
    }
}