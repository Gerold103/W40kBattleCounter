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
using System.Windows.Shapes;

namespace Wh40k
{
    /// <summary>
    /// Interaction logic for Melee.xaml
    /// </summary>
    public partial class Melee : Window
    {
        public Melee()
        {
            InitializeComponent();
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Save_Checked(object sender, RoutedEventArgs e)
        {
            SaveBox.IsEnabled = true;
        }

        private void Save_Unchecked(object sender, RoutedEventArgs e)
        {
            SaveBox.IsEnabled = false;
        }

        private void UnblockSave_Checked(object sender, RoutedEventArgs e)
        {
            UnblockSaveBox.IsEnabled = true;
        }

        private void UnblockSave_Unchecked(object sender, RoutedEventArgs e)
        {
            UnblockSaveBox.IsEnabled = false;
        }

        /*private void isInfantry_Checked(object sender, RoutedEventArgs e)
        {
            openVeh.IsEnabled = true;
        }

        private void isInfantry_Unchecked(object sender, RoutedEventArgs e)
        {
            openVeh.IsEnabled = false;
        }*/

    }
}
