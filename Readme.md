<!-- default badges list -->
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/T300124)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
<!-- default badges end -->

# Grid for ASP.NET Web Forms - How to customize the default editor in the built-in Filter Builder
<!-- run online -->
**[[Run Online]](https://codecentral.devexpress.com/t300124/)**
<!-- run online end -->

The [ASPxGridView](https://docs.devexpress.com/AspNet/DevExpress.Web.ASPxGridView) control implements the following events to customize the default editor for a column in the [Filter Builder](https://docs.devexpress.com/AspNet/5138/components/grid-view/concepts/filter-data/filter-control):

<dl>
  <dt>[FilterControlCriteriaValueEditorCreate](https://docs.devexpress.com/AspNet/DevExpress.Web.ASPxGridBase.FilterControlCriteriaValueEditorCreate)</dt>
  <dd>Allows you to replace the default [criteria value](https://docs.devexpress.com/AspNet/11155/components/data-editors/aspxfiltercontrol/visual-elements#criteria-value) editor with a custom one. In the event handler, you can set basic editor properties.
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
  </dd>
  <dt>[FilterControlCriteriaValueEditorInitialize](https://docs.devexpress.com/AspNet/DevExpress.Web.ASPxGridBase.FilterControlCriteriaValueEditorInitialize)</dt>
  <dd>Allows you to initialize the editor and customize its properties.</dd>
  <dt>[FilterControlCustomValueDisplayText](https://docs.devexpress.com/AspNet/DevExpress.Web.ASPxGridBase.FilterControlCustomValueDisplayText)</dl>
  <dd>Allows you to specify custom display text for the editor.</dd>
</dl>

In this example, 


 to In the event handler, the spin editor color is changed depending on its value in this event handler.
 In this example, the event is used to show text values "<em>NeedAlert</em>" / "<em>It's ok</em>" instead of <em>true</em> / <em>false</em>  for the "NeedAlert" Boolean column.</p>




## Files to Review

* [Default.aspx](./CS/Default.aspx) (VB: [Default.aspx](./VB/Default.aspx))
* [Default.aspx.cs](./CS/Default.aspx.cs) (VB: [Default.aspx.vb](./VB/Default.aspx.vb))

## Documentation

* [Filter Control](https://docs.devexpress.com/AspNet/5138/components/grid-view/concepts/filter-data/filter-control)
