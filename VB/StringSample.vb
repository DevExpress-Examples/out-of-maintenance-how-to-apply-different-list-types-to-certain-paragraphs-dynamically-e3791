Imports Microsoft.VisualBasic
Imports System
Namespace RichEditSwitchListFormat
	Public NotInheritable Class StringSample
		Private Sub New()
		End Sub
		Public Shared ReadOnly Property SampleText() As String
			Get
				Return "Lorem ipsum dolor sit amet, consectetuer adipiscing elit, " & ControlChars.CrLf & "sed diam nonummy nibh euismod tincidunt ut laoreet dolore " & ControlChars.CrLf & "magna aliquam erat volutpat. Ut wisi enim ad minim veniam, " & ControlChars.CrLf & "quis nostrud exerci tation ullamcorper suscipit lobortis nisl ut " & ControlChars.CrLf & "aliquip ex ea commodo consequat. Duis autem vel eum iriure " & ControlChars.CrLf & "dolor in hendrerit in vulputate velit esse molestie consequat, " & ControlChars.CrLf & "vel illum dolore eu feugiat nulla facilisis at vero eros et accumsan " & ControlChars.CrLf & "et iusto odio dignissim qui blandit praesent luptatum zzril delenit " & ControlChars.CrLf & "augue duis dolore te feugait nulla facilisi. Nam liber tempor cum " & ControlChars.CrLf & "soluta nobis eleifend option congue nihil imperdiet doming id " & ControlChars.CrLf & "quod mazim placerat facer possim assum."
			End Get
		End Property
	End Class
End Namespace
