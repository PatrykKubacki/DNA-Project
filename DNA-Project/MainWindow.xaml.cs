using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace DNA_Project
{
    public partial class MainWindow : Window
    {
        Dna Dna;
        Stopwatch Timer =  new Stopwatch();

        public MainWindow()
        {
            InitializeComponent();
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
            var size = int.Parse(SequenceSizeLabel.Text);
            Dna.SetSequence(size);
            Timer.Start();
            var result = Dna.PreciseSearch();
            double seconds = Timer.Elapsed.TotalSeconds;
            Timer.Reset();
            MessageBox.Show($"Znaleziono {result}\n w czasie: {seconds} sekund", "Rezultat dokładnego przeszukiwania", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        void Button_Click_2(object sender, RoutedEventArgs e)
        {

        }
    }

}
