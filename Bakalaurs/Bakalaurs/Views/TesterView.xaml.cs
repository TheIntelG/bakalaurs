using System;
using System.Collections.Generic;
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

namespace Bakalaurs.Views
{
    /// <summary>
    /// Interaction logic for TesterView.xaml
    /// </summary>
    public partial class TesterView : UserControl
    {
        public TesterView()
        {
            InitializeComponent();
        }

        private Point startPoint;
        private Rectangle rect;
        private Image image;

        private void Canvas_MouseDown(object sender, MouseButtonEventArgs e)
        {
            startPoint = e.GetPosition(Canvas);

            rect = new Rectangle
            {
                Stroke = Brushes.Red,
                StrokeThickness = 2
            };

            Canvas.SetLeft(rect, startPoint.X);
            Canvas.SetTop(rect, startPoint.Y);

            Canvas.Children.Clear();
            Canvas.Children.Add(DesignImage);
            Canvas.Children.Add(rect);
        }

        private void Canvas_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Released || rect == null)
                return;

            var pos = e.GetPosition(Canvas);

            var x = Math.Min(pos.X, startPoint.X);
            var y = Math.Min(pos.Y, startPoint.Y);

            var w = Math.Max(pos.X, startPoint.X) - x;
            var h = Math.Max(pos.Y, startPoint.Y) - y;

            rect.Width = w;
            rect.Height = h;

            Canvas.SetLeft(rect, x);
            Canvas.SetTop(rect, y);
        }

        private void Canvas_MouseUp(object sender, MouseButtonEventArgs e)
        {
            rect = null;
        }

        private void Reset_Click(object sender, RoutedEventArgs e)
        {
            Canvas.Children.Clear();
            Canvas.Children.Add(DesignImage);
        }

        private void Test_Click(object sender, RoutedEventArgs e)
        {
            DataLibrary dataLibrary = new DataLibrary();
            string element = dataLibrary.getElement();

            double x = 0;
            double y = 0;
            MessageBox.Show("Element: " + element + "\nTop Left Coordinates: (" + x + ";" + y + ")");
        }
    }
}
