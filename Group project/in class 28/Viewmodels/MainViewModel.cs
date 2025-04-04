using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;
using in_class_28.Models;
using MySql.Data.MySqlClient;

namespace in_class_28.Viewmodels
{
    public class MainViewModel 
    {
        private string connectionString = "server=localhost;database=agecalculator;user=root;password=Sanathmi@21;"; 

        public void InsertAgeData(AgeModel ageModel)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "INSERT INTO person (Name, BirthDate, TargetDate, AgeYears, AgeMonths, AgeDays) " +
                                   "VALUES (@Name, @BirthDate, @TargetDate, @AgeYears, @AgeMonths, @AgeDays)";

                    using (MySqlCommand cmd = new MySqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@Name", ageModel.Name);
                        cmd.Parameters.AddWithValue("@BirthDate", ageModel.BirthDate);
                        cmd.Parameters.AddWithValue("@TargetDate", ageModel.TargetDate);
                        cmd.Parameters.AddWithValue("@AgeYears", ageModel.AgeYears);
                        cmd.Parameters.AddWithValue("@AgeMonths", ageModel.AgeMonths);
                        cmd.Parameters.AddWithValue("@AgeDays", ageModel.AgeDays);

                        cmd.ExecuteNonQuery();
                    }

                    MessageBox.Show("Successfully inserted into database!");
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show("MySQL Error: " + ex.Message);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }
    }
}
