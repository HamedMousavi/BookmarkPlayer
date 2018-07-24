using System;
using System.Collections.Generic;


namespace Lib.Composables.Abstract
{

    public interface IComposable : ICollection<IComposable>
    {
        DateTime? AddedDate();
        DateTime? DeletedDate();

        void AddTo(ICollection<IComposable> collection);
        void RemoveFrom(ICollection<IComposable> collection);
    }
}