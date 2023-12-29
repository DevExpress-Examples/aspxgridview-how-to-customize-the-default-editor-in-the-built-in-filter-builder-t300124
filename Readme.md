<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/128533794/15.2.4%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/T300124)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
<!-- default badges end -->

# Grid for ASP.NET Web Forms - How to customize the default editor in the built-in the Filter Builder

This example demonstrates how to customize default editors in the built-in [Filter Builder](https://docs.devexpress.com/AspNet/5138/components/grid-view/concepts/filter-data/filter-control).

![Filter builder with custom editors](custom-editors.png)

The [ASPxGridView](https://docs.devexpress.com/AspNet/DevExpress.Web.ASPxGridView) control implements the following events that allow you to customize the editors:

* The [FilterControlCriteriaValueEditorCreate](https://docs.devexpress.com/AspNet/DevExpress.Web.ASPxGridBase.FilterControlCriteriaValueEditorCreate) event allows you to replace the default [criteria value](https://docs.devexpress.com/AspNet/11155/components/data-editors/aspxfiltercontrol/visual-elements#criteria-value) editor with a custom editor. You can set basic editor properties in the event handler.
  ```cs
  protected void grid_FilterControlCriteriaValueEditorCreate(object sender, FilterControlCriteriaValueEditorCreateEventArgs e) {
      if(e.Column.PropertyName == "NeedAlert") {
          e.EditorProperties = CreateComboBoxProperties(e.Value);
      }
  }
  EditPropertiesBase CreateComboBoxProperties(object value) {
      bool v = value != null && (bool)value;
      var props = new ComboBoxProperties();
      props.ValueType = typeof(bool);
      props.Items.Add(new ListEditItem("Need alert", true) { Selected = v });
      props.Items.Add(new ListEditItem("Is's ok", false) { Selected = !v });
      return props;
  }
  ```
* The [FilterControlCriteriaValueEditorInitialize](https://docs.devexpress.com/AspNet/DevExpress.Web.ASPxGridBase.FilterControlCriteriaValueEditorInitialize) event allows you to initialize the editor and customize its properties.
  ```cs
  protected void grid_FilterControlCriteriaValueEditorInitialize(object sender, FilterControlCriteriaValueEditorInitializeEventArgs e) {
      if(e.Value == null)
          return;
      if(e.Column.PropertyName == "Value") {
          InitializeSpinEdit(e.Editor, e.Value);
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
  ```
* The [FilterControlCustomValueDisplayText](https://docs.devexpress.com/AspNet/DevExpress.Web.ASPxGridBase.FilterControlCustomValueDisplayText) event allows you to specify custom display text for the editor.
  ```cs
  protected void grid_FilterControlCustomValueDisplayText(object sender, FilterControlCustomValueDisplayTextEventArgs e) {
      if (e.PropertyInfo.PropertyName == "NeedAlert") {
          if (e.Value == null)
              return;
          e.DisplayText = (bool)e.Value ? "Need alert" : "Is's ok";
      }
  }
  ```



## Files to Review

* [Default.aspx](./CS/Default.aspx) (VB: [Default.aspx](./VB/Default.aspx))
* [Default.aspx.cs](./CS/Default.aspx.cs) (VB: [Default.aspx.vb](./VB/Default.aspx.vb))

## Documentation

* [Filter Control](https://docs.devexpress.com/AspNet/5138/components/grid-view/concepts/filter-data/filter-control)
