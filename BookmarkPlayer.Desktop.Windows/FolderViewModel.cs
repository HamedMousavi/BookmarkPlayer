using BookmarkPlayer.Domain;
using System.ComponentModel;
using System.Runtime.CompilerServices;


namespace BookmarkPlayer.Desktop.Windows
{

    public class FolderViewModel : Folder, INotifyPropertyChanged
    {

        public new string Name
        {
            get => _name;
            set { _name = value; OnPropertyChanged(); }
        }


        public string Path
        {
            get => _path;
            set { _path = value; OnPropertyChanged(); }
        }


        private string _path;


        #region PropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion PropertyChanged
    }
}
