using System;

namespace Delegate
{
    internal class Program
    {
        delegate int DelegateSumm(int x, int y);
        delegate bool ProductCheck(int prod, int thold);

        static void Main(string[] args)
        {
            //Esercizio 1
            Console.WriteLine("------------------------------------------------------");
            Console.WriteLine("------------------------Esercizio-1-------------------");
            DelegateSumm somma = Summ;
 
            Func<DelegateSumm, int, int, int> dell2 = Operation;
   
            int result = dell2(somma, 2, 3);
            
            FinalResult(result);

            // Esercizio 2
            Console.WriteLine("------------------------------------------------------");
            Console.WriteLine("------------------------Esercizio-2-------------------");

            Func<int, int, int> prodCalculator = (a, b) => a * b;
            Predicate<int> productTHoldCheck = res => res > 9;
            Action<bool> positiveCallBack = res =>
            {
                if (res)
                {
                    Console.WriteLine("Il prodotto è maggiore");
                }
            };

            int prodResult = prodCalculator(7, 4);
            bool isGraterThenValue = productTHoldCheck(prodResult);
            positiveCallBack(isGraterThenValue);

        }

        private static int Summ(int x, int y)
        {
            return x + y;
        }

        private static int Operation(DelegateSumm Del, int x, int y)
        {
            int result = Del(x, y);
            return result;
        }

        private static void FinalResult(int risultato)
        {
            Console.WriteLine(risultato);
        }
    }
}
