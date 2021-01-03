using System;
using System.Collections.Generic;
using System.Linq;

using CommandAPI.Models;

namespace CommandAPI.Data {

    /// <summary>
    /// SQL implementation of ICommandApiRepo
    /// </summary>
    public class SqlCommandApiRepo : ICommandApiRepo {

        private readonly CommandContext _context;

        public SqlCommandApiRepo(CommandContext context) =>
            _context = context;

        public void CreateCommand(Command cmd) {
            if (cmd == null) {
                throw new ArgumentNullException(nameof(cmd));
            }
            _context.CommandItems.Add(cmd);
        }

        public void DeleteCommand(Command cmd) {
            if (cmd == null) {
                throw new ArgumentNullException(nameof(cmd));
            }
            _context.CommandItems.Remove(cmd);
        }

        public IEnumerable<Command> GetAllCommands() =>
            _context.CommandItems.ToList();

        public Command GetCommandById(int id) =>
            _context.CommandItems.FirstOrDefault(p => p.Id == id);

        public bool SaveChanges() =>
            _context.SaveChanges() >= 0;

        public void UpdateCommand(Command cmd) {
            // No implementation required.
        }
    }
}
