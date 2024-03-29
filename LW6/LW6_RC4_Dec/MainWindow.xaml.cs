﻿using System;
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

namespace LW6_RC4_Dec
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
        public static byte[] EncryptData(byte[] pwd, byte[] data,out int [] box_o)
        {
            int a, i, j, k, tmp;
            int[] key, box;
            byte[] cipher;

            key = new int[256];
            box = new int[256];
            cipher = new byte[data.Length];

            for (i = 0; i < 256; i++)
            {
                key[i] = pwd[i % pwd.Length];
                box[i] = i;
            }
            for (j = i = 0; i < 256; i++)
            {
                j = (j + box[i] + key[i]) % 256;
                tmp = box[i];
                box[i] = box[j];
                box[j] = tmp;
            }
            for (a = j = i = 0; i < data.Length; i++)
            {
                a++;
                a %= 256;
                j += box[a];
                j %= 256;
                tmp = box[a];
                box[a] = box[j];
                box[j] = tmp;
                k = box[((box[a] + box[j]) % 256)];
                cipher[i] = (byte)(data[i] ^ k);
            }
            box_o = box;
            return cipher;
        }

        public static byte[] DecryptData(byte[] pwd, byte[] data, out int [] box_o)
        {
            return EncryptData(pwd, data, out box_o);
        }

        private void Decrypt(object sender, RoutedEventArgs e)
        {

            int[] box_o;
            string[] text = TextBx.Text.Split(' ');
            byte[] data = new byte[text.Count()];
            for (int i = 0; i < text.Count(); i++)
            {
                data[i] = Convert.ToByte(text[i]);
            }

            string[] temp = Key.Text.Split(' ');
            byte[] key = new byte[temp.Count()];
            for (int i = 0; i < temp.Count(); i++)
            {
                key[i] = Convert.ToByte(temp[i]);
            }
            byte[] enc = EncryptData(key, data,out box_o);

            string encText = "";
            for (int i = 0; i < enc.Count(); i++)
            {

                encText += ((char)enc[i]).ToString();
            }
            resDecTextBx.Text = encText;
            KeysTextBx.Text = GetStringMass(box_o) ;
        }


        private static string GetStringMass(int[] mass)
        {
            StringBuilder stringBuilder = new StringBuilder();
            for (int i = 0; i < mass.Length; i++)
            {
                stringBuilder.Append(mass[i] + " ");
            }
            return stringBuilder.ToString();
        }
    }
}
