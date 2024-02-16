using System;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;
using System.Windows.Controls.Primitives;

namespace StackOverflowAnswers.Wpf
{
    /// <summary>
    /// Interaction logic for ScrollingTextBox.xaml
    /// </summary>
    public partial class ScrollingTextBox : Window
    {
        private Timer _timer;

        public ScrollingTextBox()
        {
            InitializeComponent();

            _timer = new Timer(500);
            _timer.Elapsed += (s, e) => AddtoLogWindow($"\n{DateTime.Now}");
            _timer.Start();
        }

        public async Task AddtoLogWindow(string text)
        {
            await Dispatcher.InvokeAsync(() =>
            {
                //if (logText.Length > 10000)
                //{
                //    logText = "";
                //}
                //logText += text;
                txtbxCommLog.Text += text;
                scrollViewer.ScrollToEnd();
            });
        }
    }

    public class LayerView : MultiSelector
    {
        public static readonly DependencyProperty PathStyleProperty =
            DependencyProperty.RegisterAttached(
                nameof(PathStyle),
                typeof(Style),
                typeof(LayerView),
                new FrameworkPropertyMetadata(null,
                    FrameworkPropertyMetadataOptions.AffectsRender));


        // Declare a set accessor method.
        public static Style GetPathStyle(UIElement target) =>
            (Style)target.GetValue(PathStyleProperty);
        public static void SetPathStyle(UIElement target, Style value) =>
            target.SetValue(PathStyleProperty, value);
        public Style PathStyle
        {
            get => (Style)GetValue(PathStyleProperty);
            set => SetValue(PathStyleProperty, value);
        }

        //...etc. etc -- this is a 2,000 lines of code)
        public static readonly DependencyProperty HasFishProperty =
    DependencyProperty.RegisterAttached(
          "HasFish",
          typeof(bool?),
          typeof(LayerView),
          new FrameworkPropertyMetadata(defaultValue: false,
              flags: FrameworkPropertyMetadataOptions.AffectsRender)
        );

        // Declare a get accessor method.
        public static bool GetHasFish(UIElement target) =>
            (bool)target.GetValue(HasFishProperty);

        // Declare a set accessor method.
        public static void SetHasFish(UIElement target, bool value) =>
            target.SetValue(HasFishProperty, value);
    }
}
