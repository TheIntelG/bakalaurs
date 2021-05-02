using Microsoft.Win32;
using System.IO;
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
        }

        private void UploadButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            bool? response = openFileDialog.ShowDialog();

            if(response == true)
            {
                string filePath = openFileDialog.FileName;

                FileNameLabel.Content = openFileDialog.SafeFileName;

                MessageBox.Show(filePath);
            }
        }

        private void FileDropStackPanel_Drop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);

                if (files.Length == 1)
                {
                    string filename = Path.GetFileName(files[0]);

                    FileNameLabel.Content = filename;

                    MessageBox.Show(Path.GetFullPath(files[0]));
                } else
                {
                    MessageBox.Show("Upload only 1 design at a time!");
                }
            }
        }
    }
}
