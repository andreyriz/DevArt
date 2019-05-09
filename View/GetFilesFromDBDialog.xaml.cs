using System.Windows;

namespace DataArt
{
    /// <summary>
    /// Логика взаимодействия для GetFilesFromDBDialog.xaml
    /// </summary>
    public partial class GetFilesFromDBDialog : Window
    {
        GetFilesFromDBDialogVM getFilesFromDB;
        public GetFilesFromDBDialog()
        {
            InitializeComponent();
            getFilesFromDB = new GetFilesFromDBDialogVM();
            this.DataContext = getFilesFromDB;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
