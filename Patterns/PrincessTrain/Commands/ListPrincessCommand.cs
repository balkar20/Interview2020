namespace DisneyPrincessApp
{
    class ListPrincessCommand :ICommand
    {
        IMessager messager;
        PrincessRepository repository;

        public ListPrincessCommand(PrincessRepository pr)
        {
            this.repository = pr;
            
            messager = new ConsoleMessager();
        }

        public void Execute()
        {
            Princess[] princesses = repository.GetList();
            foreach(var princess in princesses)
            {
                messager.ShowMessage(princess.ToString());
            }
        }
    }
    
}
