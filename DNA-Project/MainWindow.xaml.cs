using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace DNA_Project
{
    public partial class MainWindow : Window
    {
        Dna _dna;
        Stopwatch _timer =  new Stopwatch();
        int _sequenceSize;
        delegate int SearchDelegate();

        public MainWindow()
        {
            InitializeComponent();
            _sequenceSize = 2;
        }

         async void Button_Click(object sender, RoutedEventArgs e)
         {
            ProgressBar.Visibility = Visibility.Visible;
            var genomSize = Int32.Parse(GenomSizeLabel.Text);
            _dna = new Dna(genomSize);
            GenomLabel.Text = await GetGenom();
            ProgressBar.Visibility = Visibility.Hidden;
        }

        async Task<string> GetGenom()
        {
            return await Task.Run(() =>
            {
                return _dna.Genom.Aggregate(string.Empty, (current, x) => current + x.ToString());
            });
        }

        async void Button_Click_1(object sender, RoutedEventArgs e)
        {
            ProgressBar.Visibility = Visibility.Visible;
            _dna.SetSequence(GetSequence(_sequenceSize));
            var result = await Search(_dna.PreciseSearch, GenomSizeLabel.Text);
            PreciseSearchResultLabel.Content = result;
            ProgressBar.Visibility = Visibility.Hidden;
        }

        async void Button_Click_2(object sender, RoutedEventArgs e)
        {
            ProgressBar.Visibility = Visibility.Visible;
            _dna.SetSequence(GetSequence(_sequenceSize));
            var result = await Search(_dna.OptimalSearch, GenomSizeLabel.Text);
            OptimalSearchResultLabel.Content = result;
            ProgressBar.Visibility = Visibility.Hidden;
        }

        char[] GetSequence(int size)
        {
            char[] tempSeq = new char[size];
            for (int i = 0; i < size; i++)
            {
                switch (i)
                {
                    case 0: tempSeq[0] = Convert.ToChar(FirstCharBox.Text);
                        break;
                    case 1: tempSeq[1] = Convert.ToChar(SecondCharBox.Text);
                        break;
                    case 2: tempSeq[2] = Convert.ToChar(ThirdCharBox.Text);
                        break;
                    case 3: tempSeq[3] = Convert.ToChar(FourthCharBox.Text);
                        break;
                }
            }
            return tempSeq;
        }

        async Task<string> Search(SearchDelegate search, string genomSize)
        {
            return await Task.Run(() =>
            {
                var size = _sequenceSize;
               
                _timer.Start();
                var result = search();
                double seconds = _timer.Elapsed.TotalSeconds;
                _timer.Reset();
                MessageBox.Show($"Znaleziono {result}\n w czasie: {seconds} sekund", "Rezultat przeszukiwania", MessageBoxButton.OK, MessageBoxImage.Information);
                return $"Rozmiar genomu: {genomSize}\nRozmiar sekwencji: {size}\nZnaleziono: {result}\nCzas: {seconds} sekund";
            });
        }

        void ToggleButton1_OnChecked(object sender, RoutedEventArgs e)
        {
            _sequenceSize = 2;
            ThirdCharBox.Visibility = Visibility.Hidden;
            FourthCharBox.Visibility = Visibility.Hidden;
        }

        void ToggleButton2_OnChecked(object sender, RoutedEventArgs e)
        {
            _sequenceSize = 3;
            ThirdCharBox.Visibility = Visibility.Visible;
            FourthCharBox.Visibility = Visibility.Hidden;
        }

        void ToggleButton3_OnChecked(object sender, RoutedEventArgs e)
        {
            _sequenceSize = 4;
            ThirdCharBox.Visibility = Visibility.Visible;
            FourthCharBox.Visibility = Visibility.Visible;
        }
    }

}
