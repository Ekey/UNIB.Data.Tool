using System;
using System.IO;
using System.Text;
using System.Collections.Generic;

namespace UNIB.Unpacker
{
    class DataUnpack
    {
        private static List<DataFolder> m_FoldersTable = new List<DataFolder>();
        private static List<DataEntry> m_EntryTable = new List<DataEntry>();

        public static void iDoIt(String m_IndexFile, String m_DstFolder)
        {
            using (FileStream TIndexStream = File.OpenRead(m_IndexFile))
            {
                var m_Header = new DataHeader();

                m_Header.dwTotalFolders = TIndexStream.ReadInt32();
                m_Header.dwTotalFiles = TIndexStream.ReadInt32();
                m_Header.dwArchiveSize = TIndexStream.ReadUInt32();
                m_Header.m_ArchiveName = Encoding.ASCII.GetString(TIndexStream.ReadBytes(52)).TrimEnd('\0');

                m_FoldersTable.Clear();
                for (Int32 i = 0; i < m_Header.dwTotalFolders; i++)
                {
                    var m_Folder = new DataFolder();

                    m_Folder.dwFilesInFolder = TIndexStream.ReadInt32();
                    m_Folder.dwUnknown1 = TIndexStream.ReadInt32();
                    m_Folder.dwUnknown2 = TIndexStream.ReadInt32();
                    m_Folder.m_FolderName = Encoding.ASCII.GetString(TIndexStream.ReadBytes(116)).TrimEnd('\0');

                    m_FoldersTable.Add(m_Folder);
                }

                TIndexStream.Seek(4, SeekOrigin.Current);

                m_EntryTable.Clear();
                for (Int32 i = 0; i < m_Header.dwTotalFiles; i++)
                {
                    var m_Entry = new DataEntry();

                    m_Entry.dwDecompressedSize = TIndexStream.ReadInt32();
                    m_Entry.dwCompressedSize = TIndexStream.ReadInt32();
                    m_Entry.dwOffset = TIndexStream.ReadUInt32();
                    m_Entry.m_FileName = Encoding.ASCII.GetString(TIndexStream.ReadBytes(64)).TrimEnd('\0');

                    m_EntryTable.Add(m_Entry);

                    if (TIndexStream.Length == TIndexStream.Position)
                    {
                        break;
                    }

                    TIndexStream.Seek(4, SeekOrigin.Current);
                }

                using (FileStream TDataStream = File.OpenRead(Path.GetDirectoryName(m_IndexFile) + @"\" + m_Header.m_ArchiveName))
                {
                    Int32 j = 0;
                    foreach (var m_Folder in m_FoldersTable)
                    {
                        for (Int32 i = 0; i < m_Folder.dwFilesInFolder; i++, j++)
                        {
                            String m_FullPath = m_DstFolder + m_Folder.m_FolderName + @"\" + m_EntryTable[j].m_FileName;

                            Utils.iSetInfo("[UNPACKING]: " + m_Folder.m_FolderName + @"\" + m_EntryTable[j].m_FileName);
                            Utils.iCreateDirectory(m_FullPath);

                            TDataStream.Seek(m_EntryTable[j].dwOffset, SeekOrigin.Begin);

                            var lpBuffer = TDataStream.ReadBytes(m_EntryTable[j].dwCompressedSize);

                            File.WriteAllBytes(m_FullPath, lpBuffer);
                        }
                    }

                    TDataStream.Dispose();
                }

                TIndexStream.Dispose();
            }
        }
    }
}
