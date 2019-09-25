using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// Pour plus d'informations sur le modèle d'élément Page vierge, consultez la page https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Pixel
{
    /// <summary>
    /// Une page vide peut être utilisée seule ou constituer une page de destination au sein d'un frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {

        public MainPage()
        {

            this.InitializeComponent();

            MyFrame.Navigate(typeof(Run));

            RunCharactereListBoxItem.IsSelected = true;

        }

        private void HamburgerButton_Click(object sender, RoutedEventArgs e)
        {

            MySplitView.IsPaneOpen = !MySplitView.IsPaneOpen;
        }

        private void IconsListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            if (RunCharactereListBoxItem.IsSelected)
            {

                MyFrame.Navigate(typeof(Run));
            }
            else if (CharactereToHexadecimalListBoxItem.IsSelected)
            {

                MyFrame.Navigate(typeof(Charactere));
            }
            else if (HexadecimalToCharactereListBoxItem.IsSelected)
            {

                MyFrame.Navigate(typeof(Hexadecimal));

            }

        }

    }

}
