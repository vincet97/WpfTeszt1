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

        private void ModifCombo1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
         //   System.Diagnostics.Debug.WriteLine("Az Argumentek");
         //   System.Diagnostics.Debug.WriteLine( ViewModel.ToString());
           
        }

        private void ModifCombo2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
         //   System.Diagnostics.Debug.WriteLine("Az Argumentek");
           // System.Diagnostics.Debug.WriteLine(ViewModel.ToString());
        }

        private void SpeedCombo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
           // System.Diagnostics.Debug.WriteLine("Az Argumentek");
            String str = ((ComboBox)sender).SelectedItem as String;
            
            
            
          //  System.Diagnostics.Debug.WriteLine(ViewModel.ToString());
           // System.Diagnostics.Debug.WriteLine(str);
           // System.Diagnostics.Debug.WriteLine(e.OriginalSource.ToString());
        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataGrid dataGrid = sender as DataGrid;
            if (e.AddedItems != null && e.AddedItems.Count > 0)
            {
                // find row for the first selected item
                DataGridRow row = (DataGridRow)dataGrid.ItemContainerGenerator.ContainerFromItem(e.AddedItems[0]);
                if (row != null)
                {
                   
                    
                }
            }
            //System.Diagnostics.Debug.WriteLine(cellV);
            //System.Diagnostics.Debug.WriteLine(sender.GetType());
            System.Diagnostics.Debug.WriteLine("Lefutott a Teljes grid event");
        }
        static T GetVisualChild<T>(Visual parent) where T : Visual
        {
            T child = default(T);
            int numVisuals = VisualTreeHelper.GetChildrenCount(parent);
            for (int i = 0; i < numVisuals; i++)
            {
                Visual v = (Visual)VisualTreeHelper.GetChild(parent, i);
                child = v as T;
                if (child == null) child = GetVisualChild<T>(v);
                if (child != null) break;
            }
            return child;
        }
    }
}
