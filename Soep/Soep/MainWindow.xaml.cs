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

namespace Soep
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

        Soep_classes SoepClass = new Soep_classes;

        private void BtLogin_Click(object sender, RoutedEventArgs e)
        {
            string password = TBWachtwoord.Password;
            SoepZiek soep = new SoepZiek();
            if (TBNaam.Text==password)
            {
                soep.Show();
                SoepClass.Inloggen(sNaam);
                this.Close();
            }
           
        }
    }
}
