Imports System
Imports System.Collections.Generic
Imports System.Drawing
Imports System.Linq
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports DevExpress.Web

Partial Public Class T300124
	Inherits System.Web.UI.Page

	Protected Overrides Sub OnLoad(ByVal e As EventArgs)
		MyBase.OnLoad(e)
		grid.DataSource = GetData()
		grid.DataBind()
	End Sub

	Public Function GetData() As IEnumerable(Of Indicator)
		Return New List(Of Indicator)() From {
			New Indicator() With {
				.Value = 5,
				.WarningMessage = "It's ok",
				.NeedAlert = False
			},
			New Indicator() With {
				.Value = 75,
				.WarningMessage = "Possible dangerous",
				.NeedAlert = True
			},
			New Indicator() With {
				.Value = 790,
				.WarningMessage = "Dangerous",
				.NeedAlert = True
			},
			New Indicator() With {
				.Value = 12000,
				.WarningMessage = "Extremely dangerous",
				.NeedAlert = True
			}
		}
	End Function
	Public Class Indicator
		Public Property Value() As Integer
		Public Property WarningMessage() As String
		Public Property NeedAlert() As Boolean
	End Class
	Protected Sub grid_FilterControlCustomValueDisplayText(ByVal sender As Object, ByVal e As FilterControlCustomValueDisplayTextEventArgs)
		If e.PropertyInfo.PropertyName = "NeedAlert" Then
			If e.Value Is Nothing Then
				Return
			End If
			e.DisplayText = If(CBool(e.Value), "Need alert", "Is's ok")
		End If
	End Sub
	Protected Sub grid_FilterControlCriteriaValueEditorInitialize(ByVal sender As Object, ByVal e As FilterControlCriteriaValueEditorInitializeEventArgs)
		If e.Value Is Nothing Then
			Return
		End If
		If e.Column.PropertyName = "Value" Then
			InitializeSpinEdit(e.Editor, e.Value)
		End If
	End Sub
	Protected Sub grid_FilterControlCriteriaValueEditorCreate(ByVal sender As Object, ByVal e As FilterControlCriteriaValueEditorCreateEventArgs)
		If e.Column.PropertyName = "NeedAlert" Then
			e.EditorProperties = CreateComboBoxProperties(e.Value)
		End If
	End Sub
	Private Sub InitializeSpinEdit(ByVal editor As ASPxEditBase, ByVal value As Object)
		Dim spinEdit = TryCast(editor, ASPxSpinEdit)
		Dim intValue = DirectCast(value, Integer)
		spinEdit.BackColor = Color.LightGreen
		If intValue > 10 Then
			spinEdit.BackColor = Color.Orange
		End If
		If intValue > 100 Then
			spinEdit.BackColor = Color.Red
		End If
		If intValue > 1000 Then
			spinEdit.BackColor = Color.DarkRed
		End If
		If intValue > 10000 Then
			spinEdit.BackColor = Color.Black
		End If
	End Sub
	Private Function CreateComboBoxProperties(ByVal value As Object) As EditPropertiesBase
		Dim v As Boolean = value IsNot Nothing AndAlso DirectCast(value, Boolean)
		Dim props = New ComboBoxProperties()
		props.ValueType = GetType(Boolean)
		props.Items.Add(New ListEditItem("Need alert", True) With {.Selected = v})
		props.Items.Add(New ListEditItem("Is's ok", False) With {.Selected = Not v})
		Return props
	End Function

End Class
