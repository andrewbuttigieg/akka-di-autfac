using Akka.Actor;
using Akka.DI.Core;

namespace Actors
{
    public class ConsoleWriterActorFactory : IConsoleWriterActorFactory
    {
        public IActorRef CreateActor(ActorSystem actorSystem)
        {
            return actorSystem.ActorOf(actorSystem.DI().Props<ConsoleWriterActor>(), "ConsoleWriterActor");
        }
    }
}
