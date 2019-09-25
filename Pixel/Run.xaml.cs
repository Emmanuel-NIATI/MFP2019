using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using DisplayFont;
// Pour plus d'informations sur le modèle d'élément Page vierge, consultez la page https://go.microsoft.com/fwlink/?LinkId=234238

namespace Pixel
{
    /// <summary>
    /// Une page vide peut être utilisée seule ou constituer une page de destination au sein d'un frame.
    /// </summary>
    public sealed partial class Run : Page
    {

        private UInt16 Order = 0;

        private FontCharacterDescriptor fcd;

        private bool isPlaying;

        private Brush SCB_Color;

        private Brush SCB_White = new SolidColorBrush(Windows.UI.Color.FromArgb(255, 255, 255, 255));
        private Brush SCB_Black = new SolidColorBrush(Windows.UI.Color.FromArgb(255, 0, 0, 0));
        private Brush SCB_Grey = new SolidColorBrush(Windows.UI.Color.FromArgb(255, 127, 127, 127));
        private Brush SCB_Red = new SolidColorBrush(Windows.UI.Color.FromArgb(255, 255, 0, 0));
        private Brush SCB_Green = new SolidColorBrush(Windows.UI.Color.FromArgb(255, 0, 255, 0));
        private Brush SCB_Blue = new SolidColorBrush(Windows.UI.Color.FromArgb(255, 0, 0, 255));


        public Run()
        {

            this.InitializeComponent();

        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {

            // Choix de la couleur

            SCB_Color = SCB_Red;

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

            // rp2 : Liste des boutons

            btnRewind.Background = SCB_White;
            btnRewind.BorderBrush = SCB_Black;
			
            btnPrevious.Background = SCB_White;
            btnPrevious.BorderBrush = SCB_Black;

            btnPlay.Background = SCB_White;
            btnPlay.BorderBrush = SCB_Black;

            btnNext.Background = SCB_White;
            btnNext.BorderBrush = SCB_Black;

            btnFastForward.Background = SCB_White;
            btnFastForward.BorderBrush = SCB_Black;

            //

            fcd = DisplayFontTable.GetFontCharacterDescriptorFromFontTableStandart(Order);

            FontCharacterDescriptorToScreen(fcd);

            //

            isPlaying = false;

        }

        private void BtnRewind_Click(object sender, RoutedEventArgs e)
        {

            Order = 0;
            fcd = DisplayFontTable.GetFontCharacterDescriptorFromFontTableStandart(Order);
            FontCharacterDescriptorToScreen(fcd);

        }

        private void BtnPrevious_Click(object sender, RoutedEventArgs e)
        {

            if (Order > 0)
            {

                Order = (UInt16)(Order - 1);
            }
            else
            {

                Order = 255;
            }

            fcd = DisplayFontTable.GetFontCharacterDescriptorFromFontTableStandart(Order);
            FontCharacterDescriptorToScreen(fcd);

        }

        async private void BtnPlay_Click(object sender, RoutedEventArgs e)
        {

            isPlaying = !isPlaying;

            if (isPlaying)
            {

                btnPlay.Content = "\xE769";

                while (Order < (UInt16)(DisplayFontTable.GetFontTableStandartSize() - 1) && isPlaying)
                {

                    Order = (UInt16)(Order + 1);

                    fcd = DisplayFontTable.GetFontCharacterDescriptorFromFontTableStandart(Order);
                    FontCharacterDescriptorToScreen(fcd);

                    await Task.Delay(500);
                }

            }
            else
            {

                btnPlay.Content = "\xE768";

            }

        }

        private void BtnNext_Click(object sender, RoutedEventArgs e)
        {

            if (Order < (UInt16)(DisplayFontTable.GetFontTableStandartSize() - 1))
            {

                Order = (UInt16)(Order + 1);
            }
            else
            {

                Order = 0;
            }

            fcd = DisplayFontTable.GetFontCharacterDescriptorFromFontTableStandart(Order);
            FontCharacterDescriptorToScreen(fcd);

        }

        private void BtnFastForward_Click(object sender, RoutedEventArgs e)
        {

            Order = (UInt16)(DisplayFontTable.GetFontTableStandartSize() - 1);
            fcd = DisplayFontTable.GetFontCharacterDescriptorFromFontTableStandart(Order);
            FontCharacterDescriptorToScreen(fcd);

        }

        private void FontCharacterDescriptorToScreen(FontCharacterDescriptor fcd)
        {

            // 

            String _order = fcd.Order.ToString();

            String _c = fcd.Character.ToString();

            String _h1 = fcd.Data[0].ToString("X");
            if (_h1.Length == 1) { _h1 = "0" + _h1; }

            String _h11 = _h1.Substring(0, 1);
            bool[] _b11 = Convert.ConvertHexToBin(_h11);
            if (_b11[0]) { btn04.BorderBrush = SCB_Black; btn04.Background = SCB_Color; } else { btn04.BorderBrush = SCB_Black; btn04.Background = SCB_White; }
            if (_b11[1]) { btn05.BorderBrush = SCB_Black; btn05.Background = SCB_Color; } else { btn05.BorderBrush = SCB_Black; btn05.Background = SCB_White; }
            if (_b11[2]) { btn06.BorderBrush = SCB_Black; btn06.Background = SCB_Color; } else { btn06.BorderBrush = SCB_Black; btn06.Background = SCB_White; }
            if (_b11[3]) { btn07.BorderBrush = SCB_Black; btn07.Background = SCB_Color; } else { btn07.BorderBrush = SCB_Black; btn07.Background = SCB_Grey; }

            String _h01 = _h1.Substring(1, 1);
            bool[] _b01 = Convert.ConvertHexToBin(_h01);
            if (_b01[0]) { btn00.BorderBrush = SCB_Black; btn00.Background = SCB_Color; } else { btn00.BorderBrush = SCB_Black; btn00.Background = SCB_White; }
            if (_b01[1]) { btn01.BorderBrush = SCB_Black; btn01.Background = SCB_Color; } else { btn01.BorderBrush = SCB_Black; btn01.Background = SCB_White; }
            if (_b01[2]) { btn02.BorderBrush = SCB_Black; btn02.Background = SCB_Color; } else { btn02.BorderBrush = SCB_Black; btn02.Background = SCB_White; }
            if (_b01[3]) { btn03.BorderBrush = SCB_Black; btn03.Background = SCB_Color; } else { btn03.BorderBrush = SCB_Black; btn03.Background = SCB_White; }

            String _h2 = fcd.Data[1].ToString("X");
            if (_h2.Length == 1) { _h2 = "0" + _h2; }

            String _h12 = _h2.Substring(0, 1);
            bool[] _b12 = Convert.ConvertHexToBin(_h12);
            if (_b12[0]) { btn14.BorderBrush = SCB_Black; btn14.Background = SCB_Color; } else { btn14.BorderBrush = SCB_Black; btn14.Background = SCB_White; }
            if (_b12[1]) { btn15.BorderBrush = SCB_Black; btn15.Background = SCB_Color; } else { btn15.BorderBrush = SCB_Black; btn15.Background = SCB_White; }
            if (_b12[2]) { btn16.BorderBrush = SCB_Black; btn16.Background = SCB_Color; } else { btn16.BorderBrush = SCB_Black; btn16.Background = SCB_White; }
            if (_b12[3]) { btn17.BorderBrush = SCB_Black; btn17.Background = SCB_Color; } else { btn17.BorderBrush = SCB_Black; btn17.Background = SCB_Grey; }

            String _h02 = _h2.Substring(1, 1);
            bool[] _b02 = Convert.ConvertHexToBin(_h02);
            if (_b02[0]) { btn10.BorderBrush = SCB_Black; btn10.Background = SCB_Color; } else { btn10.BorderBrush = SCB_Black; btn10.Background = SCB_White; }
            if (_b02[1]) { btn11.BorderBrush = SCB_Black; btn11.Background = SCB_Color; } else { btn11.BorderBrush = SCB_Black; btn11.Background = SCB_White; }
            if (_b02[2]) { btn12.BorderBrush = SCB_Black; btn12.Background = SCB_Color; } else { btn12.BorderBrush = SCB_Black; btn12.Background = SCB_White; }
            if (_b02[3]) { btn13.BorderBrush = SCB_Black; btn13.Background = SCB_Color; } else { btn13.BorderBrush = SCB_Black; btn13.Background = SCB_White; }
			
            String _h3 = fcd.Data[2].ToString("X");
            if (_h3.Length == 1) { _h3 = "0" + _h3; }

            String _h13 = _h3.Substring(0, 1);
            bool[] _b13 = Convert.ConvertHexToBin(_h13);
            if (_b13[0]) { btn24.BorderBrush = SCB_Black; btn24.Background = SCB_Color; } else { btn24.BorderBrush = SCB_Black; btn24.Background = SCB_White; }
            if (_b13[1]) { btn25.BorderBrush = SCB_Black; btn25.Background = SCB_Color; } else { btn25.BorderBrush = SCB_Black; btn25.Background = SCB_White; }
            if (_b13[2]) { btn26.BorderBrush = SCB_Black; btn26.Background = SCB_Color; } else { btn26.BorderBrush = SCB_Black; btn26.Background = SCB_White; }
            if (_b13[3]) { btn27.BorderBrush = SCB_Black; btn27.Background = SCB_Color; } else { btn27.BorderBrush = SCB_Black; btn27.Background = SCB_Grey; }

            String _h03 = _h3.Substring(1, 1);
            bool[] _b03 = Convert.ConvertHexToBin(_h03);
            if (_b03[0]) { btn20.BorderBrush = SCB_Black; btn20.Background = SCB_Color; } else { btn20.BorderBrush = SCB_Black; btn20.Background = SCB_White; }
            if (_b03[1]) { btn21.BorderBrush = SCB_Black; btn21.Background = SCB_Color; } else { btn21.BorderBrush = SCB_Black; btn21.Background = SCB_White; }
            if (_b03[2]) { btn22.BorderBrush = SCB_Black; btn22.Background = SCB_Color; } else { btn22.BorderBrush = SCB_Black; btn22.Background = SCB_White; }
            if (_b03[3]) { btn23.BorderBrush = SCB_Black; btn23.Background = SCB_Color; } else { btn23.BorderBrush = SCB_Black; btn23.Background = SCB_White; }

            String _h4 = fcd.Data[3].ToString("X");
            if (_h4.Length == 1) { _h4 = "0" + _h4; }

            String _h14 = _h4.Substring(0, 1);
            bool[] _b14 = Convert.ConvertHexToBin(_h14);
            if (_b14[0]) { btn34.BorderBrush = SCB_Black; btn34.Background = SCB_Color; } else { btn34.BorderBrush = SCB_Black; btn34.Background = SCB_White; }
            if (_b14[1]) { btn35.BorderBrush = SCB_Black; btn35.Background = SCB_Color; } else { btn35.BorderBrush = SCB_Black; btn35.Background = SCB_White; }
            if (_b14[2]) { btn36.BorderBrush = SCB_Black; btn36.Background = SCB_Color; } else { btn36.BorderBrush = SCB_Black; btn36.Background = SCB_White; }
            if (_b11[3]) { btn37.BorderBrush = SCB_Black; btn37.Background = SCB_Color; } else { btn37.BorderBrush = SCB_Black; btn37.Background = SCB_Grey; }

        String _h04 = _h4.Substring(1, 1);
            bool[] _b04 = Convert.ConvertHexToBin(_h04);
            if (_b04[0]) { btn30.BorderBrush = SCB_Black; btn30.Background = SCB_Color; } else { btn30.BorderBrush = SCB_Black; btn30.Background = SCB_White; }
            if (_b04[1]) { btn31.BorderBrush = SCB_Black; btn31.Background = SCB_Color; } else { btn31.BorderBrush = SCB_Black; btn31.Background = SCB_White; }
            if (_b04[2]) { btn32.BorderBrush = SCB_Black; btn32.Background = SCB_Color; } else { btn32.BorderBrush = SCB_Black; btn32.Background = SCB_White; }
            if (_b04[3]) { btn33.BorderBrush = SCB_Black; btn33.Background = SCB_Color; } else { btn33.BorderBrush = SCB_Black; btn33.Background = SCB_White; }

            String _h5 = fcd.Data[4].ToString("X");
            if (_h5.Length == 1) { _h5 = "0" + _h5; }

            String _h15 = _h5.Substring(0, 1);
            bool[] _b15 = Convert.ConvertHexToBin(_h15);
            if (_b15[0]) { btn44.BorderBrush = SCB_Black; btn44.Background = SCB_Color; } else { btn44.BorderBrush = SCB_Black; btn44.Background = SCB_White; }
            if (_b15[1]) { btn45.BorderBrush = SCB_Black; btn45.Background = SCB_Color; } else { btn45.BorderBrush = SCB_Black; btn45.Background = SCB_White; }
            if (_b15[2]) { btn46.BorderBrush = SCB_Black; btn46.Background = SCB_Color; } else { btn46.BorderBrush = SCB_Black; btn46.Background = SCB_White; }
            if (_b15[3]) { btn47.BorderBrush = SCB_Black; btn47.Background = SCB_Color; } else { btn47.BorderBrush = SCB_Black; btn47.Background = SCB_Grey; }

            String _h05 = _h5.Substring(1, 1);
            bool[] _b05 = Convert.ConvertHexToBin(_h05);
            if (_b05[0]) { btn40.BorderBrush = SCB_Black; btn40.Background = SCB_Color; } else { btn40.BorderBrush = SCB_Black; btn40.Background = SCB_White; }
            if (_b05[1]) { btn41.BorderBrush = SCB_Black; btn41.Background = SCB_Color; } else { btn41.BorderBrush = SCB_Black; btn41.Background = SCB_White; }
            if (_b05[2]) { btn42.BorderBrush = SCB_Black; btn42.Background = SCB_Color; } else { btn42.BorderBrush = SCB_Black; btn42.Background = SCB_White; }
            if (_b05[3]) { btn43.BorderBrush = SCB_Black; btn43.Background = SCB_Color; } else { btn43.BorderBrush = SCB_Black; btn43.Background = SCB_White; }

            String _d = fcd.Description;

            //

            TB_CHAR.Text = _c;

            if (_order.Length == 1) { _order = "00" + _order; }
            if (_order.Length == 2) { _order = "0" + _order; }

            TB_ORDER.Text = _order;

            TB_H1.Text = "0x" + _h1;
            TB_H2.Text = "0x" + _h2;
            TB_H3.Text = "0x" + _h3;
            TB_H4.Text = "0x" + _h4;
            TB_H5.Text = "0x" + _h5;

            TB_D.Text = _d;

        }

    }

}
