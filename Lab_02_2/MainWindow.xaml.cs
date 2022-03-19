using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

namespace Lab_02_2
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Dodaj_Click(object sender, RoutedEventArgs e)
        {
            bool valid = true;
            foreach (object o in TextBoxes.Children)
            {
                TextBox currentTextBox = o as TextBox;
                if (currentTextBox.Background == Brushes.IndianRed)
                {
                    valid = false;
                }
            }

            if (valid)
            {
                string i = textBox_imie.Text;
                string n = textBox_nazwisko.Text;
                string wa = textBox_waga.Text;
                string wz = textBox_wzrost.Text;


                Piłkarz p = new Piłkarz(i, n, Convert.ToInt32(wa), Convert.ToInt32(wz), (Pozycja)comboBox_pozycje.SelectedIndex);
                listbox_pilkarze.Items.Add(p);
                //MessageBox.Show($"{test(1)&&test(1)}");
            }
        }

        private bool test(int x)
        {
            if (x % 2 == 0)
            {
                MessageBox.Show("test:True");
                return true; }
            MessageBox.Show("test:False");
            return false;
        }

        private void TextBox_KeyUp(object sender, KeyEventArgs e)
        {
            TextBox currentTextBox = sender as TextBox;
            string[] placeholder = { "Nazwisko", "Imię", "Wzrost [cm]", "Wiek [kg]" };

            if (currentTextBox.Name[8] == 'w')
            {
                currentTextBox.Background = currentTextBox.Text.All(char.IsDigit) ? Brushes.LightGreen : Brushes.IndianRed;
            }
            else
            {
                currentTextBox.Background = (HasSpecialChars(currentTextBox.Text) || currentTextBox.Text.Any(char.IsDigit)) ? Brushes.IndianRed : Brushes.LightGreen;
            }
        }

        private void TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox currentTextBox = sender as TextBox;
            string[] placeholder = { "Nazwisko", "Imię", "Wzrost [cm]", "Waga [kg]" };
            if (placeholder.Contains(currentTextBox.Text))
            {
                currentTextBox.Text = "";
            }
        }

        private void TextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBox currentTextBox = sender as TextBox;
            string[] placeholder = { "Nazwisko", "Imię", "Wzrost [cm]", "Waga [kg]" };
            if (currentTextBox.Text == "")
            {
                switch(currentTextBox.Name)
                {
                    case "textBox_nazwisko":
                        currentTextBox.Text = placeholder[0];
                        currentTextBox.Background = Brushes.Beige;
                        break;
                    case "textBox_imie":
                        currentTextBox.Text = placeholder[1];
                        currentTextBox.Background = Brushes.Beige;
                        break;
                    case "textBox_wzrost":
                        currentTextBox.Text = placeholder[2];
                        currentTextBox.Background = Brushes.Beige;
                        break;
                    case "textBox_waga":
                        currentTextBox.Text = placeholder[3];
                        currentTextBox.Background = Brushes.Beige;
                        break;
                }
            }
        }






        private bool HasSpecialChars(string temp)
        {
            return temp.Any(ch => !Char.IsLetterOrDigit(ch));
        }
    }
}
