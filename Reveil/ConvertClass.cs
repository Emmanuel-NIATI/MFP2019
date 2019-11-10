using System;

namespace Util
{

    public class Convert
    {

        public static bool[] ConvertHexToBin(String _hex)
        {

            bool[] res = new bool[4];

            if ("0".Equals(_hex))                       {   res[0] = false; res[1] = false; res[2] = false; res[3] = false; }

            if ("1".Equals(_hex))                       {   res[0] = true;  res[1] = false; res[2] = false; res[3] = false; }

            if ("2".Equals(_hex))                       {   res[0] = false; res[1] = true;  res[2] = false; res[3] = false; }

            if ("3".Equals(_hex))                       {   res[0] = true;  res[1] = true;  res[2] = false; res[3] = false; }

            if ("4".Equals(_hex))                       {   res[0] = false; res[1] = false; res[2] = true;  res[3] = false; }

            if ("5".Equals(_hex))                       {   res[0] = true;  res[1] = false; res[2] = true;  res[3] = false; }

            if ("6".Equals(_hex))                       {   res[0] = false; res[1] = true;  res[2] = true;  res[3] = false; }

            if ("7".Equals(_hex))                       {   res[0] = true;  res[1] = true;  res[2] = true;  res[3] = false; }

            if ("8".Equals(_hex))                       {   res[0] = false; res[1] = false; res[2] = false; res[3] = true;  }

            if ("9".Equals(_hex))                       {   res[0] = true;  res[1] = false; res[2] = false; res[3] = true;  }

            if ("A".Equals(_hex) || "a".Equals(_hex))   {   res[0] = false; res[1] = true;  res[2] = false; res[3] = true;  }

            if ("B".Equals(_hex) || "b".Equals(_hex))   {   res[0] = true;  res[1] = true;  res[2] = false; res[3] = true;  }

            if ("C".Equals(_hex) || "c".Equals(_hex))   {   res[0] = false; res[1] = false; res[2] = true;  res[3] = true;  }

            if ("D".Equals(_hex) || "d".Equals(_hex))   {   res[0] = true;  res[1] = false; res[2] = true;  res[3] = true;  }

            if ("E".Equals(_hex) || "E".Equals(_hex))   {   res[0] = false; res[1] = true;  res[2] = true;  res[3] = true;  }

            if ("F".Equals(_hex) || "f".Equals(_hex))   {   res[0] = true;  res[1] = true;  res[2] = true;  res[3] = true;  }

            return res;

        }

        public static String ConvertBinToHex(bool _b3, bool _b2, bool _b1, bool _b0)
        {

            String res = "0";

            if (!_b3 && !_b2 && !_b1 && !_b0)   { res = "0"; }

            if (!_b3 && !_b2 && !_b1 && _b0)    { res = "1"; }

            if (!_b3 && !_b2 && _b1 && !_b0)    { res = "2"; }

            if (!_b3 && !_b2 && _b1 && _b0)     { res = "3"; }

            if (!_b3 && _b2 && !_b1 && !_b0)    { res = "4"; }

            if (!_b3 && _b2 && !_b1 && _b0)     { res = "5"; }

            if (!_b3 && _b2 && _b1 && !_b0)     { res = "6"; }

            if (!_b3 && _b2 && _b1 && _b0)      { res = "7"; }

            if (_b3 && !_b2 && !_b1 && !_b0)    { res = "8"; }

            if (_b3 && !_b2 && !_b1 && _b0)     { res = "9"; }

            if (_b3 && !_b2 && _b1 && !_b0)     { res = "A"; }

            if (_b3 && !_b2 && _b1 && _b0)      { res = "B"; }

            if (_b3 && _b2 && !_b1 && !_b0)     { res = "C"; }

            if (_b3 && _b2 && !_b1 && _b0)      { res = "D"; }

            if (_b3 && _b2 && _b1 && !_b0)      { res = "E"; }

            if (_b3 && _b2 && _b1 && _b0)       { res = "F"; }

            return res;

        }

        // Ajout d'une heure
        public static String addHour(String hour)
        {

            String _hour = "06";

            if (hour.Equals("00"))
            {
                _hour = "01";
            }
            else if (hour.Equals("01"))
            {
                _hour = "02";
            }
            else if (hour.Equals("02"))
            {
                _hour = "03";
            }
            else if (hour.Equals("03"))
            {
                _hour = "04";
            }
            else if (hour.Equals("04"))
            {
                _hour = "05";
            }
            else if (hour.Equals("05"))
            {
                _hour = "06";
            }
            else if (hour.Equals("06"))
            {
                _hour = "07";
            }
            else if (hour.Equals("07"))
            {
                _hour = "08";
            }
            else if (hour.Equals("08"))
            {
                _hour = "09";
            }
            else if (hour.Equals("09"))
            {
                _hour = "10";
            }
            else if (hour.Equals("10"))
            {
                _hour = "11";
            }
            else if (hour.Equals("11"))
            {
                _hour = "12";
            }
            else if (hour.Equals("12"))
            {
                _hour = "13";
            }
            else if (hour.Equals("13"))
            {
                _hour = "14";
            }
            else if (hour.Equals("14"))
            {
                _hour = "15";
            }
            else if (hour.Equals("15"))
            {
                _hour = "16";
            }
            else if (hour.Equals("16"))
            {
                _hour = "17";
            }
            else if (hour.Equals("17"))
            {
                _hour = "18";
            }
            else if (hour.Equals("18"))
            {
                _hour = "19";
            }
            else if (hour.Equals("19"))
            {
                _hour = "20";
            }
            else if (hour.Equals("20"))
            {
                _hour = "21";
            }
            else if (hour.Equals("21"))
            {
                _hour = "22";
            }
            else if (hour.Equals("22"))
            {
                _hour = "23";
            }
            else if (hour.Equals("23"))
            {
                _hour = "00";
            }

            return _hour;

        }

        // Retrait d'une heure
        public static String removeHour(String hour)
        {

            String _hour = "06";

            if (hour.Equals("00"))
            {
                _hour = "23";
            }
            else if (hour.Equals("23"))
            {
                _hour = "22";
            }
            else if (hour.Equals("22"))
            {
                _hour = "21";
            }
            else if (hour.Equals("21"))
            {
                _hour = "20";
            }
            else if (hour.Equals("20"))
            {
                _hour = "19";
            }
            else if (hour.Equals("19"))
            {
                _hour = "18";
            }
            else if (hour.Equals("18"))
            {
                _hour = "17";
            }
            else if (hour.Equals("17"))
            {
                _hour = "16";
            }
            else if (hour.Equals("16"))
            {
                _hour = "15";
            }
            else if (hour.Equals("15"))
            {
                _hour = "14";
            }
            else if (hour.Equals("14"))
            {
                _hour = "13";
            }
            else if (hour.Equals("13"))
            {
                _hour = "12";
            }
            else if (hour.Equals("12"))
            {
                _hour = "11";
            }
            else if (hour.Equals("11"))
            {
                _hour = "10";
            }
            else if (hour.Equals("10"))
            {
                _hour = "09";
            }
            else if (hour.Equals("09"))
            {
                _hour = "08";
            }
            else if (hour.Equals("08"))
            {
                _hour = "07";
            }
            else if (hour.Equals("07"))
            {
                _hour = "06";
            }
            else if (hour.Equals("06"))
            {
                _hour = "05";
            }
            else if (hour.Equals("05"))
            {
                _hour = "04";
            }
            else if (hour.Equals("04"))
            {
                _hour = "03";
            }
            else if (hour.Equals("03"))
            {
                _hour = "02";
            }
            else if (hour.Equals("02"))
            {
                _hour = "01";
            }
            else if (hour.Equals("01"))
            {
                _hour = "00";
            }

            return _hour;

        }

        // Ajout d'une minute
        public static String addMinute(String minute)
        {

            String _minute = "30";

            if (minute.Equals("00"))
            {
                _minute = "01";
            }
            else if (minute.Equals("01"))
            {
                _minute = "02";
            }
            else if (minute.Equals("02"))
            {
                _minute = "03";
            }
            else if (minute.Equals("03"))
            {
                _minute = "04";
            }
            else if (minute.Equals("04"))
            {
                _minute = "05";
            }
            else if (minute.Equals("05"))
            {
                _minute = "06";
            }
            else if (minute.Equals("06"))
            {
                _minute = "07";
            }
            else if (minute.Equals("07"))
            {
                _minute = "08";
            }
            else if (minute.Equals("08"))
            {
                _minute = "09";
            }
            else if (minute.Equals("09"))
            {
                _minute = "10";
            }
            else if (minute.Equals("10"))
            {
                _minute = "11";
            }
            else if (minute.Equals("11"))
            {
                _minute = "12";
            }
            else if (minute.Equals("12"))
            {
                _minute = "13";
            }
            else if (minute.Equals("13"))
            {
                _minute = "14";
            }
            else if (minute.Equals("14"))
            {
                _minute = "15";
            }
            else if (minute.Equals("15"))
            {
                _minute = "16";
            }
            else if (minute.Equals("16"))
            {
                _minute = "17";
            }
            else if (minute.Equals("17"))
            {
                _minute = "18";
            }
            else if (minute.Equals("18"))
            {
                _minute = "19";
            }
            else if (minute.Equals("19"))
            {
                _minute = "20";
            }
            else if (minute.Equals("20"))
            {
                _minute = "21";
            }
            else if (minute.Equals("21"))
            {
                _minute = "22";
            }
            else if (minute.Equals("22"))
            {
                _minute = "23";
            }
            else if (minute.Equals("23"))
            {
                _minute = "24";
            }
            else if (minute.Equals("24"))
            {
                _minute = "25";
            }
            else if (minute.Equals("25"))
            {
                _minute = "26";
            }
            else if (minute.Equals("26"))
            {
                _minute = "27";
            }
            else if (minute.Equals("27"))
            {
                _minute = "28";
            }
            else if (minute.Equals("28"))
            {
                _minute = "29";
            }
            else if (minute.Equals("29"))
            {
                _minute = "30";
            }
            else if (minute.Equals("30"))
            {
                _minute = "31";
            }
            else if (minute.Equals("31"))
            {
                _minute = "32";
            }
            else if (minute.Equals("32"))
            {
                _minute = "33";
            }
            else if (minute.Equals("33"))
            {
                _minute = "34";
            }
            else if (minute.Equals("34"))
            {
                _minute = "35";
            }
            else if (minute.Equals("35"))
            {
                _minute = "36";
            }
            else if (minute.Equals("36"))
            {
                _minute = "37";
            }
            else if (minute.Equals("37"))
            {
                _minute = "38";
            }
            else if (minute.Equals("38"))
            {
                _minute = "39";
            }
            else if (minute.Equals("39"))
            {
                _minute = "40";
            }
            else if (minute.Equals("40"))
            {
                _minute = "41";
            }
            else if (minute.Equals("41"))
            {
                _minute = "42";
            }
            else if (minute.Equals("42"))
            {
                _minute = "43";
            }
            else if (minute.Equals("43"))
            {
                _minute = "44";
            }
            else if (minute.Equals("44"))
            {
                _minute = "45";
            }
            else if (minute.Equals("45"))
            {
                _minute = "46";
            }
            else if (minute.Equals("46"))
            {
                _minute = "47";
            }
            else if (minute.Equals("47"))
            {
                _minute = "48";
            }
            else if (minute.Equals("48"))
            {
                _minute = "49";
            }
            else if (minute.Equals("49"))
            {
                _minute = "50";
            }
            else if (minute.Equals("50"))
            {
                _minute = "51";
            }
            else if (minute.Equals("51"))
            {
                _minute = "52";
            }
            else if (minute.Equals("52"))
            {
                _minute = "53";
            }
            else if (minute.Equals("53"))
            {
                _minute = "54";
            }
            else if (minute.Equals("54"))
            {
                _minute = "55";
            }
            else if (minute.Equals("55"))
            {
                _minute = "56";
            }
            else if (minute.Equals("56"))
            {
                _minute = "57";
            }
            else if (minute.Equals("57"))
            {
                _minute = "58";
            }
            else if (minute.Equals("58"))
            {
                _minute = "59";
            }
            else if (minute.Equals("59"))
            {
                _minute = "00";
            }

            return _minute;

        }

        // Retrait d'une minute
        public static String removeMinute(String minute)
        {

            String _minute = "30";

            if (minute.Equals("00"))
            {
                _minute = "59";
            }
            else if (minute.Equals("59"))
            {
                _minute = "58";
            }
            else if (minute.Equals("58"))
            {
                _minute = "57";
            }
            else if (minute.Equals("57"))
            {
                _minute = "56";
            }
            else if (minute.Equals("56"))
            {
                _minute = "55";
            }
            else if (minute.Equals("55"))
            {
                _minute = "54";
            }
            else if (minute.Equals("54"))
            {
                _minute = "53";
            }
            else if (minute.Equals("53"))
            {
                _minute = "52";
            }
            else if (minute.Equals("52"))
            {
                _minute = "51";
            }
            else if (minute.Equals("51"))
            {
                _minute = "50";
            }
            else if (minute.Equals("50"))
            {
                _minute = "49";
            }
            else if (minute.Equals("49"))
            {
                _minute = "48";
            }
            else if (minute.Equals("48"))
            {
                _minute = "47";
            }
            else if (minute.Equals("47"))
            {
                _minute = "46";
            }
            else if (minute.Equals("46"))
            {
                _minute = "45";
            }
            else if (minute.Equals("45"))
            {
                _minute = "44";
            }
            else if (minute.Equals("44"))
            {
                _minute = "43";
            }
            else if (minute.Equals("43"))
            {
                _minute = "42";
            }
            else if (minute.Equals("42"))
            {
                _minute = "41";
            }
            else if (minute.Equals("41"))
            {
                _minute = "40";
            }
            else if (minute.Equals("40"))
            {
                _minute = "39";
            }
            else if (minute.Equals("39"))
            {
                _minute = "38";
            }
            else if (minute.Equals("38"))
            {
                _minute = "37";
            }
            else if (minute.Equals("37"))
            {
                _minute = "36";
            }
            else if (minute.Equals("36"))
            {
                _minute = "35";
            }
            else if (minute.Equals("35"))
            {
                _minute = "34";
            }
            else if (minute.Equals("34"))
            {
                _minute = "33";
            }
            else if (minute.Equals("33"))
            {
                _minute = "32";
            }
            else if (minute.Equals("32"))
            {
                _minute = "31";
            }
            else if (minute.Equals("31"))
            {
                _minute = "30";
            }
            else if (minute.Equals("30"))
            {
                _minute = "29";
            }
            else if (minute.Equals("29"))
            {
                _minute = "28";
            }
            else if (minute.Equals("28"))
            {
                _minute = "27";
            }
            else if (minute.Equals("27"))
            {
                _minute = "26";
            }
            else if (minute.Equals("26"))
            {
                _minute = "25";
            }
            else if (minute.Equals("25"))
            {
                _minute = "24";
            }
            else if (minute.Equals("24"))
            {
                _minute = "23";
            }
            else if (minute.Equals("23"))
            {
                _minute = "22";
            }
            else if (minute.Equals("22"))
            {
                _minute = "21";
            }
            else if (minute.Equals("21"))
            {
                _minute = "20";
            }
            else if (minute.Equals("20"))
            {
                _minute = "19";
            }
            else if (minute.Equals("19"))
            {
                _minute = "18";
            }
            else if (minute.Equals("18"))
            {
                _minute = "17";
            }
            else if (minute.Equals("17"))
            {
                _minute = "16";
            }
            else if (minute.Equals("16"))
            {
                _minute = "15";
            }
            else if (minute.Equals("15"))
            {
                _minute = "14";
            }
            else if (minute.Equals("14"))
            {
                _minute = "13";
            }
            else if (minute.Equals("13"))
            {
                _minute = "12";
            }
            else if (minute.Equals("12"))
            {
                _minute = "11";
            }
            else if (minute.Equals("11"))
            {
                _minute = "10";
            }
            else if (minute.Equals("10"))
            {
                _minute = "09";
            }
            else if (minute.Equals("09"))
            {
                _minute = "08";
            }
            else if (minute.Equals("08"))
            {
                _minute = "07";
            }
            else if (minute.Equals("07"))
            {
                _minute = "06";
            }
            else if (minute.Equals("06"))
            {
                _minute = "05";
            }
            else if (minute.Equals("05"))
            {
                _minute = "04";
            }
            else if (minute.Equals("04"))
            {
                _minute = "03";
            }
            else if (minute.Equals("03"))
            {
                _minute = "02";
            }
            else if (minute.Equals("02"))
            {
                _minute = "01";
            }
            else if (minute.Equals("01"))
            {
                _minute = "00";
            }

            return _minute;

        }

    }

}
