using System;
using System.Windows;

namespace DataArt
{
    /// <summary>
    /// Логика взаимодействия для FileNameDialog.xaml
    /// </summary>
    public partial class FileNameDialog : Window
    {
        FileNameDialogVM viewModel;

        public FileNameDialog(FileNameDialogM model, String fileName)
        {
            InitializeComponent();
            viewModel = new FileNameDialogVM(model, fileName);
            DataContext = this.viewModel;
        }

        private void onClickCancel(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void onClickOkButton(object sender, RoutedEventArgs e)
        {
            viewModel.PushMessage();
            this.Close();
        }
    }
}
