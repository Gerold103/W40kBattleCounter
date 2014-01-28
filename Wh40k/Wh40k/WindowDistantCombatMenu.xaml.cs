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

//И Н И Ц И А Л И З А Ц И Я   О К Н А   Д А Л Ь Н Е Г О   Б О Я

        public WindowDistantCombatMenu() //инициализация
        {
            InitializeComponent();
            CheckBoxDefIsOpenVeh.Visibility = System.Windows.Visibility.Hidden;  //изначально флаг открытости техники не имеет смысла, так как по умолчанию цель - пехота
        }

//С О Б Ы Т И Я   О К Н А   Д А Л Ь Н Е Г О   Б О Я

        private void Window_MouseDown(object sender, MouseButtonEventArgs e) //перетаскивание окна
        {
            this.DragMove();
        }

//С О Б Ы Т И Я   К Н О П К И   З А К Р Ы Т И Я   О К Н А

        private void ButtonCloseWindow_Click(object sender, RoutedEventArgs e) //закрытие окна по нажатию кнопки "Закрыть"
        {
            this.Close();
        }

//С П А С Б Р О С О К   Б Р О Н И

        private void CheckBoxDefArmorSave_Checked(object sender, RoutedEventArgs e) //если флаг спаса за броню установлен, то его поле ввода появляется
        {
            if (TextBoxDefArmorSave != null) TextBoxDefArmorSave.Visibility = System.Windows.Visibility.Visible;
        }

        private void CheckBoxDefArmorSave_Unchecked(object sender, RoutedEventArgs e) //если флаг спаса за броню сброшен, то его поле ввода исчезает
        {
            if (TextBoxDefArmorSave != null) TextBoxDefArmorSave.Visibility = System.Windows.Visibility.Hidden;
        }

//С П А С Б Р О С О К   Н Е И Г Н О Р И Р У Е М Ы Й

        private void CheckBoxDefInvulSave_Checked(object sender, RoutedEventArgs e) //если флаг неигнорируемого спаса установлен, то его поле ввода появляется
        {
            if (TextBoxDefInvulSave != null) TextBoxDefInvulSave.Visibility = System.Windows.Visibility.Visible;
        }

        private void CheckBoxDefInvulSave_Unchecked(object sender, RoutedEventArgs e) //если флаг неигнорируемого спаса сброшен, то его поле ввода исчезает
        {
            if (TextBoxDefInvulSave != null) TextBoxDefInvulSave.Visibility = System.Windows.Visibility.Hidden;
        }

//С П А С Б Р О С О К   З А   У К Р Ы Т И Е

        private void CheckBoxDefCoverSave_Checked(object sender, RoutedEventArgs e) //если флаг спаса за укрытие установлен, то его поле ввода появляется
        {
            if (TextBoxDefCoverSave != null) TextBoxDefCoverSave.Visibility = System.Windows.Visibility.Visible;
        }

        private void CheckBoxDefCoverSave_Unchecked(object sender, RoutedEventArgs e) //если флаг спаса за укрытие сброшен, то его поле ввода исчезает
        {
            if (TextBoxDefCoverSave != null) TextBoxDefCoverSave.Visibility = System.Windows.Visibility.Hidden;
        }

//Я В Л Я Е Т С Я   Л И   О Б О Р О Н Я Ю Щ И Й С Я   П Е Х О Т О Й

        private void CheckBoxDefIsInfantry_Checked(object sender, RoutedEventArgs e) //если флаг того, что цель пехота установлен, то производятся косметические корректировки внешнего вида
            //одного поля и пропадает флаг открытости техники
        {
            if (CheckBoxDefIsOpenVeh != null) CheckBoxDefIsOpenVeh.Visibility = System.Windows.Visibility.Hidden;
            if (LabelDefenceT != null) LabelDefenceT.Content = "T";
        }

        private void CheckBoxDefIsInfantry_Unchecked(object sender, RoutedEventArgs e) //если флаг того, что цель пехота сброшен, то производятся косметические корректировки внешнего вида
            //одного поля и появляется флаг открытости техники
        {
            if (CheckBoxDefIsOpenVeh != null) CheckBoxDefIsOpenVeh.Visibility = System.Windows.Visibility.Visible;
            if (LabelDefenceT != null) LabelDefenceT.Content = "Броня";
        }
    }
}
