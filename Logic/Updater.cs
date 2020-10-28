using FAFWikiAdapter.Helpers;
using ForEagle.Helpers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FAFWikiAdapter.Logic
{
    class Updater
    {
        RequestHelper Request;
        LuaHelper LuaHelper;
        public Updater()
        {
            Request = new RequestHelper();
            LuaHelper = new LuaHelper();
        }

        public async Task<List<string>> GetUnitsJsonByIDs(List<string> IDs)
        {
            var result = new List<string>();
            foreach (var Id in IDs)
            {
                var uri = $"https://raw.githubusercontent.com/FAForever/fa/master/units/{Id}/{Id}_unit.bp";
                var responce = await Request.GetRequest(uri);
                if (!responce.Contains("404: Not Found")) {
                    responce = responce.Substring(responce.IndexOf('{'));
                    responce = responce.Replace(" Sound ", " ");
                    responce = responce.Replace("#", "--");
                    var json = LuaHelper.ToJson(responce, Id);
                    result.Add(json);
                }
            }
            return result;
        }

    }
}
