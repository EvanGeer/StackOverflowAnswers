using System.Collections.Generic;
using System.Windows;

namespace StackOverflowAnswers.Wpf
{
    /// <summary>
    /// Interaction logic for CollapseOnSelected.xaml
    /// </summary>
    public partial class CollapseOnSelected : Window
    {
        public class Car
        {
            public string Name { get; set; }
            public Car(string name) { Name = name; }
        }
        public List<Car> Data { get; } = new List<Car>
        {
            new Car("SF90"),
            new Car("Camaro SS (Gen 5)"),
            new Car("Hellcat"),
        };

        public CollapseOnSelected()
        {
            DataContext = this;
            InitializeComponent();
        }
    }
}
