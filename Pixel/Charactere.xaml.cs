using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
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
    public sealed partial class Charactere : Page
    {

        private Brush SCB_Color;

        private Brush SCB_White;
        private Brush SCB_Black;
        private Brush SCB_Grey;
        private Brush SCB_Red;
        private Brush SCB_Green;
        private Brush SCB_Blue;

        private bool b47;
        private bool b46;
        private bool b45;
        private bool b44;
        private bool b43;
        private bool b42;
        private bool b41;
        private bool b40;

        private bool b37;
        private bool b36;
        private bool b35;
        private bool b34;
        private bool b33;
        private bool b32;
        private bool b31;
        private bool b30;

        private bool b27;
        private bool b26;
        private bool b25;
        private bool b24;
        private bool b23;
        private bool b22;
        private bool b21;
        private bool b20;

        private bool b17;
        private bool b16;
        private bool b15;
        private bool b14;
        private bool b13;
        private bool b12;
        private bool b11;
        private bool b10;

        private bool b07;
        private bool b06;
        private bool b05;
        private bool b04;
        private bool b03;
        private bool b02;
        private bool b01;
        private bool b00;
 
        public Charactere()
        {

            this.InitializeComponent();

        }

        private void initialiser()
        {

            // Gestion des couleurs

            SCB_White = new SolidColorBrush(Windows.UI.Color.FromArgb(255, 255, 255, 255));
            SCB_Black = new SolidColorBrush(Windows.UI.Color.FromArgb(255, 0, 0, 0));
            SCB_Grey = new SolidColorBrush(Windows.UI.Color.FromArgb(255, 127, 127, 127));
            SCB_Red = new SolidColorBrush(Windows.UI.Color.FromArgb(255, 255, 0, 0));
            SCB_Green = new SolidColorBrush(Windows.UI.Color.FromArgb(255, 0, 255, 0));
            SCB_Blue = new SolidColorBrush(Windows.UI.Color.FromArgb(255, 0, 0, 255));

            SCB_Color = SCB_Red;

            // Gestion des variables

            b47 = false;
            b46 = false;
            b45 = false;
            b44 = false;
            b43 = false;
            b42 = false;
            b41 = false;
            b40 = false;

            b37 = false;
            b36 = false;
            b35 = false;
            b34 = false;
            b33 = false;
            b32 = false;
            b31 = false;
            b30 = false;

            b27 = false;
            b26 = false;
            b25 = false;
            b24 = false;
            b23 = false;
            b22 = false;
            b21 = false;
            b20 = false;

            b17 = false;
            b16 = false;
            b15 = false;
            b14 = false;
            b13 = false;
            b12 = false;
            b11 = false;
            b10 = false;

            b07 = false;
            b06 = false;
            b05 = false;
            b04 = false;
            b03 = false;
            b02 = false;
            b01 = false;
            b00 = false;

            // rp1 : Liste des boutons

            Button btn;

            for (int d = 0; d < 6; d++)
            {

                for (int u = 0; u < 8; u++)
                {

                    btn = (Button)rp1.FindName("btn" + d + u);

                    btn.Background = SCB_White;
                    btn.BorderBrush = SCB_Black;

                    if (d == 5 || u == 7)
                    {

                        btn.Background = SCB_Grey;
                        btn.BorderBrush = SCB_Black;
                    }

                }

            }

            for (int d = 0; d < 5; d++)
            {

                for (int u = 0; u < 8; u++)
                {

                    btn = (Button)rp1.FindName("affb" + d + u);

                    btn.Content = "0";
                    btn.Background = SCB_White;
                    btn.BorderBrush = SCB_Black;

                    if (u == 7)
                    {

                        btn.Background = SCB_Grey;
                        btn.BorderBrush = SCB_Black;
                    }

                }

            }

            affh01.Content = "0"; affh01.Background = SCB_White; affh01.BorderBrush = SCB_Black;
            affh00.Content = "0"; affh00.Background = SCB_White; affh00.BorderBrush = SCB_Black;
            affh11.Content = "0"; affh11.Background = SCB_White; affh11.BorderBrush = SCB_Black;
            affh10.Content = "0"; affh10.Background = SCB_White; affh10.BorderBrush = SCB_Black;
            affh21.Content = "0"; affh21.Background = SCB_White; affh21.BorderBrush = SCB_Black;
            affh20.Content = "0"; affh20.Background = SCB_White; affh20.BorderBrush = SCB_Black;
            affh31.Content = "0"; affh31.Background = SCB_White; affh31.BorderBrush = SCB_Black;
            affh30.Content = "0"; affh30.Background = SCB_White; affh30.BorderBrush = SCB_Black;
            affh41.Content = "0"; affh41.Background = SCB_White; affh41.BorderBrush = SCB_Black;
            affh40.Content = "0"; affh40.Background = SCB_White; affh40.BorderBrush = SCB_Black;

        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {

            this.initialiser();

        }

        private void afficher()
        {

            if (b47) { btn47.Background = SCB_Color; btn47.BorderBrush = SCB_Black; } else { btn47.Background = SCB_Grey; btn47.BorderBrush = SCB_Black; }
            if (b46) { btn46.Background = SCB_Color; btn46.BorderBrush = SCB_Black; } else { btn46.Background = SCB_White; btn46.BorderBrush = SCB_Black; }
            if (b45) { btn45.Background = SCB_Color; btn45.BorderBrush = SCB_Black; } else { btn45.Background = SCB_White; btn45.BorderBrush = SCB_Black; }
            if (b44) { btn44.Background = SCB_Color; btn44.BorderBrush = SCB_Black; } else { btn44.Background = SCB_White; btn44.BorderBrush = SCB_Black; }
            if (b43) { btn43.Background = SCB_Color; btn43.BorderBrush = SCB_Black; } else { btn43.Background = SCB_White; btn43.BorderBrush = SCB_Black; }
            if (b42) { btn42.Background = SCB_Color; btn42.BorderBrush = SCB_Black; } else { btn42.Background = SCB_White; btn42.BorderBrush = SCB_Black; }
            if (b41) { btn41.Background = SCB_Color; btn41.BorderBrush = SCB_Black; } else { btn41.Background = SCB_White; btn41.BorderBrush = SCB_Black; }
            if (b40) { btn40.Background = SCB_Color; btn40.BorderBrush = SCB_Black; } else { btn40.Background = SCB_White; btn40.BorderBrush = SCB_Black; }

            if (b37) { btn37.Background = SCB_Color; btn37.BorderBrush = SCB_Black; } else { btn37.Background = SCB_Grey; btn37.BorderBrush = SCB_Black; }
            if (b36) { btn36.Background = SCB_Color; btn36.BorderBrush = SCB_Black; } else { btn36.Background = SCB_White; btn36.BorderBrush = SCB_Black; }
            if (b35) { btn35.Background = SCB_Color; btn35.BorderBrush = SCB_Black; } else { btn35.Background = SCB_White; btn35.BorderBrush = SCB_Black; }
            if (b34) { btn34.Background = SCB_Color; btn34.BorderBrush = SCB_Black; } else { btn34.Background = SCB_White; btn34.BorderBrush = SCB_Black; }
            if (b33) { btn33.Background = SCB_Color; btn33.BorderBrush = SCB_Black; } else { btn33.Background = SCB_White; btn33.BorderBrush = SCB_Black; }
            if (b32) { btn32.Background = SCB_Color; btn32.BorderBrush = SCB_Black; } else { btn32.Background = SCB_White; btn32.BorderBrush = SCB_Black; }
            if (b31) { btn31.Background = SCB_Color; btn31.BorderBrush = SCB_Black; } else { btn31.Background = SCB_White; btn31.BorderBrush = SCB_Black; }
            if (b30) { btn30.Background = SCB_Color; btn30.BorderBrush = SCB_Black; } else { btn30.Background = SCB_White; btn30.BorderBrush = SCB_Black; }

            if (b27) { btn27.Background = SCB_Color; btn27.BorderBrush = SCB_Black; } else { btn27.Background = SCB_Grey; btn27.BorderBrush = SCB_Black; }
            if (b26) { btn26.Background = SCB_Color; btn26.BorderBrush = SCB_Black; } else { btn26.Background = SCB_White; btn26.BorderBrush = SCB_Black; }
            if (b25) { btn25.Background = SCB_Color; btn25.BorderBrush = SCB_Black; } else { btn25.Background = SCB_White; btn25.BorderBrush = SCB_Black; }
            if (b24) { btn24.Background = SCB_Color; btn24.BorderBrush = SCB_Black; } else { btn24.Background = SCB_White; btn24.BorderBrush = SCB_Black; }
            if (b23) { btn23.Background = SCB_Color; btn23.BorderBrush = SCB_Black; } else { btn23.Background = SCB_White; btn23.BorderBrush = SCB_Black; }
            if (b22) { btn22.Background = SCB_Color; btn22.BorderBrush = SCB_Black; } else { btn22.Background = SCB_White; btn22.BorderBrush = SCB_Black; }
            if (b21) { btn21.Background = SCB_Color; btn21.BorderBrush = SCB_Black; } else { btn21.Background = SCB_White; btn21.BorderBrush = SCB_Black; }
            if (b20) { btn20.Background = SCB_Color; btn20.BorderBrush = SCB_Black; } else { btn20.Background = SCB_White; btn20.BorderBrush = SCB_Black; }

            if (b17) { btn17.Background = SCB_Color; btn17.BorderBrush = SCB_Black; } else { btn17.Background = SCB_Grey; btn17.BorderBrush = SCB_Black; }
            if (b16) { btn16.Background = SCB_Color; btn16.BorderBrush = SCB_Black; } else { btn16.Background = SCB_White; btn16.BorderBrush = SCB_Black; }
            if (b15) { btn15.Background = SCB_Color; btn15.BorderBrush = SCB_Black; } else { btn15.Background = SCB_White; btn15.BorderBrush = SCB_Black; }
            if (b14) { btn14.Background = SCB_Color; btn14.BorderBrush = SCB_Black; } else { btn14.Background = SCB_White; btn14.BorderBrush = SCB_Black; }
            if (b13) { btn13.Background = SCB_Color; btn13.BorderBrush = SCB_Black; } else { btn13.Background = SCB_White; btn13.BorderBrush = SCB_Black; }
            if (b12) { btn12.Background = SCB_Color; btn12.BorderBrush = SCB_Black; } else { btn12.Background = SCB_White; btn12.BorderBrush = SCB_Black; }
            if (b11) { btn11.Background = SCB_Color; btn11.BorderBrush = SCB_Black; } else { btn11.Background = SCB_White; btn11.BorderBrush = SCB_Black; }
            if (b10) { btn10.Background = SCB_Color; btn10.BorderBrush = SCB_Black; } else { btn10.Background = SCB_White; btn10.BorderBrush = SCB_Black; }

            if (b07) { btn07.Background = SCB_Color; btn07.BorderBrush = SCB_Black; } else { btn07.Background = SCB_Grey; btn07.BorderBrush = SCB_Black; }
            if (b06) { btn06.Background = SCB_Color; btn06.BorderBrush = SCB_Black; } else { btn06.Background = SCB_White; btn06.BorderBrush = SCB_Black; }
            if (b05) { btn05.Background = SCB_Color; btn05.BorderBrush = SCB_Black; } else { btn05.Background = SCB_White; btn05.BorderBrush = SCB_Black; }
            if (b04) { btn04.Background = SCB_Color; btn04.BorderBrush = SCB_Black; } else { btn04.Background = SCB_White; btn04.BorderBrush = SCB_Black; }
            if (b03) { btn03.Background = SCB_Color; btn03.BorderBrush = SCB_Black; } else { btn03.Background = SCB_White; btn03.BorderBrush = SCB_Black; }
            if (b02) { btn02.Background = SCB_Color; btn02.BorderBrush = SCB_Black; } else { btn02.Background = SCB_White; btn02.BorderBrush = SCB_Black; }
            if (b01) { btn01.Background = SCB_Color; btn01.BorderBrush = SCB_Black; } else { btn01.Background = SCB_White; btn01.BorderBrush = SCB_Black; }
            if (b00) { btn00.Background = SCB_Color; btn00.BorderBrush = SCB_Black; } else { btn00.Background = SCB_White; btn00.BorderBrush = SCB_Black; }

            if (b47) { affb47.Content = "1"; } else { affb47.Content = "0"; }
            if (b46) { affb46.Content = "1"; } else { affb46.Content = "0"; }
            if (b45) { affb45.Content = "1"; } else { affb45.Content = "0"; }
            if (b44) { affb44.Content = "1"; } else { affb44.Content = "0"; }
            if (b43) { affb43.Content = "1"; } else { affb43.Content = "0"; }
            if (b42) { affb42.Content = "1"; } else { affb42.Content = "0"; }
            if (b41) { affb41.Content = "1"; } else { affb41.Content = "0"; }
            if (b40) { affb40.Content = "1"; } else { affb40.Content = "0"; }

            if (b37) { affb37.Content = "1"; } else { affb37.Content = "0"; }
            if (b36) { affb36.Content = "1"; } else { affb36.Content = "0"; }
            if (b35) { affb35.Content = "1"; } else { affb35.Content = "0"; }
            if (b34) { affb34.Content = "1"; } else { affb34.Content = "0"; }
            if (b33) { affb33.Content = "1"; } else { affb33.Content = "0"; }
            if (b32) { affb32.Content = "1"; } else { affb32.Content = "0"; }
            if (b31) { affb31.Content = "1"; } else { affb31.Content = "0"; }
            if (b30) { affb30.Content = "1"; } else { affb30.Content = "0"; }

            if (b27) { affb27.Content = "1"; } else { affb27.Content = "0"; }
            if (b26) { affb26.Content = "1"; } else { affb26.Content = "0"; }
            if (b25) { affb25.Content = "1"; } else { affb25.Content = "0"; }
            if (b24) { affb24.Content = "1"; } else { affb24.Content = "0"; }
            if (b23) { affb23.Content = "1"; } else { affb23.Content = "0"; }
            if (b22) { affb22.Content = "1"; } else { affb22.Content = "0"; }
            if (b21) { affb21.Content = "1"; } else { affb21.Content = "0"; }
            if (b20) { affb20.Content = "1"; } else { affb20.Content = "0"; }

            if (b17) { affb17.Content = "1"; } else { affb17.Content = "0"; }
            if (b16) { affb16.Content = "1"; } else { affb16.Content = "0"; }
            if (b15) { affb15.Content = "1"; } else { affb15.Content = "0"; }
            if (b14) { affb14.Content = "1"; } else { affb14.Content = "0"; }
            if (b13) { affb13.Content = "1"; } else { affb13.Content = "0"; }
            if (b12) { affb12.Content = "1"; } else { affb12.Content = "0"; }
            if (b11) { affb11.Content = "1"; } else { affb11.Content = "0"; }
            if (b10) { affb10.Content = "1"; } else { affb10.Content = "0"; }

            if (b07) { affb07.Content = "1"; } else { affb07.Content = "0"; }
            if (b06) { affb06.Content = "1"; } else { affb06.Content = "0"; }
            if (b05) { affb05.Content = "1"; } else { affb05.Content = "0"; }
            if (b04) { affb04.Content = "1"; } else { affb04.Content = "0"; }
            if (b03) { affb03.Content = "1"; } else { affb03.Content = "0"; }
            if (b02) { affb02.Content = "1"; } else { affb02.Content = "0"; }
            if (b01) { affb01.Content = "1"; } else { affb01.Content = "0"; }
            if (b00) { affb00.Content = "1"; } else { affb00.Content = "0"; }

            affh01.Content = Convert.ConvertBinToHex(b07, b06, b05, b04);
            affh00.Content = Convert.ConvertBinToHex(b03, b02, b01, b00);

            affh11.Content = Convert.ConvertBinToHex(b17, b16, b15, b14);
            affh10.Content = Convert.ConvertBinToHex(b13, b12, b11, b10);

            affh21.Content = Convert.ConvertBinToHex(b27, b26, b25, b24);
            affh20.Content = Convert.ConvertBinToHex(b23, b22, b21, b20);

            affh31.Content = Convert.ConvertBinToHex(b37, b36, b35, b34);
            affh30.Content = Convert.ConvertBinToHex(b33, b32, b31, b30);

            affh41.Content = Convert.ConvertBinToHex(b47, b46, b45, b44);
            affh40.Content = Convert.ConvertBinToHex(b43, b42, b41, b40);
 
        }

        private void Btn47_Click(object sender, RoutedEventArgs e)
        {

            b47 = !b47;

            this.afficher();

        }

        private void Btn46_Click(object sender, RoutedEventArgs e)
        {

            b46 = !b46;

            this.afficher();

        }

        private void Btn45_Click(object sender, RoutedEventArgs e)
        {

            b45 = !b45;

            this.afficher();

        }

        private void Btn44_Click(object sender, RoutedEventArgs e)
        {

            b44 = !b44;

            this.afficher();

        }

        private void Btn43_Click(object sender, RoutedEventArgs e)
        {

            b43 = !b43;

            this.afficher();

        }

        private void Btn42_Click(object sender, RoutedEventArgs e)
        {

            b42 = !b42;

            this.afficher();

        }

        private void Btn41_Click(object sender, RoutedEventArgs e)
        {

            b41 = !b41;

            this.afficher();

        }

        private void Btn40_Click(object sender, RoutedEventArgs e)
        {

            b40 = !b40;

            this.afficher();

        }

        private void Btn37_Click(object sender, RoutedEventArgs e)
        {

            b37 = !b37;

            this.afficher();

        }

        private void Btn36_Click(object sender, RoutedEventArgs e)
        {

            b36 = !b36;

            this.afficher();

        }

        private void Btn35_Click(object sender, RoutedEventArgs e)
        {

            b35 = !b35;

            this.afficher();

        }

        private void Btn34_Click(object sender, RoutedEventArgs e)
        {

            b34 = !b34;

            this.afficher();

        }

        private void Btn33_Click(object sender, RoutedEventArgs e)
        {

            b33 = !b33;

            this.afficher();

        }

        private void Btn32_Click(object sender, RoutedEventArgs e)
        {

            b32 = !b32;

            this.afficher();

        }

        private void Btn31_Click(object sender, RoutedEventArgs e)
        {

            b31 = !b31;

            this.afficher();

        }

        private void Btn30_Click(object sender, RoutedEventArgs e)
        {

            b30 = !b30;

            this.afficher();

        }

        private void Btn27_Click(object sender, RoutedEventArgs e)
        {

            b27 = !b27;

            this.afficher();

        }

        private void Btn26_Click(object sender, RoutedEventArgs e)
        {

            b26 = !b26;

            this.afficher();

        }

        private void Btn25_Click(object sender, RoutedEventArgs e)
        {

            b25 = !b25;

            this.afficher();

        }

        private void Btn24_Click(object sender, RoutedEventArgs e)
        {

            b24 = !b24;

            this.afficher();

        }

        private void Btn23_Click(object sender, RoutedEventArgs e)
        {

            b23 = !b23;

            this.afficher();

        }

        private void Btn22_Click(object sender, RoutedEventArgs e)
        {

            b22 = !b22;

            this.afficher();

        }

        private void Btn21_Click(object sender, RoutedEventArgs e)
        {

            b21 = !b21;

            this.afficher();

        }

        private void Btn20_Click(object sender, RoutedEventArgs e)
        {

            b20 = !b20;

            this.afficher();

        }

        private void Btn17_Click(object sender, RoutedEventArgs e)
        {

            b17 = !b17;

            this.afficher();

        }

        private void Btn16_Click(object sender, RoutedEventArgs e)
        {

            b16 = !b16;

            this.afficher();

        }

        private void Btn15_Click(object sender, RoutedEventArgs e)
        {

            b15 = !b15;

            this.afficher();

        }

        private void Btn14_Click(object sender, RoutedEventArgs e)
        {

            b14 = !b14;

            this.afficher();

        }

        private void Btn13_Click(object sender, RoutedEventArgs e)
        {

            b13 = !b13;

            this.afficher();

        }

        private void Btn12_Click(object sender, RoutedEventArgs e)
        {

            b12 = !b12;

            this.afficher();

        }

        private void Btn11_Click(object sender, RoutedEventArgs e)
        {

            b11 = !b11;

            this.afficher();

        }

        private void Btn10_Click(object sender, RoutedEventArgs e)
        {

            b10 = !b10;

            this.afficher();

        }

        private void Btn07_Click(object sender, RoutedEventArgs e)
        {

            b07 = !b07;

            this.afficher();

        }

        private void Btn06_Click(object sender, RoutedEventArgs e)
        {

            b06 = !b06;

            this.afficher();

        }

        private void Btn05_Click(object sender, RoutedEventArgs e)
        {

            b05 = !b05;

            this.afficher();

        }

        private void Btn04_Click(object sender, RoutedEventArgs e)
        {

            b04 = !b04;

            this.afficher();

        }

        private void Btn03_Click(object sender, RoutedEventArgs e)
        {

            b03 = !b03;

            this.afficher();

        }

        private void Btn02_Click(object sender, RoutedEventArgs e)
        {

            b02 = !b02;

            this.afficher();

        }

        private void Btn01_Click(object sender, RoutedEventArgs e)
        {

            b01 = !b01;

            this.afficher();

        }

        private void Btn00_Click(object sender, RoutedEventArgs e)
        {

            b00 = !b00;

            this.afficher();

        }


        private void RAZ_Click(object sender, RoutedEventArgs e)
        {

            this.initialiser();

        }

        private void Red_Click(object sender, RoutedEventArgs e)
        {

            SCB_Color = SCB_Red;

            red.BorderBrush = SCB_Red;
            green.BorderBrush = SCB_Black;
            blue.BorderBrush = SCB_Black;

            this.afficher();

        }

        private void Green_Click(object sender, RoutedEventArgs e)
        {

            SCB_Color = SCB_Green;

            red.BorderBrush = SCB_Black;
            green.BorderBrush = SCB_Green;
            blue.BorderBrush = SCB_Black;

            this.afficher();

        }

        private void Blue_Click(object sender, RoutedEventArgs e)
        {

            SCB_Color = SCB_Blue;

            red.BorderBrush = SCB_Black;
            green.BorderBrush = SCB_Black;
            blue.BorderBrush = SCB_Blue;

            this.afficher();

        }

    }

}
