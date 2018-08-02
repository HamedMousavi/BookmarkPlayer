using System;
using System.Collections.Generic;


namespace Lib.Composables.Abstract
{

    public interface IExecutable : IComposable
    {
        void Execute();
        bool IsExecuted();
        IEnumerable<DateTime> ExecutionHistory();
    }
}
