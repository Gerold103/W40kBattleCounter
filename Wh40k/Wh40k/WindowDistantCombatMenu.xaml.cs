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
    /// Логика взаимодействия для WindowDistantCombatMenu.xaml
    /// </summary>
    public partial class WindowDistantCombatMenu : Window
    {
        public WindowDistantCombatMenu()
        {
            InitializeComponent();
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Save_Checked(object sender, RoutedEventArgs e)
        {
            SaveBox.Visibility = System.Windows.Visibility.Visible;
        }

        private void Save_Unchecked(object sender, RoutedEventArgs e)
        {
            SaveBox.Visibility = System.Windows.Visibility.Hidden;
        }

        private void UnblockSave_Checked(object sender, RoutedEventArgs e)
        {
            UnblockSaveBox.Visibility = System.Windows.Visibility.Visible;
        }

        private void UnblockSave_Unchecked(object sender, RoutedEventArgs e)
        {
            UnblockSaveBox.Visibility = System.Windows.Visibility.Hidden;
        }
    }
}
