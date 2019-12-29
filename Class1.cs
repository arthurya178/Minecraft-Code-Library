using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IWshRuntimeLibrary;

namespace Minecraft_Mod
{
    class Class1
    {
        public void Create_Launcher_Profile(string Mod_Name,string JVM,string path,string forge,string modpack_path = "Core\\CoreFile\\")
        {
            string JVM_CLP = locate_reset(JVM);
            string path_CLP = locate_reset(path) + "\\\\" +"lib" + "\\\\" + Mod_Name;
            string B_side = Create_Json(Mod_Name, path_CLP, JVM_CLP, forge);
            if (System.IO.File.Exists(Path.Combine(path_CLP, "launcher_profiles.json")))
            {
                System.IO.File.Copy(Path.Combine(path_CLP, "launcher_profiles.json"), Path.Combine(path, "Core", "CoreFIle", "launcher_profiles.json"),true);
            }
            else
            {
                to_Json(B_side, modpack_path);
            }
        }

        private string locate_reset(string line)
        {
            line = line.Replace("\\", "\\\\");
            return line;
        }

        private string Create_Json(string Mod_Name, string Game_Dir, string javaArgs,string Forge_ver)
        {
            string line =
                $"{{\n" +
                $"  \"clientToken\" : \"\",\n" +
                $"  \"launcherVersion\" : {{\n" +
                $"    \"format\" : 21,\n" +
                $"    \"name\" : \"\",\n" +
                $"    \"profilesFormat\" : 2\n" +
                $"  }},\n" +
                $"  \"profiles\" : {{\n" +
                $"    \"681c73011a4ba62e59ec1a489a69b363\" : {{\n" +
                $"      \"created\" : \"1970-01-02T00:00:00.000Z\",\n" +
                $"      \"icon\" : \"Grass\",\n" +
                $"      \"lastUsed\" : \"1970-01-02T00:00:00.000Z\",\n" +
                $"      \"lastVersionId\" : \"latest-release\",\n" +
                $"      \"name\" : \"\",\n" +
                $"      \"type\" : \"latest-release\"\n" +
                $"    }},\n" +
                $"    \"d13fbc148d51c670c6fe38d42a1806e1\" : {{\n" +
                $"      \"created\" : \"1970-01-01T00:00:00.000Z\",\n" +
                $"      \"icon\" : \"Crafting_Table\",\n" +
                $"      \"lastUsed\" : \"1970-01-01T00:00:00.000Z\",\n" +
                $"      \"lastVersionId\" : \"latest-snapshot\",\n" +
                $"      \"name\" : \"\",\n" +
                $"      \"type\" : \"latest-snapshot\"\n" +
                $"    }},\n" +
                $"    \"{Mod_Name}\" : {{\n" +
                $"      \"gameDir\" :\"{Game_Dir}\",\n" +
                $"      \"javaArgs\" :  \"{javaArgs}\",\n" +
                $"      \"lastUsed\" : \"1970-01-02T01:02:03.000Z\",\n" +
                $"      \"lastVersionId\" : \"{Forge_ver}\",\n" +
                $"      \"name\" : \"{Mod_Name}\",\n" +
                $"      \"type\" : \"\"\n" +
                $"    }}\n" +
                $"  }},\n" +
                $"  \"settings\" : {{\n" +
                $"    \"channel\" : \"release\",\n" +
                $"    \"crashAssistance\" : true,\n" +
                $"    \"enableAnalytics\" : true,\n" +
                $"    \"enableHistorical\" : false,\n" +
                $"    \"enableReleases\" : true,\n" +
                $"    \"enableSnapshots\" : false,\n" +
                $"    \"keepLauncherOpen\" : false,\n" +
                $"    \"locale\" : \"zh-TW\",\n" +
                $"    \"profileSorting\" : \"ByLastPlayed\",\n" +
                $"    \"showGameLog\" : false,\n" +
                $"    \"showMenu\" : false,\n" +
                $"    \"soundOn\" : false\n" +
                $"  }}\n" +
                $"}}";
            return line;
        }
        private void to_Json(string data,string location )
        {
            using (StreamWriter sw123 = new StreamWriter(Path.Combine(location, "launcher_profiles.json")))
            {
                sw123.Write(data);
            }
        }
        public void Check_Set_end(string version,string Core_path, string F_ver)
        {
            if(System.IO.File.Exists(Path.Combine(Core_path, "Core", "CoreFIle", "launcher_profiles.json")) && 
               System.IO.File.Exists(Path.Combine(Core_path,"lib", version, "launcher_profiles.json")))
            {
                
                System.IO.File.Copy( Path.Combine(Core_path, "Core", "CoreFIle", "launcher_profiles.json"), Path.Combine(Core_path,"lib",version,"launcher_profiles.json"),true);
            }
        }
    }
}
