using ComfortStoreLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
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

namespace Admin.Pages
{
    /// <summary>
    /// Логика взаимодействия для StatPage.xaml
    /// </summary>
    public partial class StatPage : Page
    {
        public StatPage()
        {
            InitializeComponent();
            var area = MainChart.ChartAreas.Add("Main chart");
            var legend = MainChart.Legends.Add("Main legend");
            area.AxisX.Interval = 1;
            area.AxisY.Interval = 1;
        }

        private void GenerateBt_Click(object sender, RoutedEventArgs e)
        {
            var startDate = StartDate.SelectedDate;
            var endDate = EndDate.SelectedDate;
            if (!startDate.HasValue)
            {
                MessageBox.Show("Выберите даты", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            MainChart.Series.Clear();


            foreach (var delivery in App.db.Order)
            {
                var seria = MainChart.Series.Add($"#{delivery.User.FullName}");
                var chartData = App.db.Order.ToList()
                    .Where(o => o.Date >= startDate.Value.Date && o.Date <=
           endDate)
                    .GroupBy(o => o.UserId)
                    .ToDictionary(key => key.Key, value => value.Count());
                seria.Points.DataBindXY(chartData.Keys, chartData.Values);
                seria.BorderWidth = 5;
                seria.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column;
            }
        }
    }
}
