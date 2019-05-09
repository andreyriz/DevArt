using System.Windows;
using System.Windows.Input;

namespace DataArt
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        TextEditorVM tvm;
        public MainWindow()
        {
            InitializeComponent();
            tvm = new TextEditorVM();
            DataContext = tvm;
        }

        private void TextBox_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                int currentPos = this.fileTextBox.SelectionStart;
                tvm.EnterCommand(currentPos);
                this.fileTextBox.SelectionStart = currentPos+1;
                this.fileTextBox.SelectionLength = 0;
            }
        }
    }
}
