using Actors;
using Akka.Actor;
using Akka.DI.AutoFac;
using Akka.DI.Core;
using Akka_Di_Autofac.Messages;
using Autofac;
using Autofac.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Akka_Di_Autofac
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create and build your container
            var builder = new Autofac.ContainerBuilder();

            builder.RegisterType<ConsoleWriterActor>().InstancePerDependency();
            builder.RegisterType<ConsoleWriterActorFactory>().As<IConsoleWriterActorFactory>().InstancePerDependency();
            builder.RegisterType<ConsoleReaderActor>().InstancePerDependency();

            var container = builder.Build();

            var actorSystem = ActorSystem.Create("DiActorSystem");
            var propsResolver = new AutoFacDependencyResolver(container, actorSystem);

            var consoleWriter = actorSystem.ActorOf(actorSystem.DI().Props<ConsoleWriterActor>(), "ConsoleWriter");
            var consoleReader = actorSystem.ActorOf(actorSystem.DI().Props<ConsoleReaderActor>(), "ConsoleReader");


            consoleWriter.Tell(new ConsoleWriterMessage("Got DI working!", ConsoleColor.Blue));

            var leaveLoop = false;
            do
            {
                var consoleInput = Console.ReadLine();
                var task = consoleReader.Ask<bool>(new ConsoleReadMessage(consoleInput));
                leaveLoop = task.Result;

            } while (leaveLoop == false);

            actorSystem.Terminate();
        }
    }
}
