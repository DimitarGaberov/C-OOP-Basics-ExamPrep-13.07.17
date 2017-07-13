using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Engine
{
    private bool isRunning;
    private NationsBuilder nationsBuilder;

    public Engine()
    {
        this.isRunning = true;
        this.nationsBuilder = new NationsBuilder();
    }

    public void Run()
    {
        while (this.isRunning)
        {
            string inputCommand = this.ReadInput();
            List<string> commandParameters = this.ParseCommand(inputCommand);
            this.DistributeCommand(commandParameters);
        }
    }

    private void DistributeCommand(List<string> commandParameters)
    {
        string command = commandParameters[0];
        commandParameters.Remove(command);

        switch (command)
        {
            case "Bender":
                this.nationsBuilder.AssignBender(commandParameters);
                break;
            case "Monument":
                this.nationsBuilder.AssignMonument(commandParameters);
                break;
            case "Status":
                string status = this.nationsBuilder.GetStatus(commandParameters[0]);
                this.OutputWriter(status);
                break;
            case "War":
                this.nationsBuilder.IssueWar(commandParameters[0]);
                break;
            case "Quit":
                string record = this.nationsBuilder.GetWarsRecord();
                this.OutputWriter(record);
                isRunning = false;
                break;
        }
    }

    private List<string> ParseCommand(string inputCommand)
    {
        return inputCommand.Split(' ').ToList();
    }

    private string ReadInput()
    {
        return Console.ReadLine();
    }

    private void OutputWriter(string status) => Console.WriteLine(status);
}
