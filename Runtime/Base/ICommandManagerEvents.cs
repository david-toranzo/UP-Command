using System;

namespace Patterns.Command
{
    public interface ICommandManagerEvents
    {
        Action OnStartExecute { get; set; }
        Action OnFinishAllExecute { get; set; }
        Action<int> OnFinishOneExecute { get; set; }
    }
}