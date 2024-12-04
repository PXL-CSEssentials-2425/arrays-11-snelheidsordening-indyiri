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

        string[] athletes = new string[100];
        int[] times = new int[100];
        int currentIndex = 0;
        int fastestIndex = -1;

        string nameFastest = "";
        int timeFastest;

        private void newButton_Click(object sender, RoutedEventArgs e)
        {
            int timeCurrent;
            bool isValidNumber = int.TryParse(timeTextBox.Text, out timeCurrent);

            if (currentIndex >= athletes.Length)
            {
                MessageBox.Show("Maximum number of athletes reached", "Too many inputs", MessageBoxButton.OK, MessageBoxImage.Stop);
            }
            else
            { 
                if (isValidNumber == true)       // of 'if (isValidNumber)' is eigenlijk al genoeg
                {
                    athletes[currentIndex] = nameTextBox.Text;
                    times[currentIndex] = timeCurrent;

                    if (fastestIndex == -1 || timeCurrent < timeFastest)
                    { 
                        fastestIndex = currentIndex;

                        timeFastest = times[fastestIndex];
                        nameFastest = athletes[fastestIndex];
                    }

                    currentIndex++;

                    /*
                    if (timeFastest == 0 || timeCurrent < timeFastest)
                    {
                        timeFastest = timeCurrent;
                        nameFastest = nameTextBox.Text;
                    }
                    */
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

        }

        private void fastestButton_Click(object sender, RoutedEventArgs e)
        {
            int hourAmount = timeFastest / 3600;
            int minutesAmount = (timeFastest % 3600) / 60;
            int secondsAmount = (timeFastest % 3600) % 60;


            resultTextBox.Text = $"De snelste atleet is {nameFastest} \nTotaal aantal seconden: {timeFastest}\n\rAantal uren: {hourAmount}\nAantal minuten: {minutesAmount}\nAantal seconden: {secondsAmount}";
        }

        private void closeButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}