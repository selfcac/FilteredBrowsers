using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NamedPipesHelper;

namespace NamedPipesHelper.Example
{
    class Program
    {
        static void Main(string[] args)
        {
            if (!args.Contains("--no-server"))
            {
                Server myServer = new Server((t) => Console.WriteLine(t), (t) => Console.WriteLine(t));
                myServer.Start();
            }

            Console.WriteLine(Client.getSecret());
            Console.WriteLine(Client.getSecret());
            Console.WriteLine(Client.getSecret());

            Console.ReadLine();
        }
    }
}
