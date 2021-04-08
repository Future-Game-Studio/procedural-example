namespace FUGAS.Examples.Events.Observer.Abstractions
{
    public interface IObserver
    {
        void OnNotify(IObservableEvent observableEvent);
    }
}