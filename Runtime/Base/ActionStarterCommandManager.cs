using UnityEngine;

namespace Patterns.Command
{
    public class ActionStarterCommandManager : MonoBehaviour
    {
        [SerializeField] private CommandManager _commandManager;

        private void Start()
        {
            _commandManager.StartMakeCommandAction();
        }
    }
}
