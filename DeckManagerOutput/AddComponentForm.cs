using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DeckManager.Boards.Dradis.Enums;
using DeckManager.Components.Enums;
using DeckManagerOutput.CustomControls;

namespace DeckManagerOutput
{
    public partial class AddComponentForm : Form
    {
        public IEnumerable<Tuple<DradisNodeName, ComponentType>> RequestedComponents { get; set; }
        public AddComponentForm()
        {
            InitializeComponent();
            var componentTypes = ((ComponentType[])Enum.GetValues(typeof (ComponentType))).Skip(1); // Skip Unknown.
            foreach (var componentType in componentTypes)
            {
                AlphaFlowLayoutPanel.Controls.Add(new AddDradisComponentsControl(componentType));
                BravoFlowLayoutPanel.Controls.Add(new AddDradisComponentsControl(componentType));
                CharlieFlowLayoutPanel.Controls.Add(new AddDradisComponentsControl(componentType));
                DeltaFlowLayoutPanel.Controls.Add(new AddDradisComponentsControl(componentType));
                EchoFlowLayoutPanel.Controls.Add(new AddDradisComponentsControl(componentType));
                FoxtrotFlowLayoutPanel.Controls.Add(new AddDradisComponentsControl(componentType));
            }
        }

        private void SubmitButton_Click(object sender, EventArgs e)
        {
            var ret = new List<Tuple<DradisNodeName, ComponentType>>();
            foreach (AddDradisComponentsControl control in AlphaFlowLayoutPanel.Controls)
            {
                ret.AddRange(control.Components.Select(x => new Tuple<DradisNodeName, ComponentType>(DradisNodeName.Alpha, x)));
            }
            foreach (AddDradisComponentsControl control in BravoFlowLayoutPanel.Controls)
            {
                ret.AddRange(control.Components.Select(x => new Tuple<DradisNodeName, ComponentType>(DradisNodeName.Bravo, x)));
            }
            foreach (AddDradisComponentsControl control in CharlieFlowLayoutPanel.Controls)
            {
                ret.AddRange(control.Components.Select(x => new Tuple<DradisNodeName, ComponentType>(DradisNodeName.Charlie, x)));
            }
            foreach (AddDradisComponentsControl control in DeltaFlowLayoutPanel.Controls)
            {
                ret.AddRange(control.Components.Select(x => new Tuple<DradisNodeName, ComponentType>(DradisNodeName.Delta, x)));
            }
            foreach (AddDradisComponentsControl control in EchoFlowLayoutPanel.Controls)
            {
                ret.AddRange(control.Components.Select(x => new Tuple<DradisNodeName, ComponentType>(DradisNodeName.Echo, x)));
            }
            foreach (AddDradisComponentsControl control in FoxtrotFlowLayoutPanel.Controls)
            {
                ret.AddRange(control.Components.Select(x => new Tuple<DradisNodeName, ComponentType>(DradisNodeName.Foxtrot, x)));
            }
            RequestedComponents = ret;
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
