using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using DeckManager.Components.Enums;
using DeckManager.Extensions;

namespace DeckManagerOutput.CustomControls
{
    public partial class AddDradisComponentsControl : UserControl
    {
        private readonly ComponentType _componentType;
        public IEnumerable<ComponentType> Components { 
            get
            {
                return Enumerable.Repeat(_componentType, ((string)requestedNumberComboBox.SelectedItem).ParseAs<int>());
            } 
        }

        public AddDradisComponentsControl(ComponentType componentType)
        {
            InitializeComponent();
            ComponentNameLabel.Text = componentType.ToString();
            _componentType = componentType;
            requestedNumberComboBox.SelectedIndex = 0;
        }
    }
}
