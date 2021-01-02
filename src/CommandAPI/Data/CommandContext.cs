using Microsoft.EntityFrameworkCore;

using CommandAPI.Models;

namespace CommandAPI.Data {

    /// <summary>
    /// DB Context class - representation of the Database
    /// </summary>
    public class CommandContext : DbContext {

        public CommandContext(DbContextOptions<CommandContext> options)
            : base(options) { }

        /// <summary>
        /// DbSet - representation of a table
        /// </summary>
        /// <value></value>
        public DbSet<Command> CommandItems { get; set; }
    }
}
