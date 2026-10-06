using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace MultiApp
{
    /// <summary>
    /// Interaction logic for EditWindow.xaml
    /// </summary>
    public partial class EditWindow : Window
    {
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public int Age { get; private set; }

        public string FullName => $"{FirstName} {LastName}";

        public EditWindow(string firstName, string lastName, int age)
        {
            InitializeComponent();

            FirstName = firstName;
            LastName = lastName;
            Age = age;

            FirstNameBox.Text = firstName;
            LastNameBox.Text = lastName;
            AgeBox.Text = age.ToString();
        }

        private void FinishButton(object sender, RoutedEventArgs e)
        {
            if (!int.TryParse(AgeBox.Text, out int age) || age < 0)
            {
                MessageBox.Show("Please enter a real age.",
                                "Invalid Age", MessageBoxButton.OK, MessageBoxImage.Warning);
                AgeBox.Focus();
                AgeBox.SelectAll();
                return; // stay open
            }

            FirstName = FirstNameBox.Text.Trim();
            LastName = LastNameBox.Text.Trim();
            Age = age;

            DialogResult = true; // closes the window
        }

        private void CancelButton(object sender, RoutedEventArgs e)
        {
            DialogResult = false; // closes but doesn't change the window
        }
    }
}
