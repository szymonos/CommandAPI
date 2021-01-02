using System.Collections.Generic;

using CommandAPI.Models;

namespace CommandAPI.Data
{
    /// <summary>MockCommandApiRepo</summary>
    public class MockCommandApiRepo : ICommandApiRepo
    {
        /// <summary>CreateCommand</summary>
        public void CreateCommand(Command cmd)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>DeleteCommand</summary>
        public void DeleteCommand(Command cmd)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>GetAllCommands</summary>
        public IEnumerable<Command> GetAllCommands()
        {
            var commands = new List<Command>
            {
                new Command
                {
                    Id=0,
                    HowTo="How to generate a migration",
                    CommandLine="dotnet ef migrations add <Name of Migration>",
                    Platform=".Net Core EF"
                },
                new Command
                {
                    Id=1,
                    HowTo="Run Migrations",
                    CommandLine="dotnet ef database update",
                    Platform=".Net Core EF"
                },
                new Command
                {
                    Id=2,
                    HowTo="List active migrations",
                    CommandLine="dotnet ef migrations list",
                    Platform=".Net Core EF"
                }
            };
            return commands;
        }
        /// <summary>GetCommandById</summary>
        public Command GetCommandById(int id)
        {
            return new Command
            {
                Id = 0,
                HowTo = "How to generate a migration",
                CommandLine = "dotnet ef migrations add <Name of Migration>",
                Platform = ".Net Core EF"
            };
        }

        /// <summary>SaveChanges</summary>
        public bool SaveChanges()
        {
            throw new System.NotImplementedException();
        }

        /// <summary>UpdateCommand</summary>
        public void UpdateCommand(Command cmd)
        {
            throw new System.NotImplementedException();
        }
    }
}
