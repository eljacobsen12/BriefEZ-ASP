Public Class Options
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub btnContinue_Click(sender As Object, e As EventArgs) Handles btnContinue.Click
        Session("Font") = btnFontList.SelectedValue
        If btnCheckBox.Items.Item(0).Selected = True Then
            Session("Index") = True
        Else
            Session("Index") = False
        End If
        If btnCheckBox.Items.Item(1).Selected = True Then
            Session("CertificateOfService") = True
        Else
            Session("CertificateOfService") = False
        End If
        If btnCheckBox.Items.Item(2).Selected = True Then
            Session("CertificateOfCompliance") = True
        Else
            Session("CertificateOfCompliance") = False
        End If
        Server.Transfer("~/06 Cases.aspx", False)
    End Sub
End Class