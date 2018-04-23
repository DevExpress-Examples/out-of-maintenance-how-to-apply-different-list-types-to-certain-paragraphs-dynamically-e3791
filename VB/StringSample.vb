Namespace RichEditSwitchListFormat
    Public NotInheritable Class StringSample

        Private Sub New()
        End Sub

        Public Shared ReadOnly Property SampleText() As String
            Get
                Return "Lorem ipsum dolor sit amet, consectetuer adipiscing elit, " & ControlChars.CrLf & _
"sed diam nonummy nibh euismod tincidunt ut laoreet dolore " & ControlChars.CrLf & _
"magna aliquam erat volutpat. Ut wisi enim ad minim veniam, " & ControlChars.CrLf & _
"quis nostrud exerci tation ullamcorper suscipit lobortis nisl ut " & ControlChars.CrLf & _
"aliquip ex ea commodo consequat. Duis autem vel eum iriure " & ControlChars.CrLf & _
"dolor in hendrerit in vulputate velit esse molestie consequat, " & ControlChars.CrLf & _
"vel illum dolore eu feugiat nulla facilisis at vero eros et accumsan " & ControlChars.CrLf & _
"et iusto odio dignissim qui blandit praesent luptatum zzril delenit " & ControlChars.CrLf & _
"augue duis dolore te feugait nulla facilisi. Nam liber tempor cum " & ControlChars.CrLf & _
"soluta nobis eleifend option congue nihil imperdiet doming id " & ControlChars.CrLf & _
"quod mazim placerat facer possim assum."
            End Get
        End Property
    End Class
End Namespace
