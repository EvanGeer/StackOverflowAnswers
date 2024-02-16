using System.Collections.Generic;
using System.Windows;

namespace StackOverflowAnswers.Wpf
{
    /// <summary>
    /// Interaction logic for ListBoxDataTemplate.xaml
    /// </summary>
    public partial class ListBoxDataTemplate : Window
    {
        public List<string> Data { get; } = new List<string>
        {
            "sample string",
            "longer sample string",
            "sample a bit longer string",
            "sample string",
            "longer sample string",
            "sample a bit longer string",
            "sample string",
            "longer sample string",
            "sample a bit longer string",
            "sample string",
            "longer sample string",
            "sample a bit longer string",
        };
        public ListBoxDataTemplate()
        {
            DataContext = this;
            InitializeComponent();
        }
    }
}
