using BookmarkPlayer.Domain.Abstract;


namespace BookmarkPlayer.Domain
{

    public class Progressable : Navigatable, IProgressable
    {

        public Progress Progress()
        {
            return new Progress(_active == null ? 0 : CurrentItemIndex(), GetCount());
        }
    }


    public class Progress
    {
        private readonly double _index;
        private readonly double _total;

        public Progress(int index, int total)
        {
            _index = index;
            _total = total;
        }


        public double Percentage()
        {
            return 100.0 * Share();
        }


        public static implicit operator double(Progress progress)
        {
            return progress.Share();
        }


        private double Share()
        {
            if (_total <= 0 || _index <= 0) return 0;

            return _index / _total;
        }
    }
}
