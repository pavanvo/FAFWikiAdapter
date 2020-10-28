using FAFWikiAdapter.Properties;
using Newtonsoft.Json;
using QuickType;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace FAFWikiAdapter.Logic
{
    class Translator
    {

        Dictionary<string, string> loc;
        public Translator() {
            var jsonLocalization = new StreamReader(new MemoryStream(Resources.localization)).ReadToEnd();
            loc = JsonConvert.DeserializeObject<Localization>(jsonLocalization).Us;
        }
        public String Attempt(String id)
        {

            String infoStr = string.Empty;
            if (id.Contains("<LOC "))
            {
                String str = id.Substring(id.IndexOf("<LOC ") + "<LOC ".Length, id.IndexOf(">"));
                var unitLoc = loc.FirstOrDefault(x => x.Key.StartsWith(str)); // StartsWith insteed contains
                infoStr = unitLoc.Value?.Substring(unitLoc.Value.IndexOf("\"") + 1);
            }
            else
            {
                var unitLocs = loc.Where(x => x.Key.StartsWith(id.ToLower())); //StartsWith insteed contains
                foreach (var unitLoc in unitLocs)
                {
                    if (unitLoc.Key.Contains("_desc"))
                    {
                        infoStr += unitLoc.Value.Replace("\"", "") + " ";
                    }
                    if (unitLoc.Key.Contains("_name"))
                    {
                        infoStr += unitLoc.Value
                                .Replace("\\\"", "") + "\"";
                    }
                }
            }
            return infoStr;
        }
    }
}
