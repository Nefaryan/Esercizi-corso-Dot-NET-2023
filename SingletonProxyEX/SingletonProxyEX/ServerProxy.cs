using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingletonProxyEX
{
    //Classe singleton per il proxy
    public class ServerProxy
    {

        private static ServerProxy instance;
        private List<string> serversIP;

        private ServerProxy()   
        {
            serversIP = new List<string>()
            {
                IPGenerator(),
                IPGenerator(),
                IPGenerator(),
                IPGenerator()
            };
        }

        private string IPGenerator()
        {
            Random random = new Random();
            return $"{random.Next(256)}.{random.Next(256)}.{random.Next(256)}.{random.Next(256)}";
        }

        public static ServerProxy Instance
        {
            get
            {
                if(instance == null)
                {
                    instance = new ServerProxy();
                }
                return instance;
            }
        }

        public string ServerRequest()
        {
            Random random = new Random();
            int randomIndex = random.Next(serversIP.Count);
            return serversIP[randomIndex];
        }
    }


    
}

