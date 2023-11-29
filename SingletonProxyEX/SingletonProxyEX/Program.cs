using System;
using System.Net;

namespace SingletonProxyEX
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int NInstance = 8;// numero di istanze al proxy
            int CCall = 4;// nUmero di chiamate per istanze

            for(int i = 0; i < NInstance; i++)
            {
                ServerProxy proxy = ServerProxy.Instance;

                for(int j = 0; j < CCall; j++)
                {
                    string IndirizzoIP = proxy.ServerRequest();
                    Console.WriteLine($"Proxy {i + 1}, Chiamata {j + 1}: {IndirizzoIP}");

                }
            
            }
        }
    }
}
