using System.Windows;
using System.Windows.Input;

namespace StackOverflowAnswers.Wpf
{
    /// <summary>
    /// Interaction logic for AnimatedBorder.xaml
    /// </summary>
    public partial class AnimatedBorder : Window
    {
        public AnimatedBorder()
        {
            InitializeComponent();

        }
        private void AnimatedBorder_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.MouseDevice.LeftButton == MouseButtonState.Pressed)
                DragMove();
        }
    }
}
