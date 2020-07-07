using System;
using System.Linq;


namespace DisneyPrincessApp
{
    class UpdatePrincessCommand : IParametrizedCommand
    {
        IMessager messager;
        IRepository<Princess, int> repository;
        Princess princess;
        IParser<PrincessProperties, string[]> parser;

        public UpdatePrincessCommand(PrincessRepository pr)
        {
            this.repository = pr;
            messager = new ConsoleMessager();
            parser = new ArrToPropsParser();
        }

        public void Execute()
        {
            try
            {
                repository.UpdateElement(princess);
                messager.ShowMessage("Princess \"" + princess.Name + "\" has been updated");
            }
            catch
            {
                messager.ShowMessage("This princess not exists!");
            }
        }

        public void SetParams(params string[] parametres)
        {
            try
            {
                PrincessProperties proprties = parser.Parse(parametres);
                princess = new Princess(proprties.Number, proprties.Name, Convert.ToByte(proprties.Age), proprties.HairColor, proprties.EyeColor);
            }
            catch(Exception ex)
            {
                messager.ShowMessage("Entred data is not valid!");
                messager.ShowMessage(ex.Message);
            }
        }

        public int CountParameters(object[] pars)
        {
            return pars.Count();
        }
    }
    
}
