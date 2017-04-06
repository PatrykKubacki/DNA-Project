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

         void Button_Click(object sender, RoutedEventArgs e)
         {
            var genomSize = Int32.Parse(GenomSizeLabel.Text);
            _dna = new Dna(genomSize);
            GenomLabel.Text = string.Empty;
            foreach (var x in _dna.Genom)
            {
                GenomLabel.Text += x.ToString();
            }
        }

        void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var result = Search(_dna.PreciseSearch);
            PreciseSearchResultLabel.Content = result;
        }

        void Button_Click_2(object sender, RoutedEventArgs e)
        {
            var result = Search(_dna.OptimalSearch);
            OptimalSearchResultLabel.Content = result;
        }

        string Search(SearchDelegate search)
        {
            var size = _sequenceSize;
            _dna.SetSequence(size);
            _timer.Start();
            var result = search();
            double seconds = _timer.Elapsed.TotalSeconds;
            _timer.Reset();
            MessageBox.Show($"Znaleziono {result}\n w czasie: {seconds} sekund", "Rezultat przeszukiwania", MessageBoxButton.OK, MessageBoxImage.Information);
            return $"Rozmiar genomu: {GenomSizeLabel.Text}\nRozmiar sekwencji: {size}\nZnaleziono: {result}\nCzas: {seconds} sekund";
        }

        void ToggleButton1_OnChecked(object sender, RoutedEventArgs e)
        {
            _sequenceSize = 2;
        }

        void ToggleButton2_OnChecked(object sender, RoutedEventArgs e)
        {
            _sequenceSize = 3;
        }

        void ToggleButton3_OnChecked(object sender, RoutedEventArgs e)
        {
            _sequenceSize = 4;
        }
    }

}
