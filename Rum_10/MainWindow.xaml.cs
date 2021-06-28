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

namespace Rum_10
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        
        public bool SNILS(string sn)
        {
            int p = 0;
            bool rez;
            for (int i = 0; i < sn.Length; i++)
            {
                if (Char.IsDigit(sn[i])) { p++; }
            }
            if (p != sn.Length) { rez = false; }//Ошибка
            else if (sn.Length == 11) { rez = true; } //Все верно
            else { rez = false; } //Ошибка
            return rez;
        }

        public bool Telephone(string tel)
        {
            int p = 0;
            bool rez;
            for (int i = 0; i < tel.Length; i++)
            {
                if (Char.IsDigit(tel[i])) { p++; }
            }
            if (p != tel.Length) { rez = false; }//Ошибка
            else if (tel.Length == 10) { rez = true; } //Все верно
            else { rez = false; } //Ошибка
            return rez;
        }

        public bool Mail(string mail)
        {
            int b = mail.IndexOf('@');
            string bna = "№;:!#$%^&*()+=?/, '><|][{}";
            int zz = 0;
            bool rez;
            for (int i = 0; i < bna.Length; i++)
            {
                int bb = mail.IndexOf(bna[i]);
                if (bb == -1) { zz++; }
            }
            if (b != -1 && zz == bna.Length)
            {
                string[] z = mail.Split('@');
                string k = z[0];
                if (z.Length == 2 && z[0].Length != 0)
                {
                    string il = z[1];
                    if (il.IndexOf('.') != -1)
                    {
                        string[] ba = z[1].Split('.');
                        if (ba.Length >= 2 && ba[0].Length != 0) { rez = true; } //Все верно
                        else { rez = false; }//Ошибка
                    }
                    else { rez = false; } //Ошибка
                }
                else { rez = false; } //Ошибка
            }
            else { rez = false; } //Ошибка
            return rez;
        }

        private void Check(object sender, RoutedEventArgs e)
        {
            bool sn = SNILS(Snils.Text);
            bool mail = Mail(Email.Text);
            bool tel = Telephone(phone.Text);
            if (mail == true && sn == true && tel == true)
            {
                string oth = "Все верно";
            }
            else
            {
                string oth = "Неверно введены:\n";
                if(sn == false) { oth = oth + "Снилс\n"; }
                if(mail == false) { oth = oth + "Email\n"; }
                if(tel == false) { oth = oth + "Телефон"; }
                MessageBox.Show(oth);
                Snils.Text = "";
                Email.Text = "";
                phone.Text = "";
            }
        }
    }
}
