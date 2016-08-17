using Akka.Actor;

namespace Actors
{
    public interface IConsoleWriterActorFactory
    {
        IActorRef CreateActor(ActorSystem actorSystem);
    }
}