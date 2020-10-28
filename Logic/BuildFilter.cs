using QuickType;
using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using System.IO;
using FAFWikiAdapter.Properties;

namespace FAFWikiAdapter.Logic
{
    class BuildFilter
    {
        private List<Unit> Units = new List<Unit>();
        private Translator Translator = new Translator();

        public BuildFilter()
        {
            var jsonBlueprints = new StreamReader(new MemoryStream(Resources.blueprints)).ReadToEnd();
            Units = JsonConvert.DeserializeObject<List<Unit>>(jsonBlueprints, Converter.Settings);
        }
        public List<string> GetUnitsID() {
            var buildable = new List<string>();
            foreach (var unit in Units)
            {
                var units = GetUnitlistArmies(unit);
                foreach (var item in units)
                {
                    if (!buildable.Contains(item.Id.ToUpper()))
                    {
                        buildable.Add(item.Id.ToUpper());
                    }
                }
            }
            return buildable;
        }
        private List<Unit> GetUnitlistArmies(Unit CurrentUnit)
        {
            var buildable = new List<Unit>();
            if (CurrentUnit?.Economy?.BuildableCategory != null)
            {
                foreach (var unit in Units)
                {
                    foreach (var buildCat in CurrentUnit.Economy.BuildableCategory)
                    {
                        var buildReq = buildCat.Split(" ");
                        bool canBuild = true;
                        foreach (var req in buildReq)
                        {
                            if (!unit.Categories.Contains(req) && req.ToUpper() != unit.Id.ToUpper())
                            {
                                canBuild = false;
                            }
                        }
                        if (canBuild)
                        {
                            String name = Translator.Attempt(unit.Id);
                            if (!name.Equals(""))
                            {
                                buildable.Add(unit);// when unit can be builded
                            }
                        }
                    }
                }
            }
            if (buildable.Count > 0)// if unit can build somthing
            {
                var name = Translator.Attempt(CurrentUnit.Id);
                if (!name.Equals(""))
                {
                    buildable.Add(CurrentUnit);
                }
            }
            return buildable;
        }
    }
}
