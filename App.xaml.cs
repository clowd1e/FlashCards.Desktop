using FlashCards.Desktop.ViewModels;
using System.Configuration;
using System.Data;
using System.Windows;

namespace FlashCards.Desktop
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            MainWindow = new LoginWindow()
            {
                DataContext = new LoginViewModel()
            };
            MainWindow.Show();

            //MainWindow = new MainWindow()
            //{
            //    DataContext = new MainViewModel()
            //};
            //MainWindow.Show();

            base.OnStartup(e);
        }
    }

}
