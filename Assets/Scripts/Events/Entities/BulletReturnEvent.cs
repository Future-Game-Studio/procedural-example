using FUGAS.Examples.Events.Observer.Abstractions;

namespace FUGAS.Examples.Events.Entities
{
    public class BulletReturnEvent : IObservableEvent
    {
        public virtual string Message => "+1";
    }
}