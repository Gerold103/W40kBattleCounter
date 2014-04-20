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
    /// Логика взаимодействия для WindowAutors.xaml
    /// </summary>
    public partial class WindowAutors : Window
    {
        public WindowAutors()
        {
            InitializeComponent();
        }

        private void Window_MouseDown(object sender, RoutedEventArgs e)
        {
            this.DragMove();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
