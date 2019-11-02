using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Devices.Enumeration;
using Windows.Devices.Spi;
using Windows.Devices.Gpio;
using Windows.Graphics.Imaging;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.Storage.Streams;
using DisplayFont;
using Util;

namespace LCDDisplayDriver
{

    public class ILI9341
    {

        private const string SPI_CONTROLLER_NAME = "SPI0";              // For Raspberry Pi 2 & 3, use SPI0
        private const Int32 SPI_CHIP_SELECT_LINE = 0;                   // Line 0 maps to physical pin number 24 on the Raspberry Pi 2 & 3
        private const Int32 DATA_COMMAND_PIN = 22;                      // We use GPIO 22 since it's conveniently near the SPI
        private const Int32 RESET_PIN = 23;                             // We use GPIO 23 since it's conveniently near the SPI pins

        public const uint LCD_W = 240;                                  // SPI Display width
        public const uint LCD_H = 320;                                  // SPI Display height

        private const uint LINE_HEIGHT_08 = 08;
        private const uint LINE_HEIGHT_10 = 10;
        private const uint LINE_HEIGHT_20 = 20;
        private const uint LINE_HEIGHT_30 = 30;
        private const uint LINE_HEIGHT_32 = 32;

        private static readonly byte[] CMD_SLEEP_OUT = { 0x11 };
        private static readonly byte[] CMD_DISPLAY_ON = { 0x29 };
        private static readonly byte[] CMD_MEMORY_WRITE_MODE = { 0x2C };
        private static readonly byte[] CMD_DISPLAY_OFF = { 0x28 };
        private static readonly byte[] CMD_ENTER_SLEEP = { 0x10 };
        private static readonly byte[] CMD_COLUMN_ADDRESS_SET = { 0x2a };
        private static readonly byte[] CMD_PAGE_ADDRESS_SET = { 0x2b };
        private static readonly byte[] CMD_POWER_CONTROL_A = { 0xcb };
        private static readonly byte[] CMD_POWER_CONTROL_B = { 0xcf };
        private static readonly byte[] CMD_DRIVER_TIMING_CONTROL_A = { 0xe8 };
        private static readonly byte[] CMD_DRIVER_TIMING_CONTROL_B = { 0xea };
        private static readonly byte[] CMD_POWER_ON_SEQUENCE_CONTROL = { 0xed };
        private static readonly byte[] CMD_PUMP_RATIO_CONTROL = { 0xf7 };
        private static readonly byte[] CMD_POWER_CONTROL_1 = { 0xc0 };
        private static readonly byte[] CMD_POWER_CONTROL_2 = { 0xc1 };
        private static readonly byte[] CMD_VCOM_CONTROL_1 = { 0xc5 };
        private static readonly byte[] CMD_VCOM_CONTROL_2 = { 0xc7 };
        private static readonly byte[] CMD_MEMORY_ACCESS_CONTROL = { 0x36 };
        private static readonly byte[] CMD_PIXEL_FORMAT = { 0x3a };
        private static readonly byte[] CMD_FRAME_RATE_CONTROL = { 0xb1 };
        private static readonly byte[] CMD_DISPLAY_FUNCTION_CONTROL = { 0xb6 };
        private static readonly byte[] CMD_ENABLE_3G = { 0xf2 };
        private static readonly byte[] CMD_GAMMA_SET = { 0x26 };
        private static readonly byte[] CMD_POSITIVE_GAMMA_CORRECTION = { 0xe0 };
        private static readonly byte[] CMD_NEGATIVE_GAMMA_CORRECTION = { 0xe1 };

        private SpiDevice SpiDisplay;
        private GpioController IoController;
        private GpioPin DataCommandPin;
        private GpioPin ResetPin;

        public UInt16 cursorX;
        public UInt16 cursorY;

        public byte[] DisplayBuffer;

        ushort[] _lcd = new ushort[ LCD_W * LCD_H ];

        public struct Rectangle
        {

            public int XMin;
            public int XMax;
            public int YMin;
            public int YMax;

        }

        public struct Color
        {

            public int R;
            public int G;
            public int B;

        }

        private async Task InitHardware()
        {

            IoController = GpioController.GetDefault();
            DataCommandPin = IoController.OpenPin(DATA_COMMAND_PIN);
            DataCommandPin.Write(GpioPinValue.High);
            DataCommandPin.SetDriveMode(GpioPinDriveMode.Output);

            ResetPin = IoController.OpenPin(RESET_PIN);
            ResetPin.Write(GpioPinValue.High);
            ResetPin.SetDriveMode(GpioPinDriveMode.Output);

            var settings = new SpiConnectionSettings(SPI_CHIP_SELECT_LINE);
            settings.ClockFrequency = 10000000;
            settings.Mode = SpiMode.Mode3;
            string spiAqs = SpiDevice.GetDeviceSelector(SPI_CONTROLLER_NAME);
            var devicesInfo = await DeviceInformation.FindAllAsync(spiAqs);
            SpiDisplay = await SpiDevice.FromIdAsync(devicesInfo[0].Id, settings);

        }

        public async Task PowerOnSequence()
        {

            await InitHardware();
            await Task.Delay(5);
            ResetPin.Write(GpioPinValue.Low);
            await Task.Delay(5);
            ResetPin.Write(GpioPinValue.High);
            await Task.Delay(20);
            await Wakeup();

        }

        public async Task Wakeup()
        {

            DisplaySendCommand(CMD_SLEEP_OUT);
            await Task.Delay(60);

            DisplaySendCommand(CMD_POWER_CONTROL_A);
            DisplaySendData(new byte[] { 0x39, 0x2C, 0x00, 0x34, 0x02 });
            DisplaySendCommand(CMD_POWER_CONTROL_B);
            DisplaySendData(new byte[] { 0x00, 0xC1, 0x30 });
            DisplaySendCommand(CMD_DRIVER_TIMING_CONTROL_A);
            DisplaySendData(new byte[] { 0x85, 0x00, 0x78 });
            DisplaySendCommand(CMD_DRIVER_TIMING_CONTROL_B);
            DisplaySendData(new byte[] { 0x00, 0x00 });
            DisplaySendCommand(CMD_POWER_ON_SEQUENCE_CONTROL);
            DisplaySendData(new byte[] { 0x64, 0x03, 0x12, 0x81 });
            DisplaySendCommand(CMD_PUMP_RATIO_CONTROL);
            DisplaySendData(new byte[] { 0x20 });
            DisplaySendCommand(CMD_POWER_CONTROL_1);
            DisplaySendData(new byte[] { 0x23 });
            DisplaySendCommand(CMD_POWER_CONTROL_2);
            DisplaySendData(new byte[] { 0x10 });
            DisplaySendCommand(CMD_VCOM_CONTROL_1);
            DisplaySendData(new byte[] { 0x3e, 0x28 });
            DisplaySendCommand(CMD_VCOM_CONTROL_2);
            DisplaySendData(new byte[] { 0x86 });
            DisplaySendCommand(CMD_MEMORY_ACCESS_CONTROL);
            DisplaySendData(new byte[] { 0x48 });
            DisplaySendCommand(CMD_PIXEL_FORMAT);
            DisplaySendData(new byte[] { 0x55 });
            DisplaySendCommand(CMD_FRAME_RATE_CONTROL);
            DisplaySendData(new byte[] { 0x00, 0x18 });
            DisplaySendCommand(CMD_DISPLAY_FUNCTION_CONTROL);
            DisplaySendData(new byte[] { 0x08, 0x82, 0x27 });
            DisplaySendCommand(CMD_ENABLE_3G);
            DisplaySendData(new byte[] { 0x00 });
            DisplaySendCommand(CMD_GAMMA_SET);
            DisplaySendData(new byte[] { 0x01 });
            DisplaySendCommand(CMD_POSITIVE_GAMMA_CORRECTION);
            DisplaySendData(new byte[] { 0x0F, 0x31, 0x2B, 0x0C, 0x0E, 0x08, 0x4E, 0xF1, 0x37, 0x07, 0x10, 0x03, 0x0E, 0x09, 0x00 });
            DisplaySendCommand(CMD_NEGATIVE_GAMMA_CORRECTION);
            DisplaySendData(new byte[] { 0x00, 0x0E, 0x14, 0x03, 0x11, 0x07, 0x31, 0xC1, 0x48, 0x08, 0x0F, 0x0C, 0x31, 0x36, 0x0F });
            DisplaySendCommand(CMD_SLEEP_OUT);

            await Task.Delay(120);

            DisplaySendCommand(CMD_DISPLAY_ON);

        }

        public void Sleep()
        {

            DisplaySendCommand(CMD_DISPLAY_OFF);
            DisplaySendCommand(CMD_ENTER_SLEEP);

        }

        public void CleanUp()
        {

            SpiDisplay.Dispose();
            ResetPin.Dispose();
            DataCommandPin.Dispose();

        }

        private void SetAddress(uint x0, uint y0, uint x1, uint y1)
        {

            DisplaySendCommand(CMD_COLUMN_ADDRESS_SET);
            DisplaySendData(new byte[] { (byte)(x0 >> 8), (byte)(x0), (byte)(x1 >> 8), (byte)(x1) });
            DisplaySendCommand(CMD_PAGE_ADDRESS_SET);
            DisplaySendData(new byte[] { (byte)(y0 >> 8), (byte)(y0), (byte)(y1 >> 8), (byte)(y1) });
            DisplaySendCommand(CMD_MEMORY_WRITE_MODE);

        }

        public ushort RGB888ToRGB565(byte r8, byte g8, byte b8)
        {

            ushort r5 = (ushort)((r8 * 249 + 1014) >> 11);
            ushort g6 = (ushort)((g8 * 253 + 505) >> 10);
            ushort b5 = (ushort)((b8 * 249 + 1014) >> 11);

            return (ushort)(r5 << 11 | g6 << 5 | b5);

        }

        private void DisplaySendData(byte[] Data)
        {

            DataCommandPin.Write(GpioPinValue.High);
            SpiDisplay.Write(Data);

        }

        private void DisplaySendCommand(byte[] Command)
        {

            DataCommandPin.Write(GpioPinValue.Low);
            SpiDisplay.Write(Command);

        }

        // Zone Text

        public void PlaceCursor(UInt16 x, UInt16 y)
        {

            this.cursorX = (byte)x;
            this.cursorY = (byte)y;
        }

        public void Print(String s, byte textsize, int color)
        {

            for (int len = 0; len < s.Length; len++)
            {

                Print(s.ElementAt<char>(len), textsize, color);
            }

        }

        public void Println(String s, byte textsize, int color)
        {

            for (int len = 0; len < s.Length; len++)
            {

                Print(s.ElementAt<char>(len), textsize, color);
            }

            Print("\n", textsize, color);

        }

        private void Print(char[] c, byte textsize, int color)
        {

            for (int len = 0; len < c.Length; len++)
            {

                Print(c[len], textsize, color);
            }

        }

        private void Print(char c, byte textsize, int color)
        {

            // bounds check
            if (this.cursorX >= LCD_W || this.cursorY >= LCD_H)
            {

                return;
            }

            // do we have a new line, if so simply adjust cursor position
            if (c == '\n')
            {

                // next line based on font size
                this.cursorY += (byte)(textsize * 8);
                // back to  character 0
                this.cursorX = 0;
            }
            else if (c == '\r')
            {

                // back to  character 0
                this.cursorX = 0;
            }
            else
            {

                this.MakeChar(this.cursorX, this.cursorY, c, textsize, color);

                this.cursorX += (byte)(textsize * 6);

                if (this.cursorX > (LCD_W - textsize * 6))
                {

                    // next line based on font size
                    this.cursorY += (byte)(textsize * 8);
                    // back to  character 0
                    this.cursorX = 0;
                }

            }

        }

        private void FillRectangle(UInt16 x0, UInt16 y0, UInt16 width, UInt16 height, int color)
        {

            if (x0 >= LCD_W || y0 >= LCD_H)
            {

                return;
            }

            if ((x0 + width - 1) >= LCD_W)
            {
                width = (UInt16)(LCD_W - x0);
            }

            UInt16 x1 = (UInt16)(x0 + width - 1);

            if ((y0 + height - 1) >= LCD_H)
            {
                height = (UInt16)(LCD_H - y0);
            }

            UInt16 y1 = (UInt16)(y0 + height - 1);

            byte VH = (byte)(color >> 8);
            byte VL = (byte)(color & 0xFF);

            byte[] buffer = new byte[width * height * 2];

            for (int index = 0; index < buffer.Length; index += 2)
            {

                buffer[index] = VH;
                buffer[index + 1] = VL;

            }

            SetAddress(x0, y0, x1, y1);
            DisplaySendData(buffer);

        }

        public void MakeChar(UInt16 x, UInt16 y, char c, UInt16 textsize, int color)
        {

            UInt16 wCharOriginal = 6;
            UInt16 hCharOriginal = 8;

            UInt16 wCharSized = (UInt16)(wCharOriginal * textsize);
            UInt16 hCharSized = (UInt16)(hCharOriginal * textsize);

            // bounds checks
            if ((x >= LCD_W) || (y >= LCD_H) || ((x + wCharSized - 1) < 0) || ((y + hCharSized - 1) < 0))
            {

                return;
            }

            byte[] car = DisplayFontTable.GetFontCharacterDescriptorFromFontTableStandart(c).Data;

            String c0 = car[0].ToString("X");
            String c1 = car[1].ToString("X");
            String c2 = car[2].ToString("X");
            String c3 = car[3].ToString("X");
            String c4 = car[4].ToString("X");

            if (c0.Length < 2) { c0 = "0" + c0; }
            if (c1.Length < 2) { c1 = "0" + c1; }
            if (c2.Length < 2) { c2 = "0" + c2; }
            if (c3.Length < 2) { c3 = "0" + c3; }
            if (c4.Length < 2) { c4 = "0" + c4; }

            String c01 = c0.Substring(0, 1);
            String c00 = c0.Substring(1, 1);

            String c11 = c1.Substring(0, 1);
            String c10 = c1.Substring(1, 1);

            String c21 = c2.Substring(0, 1);
            String c20 = c2.Substring(1, 1);

            String c31 = c3.Substring(0, 1);
            String c30 = c3.Substring(1, 1);

            String c41 = c4.Substring(0, 1);
            String c40 = c4.Substring(1, 1);

            bool[] b01 = Util.Convert.ConvertHexToBin(c01);
            bool[] b00 = Util.Convert.ConvertHexToBin(c00);

            bool[] b11 = Util.Convert.ConvertHexToBin(c11);
            bool[] b10 = Util.Convert.ConvertHexToBin(c10);

            bool[] b21 = Util.Convert.ConvertHexToBin(c21);
            bool[] b20 = Util.Convert.ConvertHexToBin(c20);

            bool[] b31 = Util.Convert.ConvertHexToBin(c31);
            bool[] b30 = Util.Convert.ConvertHexToBin(c30);

            bool[] b41 = Util.Convert.ConvertHexToBin(c41);
            bool[] b40 = Util.Convert.ConvertHexToBin(c40);

            ushort[] _charOriginal = new ushort[ wCharOriginal * hCharOriginal ];

            if (b00[0]) { _charOriginal[0] = (ushort)color; } else { _charOriginal[0] = RGB888ToRGB565(0, 0, 0); }
            if (b10[0]) { _charOriginal[1] = (ushort)color; } else { _charOriginal[1] = RGB888ToRGB565(0, 0, 0); }
            if (b20[0]) { _charOriginal[2] = (ushort)color; } else { _charOriginal[2] = RGB888ToRGB565(0, 0, 0); }
            if (b30[0]) { _charOriginal[3] = (ushort)color; } else { _charOriginal[3] = RGB888ToRGB565(0, 0, 0); }
            if (b40[0]) { _charOriginal[4] = (ushort)color; } else { _charOriginal[4] = RGB888ToRGB565(0, 0, 0); }
            _charOriginal[5] = RGB888ToRGB565(0, 0, 0);

            if (b00[1]) { _charOriginal[6] = (ushort)color; } else { _charOriginal[6] = RGB888ToRGB565(0, 0, 0); }
            if (b10[1]) { _charOriginal[7] = (ushort)color; } else { _charOriginal[7] = RGB888ToRGB565(0, 0, 0); }
            if (b20[1]) { _charOriginal[8] = (ushort)color; } else { _charOriginal[8] = RGB888ToRGB565(0, 0, 0); }
            if (b30[1]) { _charOriginal[9] = (ushort)color; } else { _charOriginal[9] = RGB888ToRGB565(0, 0, 0); }
            if (b40[1]) { _charOriginal[10] = (ushort)color; } else { _charOriginal[10] = RGB888ToRGB565(0, 0, 0); }
            _charOriginal[11] = RGB888ToRGB565(0, 0, 0);

            if (b00[2]) { _charOriginal[12] = (ushort)color; } else { _charOriginal[12] = RGB888ToRGB565(0, 0, 0); }
            if (b10[2]) { _charOriginal[13] = (ushort)color; } else { _charOriginal[13] = RGB888ToRGB565(0, 0, 0); }
            if (b20[2]) { _charOriginal[14] = (ushort)color; } else { _charOriginal[14] = RGB888ToRGB565(0, 0, 0); }
            if (b30[2]) { _charOriginal[15] = (ushort)color; } else { _charOriginal[15] = RGB888ToRGB565(0, 0, 0); }
            if (b40[2]) { _charOriginal[16] = (ushort)color; } else { _charOriginal[16] = RGB888ToRGB565(0, 0, 0); }
            _charOriginal[17] = RGB888ToRGB565(0, 0, 0);

            if (b00[3]) { _charOriginal[18] = (ushort)color; } else { _charOriginal[18] = RGB888ToRGB565(0, 0, 0); }
            if (b10[3]) { _charOriginal[19] = (ushort)color; } else { _charOriginal[19] = RGB888ToRGB565(0, 0, 0); }
            if (b20[3]) { _charOriginal[20] = (ushort)color; } else { _charOriginal[20] = RGB888ToRGB565(0, 0, 0); }
            if (b30[3]) { _charOriginal[21] = (ushort)color; } else { _charOriginal[21] = RGB888ToRGB565(0, 0, 0); }
            if (b40[3]) { _charOriginal[22] = (ushort)color; } else { _charOriginal[22] = RGB888ToRGB565(0, 0, 0); }
            _charOriginal[23] = RGB888ToRGB565(0, 0, 0);

            if (b01[0]) { _charOriginal[24] = (ushort)color; } else { _charOriginal[24] = RGB888ToRGB565(0, 0, 0); }
            if (b11[0]) { _charOriginal[25] = (ushort)color; } else { _charOriginal[25] = RGB888ToRGB565(0, 0, 0); }
            if (b21[0]) { _charOriginal[26] = (ushort)color; } else { _charOriginal[26] = RGB888ToRGB565(0, 0, 0); }
            if (b31[0]) { _charOriginal[27] = (ushort)color; } else { _charOriginal[27] = RGB888ToRGB565(0, 0, 0); }
            if (b41[0]) { _charOriginal[28] = (ushort)color; } else { _charOriginal[28] = RGB888ToRGB565(0, 0, 0); }
            _charOriginal[29] = RGB888ToRGB565(0, 0, 0);

            if (b01[1]) { _charOriginal[30] = (ushort)color; } else { _charOriginal[30] = RGB888ToRGB565(0, 0, 0); }
            if (b11[1]) { _charOriginal[31] = (ushort)color; } else { _charOriginal[31] = RGB888ToRGB565(0, 0, 0); }
            if (b21[1]) { _charOriginal[32] = (ushort)color; } else { _charOriginal[32] = RGB888ToRGB565(0, 0, 0); }
            if (b31[1]) { _charOriginal[33] = (ushort)color; } else { _charOriginal[33] = RGB888ToRGB565(0, 0, 0); }
            if (b41[1]) { _charOriginal[34] = (ushort)color; } else { _charOriginal[34] = RGB888ToRGB565(0, 0, 0); }
            _charOriginal[35] = RGB888ToRGB565(0, 0, 0);

            if (b01[2]) { _charOriginal[36] = (ushort)color; } else { _charOriginal[36] = RGB888ToRGB565(0, 0, 0); }
            if (b11[2]) { _charOriginal[37] = (ushort)color; } else { _charOriginal[37] = RGB888ToRGB565(0, 0, 0); }
            if (b21[2]) { _charOriginal[38] = (ushort)color; } else { _charOriginal[38] = RGB888ToRGB565(0, 0, 0); }
            if (b31[2]) { _charOriginal[39] = (ushort)color; } else { _charOriginal[39] = RGB888ToRGB565(0, 0, 0); }
            if (b41[2]) { _charOriginal[40] = (ushort)color; } else { _charOriginal[40] = RGB888ToRGB565(0, 0, 0); }
            _charOriginal[41] = RGB888ToRGB565(0, 0, 0);

            _charOriginal[42] = RGB888ToRGB565(0, 0, 0);
            _charOriginal[43] = RGB888ToRGB565(0, 0, 0);
            _charOriginal[44] = RGB888ToRGB565(0, 0, 0);
            _charOriginal[45] = RGB888ToRGB565(0, 0, 0);
            _charOriginal[46] = RGB888ToRGB565(0, 0, 0);
            _charOriginal[47] = RGB888ToRGB565(0, 0, 0);

            ushort[] _charSized = new ushort[wCharSized * hCharSized];

            int cs = 0;

            for (int hco = 0; hco < hCharOriginal; hco++)
            {

                for (int hts = 0; hts < textsize; hts++)
                {

                    for (int wco = 0; wco < wCharOriginal; wco++)
                    {

                        for (int wts = 0; wts < textsize; wts++)
                        {

                            _charSized[cs] = _charOriginal[ hco * wCharOriginal + wco];

                            cs++;

                        }

                    }

                }

            }

            DrawPicture08( _charSized, wCharSized, hCharSized, x, y);

        }


        // Zone File

        public async void LoadFile(ushort[] _picture, uint w, uint h, string name)
        {

            StorageFile srcfile = await StorageFile.GetFileFromApplicationUriAsync( new Uri(name) );

            using (IRandomAccessStream fileStream = await srcfile.OpenAsync(Windows.Storage.FileAccessMode.Read))
            {

                BitmapDecoder decoder = await BitmapDecoder.CreateAsync(fileStream);

                BitmapTransform transform = new BitmapTransform()
                {

                    ScaledWidth = System.Convert.ToUInt32( w ),
                    ScaledHeight = System.Convert.ToUInt32( h )
                };

                PixelDataProvider pixelData = await decoder.GetPixelDataAsync( BitmapPixelFormat.Bgra8, BitmapAlphaMode.Straight, transform, ExifOrientationMode.IgnoreExifOrientation, ColorManagementMode.DoNotColorManage);

                byte[] sourcePixels = pixelData.DetachPixelData();

                if (sourcePixels.Length == w * h * 4)
                {

                    int pi = 0;
                    int i = 0;
                    byte red = 0, green = 0, blue = 0;

                    foreach (byte b in sourcePixels)
                    {

                        switch (i)
                        {

                            case 0:
                                blue = b;
                                break;
                            case 1:
                                green = b;
                                break;
                            case 2:
                                red = b;
                                break;
                            case 3:
                                _picture[pi] = RGB888ToRGB565(red, green, blue);
                                pi++;
                                break;
                        }

                        i = (i + 1) % 4;
                    }

                }
                else
                {

                    return;
                }

            }

        }


        // Zone Screen

        public void ClearScreen()
        {

            this.ColorScreen(this.RGB888ToRGB565(0, 0, 0));
        }

        public void ColorScreen(int color)
        {

            this.FillRectangle(0, 0, (UInt16)LCD_W, (UInt16)LCD_H, color);
        }

        public void EditScreen(ushort[] _picture, int w, int h, int x, int y)
        {

            for (int j = 0; j < h; j++)
            {

                for (int i = 0; i < w; i++)
                {

                    // Numéro de pixel du square

                    int s = i + j * 60;

                    // Numéro de pixel du picture

                    int p = (j * 240) + (y * 240 + x + i);

                    _lcd[p] = _picture[s];

                }


            }

        }

        public void DrawScreen()
        {

            // taille du block = 240 x 32 = 7 680
            int block_size = (int) (LCD_W * LINE_HEIGHT_32);

            // nombre de block = 76 800 / 7 680 = 10
            int number_of_blocks = _lcd.Length / block_size;

            // buffer = tableau de byte de taille = 7 680 x 2 = 15 360
            byte[] buffer = new byte[block_size * 2];

            int i = 0;
            uint line = 0;

            foreach (ushort s in _lcd)
            {

                buffer[i * 2] = (byte)((s >> 8) & 0xFF);
                buffer[i * 2 + 1] = (byte)(s & 0xFF);
                i++;

                if (i >= block_size)
                {

                    i = 0;
                    SetAddress(0, line * LINE_HEIGHT_32, LCD_W - 1, (line + 1) * LINE_HEIGHT_32 - 1);
                    DisplaySendData(buffer);
                    line++;
                }

            }

        }

        public void DrawPicture08(ushort[] _picture, UInt16 w, UInt16 h, UInt16 x0, UInt16 y0)
        {

            int block_size = (int) (w * LINE_HEIGHT_08);

            int number_of_blocks = _picture.Length / block_size;

            byte[] buffer = new byte[block_size * 2];

            int i = 0;
            uint line = 0;

            foreach (ushort s in _picture)
            {

                buffer[i * 2] = (byte)((s >> 8) & 0xFF);
                buffer[i * 2 + 1] = (byte)(s & 0xFF);
                i++;

                if (i >= block_size)
                {

                    i = 0;
                    SetAddress((UInt16)(x0), (UInt16)(y0 + line * LINE_HEIGHT_08), (UInt16)(x0 + w - 1), (UInt16)(y0 + (line + 1) * LINE_HEIGHT_08 - 1));
                    DisplaySendData(buffer);
                    line++;

                }

            }

        }

        public void DrawPicture10(ushort[] _picture, UInt16 w, UInt16 h, UInt16 x0, UInt16 y0)
        {

            int block_size = (int)(w * LINE_HEIGHT_10);

            int number_of_blocks = _picture.Length / block_size;

            byte[] buffer = new byte[block_size * 2];

            int i = 0;
            uint line = 0;

            foreach (ushort s in _picture)
            {

                buffer[i * 2] = (byte)((s >> 8) & 0xFF);
                buffer[i * 2 + 1] = (byte)(s & 0xFF);
                i++;

                if (i >= block_size)
                {

                    i = 0;
                    SetAddress( (UInt16) (x0), (UInt16) (y0 + line * LINE_HEIGHT_10), (UInt16) (x0 + w - 1), (UInt16) (y0 + (line + 1) * LINE_HEIGHT_10 - 1) );
                    DisplaySendData(buffer);
                    line++;

                }

            }

        }
               
        public void DrawPicture20(ushort[] _picture, UInt16 w, UInt16 h, UInt16 x0, UInt16 y0)
        {

            int block_size = (int)(w * LINE_HEIGHT_20);

            int number_of_blocks = _picture.Length / block_size;

            byte[] buffer = new byte[block_size * 2];

            int i = 0;
            uint line = 0;

            foreach (ushort s in _picture)
            {

                buffer[i * 2] = (byte)((s >> 8) & 0xFF);
                buffer[i * 2 + 1] = (byte)(s & 0xFF);
                i++;

                if (i >= block_size)
                {

                    i = 0;
                    SetAddress(x0, (UInt16)(y0 + line * LINE_HEIGHT_20), (UInt16)(x0 + w - 1), (UInt16)(y0 + (line + 1) * LINE_HEIGHT_20 - 1));
                    DisplaySendData(buffer);
                    line++;

                }

            }

        }

        public void DrawPicture30(ushort[] _picture, UInt16 w, UInt16 h, UInt16 x0, UInt16 y0)
        {

            int block_size = (int)(w * LINE_HEIGHT_30);

            int number_of_blocks = _picture.Length / block_size;

            byte[] buffer = new byte[block_size * 2];

            int i = 0;
            uint line = 0;

            foreach (ushort s in _picture)
            {

                buffer[i * 2] = (byte)((s >> 8) & 0xFF);
                buffer[i * 2 + 1] = (byte)(s & 0xFF);
                i++;

                if (i >= block_size)
                {

                    i = 0;
                    SetAddress(x0, (UInt16)(y0 + line * LINE_HEIGHT_30), (UInt16)(x0 + w - 1), (UInt16)(y0 + (line + 1) * LINE_HEIGHT_30 - 1));
                    DisplaySendData(buffer);
                    line++;

                }

            }

        }

        public void DrawPicture32(ushort[] _picture, UInt16 w, UInt16 h, UInt16 x0, UInt16 y0)
        {

            int block_size = (int)(w * LINE_HEIGHT_32);

            int number_of_blocks = _picture.Length / block_size;

            byte[] buffer = new byte[block_size * 2];

            int i = 0;
            uint line = 0;

            foreach (ushort s in _picture)
            {

                buffer[i * 2] = (byte)((s >> 8) & 0xFF);
                buffer[i * 2 + 1] = (byte)(s & 0xFF);
                i++;

                if (i >= block_size)
                {

                    i = 0;
                    SetAddress( x0, (UInt16) (y0 + line * LINE_HEIGHT_32), (UInt16) (x0 + w - 1), (UInt16) (y0 + (line + 1) * LINE_HEIGHT_32 - 1));
                    DisplaySendData(buffer);
                    line++;

                }

            }

        }

        // Zone Graphique

        public void LCDPixel(UInt16 x0, UInt16 y0, int color)
        {

            if ((x0 < 0) || (x0 >= LCD_W) || (y0 < 0) || (y0 >= LCD_H))
            {
                return;
            }

            UInt16 x1 = (UInt16)(x0 + 1);
            UInt16 y1 = (UInt16)(y0 + 1);

            byte VH = (byte)(color >> 8);
            byte VL = (byte)(color & 0xFF);

            byte[] buffer = new byte[2];

            for (int index = 0; index < buffer.Length; index += 2)
            {
                buffer[index] = VH;
                buffer[index + 1] = VL;

            }

            SetAddress(x0, y0, x1, y1);
            DisplaySendData(buffer);

        }

        public void DrawLine(UInt16 x1, UInt16 y1, UInt16 x2, UInt16 y2, int color)
        {

            if ( x1 >= LCD_W || y1 >= LCD_H || x2 >= LCD_W || y2 >= LCD_H )
            {

                return;
            }

            if (x1 == x2)
            {

                for (int n = y1; n < y2; n++)
                {

                    UInt16 xn = (UInt16)(x1);
                    UInt16 yn = (UInt16)(n);

                    LCDPixel(xn, yn, color);

                }

            }
            else if (y1 == y2)
            {

                for (int n = x1; n < x2; n++)
                {

                    UInt16 xn = (UInt16)(n);
                    UInt16 yn = (UInt16)(y1);

                    LCDPixel(xn, yn, color);

                }

            }
            else if (x1 == x2 && y1 == y2)
            {

                LCDPixel(x1, y1, color);

            }
            else if( x2 > x1 )
            {

                double dx = x2 - x1;
                double dy = y2 - y1;

                double a = dy / dx;

                for (int n = 0; n < (x2 - x1); n++)
                {

                    UInt16 xn = (UInt16)(n + x1);

                    UInt16 yn = (UInt16)(a * n + y1);

                    LCDPixel(xn, yn, color);

                }

            }
            else if (x2 < x1)
            {

                UInt16 X1 = x2;
                UInt16 Y1 = y2;

                UInt16 X2 = x1;
                UInt16 Y2 = y1;
                
                double dX = X2 - X1;
                double dY = Y2 - Y1;

                double a = dY / dX;

                for (int n = 0; n < (X2 - X1); n++)
                {

                    UInt16 xn = (UInt16)(n + X1);

                    UInt16 yn = (UInt16)(a * n + Y1);

                    LCDPixel(xn, yn, color);

                }

            }

        }

        public void DrawArc(UInt16 x0, UInt16 y0, UInt16 Radius, UInt16 startAngle, UInt16 endAngle, int color)
        {

            double increment = 0.1;

            double startA = startAngle;

            double endA = endAngle;

            if (startA > 360)
            {
                startA = 360;
            }

            if (endA > 360)
            {

                endA = 360;
            }

            for (double i = startA; i < endA; i += increment)
            {

                double angle = i * System.Math.PI / 180;

                UInt16 x = (UInt16) (x0 + Radius * System.Math.Sin(angle));
                UInt16 y = (UInt16) (y0 - Radius * System.Math.Cos(angle));

                LCDPixel(x, y, color);

            }

        }

        public void DrawCircle(UInt16 x0, UInt16 y0, UInt16 radius, int color)
        {

            DrawArc(x0, y0, radius, 0, 360, color);
        }

        public void DrawRectangle(UInt16 x0, UInt16 y0, UInt16 width, UInt16 height, int color)
        {

            // bounds check
            if (x0 >= LCD_W || y0 >= LCD_H || (x0 + width - 1) >= LCD_W || (y0 + height - 1) >= LCD_H)
            {

                return;
            }

            UInt16 xa = (UInt16) (x0);
            UInt16 ya = (UInt16) (y0);

            UInt16 xb = (UInt16) (x0 + width - 1);
            UInt16 yb = (UInt16) (y0);

            UInt16 xc = (UInt16) (x0 + width - 1);
            UInt16 yc = (UInt16) (y0 + height - 1);

            UInt16 xd = (UInt16) (x0);
            UInt16 yd = (UInt16) (y0 + height - 1);

            DrawLine(xa, ya, xb, yb, color);
            DrawLine(xd, yd, xc, yc, color);
            DrawLine(xa, ya, xd, yd, color);
            DrawLine(xb, yb, xc, yc, color);

        }

    }

}
