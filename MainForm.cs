using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FAFWikiAdapter.Logic;
using Newtonsoft.Json;

namespace FAFWikiAdapter
{
    public partial class MainForm : Form
    {
        private BuildFilter BuildFilter;
        private Updater Updater;
        public MainForm()
        {
            InitializeComponent();
        }
        private async void buttonPrepare_Click(object sender, EventArgs e)
        {
            buttonStart.Enabled = false;
            await Task.Run(() =>
            {
                BuildFilter = new BuildFilter();
            });
            buttonStart.Enabled = true;
        }
        private async void buttonStart_Click(object sender, EventArgs e) =>
            await Task.Run(() =>
            {
                var buildable = BuildFilter.GetUnitsID();
                Invoke(new Action(() => label1.Text = buildable.Count + string.Empty));
                var buildableUnits = JsonConvert.SerializeObject(buildable);
                File.WriteAllText("buildableUnits.json", buildableUnits);
            });
        private async void buttonUpdate_Click(object sender, EventArgs e) => await Task.Run(async () =>
        {
            if (File.Exists("buildableUnits.json"))
            {
                var buildableUnits = JsonConvert.DeserializeObject<List<string>>(
                    File.ReadAllText("buildableUnits.json")
                    );
                var units = await Updater.GetUnitsJsonByIDs(buildableUnits);
                Invoke(new Action(() => label2.Text = units.Count + string.Empty));

                StringBuilder UpdatedUnits = new StringBuilder("[");
                foreach (var item in units)
                { UpdatedUnits.Append(item + ','); }
                UpdatedUnits.Remove(UpdatedUnits.Length - 1, 1);
                UpdatedUnits.Append(']');

                File.WriteAllText("UpdatedUnits.json", UpdatedUnits.ToString());
            }
        });

        private void MainForm_Shown(object sender, EventArgs e)
        {
            Updater = new Updater();
        }
    }
}
