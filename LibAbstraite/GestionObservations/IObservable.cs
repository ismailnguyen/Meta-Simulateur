namespace LibAbstraite.GestionObservations
{
    public interface IObservable
    {
        void AjouterObservateur(IObservateur observateur);
        void SupprimerObservateur(IObservateur observateur);
        void NotifierObservateur();
    }
}
