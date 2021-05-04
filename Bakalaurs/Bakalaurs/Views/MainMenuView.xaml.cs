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
            openFileDialog.Filter = "Image files (*.png;*.jpeg;*.jpg;*.bpm)|*.png;*.jpeg;*.jpg;*.bmp|All files (*.*)|*.*";

            bool? response = openFileDialog.ShowDialog();

            if(response == true)
            {
                string filePath = openFileDialog.FileName;

                FileNameLabel.Content = openFileDialog.SafeFileName;

                NextButton.IsEnabled = true;

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
                    if (Path.GetExtension(files[0]).ToUpperInvariant() != ".PNG" && Path.GetExtension(files[0]).ToUpperInvariant() != ".JPG" &&
                        Path.GetExtension(files[0]).ToUpperInvariant() != ".JPEG" && Path.GetExtension(files[0]).ToUpperInvariant() != ".BMP")
                    {
                        MessageBox.Show("Only .png .jpg .jpeg and .bmp is supported!");
                    } else
                    {
                        string filename = Path.GetFileName(files[0]);

                        FileNameLabel.Content = filename;

                        NextButton.IsEnabled = true;

                        DataLibrary dataLibrary = new DataLibrary();
                        dataLibrary.setDesignFilePath(Path.GetFullPath(files[0]));
                    }
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

            MessageBox.Show(filePath);
        }
    }
}
