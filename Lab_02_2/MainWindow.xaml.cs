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
        private Piłkarz current;

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
                textBox_imie.Text = "Imię";
                textBox_nazwisko.Text = "Nazwisko";
                textBox_wzrost.Text = "Wzrost [cm]";
                textBox_waga.Text = "Waga [kg]";
                textBox_imie.Background = Brushes.Beige;
                textBox_nazwisko.Background = Brushes.Beige;
                textBox_wzrost.Background = Brushes.Beige;
                textBox_waga.Background = Brushes.Beige;
            }
            else
            {
                _ = MessageBox.Show("ZŁE DANE!");
            }
        }

        private void Button_Usun_Click(object sender, RoutedEventArgs e)
        {
            if (listbox_pilkarze.SelectedItem == null)
            {
                MessageBox.Show("Nie wybrano piłkarza!");
            }
            else
            {
                listbox_pilkarze.Items.Remove(listbox_pilkarze.SelectedItem);
            }
        }

        private void Button_Edytuj_Click(object sender, RoutedEventArgs e)
        {
            string i = textBox_imie.Text.ToLower();
            i = char.ToUpper(i[0]) + i.Substring(1);
            string n = textBox_nazwisko.Text.ToLower();
            n = char.ToUpper(n[0]) + n.Substring(1);
            string wa = textBox_waga.Text;
            string wz = textBox_wzrost.Text;

            // TODO: MAKE A VALIDATION ------------------------------------------------------------------------------------------------------------------------------

            Piłkarz p = new Piłkarz(i, n, Convert.ToInt32(wa), Convert.ToInt32(wz), (Pozycja)comboBox_pozycje.SelectedIndex);
            int currentIndex = listbox_pilkarze.Items.IndexOf(listbox_pilkarze.SelectedItem);
            listbox_pilkarze.Items.Remove(listbox_pilkarze.SelectedItem);
            listbox_pilkarze.Items.Insert(currentIndex, p);

            //if ((string)button_Edytuj.Content == "Edytuj")
            //{
            //    button_Edytuj.Content = "GOTOWE";
            //    button_Dodaj.IsEnabled = false;
            //    button_Usun.IsEnabled = false;
            //    Button_Usun_Click(sender, e);
            //    Button_Dodaj_Click(sender, e);
            //}
            //else
            //{
                
            //}
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
            button_Dodaj.IsEnabled = valid;
            button_Usun.IsEnabled = valid;
            button_Edytuj.IsEnabled = valid;
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

        private void Listbox_pilkarze_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if ((sender as ListBox).SelectedItem is Piłkarz currentItem)
            {
                textBox_imie.Text = currentItem.Imie;
                textBox_nazwisko.Text = currentItem.Nazwisko;
                textBox_wzrost.Text = currentItem.Wzrost.ToString();
                textBox_waga.Text = currentItem.Waga.ToString();
                current = currentItem;
            }
        }




        private bool HasSpecialChars(string temp)
        {
            return temp.Any(ch => !char.IsLetterOrDigit(ch));
        }
    }
}
