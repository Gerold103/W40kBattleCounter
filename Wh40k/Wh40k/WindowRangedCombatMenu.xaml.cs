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
                        if (this.CheckBoxDefArmorSave.IsChecked == true)
                        {
                            DefendingPlayer.ArmorSave = Convert.ToInt16(this.TextBoxDefArmorSave.Text);
                        }
                        errLoc = "InvulSave";
                        if (this.CheckBoxDefInvulSave.IsChecked == true)
                        {
                            DefendingPlayer.InvulSave = Convert.ToInt16(this.TextBoxDefInvulSave.Text);
                        }
                        errLoc = "CoverSave";
                        if (this.CheckBoxDefCoverSave.IsChecked == true)
                        {
                            DefendingPlayer.CoverSave = Convert.ToInt16(this.TextBoxDefCoverSave.Text);
                        }
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
                        if (this.CheckBoxDefCoverSave.IsChecked == true)
                        {
                            DefendingPlayer.CoverSave = Convert.ToInt16(this.TextBoxDefCoverSave.Text);
                        }
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
                        if (this.CheckBoxDefArmorSave.IsChecked == true)
                        {
                            DefendingPlayer.ArmorSave = Convert.ToInt16(this.TextBoxDefArmorSave.Text);
                        }
                        errLoc = "InvulSave";
                        if (this.CheckBoxDefInvulSave.IsChecked == true)
                        {
                            DefendingPlayer.InvulSave = Convert.ToInt16(this.TextBoxDefInvulSave.Text);
                        }
                        errLoc = "CoverSave";
                        if (this.CheckBoxDefCoverSave.IsChecked == true)
                        {
                            DefendingPlayer.CoverSave = Convert.ToInt16(this.TextBoxDefCoverSave.Text);
                        }
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
                        if (this.CheckBoxDefCoverSave.IsChecked == true)
                        {
                            DefendingPlayer.CoverSave = Convert.ToInt16(this.TextBoxDefCoverSave.Text);
                        }
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
            this.DisplayResult(Hits, Wounds, AttackingPlayer.S, Saves);
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
            this.DisplayResult(Hits, Wounds, AttackingPlayer.S, Saves);
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

            if (Wounds == null)
                SetResultImg(ref Result, Hits.Hits);
            else
                SetResultImg(ref Result, Hits.Hits, Wounds.Wounds);

            //Hits
            if (Hits.Condition > 6)
            {
                //hits
                Result.LabelHits.Content = "нельзя попасть";
                Result.LabelAddHitCondInfo.Visibility = System.Windows.Visibility.Hidden;
                Result.LabelAddHitCondition.Visibility = System.Windows.Visibility.Hidden;
                //wounds
                Result.LabelWoundInfo.Visibility = System.Windows.Visibility.Hidden;
                Result.LabelWounds.Visibility = System.Windows.Visibility.Hidden;
                //saves
                Result.LabelSaveInfo.Visibility = System.Windows.Visibility.Hidden;
                Result.LabelSaves.Visibility = System.Windows.Visibility.Hidden;
                //groups
                Result.GroupHits.Visibility = System.Windows.Visibility.Hidden;
                Result.GroupWounds.Visibility = System.Windows.Visibility.Hidden;
                Result.GroupSaves.Visibility = System.Windows.Visibility.Hidden;
                return;
            }
            else
            {
                Result.LabelHits.Content = Hits.Hits.ToString();
                Result.LabelHitCondition.Content = Hits.Condition.ToString() + "+";

                Result.TextBlockHitCubes.Text = Hits.HitCubesStr;
                Result.TextBlockHitCubes.TextWrapping = TextWrapping.Wrap;
                if (Hits.AdditionalCondition <= 6)
                {
                    Result.LabelAddHitCondition.Content = Hits.AdditionalCondition.ToString() + "+";
                }
                else
                {
                    Result.LabelAddHitCondInfo.Visibility = System.Windows.Visibility.Hidden;
                    Result.LabelAddHitCondition.Visibility = System.Windows.Visibility.Hidden;
                }
            }

            //Wounds
            if ((Wounds == null) || (Wounds.Condition > 6))
            {
                //saves
                Result.LabelSaveInfo.Visibility = System.Windows.Visibility.Hidden;
                Result.LabelSaves.Visibility = System.Windows.Visibility.Hidden;
                //groups
                Result.GroupWounds.Visibility = System.Windows.Visibility.Hidden;
                Result.GroupSaves.Visibility = System.Windows.Visibility.Hidden;
            }

            if (Wounds == null)
            {
                //wounds
                Result.LabelWounds.Content = "не попал";
                return;
            }
            else if (Wounds.Condition > 6)
            {
                //wounds
                Result.LabelWounds.Content = "нельзя ранить";
                return;
            }
            else
            {
                Result.LabelWounds.Content = Wounds.Wounds.ToString();
                Result.LabelWoundCondition.Content = Wounds.Condition.ToString() + "+";

                Result.TextBlockWoundCubes.Text = Wounds.WoundCubesStr;
                Result.TextBlockWoundCubes.TextWrapping = TextWrapping.Wrap;
            }

            //Saves
            if ((Saves == null) || (Saves.Condition > 6))
            {
                //groups
                Result.GroupSaves.Visibility = System.Windows.Visibility.Hidden;
            }

            if (Saves == null)
            {
                //saves
                Result.LabelSaves.Content = "не ранил";
                return;
            }
            else if (Saves.Condition > 6)
            {
                //saves
                Result.LabelSaves.Content = "нельзя спасти";
                return;
            }
            else
            {
                Result.LabelSaves.Content = Saves.Saves.ToString();
                Result.LabelSaveCondition.Content = Saves.Condition.ToString() + "+";

                Result.TextBlockSaveCubes.Text = Saves.SaveCubesStr;
                Result.TextBlockSaveCubes.TextWrapping = TextWrapping.Wrap;
            }
            return;
        }

        //против техники
        void DisplayResult(CombatLib.Phases.PhaseHits.PhaseHitsVehicle Hits, CombatLib.Phases.PhaseWounds.PhaseWoundsVehicle Wounds = null, int S = -1, CombatLib.Phases.PhaseSaves.PhaseSavesVehicle Saves = null)
        {
            /*MessageBox.Show(Hits.ToString(), "Попадания", MessageBoxButton.OK);
            if (Wounds != null) MessageBox.Show(Wounds.ToString(), "Раны", MessageBoxButton.OK);
            if (Saves != null) MessageBox.Show(Saves.ToString(), "Спасброски", MessageBoxButton.OK);*/
            WindowResultVehicle Result = new WindowResultVehicle();
            Result.Show();

            if (Wounds == null)
                SetResultImg(ref Result, Hits.Hits);
            else 
                SetResultImg(ref Result, Hits.Hits, Wounds.Wounds);

            //Hits
            if (Hits.Condition > 6)
            {
                //hits
                Result.LabelHits.Content = "нельзя попасть";
                Result.LabelAddHitCondInfo.Visibility = System.Windows.Visibility.Hidden;
                Result.LabelAddHitCondition.Visibility = System.Windows.Visibility.Hidden;
                //wounds
                Result.LabelPunchedWoundsInfo.Visibility = System.Windows.Visibility.Hidden;
                Result.LabelPunchedWounds.Visibility = System.Windows.Visibility.Hidden;
                Result.LabelSlidingWoundsInfo.Visibility = System.Windows.Visibility.Hidden;
                Result.LabelSlidingWounds.Visibility = System.Windows.Visibility.Hidden;
                Result.LabelStrengthInfo.Visibility = System.Windows.Visibility.Hidden;
                Result.LabelStrength.Visibility = System.Windows.Visibility.Hidden;
                //saves
                Result.LabelSaveInfo.Visibility = System.Windows.Visibility.Hidden;
                Result.LabelSaves.Visibility = System.Windows.Visibility.Hidden;
                //groups
                Result.GroupHits.Visibility = System.Windows.Visibility.Hidden;
                Result.GroupWounds.Visibility = System.Windows.Visibility.Hidden;
                Result.GroupSaves.Visibility = System.Windows.Visibility.Hidden;
                return;
            }
            else
            {
                Result.LabelHits.Content = Hits.Hits.ToString();
                Result.LabelHitCondition.Content = Hits.Condition.ToString() + "+";

                Result.TextBlockHitCubes.Text = Hits.HitCubesStr;
                Result.TextBlockHitCubes.TextWrapping = TextWrapping.Wrap;
                if (Hits.AdditionalCondition <= 6)
                {
                    Result.LabelAddHitCondition.Content = Hits.AdditionalCondition.ToString() + "+";
                }
                else
                {
                    Result.LabelAddHitCondInfo.Visibility = System.Windows.Visibility.Hidden;
                    Result.LabelAddHitCondition.Visibility = System.Windows.Visibility.Hidden;
                }
            }

            //Wounds
            if ((Wounds == null) || (Wounds.Condition > 14))
            {
                //wounds
                Result.LabelPunchedWoundsInfo.Visibility = System.Windows.Visibility.Hidden;
                Result.LabelPunchedWounds.Visibility = System.Windows.Visibility.Hidden;
                Result.LabelSlidingWoundsInfo.Visibility = System.Windows.Visibility.Hidden;
                Result.LabelSlidingWounds.Visibility = System.Windows.Visibility.Hidden;
                Result.LabelStrengthInfo.Visibility = System.Windows.Visibility.Hidden;
                Result.LabelStrength.Visibility = System.Windows.Visibility.Hidden;
                //saves
                Result.LabelSaveInfo.Visibility = System.Windows.Visibility.Hidden;
                Result.LabelSaves.Visibility = System.Windows.Visibility.Hidden;
                //groups
                Result.GroupWounds.Visibility = System.Windows.Visibility.Hidden;
                Result.GroupSaves.Visibility = System.Windows.Visibility.Hidden;
            }

            if (Wounds == null)
            {
                //wounds
                Result.LabelWoundsInfo.Content = "не попал";
                return;
            }
            else if (Wounds.Condition > 14)
            {
                //wounds
                Result.LabelWoundsInfo.Content = "нельзя ранить";
                return;
            }
            else
            {
                Result.LabelPunchedWounds.Content = Wounds.PunchedWounds.ToString();
                Result.LabelSlidingWounds.Content = Wounds.SlidingWounds.ToString();
                Result.LabelWoundCondition.Content = Wounds.Condition.ToString() + "+";

                Result.TextBlockWoundCubes.Text = Wounds.WoundCubesStr;
                Result.TextBlockWoundCubes.TextWrapping = TextWrapping.Wrap;

                Result.LabelStrength.Content = S.ToString();
            }

            //Saves

            if ((Saves == null) && (Wounds.Wounds != 0))
            {
                //saves
                Result.LabelSaveInfo.Visibility = System.Windows.Visibility.Hidden;
                Result.LabelSaves.Visibility = System.Windows.Visibility.Hidden;
                //groups
                Result.GroupSaves.Visibility = System.Windows.Visibility.Hidden;
                return;
            }

            if ((Saves == null) || (Saves.Condition > 6))
            {
                //groups
                Result.GroupSaves.Visibility = System.Windows.Visibility.Hidden;
            }

            if (Saves == null)
            {
                //saves
                Result.LabelSaves.Content = "не ранил";
                return;
            }
            else if (Saves.Condition > 6)
            {
                //saves
                Result.LabelSaves.Content = "нельзя спасти";
                return;
            }
            else
            {
                Result.LabelSaves.Content = Saves.Saves.ToString();
                Result.LabelSaveCondition.Content = Saves.Condition.ToString() + "+";

                Result.TextBlockSaveCubes.Text = Saves.SaveCubesStr;
                Result.TextBlockSaveCubes.TextWrapping = TextWrapping.Wrap;
            }
            return;
        }

//У С Т А Н О В К А   И З О Б Р А Ж Е Н И Й

        private void SetResultImg(ref WindowResultInfantry Result, int hits, int wounds = 0)
        {
            if (wounds * 4 <= hits)
            {
                Result.ImageBattleResult.Source = new BitmapImage(new Uri("Lose.png", UriKind.Relative));
            }
            else if (wounds * 3 <= hits)
            {
                Result.ImageBattleResult.Source = new BitmapImage(new Uri("Mid.png", UriKind.Relative));
            }
            else
            {
                Result.ImageBattleResult.Source = new BitmapImage(new Uri("Win.png", UriKind.Relative));
            }
        }

        private void SetResultImg(ref WindowResultVehicle Result, int hits, int wounds = 0)
        {
            if (wounds * 4 <= hits)
            {
                Result.ImageBattleResult.Source = new BitmapImage(new Uri("Lose.png", UriKind.Relative));
            }
            else if (wounds * 3 <= hits)
            {
                Result.ImageBattleResult.Source = new BitmapImage(new Uri("Mid.png", UriKind.Relative));
            }
            else
            {
                Result.ImageBattleResult.Source = new BitmapImage(new Uri("Win.png", UriKind.Relative));
            }
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
