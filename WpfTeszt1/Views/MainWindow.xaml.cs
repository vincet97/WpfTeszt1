using System;
using System.Windows;
using System.Windows.Controls;
using WpfTeszt1.ViewModels;

namespace WpfTeszt1.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindowViewModel ViewModel { get; set; }
        public MainWindow()
        {   

            InitializeComponent();
            ViewModel = new MainWindowViewModel();
            this.DataContext = ViewModel;
            this.Closed += new EventHandler(MainWindow_Closed);
        }

        private void SpeedCombo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
           // System.Diagnostics.Debug.WriteLine("Az Argumentek");
            String str = ((ComboBox)sender).SelectedItem as String;
            
            
            
           System.Diagnostics.Debug.WriteLine(ViewModel.ToString());
           // System.Diagnostics.Debug.WriteLine(str);
           // System.Diagnostics.Debug.WriteLine(e.OriginalSource.ToString());
        }

        private void FileSelectButton_Click(object sender, RoutedEventArgs e)
        {

        }
        void MainWindow_Closed(object sender, EventArgs e)
        {
            if(ViewModel.Tracking == "Tracking")
            
            {
                ViewModel.t1.Abort();
            }
        }
    }
}
