using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace DisneyPrincessApp
{
    class ClientHelper
    {
        IMessager messager;
        PrincessRepository repository;
        Dictionary<string, ICommand> comands;
        public IMessager Messager { get => messager; set => messager = value; }
        public PrincessRepository Repository { get => repository; set => repository = value; }
        public Dictionary<string, ICommand> Comands { get => comands; set => comands = value; }
        string msg = "Application started successfuly.Pleaze enter one of this command for start working:\n" +
                "'list' - show all princesses.\n" +
                "'add [number] [name] [age] [haircolor] [eyecolor]' - add new princess.\n" +
                "'get [number]' - show info about princess.\n" +
                "'update [number] [name] [age] [haircolor] [eyecolor]' - update some data about princess.\n" +
                "'delete [number]' - remove princess from collection\n" +
                "'exit' - leave application.\n" +
                "HAIRCOLOR SHOULD BE INCLUDE IN ('Black', 'Blonde', 'Platinum-blonde', 'Strawberry-blond'," + "'Red', 'Brown')\n" +
                "EYECOLOR SHOULD BE INCLUDE IN('Brown', 'Blue', 'Violet', 'Hazel')";

        public ClientHelper(Dictionary<string, ICommand> comands, PrincessRepository repository)
        {
            Messager = new ConsoleMessager();
            Repository = repository;
            Comands = comands;
        }

        public void Start()
        {
            Messager.ShowMessage(msg);
            WaitCommand();
        }

        void WaitCommand()
        {
            ICommand command = null;
            do
            {
                string commandLine = WaitCommandFromConsole();
                List<string> commandList = commandLine.Split(' ').ToList();
                string commandKey = commandList[0];

                commandList.RemoveAt(0);
                if (Comands.ContainsKey(commandKey))
                {
                    bool isGetCommand = Comands.TryGetValue(commandKey, out command);
                    if(command is IParametrizedCommand)
                    {
                        ((IParametrizedCommand)(command)).SetParams((commandList).Select(p => p.Trim()).ToArray());
                    }
                    command.Execute(); 
                }
                else
                {
                    Messager.ShowMessage("Please enter command whitch defined in specification !");
                }
            } while (true);
        }

        string WaitCommandFromConsole()
        {
            string command = Console.ReadLine();
            return command;
        }
    }
}
