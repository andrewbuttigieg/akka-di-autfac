using Akka.Actor;
using Akka_Di_Autofac.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Actors
{
    public class ConsoleReaderActor: ReceiveActor
    {
        IActorRef consoleWriterActor;
        public ConsoleReaderActor(IConsoleWriterActorFactory consoleWriterActorFactory)
        {
            this.consoleWriterActor = consoleWriterActorFactory.CreateActor(Context.System);

            Receive<ConsoleReadMessage>(message =>
            {
                if (message.Message.Equals("exit", StringComparison.CurrentCultureIgnoreCase))
                {
                    consoleWriterActor.Tell(new ConsoleWriterMessage("Exiting loop.", ConsoleColor.White));
                    Sender.Tell(true);
                }
                else
                {
                    consoleWriterActor.Tell(new ConsoleWriterMessage("Type exit to leave loop.", ConsoleColor.Red));
                    Sender.Tell(false);
                }
            });
        }
    }
}
