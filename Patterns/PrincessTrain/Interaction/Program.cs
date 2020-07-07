using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Collections;

namespace DisneyPrincessApp
{
    class Program
    {
        static void Main(string[] args)
        {
            IReader reader = new FileReader(Environment.CurrentDirectory + "/" + "disney-princesses.txt");
            string[] strings = reader.Read();

            IParser<Princess[], string[]> parser = new FileParser();
            List<Princess> princesses = parser.Parse(strings).ToList();

            PrincessRepository repository = new PrincessRepository(princesses);

            ICommand commandGetPrincess = new GetPrincessCommand(repository);
            ICommand commandUpdatePrincess = new UpdatePrincessCommand(repository);
            ICommand commandDeletePrincess = new DeletePrincessCommand(repository);
            ICommand commandAddPrincess = new AddPrincessCommand(repository);
            ICommand commandListPeincess = new ListPrincessCommand(repository);
            ICommand commandExit = new ExitCommand();

            Dictionary<string, ICommand> commands = new Dictionary<string, ICommand>();

            commands.Add("get", commandGetPrincess);
            commands.Add("update", commandUpdatePrincess);
            commands.Add("delete", commandDeletePrincess);
            commands.Add("add", commandAddPrincess);
            commands.Add("list", commandListPeincess);
            commands.Add("exit",commandExit);

            ClientHelper asistant = new ClientHelper(commands,repository);
            asistant.Start();

            Console.ReadLine();

        }

        
    }
}
