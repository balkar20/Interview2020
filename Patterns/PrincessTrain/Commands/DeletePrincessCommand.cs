using System;


namespace DisneyPrincessApp
{
    class DeletePrincessCommand : IParametrizedCommand
    {
        IMessager messager;
        int parametr;
        IRepository<Princess, int> repository;

        public DeletePrincessCommand(PrincessRepository pr)
        {
            this.repository = pr;
            messager = new ConsoleMessager();
        }

        public void Execute()
        {
            try
            {
                string name = repository.GetElement(parametr).Name;
                repository.DeleteElement(parametr);
                messager.ShowMessage("Princess \"" + name + "\" has been removed");
            }
            catch(Exception ex)
            {
                messager.ShowMessage(ex.Message);
                messager.ShowMessage("This princess not exists!");
            }
        }

        public void SetParams(params string[] parametres)
        {
            if (Int32.TryParse(parametres[0], out parametr) == false)
            {
                messager.ShowMessage("Entred parametres is incorrect!");
            }
        }
    }
    
}
