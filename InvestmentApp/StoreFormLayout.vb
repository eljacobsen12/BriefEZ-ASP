Public Class StoreFormLayout
    Private Sub StoreFormLayout_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private ds As New DataSet
    Public Sub StoreLayout(ByVal parentCtr As Control)
        Dim ctr As Control
        For Each ctr In parentCtr.Controls
            Dim dr As DataRow = ds.Tables(0).NewRow
            dr("Type") = ctr.GetType.ToString
            dr("Name") = ctr.Name
            dr("Height") = ctr.Height
            dr("Width") = ctr.Width
            ds.Tables(0).Rows.Add(dr)
            StoreLayout(ctr)
        Next
    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click
        Dim dt As DataTable
        ds.Tables.Add(dt)
        dt.Columns.Add("Type")
        dt.Columns.Add("Name")
        dt.Columns.Add("Height")
        dt.Columns.Add("Width")
        StoreLayout(Me)
        ds.WriteXml("c:\StoredLayouts\" + Application.ProductName + ".xml")     'Location to store Layout XML
    End Sub
End Class