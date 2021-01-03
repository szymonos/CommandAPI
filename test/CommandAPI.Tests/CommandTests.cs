using System;

using CommandAPI.Models;

using Xunit;

namespace CommandAPI.Tests {
    public class CommandTests : IDisposable {
        Command testCommand;
        public CommandTests() {
            testCommand = new Command {
                HowTo = "Do something",
                Platform = "Some platform",
                CommandLine = "Some commandline"
            };
        }

        public void Dispose() {
            testCommand = null;
            GC.SuppressFinalize(this);
        }

        [Fact]
        public void CanChangeHowTo() {
            // Arrange

            // Act
            testCommand.HowTo = "Execute Unit Tests";
            // Assert
            Assert.Equal("Execute Unit Tests", testCommand.HowTo);
        }

        [Fact]
        public void CanChangePlatform() {
            // Arrange

            // Act
            testCommand.Platform = "Execute Unit Tests";
            // Assert
            Assert.Equal("Execute Unit Tests", testCommand.Platform);
        }

        [Fact]
        public void CanChangeCommandLine() {
            // Arrange

            // Act
            testCommand.CommandLine = "Execute Unit Tests";
            // Assert
            Assert.Equal("Execute Unit Tests", testCommand.CommandLine);
        }
    }
}
