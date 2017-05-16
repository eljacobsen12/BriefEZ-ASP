Public Class Home_Page
    Inherits System.Web.UI.Page
    Public Shared wordDoc As Microsoft.Office.Interop.Word.Document
    'Public Shared desktopPath As String = ""

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session.Item("State") <> Nothing Then
            btnSelectState.SelectedValue = CType(Session.Item("State"), String)
        End If
        If Session.Item("Brief") <> Nothing Then
            btnSelectBrief.SelectedValue = CType(Session.Item("Brief"), String)
        End If
    End Sub

    Protected Sub btnCreateBrief_Click(sender As Object, e As EventArgs) Handles btnCreateBrief.Click
        Session("State") = btnSelectState.SelectedValue
        Session("Brief") = btnSelectBrief.SelectedValue

        If btnSelectState.Text = "NORTH CAROLINA" Then
            If btnSelectBrief.SelectedValue = "Trial Brief" Then
                '******TRIAL BRIEF CODE HERE********
            ElseIf btnSelectBrief.SelectedValue = "Appellate Brief" Then
                Session("desktopPath") = IO.Path.GetTempPath & "\NEWBRIEF.docx"
                Try
                    IO.File.WriteAllBytes(Session.Item("desktopPath").ToString, My.Resources.NCBriefTemplate)
                Catch ex As Exception
                    wordDoc = GetObject(Session.Item("desktopPath").ToString)
                    wordDoc.Close()
                    wordDoc = Nothing
                    IO.File.Delete(path:=Session.Item("desktopPath").ToString)
                    IO.File.WriteAllBytes(Session.Item("desktopPath").ToString, My.Resources.NCBriefTemplate)
                End Try
                wordDoc = GetObject(PathName:=Session.Item("desktopPath"))
                Server.Transfer("~/02 CaseDetails.aspx", True)

            ElseIf btnSelectBrief.SelectedValue = "Legal Brief" Then
                '******LEGAL BRIEF CODE HERE*********
            ElseIf btnSelectBrief.SelectedValue = "Memorandum of Law" Then
                '******MEMORANDUM OF LAW*************
            ElseIf btnSelectBrief.SelectedValue = "IRAC Case Brief" Then
                '******IRAC CASE BRIEF CODE HERE*****        
            Else
                '******ELSE CODE HERE****************
            End If
        ElseIf btnSelectState.Text = "VIRGINIA" Then
            '********************************
            '******VIRGINIA CODE HERE********
            '********************************
        Else
            '********ELSE CODE HERE**********
        End If
    End Sub
End Class