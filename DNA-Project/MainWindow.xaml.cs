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
        Dna Dna;
        Stopwatch Timer =  new Stopwatch();
        int _sequenceSize;

        public MainWindow()
        {
            InitializeComponent();
            _sequenceSize = 2;
        }

         void Button_Click(object sender, RoutedEventArgs e)
         {
            var genomSize = Int32.Parse(GenomSizeLabel.Text);
            Dna = new Dna(genomSize);
            GenomLabel.Text = string.Empty;
            foreach (var x in Dna.Genom)
            {
                GenomLabel.Text += x.ToString();
            }
        }

        void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var size = _sequenceSize;
            Dna.SetSequence(size);
            Timer.Start();
            var result = Dna.PreciseSearch();
            double seconds = Timer.Elapsed.TotalSeconds;
            Timer.Reset();
            MessageBox.Show($"Znaleziono {result}\n w czasie: {seconds} sekund", "Rezultat dokładnego przeszukiwania", MessageBoxButton.OK, MessageBoxImage.Information);
            PreciseSearchResultLabel.Content = $"Rozmiar genomu: {GenomSizeLabel.Text}\nRozmiar sekwencji: {size}\nZnaleziono: {result}\nCzas: {seconds} sekundy";
        }

        void Button_Click_2(object sender, RoutedEventArgs e)
        {
            var size = _sequenceSize;
            Dna.SetSequence(size);
            Timer.Start();
            var result = Dna.OptimalSearch();
            double seconds = Timer.Elapsed.TotalSeconds;
            Timer.Reset();
            MessageBox.Show($"Znaleziono {result}\n w czasie: {seconds} sekund", "Rezultat dokładnego przeszukiwania", MessageBoxButton.OK, MessageBoxImage.Information);
            OptimalSearchResultLabel.Content = $"Rozmiar genomu: {GenomSizeLabel.Text}\nRozmiar sekwencji: {size}\nZnaleziono: {result}\nCzas: {seconds} sekund";
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
