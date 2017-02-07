namespace LibAbstraite.GestionObservations
{
    public interface IObservateur
    {
        void Notifier(IObservable observable);
    }
}
