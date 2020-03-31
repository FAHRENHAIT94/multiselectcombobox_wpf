using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MULTİSELECTCOMBO
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DaysCollection dc = new DaysCollection();
        public MainWindow()
        {
            InitializeComponent();
           
            dc.Add(new ComboTemplate<string>(false, "Select All"));
            dc.Add(new ComboTemplate<string>(false, "Sunday"));
            dc.Add(new ComboTemplate<string>(false, "Monday"));
            dc.Add(new ComboTemplate<string>(false, "Tuesday"));
            dc.Add(new ComboTemplate<string>(true, "Wednesday"));
            dc.Add(new ComboTemplate<string>(false, "Thursday"));
            dc.Add(new ComboTemplate<string>(false, "Friday"));
            dc.Add(new ComboTemplate<string>(false, "Saturday"));
            customcombo.ItemsSource = dc;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }

       

        private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            CheckBox _selectall = sender as CheckBox;
            if (_selectall.IsChecked.HasValue)
                if (!_selectall.IsChecked.Value && _selectall.Content == "Select All")
                {
                    foreach (ComboTemplate<string> _val in dc)
                    {
                        _val.IsSelected = false;
                    }
                }
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            CheckBox _selectall = sender as CheckBox;
            if (_selectall.IsChecked.HasValue)
                if (_selectall.IsChecked.Value && _selectall.Content == "Select All")
                {
                    foreach (ComboTemplate<string> _val in dc)
                    {
                        _val.IsSelected = true;
                    }
                }

        }

       
       

    }

    class DaysCollection : ObservableCollection<ComboTemplate<string>>
    {

    }

    class ComboTemplate<T> : INotifyPropertyChanged
    {

        private bool _IsSelected;

        public bool IsSelected
        {
            set
            {
                if (IsSelected != value)
                {
                    _IsSelected = value;
                    OnPropertyChange("IsSelected");
                }
            }
            get
            {
                return _IsSelected;
            }
        }

        public T Data { set; get; }

        public ComboTemplate(T data)
        {
            Data = data;
        }

        public ComboTemplate(bool isSelected, T data)
        {
            _IsSelected = isSelected;
            Data = data;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChange(string propertyname)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyname));
            }
        }
    }
}

