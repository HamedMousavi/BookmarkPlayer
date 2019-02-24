﻿using System.Windows;


namespace BookmarkPlayer.Desktop.Windows
{

    public partial class App : Application
    {

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            var loader = new BootStrapper();
            loader.Bootstrap();
            loader.Locate<MainWindow>().Show();
        }
    }

}
