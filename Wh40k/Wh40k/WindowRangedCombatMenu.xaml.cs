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
                    this.PlayVehicleVSVehicle(AttackingPlayer, DefendingPlayer);
                    return;
                }
            }
        }

//Ф У Н К Ц И И   О Т Ы Г Р Ы Ш А   Б О Я

        //Т Е Х Н И К А   П Р О Т И В   Т Е Х Н И К И
        private void PlayVehicleVSVehicle(CombatLib.Offence.Ranged.ORVehicle AttackingPlayer, CombatLib.Defence.Ranged.DRVehicle DefendingPlayer)
        {
            /*//отладочные выводы
            MessageBox.Show("VehicleVSVehicle");
            MessageBox.Show(AttackingPlayer.ToString(), "AttackingPlayer");
            MessageBox.Show(DefendingPlayer.ToString(), "DefendingPlayer");*/

            //инициализация объектов
            Random RndGenerator = new Random();
            CombatLib.Phases.PhaseHits.PhaseHitsVehicle Hits = new CombatLib.Phases.PhaseHits.PhaseHitsVehicle();
            CombatLib.Phases.PhaseWounds.PhaseWoundsVehicle Wounds = new CombatLib.Phases.PhaseWounds.PhaseWoundsVehicle();
            CombatLib.Phases.PhaseSaves.PhaseSavesVehicle Saves = new CombatLib.Phases.PhaseSaves.PhaseSavesVehicle();

            //указатели на родителей классов
            CombatLib.Offence.Ranged.OffenceRanged baseORInfantry = AttackingPlayer;
            CombatLib.Phases.PhaseHits.PhaseHits basePhaseHitsVehicle = Hits;

            ////ПОДГОТОВЛЕНИЯ ПЕРЕД ИГРОЙ
            //вычисление наилучшего спасброска
            Saves.Condition = DefendingPlayer.CoverSave;

            //И Г Р А

            //попадания
            try
            {
                CombatLib.BattleFuncs.PlayHits.PlayRanged(baseORInfantry, ref basePhaseHitsVehicle, ref RndGenerator);
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message, "Ошибка: " + e.GetType().ToString(), MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (Hits.Hits == 0)
            {
                this.DisplayResult(Hits);
                return;
            }

            //раны
            try
            {
                CombatLib.BattleFuncs.PlayWounds.RangedPlay(baseORInfantry, DefendingPlayer, Hits, ref Wounds, ref RndGenerator);
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message, "Ошибка: " + e.GetType().ToString(), MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (Wounds.RowWounds == 0)
            {
                this.DisplayResult(Hits, Wounds);
                return;
            }

            //спасы
            try
            {
                CombatLib.BattleFuncs.PlaySaves.Play(ref Wounds, ref Saves, ref RndGenerator);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Ошибка: " + e.GetType().ToString(), MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            this.DisplayResult(Hits, Wounds, Saves);
        }

        //Т Е Х Н И К А   П Р О Т И В   П Е Х О Т Ы
        private void PlayVehicleVSInfantry(CombatLib.Offence.Ranged.ORVehicle AttackingPlayer, CombatLib.Defence.Ranged.DRInfantry DefendingPlayer)
        {
            /*//отладочные выводы
            MessageBox.Show("VehicleVSInfantry");
            MessageBox.Show(AttackingPlayer.ToString(), "AttackingPlayer");
            MessageBox.Show(DefendingPlayer.ToString(), "DefendingPlayer");*/

            //инициализация объектов
            Random RndGenerator = new Random();
            CombatLib.Phases.PhaseHits.PhaseHitsInfantry Hits = new CombatLib.Phases.PhaseHits.PhaseHitsInfantry();
            CombatLib.Phases.PhaseWounds.PhaseWoundsInfantry Wounds = new CombatLib.Phases.PhaseWounds.PhaseWoundsInfantry();
            CombatLib.Phases.PhaseSaves.PhaseSavesInfantry Saves = new CombatLib.Phases.PhaseSaves.PhaseSavesInfantry();

            //указатели на родителей классов
            CombatLib.Offence.Ranged.OffenceRanged baseORInfantry = AttackingPlayer;
            CombatLib.Phases.PhaseHits.PhaseHits basePhaseHitsInfantry = Hits;

            ////ПОДГОТОВЛЕНИЯ ПЕРЕД ИГРОЙ
            //вычисление наилучшего спасброска
            Saves.Condition = CombatLib.Addition.AdditionalFuncs.BestSaveThrow(AttackingPlayer.AP, DefendingPlayer.CoverSave, DefendingPlayer.ArmorSave, DefendingPlayer.InvulSave);

            //И Г Р А

            //попадания
            try
            {
                CombatLib.BattleFuncs.PlayHits.PlayRanged(baseORInfantry, ref basePhaseHitsInfantry, ref RndGenerator);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Ошибка: " + e.GetType().ToString(), MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (Hits.Hits == 0)
            {
                this.DisplayResult(Hits);
                return;
            }

            //раны
            try
            {
                CombatLib.BattleFuncs.PlayWounds.RangedPlay(baseORInfantry, DefendingPlayer, Hits, ref Wounds, ref RndGenerator);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Ошибка: " + e.GetType().ToString(), MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (Wounds.RowWounds == 0)
            {
                this.DisplayResult(Hits, Wounds);
                return;
            }

            //спасы
            try
            {
                CombatLib.BattleFuncs.PlaySaves.Play(ref Wounds, ref Saves, ref RndGenerator);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Ошибка: " + e.GetType().ToString(), MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            this.DisplayResult(Hits, Wounds, Saves);
        }

        //П Е Х О Т А   П Р О Т И В   Т Е Х Н И К И
        private void PlayInfantryVSVehicle(CombatLib.Offence.Ranged.ORInfantry AttackingPlayer, CombatLib.Defence.Ranged.DRVehicle DefendingPlayer)
        {
            /*//отладочные выводы
            MessageBox.Show("InfantryVSVehicle");
            MessageBox.Show(AttackingPlayer.ToString(), "AttackingPlayer");
            MessageBox.Show(DefendingPlayer.ToString(), "DefendingPlayer");*/

            //инициализация объектов
            Random RndGenerator = new Random();
            CombatLib.Phases.PhaseHits.PhaseHitsVehicle Hits = new CombatLib.Phases.PhaseHits.PhaseHitsVehicle();
            CombatLib.Phases.PhaseWounds.PhaseWoundsVehicle Wounds = new CombatLib.Phases.PhaseWounds.PhaseWoundsVehicle();
            CombatLib.Phases.PhaseSaves.PhaseSavesVehicle Saves = new CombatLib.Phases.PhaseSaves.PhaseSavesVehicle();

            //указатели на родителей классов
            CombatLib.Offence.Ranged.OffenceRanged baseORInfantry = AttackingPlayer;
            CombatLib.Phases.PhaseHits.PhaseHits basePhaseHitsVehicle = Hits;

            ////ПОДГОТОВЛЕНИЯ ПЕРЕД ИГРОЙ
            //вычисление наилучшего спасброска
            Saves.Condition = DefendingPlayer.CoverSave;

            //И Г Р А

            //попадания
            try
            {
                CombatLib.BattleFuncs.PlayHits.PlayRanged(baseORInfantry, ref basePhaseHitsVehicle, ref RndGenerator);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Ошибка: " + e.GetType().ToString(), MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (Hits.Hits == 0)
            {
                this.DisplayResult(Hits);
                return;
            }

            //раны
            try
            {
                CombatLib.BattleFuncs.PlayWounds.RangedPlay(baseORInfantry, DefendingPlayer, Hits, ref Wounds, ref RndGenerator);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Ошибка: " + e.GetType().ToString(), MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (Wounds.RowWounds == 0)
            {
                this.DisplayResult(Hits, Wounds);
                return;
            }

            //спасы
            try
            {
                CombatLib.BattleFuncs.PlaySaves.Play(ref Wounds, ref Saves, ref RndGenerator);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Ошибка: " + e.GetType().ToString(), MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            this.DisplayResult(Hits, Wounds, Saves);
        }

        //П Е Х О Т А   П Р О Т И В   П Е Х О Т Ы
        private void PlayInfantryVSInfantry(CombatLib.Offence.Ranged.ORInfantry AttackingPlayer, CombatLib.Defence.Ranged.DRInfantry DefendingPlayer)
        {
            /*//отладочные выводы
            MessageBox.Show("InfantryVSInfantry");
            MessageBox.Show(AttackingPlayer.ToString(), "AttackingPlayer");
            MessageBox.Show(DefendingPlayer.ToString(), "DefendingPlayer");*/

            //инициализация объектов
            Random RndGenerator = new Random(); //генератор рандомных числе - один на все время работы программы со случайной затравкой
            CombatLib.Phases.PhaseHits.PhaseHitsInfantry Hits = new CombatLib.Phases.PhaseHits.PhaseHitsInfantry(); //класс фазы попаданий
            CombatLib.Phases.PhaseWounds.PhaseWoundsInfantry Wounds = new CombatLib.Phases.PhaseWounds.PhaseWoundsInfantry(); //класс фазы ран
            CombatLib.Phases.PhaseSaves.PhaseSavesInfantry Saves = new CombatLib.Phases.PhaseSaves.PhaseSavesInfantry(); //класс фазы спасбросков

            //указатели на родителей классов
            CombatLib.Offence.Ranged.OffenceRanged baseORInfantry = AttackingPlayer; //родитель атакующего игрока
            CombatLib.Phases.PhaseHits.PhaseHits basePhaseHitsInfantry = Hits; //родитель фазы попаданий

            //ПОДГОТОВЛЕНИЯ ПЕРЕД ИГРОЙ
            //вычисление наилучшего спасброска
            Saves.Condition = CombatLib.Addition.AdditionalFuncs.BestSaveThrow(AttackingPlayer.AP, DefendingPlayer.CoverSave, DefendingPlayer.ArmorSave, DefendingPlayer.InvulSave);

            //И Г Р А

            //попадания
            try
            {
                CombatLib.BattleFuncs.PlayHits.PlayRanged(baseORInfantry, ref basePhaseHitsInfantry, ref RndGenerator);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Ошибка: " + e.GetType().ToString(), MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (Hits.Hits == 0)
            {
                this.DisplayResult(Hits);
                return;
            }

            //раны
            try
            {
                CombatLib.BattleFuncs.PlayWounds.RangedPlay(baseORInfantry, DefendingPlayer, Hits, ref Wounds, ref RndGenerator);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Ошибка: " + e.GetType().ToString(), MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (Wounds.RowWounds == 0)
            {
                this.DisplayResult(Hits, Wounds);
                return;
            }

            //спасы
            try
            {
                CombatLib.BattleFuncs.PlaySaves.Play(ref Wounds, ref Saves, ref RndGenerator);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Ошибка: " + e.GetType().ToString(), MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            this.DisplayResult(Hits, Wounds, Saves);
        }

//В Ы В О Д   Р Е З У Л Ь Т А Т А

        //против пехоты
        void DisplayResult(CombatLib.Phases.PhaseHits.PhaseHitsInfantry Hits, CombatLib.Phases.PhaseWounds.PhaseWoundsInfantry Wounds = null, CombatLib.Phases.PhaseSaves.PhaseSavesInfantry Saves = null)
        {
            /*MessageBox.Show(Hits.ToString(), "Попадания", MessageBoxButton.OK);
            if (Wounds != null) MessageBox.Show(Wounds.ToString(), "Раны", MessageBoxButton.OK);
            if (Saves != null) MessageBox.Show(Saves.ToString(), "Спасброски", MessageBoxButton.OK);*/
            WindowResultInfantry Result = new WindowResultInfantry();
            Result.Show();

            //Hits label
            if (Hits.Condition <= 6)
                if (Hits.Hits != 0)
                    Result.LabelHits.Content = Hits.Hits.ToString();
                else
                    Result.LabelHits.Content = "нет";
            else
            {
                Result.LabelHits.Content = "нельзя попасть";
                Result.LabelHits.FontSize = 10;
            }

            if (Wounds == null)
            {
                Result.GroupWounds.Visibility = System.Windows.Visibility.Hidden;
                Result.GroupSaves.Visibility = System.Windows.Visibility.Hidden;
                return;
            }

            //Wounds label
            if (Wounds.Condition <= 6)
                if (Wounds.Wounds != 0)
                    Result.LabelWounds.Content = Wounds.Wounds.ToString();
                else
                    Result.LabelWounds.Content = "нет";
            else
            {
                Result.LabelWounds.Content = "нельзя ранить";
                Result.LabelWounds.FontSize = 10;
            }

            if (Saves == null)
            {
                Result.GroupSaves.Visibility = System.Windows.Visibility.Hidden;
                return;
            }

            //Saves label
            if (Saves.Condition <= 6)
                if (Saves.Saves != 0)
                    Result.LabelSaves.Content = Saves.Saves.ToString();
                else
                    Result.LabelSaves.Content = "нет";
            else
            {
                Result.LabelSaves.Content = "нельзя спасти";
                Result.LabelSaves.FontSize = 10;
            }

            //G R O U P   H I T S
            //Hit condition
            if (Hits.Condition <= 6)
                Result.LabelHitCondition.Content = Hits.Condition.ToString() + "+";
            else
            {
                Result.LabelHitCondition.Content = "не попасть";
                Result.LabelHitCondition.FontSize = 10;
            }
            //Additional hit condition
            if (Hits.AdditionalCondition > 6)
            {
                Result.LabelAddHitCondInfo.Visibility = System.Windows.Visibility.Hidden;
                Result.LabelAddHitCondition.Visibility = System.Windows.Visibility.Hidden;
            }
            else
            {
                Result.LabelAddHitCondition.Content = Hits.AdditionalCondition.ToString() + "+";
            }

            //If hit condition > 6 then battle ended
            if (Hits.Condition > 6)
            {
                Result.GroupWounds.Visibility = System.Windows.Visibility.Hidden;
                Result.GroupSaves.Visibility = System.Windows.Visibility.Hidden;
                Result.LabelHitCubesInfo.Visibility = System.Windows.Visibility.Hidden;
                Result.LabelHitCubes.Visibility = System.Windows.Visibility.Hidden;
                return;
            }
            //Hit cubes
            Result.LabelHitCubes.Content = Hits.HitCubesStr;

            //G R O U P   W O U N D S
            //Wound condition
            if (Wounds.Condition <= 6)
                Result.LabelWoundCondition.Content = Wounds.Condition.ToString() + "+";
            else
            {
                Result.LabelWoundCondition.Content = "не ранить";
            }

            //If wound condition > 6 then battle ended
            if (Wounds.Condition > 6)
            {
                Result.LabelWoundCubes.Visibility = System.Windows.Visibility.Hidden;
                Result.LabelWoundCubesInfo.Visibility = System.Windows.Visibility.Hidden;
                Result.GroupSaves.Visibility = System.Windows.Visibility.Hidden;
                return;
            }
            //Wound cubes
            Result.LabelWoundCubes.Content = Wounds.WoundCubesStr;

            //G R O U P   S A V E S
            //Save condition
            if (Saves.Condition <= 6)
                Result.LabelSaveCondition.Content = Saves.Condition.ToString() + "+";
            else
            {
                Result.LabelSaveCondition.Content = "не спасти";
            }

            //If save condition > 6 then battle ended
            if (Saves.Condition > 6)
            {
                Result.LabelSaveCubesInfo.Visibility = System.Windows.Visibility.Hidden;
                Result.LabelSaveCubes.Visibility = System.Windows.Visibility.Hidden;
                return;
            }
            //Save cubes
            Result.LabelSaveCubes.Content = Saves.SaveCubesStr;
            return;
        }

        //против техники
        void DisplayResult(CombatLib.Phases.PhaseHits.PhaseHitsVehicle Hits, CombatLib.Phases.PhaseWounds.PhaseWoundsVehicle Wounds = null, CombatLib.Phases.PhaseSaves.PhaseSavesVehicle Saves = null)
        {
            /*MessageBox.Show(Hits.ToString(), "Попадания", MessageBoxButton.OK);
            if (Wounds != null) MessageBox.Show(Wounds.ToString(), "Раны", MessageBoxButton.OK);
            if (Saves != null) MessageBox.Show(Saves.ToString(), "Спасброски", MessageBoxButton.OK);*/
            WindowResultVehicle Result = new WindowResultVehicle();
            Result.Show();

            //Hits label
            if (Hits.Condition <= 6)
                if (Hits.Hits != 0)
                    Result.LabelHits.Content = Hits.Hits.ToString();
                else
                    Result.LabelHits.Content = "нет";
            else
                Result.LabelHits.Content = "нельзя попасть";

            if (Wounds == null)
            {
                Result.GroupWounds.Visibility = System.Windows.Visibility.Hidden;
                Result.GroupSaves.Visibility = System.Windows.Visibility.Hidden;
                return;
            }

            //Wounds labels
            if (Wounds.Condition <= 6)
                if (Wounds.Wounds != 0)
                {
                    Result.LabelPunchedWounds.Content = Wounds.PunchedWounds.ToString();
                    Result.LabelSlidingWounds.Content = Wounds.SlidingWounds.ToString();
                }
                else
                {
                    Result.LabelPunchedWounds.Content = "нет";
                    Result.LabelSlidingWounds.Content = "нет";
                }
            else
            {
                Result.LabelPunchedWounds.Content = "нельзя ранить";
                Result.LabelSlidingWounds.Content = "нельзя ранить";
            }

            if (Saves == null)
            {
                Result.GroupSaves.Visibility = System.Windows.Visibility.Hidden;
                return;
            }

            //Saves label
            if (Saves.Condition <= 6)
                if (Saves.Saves != 0)
                    Result.LabelSaves.Content = Saves.Saves.ToString();
                else
                    Result.LabelSaves.Content = "нет";
            else
                Result.LabelSaves.Content = "нельзя спасти";

            //G R O U P   H I T S
            //Hit condition
            if (Hits.Condition <= 6)
                Result.LabelHitCondition.Content = Hits.Condition.ToString() + "+";
            else
            {
                Result.LabelHitCondition.Content = "не попасть";
                Result.LabelHitCondition.FontSize = 10;
            }
            //Additional hit condition
            if (Hits.AdditionalCondition > 6)
            {
                Result.LabelAddHitCondInfo.Visibility = System.Windows.Visibility.Hidden;
                Result.LabelAddHitCondition.Visibility = System.Windows.Visibility.Hidden;
            }
            else
            {
                Result.LabelAddHitCondition.Content = Hits.AdditionalCondition.ToString() + "+";
            }

            //If hit condition > 6 then battle ended
            if (Hits.Condition > 6)
            {
                Result.GroupWounds.Visibility = System.Windows.Visibility.Hidden;
                Result.GroupSaves.Visibility = System.Windows.Visibility.Hidden;
                Result.LabelHitCubesInfo.Visibility = System.Windows.Visibility.Hidden;
                Result.LabelHitCubes.Visibility = System.Windows.Visibility.Hidden;
                return;
            }
            //Hit cubes
            Result.LabelHitCubes.Content = Hits.HitCubesStr;

            //G R O U P   W O U N D S
            //Wound condition
            if (Wounds.Condition <= 6)
                Result.LabelWoundCondition.Content = Wounds.Condition.ToString() + "+";
            else
            {
                Result.LabelWoundCondition.Content = "не ранить";
            }

            //If wound condition > 6 then battle ended
            if (Wounds.Condition > 6)
            {
                Result.LabelWoundCubes.Visibility = System.Windows.Visibility.Hidden;
                Result.LabelWoundCubesInfo.Visibility = System.Windows.Visibility.Hidden;
                Result.GroupSaves.Visibility = System.Windows.Visibility.Hidden;
                return;
            }
            //Wound cubes
            Result.LabelWoundCubes.Content = Wounds.WoundCubesStr;

            //G R O U P   S A V E S
            //Save condition
            if (Saves.Condition <= 6)
                Result.LabelSaveCondition.Content = Saves.Condition.ToString() + "+";
            else
            {
                Result.LabelSaveCondition.Content = "не спасти";
            }

            //If save condition > 6 then battle ended
            if (Saves.Condition > 6)
            {
                Result.LabelSaveCubesInfo.Visibility = System.Windows.Visibility.Hidden;
                Result.LabelSaveCubes.Visibility = System.Windows.Visibility.Hidden;
                return;
            }
            //Save cubes
            Result.LabelSaveCubes.Content = Saves.SaveCubesStr;
            return;
        }

//Д О П О Л Н Е Н И Я

        void ButtonFillFieldsWithRnd_Click(object sender, RoutedEventArgs e)
        {
            Random RndGenerator = new Random();
            this.TextBoxOffenceA.Text = RndGenerator.Next(1, 11).ToString();
            this.TextBoxOffenceAP.Text = RndGenerator.Next(1, 7).ToString();
            this.TextBoxOffenceBS.Text = RndGenerator.Next(1, 11).ToString();
            this.TextBoxOffenceS.Text = RndGenerator.Next(1, 11).ToString();

            this.TextBoxDefArmorSave.Text = RndGenerator.Next(2, 7).ToString();
            this.TextBoxDefCoverSave.Text = RndGenerator.Next(2, 7).ToString();
            this.TextBoxDefInvulSave.Text = RndGenerator.Next(2, 7).ToString();
            if (this.CheckBoxDefIsInfantry.IsChecked == true) this.TextBoxDefenceT.Text = RndGenerator.Next(1, 11).ToString();
            else this.TextBoxDefenceT.Text = RndGenerator.Next(1, 15).ToString();

            if (RndGenerator.Next(1, 3) == 1) this.CheckBoxDefArmorSave.IsChecked = false;
            else this.CheckBoxDefArmorSave.IsChecked = true;

            if (RndGenerator.Next(1, 3) == 1) this.CheckBoxDefCoverSave.IsChecked = false;
            else this.CheckBoxDefCoverSave.IsChecked = true;

            if (RndGenerator.Next(1, 3) == 1) this.CheckBoxDefInvulSave.IsChecked = false;
            else this.CheckBoxDefInvulSave.IsChecked = true;
            return;
        }
    }
}
