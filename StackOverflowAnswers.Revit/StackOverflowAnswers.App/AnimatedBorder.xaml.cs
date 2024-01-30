using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

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
