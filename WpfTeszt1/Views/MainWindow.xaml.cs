using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
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
    }
}
