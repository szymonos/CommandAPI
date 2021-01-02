using System.Collections.Generic;
using CommandAPI.Models;

namespace CommandAPI.Data
{
    ///<Summary>
    /// ICommandApiRepo
    ///</Summary>
    public interface ICommandApiRepo
    {
        ///<Summary>
        /// SaveChanges
        ///</Summary>
        bool SaveChanges();

        ///<Summary>
        /// GetAllCommands
        ///</Summary>
        IEnumerable<Command> GetAllCommands();
        ///<Summary>
        /// GetCommandById
        ///</Summary>
        Command GetCommandById(int id);
        ///<Summary>
        /// CreateCommand
        ///</Summary>
        void CreateCommand(Command cmd);
        ///<Summary>
        /// UpdateCommand
        ///</Summary>
        void UpdateCommand(Command cmd);
        ///<Summary>
        /// DeleteCommand
        ///</Summary>
        void DeleteCommand(Command cmd);
    }
}
