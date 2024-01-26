using System;
using System.IO;

namespace UNIB.Unpacker
{
    class Program
    {
        private static String m_Title = "UNDER NIGHT IN-BIRTH II Sys Celes Unpacker";

        private static String[] m_IndexFiles = {
            "oooFoOtuzqeqoruxquzra",    // ___T_Chinese
            "ooxoosCsoxporpsooyvcM",    // ___S_Chinese
            "oMtaqooqotvvonnpwmq",      // ___English
            "eohGonbwaokebajjok",       // ___Korean
            "olotkxLluoootokrin",       // ___French
            "Ywjfsooxawfaoxgode",       // ___German
            "ojombmooogjopfjJugb",      // ___Italian
            "oagyeLboblhoyoitxbg",      // ___Spanish
            //"oooFsuwcbotwzswbtc",     // Empty
            "VycozuyzchnLimfnf3y",      // BattleRes
            "fyLym4ozcfychziVunn",      // BattleRes
            "Pshszb7ogFztcohwstw",      // BattleRes
            "fmjisrkojmp",              // bg
            "bswPtcotwzua",             // Bgm
            "hexeojmpimrjs",            // data
            "lzwp1onbeaejbkCh",         // grpdat
            "7osxauxctdVgeupi",         // grpdat
            "lgMotvl9rxojuzko",         // grpdat
            //"vxlj0zrolookgtMu",       // Empty
            //"dzrao7bpruqmfuxS",       // Empty
            "cfopiyiGczyzhc",           // Movie
            "kluioyxovozlort",          // script
            "rhmekdhnoed",              // se
            "bswGtcotwzs5",             // se
            "iz3Nadozdgaj",             // se
            "phkUh1ogqngk",             // se
            "wnrBoxoorun9",             // se
            "veIxqtuhovybuyd",          // Shader
            "rcwWiiqjmxpmojs",          // System
            "IQHoknqjnskt"              // DLC
        };

        static void Main(String[] args)
        {
            Console.Title = m_Title;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(m_Title);
            Console.WriteLine("(c) 2024 Ekey (h4x0r) / v{0}\n", Utils.iGetApplicationVersion());
            Console.ResetColor();

            if (args.Length != 2)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("[Usage]");
                Console.WriteLine("    UNIB.Unpacker <m_Directory> <m_OutDirectory>");
                Console.WriteLine("    m_DataDirectory - Directory of data");
                Console.WriteLine("    m_OutDirectory - Destination directory\n");
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("[Examples]");
                Console.WriteLine("    UNIB.Unpacker E:\\UNDER NIGHT IN-BIRTH II Sys Celes\\d D:\\Unpacked");
                Console.ResetColor();
                return;
            }

            String m_Input = Utils.iCheckArgumentsPath(args[0]);
            String m_Output = Utils.iCheckArgumentsPath(args[1]);

            foreach (var m_IndexFile in m_IndexFiles)
            {
                if (File.Exists(m_Input + m_IndexFile))
                {
                    DataUnpack.iDoIt(m_Input + m_IndexFile, m_Output);
                }
                else
                {
                    Utils.iSetError("[ERROR]: Unable to read index file -> " + m_Input + m_IndexFile);
                }
            }
        }
    }
}
