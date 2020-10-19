using System.Data;
using System.Collections.Generic;
using CommandAPI.Models;

namespace CommandAPI.Data
{
    ///<Summary>
    /// MockCommandApiRepo
    ///</Summary>
    public class MockCommandApiRepo : ICommandApiRepo
    {
        ///<Summary>
        /// CreateCommand
        ///</Summary>
        public void CreateCommand(Command cmd)
        {
            throw new System.NotImplementedException();
        }

        ///<Summary>
        /// DeleteCommand
        ///</Summary>
        public void DeleteCommand(Command cmd)
        {
            throw new System.NotImplementedException();
        }

        ///<Summary>
        /// GetAllCommands
        ///</Summary>
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
        ///<Summary>
        /// GetCommandById
        ///</Summary>
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

        ///<Summary>
        /// SaveChanges
        ///</Summary>
        public bool SaveChanges()
        {
            throw new System.NotImplementedException();
        }

        ///<Summary>
        /// UpdateCommand
        ///</Summary>
        public void UpdateCommand(Command cmd)
        {
            throw new System.NotImplementedException();
        }
    }
}
