using FUGAS.Examples.Events.Observer.Abstractions;

namespace FUGAS.Examples.Events.Entities
{
    public class GunShootingStoppedEvent : GunFireEvent
    {
        public GunShootingStoppedEvent(int free, int magazineCapacity) : base(free, magazineCapacity)
        {
        }

        public override string Message => "Well done";
    }
}