using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;

namespace StackOverflowAnswers.Wpf
{
    public class Sample_DataViewModel
    {
        public Sample_DataViewModel(Sample_Data dataModel, MainViewChartVM.DataProperty dataProperty)
        {
            DataModel = dataModel;
            _currentChartItem = dataProperty;
        }

        public double IndependentValue => DataModel.SampleTime;
        public double DependentValue
        {
            get
            {
                switch (_currentChartItem)
                {
                    case MainViewChartVM.DataProperty.AmbientTemp:
                        return DataModel.AmbientTemp;
                    case MainViewChartVM.DataProperty.RelativeHumidity:
                        return DataModel.RelativeHumidity;
                    case MainViewChartVM.DataProperty.BarometricPressure:
                    case MainViewChartVM.DataProperty.WindSpeed:
                    case MainViewChartVM.DataProperty.WindDirection:
                    default:
                        return 0;
                }
            }
        }
        public Sample_Data DataModel { get; }
        public MainViewChartVM.DataProperty _currentChartItem { get; }
    }
    public class Sample_Data
    {
        public Sample_Data(double sampleTime, double ambientTemp, double relativeHumidity)
        {
            SampleTime = sampleTime;
            AmbientTemp = ambientTemp;
            RelativeHumidity = relativeHumidity;
        }

        public double SampleTime { get; internal set; }
        public double AmbientTemp { get; internal set; }
        public double RelativeHumidity { get; internal set; }
    }

    public partial class MainViewChartVM : ObservableObject
    {
        private const int N_RECORDS = 60;

        private DataProperty _currentChartItem;

        public enum DataProperty
        {
            AmbientTemp,
            RelativeHumidity,
            BarometricPressure,
            WindSpeed,
            WindDirection,
        }

        public MainViewChartVM(DataProperty currentChartItem)
        {
            _currentChartItem = currentChartItem;

            InitializeChart();
        }

        [ObservableProperty]
        private string _chartTitle;
        [ObservableProperty]
        private string _chartUnits;
        [ObservableProperty]
        private ObservableCollection<Sample_DataViewModel> _currentDataSet;

        // ToDo: these are not needed
        //[ObservableProperty]
        //private string _independentValuePath;
        //[ObservableProperty]
        //private double _dependentValue;

        private void InitializeChart()
        {
            // Update button options
            var mockData = new Sample_Data[]{
            new Sample_Data(0,0,4),
            new Sample_Data(1,1,3),
            new Sample_Data(1.5,2,2),
            new Sample_Data(1.6,3,3),
            new Sample_Data(2,4,1),
        };

            // Update chart
            CurrentDataSet = new ObservableCollection<Sample_DataViewModel>(
                mockData.Select(x => new Sample_DataViewModel(x, _currentChartItem)));

        }

    }


    /// <summary>
    /// Interaction logic for ChartingExample.xaml
    /// </summary>
    public partial class ChartingExample : Window
    {
        public ChartingExample()
        {
            DataContext = new MainViewChartVM(MainViewChartVM.DataProperty.AmbientTemp);
            InitializeComponent();
        }
    }
}
