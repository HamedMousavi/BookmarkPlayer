﻿using System;
using System.Collections.Generic;


namespace BookmarkPlayer.Domain
{

    public interface IComposable : ICollection<IComposable>
    {
        string Title();
        DateTime? AddedDate();
        DateTime? DeletedDate();

        void AddTo(ICollection<IComposable> collection);
        void RemoveFrom(ICollection<IComposable> collection);
    }
}