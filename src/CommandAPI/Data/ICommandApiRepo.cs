using System.Collections.Generic;

using CommandAPI.Models;

namespace CommandAPI.Data {
    /// <summary>ICommandApiRepo</summary>
    public interface ICommandApiRepo {
        /// <summary>SaveChanges</summary>
        bool SaveChanges();

        /// <summary>GetAllCommands</summary>
        IEnumerable<Command> GetAllCommands();

        /// <summary>GetCommandById</summary>
        Command GetCommandById(int id);

        /// <summary>CreateCommand</summary>
        void CreateCommand(Command cmd);

        /// <summary>UpdateCommand</summary>
        void UpdateCommand(Command cmd);

        /// <summary>DeleteCommand</summary>
        void DeleteCommand(Command cmd);
    }
}
