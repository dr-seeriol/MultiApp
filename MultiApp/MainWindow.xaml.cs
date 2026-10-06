using System.Windows;

namespace MultiApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 

    
    public partial class MainWindow : Window
    {
        public string FirstName { get; set; } = "Evil";
        public string LastName { get; set; } = "Wizard";
        public int Age { get; set; } = 700;

        // Read-only
        public string FullName => $"{FirstName} {LastName}";

        public MainWindow()
        {
            InitializeComponent();
            UpdateDisplay();
        }

        private void EditButton(object sender, RoutedEventArgs e)
        {
            var editWindow = new EditWindow(FirstName, LastName, Age)
            {
                Owner = this
            };

            
            if (editWindow.ShowDialog() == true)
            {
                FirstName = editWindow.FirstName;
                LastName = editWindow.LastName;
                Age = editWindow.Age;
                UpdateDisplay();
            }
        }

        private void UpdateDisplay()
        {
            NameValueLabel.Content = FullName;
            AgeValueLabel.Content = Age;
        }
    }
}
