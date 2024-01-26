using System;

namespace UNIB.Unpacker
{
    class DataHeader
    {
        public Int32 dwTotalFolders { get; set; }
        public Int32 dwTotalFiles { get; set; }
        public UInt32 dwArchiveSize { get; set; }
        public String m_ArchiveName { get; set; } // 0x34 bytes
    }
}
