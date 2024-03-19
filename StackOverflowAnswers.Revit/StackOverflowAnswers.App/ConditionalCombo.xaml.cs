using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace StackOverflowAnswers.Wpf
{
    /// <summary>
    /// Interaction logic for ConditionalCombo.xaml
    /// </summary>
    public partial class ConditionalCombo : Window
    {
        public ConditionalCombo()
        {
            this.DataContext = new ConditionalComboViewModel();
            InitializeComponent();
        }
    }

    public class ConditionalComboViewModel : INotifyPropertyChanged
    {
        private List<string> items;
        private string selectedItem;
        private bool isToggleButtonEnabled = true;
        public ConditionalComboViewModel()
        {
            Items = new List<string> { "item1", "item2", "item3" };
        }

        public List<string> Items
        {
            get => items;
            set
            {
                items = value;
                OnPropertyChanged();
            }
        }
public bool IsToggleButtonEnabled
{
    get => isToggleButtonEnabled;
    set
    {
        isToggleButtonEnabled = value;
        OnPropertyChanged();
        OnPropertyChanged(nameof(DisplayText));
        OnPropertyChanged(nameof(State));
        OnPropertyChanged(nameof(ComboBoxVisibility));
        OnPropertyChanged(nameof(TextBlockVisibility));
    }
}
public Visibility ComboBoxVisibility => IsToggleButtonEnabled ? Visibility.Visible : Visibility.Collapsed;
public Visibility TextBlockVisibility => IsToggleButtonEnabled ? Visibility.Hidden : Visibility.Visible;


        public string DisplayText 
{ 
    get => IsToggleButtonEnabled ? selectedItem : string.Empty; 
}

        public string State
        {
            get => IsToggleButtonEnabled ? "On" : "Off";
        }

        public string SelectedItem
        {
            get => selectedItem;
            set
            {
                if (!isToggleButtonEnabled) 
                    return; // prevent hiding the text from resetting the selection
                selectedItem = value;
                OnPropertyChanged();
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string prop = null)
        {
            if (string.IsNullOrWhiteSpace(prop)) return;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
