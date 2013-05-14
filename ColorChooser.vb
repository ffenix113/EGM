Public Class ColorChooser

    Public Chosen As String = "White"

    Private Sub ColorChooser_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Dim ColorList() As String = {"AliceBlue", "AntiqueWhite", "Aqua", "Aquamarine", "Azure", "Beige", "Bisque", "Black", "BlanchedAlmond", "Blue", "BlueViolet", "Brown", _
                                         "Burlywood", "CadetBlue", "Chartreuse", "Chocolate", "Coral", "CornflowerBlue", "Cornsilk", "Crimson", "Cyan", "DarkBlue", "DarkCyan", _
                                         "DarkGoldenrod", "DarkGray", "DarkGreen", "DarkKhaki", "DarkMagenta", "DarkOliveGreen", "DarkOrange", "DarkOrchid", "DarkRed", "DarkSalmon", _
                                         "DarkSeaGreen", "DarkSlateBlue", "DarkSlateGray", "DarkTurquoise", "DarkVoilet", "DeepPink", "DeekSkyBlue", "DimGray", "DodgerBlue", "Firebrick", _
                                         "FloralWhite", "ForestGreen", "Fuchsia", "Gainsboro", "GhostWhite", "Gold", "Goldenrod", "Gray", "Green", "GreenYellow", "Honeydew", "HotPink", _
                                         "IndianRed", "Indigo", "Ivory", "Lavender", "LavenderBlush", "LawnGreen", "LemonChiffon", "LightBlue", "LightCoral", "LightCyan", "LightGoldenrodYellow", _
                                         "LightGreen", "LightGrey", "LightPink", "LightSalmon", "LightSeaGreen", "LightSkyBlue", "LightSlateGray", "LightSteelBlue", "LightYellow", "Lime", _
                                         "LimeGreen", "Linen", "Magenta", "Maroon", "MediumAquamarine", "MediumBlue", "MediumOrchid", "MediumPurple", "MediumSeaGreen", "MediumSlateBlue", "MediumSpringGreen", _
                                         "MediumTurqoise", "MediumVioletRed", "MidnightBlue", "MintCream", "MistyRose", "Moccasin", "NavajoWhite", "Navy", "OldLace", "Olive", "OliveDrab", "Orange", "OrangeRed", _
                                         "Orchid", "PaleGoldenrod", "PaleGreen", "PaleTurquoise", "PaleVioletRed", "PapayaWhip", "PeachPuff", "Peru", "Pink", "Plum", "PowderBlue", "Purple", "Red", "RosyBrown", _
                                         "RoyalBlue", "SaddleBrown", "Salmon", "SandyBrown", "SeaGreen", "Seashell", "Sienna", "Silver", "SkyBlue", "SlateBlue", "SlateGray", "Snow", "SpringGreen", "SteelBlue", _
                                         "Tan", "Teal", "Thistle", "Tomato", "Turquoise", "Violet", "Wheat", "White", "WhiteSmoke", "Yellow", "YellowGreen"}
            For Each Col As String In ColorList
                Try
                    Dim ColChooser As New PictureBox
                    ColChooser.BackColor = Color.FromName(Col)
                    ColChooser.BorderStyle = BorderStyle.FixedSingle
                    ColChooser.Dock = DockStyle.Top
                    ColChooser.Tag = Col
                    FlowLayoutPanel1.Controls.Add(ColChooser)
                    AddHandler ColChooser.Click, AddressOf SelectedAColor_Click
                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try
            Next Col
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub


    Public Sub SelectedAColor_Click(ByVal sender As Object, e As EventArgs)
        Panel2.BackColor = CType(sender, PictureBox).BackColor
        Chosen = CType(sender, PictureBox).Tag
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Close()
    End Sub
End Class