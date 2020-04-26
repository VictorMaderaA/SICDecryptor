using System;
using System.Text.RegularExpressions;
using System.Text;

namespace SICLib.Manager
{
    public class StringBuilder
    {

        private string _line;

        private readonly string RXAsciiControlChars = "[\x00-\x1F]";
        private readonly string RXAsciiExtendedChars = "[\x80-\xFF]";
        private readonly string RXAsciiExtraSimbolsChars = "[\x21-\x2F]|[\x3A-\x40]|[\x5B-\x60]|[\x7b-\x7F]";

        private readonly string RXAlphaNumericChars = "[a-zA-Z0-9]";
        private readonly string RXHexChars = "[\x30-\x39]|[\x41-\x46]|[\x61-\x66]";
        private readonly string RXCommonLettersChars = "[E|A|O|S|R|T]";
        private readonly string RXSpaceChar = @"[\x20]";

        private readonly string RXHexKey = @"([\s|\-|.|_|:]*[\x30-\x39]|[\x41-\x46]|[\x61-\x66]){2,}";
        private readonly string RXWords = @"([^\W_]+[^\s,]*)";



        public StringBuilder(string line)
        {
            _line = string.Copy(line);
        }

        public StringBuilder New(string line)
        {
            _line = string.Copy(line);
            return this;
        }

        public StringBuilder RemoveNewLines()
        {
            _line = _line.Replace(Environment.NewLine, " ");
            return this;
        }

        public StringBuilder RemoveChar(char c)
        {
            _line = _line.Replace(c, ' ');
            return this;
        }

        public StringBuilder RemoveAsciiControllChars()
        {
            _line = Regex.Replace(_line, RXAsciiControlChars, string.Empty);
            return this;
        }

        public StringBuilder RemoveAsciiExtendedChars()
        {
            _line = Regex.Replace(_line, RXAsciiExtendedChars, string.Empty);
            return this;
        }

        public StringBuilder RemoveAsciiExtraSimbolsChars()
        {
            _line = Regex.Replace(_line, RXAsciiExtraSimbolsChars, string.Empty);
            return this;
        }

        public StringBuilder RemoveNoneAlphanumericChars()
        {
            var sb = new System.Text.StringBuilder();
            foreach(var c in _line)
                if (char.IsLetterOrDigit(c))
                    sb.Append(c);
                else if(char.IsWhiteSpace(c))
                    sb.Append('_');
            _line = sb.ToString().Replace("_"," ");
            //var matches = Regex.Matches(_line, RXAlphaNumericChars + "+");
            //var s = string.Empty;
            //foreach (var m in matches)
            //    s += m.ToString() + " ";
            //_line = s;
            return this;
        }



        public int CountChars()
        {
            return _line.Length;
        }


        public int CountAlphanumericChars()
        {
            int x = 0;
            foreach (var c in _line)
                if (Regex.IsMatch(c.ToString(), RXAlphaNumericChars, RegexOptions.IgnoreCase))
                    x++;
            return x;
        }

        public int CountNoAlphanumericChars()
        {
            int x = 0;
            foreach (var c in _line)
                if (!Regex.IsMatch(c.ToString(), RXAlphaNumericChars, RegexOptions.IgnoreCase))
                    x++;
            return x;
        }



        public int CountHexadecimalChars()
        {
            int x = 0;
            foreach (var c in _line)
                if (Regex.IsMatch(c.ToString(), RXHexChars, RegexOptions.IgnoreCase))
                    x++;
            return x;
        }

        public int CountNoHexadecimalChars()
        {
            int x = 0;
            foreach (var c in _line)
                if (!Regex.IsMatch(c.ToString(), RXHexChars, RegexOptions.IgnoreCase))
                    x++;
            return x;
        }

        public int CountChar(string chr)
        {
            int x = 0;
            foreach (var c in _line)
                if (Regex.IsMatch(c.ToString(), chr, RegexOptions.IgnoreCase))
                    x++;
            return x;
        }

        public bool CountChar(string chr, int max)
        {
            int x = 0;
            foreach (var c in _line)
                if (Regex.IsMatch(c.ToString(), chr, RegexOptions.IgnoreCase))
                {
                    x++;
                    if (x > max)
                        return true;
                }
            return false;
        }

        public string GetString()
        {
            return _line;
        }


    }
}
