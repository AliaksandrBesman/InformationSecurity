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
using System.Numerics;

namespace LW6
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
           
        }
        static string alphabet = "abcdefghijklmnopqrstuvwxyz";

        private static bool IsSimple(int n)
        {
            for (int i = 2; i <= (int)(n / 2); i++)
            {
                if (n % i == 0)
                    return false;
            }
            return true;
        }


        private int NOD(int first, int second)
        {
            int a, b, q, r = 1;
            if (first >= second)
            {
                a = first;
                b = second;
            }
            else
            {
                a = second;
                b = first;
            }
            while (r != 0)
            {
                q = (int)(a / b);
                r = (a % b);
                a = b;
                b = r;
            }
            return a;
        }

        private static int LetterNumber(char letter)
        {
            int number = 0;
            for (int i = 0; i < alphabet.Length; i++)
            {
                if (alphabet[i] == letter)
                {
                    number = i;
                }
            }
            return number;
        }

        private void Encrypt(object sender, RoutedEventArgs e)
        {

            int p = Int32.Parse(pTextBx.Text);
            int q = Int32.Parse(qTextBx.Text);
            int E = Int32.Parse(eTextBx.Text);
            if (IsSimple(p) && IsSimple(q))
            {
                int n = p * q;
                int fn = (p - 1) * (q - 1);
                if (E < n && NOD(E, fn) == 1)
                {
                    int startValue = int.Parse(SrartVakueTextBx.Text);
                    int counter = 0;
                    do
                    {
                        string encText = "";
                        encText += ((int)(Math.Pow(startValue, E) % n)).ToString();
                        resTextBx.Text += encText+" ";
                        startValue = int.Parse(encText);
                        counter++;
                    } while (counter < 10);
                 
                  
                }
                else
                {
                    MessageBox.Show("Коэффициент e не является взаимнопростым с f(n). Исправьте это");
                }
            }
            else
            {
                MessageBox.Show("Числа p и q не являются простыми. Исправьте это");
            }

            resTextBx.Text += "\n";
        }
}
}
