namespace Patterns.Command
{
    public interface ICommandManager : ICommandDoneTask, ICommandManagerEvents
    {
        int GetMaxCountExecuteCommand();

        void StartMakeCommandAction();
    }
}