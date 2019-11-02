using System;

namespace DisplayFont
{

    public class FontCharacterDescriptor
    {

        public readonly UInt16 Order;
        public readonly char Character;
        public readonly byte[] Data;
        public readonly String Description;

        public FontCharacterDescriptor(UInt16 _Order, Char _Character, byte[] _Data, String _Description)
        {

            Order = _Order;
            Character = _Character;
            Data = _Data;
            Description = _Description;

        }

    }

    public static class DisplayFontTable
    {

        public static FontCharacterDescriptor GetFontCharacterDescriptorFromFontTableStandart(Char _Character)
        {

            FontCharacterDescriptor fcd = new FontCharacterDescriptor(000, ' ', new byte[] { 0x00, 0x00, 0x00, 0x00, 0x00 }, "");

            foreach (FontCharacterDescriptor _fcd in FontTableStandart)
            {

                if ( _fcd.Character == _Character )
                {

                    fcd = _fcd;
                }

            }

            return fcd;

        }

        public static FontCharacterDescriptor GetFontCharacterDescriptorFromFontTableStandart(UInt16 _Order)
        {

            FontCharacterDescriptor fcd = new FontCharacterDescriptor(000, ' ', new byte[] { 0x00, 0x00, 0x00, 0x00, 0x00 }, "");

            foreach (FontCharacterDescriptor _fcd in FontTableStandart)
            {

                if ( _fcd.Order == _Order )
                {

                    fcd = _fcd;
                }

            }

            return fcd;

        }

        public static UInt16 GetFontTableStandartSize()
        {

            UInt16 size = 0;

            foreach (FontCharacterDescriptor fcd in FontTableStandart)
            {

                size++;
            }

            return size;

        }

        private static readonly FontCharacterDescriptor[] FontTableStandart = 
        {

            new FontCharacterDescriptor( 000, ' ', new byte[]{ 0x00, 0x00, 0x00, 0x00, 0x00}, "Caractère  "),
            new FontCharacterDescriptor( 001, '☺', new byte[]{ 0x3E, 0x5B, 0x4F, 0x5B, 0x3E}, "Caractère ☺"),
            new FontCharacterDescriptor( 002, '☻', new byte[]{ 0x3E, 0x6B, 0x4F, 0x6B, 0x3E}, "Caractère ☻"),
            new FontCharacterDescriptor( 003, '♥', new byte[]{ 0x1C, 0x3E, 0x7C, 0x3E, 0x1C}, "Caractère ♥"),
            new FontCharacterDescriptor( 004, '♦', new byte[]{ 0x18, 0x3C, 0x7E, 0x3C, 0x18}, "Caractère ♦"),
            new FontCharacterDescriptor( 005, '♣', new byte[]{ 0x1C, 0x57, 0x7D, 0x57, 0x1C}, "Caractère ♣"),
            new FontCharacterDescriptor( 006, '♠', new byte[]{ 0x1C, 0x5E, 0x7F, 0x5E, 0x1C}, "Caractère ♠"),
            new FontCharacterDescriptor( 007, '•', new byte[]{ 0x00, 0x18, 0x3C, 0x18, 0x00}, "Caractère •"),
            new FontCharacterDescriptor( 008, '◘', new byte[]{ 0xFF, 0xE7, 0xC3, 0xE7, 0xFF}, "Caractère ◘"),
            new FontCharacterDescriptor( 009, '○', new byte[]{ 0x00, 0x18, 0x24, 0x18, 0x00}, "Caractère ○"),
            new FontCharacterDescriptor( 010, '◙', new byte[]{ 0xFF, 0xE7, 0xDB, 0xE7, 0xFF}, "Caractère ◙"),
            new FontCharacterDescriptor( 011, '♂', new byte[]{ 0x30, 0x48, 0x3A, 0x06, 0x0E}, "Caractère ♂"),
            new FontCharacterDescriptor( 012, '♀', new byte[]{ 0x26, 0x29, 0x79, 0x29, 0x26}, "Caractère ♀"),
            new FontCharacterDescriptor( 013, '♪', new byte[]{ 0x40, 0x7F, 0x05, 0x05, 0x07}, "Caractère ♪"),
            new FontCharacterDescriptor( 014, '♫', new byte[]{ 0x40, 0x7F, 0x05, 0x25, 0x3F}, "Caractère ♫"),
            new FontCharacterDescriptor( 015, '☼', new byte[]{ 0x5A, 0x3C, 0xE7, 0x3C, 0x5A}, "Caractère ☼"),
            new FontCharacterDescriptor( 016, '►', new byte[]{ 0x7F, 0x3E, 0x1C, 0x1C, 0x08}, "Caractère ►"),
            new FontCharacterDescriptor( 017, '◄', new byte[]{ 0x08, 0x1C, 0x1C, 0x3E, 0x7F}, "Caractère ◄"),
            new FontCharacterDescriptor( 018, '↕', new byte[]{ 0x14, 0x22, 0x7F, 0x22, 0x14}, "Caractère ↕"),
            new FontCharacterDescriptor( 019, '‼', new byte[]{ 0x5F, 0x5F, 0x00, 0x5F, 0x5F}, "Caractère ‼"),
            new FontCharacterDescriptor( 020, '¶', new byte[]{ 0x06, 0x09, 0x7F, 0x01, 0x7F}, "Caractère ¶"),
            new FontCharacterDescriptor( 021, '§', new byte[]{ 0x00, 0x66, 0x89, 0x95, 0x6A}, "Caractère §"),
            new FontCharacterDescriptor( 022, '▬', new byte[]{ 0x60, 0x60, 0x60, 0x60, 0x60}, "Caractère ▬"),
            new FontCharacterDescriptor( 023, '↨', new byte[]{ 0x94, 0xA2, 0xFF, 0xA2, 0x94}, "Caractère ↨"),
            new FontCharacterDescriptor( 024, '↑', new byte[]{ 0x08, 0x04, 0x7E, 0x04, 0x08}, "Caractère ↑"),
            new FontCharacterDescriptor( 025, '↓', new byte[]{ 0x10, 0x20, 0x7E, 0x20, 0x10}, "Caractère ↓"),
            new FontCharacterDescriptor( 026, '→', new byte[]{ 0x08, 0x08, 0x2A, 0x1C, 0x08}, "Caractère →"),
            new FontCharacterDescriptor( 027, '←', new byte[]{ 0x08, 0x1C, 0x2A, 0x08, 0x08}, "Caractère ←"),
            new FontCharacterDescriptor( 028, '∟', new byte[]{ 0x1E, 0x10, 0x10, 0x10, 0x10}, "Caractère ∟"),
            new FontCharacterDescriptor( 029, '↔', new byte[]{ 0x0C, 0x1E, 0x0C, 0x1E, 0x0C}, "Caractère ↔"),
            new FontCharacterDescriptor( 030, '▲', new byte[]{ 0x30, 0x38, 0x3E, 0x38, 0x30}, "Caractère ▲"),
            new FontCharacterDescriptor( 031, '▼', new byte[]{ 0x06, 0x0E, 0x3E, 0x0E, 0x06}, "Caractère ▼"),
            new FontCharacterDescriptor( 032, ' ', new byte[]{ 0x00, 0x00, 0x00, 0x00, 0x00}, "Caractère  "),
            new FontCharacterDescriptor( 033, '!', new byte[]{ 0x00, 0x00, 0x5F, 0x00, 0x00}, "Caractère !"),
            new FontCharacterDescriptor( 034, '"', new byte[]{ 0x00, 0x07, 0x00, 0x07, 0x00}, "Caractère \""),
            new FontCharacterDescriptor( 035, '#', new byte[]{ 0x14, 0x7F, 0x14, 0x7F, 0x14}, "Caractère #"),
            new FontCharacterDescriptor( 036, '$', new byte[]{ 0x24, 0x2A, 0x7F, 0x2A, 0x12}, "Caractère $"),
            new FontCharacterDescriptor( 037, '%', new byte[]{ 0x23, 0x13, 0x08, 0x64, 0x62}, "Caractère %"),
            new FontCharacterDescriptor( 038, '&', new byte[]{ 0x36, 0x49, 0x56, 0x20, 0x50}, "Caractère &"),
            new FontCharacterDescriptor( 039, '\'', new byte[]{ 0x00, 0x08, 0x07, 0x03, 0x00}, "Caractère \'"),
            new FontCharacterDescriptor( 040, '(', new byte[]{ 0x00, 0x1C, 0x22, 0x41, 0x00}, "Caractère ("),
            new FontCharacterDescriptor( 041, ')', new byte[]{ 0x00, 0x41, 0x22, 0x1C, 0x00}, "Caractère )"),
            new FontCharacterDescriptor( 042, '*', new byte[]{ 0x2A, 0x1C, 0x7F, 0x1C, 0x2A}, "Caractère *"),
            new FontCharacterDescriptor( 043, '+', new byte[]{ 0x08, 0x08, 0x3E, 0x08, 0x08}, "Caractère +"),
            new FontCharacterDescriptor( 044, ',', new byte[]{ 0x00, 0x80, 0x70, 0x30, 0x00}, "Caractère ,"),
            new FontCharacterDescriptor( 045, '-', new byte[]{ 0x08, 0x08, 0x08, 0x08, 0x08}, "Caractère -"),
            new FontCharacterDescriptor( 046, '.', new byte[]{ 0x00, 0x00, 0x60, 0x60, 0x00}, "Caractère ."),
            new FontCharacterDescriptor( 047, '/', new byte[]{ 0x20, 0x10, 0x08, 0x04, 0x02}, "Caractère /"),
            new FontCharacterDescriptor( 048, '0', new byte[]{ 0x3E, 0x51, 0x49, 0x45, 0x3E}, "Chiffre 0"),
            new FontCharacterDescriptor( 049, '1', new byte[]{ 0x00, 0x42, 0x7F, 0x40, 0x00}, "Chiffre 1"),
            new FontCharacterDescriptor( 050, '2', new byte[]{ 0x72, 0x49, 0x49, 0x49, 0x46}, "Chiffre 2"),
            new FontCharacterDescriptor( 051, '3', new byte[]{ 0x21, 0x41, 0x49, 0x4D, 0x33}, "Chiffre 3"),
            new FontCharacterDescriptor( 052, '4', new byte[]{ 0x18, 0x14, 0x12, 0x7F, 0x10}, "Chiffre 4"),
            new FontCharacterDescriptor( 053, '5', new byte[]{ 0x27, 0x45, 0x45, 0x45, 0x39}, "Chiffre 5"),
            new FontCharacterDescriptor( 054, '6', new byte[]{ 0x3C, 0x4A, 0x49, 0x49, 0x31}, "Chiffre 6"),
            new FontCharacterDescriptor( 055, '7', new byte[]{ 0x41, 0x21, 0x11, 0x09, 0x07}, "Chiffre 7"),
            new FontCharacterDescriptor( 056, '8', new byte[]{ 0x36, 0x49, 0x49, 0x49, 0x36}, "Chiffre 8"),
            new FontCharacterDescriptor( 057, '9', new byte[]{ 0x46, 0x49, 0x49, 0x29, 0x1E}, "Chiffre 9"),
            new FontCharacterDescriptor( 058, ':', new byte[]{ 0x00, 0x00, 0x14, 0x00, 0x00}, "Caractère :"),
            new FontCharacterDescriptor( 059, ';', new byte[]{ 0x00, 0x40, 0x34, 0x00, 0x00}, "Caractère ;"),
            new FontCharacterDescriptor( 060, '<', new byte[]{ 0x00, 0x08, 0x14, 0x22, 0x41}, "Caractère <"),
            new FontCharacterDescriptor( 061, '=', new byte[]{ 0x14, 0x14, 0x14, 0x14, 0x14}, "Caractère ="),
            new FontCharacterDescriptor( 062, '>', new byte[]{ 0x00, 0x41, 0x22, 0x14, 0x08}, "Caractère >"),
            new FontCharacterDescriptor( 063, '?', new byte[]{ 0x02, 0x01, 0x59, 0x09, 0x06}, "Caractère ?"),
            new FontCharacterDescriptor( 064, '@', new byte[]{ 0x3E, 0x41, 0x5D, 0x59, 0x4E}, "Caractère @"),
            new FontCharacterDescriptor( 065, 'A', new byte[]{ 0x7C, 0x12, 0x11, 0x12, 0x7C}, "Lettre A majuscule"),
            new FontCharacterDescriptor( 066, 'B', new byte[]{ 0x7F, 0x49, 0x49, 0x49, 0x36}, "Lettre B majuscule"),
            new FontCharacterDescriptor( 067, 'C', new byte[]{ 0x3E, 0x41, 0x41, 0x41, 0x22}, "Lettre C majuscule"),
            new FontCharacterDescriptor( 068, 'D', new byte[]{ 0x7F, 0x41, 0x41, 0x41, 0x3E}, "Lettre D majuscule"),
            new FontCharacterDescriptor( 069, 'E', new byte[]{ 0x7F, 0x49, 0x49, 0x49, 0x41}, "Lettre E majuscule"),
            new FontCharacterDescriptor( 070, 'F', new byte[]{ 0x7F, 0x09, 0x09, 0x09, 0x01}, "Lettre F majuscule"),
            new FontCharacterDescriptor( 071, 'G', new byte[]{ 0x3E, 0x41, 0x41, 0x51, 0x73}, "Lettre G majuscule"),
            new FontCharacterDescriptor( 072, 'H', new byte[]{ 0x7F, 0x08, 0x08, 0x08, 0x7F}, "Lettre H majuscule"),
            new FontCharacterDescriptor( 073, 'I', new byte[]{ 0x00, 0x41, 0x7F, 0x41, 0x00}, "Lettre I majuscule"),
            new FontCharacterDescriptor( 074, 'J', new byte[]{ 0x20, 0x40, 0x41, 0x3F, 0x01}, "Lettre J majuscule"),
            new FontCharacterDescriptor( 075, 'K', new byte[]{ 0x7F, 0x08, 0x14, 0x22, 0x41}, "Lettre K majuscule"),
            new FontCharacterDescriptor( 076, 'L', new byte[]{ 0x7F, 0x40, 0x40, 0x40, 0x40}, "Lettre L majuscule"),
            new FontCharacterDescriptor( 077, 'M', new byte[]{ 0x7F, 0x02, 0x1C, 0x02, 0x7F}, "Lettre M majuscule"),
            new FontCharacterDescriptor( 078, 'N', new byte[]{ 0x7F, 0x04, 0x08, 0x10, 0x7F}, "Lettre N majuscule"),
            new FontCharacterDescriptor( 079, 'O', new byte[]{ 0x3E, 0x41, 0x41, 0x41, 0x3E}, "Lettre O majuscule"),
            new FontCharacterDescriptor( 080, 'P', new byte[]{ 0x7F, 0x09, 0x09, 0x09, 0x06}, "Lettre P majuscule"),
            new FontCharacterDescriptor( 081, 'Q', new byte[]{ 0x3E, 0x41, 0x51, 0x21, 0x5E}, "Lettre Q majuscule"),
            new FontCharacterDescriptor( 082, 'R', new byte[]{ 0x7F, 0x09, 0x19, 0x29, 0x46}, "Lettre R majuscule"),
            new FontCharacterDescriptor( 083, 'S', new byte[]{ 0x26, 0x49, 0x49, 0x49, 0x32}, "Lettre S majuscule"),
            new FontCharacterDescriptor( 084, 'T', new byte[]{ 0x03, 0x01, 0x7F, 0x01, 0x03}, "Lettre T majuscule"),
            new FontCharacterDescriptor( 085, 'U', new byte[]{ 0x3F, 0x40, 0x40, 0x40, 0x3F}, "Lettre U majuscule"),
            new FontCharacterDescriptor( 086, 'V', new byte[]{ 0x1F, 0x20, 0x40, 0x20, 0x1F}, "Lettre V majuscule"),
            new FontCharacterDescriptor( 087, 'W', new byte[]{ 0x3F, 0x40, 0x38, 0x40, 0x3F}, "Lettre W majuscule"),
            new FontCharacterDescriptor( 088, 'X', new byte[]{ 0x63, 0x14, 0x08, 0x14, 0x63}, "Lettre X majuscule"),
            new FontCharacterDescriptor( 089, 'Y', new byte[]{ 0x03, 0x04, 0x78, 0x04, 0x03}, "Lettre Y majuscule"),
            new FontCharacterDescriptor( 090, 'Z', new byte[]{ 0x61, 0x59, 0x49, 0x4D, 0x43}, "Lettre Z majuscule"),
            new FontCharacterDescriptor( 091, '[', new byte[]{ 0x00, 0x7F, 0x41, 0x41, 0x41}, "Caractère ["),
            new FontCharacterDescriptor( 092, '\\', new byte[]{ 0x02, 0x04, 0x08, 0x10, 0x20}, "Caractère \\"),
            new FontCharacterDescriptor( 093, ']', new byte[]{ 0x00, 0x41, 0x41, 0x41, 0x7F}, "Caractère ]"),
            new FontCharacterDescriptor( 094, '^', new byte[]{ 0x04, 0x02, 0x01, 0x02, 0x04}, "Caractère ^"),
            new FontCharacterDescriptor( 095, '_', new byte[]{ 0x40, 0x40, 0x40, 0x40, 0x40}, "Caractère _"),
            new FontCharacterDescriptor( 096, '`', new byte[]{ 0x00, 0x03, 0x07, 0x08, 0x00}, "Caractère `"),
            new FontCharacterDescriptor( 097, 'a', new byte[]{ 0x20, 0x54, 0x54, 0x78, 0x40}, "Lettre a minuscule"),
            new FontCharacterDescriptor( 098, 'b', new byte[]{ 0x7F, 0x28, 0x44, 0x44, 0x38}, "Lettre b minuscule"),
            new FontCharacterDescriptor( 099, 'c', new byte[]{ 0x38, 0x44, 0x44, 0x44, 0x28}, "Lettre c minuscule"),
            new FontCharacterDescriptor( 100, 'd', new byte[]{ 0x38, 0x44, 0x44, 0x28, 0x7F}, "Lettre d minuscule"),
            new FontCharacterDescriptor( 101, 'e', new byte[]{ 0x38, 0x54, 0x54, 0x54, 0x18}, "Lettre e minuscule"),
            new FontCharacterDescriptor( 102, 'f', new byte[]{ 0x00, 0x08, 0x7E, 0x09, 0x02}, "Lettre f minuscule"),
            new FontCharacterDescriptor( 103, 'g', new byte[]{ 0x18, 0xA4, 0xA4, 0x9C, 0x78}, "Lettre g minuscule"),
            new FontCharacterDescriptor( 104, 'h', new byte[]{ 0x7F, 0x08, 0x04, 0x04, 0x78}, "Lettre h minuscule"),
            new FontCharacterDescriptor( 105, 'i', new byte[]{ 0x00, 0x44, 0x7D, 0x40, 0x00}, "Lettre i minuscule"),
            new FontCharacterDescriptor( 106, 'j', new byte[]{ 0x20, 0x40, 0x40, 0x3D, 0x00}, "Lettre j minuscule"),
            new FontCharacterDescriptor( 107, 'k', new byte[]{ 0x7F, 0x10, 0x28, 0x44, 0x00}, "Lettre k minuscule"),
            new FontCharacterDescriptor( 108, 'l', new byte[]{ 0x00, 0x41, 0x7F, 0x40, 0x00}, "Lettre l minuscule"),
            new FontCharacterDescriptor( 109, 'm', new byte[]{ 0x7C, 0x04, 0x78, 0x04, 0x78}, "Lettre m minuscule"),
            new FontCharacterDescriptor( 110, 'n', new byte[]{ 0x7C, 0x08, 0x04, 0x04, 0x78}, "Lettre n minuscule"),
            new FontCharacterDescriptor( 111, 'o', new byte[]{ 0x38, 0x44, 0x44, 0x44, 0x38}, "Lettre o minuscule"),
            new FontCharacterDescriptor( 112, 'p', new byte[]{ 0xFC, 0x18, 0x24, 0x24, 0x18}, "Lettre p minuscule"),
            new FontCharacterDescriptor( 113, 'q', new byte[]{ 0x18, 0x24, 0x24, 0x18, 0xFC}, "Lettre q minuscule"),
            new FontCharacterDescriptor( 114, 'r', new byte[]{ 0x7C, 0x08, 0x04, 0x04, 0x08}, "Lettre r minuscule"),
            new FontCharacterDescriptor( 115, 's', new byte[]{ 0x48, 0x54, 0x54, 0x54, 0x24}, "Lettre s minuscule"),
            new FontCharacterDescriptor( 116, 't', new byte[]{ 0x04, 0x04, 0x3F, 0x44, 0x24}, "Lettre t minuscule"),
            new FontCharacterDescriptor( 117, 'u', new byte[]{ 0x3C, 0x40, 0x40, 0x20, 0x7C}, "Lettre u minuscule"),
            new FontCharacterDescriptor( 118, 'v', new byte[]{ 0x1C, 0x20, 0x40, 0x20, 0x1C}, "Lettre v minuscule"),
            new FontCharacterDescriptor( 119, 'w', new byte[]{ 0x3C, 0x40, 0x30, 0x40, 0x3C}, "Lettre w minuscule"),
            new FontCharacterDescriptor( 120, 'x', new byte[]{ 0x44, 0x28, 0x10, 0x28, 0x44}, "Lettre x minuscule"),
            new FontCharacterDescriptor( 121, 'y', new byte[]{ 0x4C, 0x90, 0x90, 0x90, 0x7C}, "Lettre y minuscule"),
            new FontCharacterDescriptor( 122, 'z', new byte[]{ 0x44, 0x64, 0x54, 0x4C, 0x44}, "Lettre z minuscule"),
            new FontCharacterDescriptor( 123, '{', new byte[]{ 0x00, 0x08, 0x36, 0x41, 0x00}, "Caractère {"),
            new FontCharacterDescriptor( 124, '|', new byte[]{ 0x00, 0x00, 0x77, 0x00, 0x00}, "Caractère |"),
            new FontCharacterDescriptor( 125, '}', new byte[]{ 0x00, 0x41, 0x36, 0x08, 0x00}, "Caractère }"),
            new FontCharacterDescriptor( 126, '~', new byte[]{ 0x02, 0x01, 0x02, 0x04, 0x02}, "Caractère ~"),
            new FontCharacterDescriptor( 127, '⌂', new byte[]{ 0x3C, 0x26, 0x23, 0x26, 0x3C}, "Caractère ⌂"),
            new FontCharacterDescriptor( 128, 'Ç', new byte[]{ 0x00, 0x00, 0x00, 0x00, 0x00}, "Caractère Ç"),
            new FontCharacterDescriptor( 129, 'ü', new byte[]{ 0x00, 0x00, 0x00, 0x00, 0x00}, "Caractère ü"),
            new FontCharacterDescriptor( 130, 'é', new byte[]{ 0x00, 0x00, 0x00, 0x00, 0x00}, "Caractère é"),
            new FontCharacterDescriptor( 131, 'â', new byte[]{ 0x00, 0x00, 0x00, 0x00, 0x00}, "Caractère â"),
            new FontCharacterDescriptor( 132, 'ä', new byte[]{ 0x00, 0x00, 0x00, 0x00, 0x00}, "Caractère ä"),
            new FontCharacterDescriptor( 133, 'à', new byte[]{ 0x00, 0x00, 0x00, 0x00, 0x00}, "Caractère à"),
            new FontCharacterDescriptor( 134, 'å', new byte[]{ 0x00, 0x00, 0x00, 0x00, 0x00}, "Caractère å"),
            new FontCharacterDescriptor( 135, 'ç', new byte[]{ 0x00, 0x00, 0x00, 0x00, 0x00}, "Caractère ç"),
            new FontCharacterDescriptor( 136, 'ê', new byte[]{ 0x00, 0x00, 0x00, 0x00, 0x00}, "Caractère ê"),
            new FontCharacterDescriptor( 137, 'ë', new byte[]{ 0x00, 0x00, 0x00, 0x00, 0x00}, "Caractère ë"),
            new FontCharacterDescriptor( 138, 'è', new byte[]{ 0x00, 0x00, 0x00, 0x00, 0x00}, "Caractère è"),
            new FontCharacterDescriptor( 139, 'ï', new byte[]{ 0x00, 0x00, 0x00, 0x00, 0x00}, "Caractère ï"),
            new FontCharacterDescriptor( 140, 'î', new byte[]{ 0x00, 0x00, 0x00, 0x00, 0x00}, "Caractère î"),
            new FontCharacterDescriptor( 141, 'ì', new byte[]{ 0x00, 0x00, 0x00, 0x00, 0x00}, "Caractère ì"),
            new FontCharacterDescriptor( 142, 'Ä', new byte[]{ 0x00, 0x00, 0x00, 0x00, 0x00}, "Caractère Ä"),
            new FontCharacterDescriptor( 143, 'Å', new byte[]{ 0x00, 0x00, 0x00, 0x00, 0x00}, "Caractère Å"),
            new FontCharacterDescriptor( 144, 'É', new byte[]{ 0x00, 0x00, 0x00, 0x00, 0x00}, "Caractère É"),
            new FontCharacterDescriptor( 145, 'æ', new byte[]{ 0x00, 0x00, 0x00, 0x00, 0x00}, "Caractère æ"),
            new FontCharacterDescriptor( 146, 'Æ', new byte[]{ 0x00, 0x00, 0x00, 0x00, 0x00}, "Caractère Æ"),
            new FontCharacterDescriptor( 147, 'ô', new byte[]{ 0x00, 0x00, 0x00, 0x00, 0x00}, "Caractère ô"),
            new FontCharacterDescriptor( 148, 'ö', new byte[]{ 0x00, 0x00, 0x00, 0x00, 0x00}, "Caractère ö"),
            new FontCharacterDescriptor( 149, 'ò', new byte[]{ 0x00, 0x00, 0x00, 0x00, 0x00}, "Caractère ò"),
            new FontCharacterDescriptor( 150, 'û', new byte[]{ 0x00, 0x00, 0x00, 0x00, 0x00}, "Caractère û"),
            new FontCharacterDescriptor( 151, 'ù', new byte[]{ 0x00, 0x00, 0x00, 0x00, 0x00}, "Caractère ù"),
            new FontCharacterDescriptor( 152, 'ÿ', new byte[]{ 0x00, 0x00, 0x00, 0x00, 0x00}, "Caractère ÿ"),
            new FontCharacterDescriptor( 153, 'Ö', new byte[]{ 0x00, 0x00, 0x00, 0x00, 0x00}, "Caractère Ö"),
            new FontCharacterDescriptor( 154, 'Ü', new byte[]{ 0x00, 0x00, 0x00, 0x00, 0x00}, "Caractère Ü"),
            new FontCharacterDescriptor( 155, 'ø', new byte[]{ 0x00, 0x00, 0x00, 0x00, 0x00}, "Caractère ø"),
            new FontCharacterDescriptor( 156, '£', new byte[]{ 0x00, 0x00, 0x00, 0x00, 0x00}, "Caractère £"),
            new FontCharacterDescriptor( 157, 'Ø', new byte[]{ 0x00, 0x00, 0x00, 0x00, 0x00}, "Caractère Ø"),
            new FontCharacterDescriptor( 158, '×', new byte[]{ 0x00, 0x00, 0x00, 0x00, 0x00}, "Caractère ×"),
            new FontCharacterDescriptor( 159, 'ƒ', new byte[]{ 0x00, 0x00, 0x00, 0x00, 0x00}, "Caractère ƒ"),
            new FontCharacterDescriptor( 160, 'á', new byte[]{ 0x00, 0x00, 0x00, 0x00, 0x00}, "Caractère á"),
            new FontCharacterDescriptor( 161, 'í', new byte[]{ 0x00, 0x00, 0x00, 0x00, 0x00}, "Caractère í"),
            new FontCharacterDescriptor( 162, 'ó', new byte[]{ 0x00, 0x00, 0x00, 0x00, 0x00}, "Caractère ó"),
            new FontCharacterDescriptor( 163, 'ú', new byte[]{ 0x00, 0x00, 0x00, 0x00, 0x00}, "Caractère ú"),
            new FontCharacterDescriptor( 164, 'ñ', new byte[]{ 0x00, 0x00, 0x00, 0x00, 0x00}, "Caractère ñ"),
            new FontCharacterDescriptor( 165, 'Ñ', new byte[]{ 0x00, 0x00, 0x00, 0x00, 0x00}, "Caractère Ñ"),
            new FontCharacterDescriptor( 166, 'ª', new byte[]{ 0x00, 0x00, 0x00, 0x00, 0x00}, "Caractère ª"),
            new FontCharacterDescriptor( 167, 'º', new byte[]{ 0x00, 0x00, 0x00, 0x00, 0x00}, "Caractère º"),
            new FontCharacterDescriptor( 168, '¿', new byte[]{ 0x00, 0x00, 0x00, 0x00, 0x00}, "Caractère ¿"),
            new FontCharacterDescriptor( 169, '®', new byte[]{ 0x00, 0x00, 0x00, 0x00, 0x00}, "Caractère ®"),
            new FontCharacterDescriptor( 170, '¬', new byte[]{ 0x00, 0x00, 0x00, 0x00, 0x00}, "Caractère ¬"),
            new FontCharacterDescriptor( 171, '½', new byte[]{ 0x00, 0x00, 0x00, 0x00, 0x00}, "Caractère ½"),
            new FontCharacterDescriptor( 172, '¼', new byte[]{ 0x00, 0x00, 0x00, 0x00, 0x00}, "Caractère ¼"),
            new FontCharacterDescriptor( 173, '¡', new byte[]{ 0x00, 0x00, 0x00, 0x00, 0x00}, "Caractère ¡"),
            new FontCharacterDescriptor( 174, '«', new byte[]{ 0x00, 0x00, 0x00, 0x00, 0x00}, "Caractère «"),
            new FontCharacterDescriptor( 175, '»', new byte[]{ 0x00, 0x00, 0x00, 0x00, 0x00}, "Caractère »"),
            new FontCharacterDescriptor( 176, '░', new byte[]{ 0x00, 0x00, 0x00, 0x00, 0x00}, "Caractère ░"),
            new FontCharacterDescriptor( 177, '▒', new byte[]{ 0x00, 0x00, 0x00, 0x00, 0x00}, "Caractère ▒"),
            new FontCharacterDescriptor( 178, '▓', new byte[]{ 0x00, 0x00, 0x00, 0x00, 0x00}, "Caractère ▓"),
            new FontCharacterDescriptor( 179, '│', new byte[]{ 0x00, 0x00, 0x00, 0x00, 0x00}, "Caractère │"),
            new FontCharacterDescriptor( 180, '┤', new byte[]{ 0x00, 0x00, 0x00, 0x00, 0x00}, "Caractère ┤"),
            new FontCharacterDescriptor( 181, 'Á', new byte[]{ 0x00, 0x00, 0x00, 0x00, 0x00}, "Caractère Á"),
            new FontCharacterDescriptor( 182, 'Â', new byte[]{ 0x00, 0x00, 0x00, 0x00, 0x00}, "Caractère Â"),
            new FontCharacterDescriptor( 183, 'À', new byte[]{ 0x00, 0x00, 0x00, 0x00, 0x00}, "Caractère À"),
            new FontCharacterDescriptor( 184, '©', new byte[]{ 0x00, 0x00, 0x00, 0x00, 0x00}, "Caractère ©"),
            new FontCharacterDescriptor( 185, '╣', new byte[]{ 0x00, 0x00, 0x00, 0x00, 0x00}, "Caractère ╣"),
            new FontCharacterDescriptor( 186, '║', new byte[]{ 0x00, 0x00, 0x00, 0x00, 0x00}, "Caractère ║"),
            new FontCharacterDescriptor( 187, '╗', new byte[]{ 0x00, 0x00, 0x00, 0x00, 0x00}, "Caractère ╗"),
            new FontCharacterDescriptor( 188, '╝', new byte[]{ 0x00, 0x00, 0x00, 0x00, 0x00}, "Caractère ╝"),
            new FontCharacterDescriptor( 189, '¢', new byte[]{ 0x00, 0x00, 0x00, 0x00, 0x00}, "Caractère ¢"),
            new FontCharacterDescriptor( 190, '¥', new byte[]{ 0x00, 0x00, 0x00, 0x00, 0x00}, "Caractère ¥"),
            new FontCharacterDescriptor( 191, '┐', new byte[]{ 0x00, 0x00, 0x00, 0x00, 0x00}, "Caractère ┐"),
            new FontCharacterDescriptor( 192, '└', new byte[]{ 0x00, 0x00, 0x00, 0x00, 0x00}, "Caractère └"),
            new FontCharacterDescriptor( 193, '┴', new byte[]{ 0x00, 0x00, 0x00, 0x00, 0x00}, "Caractère ┴"),
            new FontCharacterDescriptor( 194, '┬', new byte[]{ 0x00, 0x00, 0x00, 0x00, 0x00}, "Caractère ┬"),
            new FontCharacterDescriptor( 195, '├', new byte[]{ 0x00, 0x00, 0x00, 0x00, 0x00}, "Caractère ├"),
            new FontCharacterDescriptor( 196, '─', new byte[]{ 0x00, 0x00, 0x00, 0x00, 0x00}, "Caractère ─"),
            new FontCharacterDescriptor( 197, '┼', new byte[]{ 0x00, 0x00, 0x00, 0x00, 0x00}, "Caractère ┼"),
            new FontCharacterDescriptor( 198, 'ã', new byte[]{ 0x00, 0x00, 0x00, 0x00, 0x00}, "Caractère ã"),
            new FontCharacterDescriptor( 199, 'Ã', new byte[]{ 0x00, 0x00, 0x00, 0x00, 0x00}, "Caractère Ã"),
            new FontCharacterDescriptor( 200, '╚', new byte[]{ 0x00, 0x00, 0x00, 0x00, 0x00}, "Caractère ╚"),
            new FontCharacterDescriptor( 201, '╔', new byte[]{ 0x00, 0x00, 0x00, 0x00, 0x00}, "Caractère ╔"),
            new FontCharacterDescriptor( 202, '╩', new byte[]{ 0x00, 0x00, 0x00, 0x00, 0x00}, "Caractère ╩"),
            new FontCharacterDescriptor( 203, '╦', new byte[]{ 0x00, 0x00, 0x00, 0x00, 0x00}, "Caractère ╦"),
            new FontCharacterDescriptor( 204, '╠', new byte[]{ 0x00, 0x00, 0x00, 0x00, 0x00}, "Caractère ╠"),
            new FontCharacterDescriptor( 205, '═', new byte[]{ 0x00, 0x00, 0x00, 0x00, 0x00}, "Caractère ═"),
            new FontCharacterDescriptor( 206, '╬', new byte[]{ 0x00, 0x00, 0x00, 0x00, 0x00}, "Caractère ╬"),
            new FontCharacterDescriptor( 207, '¤', new byte[]{ 0x00, 0x00, 0x00, 0x00, 0x00}, "Caractère ¤"),
            new FontCharacterDescriptor( 208, 'ð', new byte[]{ 0x00, 0x00, 0x00, 0x00, 0x00}, "Caractère ð"),
            new FontCharacterDescriptor( 209, 'Ð', new byte[]{ 0x00, 0x00, 0x00, 0x00, 0x00}, "Caractère Ð"),
            new FontCharacterDescriptor( 210, 'Ê', new byte[]{ 0x00, 0x00, 0x00, 0x00, 0x00}, "Caractère Ê"),
            new FontCharacterDescriptor( 211, 'Ë', new byte[]{ 0x00, 0x00, 0x00, 0x00, 0x00}, "Caractère Ë"),
            new FontCharacterDescriptor( 212, 'È', new byte[]{ 0x00, 0x00, 0x00, 0x00, 0x00}, "Caractère È"),
            new FontCharacterDescriptor( 213, 'ı', new byte[]{ 0x00, 0x00, 0x00, 0x00, 0x00}, "Caractère ı"),
            new FontCharacterDescriptor( 214, 'Í', new byte[]{ 0x00, 0x00, 0x00, 0x00, 0x00}, "Caractère Í"),
            new FontCharacterDescriptor( 215, 'Î', new byte[]{ 0x00, 0x00, 0x00, 0x00, 0x00}, "Caractère Î"),
            new FontCharacterDescriptor( 216, 'Ï', new byte[]{ 0x00, 0x00, 0x00, 0x00, 0x00}, "Caractère Ï"),
            new FontCharacterDescriptor( 217, '┘', new byte[]{ 0x00, 0x00, 0x00, 0x00, 0x00}, "Caractère ┘"),
            new FontCharacterDescriptor( 218, '┌', new byte[]{ 0x00, 0x00, 0x00, 0x00, 0x00}, "Caractère ┌"),
            new FontCharacterDescriptor( 219, '█', new byte[]{ 0x00, 0x00, 0x00, 0x00, 0x00}, "Caractère █"),
            new FontCharacterDescriptor( 220, '▄', new byte[]{ 0x00, 0x00, 0x00, 0x00, 0x00}, "Caractère ▄"),
            new FontCharacterDescriptor( 221, '¦', new byte[]{ 0x00, 0x00, 0x00, 0x00, 0x00}, "Caractère ¦"),
            new FontCharacterDescriptor( 222, '▬', new byte[]{ 0x00, 0x00, 0x00, 0x00, 0x00}, "Caractère ▬"),
            new FontCharacterDescriptor( 223, '▀', new byte[]{ 0x00, 0x00, 0x00, 0x00, 0x00}, "Caractère ▀"),
            new FontCharacterDescriptor( 224, 'Ó', new byte[]{ 0x00, 0x00, 0x00, 0x00, 0x00}, "Caractère Ó"),
            new FontCharacterDescriptor( 225, 'ß', new byte[]{ 0x00, 0x00, 0x00, 0x00, 0x00}, "Caractère ß"),
            new FontCharacterDescriptor( 226, 'Ô', new byte[]{ 0x00, 0x00, 0x00, 0x00, 0x00}, "Caractère Ô"),
            new FontCharacterDescriptor( 227, 'Ò', new byte[]{ 0x00, 0x00, 0x00, 0x00, 0x00}, "Caractère Ò"),
            new FontCharacterDescriptor( 228, 'õ', new byte[]{ 0x00, 0x00, 0x00, 0x00, 0x00}, "Caractère õ"),
            new FontCharacterDescriptor( 229, 'Õ', new byte[]{ 0x00, 0x00, 0x00, 0x00, 0x00}, "Caractère Õ"),
            new FontCharacterDescriptor( 230, 'µ', new byte[]{ 0x00, 0x00, 0x00, 0x00, 0x00}, "Caractère µ"),
            new FontCharacterDescriptor( 231, 'þ', new byte[]{ 0x00, 0x00, 0x00, 0x00, 0x00}, "Caractère þ"),
            new FontCharacterDescriptor( 232, 'Þ', new byte[]{ 0x00, 0x00, 0x00, 0x00, 0x00}, "Caractère Þ"),
            new FontCharacterDescriptor( 233, 'Ú', new byte[]{ 0x00, 0x00, 0x00, 0x00, 0x00}, "Caractère Ú"),
            new FontCharacterDescriptor( 234, 'Û', new byte[]{ 0x00, 0x00, 0x00, 0x00, 0x00}, "Caractère Û"),
            new FontCharacterDescriptor( 235, 'Ù', new byte[]{ 0x00, 0x00, 0x00, 0x00, 0x00}, "Caractère Ù"),
            new FontCharacterDescriptor( 236, 'ý', new byte[]{ 0x00, 0x00, 0x00, 0x00, 0x00}, "Caractère ý"),
            new FontCharacterDescriptor( 237, 'Ý', new byte[]{ 0x00, 0x00, 0x00, 0x00, 0x00}, "Caractère Ý"),
            new FontCharacterDescriptor( 238, '¯', new byte[]{ 0x00, 0x00, 0x00, 0x00, 0x00}, "Caractère ¯"),
            new FontCharacterDescriptor( 239, '´', new byte[]{ 0x00, 0x00, 0x00, 0x00, 0x00}, "Caractère ´"),
            new FontCharacterDescriptor( 240, ' ', new byte[]{ 0x00, 0x00, 0x00, 0x00, 0x00}, "Caractère  "),
            new FontCharacterDescriptor( 241, '±', new byte[]{ 0x00, 0x00, 0x00, 0x00, 0x00}, "Caractère ±"),
            new FontCharacterDescriptor( 242, '‗', new byte[]{ 0x00, 0x00, 0x00, 0x00, 0x00}, "Caractère ‗"),
            new FontCharacterDescriptor( 243, '¾', new byte[]{ 0x00, 0x00, 0x00, 0x00, 0x00}, "Caractère ¾"),
            new FontCharacterDescriptor( 244, '¶', new byte[]{ 0x00, 0x00, 0x00, 0x00, 0x00}, "Caractère ¶"),
            new FontCharacterDescriptor( 245, '§', new byte[]{ 0x00, 0x00, 0x00, 0x00, 0x00}, "Caractère §"),
            new FontCharacterDescriptor( 246, '÷', new byte[]{ 0x00, 0x00, 0x00, 0x00, 0x00}, "Caractère ÷"),
            new FontCharacterDescriptor( 247, '¸', new byte[]{ 0x00, 0x00, 0x00, 0x00, 0x00}, "Caractère ¸"),
            new FontCharacterDescriptor( 248, '°', new byte[]{ 0x00, 0x00, 0x00, 0x00, 0x00}, "Caractère °"),
            new FontCharacterDescriptor( 249, '¨', new byte[]{ 0x00, 0x00, 0x00, 0x00, 0x00}, "Caractère ¨"),
            new FontCharacterDescriptor( 250, '·', new byte[]{ 0x00, 0x00, 0x00, 0x00, 0x00}, "Caractère ·"),
            new FontCharacterDescriptor( 251, '¹', new byte[]{ 0x00, 0x00, 0x00, 0x00, 0x00}, "Caractère ¹"),
            new FontCharacterDescriptor( 252, '³', new byte[]{ 0x00, 0x00, 0x00, 0x00, 0x00}, "Caractère ³"),
            new FontCharacterDescriptor( 253, '²', new byte[]{ 0x00, 0x00, 0x00, 0x00, 0x00}, "Caractère ²"),
            new FontCharacterDescriptor( 254, '■', new byte[]{ 0x00, 0x00, 0x00, 0x00, 0x00}, "Caractère ■"),
            new FontCharacterDescriptor( 255, ' ', new byte[]{ 0x00, 0x00, 0x00, 0x00, 0x00}, "Caractère  ")

        };

    }

}
