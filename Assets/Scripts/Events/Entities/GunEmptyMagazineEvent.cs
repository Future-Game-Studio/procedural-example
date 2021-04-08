using FUGAS.Examples.Events.Observer.Abstractions;

namespace FUGAS.Examples.Events.Entities
{

    public class GunEmptyMagazineEvent : IObservableEvent
    {
        public string Message => "No more bullets, comrade!";
    }
}