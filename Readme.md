# ASPxGridView - How to customize the default editor in the built-in Filter Builder


<p>ASPxGridView provides the following events to customize the default editor for a column in the Filter Builder:</p>
<p>1) <a href="https://documentation.devexpress.com/AspNet/DevExpress.Web.ASPxGridBase.FilterControlCriteriaValueEditorCreate.event">FilterControlCriteriaValueEditorCreate</a> allows substituting the default editor with a custom one. You can also set basic editor properties there.<br>2) <a href="https://documentation.devexpress.com/AspNet/DevExpress.Web.ASPxGridBase.FilterControlCriteriaValueEditorInitialize.event">FilterControlCriteriaValueEditorInitialize</a> is used to initialize the editor. Here, the spin editor color is changed depending on its value in this event handler.<br>3) <a href="https://documentation.devexpress.com/AspNet/DevExpress.Web.ASPxGridBase.FilterControlCustomValueDisplayText.event">FilterControlCustomValueDisplayText</a> allows displaying a custom text in the editor. In this example, the event is used to show text values "<em>NeedAlert</em>" / "<em>It's ok</em>" instead of <em>true</em> / <em>false</em>  for the "NeedAlert" Boolean column.</p>

<br/>


