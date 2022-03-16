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

        private void button_Dodaj_Click(object sender, RoutedEventArgs e)
        {

            string i = textBox_imie.Text;
            string n = textBox_nazwisko.Text;
            string wa = textBox_waga.Text;
            string wz = textBox_wzrost.Text;


            Piłkarz p = new Piłkarz(i, n, Convert.ToInt32(wa), Convert.ToInt32(wz), (Pozycja)comboBox_pozycje.SelectedIndex);
            listbox_pilkarze.Items.Add(p);
            //MessageBox.Show($"{test(1)&&test(1)}");
            
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

        private void TextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key != Key.Back)
            {
                if (textBox_imie.Text.Length > 20)
                {
                    textBox_imie.Background = Brushes.Gray;
                    textBox_imie.Text = textBox_imie.Text.Remove(textBox_imie.Text.Length - 1);
                    textBox_imie.Focus();
                    textBox_imie.SelectionStart = textBox_imie.Text.Length;
                    textBox_imie.SelectionLength = 0;

                }
            }
            if (textBox_imie.Text.Length < 20)
            {
                textBox_imie.Background = Brushes.Beige;
            }
        }
    }
}
