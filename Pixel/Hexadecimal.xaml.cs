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
    public sealed partial class Hexadecimal : Page
    {

        private Brush SCB_Color;

        private Brush SCB_White;
        private Brush SCB_Black;
        private Brush SCB_Grey;
        private Brush SCB_Red;
        private Brush SCB_Green;
        private Brush SCB_Blue;

        String btnSelected;

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
 
        public Hexadecimal()
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

            btnSelected = "BTN_AFFH01";

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

        }

        private void afficher()
        {

            if (btnSelected.Equals("BTN_AFFH01")) { affh01.BorderThickness = new Thickness(2.0); } else { affh01.BorderThickness = new Thickness(1.0); }
            if (btnSelected.Equals("BTN_AFFH00")) { affh00.BorderThickness = new Thickness(2.0); } else { affh00.BorderThickness = new Thickness(1.0); }
            if (btnSelected.Equals("BTN_AFFH11")) { affh11.BorderThickness = new Thickness(2.0); } else { affh11.BorderThickness = new Thickness(1.0); }
            if (btnSelected.Equals("BTN_AFFH10")) { affh10.BorderThickness = new Thickness(2.0); } else { affh10.BorderThickness = new Thickness(1.0); }
            if (btnSelected.Equals("BTN_AFFH21")) { affh21.BorderThickness = new Thickness(2.0); } else { affh21.BorderThickness = new Thickness(1.0); }
            if (btnSelected.Equals("BTN_AFFH20")) { affh20.BorderThickness = new Thickness(2.0); } else { affh20.BorderThickness = new Thickness(1.0); }
            if (btnSelected.Equals("BTN_AFFH31")) { affh31.BorderThickness = new Thickness(2.0); } else { affh31.BorderThickness = new Thickness(1.0); }
            if (btnSelected.Equals("BTN_AFFH30")) { affh30.BorderThickness = new Thickness(2.0); } else { affh30.BorderThickness = new Thickness(1.0); }
            if (btnSelected.Equals("BTN_AFFH41")) { affh41.BorderThickness = new Thickness(2.0); } else { affh41.BorderThickness = new Thickness(1.0); }
            if (btnSelected.Equals("BTN_AFFH40")) { affh40.BorderThickness = new Thickness(2.0); } else { affh40.BorderThickness = new Thickness(1.0); }

            bool[] b0H = Convert.ConvertHexToBin(affh01.Content.ToString());
            bool[] b0L = Convert.ConvertHexToBin(affh00.Content.ToString());

            bool[] b1H = Convert.ConvertHexToBin(affh11.Content.ToString());
            bool[] b1L = Convert.ConvertHexToBin(affh10.Content.ToString());

            bool[] b2H = Convert.ConvertHexToBin(affh21.Content.ToString());
            bool[] b2L = Convert.ConvertHexToBin(affh20.Content.ToString());

            bool[] b3H = Convert.ConvertHexToBin(affh31.Content.ToString());
            bool[] b3L = Convert.ConvertHexToBin(affh30.Content.ToString());

            bool[] b4H = Convert.ConvertHexToBin(affh41.Content.ToString());
            bool[] b4L = Convert.ConvertHexToBin(affh40.Content.ToString());

            b07 = b0H[3]; b06 = b0H[2]; b05 = b0H[1]; b04 = b0H[0];
            b03 = b0L[3]; b02 = b0L[2]; b01 = b0L[1]; b00 = b0L[0];

            b17 = b1H[3]; b16 = b1H[2]; b15 = b1H[1]; b14 = b1H[0];
            b13 = b1L[3]; b12 = b1L[2]; b11 = b1L[1]; b10 = b1L[0];

            b27 = b2H[3]; b26 = b2H[2]; b25 = b2H[1]; b24 = b2H[0];
            b23 = b2L[3]; b22 = b2L[2]; b21 = b2L[1]; b20 = b2L[0];

            b37 = b3H[3]; b36 = b3H[2]; b35 = b3H[1]; b34 = b3H[0];
            b33 = b3L[3]; b32 = b3L[2]; b31 = b3L[1]; b30 = b3L[0];

            b47 = b4H[3]; b46 = b4H[2]; b45 = b4H[1]; b44 = b4H[0];
            b43 = b4L[3]; b42 = b4L[2]; b41 = b4L[1]; b40 = b4L[0];

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

        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {

            this.initialiser();

            this.afficher();

        }

        private void Affh01_Click(object sender, RoutedEventArgs e)
        {

            btnSelected = "BTN_AFFH01";

            this.afficher();

        }

        private void Affh00_Click(object sender, RoutedEventArgs e)
        {

            btnSelected = "BTN_AFFH00";

            this.afficher();

        }

        private void Affh11_Click(object sender, RoutedEventArgs e)
        {

            btnSelected = "BTN_AFFH11";

            this.afficher();

        }

        private void Affh10_Click(object sender, RoutedEventArgs e)
        {

            btnSelected = "BTN_AFFH10";

            this.afficher();

        }

        private void Affh21_Click(object sender, RoutedEventArgs e)
        {

            btnSelected = "BTN_AFFH21";

            this.afficher();

        }

        private void Affh20_Click(object sender, RoutedEventArgs e)
        {

            btnSelected = "BTN_AFFH20";

            this.afficher();

        }

        private void Affh31_Click(object sender, RoutedEventArgs e)
        {

            btnSelected = "BTN_AFFH31";

            this.afficher();

        }

        private void Affh30_Click(object sender, RoutedEventArgs e)
        {

            btnSelected = "BTN_AFFH30";

            this.afficher();

        }

        private void Affh41_Click(object sender, RoutedEventArgs e)
        {

            btnSelected = "BTN_AFFH41";

            this.afficher();

        }

        private void Affh40_Click(object sender, RoutedEventArgs e)
        {

            btnSelected = "BTN_AFFH40";

            this.afficher();

        }

        private void RAZ_Click(object sender, RoutedEventArgs e)
        {

            this.initialiser();

            this.afficher();

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

        private void saisir(String message)
        {

            if (btnSelected.Equals("BTN_AFFH01")) { affh01.Content = message; btnSelected = "BTN_AFFH00"; }
            else if (btnSelected.Equals("BTN_AFFH00")) { affh00.Content = message; btnSelected = "BTN_AFFH11"; }
            else if (btnSelected.Equals("BTN_AFFH11")) { affh11.Content = message; btnSelected = "BTN_AFFH10"; }
            else if (btnSelected.Equals("BTN_AFFH10")) { affh10.Content = message; btnSelected = "BTN_AFFH21"; }
            else if (btnSelected.Equals("BTN_AFFH21")) { affh21.Content = message; btnSelected = "BTN_AFFH20"; }
            else if (btnSelected.Equals("BTN_AFFH20")) { affh20.Content = message; btnSelected = "BTN_AFFH31"; }
            else if (btnSelected.Equals("BTN_AFFH31")) { affh31.Content = message; btnSelected = "BTN_AFFH30"; }
            else if (btnSelected.Equals("BTN_AFFH30")) { affh30.Content = message; btnSelected = "BTN_AFFH41"; }
            else if (btnSelected.Equals("BTN_AFFH41")) { affh41.Content = message; btnSelected = "BTN_AFFH40"; }
            else if (btnSelected.Equals("BTN_AFFH40")) { affh40.Content = message; btnSelected = "BTN_AFFH01"; }

        }
 
        private void C0_Click(object sender, RoutedEventArgs e)
        {

            this.saisir("0");

            this.afficher();

        }

        private void C1_Click(object sender, RoutedEventArgs e)
        {

            this.saisir("1");

            this.afficher();

        }

        private void C2_Click(object sender, RoutedEventArgs e)
        {

            this.saisir("2");

            this.afficher();

        }

        private void C3_Click(object sender, RoutedEventArgs e)
        {

            this.saisir("3");

            this.afficher();


        }

        private void C4_Click(object sender, RoutedEventArgs e)
        {

            this.saisir("4");

            this.afficher();

        }

        private void C5_Click(object sender, RoutedEventArgs e)
        {

            this.saisir("5");

            this.afficher();

        }

        private void C6_Click(object sender, RoutedEventArgs e)
        {

            this.saisir("6");

            this.afficher();

        }

        private void C7_Click(object sender, RoutedEventArgs e)
        {

            this.saisir("7");

            this.afficher();

        }

        private void C8_Click(object sender, RoutedEventArgs e)
        {

            this.saisir("8");

            this.afficher();

        }

        private void C9_Click(object sender, RoutedEventArgs e)
        {

            this.saisir("9");

            this.afficher();

        }

        private void CA_Click(object sender, RoutedEventArgs e)
        {

            this.saisir("A");

            this.afficher();

        }

        private void CB_Click(object sender, RoutedEventArgs e)
        {

            this.saisir("B");

            this.afficher();

        }

        private void CC_Click(object sender, RoutedEventArgs e)
        {

            this.saisir("C");

            this.afficher();

        }

        private void CD_Click(object sender, RoutedEventArgs e)
        {

            this.saisir("D");

            this.afficher();

        }

        private void CE_Click(object sender, RoutedEventArgs e)
        {

            this.saisir("E");

            this.afficher();

        }

        private void CF_Click(object sender, RoutedEventArgs e)
        {

            this.saisir("F");

            this.afficher();

        }

    }

}
