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

        private readonly string RXHexKey = @"([\s|\-|.|_|:]*[\x30-\x39]|[\x41-\x46]|[\x61-\x66]){2,}";
        private readonly string RXWords = @"([^\W_]+[^\s,]*)";



        public StringBuilder(string line)
        {
            _line = line;
        }

        public StringBuilder New(string line)
        {
            _line = line;
            return this;
        }

        public StringBuilder RemoveNewLines()
        {
            _line = _line.Replace(Environment.NewLine, " ");
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
            string regex = RXAsciiExtraSimbolsChars;
            _line = Regex.Replace(_line, regex, string.Empty);
            return this;
        }

        public StringBuilder RemoveNoneAlphanumericChars()
        {
            var sb = new System.Text.StringBuilder();
            foreach(var c in _line)
                if (Regex.IsMatch(c.ToString(), RXAlphaNumericChars + @"|[\s]"))
                    sb.Append(c);
            _line = sb.ToString();
            return this;
        }

        public StringBuilder RemoveNoneHexChars()
        {
            var sb = new System.Text.StringBuilder();
            foreach (var c in _line)
                if (Regex.IsMatch(c.ToString(), RXHexChars + @"|[\s]"))
                    sb.Append(c);
            _line = sb.ToString();
            return this;
        }

        public StringBuilder RemoveNoneHexKey()
        {
            var matches = Regex.Matches(_line, RXHexKey);
            var s = string.Empty;
            foreach (var m in matches)
                s += m.ToString() + " ";
            _line = s;
            return this;
        }

        public int CountAlphanumericChars()
        {
            return Regex.Matches(_line, RXAlphaNumericChars).Count;
        }

        public int CountHexadecimalChars()
        {
            return Regex.Matches(_line, RXHexChars).Count;
        }

        public int CountCommonChars()
        {
            return Regex.Matches(_line, RXCommonLettersChars, RegexOptions.IgnoreCase).Count;
        }

        public int CountWords()
        {
            return Regex.Matches(_line, RXWords).Count;
        }

        public int CountHexBytes()
        {
            return Regex.Matches(_line, RXHexKey).Count;
        }

        public string GetString()
        {
            return _line;
        }



    }
}
