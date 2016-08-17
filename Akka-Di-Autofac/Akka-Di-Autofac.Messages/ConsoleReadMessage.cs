using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Akka_Di_Autofac.Messages
{
    public class ConsoleReadMessage
    {
        public string Message { get; private set; }

        public ConsoleReadMessage(string message)
        {
            Message = message;
        }
    }
}
