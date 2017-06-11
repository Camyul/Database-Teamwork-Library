namespace LibraryApp.Core.Contracts
{
    public interface ICommandParser
    {
        ICommand Parse(string commandString);
    }
}
