using Akka.Actor;
using Akka_Di_Autofac.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Actors
{
    public class ConsoleWriterActor:ReceiveActor
    {
        public ConsoleWriterActor()
        {
            Receive<ConsoleWriterMessage>(message =>
            {
                Console.ForegroundColor = message.ConsoleColor;
                Console.WriteLine(message.Message);
                Console.ResetColor();
            });
        }
    }
}
