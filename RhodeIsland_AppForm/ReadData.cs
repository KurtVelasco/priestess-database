using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;

namespace RhodeIsland_AppForm
{
    class ReadData
    {
        public static string StoredData = "";
        public static dynamic JSONData = "";
        public static dynamic SelectedOperator = "";
        public static void ReadFile()
        {
            StoredData = File.ReadAllText("ArknightDatabase.txt");
            JSONData = JsonConvert.DeserializeObject(StoredData);
        }
        public static void SearchOperator(string Userinput)
        {
            foreach (var items in JSONData)
            {
                string ValueName = items.Value.name;
                string lowerValue = ValueName.ToLower();
                //
                string lower = Userinput.ToLower();
                if (lowerValue == Userinput.ToLower())
                {
                    SelectedOperator = items;
                    break;
                } 
                
            }
            if(SelectedOperator == null)
            {
                
            }
            CompileInformation NewInfo = new CompileInformation(SelectedOperator);
            NewInfo.ApplyInformation();
        }
   
        
    }
}
