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

namespace Wh40k
{
    /// <summary>
    /// Interaction logic for WindowMainMenu.xaml
    /// </summary>
    public partial class WindowMainMenu : Window
    {
        public WindowMainMenu()
        {
            InitializeComponent();
        }

//B U T T O N   " C L O S E   W I N D O W "

        private void ButtonCloseWindow_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

//B U T T O N   " C L O S E   C O M B A T "

        private void ButtonCloseCombat_Click(object sender, RoutedEventArgs e)
        {
            Window WCloseCombat = new WindowCloseCombatMenu();
            WCloseCombat.Show();
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }
    }
}
