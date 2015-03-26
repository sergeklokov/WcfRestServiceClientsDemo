using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PunClient
{
    class Program
    {
        static void Main(string[] args)
        {
            var service = new PunDataService();

            var puns = service.GetPuns();
            Console.WriteLine(puns[0]);

            var pun = service.GetPunByID(1);
            Console.WriteLine(pun);

            Console.ReadLine();
        }
    }
}
