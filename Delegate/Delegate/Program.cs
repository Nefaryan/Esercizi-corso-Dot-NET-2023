using System;

namespace Delegate
{
    internal class Program
    {
        delegate int DelegateSumm(int x, int y);

        static void Main(string[] args)
        {
            
            DelegateSumm somma = Summ;
 
            Func<DelegateSumm, int, int, int> dell2 = Operation;
   
            int result = dell2(somma, 2, 3);
            
            FinalResult(result);
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
