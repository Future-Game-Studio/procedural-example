using FUGAS.Examples.Events.Observer.Abstractions;

namespace FUGAS.Examples.Events.Entities
{
    public class GunFireEvent : IObservableEvent
    {
        public GunFireEvent(int free, int magazineCapacity)
        {
            Free = free;
            MagazineCapacity = magazineCapacity;
        }

        public virtual string Message => "Shooting!";

        public int Free { get; }
        public int MagazineCapacity { get; }
    }
}