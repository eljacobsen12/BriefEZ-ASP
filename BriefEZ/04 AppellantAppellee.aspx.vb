Public Class AppellantAppellee
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub btnContinue_Click(sender As Object, e As EventArgs) Handles btnContinue.Click
        Session("Appellant") = txtAppellant.Text
        Session("Appellee") = txtAppellee.Text
        Session("BriefType") = btnBriefTypes.SelectedValue
        Server.Transfer("~/05 Options.aspx", False)
    End Sub
End Class