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
    /// Interaction logic for ElementMenuView.xaml
    /// </summary>
    public partial class ElementMenuView : UserControl
    {
        public ElementMenuView()
        {
            InitializeComponent();
        }

        private void SaveElement(object sender, RoutedEventArgs e)
        {
            DataLibrary dataLibrary = new DataLibrary();

            string elementName = (e.Source as Button).Content.ToString();

            dataLibrary.setElement(elementName);

            MessageBox.Show(dataLibrary.getElement());
        }
    }
}
