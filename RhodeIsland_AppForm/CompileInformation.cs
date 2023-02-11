using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RhodeIsland_AppForm
{
    class CompileInformation
    {
        public static dynamic ChoosenOperator = "";
        public static string Name = "";
        public static int Rarity = 0;
        public static string Profession = "";
        public static string SubProfession = "";
        public static string NationID = "";
        public CompileInformation(dynamic OpData)
        {
            ChoosenOperator = OpData;
        }
        public void ApplyInformation()
        {
            Name = ChoosenOperator.Value.name;
            Rarity = ChoosenOperator.Value.rarity + 1;
            Profession = ChoosenOperator.Value.profession;
            SubProfession = ChoosenOperator.Value.subProfessionId;
            NationID = ChoosenOperator.Value.nationID;
        }

    }
}
