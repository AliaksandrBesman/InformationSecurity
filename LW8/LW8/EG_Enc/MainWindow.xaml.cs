﻿using System;
using System.Numerics;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;

namespace EG_Enc
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

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void LetterValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^a-zA-Z]+");
            e.Handled = regex.IsMatch(e.Text);
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
            RichTextEnc.Document.Blocks.Clear();
            if (RichText.GetText(RichTextOrig) != String.Empty && TextP.Text != String.Empty && TextG.Text != String.Empty && TextC.Text != String.Empty)
            {
                int p = Int32.Parse(TextP.Text);
                int g = Int32.Parse(TextG.Text);
                int c = Int32.Parse(TextC.Text);
                if (IsSimple(p) && g < (p - 1) && c < (p - 1))
                {
                    string text = RichText.GetText(RichTextOrig).ToLower();
                    text = text.Substring(0, text.Length - 2);
                    string encText = "";
                    int d = (int)BigInteger.ModPow(g, c, p);
                    int k = new Random().Next(1, 9);
                    int r = (int)BigInteger.ModPow(g, k, p);
                    for (int i = 0; i < text.Length; i++)
                    {
                        int E = (int)BigInteger.ModPow(BigInteger.Pow(d, k) * LetterNumber(text[i]), 1, p);
                        encText += "(" + r.ToString() + "," + E.ToString() + ") ";
                    }
                    RichText.SetText(RichTextEnc, encText);
                    //int m_ = (int)BigInteger.ModPow(BigInteger.Pow(r, p - 1 - c) * E, 1, p);
                }
                else
                {
                    MessageBox.Show("Число p не является простым или коэффициенты ошибочны. Исправьте это");
                }
            }
            else
            {
                MessageBox.Show("Заполните все поля");
            }
        }
    }

    public static class RichText
    {
        public static void SetText(this RichTextBox richTextBox, string text)
        {
            richTextBox.Document.Blocks.Clear();
            richTextBox.Document.Blocks.Add(new Paragraph(new Run(text)));
        }

        public static string GetText(this RichTextBox richTextBox)
        {
            return new TextRange(richTextBox.Document.ContentStart,
                richTextBox.Document.ContentEnd).Text;
        }
    }
}
