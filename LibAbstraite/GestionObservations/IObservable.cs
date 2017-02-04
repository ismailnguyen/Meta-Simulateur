namespace LibAbstraite.GestionObservations
{
    public interface IObservable
    {
        void AjouterObservateur(IObservateur observateur);
        void Supprimer(IObservateur observateur);
        void NotifierObservateurs();
    }
}
