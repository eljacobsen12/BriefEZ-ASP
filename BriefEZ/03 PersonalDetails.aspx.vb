Public Class PersonalDetails
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session.Item("PersonalTitle") <> Nothing Then
            txtPersonalTitle.Text = CType(Session.Item("CaseNumber"), String)
        End If
        If Session.Item("FullName") <> Nothing Then
            txtFullName.Text = CType(Session.Item("District"), String)
        End If
        If Session.Item("BarNumber") <> Nothing Then
            txtBarNumber.Text = CType(Session.Item("Court"), String)
        End If
        If Session.Item("FirmName") <> Nothing Then
            txtFirmName.Text = CType(Session.Item("County"), String)
        End If
        If Session.Item("FirmAddress") <> Nothing Then
            txtFirmAddress.Text = CType(Session.Item("County"), String)
        End If
    End Sub

    Protected Sub btnContinue_Click(sender As Object, e As EventArgs) Handles btnContinue.Click
        Session("PersonalTitle") = Server.HtmlEncode(txtPersonalTitle.Text)
        Session("FullName") = Server.HtmlEncode(txtFullName.Text)
        Session("BarNumber") = Server.HtmlEncode(txtBarNumber.Text)
        Session("FirmName") = Server.HtmlEncode(txtFirmName.Text)
        Session("FirmAddress") = Server.HtmlEncode(txtFirmAddress.Text)
        Server.Transfer("~/04 AppellantAppellee.aspx", False)
    End Sub

    Protected Sub BriefMenu_MenuItemClick(sender As Object, e As MenuEventArgs) Handles BriefMenu.MenuItemClick
        If BriefMenu.SelectedItem Is BriefMenu.Items.Item(0).Value Then
            Server.Transfer("~/01 HomePage.aspx", False)
        ElseIf BriefMenu.SelectedItem Is BriefMenu.Items.Item(1).Value Then
            Server.Transfer("~/02 CaseDetails.aspx", False)
        End If
    End Sub

    Protected Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnBack.Click
        Session("PersonalTitle") = Server.HtmlEncode(txtPersonalTitle.Text)
        Session("FullName") = Server.HtmlEncode(txtFullName.Text)
        Session("BarNumber") = Server.HtmlEncode(txtBarNumber.Text)
        Session("FirmName") = Server.HtmlEncode(txtFirmName.Text)
        Session("FirmAddress") = Server.HtmlEncode(txtFirmAddress.Text)
        Server.Transfer("~/02 CaseDetails.aspx", False)
    End Sub
End Class