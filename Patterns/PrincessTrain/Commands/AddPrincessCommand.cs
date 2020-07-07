using System;
using System.Linq;


namespace DisneyPrincessApp
{
    class AddPrincessCommand : IParametrizedCommand
    {
        IMessager messager;
        Princess princess;
        IRepository<Princess, int> repository;
        IParser<PrincessProperties, string[]> parser;

        public AddPrincessCommand(PrincessRepository pr)
        {
            this.repository = pr;
            this.messager = new ConsoleMessager();
            parser = new ArrToPropsParser();
        }

        public void Execute()
        {
            try
            {
                repository.AddElement(princess);
                messager.ShowMessage("Princess \"" +princess.Name+ "\" has been added.");
            }
            catch
            {
                messager.ShowMessage("You entred invalid data");
            }
        }

        public void SetParams(params string[] parametres)
        {
            try
            {
                PrincessProperties proprties = parser.Parse(parametres);
                princess = new Princess(proprties.Number, proprties.Name, Convert.ToByte(proprties.Age), proprties.HairColor, proprties.EyeColor);
            }
            catch
            {
                messager.ShowMessage("Entred data is not valid!");
            }
        }

        public int CountParameters(string[] pars)
        {
            return pars.Count();
        }
    }
    
}
