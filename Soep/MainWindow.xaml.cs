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
using System.Data;

namespace Soep
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        Functies FunctieClass = new Functies();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnInloggen_Click(object sender, RoutedEventArgs e)
        {
            if (tbGebruikersnaam.Text == "" || tbWachtwoord.Password == "")
            {
                MessageBox.Show("Je hebt je gebruikersnaam of wachtwoord niet ingevuld");
            }
            else
            {
                string sGebruikersnaam = tbGebruikersnaam.Text;
                string sPassword = tbWachtwoord.Password;
                bool check = FunctieClass.Inloggen(sGebruikersnaam, sPassword);
                if (check)
                {
                    ComboBoxItem typeItem = (ComboBoxItem)cbNiveau.SelectedItem;
                    string value = typeItem.Content.ToString();
                    Schermpie schermpie = new Schermpie(tbGebruikersnaam.Text, typeItem.Content.ToString());
                    schermpie.Show();
                    this.Close();
                }
            }
           
        }
    }
}
