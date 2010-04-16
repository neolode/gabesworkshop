using System;
using System.Collections;
using System.Text;

namespace lightAsp.WebServer
{
    internal class ByteString
    {
        private byte[] _bytes;
        private int _length;
        private int _offset;

        public ByteString(byte[] bytes, int offset, int length)
        {
            _bytes = bytes;
            _offset = offset;
            _length = length;
        }

        public byte[] Bytes
        {
            get { return _bytes; }
        }

        public bool IsEmpty
        {
            get
            {
                if (_bytes != null)
                {
                    return (_length == 0);
                }
                return true;
            }
        }

        public byte this[int index]
        {
            get { return _bytes[_offset + index]; }
        }

        public int Length
        {
            get { return _length; }
        }

        public int Offset
        {
            get { return _offset; }
        }

        public byte[] GetBytes()
        {
            var dst = new byte[_length];
            if (_length > 0)
            {
                Buffer.BlockCopy(_bytes, _offset, dst, 0, _length);
            }
            return dst;
        }

        public string GetString()
        {
            return GetString(Encoding.UTF8);
        }

        public string GetString(Encoding enc)
        {
            if (IsEmpty)
            {
                return string.Empty;
            }
            return enc.GetString(_bytes, _offset, _length);
        }

        public int IndexOf(char ch)
        {
            return IndexOf(ch, 0);
        }

        public int IndexOf(char ch, int offset)
        {
            for (int i = offset; i < _length; i++)
            {
                if (this[i] == ((byte) ch))
                {
                    return i;
                }
            }
            return -1;
        }

        public ByteString[] Split(char sep)
        {
            var list = new ArrayList();
            int offset = 0;
            while (offset < _length)
            {
                int index = IndexOf(sep, offset);
                if (index < 0)
                {
                    break;
                }
                list.Add(Substring(offset, index - offset));
                offset = index + 1;
                while ((this[offset] == ((byte) sep)) && (offset < _length))
                {
                    offset++;
                }
            }
            if (offset < _length)
            {
                list.Add(Substring(offset));
            }
            int count = list.Count;
            var strArray = new ByteString[count];
            for (int i = 0; i < count; i++)
            {
                strArray[i] = (ByteString) list[i];
            }
            return strArray;
        }

        public ByteString Substring(int offset)
        {
            return Substring(offset, _length - offset);
        }

        public ByteString Substring(int offset, int len)
        {
            return new ByteString(_bytes, _offset + offset, len);
        }
    }
}