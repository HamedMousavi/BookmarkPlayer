using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;


namespace BookmarkPlayer.Desktop.Windows
{

    public class MainWindowViewModel : INotifyPropertyChanged
    {

        public ObservableCollection<FolderViewModel> Folders { get; }

        public string DirectoriesDetail => null; // $"Directories ({(Directories == null ? 0 : Directories.Count)})";
        public string FilesDetails => null; // $"Files ({(PlayListViewModel == null ? 0 : PlayListViewModel.Count)})";
        public ICommand PlaySelectedCommand => null; // new RelayCommand(a => SelectedDirectory?.PlaySelected(), a => SelectedDirectory != null && SelectedDirectory.CanPlaySelected());
        public ICommand AddDirectoryCommand => null; // new RelayCommand(WhenAddDirectoryButtonClicked);
        public ICommand RemoveDirectoryCommand => null; // new RelayCommand(WhenRemoveDirectoryButtonClicked, a => SelectedDirectory != null);
        public ICommand PlayPreviousCommand => null; // new RelayCommand(a => SelectedDirectory?.PlayPrevious(), a => SelectedDirectory != null && SelectedDirectory.CanPlayPrevious());
        public ICommand PlayCurrentCommand => null; // new RelayCommand(a => SelectedDirectory?.PlayActive(), a => SelectedDirectory != null && SelectedDirectory.CanPlayActive());
        public ICommand PlayNextCommand => null; // new RelayCommand(a => SelectedDirectory?.PlayNext(), a => SelectedDirectory != null && SelectedDirectory.CanPlayNext());
        public ICommand SetBookmarkCommand => null; // new RelayCommand(a => SelectedDirectory?.SelectFile(), a => SelectedDirectory != null && SelectedDirectory.CanPlaySelected());
        public object Status => null;
        public object SelectedDirectory { get; set; }
        public object SelectedPlayableViewModel { get; set; }
        public object PlayListViewModel => null;

        public MainWindowViewModel()
        {
            Folders = new ObservableCollection<FolderViewModel>();
        }

        //public AppStatus Status => AppStatus.Instance;
        //public Directories Directories { get; }
        //public DirectoryViewModel SelectedDirectory
        //{
        //    get => _selectedDirectory;
        //    set
        //    {
        //        _selectedDirectory = value;
        //        OnPropertyChanged();
        //        OnPropertyChanged(nameof(PlayListViewModel));
        //        OnPropertyChanged(nameof(FilesDetails));

        //        if (_selectedDirectory != null &&
        //            _selectedDirectory.FileListViewModel != null)
        //        {
        //            var active = _selectedDirectory.FileListViewModel.GetActive();
        //            if (active != null)
        //            {
        //                SelectedPlayableViewModel = active;
        //            }
        //        }
        //    }
        //}
        //public Playable SelectedPlayableViewModel
        //{
        //    get { return SelectedDirectory?.FileListViewModel.Selected; }
        //    set { SelectedDirectory.FileListViewModel.Selected = value; OnPropertyChanged(); }
        //}
        //public PlayableList PlayListViewModel => SelectedDirectory?.FileListViewModel;

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
