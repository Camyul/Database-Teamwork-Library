using LibraryApp.Core.Contracts;
using System;
using System.Linq;
using System.Reflection;

namespace LibraryApp.Core.Providers
{
    public class CommandParser : ICommandParser
    {
        public ICommand Parse(string commandString)
        {
            var commandName = commandString.Split(' ')[0];
            var commandTypeInfo = this.TranslateCommand(commandName);
            var command = Activator.CreateInstance(commandTypeInfo) as ICommand;

            return command;
        }

        private TypeInfo TranslateCommand(string commandName)
        {
            var currentAssembly = this.GetType().GetTypeInfo().Assembly;
            var commandTypeInfo = currentAssembly.DefinedTypes
                .Where(type => type.ImplementedInterfaces.Any(i => i == typeof(ICommand)))
                .Where(type => type.Name.ToLower().Contains(commandName.ToLower()))
                .SingleOrDefault();

            if (commandTypeInfo == null)
            {
                throw new ArgumentException("Wrong command");
            }

            return commandTypeInfo;
        }
    }
}
