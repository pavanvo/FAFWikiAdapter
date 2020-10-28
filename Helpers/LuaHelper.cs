using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using NLua;

namespace FAFWikiAdapter.Helpers
{
    class LuaHelper
    {
        public string ToJson(string lua, string id)
        {
            var result = string.Empty;
            Lua state = new Lua();
            try
            {
                state.DoString($"json = require('json') myTable = {lua}  myTable[\"ID\"] = \"{id}\"  result = json.encode(myTable)");
                result = (string)state["result"];
            }
            catch (Exception ex){ }
            return result;
        }

        //public string SetProperty(string table, string prop, object value)
        //{
        //    var result = string.Empty;
        //    Lua state = new Lua();
        //    try
        //    {
        //        state.DoString($"table = {table} table[\"{prop}\"] = {value}");
        //        result = (string)state["table"];
        //    }
        //    catch (Exception ex) { }
        //    return result;
        //}
    }
}
