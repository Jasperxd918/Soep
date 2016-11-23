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

        Soep_classes SoepClass = new Soep_classes();

        private void BtLogin_Click(object sender, RoutedEventArgs e)
        {
   
            SoepZiek soep = new SoepZiek();
            
           
            SoepClass.Inloggen(TBNaam.Text,TBWachtwoord.Password);

            if (TBNaam.Text=="JE MOEDER IS EEN HOER")
            {
                soep.Show();
                
                this.Close();
            }
           
        }
    }
}
