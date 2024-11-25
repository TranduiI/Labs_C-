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

namespace Lab6A
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Shape _shape;

        public MainWindow()
        {
            InitializeComponent();
            RadioButtonRectangle_Click(new object(), new RoutedEventArgs());
        }

        private void RadioButtonRectangle_Click(object sender, RoutedEventArgs e)
        {
            _shape = new Rectangle();
            ChangeRectangleData(Visibility.Visible);
            ChangeSquareData(Visibility.Hidden);
            ChangeCircleData(Visibility.Hidden);
            ResetEnterData();
        }

        private void RadioButtonCircle_Click(object sender, RoutedEventArgs e)
        {
            _shape = new Circle();
            ChangeRectangleData(Visibility.Hidden);
            ChangeSquareData(Visibility.Hidden);
            ChangeCircleData(Visibility.Visible);
            ResetEnterData();
        }

        private void RadioButtonSquare_Click(object sender, RoutedEventArgs e)
        {
            _shape = new Square();
            ChangeRectangleData(Visibility.Hidden);
            ChangeSquareData(Visibility.Visible);
            ChangeCircleData(Visibility.Hidden);
            ResetEnterData();
        }

        private void ChangeCircleData(Visibility visibility)
        {
            labelRadius.Visibility = visibility;
            textBoxRadius.Visibility = visibility;
        }

        private void ChangeSquareData(Visibility visibility)
        {
            labelSide.Visibility = visibility;
            textBoxSide.Visibility = visibility;
        }

        private void ChangeRectangleData(Visibility visibility)
        {
            labelSide1.Visibility = visibility;
            labelSide2.Visibility = visibility;
            textBoxSide1.Visibility = visibility;
            textBoxSide2.Visibility = visibility;
        }

        private void ResetEnterData()
        {
            labelNameResult.Content = "No name";
            labelPerimetrResult.Content = "0";
            labelSquareResult.Content = "0";
            textBoxRadius.Text = "";
            textBoxSide1.Text = "";
            textBoxSide2.Text = "";
            textBoxSide.Text = "";
            buttonGetShape.IsEnabled = false;
        }

        private void ButtonGetShape_Click(object sender, RoutedEventArgs e)
        {
            if (_shape is Square)
            {
                _shape = new Square(double.Parse(textBoxSide.Text));
            }
            else if (_shape is Rectangle)
            {
                _shape = new Rectangle(double.Parse(textBoxSide1.Text), double.Parse(textBoxSide2.Text));
            }
            else
            {
                _shape = new Circle(double.Parse(textBoxRadius.Text));
            }
            labelNameResult.Content = _shape.NameShape;
            labelPerimetrResult.Content = _shape.P;
            labelSquareResult.Content = _shape.S;
        }

        private void TextBoxSide1_TextChanged(object sender, TextChangedEventArgs e)
        {
            CheckRectangle();
        }

        private void TextBoxSide2_TextChanged(object sender, TextChangedEventArgs e)
        {
            CheckRectangle();
        }

        private void TextBoxSide_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (_shape is Square)
            {
                if (textBoxSide.Text != "")
                {
                    buttonGetShape.IsEnabled = true;
                }
                else
                {
                    buttonGetShape.IsEnabled = false;
                }
            }
        }

        private void TextBoxRadius_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (_shape is Circle)
            {
                if (textBoxRadius.Text != "")
                {
                    buttonGetShape.IsEnabled = true;
                }
                else
                {
                    buttonGetShape.IsEnabled = false;
                }
            }
        }

        private void CheckRectangle()
        {
            if (_shape is Rectangle && !(_shape is Square))
            {
                if (textBoxSide1.Text != "" && textBoxSide2.Text != "")
                {
                    buttonGetShape.IsEnabled = true;
                }
                else
                {
                    buttonGetShape.IsEnabled = false;
                }
            }
        }

        
    }
}
