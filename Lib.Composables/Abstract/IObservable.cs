using System;


namespace Lib.Composables.Abstract
{

    public interface IComposableObservable
    {
        void When<T>(Action<T> action);
    }

    public interface IComposableNotifier
    {
        void Notify(object e);
    }
}
