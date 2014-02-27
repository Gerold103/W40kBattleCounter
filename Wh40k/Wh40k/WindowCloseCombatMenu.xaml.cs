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
using System.Windows.Shapes;

namespace Wh40k
{
    /// <summary>
    /// Interaction logic for WindowCloseCombatMenu.xaml
    /// </summary>
    public partial class WindowCloseCombatMenu : Window
    {

//И Н И Ц И А Л И З А Ц И Я   О К Н А   Б Л И Ж Н Е Г О   Б О Я

        public WindowCloseCombatMenu() //инициализация
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
                CombatLib.Offence.Melee.OMInfantry AttackingPlayer = new CombatLib.Offence.Melee.OMInfantry();
                try
                {
                    errLoc = "A";
                    AttackingPlayer.A = Convert.ToInt32(this.TextBoxOffenceA.Text);
                    errLoc = "S";
                    AttackingPlayer.S = Convert.ToInt16(this.TextBoxOffenceS.Text);
                    errLoc = "WS";
                    AttackingPlayer.WS = Convert.ToInt16(this.TextBoxOffenceWS.Text);
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
                    CombatLib.Defence.Melee.DMInfantry DefendingPlayer = new CombatLib.Defence.Melee.DMInfantry();
                    try
                    {
                        errLoc = "ArmorSave";
                        DefendingPlayer.ArmorSave = Convert.ToInt16(this.TextBoxDefArmorSave.Text);
                        errLoc = "InvulSave";
                        DefendingPlayer.InvulSave = Convert.ToInt16(this.TextBoxDefInvulSave.Text);
                        errLoc = "WS";
                        DefendingPlayer.WS = Convert.ToInt16(this.TextBoxDefenceWS);
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
                    CombatLib.Defence.Melee.DMVehicle DefendingPlayer = new CombatLib.Defence.Melee.DMVehicle();
                    try
                    {
                        errLoc = "WS";
                        DefendingPlayer.WS = Convert.ToInt16(this.TextBoxDefenceWS);
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
                CombatLib.Offence.Melee.OMVehicle AttackingPlayer = new CombatLib.Offence.Melee.OMVehicle();
                try
                {
                    errLoc = "A";
                    AttackingPlayer.A = Convert.ToInt32(this.TextBoxOffenceA.Text);
                    errLoc = "S";
                    AttackingPlayer.S = Convert.ToInt16(this.TextBoxOffenceS.Text);
                    errLoc = "WS";
                    AttackingPlayer.WS = Convert.ToInt16(this.TextBoxOffenceWS.Text);
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
                    CombatLib.Defence.Melee.DMInfantry DefendingPlayer = new CombatLib.Defence.Melee.DMInfantry();
                    try
                    {
                        errLoc = "ArmorSave";
                        DefendingPlayer.ArmorSave = Convert.ToInt16(this.TextBoxDefArmorSave.Text);
                        errLoc = "InvulSave";
                        DefendingPlayer.InvulSave = Convert.ToInt16(this.TextBoxDefInvulSave.Text);
                        errLoc = "WS";
                        DefendingPlayer.WS = Convert.ToInt16(this.TextBoxDefenceWS);
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
                    CombatLib.Defence.Melee.DMVehicle DefendingPlayer = new CombatLib.Defence.Melee.DMVehicle();
                    try
                    {
                        errLoc = "WS";
                        DefendingPlayer.WS = Convert.ToInt16(this.TextBoxDefenceWS);
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
        private void PlayVehicleVSVehicle(CombatLib.Offence.Melee.OMVehicle AttackingPlayer, CombatLib.Defence.Melee.DMVehicle DefendingPlayer)
        {
            //отладочные выводы
            MessageBox.Show("VehicleVSVehicle");
            MessageBox.Show(AttackingPlayer.ToString(), "AttackingPlayer");
            MessageBox.Show(DefendingPlayer.ToString(), "DefendingPlayer");
        }

        //Т Е Х Н И К А   П Р О Т И В   П Е Х О Т Ы
        private void PlayVehicleVSInfantry(CombatLib.Offence.Melee.OMVehicle AttackingPlayer, CombatLib.Defence.Melee.DMInfantry DefendingPlayer)
        {
            //отладочные выводы
            MessageBox.Show("VehicleVSInfantry");
            MessageBox.Show(AttackingPlayer.ToString(), "AttackingPlayer");
            MessageBox.Show(DefendingPlayer.ToString(), "DefendingPlayer");
        }

        //П Е Х О Т А   П Р О Т И В   Т Е Х Н И К И
        private void PlayInfantryVSVehicle(CombatLib.Offence.Melee.OMInfantry AttackingPlayer, CombatLib.Defence.Melee.DMVehicle DefendingPlayer)
        {
            //отладочные выводы
            MessageBox.Show("InfantryVSVehicle");
            MessageBox.Show(AttackingPlayer.ToString(), "AttackingPlayer");
            MessageBox.Show(DefendingPlayer.ToString(), "DefendingPlayer");
        }

        //П Е Х О Т А   П Р О Т И В   П Е Х О Т Ы
        private void PlayInfantryVSInfantry(CombatLib.Offence.Melee.OMInfantry AttackingPlayer, CombatLib.Defence.Melee.DMInfantry DefendingPlayer)
        {
            //отладочные выводы
            MessageBox.Show("InfantryVSInfantry");
            MessageBox.Show(AttackingPlayer.ToString(), "AttackingPlayer");
            MessageBox.Show(DefendingPlayer.ToString(), "DefendingPlayer");
        }

//В Ы В О Д   Р Е З У Л Ь Т А Т А

        //против пехоты
        void DisplayResult(CombatLib.Phases.PhaseHits.PhaseHitsInfantry Hits, CombatLib.Phases.PhaseWounds.PhaseWoundsInfantry Wounds = null, CombatLib.Phases.PhaseSaves.PhaseSavesInfantry Saves = null)
        {
            MessageBox.Show(Hits.ToString(), "Попадания", MessageBoxButton.OK);
            if (Wounds != null) MessageBox.Show(Wounds.ToString(), "Раны", MessageBoxButton.OK);
            if (Saves != null) MessageBox.Show(Saves.ToString(), "Спасброски", MessageBoxButton.OK);
            return;
        }

        //против техники
        void DisplayResult(CombatLib.Phases.PhaseHits.PhaseHitsVehicle Hits, CombatLib.Phases.PhaseWounds.PhaseWoundsVehicle Wounds = null, CombatLib.Phases.PhaseSaves.PhaseSavesVehicle Saves = null)
        {
            MessageBox.Show(Hits.ToString(), "Попадания", MessageBoxButton.OK);
            if (Wounds != null) MessageBox.Show(Wounds.ToString(), "Раны", MessageBoxButton.OK);
            if (Saves != null) MessageBox.Show(Saves.ToString(), "Спасброски", MessageBoxButton.OK);
            return;
        }

//Д О П О Л Н Е Н И Я

        void ButtonFillFieldsWithRnd_Click(object sender, RoutedEventArgs e)
        {
            Random RndGenerator = new Random();
            this.TextBoxOffenceA.Text = RndGenerator.Next(1, 11).ToString();
            this.TextBoxOffenceAP.Text = RndGenerator.Next(1, 7).ToString();
            this.TextBoxOffenceWS.Text = RndGenerator.Next(1, 11).ToString();
            this.TextBoxOffenceS.Text = RndGenerator.Next(1, 11).ToString();

            this.TextBoxDefArmorSave.Text = RndGenerator.Next(2, 7).ToString();
            this.TextBoxDefInvulSave.Text = RndGenerator.Next(2, 7).ToString();
            this.TextBoxDefenceWS.Text = RndGenerator.Next(1, 11).ToString();
            if (this.CheckBoxDefIsInfantry.IsChecked == true) this.TextBoxDefenceT.Text = RndGenerator.Next(1, 11).ToString();
            else this.TextBoxDefenceT.Text = RndGenerator.Next(1, 15).ToString();

            if (RndGenerator.Next(1, 3) == 1) this.CheckBoxDefArmorSave.IsChecked = false;
            else this.CheckBoxDefArmorSave.IsChecked = true;

            if (RndGenerator.Next(1, 3) == 1) this.CheckBoxDefInvulSave.IsChecked = false;
            else this.CheckBoxDefInvulSave.IsChecked = true;
            return;
        }
    }
}
