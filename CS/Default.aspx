<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="T300124" %>

<%@ Register Assembly="DevExpress.Web.v15.2" Namespace="DevExpress.Web" TagPrefix="dx" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <dx:ASPxGridView ID="grid" runat="server"
            OnFilterControlCriteriaValueEditorInitialize="grid_FilterControlCriteriaValueEditorInitialize"
            OnFilterControlCriteriaValueEditorCreate="grid_FilterControlCriteriaValueEditorCreate"
            OnFilterControlCustomValueDisplayText="grid_FilterControlCustomValueDisplayText">
            <Columns>
                <dx:GridViewDataSpinEditColumn FieldName="Value" />
                <dx:GridViewDataTextColumn FieldName="WarningMessage" />
            </Columns>
            <Settings ShowFilterBar="Visible" />
            <SettingsFilterControl ShowAllDataSourceColumns="true" />
        </dx:ASPxGridView>
    </form>
</body>
</html>
