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
using System.IO;

namespace Chess4WPF
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {


        public MainWindow()
        {
            InitializeComponent();
            
            int count = 0;
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {

                    var bor = new Button();
                    bor.Click += Active;
                    bor.Height = 100;
                    bor.Width = 100;
                    bor.Background = Brushes.WhiteSmoke;

                    count += 1;
                    if ((count) % 2 == 0)
                    {
                        bor.Background = Brushes.Red;
                    }
                    Grid.SetRow(bor, i);
                    Grid.SetColumn(bor, j);

                    gridMain.Children.Add(bor);


                }
                count += 1;
            }
            Image img = new Image();
            img.Height = 100;
            img.Width = 100;
            img.Name = "бкороль";
            img.MouseDown += Active;
            img.Source = new BitmapImage(new System.Uri("pack://application:,,,/king.jpeg"));
            Grid.SetRow(img, 7);
            Grid.SetColumn(img, 3);
            gridMain.Children.Add(img);
        }
        public static bool flag = false;//переменная для проверки второго нажатия на клетку
        public static int xFigure;
        public static int yFigure;
        public static Image figur;
        
        
        private void Active(object sender, RoutedEventArgs e)
        {
            
            if (flag)
            {
                var figure = sender as Button;
                int x = Grid.GetRow(figure);
                int y = Grid.GetColumn(figure);
                bool mogno = rule.tryKingMove(xFigure, yFigure, x, y);
                if (mogno)
                {
                    Grid.SetRow(figur, x);
                    Grid.SetColumn(figur, y);
                }
                else
                {
                    MessageBox.Show("Wrong move");
                }
                flag = false;
            }
            else
            {
                if (sender is Image)
                {
                    var figure = sender as Image;
                    figur = figure;
                    xFigure = Grid.GetRow(figure);
                    yFigure = Grid.GetColumn(figure);
                    flag = true;
                    string r = "x=" + xFigure + " y=" + yFigure;
                    MessageBox.Show(r);
                }
            }
        }
    }
}
