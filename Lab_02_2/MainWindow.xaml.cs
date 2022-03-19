using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

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
                if (o is TextBox currentTextBox)
                {
                    if (currentTextBox.Background != Brushes.LightGreen)
                    {
                        valid = false;
                    }
                }
            }

            if (valid)
            {
                string i = textBox_imie.Text.ToLower();
                i = char.ToUpper(i[0]) + i.Substring(1);
                string n = textBox_nazwisko.Text.ToLower();
                n = char.ToUpper(n[0]) + n.Substring(1);
                string wa = textBox_waga.Text;
                string wz = textBox_wzrost.Text;


                Piłkarz p = new Piłkarz(i, n, Convert.ToInt32(wa), Convert.ToInt32(wz), (Pozycja)comboBox_pozycje.SelectedIndex);
                listbox_pilkarze.Items.Add(p);
                //MessageBox.Show($"{test(1)&&test(1)}");
            }
            else
            {
                _ = MessageBox.Show("ZŁE DANE!");
            }
        }

        private void Button_Usun_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Edytuj_Click(object sender, RoutedEventArgs e)
        {

        }

        private bool test(int x)
        {
            if (x % 2 == 0)
            {
                MessageBox.Show("test:True");
                return true;
            }
            MessageBox.Show("test:False");
            return false;
        }

        private void TextBox_KeyUp(object sender, KeyEventArgs e)
        {
            TextBox currentTextBox = sender as TextBox;
            Validation_Key(currentTextBox);
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

            Validation_Focus(currentTextBox);
            if (currentTextBox.Text == "")
            {
                switch (currentTextBox.Name)
                {
                    case "textBox_nazwisko":
                        currentTextBox.Text = placeholder[0];
                        currentTextBox.Background = Brushes.Beige;
                        textBlockV.Text = "";
                        break;
                    case "textBox_imie":
                        currentTextBox.Text = placeholder[1];
                        currentTextBox.Background = Brushes.Beige;
                        textBlockV.Text = "";
                        break;
                    case "textBox_wzrost":
                        currentTextBox.Text = placeholder[2];
                        textBlockV.Text = "";
                        currentTextBox.Background = Brushes.Beige;
                        break;
                    case "textBox_waga":
                        currentTextBox.Text = placeholder[3];
                        currentTextBox.Background = Brushes.Beige;
                        textBlockV.Text = "";
                        break;
                    default:
                        break;
                }
            }
        }

        private void Validation_Key(TextBox currentTextBox)
        {
            bool valid = true;
            if (textBlockV.Text.Contains("Podano"))
            {
                textBlockV.Text = "";
            }

            if (currentTextBox.Name[8] != 'w')
            {
                valid = !HasSpecialChars(currentTextBox.Text) && !currentTextBox.Text.Any(char.IsDigit);
            }
            else
            {
                valid = currentTextBox.Text.All(char.IsDigit);
            }

            currentTextBox.Background = valid ? Brushes.LightGreen : Brushes.IndianRed;
            textBlockV.Text = valid ? "" : "Podano złą wartość!";
        }

        private void Validation_Focus(TextBox currentTextBox)
        {
            bool valid = true;
            int.TryParse(currentTextBox.Text, out int temp);

            if (textBlockV.Text.Contains("Podano"))
            {
                textBlockV.Text = "";
            }

            if (currentTextBox.Name == "textBox_wzrost")
            {
                if (currentTextBox.Text != "Wzrost [cm]")
                {
                    if (temp < 100)
                    {
                        valid = false;
                        textBlockV.Text += "\nZa mała liczba";
                    }
                    else if (temp > 250)
                    {
                        valid = false;
                        textBlockV.Text += "\nZa duża liczba";
                    }
                }
            }
            if (currentTextBox.Name == "textBox_waga")
            {
                if (currentTextBox.Text != "Waga [kg]")
                {
                    if (temp < 40)
                    {
                        valid = false;
                        textBlockV.Text += "\nZa mała liczba";
                    }
                    else if (temp > 250)
                    {
                        valid = false;
                        textBlockV.Text += "\nZa duża liczba";
                    }
                }
            }

            currentTextBox.Background = valid ? Brushes.LightGreen : Brushes.IndianRed;
            textBlockV.Text = valid ? "" : "Podano złą wartość!" + textBlockV.Text;
        }






        private bool HasSpecialChars(string temp)
        {
            return temp.Any(ch => !char.IsLetterOrDigit(ch));
        }
    }
}
