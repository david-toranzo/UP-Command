using System;
using System.Collections.Generic;
using UnityEngine;

namespace Patterns.Command
{
    public class CommandManager : MonoBehaviour, ICommandManager
    {
        [SerializeField] private BaseCommand[] _baseCommands;

        private List<ICommandWithManager> _commands;

        public Action OnStartExecute { get; set; }
        public Action OnFinishAllExecute { get; set; }
        public Action<int> OnFinishOneExecute { get; set; }

        protected int _commandInternalCount = 0;

        private void Awake()
        {
            AddAndSetNodes(_baseCommands);
        }

        public void AddAndSetNodes(ICommandWithManager[] commands)
        {
            _commands = new List<ICommandWithManager>();

            foreach (ICommandWithManager nodeCommander in commands)
            {
                nodeCommander.SetCommandManager(this);
                _commands.Add(nodeCommander);
            }
        }

        public void StartMakeCommandAction()
        {
            OnStartExecute?.Invoke();

            _commandInternalCount = 0;

            RunNextCommand();
        }

        public void DoneExecutionCommand()
        {
            _commandInternalCount++;

            OnFinishOneExecute?.Invoke(_commandInternalCount);

            if (_commandInternalCount >= _commands.Count)
            {
                FinishAllExecutionCommand();
                return;
            }

            RunNextCommand();
        }

        public void RunNextCommand()
        {
            _commands[_commandInternalCount].Execute();
        }

        private void FinishAllExecutionCommand()
        {
            OnFinishAllExecute?.Invoke();
        }

        public int GetMaxCountExecuteCommand() => _commands.Count;
    }
}