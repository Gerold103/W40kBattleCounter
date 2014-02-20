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
            if (CheckBoxDefIsOpenVeh != null) CheckBoxDefIsOpenVeh.Visibility = System.Windows.Visibility.Hidden; //скрыть чекбокс открытой техники
            if (LabelDefenceT != null) LabelDefenceT.Content = "T"; //переименовать поле защиты
            if (CheckBoxDefArmorSave != null) CheckBoxDefArmorSave.Visibility = System.Windows.Visibility.Visible; //сделать видимым блок спасброска по броне
            if ((TextBoxDefArmorSave != null) && (CheckBoxDefArmorSave.IsChecked == true)) TextBoxDefArmorSave.Visibility = System.Windows.Visibility.Visible;

            if (CheckBoxDefInvulSave != null) CheckBoxDefInvulSave.Visibility = System.Windows.Visibility.Visible; //сделать видимым блок непробиваемого спасброска
            if ((TextBoxDefInvulSave != null) && (CheckBoxDefInvulSave.IsChecked == true)) TextBoxDefInvulSave.Visibility = System.Windows.Visibility.Visible;
        }

        private void CheckBoxDefIsInfantry_Unchecked(object sender, RoutedEventArgs e) //если флаг того, что цель пехота сброшен, то производятся косметические корректировки внешнего вида
            //одного поля и появляется флаг открытости техники
        {
            if (CheckBoxDefIsOpenVeh != null) CheckBoxDefIsOpenVeh.Visibility = System.Windows.Visibility.Visible; //открыть чекбокс открытой техники
            if (LabelDefenceT != null) LabelDefenceT.Content = "Броня"; //переименовать поле защиты
            if (CheckBoxDefArmorSave != null) CheckBoxDefArmorSave.Visibility = System.Windows.Visibility.Hidden; //сделать скрытым блок спасброска по броне
            if (TextBoxDefArmorSave != null) TextBoxDefArmorSave.Visibility = System.Windows.Visibility.Hidden;

            if (CheckBoxDefInvulSave != null) CheckBoxDefInvulSave.Visibility = System.Windows.Visibility.Hidden; //сделать скрытым блок непробиваемого спасброска
            if (TextBoxDefInvulSave != null) TextBoxDefInvulSave.Visibility = System.Windows.Visibility.Hidden;
        }

//К Н О П К А   " С Ы Г Р А Т Ь   Б О Й "

        private void ButtonPlayCombat_Click(object sender, RoutedEventArgs e) //Клик
        {
            string errLoc = "#Err"; //переменная для хранения обрабатываемого в данный момент поля меню
            if (this.CheckBoxOffIsInfantry.IsChecked == true) //если атакующий - пехота
            {
                CombatLib.Offence.Ranged.ORInfantry AttackingPlayer = new CombatLib.Offence.Ranged.ORInfantry();
                try
                {
                    errLoc = "A";
                    AttackingPlayer.A = Convert.ToInt32(this.TextBoxOffenceA.Text);
                    errLoc = "S";
                    AttackingPlayer.S = Convert.ToInt16(this.TextBoxOffenceS.Text);
                    errLoc = "BS";
                    AttackingPlayer.BS = Convert.ToInt16(this.TextBoxOffenceBS.Text);
                    errLoc = "AP";
                    AttackingPlayer.AP = Convert.ToInt16(this.TextBoxOffenceAP.Text);
                }
                catch (FormatException)
                {
                    MessageBox.Show("В поле " + errLoc + " введено не число.", "Ошибка в " + errLoc, MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                catch (OverflowException)
                {
                    MessageBox.Show("В поле " + errLoc + "введено слишком большое по модулю число.", "Ошибка в " + errLoc, MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                catch (ApplicationException excpt)
                {
                    MessageBox.Show(excpt.Message, "Ошибка в " + errLoc, MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                catch (Exception excpt)
                {
                    MessageBox.Show(excpt.Message + "\nСообщите разработчикам об этой ошибке", "Неизвестная ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                if (this.CheckBoxDefIsInfantry.IsChecked == true) //если защищающийся - пехота и атакующий - пехота
                {
                    CombatLib.Defence.Ranged.DRInfantry DefendingPlayer = new CombatLib.Defence.Ranged.DRInfantry();
                    try
                    {
                        errLoc = "ArmorSave";
                        DefendingPlayer.ArmorSave = Convert.ToInt16(this.TextBoxDefArmorSave.Text);
                        errLoc = "InvulSave";
                        DefendingPlayer.InvulSave = Convert.ToInt16(this.TextBoxDefInvulSave.Text);
                        errLoc = "CoverSave";
                        DefendingPlayer.CoverSave = Convert.ToInt16(this.TextBoxDefCoverSave.Text);
                        errLoc = this.LabelDefenceT.Content.ToString();
                        DefendingPlayer.T = Convert.ToInt16(this.TextBoxDefenceT.Text);
                    }
                    catch (FormatException)
                    {
                        MessageBox.Show("В поле " + errLoc + " введено не число.", "Ошибка в " + errLoc, MessageBoxButton.OK, MessageBoxImage.Error);
                        return;
                    }
                    catch (OverflowException)
                    {
                        MessageBox.Show("В поле " + errLoc + "введено слишком большое по модулю число.", "Ошибка в " + errLoc, MessageBoxButton.OK, MessageBoxImage.Error);
                        return;
                    }
                    catch (ApplicationException excpt)
                    {
                        MessageBox.Show(excpt.Message, "Ошибка в " + errLoc, MessageBoxButton.OK, MessageBoxImage.Error);
                        return;
                    }
                    catch (Exception excpt)
                    {
                        MessageBox.Show(excpt.Message + "\nСообщите разработчикам об этой ошибке", "Неизвестная ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                        return;
                    }
                    this.PlayInfantryVSInfantry(AttackingPlayer, DefendingPlayer);
                    return;
                }
                else //если защищающийся - техника и атакующий - пехота
                {
                    CombatLib.Defence.Ranged.DRVehicle DefendingPlayer = new CombatLib.Defence.Ranged.DRVehicle();
                    try
                    {
                        DefendingPlayer.CoverSave = Convert.ToInt16(this.TextBoxDefCoverSave.Text);
                        errLoc = this.LabelDefenceT.Content.ToString();
                        DefendingPlayer.T = Convert.ToInt16(this.TextBoxDefenceT.Text);
                    }
                    catch (FormatException)
                    {
                        MessageBox.Show("В поле " + errLoc + " введено не число.", "Ошибка в " + errLoc, MessageBoxButton.OK, MessageBoxImage.Error);
                        return;
                    }
                    catch (OverflowException)
                    {
                        MessageBox.Show("В поле " + errLoc + "введено слишком большое по модулю число.", "Ошибка в " + errLoc, MessageBoxButton.OK, MessageBoxImage.Error);
                        return;
                    }
                    catch (ApplicationException excpt)
                    {
                        MessageBox.Show(excpt.Message, "Ошибка в " + errLoc, MessageBoxButton.OK, MessageBoxImage.Error);
                        return;
                    }
                    catch (Exception excpt)
                    {
                        MessageBox.Show(excpt.Message + "\nСообщите разработчикам об этой ошибке", "Неизвестная ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                        return;
                    }
                    this.PlayInfantryVSVehicle(AttackingPlayer, DefendingPlayer);
                    return;
                }
            }
            else //атакующий - техника
            {
                CombatLib.Offence.Ranged.ORVehicle AttackingPlayer = new CombatLib.Offence.Ranged.ORVehicle();
                try
                {
                    errLoc = "A";
                    AttackingPlayer.A = Convert.ToInt32(this.TextBoxOffenceA.Text);
                    errLoc = "S";
                    AttackingPlayer.S = Convert.ToInt16(this.TextBoxOffenceS.Text);
                    errLoc = "BS";
                    AttackingPlayer.BS = Convert.ToInt16(this.TextBoxOffenceBS.Text);
                    errLoc = "AP";
                    AttackingPlayer.AP = Convert.ToInt16(this.TextBoxOffenceAP.Text);
                }
                catch (FormatException)
                {
                    MessageBox.Show("В поле " + errLoc + " введено не число.", "Ошибка в " + errLoc, MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                catch (OverflowException)
                {
                    MessageBox.Show("В поле " + errLoc + "введено слишком большое по модулю число.", "Ошибка в " + errLoc, MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                catch (ApplicationException excpt)
                {
                    MessageBox.Show(excpt.Message, "Ошибка в " + errLoc, MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                catch (Exception excpt)
                {
                    MessageBox.Show(excpt.Message + "\nСообщите разработчикам об этой ошибке", "Неизвестная ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                if (this.CheckBoxDefIsInfantry.IsChecked == true) //атакующий - техника и защищающийся - пехота
                {
                    CombatLib.Defence.Ranged.DRInfantry DefendingPlayer = new CombatLib.Defence.Ranged.DRInfantry();
                    try
                    {
                        errLoc = "ArmorSave";
                        DefendingPlayer.ArmorSave = Convert.ToInt16(this.TextBoxDefArmorSave.Text);
                        errLoc = "InvulSave";
                        DefendingPlayer.InvulSave = Convert.ToInt16(this.TextBoxDefInvulSave.Text);
                        errLoc = "CoverSave";
                        DefendingPlayer.CoverSave = Convert.ToInt16(this.TextBoxDefCoverSave.Text);
                        errLoc = this.LabelDefenceT.Content.ToString();
                        DefendingPlayer.T = Convert.ToInt16(this.TextBoxDefenceT.Text);
                    }
                    catch (FormatException)
                    {
                        MessageBox.Show("В поле " + errLoc + " введено не число.", "Ошибка в " + errLoc, MessageBoxButton.OK, MessageBoxImage.Error);
                        return;
                    }
                    catch (OverflowException)
                    {
                        MessageBox.Show("В поле " + errLoc + "введено слишком большое по модулю число.", "Ошибка в " + errLoc, MessageBoxButton.OK, MessageBoxImage.Error);
                        return;
                    }
                    catch (ApplicationException excpt)
                    {
                        MessageBox.Show(excpt.Message, "Ошибка в " + errLoc, MessageBoxButton.OK, MessageBoxImage.Error);
                        return;
                    }
                    catch (Exception excpt)
                    {
                        MessageBox.Show(excpt.Message + "\nСообщите разработчикам об этой ошибке", "Неизвестная ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                        return;
                    }
                    this.PlayVehicleVSInfantry(AttackingPlayer, DefendingPlayer);
                    return;
                }
                else //атакующий - техника и защищающийся - техника
                {
                    CombatLib.Defence.Ranged.DRVehicle DefendingPlayer = new CombatLib.Defence.Ranged.DRVehicle();
                    try
                    {
                        DefendingPlayer.CoverSave = Convert.ToInt16(this.TextBoxDefCoverSave.Text);
                        errLoc = this.LabelDefenceT.Content.ToString();
                        DefendingPlayer.T = Convert.ToInt16(this.TextBoxDefenceT.Text);
                    }
                    catch (FormatException)
                    {
                        MessageBox.Show("В поле " + errLoc + " введено не число.", "Ошибка в " + errLoc, MessageBoxButton.OK, MessageBoxImage.Error);
                        return;
                    }
                    catch (OverflowException)
                    {
                        MessageBox.Show("В поле " + errLoc + "введено слишком большое по модулю число.", "Ошибка в " + errLoc, MessageBoxButton.OK, MessageBoxImage.Error);
                        return;
                    }
                    catch (ApplicationException excpt)
                    {
                        MessageBox.Show(excpt.Message, "Ошибка в " + errLoc, MessageBoxButton.OK, MessageBoxImage.Error);
                        return;
                    }
                    catch (Exception excpt)
                    {
                        MessageBox.Show(excpt.Message + "\nСообщите разработчикам об этой ошибке", "Неизвестная ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                        return;
                    }
                    this.PlayVehicleVSVehicle(AttackingPlayer, DefendingPlayer);
                    return;
                }
            }
        }

//Ф У Н К Ц И И   О Т Ы Г Р Ы Ш А   Б О Я

        //Т Е Х Н И К А   П Р О Т И В   Т Е Х Н И К И
        private void PlayVehicleVSVehicle(CombatLib.Offence.Ranged.ORVehicle AttackingPlayer, CombatLib.Defence.Ranged.DRVehicle DefendingPlayer)
        {
            MessageBox.Show("VehicleVSVehicle");
        }

        //Т Е Х Н И К А   П Р О Т И В   П Е Х О Т Ы
        private void PlayVehicleVSInfantry(CombatLib.Offence.Ranged.ORVehicle AttackingPlayer, CombatLib.Defence.Ranged.DRInfantry DefendingPlayer)
        {
            MessageBox.Show("VehicleVSInfantry");
        }

        //П Е Х О Т А   П Р О Т И В   Т Е Х Н И К И
        private void PlayInfantryVSVehicle(CombatLib.Offence.Ranged.ORInfantry AttackingPlayer, CombatLib.Defence.Ranged.DRVehicle DefendingPlayer)
        {
            MessageBox.Show("InfantryVSVehicle");
        }

        //П Е Х О Т А   П Р О Т И В   П Е Х О Т Ы
        private void PlayInfantryVSInfantry(CombatLib.Offence.Ranged.ORInfantry AttackingPlayer, CombatLib.Defence.Ranged.DRInfantry DefendingPlayer)
        {
            MessageBox.Show("InfantryVSInfantry");
            MessageBox.Show(AttackingPlayer.ToString());
            MessageBox.Show(DefendingPlayer.ToString());
            Random RndGenerator = new Random();
            CombatLib.Phases.PhaseHits.PhaseHitsInfantry Hits = new CombatLib.Phases.PhaseHits.PhaseHitsInfantry();
            CombatLib.Offence.Ranged.OffenceRanged baseORInfantry = AttackingPlayer;
            CombatLib.Phases.PhaseHits.PhaseHits basePhaseHitsInfantry = Hits;
            CombatLib.BattleFuncs.PlayHits.PlayRanged(baseORInfantry, ref basePhaseHitsInfantry, ref RndGenerator);
            MessageBox.Show("Additional Condition = " + Hits.AdditionalCondition.ToString() + "\n" +
                "Condition = " + Hits.Condition.ToString() + "\n" +
                "HitCubes = " + Hits.HitCubes.ToString() + "\n" +
                "HitCubesStr = " + Hits.HitCubesStr + "\n" +
                "Hits = " + Hits.Hits.ToString());
        }
    }
}
