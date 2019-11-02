using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Devices.Enumeration;
using Windows.Devices.Spi;
using Windows.Devices.Gpio;
using Windows.Graphics.Imaging;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Media;
using Windows.Media.Core;
using Windows.Media.Playback;
using Windows.Media.SpeechSynthesis;
using Windows.Storage;
using Windows.Storage.Streams;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using System.Threading.Tasks;
using Windows.UI;
using Windows.UI.Xaml.Media.Imaging;
using LCDDisplayDriver;

// Pour plus d'informations sur le modèle d'élément Page vierge, consultez la page https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Horloge
{
    /// <summary>
    /// Une page vide peut être utilisée seule ou constituer une page de destination au sein d'un frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {

        // Variables liées aux librairies
        private static readonly ILI9341 _SpiDisplayDriver = new ILI9341();

        // Variables liées au GPIO
        private GpioController _gpc;

        private GpioPin _pin27;
        private GpioPin _pin05;
        private GpioPin _pin13;
        private GpioPin _pin19;
        private GpioPin _pin26;

        private GpioPin _pin21;

        // Variables liées à l'affichage LCD
        ushort[] maky = new ushort[80 * 80];
        ushort[] mfp2019 = new ushort[240 * 320];
        ushort[] reveil = new ushort[80 * 80];
        ushort[] rpi = new ushort[80 * 80];
        ushort[] win = new ushort[80 * 80];
        ushort[] win10iot = new ushort[240 * 320];

        int color = _SpiDisplayDriver.RGB888ToRGB565(226, 010, 023);

        String temps_heure = "10";
        String temps_minute = "50";
        String temps_seconde = "00";

        String date_sem = "lun";
        String date_jour = "10";
        String date_mois = "06";
        String date_annee = "2019";

        String reveil_heure = "06";
        String reveil_minute = "30";

        public MainPage()
        {

            this.InitializeComponent();

            // Initialisation des variables
            this.InitVariable();

            // Initialisation du GPIO
            this.InitGpio();

            // Initialisation de l'affichage LCD
            this.InitSpiDisplay();

            // Initialisation du Timer
            this.TravauxTimer();

        }


        private void InitVariable()
        {

            _SpiDisplayDriver.LoadFile(maky, 80, 80, "ms-appx:///MFP2019/maky.png");
            _SpiDisplayDriver.LoadFile(mfp2019, 240, 320, "ms-appx:///MFP2019/mfp2019.png");
            _SpiDisplayDriver.LoadFile(reveil, 80, 80, "ms-appx:///MFP2019/reveil.png");
            _SpiDisplayDriver.LoadFile(rpi, 80, 80, "ms-appx:///MFP2019/rpi.png");
            _SpiDisplayDriver.LoadFile(win, 80, 80, "ms-appx:///MFP2019/win.png");
            _SpiDisplayDriver.LoadFile(win10iot, 240, 320, "ms-appx:///MFP2019/win10iot.png");

        }

        private void InitGpio()
        {

            // Configuration du contrôleur du GPIO par défaut
            _gpc = GpioController.GetDefault();

            // Bouton Gris sur GPIO27 en entrée
            _pin27 = _gpc.OpenPin(27);
            _pin27.SetDriveMode(GpioPinDriveMode.InputPullDown);
            _pin27.DebounceTimeout = new TimeSpan(10000);

            // Bouton Blanc sur GPIO05 en entrée
            _pin05 = _gpc.OpenPin(5);
            _pin05.SetDriveMode(GpioPinDriveMode.InputPullDown);
            _pin05.DebounceTimeout = new TimeSpan(10000);

            // Bouton Vert sur GPIO13 en entrée
            _pin13 = _gpc.OpenPin(13);
            _pin13.SetDriveMode(GpioPinDriveMode.InputPullDown);
            _pin13.DebounceTimeout = new TimeSpan(10000);

            // Bouton Bleu sur GPIO19 en entrée
            _pin19 = _gpc.OpenPin(19);
            _pin19.SetDriveMode(GpioPinDriveMode.InputPullDown);
            _pin19.DebounceTimeout = new TimeSpan(10000);

            // Bouton Jaune sur GPIO26 en entrée
            _pin26 = _gpc.OpenPin(26);
            _pin26.SetDriveMode(GpioPinDriveMode.InputPullDown);
            _pin26.DebounceTimeout = new TimeSpan(10000);

            // Buzzer sur sur GPIO21 en sortie
            _pin21 = _gpc.OpenPin(21);
            _pin21.SetDriveMode(GpioPinDriveMode.Output);
            _pin21.Write(GpioPinValue.Low);

        }

        private async void InitSpiDisplay()
        {

            // Initialisation de l'affichage
            await _SpiDisplayDriver.PowerOnSequence();
            await _SpiDisplayDriver.Wakeup();

            // Effacer l'écran
            _SpiDisplayDriver.ClearScreen();

            // Dessin des images
            _SpiDisplayDriver.DrawPicture20(rpi, 80, 80, 0, 0);
            _SpiDisplayDriver.DrawPicture20(win, 80, 80, 80, 0);
            _SpiDisplayDriver.DrawPicture20(maky, 80, 80, 160, 0);
            _SpiDisplayDriver.DrawPicture20(reveil, 80, 80, 0, 220);

        }

        private void TravauxTimer()
        {

            // Configuration du Timer
            DispatcherTimer dispatcherTimer = new DispatcherTimer();
            dispatcherTimer.Tick += DispatcherTimer_Tick;
            dispatcherTimer.Interval = new TimeSpan(0, 0, 0, 0, 200);
            dispatcherTimer.Start();

        }

        private void DispatcherTimer_Tick(object sender, object e)
        {

            DateTime _DateTime = DateTime.Now;

            temps_heure = _DateTime.Hour.ToString();
            temps_minute = _DateTime.Minute.ToString();
            temps_seconde = _DateTime.Second.ToString();

            date_sem = _DateTime.DayOfWeek.ToString();
            date_jour = _DateTime.Day.ToString();
            date_mois = _DateTime.Month.ToString();
            date_annee = _DateTime.Year.ToString();

            DisplayTime();

        }

        private void DisplayTime()
        {

            // Affichage de l'heure
            _SpiDisplayDriver.PlaceCursor(0, 100);

            temps_heure = TwoChar(temps_heure);
            temps_minute = TwoChar(temps_minute);
            temps_seconde = TwoChar(temps_seconde);

            _SpiDisplayDriver.Print(temps_heure, 6, color);
            _SpiDisplayDriver.Print(":", 6, color);
            _SpiDisplayDriver.Print(temps_minute, 6, color);
            _SpiDisplayDriver.Print(":", 3, color);
            _SpiDisplayDriver.Print(temps_seconde, 3, color);

            // Affichage de la date 
            _SpiDisplayDriver.PlaceCursor(0, 160);

            date_sem = DayWeek(date_sem);
            date_jour = TwoChar(date_jour);
            date_mois = TwoChar(date_mois);
            date_annee = TwoChar(date_annee);

            _SpiDisplayDriver.Print(date_sem, 2, color);
            _SpiDisplayDriver.Print(" ", 3, color);
            _SpiDisplayDriver.Print(date_jour, 3, color);
            _SpiDisplayDriver.Print("/", 3, color);
            _SpiDisplayDriver.Print(date_mois, 3, color);
            _SpiDisplayDriver.Print("/", 3, color);
            _SpiDisplayDriver.Print(date_annee, 3, color);

            // Affichage du reveil
            _SpiDisplayDriver.PlaceCursor(100, 240);

            reveil_heure = TwoChar(reveil_heure);
            reveil_minute = TwoChar(reveil_minute);

            _SpiDisplayDriver.Print(reveil_heure, 4, color);
            _SpiDisplayDriver.Print(":", 4, color);
            _SpiDisplayDriver.Print(reveil_minute, 4, color);

        }

        private String TwoChar(string c)
        {

            if (c.Length < 2)
            {
                c = "0" + c;
            }

            return c;

        }

        private String DayWeek(string c)
        {

            if( c.Equals("Monday") )
            {

                c = "lun";
            }

            if (c.Equals("Tuesday"))
            {

                c = "mar";
            }

            if (c.Equals("Wednesday"))
            {

                c = "mer";
            }

            if (c.Equals("Thursday"))
            {

                c = "jeu";
            }

            if (c.Equals("Friday"))
            {

                c = "ven";
            }

            if (c.Equals("Saturday"))
            {

                c = "sam";
            }

            if (c.Equals("Sunday"))
            {

                c = "dim";
            }

            return c;

        }

        // Action sur les boutons
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {

            // Bouton Gris sur GPIO27
            _pin27.ValueChanged += _pin27_ValueChanged;
            // Bouton Blanc sur GPIO05
            _pin05.ValueChanged += _pin05_ValueChanged;
            // Bouton Vert sur GPIO13
            _pin13.ValueChanged += _pin13_ValueChanged;
            // Bouton Bleu sur GPIO19
            _pin19.ValueChanged += _pin19_ValueChanged;
            // Bouton Jaune sur GPIO26
            _pin26.ValueChanged += _pin26_ValueChanged;

        }

        // Bouton Gris
        private void _pin27_ValueChanged(GpioPin sender, GpioPinValueChangedEventArgs args)
        {

            // Détection du front montant
            if (args.Edge == GpioPinEdge.RisingEdge)
            {

                color = _SpiDisplayDriver.RGB888ToRGB565(127, 127, 127);
            }

        }

        // Bouton Blanc
        private void _pin05_ValueChanged(GpioPin sender, GpioPinValueChangedEventArgs args)
        {

            // Détection du front montant
            if (args.Edge == GpioPinEdge.RisingEdge)
            {

                color = _SpiDisplayDriver.RGB888ToRGB565(255, 255, 255);
            }

        }

        // Bouton Vert
        private void _pin13_ValueChanged(GpioPin sender, GpioPinValueChangedEventArgs args)
        {

            // Détection du front montant
            if (args.Edge == GpioPinEdge.RisingEdge)
            {

                color = _SpiDisplayDriver.RGB888ToRGB565(0, 255, 0);
            }

        }

        // Bouton Bleu
        private void _pin19_ValueChanged(GpioPin sender, GpioPinValueChangedEventArgs args)
        {

            // Détection du front montant
            if (args.Edge == GpioPinEdge.RisingEdge)
            {

                color = _SpiDisplayDriver.RGB888ToRGB565(0, 0, 255);
                
            }

        }

        // Bouton Jaune
        private void _pin26_ValueChanged(GpioPin sender, GpioPinValueChangedEventArgs args)
        {

            // Détection du front montant
            if (args.Edge == GpioPinEdge.RisingEdge)
            {

                color = _SpiDisplayDriver.RGB888ToRGB565(255, 255, 0);

            }

        }

    }

}
