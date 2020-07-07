using System;


namespace DisneyPrincessApp
{
    class GetPrincessCommand: IParametrizedCommand
    {
        IMessager messager;
        int parametr;
        IRepository<Princess, int> repository;

        public GetPrincessCommand(PrincessRepository pr)
        {
            this.repository = pr;
            messager = new ConsoleMessager();
        }

        public void Execute()
        {
            Princess princess = repository.GetElement(parametr);
            if(princess != null)
            {
                 messager.ShowMessage(princess.ToString());
            }
            else
            {
                messager.ShowMessage("This princess not exists!");
            }
        }

        public void SetParams(params string[] parametres)
        {
            if(Int32.TryParse(parametres[0],out parametr) == false)
            {
                messager.ShowMessage("Entred parametres is incorrect!");
            }
        }
    }
    
}
