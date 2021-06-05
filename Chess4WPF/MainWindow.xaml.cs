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
					bor.Name = "b" + Convert.ToString(i) + Convert.ToString(j);
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

		}
		public static bool flag = false;//переменная для проверки второго нажатия на клетку
		public static int xFigure;
		public static int yFigure;
		public static Image figur;

		public bool ButtonKingClick = false;

		private void Active(object sender, RoutedEventArgs e)
		{

			if (flag && sender is Button)
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
					//Button ButtonClicked = FindButton(yFigure, xFigure);
					//ButtonClicked.Background = Brushes.Aqua;
					flag = true;
					string r = "x=" + xFigure + " y=" + yFigure;
					//MessageBox.Show(r);

				}
				if (sender is Button && ButtonKingClick)
				{
					Button but = sender as Button;

					Image img = new Image();
					//img.Height = 100;
					//img.Width = 100;
					img.Name = "бкороль";
					img.MouseDown += Active;
					if (WhiteCheck.IsChecked == true)
					{
						img.Source = new BitmapImage(new System.Uri("pack://application:,,,/king.png"));
					}
					else
					{
						img.Source = new BitmapImage(new System.Uri("pack://application:,,,/bKing.png"));
					}
					Grid.SetRow(img, Grid.GetRow(but));
					Grid.SetColumn(img, Grid.GetColumn(but));
					gridMain.Children.Add(img);
					ButtonKingClick = false;
				}
			}
		}

		public Button FindButton(int column, int row)
		{
			foreach (Button child in gridMain.Children)
			{
				if (Grid.GetRow(child) == row && Grid.GetColumn(child) == column)
				{
					return child;
				}
			}
			return null;
		}
		private void KingButton_Click_1(object sender, RoutedEventArgs e)
		{
			ButtonKingClick = true;
		}
	}
}