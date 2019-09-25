using System;

namespace Pixel
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

    }

}