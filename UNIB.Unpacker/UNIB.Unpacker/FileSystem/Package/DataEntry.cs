using System;

namespace UNIB.Unpacker
{
    class DataEntry
    {
        public Int32 dwDecompressedSize { get; set; }
        public Int32 dwCompressedSize { get; set; }
        public UInt32 dwOffset { get; set; }
        public String m_FileName { get; set; } // 0x40 bytes
    }
}
