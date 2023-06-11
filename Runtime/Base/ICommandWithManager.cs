namespace Patterns.Command
{
    public interface ICommandWithManager : ICommand
    {
        void SetCommandManager(ICommandDoneTask commandDone);
    }
}