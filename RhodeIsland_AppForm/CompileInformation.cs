using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace RhodeIsland_AppForm
{
    class CompileInformation
    {
        public static dynamic ChoosenOperator = "";
        public static dynamic ChoosenOperator_Prof = "";
        public static string Name = "";
        public static int Rarity = 0;
        public static string Profession = "";
        public static string SubProfession = "";
        public static string NationID = "";
        public static string PrehabKey = "";
        public static int  SecurityCode= 0;
        public static string Sec_Class = "";
        public static string Faction = "";
        public static int NumberofOps = 0;
        public static string Squad = "";
        ///////////////////////////////////////
        public static string Clinical = "";
        public CompileInformation(dynamic OpData, dynamic OPProfile,int OpNumbers)
        {
            ChoosenOperator = OpData;
            ChoosenOperator_Prof = OPProfile;
            NumberofOps = OpNumbers;
        }
        public void ApplyInformation()
        {
            Name = ChoosenOperator.Value.name;
            SecurityCode = ChoosenOperator.Value.rarity + 1;
            Profession = ChoosenOperator.Value.profession;
            SubProfession = ChoosenOperator.Value.subProfessionId;
            Squad = ChoosenOperator.Value.teamdId;
            if(ChoosenOperator.Value.teamId != null)
            {
                Squad = ChoosenOperator.Value.teamId;
            }
            else
            {
                Squad = "[REDACTED]";
            }
            if (ChoosenOperator.Value.nationId != null)
            {
                NationID = ChoosenOperator.Value.nationId;
            }
            else
            {
                NationID = "[REDACTED]";
            }
            Faction = ChoosenOperator.Value.groupId;
            //PrehabKey = ChoosenOperator.Name;
            //PrehabKey = ChoosenOperator.Value.phases[0].characterPrefabKey;
            //ChoosenOperator.Value.phases[0].attributesKeyFrames[0].data.atk;
            foreach (var phase in ChoosenOperator.Value.phases)
            {
                PrehabKey = phase.characterPrefabKey;
            }
            /////
            try
            {
                Clinical = ChoosenOperator_Prof.Value.storyTextAudio[3].stories[0].storyText;
            }
            catch(Exception e)
            {
                Clinical = "Clinical Data Not Available.";
            }

            SecurityClearance();
        }
        public void SecurityClearance()
        {
            switch(SecurityCode)
            {
                case 1:
                    Sec_Class = "rar-class-001";
                    break;
                case 2:
                    Sec_Class = "rar-class-002";
                    break;
                case 3:
                    Sec_Class = "rar-class-003";
                    break;
                case 4:
                    Sec_Class = "rar-class-004";
                    break;
                case 5:
                    Sec_Class = "rar-class-005";
                    break;
                case 6:
                    Sec_Class = "rar-class-006";
                    break;
            }
        }
    }
}
