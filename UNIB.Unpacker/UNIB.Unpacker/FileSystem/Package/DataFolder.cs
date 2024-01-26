using System;

namespace UNIB.Unpacker
{
    class DataFolder
    {
        public Int32 dwFilesInFolder { get; set; }
        public Int32 dwUnknown1 { get; set; } // Folder Offset ???
        public Int32 dwUnknown2 { get; set; } // Folder Size ???
        public String m_FolderName { get; set; } // 0x74 bytes
    }
}
