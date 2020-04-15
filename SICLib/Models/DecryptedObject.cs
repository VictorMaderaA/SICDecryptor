using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SICLib.Models
{
    public class DecryptedObject
    {

		private byte[] _bytes = null;
		public byte[] Bytes
		{
			get { return _bytes; }
			set { _bytes = value; }
		}


		private byte[] _keyUsed;
		public byte[] KeyUsed
		{
			get { return _keyUsed; }
			set { _keyUsed = value; }
		}


		public DecryptedObject(byte[] bytes, byte[] keyUsed = null)
		{
			_bytes = bytes;
			_keyUsed = keyUsed;
		}

		public string GetDecodedString(Encoding encoder)
		{
			if (_bytes == null) return string.Empty;
			return encoder.GetString(_bytes);
		}

		public string GetBytesHex()
		{
			return BitConverter.ToString(_bytes);
		}

		public string GetBytesKeyHex()
		{
			return BitConverter.ToString(_keyUsed);
		}



	}
}
