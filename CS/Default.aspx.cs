using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DevExpress.Web;

public partial class T300124 : System.Web.UI.Page {
    protected override void OnLoad(EventArgs e) {
        base.OnLoad(e);
        grid.DataSource = GetData();
        grid.DataBind();
    }

    public IEnumerable<Indicator> GetData() {
        return new List<Indicator>() {
                new Indicator() { Value = 5, WarningMessage = "It's ok", NeedAlert = false },
                new Indicator() { Value = 75, WarningMessage = "Possible dangerous", NeedAlert = true },
                new Indicator() { Value = 790, WarningMessage = "Dangerous", NeedAlert = true },
                new Indicator() { Value = 12000, WarningMessage = "Extremely dangerous", NeedAlert = true },
            };
    }
    public class Indicator {
        public int Value { get; set; }
        public string WarningMessage { get; set; }
        public bool NeedAlert { get; set; }
    }
    protected void grid_FilterControlCustomValueDisplayText(object sender, FilterControlCustomValueDisplayTextEventArgs e) {
        if (e.PropertyInfo.PropertyName == "NeedAlert") {
            if (e.Value == null)
                return;
            e.DisplayText = (bool)e.Value ? "Need alert" : "Is's ok";
        }
    }
    protected void grid_FilterControlCriteriaValueEditorInitialize(object sender, FilterControlCriteriaValueEditorInitializeEventArgs e) {
        if(e.Value == null)
            return;
        if(e.Column.PropertyName == "Value") {
            InitializeSpinEdit(e.Editor, e.Value);
        }
    }
    protected void grid_FilterControlCriteriaValueEditorCreate(object sender, FilterControlCriteriaValueEditorCreateEventArgs e) {
        if(e.Column.PropertyName == "NeedAlert") {
            e.EditorProperties = CreateComboBoxProperties(e.Value);
        }
    }
    void InitializeSpinEdit(ASPxEditBase editor, object value) {
        var spinEdit = editor as ASPxSpinEdit;
        var intValue = (int)value;
        spinEdit.BackColor = Color.LightGreen;
        if(intValue > 10)
            spinEdit.BackColor = Color.Orange;
        if(intValue > 100)
            spinEdit.BackColor = Color.Red;
        if(intValue > 1000)
            spinEdit.BackColor = Color.DarkRed;
        if(intValue > 10000)
            spinEdit.BackColor = Color.Black;
    }
    EditPropertiesBase CreateComboBoxProperties(object value) {
        bool v = value != null && (bool)value;
        var props = new ComboBoxProperties();
        props.ValueType = typeof(bool);
        props.Items.Add(new ListEditItem("Need alert", true) { Selected = v });
        props.Items.Add(new ListEditItem("Is's ok", false) { Selected = !v });
        return props;
    }
   
}
