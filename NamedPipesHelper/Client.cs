using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Pipes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NamedPipesHelper
{
    public class Client
    {
        public static string getSecret()
        {
            string result = "secret-init";

            using (var client = new NamedPipeClientStream(".", Server.pipeName, PipeDirection.In))
            {
                client.Connect();

                using (var reader = new StreamReader(client))
                {
                    result = reader.ReadLine();
                }

            }

            return result;
        }
    }
}
