using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
//using Lab6B_Library;

namespace Lab6B
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Deck deck;
        private Image[,] images;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void ButtonCreateDeck_Click(object sender, RoutedEventArgs e)
        {
            deck = new Deck();
            CreateVisual();
            UpdateVisual();
        }

        private void CreateVisual()
        {
            images = new Image[13, 4];
            for (int i = 0; i < 13; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    Image image = new Image();
                    image.Stretch = Stretch.Fill;
                    gridCards.Children.Add(image);
                    images[i, j] = image;
                    Grid.SetColumn(image, j);
                    Grid.SetRow(image, 1+ i);
                }
            }
        }

        private void UpdateVisual()
        {
            for (int i = 0; i < 13; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    string cardName = deck.GetCard(i + j * 13).ToString();
                    BitmapImage imageSource = new BitmapImage(new Uri($@"pack://siteoforigin:,,,/Images/{cardName.ToUpperInvariant()}.png"));
                    imageSource.DecodePixelWidth = 300;
                    imageSource.DecodePixelHeight = 600;
                    images[i, j].Source = imageSource;

                }
            }
        }

        private void ButtonShuffleDeck_Click(object sender, RoutedEventArgs e)
        {
            deck.Shuffle();
            UpdateVisual();
        }
    }
}

