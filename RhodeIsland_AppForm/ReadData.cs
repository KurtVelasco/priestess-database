using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
namespace RhodeIsland_AppForm
{
    class ReadData
    {
        private static dynamic Operator_Data = "";
        private static dynamic JSONData = "";
        private static dynamic JSONData_Profile = "";
        private static dynamic SelectedOp_Dict = "";
        /// <summary>
        /// ///////////////////////
        /// </summary>
        private static string StoredData = "";
        private static string StoredData_Profile = "";
        private static dynamic SelectedOperator = "";
        public bool FoundOperator = true;
        private static string PrefabKey = "";
        public static int NumberOps = 0;
        public static void ReadFile()
        {
            StoredData = File.ReadAllText("ArknightDatabase.txt");
            JSONData = JsonConvert.DeserializeObject(StoredData);
            StoredData_Profile = File.ReadAllText("ArknightProfiles.JSON");
            JSONData_Profile = JsonConvert.DeserializeObject(StoredData_Profile);
            Operator_Data = JSONData_Profile["handbookDict"];
            NumberOps = ((JToken)Operator_Data).Count();

        }
        public void SearchOperator(string Userinput)
        {
            foreach (var items in JSONData)
            {
                string ValueName = items.Value.name;
                PrefabKey = items.Name;
                string lowerValue = ValueName.ToLower();
                //
                string lower = Userinput.ToLower();
                if (lowerValue == Userinput.ToLower())
                {
                    SelectedOperator = items;
                    break;
                }
                else
                {
                    SelectedOperator = "";
                }
                
            }
            if(SelectedOperator is string)
            {
                FoundOperator = false;
            }
            else
            {
                foreach(var items in Operator_Data)
                {
                    if(items.Name == PrefabKey)
                    {
                        SelectedOp_Dict = items;
                        break;
                    }
                    else
                    {
                        SelectedOp_Dict = "";
                    }
                }
                FoundOperator = true;
                CompileInformation NewInfo = new CompileInformation(SelectedOperator,SelectedOp_Dict,NumberOps);
                NewInfo.ApplyInformation();
            }
       
        }
   
        
    }
}
