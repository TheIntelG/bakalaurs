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

                DataLibrary dataLibrary = new DataLibrary();
                dataLibrary.setDesignFilePath(filePath);
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

                    DataLibrary dataLibrary = new DataLibrary();
                    dataLibrary.setDesignFilePath(Path.GetFullPath(files[0]));
                } else
                {
                    MessageBox.Show("Upload only 1 design at a time!");
                }
            }
        }

        private void NextButton_Click(object sender, RoutedEventArgs e)
        {
            DataLibrary dataLibrary = new DataLibrary();
            string filePath = dataLibrary.getDesignFilePath();

            if (!string.IsNullOrEmpty(filePath))
            {
                MessageBox.Show(filePath);
            } else
            {
                MessageBox.Show("Please upload a design!");
            }
        }
    }
}
