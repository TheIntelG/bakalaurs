using System.Windows;
using System.Windows.Controls;

namespace Bakalaurs.Views
{
    /// <summary>
    /// Interaction logic for MainMenuView.xaml
    /// </summary>
    public partial class MainMenuView : UserControl
    {
        public MainMenuView()
        {
            InitializeComponent();

            this.DataContext = this;
        }

        private void UploadButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
