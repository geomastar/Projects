using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Metal_Lynch__v3._0_
{
    public class WeaponSelector : GUIObject
    {
        private ComboBox weaponSelector_ComboBox;

        public WeaponSelector(Game weaponSelector_Game, int X, int Y)
        {
            game = weaponSelector_Game;

            weaponSelector_ComboBox = new ComboBox()
            {
                Width = 120,
                Height = 50,
                FontSize = 30,
                FontStyle = FontStyles.Italic,
                IsEditable = true,
                IsReadOnly = true,
                RenderTransform = new TranslateTransform(X, Y)                
            };

            foreach (string weaponName in Enum.GetNames(typeof(Game.Weapons)))
            {
                weaponSelector_ComboBox.Items.Add(new ComboBoxItem() { Content = weaponName });
            }

            weaponSelector_ComboBox.SelectedIndex = 0;

            weaponSelector_ComboBox.DropDownOpened += DropDownOpenedEvent;
            weaponSelector_ComboBox.DropDownClosed += DropDownClosedEvent;

            GUIMainElement = weaponSelector_ComboBox;

            AddToCanvas();
        }

        private void DropDownOpenedEvent(object sender, EventArgs e)
        {
            game.PlayClickForwardSound();
        }

        private void DropDownClosedEvent(object sender, EventArgs e)
        {
            game.PlayClickForwardSound();

            if (weaponSelector_ComboBox.SelectedItem != null)
            {
                game.SelectWeapon(
                    (Game.Weapons)Enum.Parse(typeof(Game.Weapons), Enum.GetNames(
                    typeof(Game.Weapons))[weaponSelector_ComboBox.SelectedIndex]));
            }
        }

        public void Enable()
        {
            weaponSelector_ComboBox.IsEnabled = true;
        }
        public void Disable()
        {
            weaponSelector_ComboBox.IsEnabled = false;
        }
        public void Toggle()
        {
            weaponSelector_ComboBox.IsEnabled = !weaponSelector_ComboBox.IsEnabled;
        }

        public bool GetWeaponSelector_IsEnabled()
        {
            return weaponSelector_ComboBox.IsEnabled;
        }

        public void SetWeaponSelector_SelectedWeapon(Game.Weapons weapon)
        {
            weaponSelector_ComboBox.SelectedIndex = Array.IndexOf(Enum.GetNames(typeof(Game.Weapons)), weapon.ToString());
        }
    }
}
