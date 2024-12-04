using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace H11Oef1SnelsteAtleet
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            nameTextBox.Focus();
        }

        string[,] athleteData = new string[100, 2];
        int currentIndex = 0;

        private void newButton_Click(object sender, RoutedEventArgs e)
        {
            int timeCurrent;
            bool isValidNumber = int.TryParse(timeTextBox.Text, out timeCurrent);

            if (currentIndex >= athleteData.GetLength(0))
            {
                MessageBox.Show("Het maximale aantal inputs is bereikt", "Te veel inputs", MessageBoxButton.OK, MessageBoxImage.Stop);
            }
            else
            { 
                if (isValidNumber == true)       // of 'if (isValidNumber)' is eigenlijk al genoeg
                {
                    athleteData[currentIndex, 0] = nameTextBox.Text;
                    athleteData[currentIndex, 1] = timeCurrent.ToString();
                    currentIndex++;
                }

                nameTextBox.Clear();
                timeTextBox.Clear();
                resultTextBox.Clear();
                nameTextBox.Focus();
            }
        }

        private void clearButton_Click(object sender, RoutedEventArgs e)
        {
            nameTextBox.Text = string.Empty;
            timeTextBox.Text = string.Empty;
            resultTextBox.Text = string.Empty;
            Array.Clear(athleteData, 0, athleteData.Length);
            currentIndex = 0;
            nameTextBox.Focus();
        }

        private void fastestButton_Click(object sender, RoutedEventArgs e)
        {

            if (currentIndex == 0)
            {
                MessageBox.Show("Geen atleten gegeven","Geen atleten", MessageBoxButton.OK, MessageBoxImage.Error);
                nameTextBox.Focus();
            }
            else
            {
                int[] times = new int[currentIndex];

                for (int i = 0; i < currentIndex; i++)
                {
                    times[i] = int.Parse(athleteData[i, 1]);
                }

                Array.Sort(times);
                Array.Reverse(times);

                string[] sortedNames = new string[times.Length];

                for (int i = 0; i < currentIndex; i++)
                {
                    for (int j = 0; j < currentIndex; j++)
                    {
                        if (times[i] == int.Parse(athleteData[j, 1]))
                        {
                            sortedNames[i] = athleteData[j, 0];
                            athleteData[j, 1] = "-1";           // Mark this entry as processed to avoid duplicate matching
                        }
                    }
                }
                
                for (int i = 0; i < currentIndex; i++)
                {
                    
                    int time = times[i];

                    int hourAmount = time / 3600;
                    int minutesAmount = (time % 3600) / 60;
                    int secondsAmount = (time % 3600) % 60;

                    resultTextBox.Text += $"   {sortedNames[i]} : {hourAmount} hours {minutesAmount} minutes {secondsAmount} seconds \n";
                }
            }    
        }

        private void closeButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}