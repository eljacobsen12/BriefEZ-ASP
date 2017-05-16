Public Class _02_CaseDetails
    Inherits System.Web.UI.Page


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            If Session.Item("CaseNumber") <> Nothing Then
                txtCaseNumber.Text = CType(Session.Item("CaseNumber"), String)
            End If
            If Session.Item("District") <> Nothing Then
                txtDistrict.Text = CType(Session.Item("District"), String)
            End If
            If Session.Item("Court") <> Nothing Then
                txtCourt.Text = CType(Session.Item("Court"), String)
            End If
            If Session.Item("County") <> Nothing Then
                txtCounty.Text = CType(Session.Item("County"), String)
            End If
        End If
    End Sub

    Protected Sub btnContinue_Click(sender As Object, e As EventArgs) Handles btnContinue.Click
        Session("CaseNumber") = Server.HtmlEncode(txtCaseNumber.Text)
        Session("District") = Server.HtmlEncode(txtDistrict.Text)
        Session("Court") = Server.HtmlEncode(txtCourt.Text)
        Session("County") = Server.HtmlEncode(txtCounty.Text)
        Server.Transfer("~/03 PersonalDetails.aspx", True)
    End Sub

    Protected Sub BriefMenu_MenuItemClick(sender As Object, e As MenuEventArgs) Handles BriefMenu.MenuItemClick

    End Sub

    Protected Sub btnBack_Click(sender As Object, e As EventArgs) Handles btnBack.Click
        Session("CaseNumber") = Server.HtmlEncode(txtCaseNumber.Text)
        Session("District") = Server.HtmlEncode(txtDistrict.Text)
        Session("Court") = Server.HtmlEncode(txtCourt.Text)
        Session("County") = Server.HtmlEncode(txtCounty.Text)
        Server.Transfer("~/01 HomePage.aspx", True)
    End Sub
End Class