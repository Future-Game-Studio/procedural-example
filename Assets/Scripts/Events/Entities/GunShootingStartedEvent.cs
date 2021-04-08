using FUGAS.Examples.Events.Observer.Abstractions;

namespace FUGAS.Examples.Events.Entities
{
    public class GunShootingStartedEvent : GunFireEvent
    {
        public GunShootingStartedEvent(int free, int magazineCapacity) : base(free, magazineCapacity)
        {
        }

        public override string Message => "Fire!!!";
    }
}