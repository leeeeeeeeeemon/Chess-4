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
        public class VisualHelper
        {
            public static IEnumerable<T> FindVisualChildren<T>(DependencyObject depObj) where T : DependencyObject
            {
                if (depObj != null)
                {
                    for (int i = 0; i < VisualTreeHelper.GetChildrenCount(depObj); i++)
                    {
                        DependencyObject child = VisualTreeHelper.GetChild(depObj, i);
                        if (child != null && child is T)
                        {
                            yield return (T)child;
                        }

                        foreach (T childOfChild in FindVisualChildren<T>(child))
                        {
                            yield return childOfChild;
                        }
                    }
                }
            }
        }

        public MainWindow()
        {
            InitializeComponent();
            int count = 0;
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {

                    var bor = new Button();
                    //bor.Click += Active;
                    bor.Height = 100;
                    bor.Width = 100;
                    bor.Background = Brushes.Yellow;

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
            img.Source = new BitmapImage(new System.Uri("pack://application:,,,/Resources/king.jpeg"));
            Grid.SetRow(img, 8);
            Grid.SetColumn(img, 4);
            gridMain.Children.Add(img);
        }
    }
}
