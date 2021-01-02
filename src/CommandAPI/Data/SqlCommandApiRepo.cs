using System.Collections.Generic;
using System.Linq;

using CommandAPI.Models;

namespace CommandAPI.Data {

    /// <summary>
    /// SQL implementation of ICommandApiRepo
    /// </summary>
    public class SqlCommandApiRepo : ICommandApiRepo {

        private readonly CommandContext _context;

        public SqlCommandApiRepo(CommandContext context) {
            _context = context;
        }

        public void CreateCommand(Command cmd) {
            throw new System.NotImplementedException();
        }

        public void DeleteCommand(Command cmd) {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Command> GetAllCommands() {
            return _context.CommandItems.ToList();
        }

        public Command GetCommandById(int id) {
            return _context.CommandItems.FirstOrDefault(p =>
                p.Id == id);
        }

        public bool SaveChanges() {
            throw new System.NotImplementedException();
        }

        public void UpdateCommand(Command cmd) {
            throw new System.NotImplementedException();
        }
    }
}
