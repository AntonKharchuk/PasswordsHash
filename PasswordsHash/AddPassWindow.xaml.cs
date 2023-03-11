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
using System.Windows.Shapes;
using System.IO;

namespace PasswordsHash
{
    /// <summary>
    /// Логика взаимодействия для AddPassWindow.xaml
    /// </summary>
    public partial class AddPassWindow : Window
    {
        public AddPassWindow()
        {
            InitializeComponent();
        }

        private void AddPassFromWindow_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(NameForPassword.Text))
                return;
            if (string.IsNullOrEmpty(Login.Text)&&string.IsNullOrEmpty(Password.Text))
                return;

            using (StreamWriter sw = new StreamWriter(Constants.AppDirectory+"data.txt", true))
            {
                sw.WriteLine(NameForPassword.Text);
                if (!string.IsNullOrEmpty(Login.Text))
                {
                    sw.WriteLine(Code(Login.Text));
                }
                else
                    sw.WriteLine();
                if (!string.IsNullOrEmpty(Password.Text))
                {
                    sw.WriteLine(Code(Password.Text));
                }
                else
                    sw.WriteLine();
            }
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            CloseAllWindows();

        }
        private string Code(string line)
        {
            line = line.Trim();
            var charArr = line.ToCharArray();
            var rescchars = new List<char> { };

            foreach (var item in charArr)
            {
                if (!char.IsDigit(item))
                {
                    int Unicode = (int) item;
                    Unicode--;
                    rescchars.Add((char)Unicode);
                }
                else
                {
                    rescchars.Add(item);
                }
            }
            string result = string.Empty;

            foreach (var letter in rescchars)
            {
                result += letter;
            }
            return result;
        }
        private void CloseAllWindows()
        {
            for (int intCounter = App.Current.Windows.Count - 2; intCounter >= 0; intCounter--)
            {
                App.Current.Windows[intCounter].Close();
            }
        }
    }
}
