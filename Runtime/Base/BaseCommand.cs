using UnityEngine;

namespace Patterns.Command
{
    public abstract class BaseCommand : MonoBehaviour, ICommandWithManager
    {
        private ICommandDoneTask _commandDoneTask;

        public abstract void Execute();

        public void SetCommandManager(ICommandDoneTask commandDone)
        {
            _commandDoneTask = commandDone;

            InitialConfiguration(commandDone);
        }

        public abstract void InitialConfiguration(ICommandDoneTask commandDone);

        protected void NotifyDoneExecution()
        {
            _commandDoneTask.DoneExecutionCommand();
        }
    }
}