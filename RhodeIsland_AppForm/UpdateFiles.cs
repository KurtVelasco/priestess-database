using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net;

namespace RhodeIsland_AppForm
{
    class UpdateFiles
    {
        private static string ArknightDataBase = $"https://raw.githubusercontent.com/Kengxxiao/ArknightsGameData/master/en_US/gamedata/excel/character_table.json";
        private static string UrlOperateProfile = $"https://raw.githubusercontent.com/Kengxxiao/ArknightsGameData/master/en_US/gamedata/excel/handbook_info_table.json";
        public static dynamic data = "";
        public static string NameFile = "";
        public static bool IfSuccess = true;
        public static void UpdateOperator(string Name)
        {
            NameFile = Name;
            using(WebClient client = new WebClient())
            {
                try
                {
                    if(NameFile == "ArknightDataBase")
                    {
                        data = client.DownloadString(ArknightDataBase);
                    }
                    else
                    {
                        data = client.DownloadString(UrlOperateProfile);
                    }
                    IfSuccess = true;
                    WriteFile();
                }
                catch(Exception e)
                {
                    IfSuccess = false;
                }
            }
     
        }
        public static void WriteFile()
        {
            using (StreamWriter sr = new StreamWriter(NameFile + ".txt", false))
            {
                sr.WriteLine(data);
            }
        }
    }
}
