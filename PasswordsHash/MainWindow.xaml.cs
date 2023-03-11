using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PasswordsHash
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 

    

    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            //ViewList
            var passData = ReadAllLines();

            for (int i = 0; i < passData.Count; i++)
            {
                if (i%3==0)
                {
                    if(i>0)
                        ViewList.Children.Add(new TextBlock());

                    ViewList.Children.Add(new TextBlock{ 
                        Text = passData[i],
                        FontSize = 22,
                    });
                    continue;
                }
                else
                {
                    if (string.IsNullOrEmpty(passData[i]))
                        continue;
                    string data = DeCode(passData[i]);
                    ViewList.Children.Add(new TextBox
                    {
                        Text = data,
                        FontSize = 16,
                        FontFamily = new FontFamily("Times New Roman Italic"),
                    });
                    continue;
                }               
            }


        }
        private void AddPass_Click(object sender, RoutedEventArgs e)
        {
            AddPassWindow passWindow = new AddPassWindow();
            passWindow.Show();
        }
        private string DeCode(string line)
        {
            var charArr = line.ToCharArray();
            var rescchars = new List<char> { };

            foreach (var item in charArr)
            {
                if (!char.IsDigit(item))
                {
                    int Unicode = (int)item;
                    Unicode++;
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

        private List<string> ReadAllLines()
        {
            var lines = new List<string> { };
            using (StreamReader sr = File.OpenText(Constants.AppDirectory + "data.txt"))
            {
                while (true)
                {
                    var line = sr.ReadLine();
                    if (line == null)
                        return lines;
                    else
                        lines.Add(line);
                }
            }
        }
    }

}
