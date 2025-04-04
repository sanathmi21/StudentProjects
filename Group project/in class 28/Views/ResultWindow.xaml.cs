using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace in_class_28.Views
{
    public partial class ResultWindow : Window
    {
        public ResultWindow(string name, int ageYears, int ageMonths, int ageDays)
        {
            InitializeComponent();

            // Display the result in the desired format
            resultDisplay.Text = $"Hi, {name} your age is {ageYears} years, {ageMonths} months, and {ageDays} days.";
        }

        // Close the result window
        private void CloseWindow_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}