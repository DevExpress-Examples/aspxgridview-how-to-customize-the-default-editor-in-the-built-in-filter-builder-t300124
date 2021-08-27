<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/128533794/15.2.4%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/T300124)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
<!-- default badges end -->
<!-- default file list -->
*Files to look at*:

* [Default.aspx](./CS/Default.aspx) (VB: [Default.aspx](./VB/Default.aspx))
* [Default.aspx.cs](./CS/Default.aspx.cs) (VB: [Default.aspx.vb](./VB/Default.aspx.vb))
<!-- default file list end -->
# ASPxGridView - How to customize the default editor in the built-in Filter Builder
<!-- run online -->
**[[Run Online]](https://codecentral.devexpress.com/t300124/)**
<!-- run online end -->


<p>ASPxGridView provides the following events to customize the default editor for a column in the Filter Builder:</p>
<p>1) <a href="https://documentation.devexpress.com/AspNet/DevExpress.Web.ASPxGridBase.FilterControlCriteriaValueEditorCreate.event">FilterControlCriteriaValueEditorCreate</a> allows substituting the default editor with a custom one. You can also set basic editor properties there.<br>2) <a href="https://documentation.devexpress.com/AspNet/DevExpress.Web.ASPxGridBase.FilterControlCriteriaValueEditorInitialize.event">FilterControlCriteriaValueEditorInitialize</a> is used to initialize the editor. Here, the spin editor color is changed depending on its value in this event handler.<br>3) <a href="https://documentation.devexpress.com/AspNet/DevExpress.Web.ASPxGridBase.FilterControlCustomValueDisplayText.event">FilterControlCustomValueDisplayText</a> allows displaying a custom text in the editor. In this example, the event is used to show text values "<em>NeedAlert</em>" / "<em>It's ok</em>" instead of <em>true</em> / <em>false</em>  for the "NeedAlert" Boolean column.</p>

<br/>


