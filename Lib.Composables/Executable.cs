using Lib.Composables.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;


namespace Lib.Composables
{

    public class Executable : Progressable, IExecutable
    {

        private ICollection<DateTime> _history;


        public virtual void Execute()
        {
            if (_history == null) _history = new List<DateTime>();
            _history.Add(DateTime.UtcNow);

            _children?.OfType<IExecutable>()?.ToList()?.ForEach(e => e.Execute());
        }


        public virtual IEnumerable<DateTime> ExecutionHistory()
        {
            return _history;
        }


        public virtual bool IsExecuted()
        {
            return _history != null && _history.Any();
        }


        public virtual Progress ExecutionProgress()
        {
            return new Progress(
                _children.OfType<IExecutable>()
                    .Count(e => e.IsExecuted())
                , GetCount());
        }
    }
}
