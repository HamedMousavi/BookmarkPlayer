using System;
using System.Collections.Generic;


namespace BookmarkPlayer.Domain.Abstract
{

    public interface IComposable : ICollection<IComposable>
    {
        DateTime? AddedDate();
        DateTime? DeletedDate();

        void AddTo(ICollection<IComposable> collection);
        void RemoveFrom(ICollection<IComposable> collection);
    }
}