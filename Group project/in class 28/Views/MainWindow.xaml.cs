using in_class_28.Models; 
using System;
using System.Windows;
using System.Windows.Controls;

namespace in_class_28.Views
{
    public partial class MainWindow : Window
    {
        private MainWindowModel mainWindowModel = new MainWindowModel(); 

        public MainWindow()
        {
            InitializeComponent();
        }

        private void CalculateAge_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(nameInput.Text))
            {
                MessageBox.Show("Please enter your name.");
                return;
            }

            if (dobDatePicker.SelectedDate == null || targetDatePicker.SelectedDate == null)
            {
                MessageBox.Show("Please select both dates.");
                return;
            }

            DateTime birthDate = dobDatePicker.SelectedDate.Value;
            DateTime targetDate = targetDatePicker.SelectedDate.Value;
            string name = nameInput.Text;

            int ageYears = targetDate.Year - birthDate.Year;
            if (birthDate > targetDate.AddYears(-ageYears)) ageYears--;

            int ageMonths = targetDate.Month - birthDate.Month;
            if (ageMonths < 0) ageMonths += 12;

            int ageDays = targetDate.Day - birthDate.Day;
            if (ageDays < 0)
            {
                DateTime prevMonth = targetDate.AddMonths(-1);
                ageDays += DateTime.DaysInMonth(prevMonth.Year, prevMonth.Month);
            }

            // Create an AgeModel instance
            AgeModel ageModel = new AgeModel
            {
                Name = name,
                BirthDate = birthDate,
                TargetDate = targetDate,
                AgeYears = ageYears,
                AgeMonths = ageMonths,
                AgeDays = ageDays
            };

            // Insert into database using MainWindowModel
            mainWindowModel.InsertAgeData(ageModel);

            // Show result window
            ResultWindow resultWindow = new ResultWindow(name, ageYears, ageMonths, ageDays);
            resultWindow.Show();
            this.Close();
        }
    }
}
