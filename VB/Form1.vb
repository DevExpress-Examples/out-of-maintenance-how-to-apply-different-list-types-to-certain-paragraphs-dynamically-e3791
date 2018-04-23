Imports Microsoft.VisualBasic
Imports System
Imports System.Windows.Forms
Imports DevExpress.XtraRichEdit.API.Native

Namespace RichEditSwitchListFormat
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()

			richEditControl1.Text = StringSample.SampleText
			DefineAbstractLists(richEditControl1.Document)
		End Sub

		Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
			ApplyNextListToSelection(richEditControl1.Document)
		End Sub

		Private Sub DefineAbstractLists(ByVal document As Document)
			document.BeginUpdate()

			' Bulleted list
			Dim abstractListBulleted As AbstractNumberingList = document.AbstractNumberingLists.Add()
			abstractListBulleted.NumberingType = NumberingType.Bullet

			Dim level As ListLevel = abstractListBulleted.Levels(0)
			level.ParagraphProperties.LeftIndent = 150
			level.ParagraphProperties.FirstLineIndentType = ParagraphFirstLineIndent.Hanging
			level.ParagraphProperties.FirstLineIndent = 75
			level.CharacterProperties.FontName = "Symbol"
			level.DisplayFormatString = New String(ChrW(&H00B7), 1)

			' Numbered list with decimal format
			Dim abstractListNumberingDecimal As AbstractNumberingList = document.AbstractNumberingLists.Add()
			abstractListNumberingDecimal.NumberingType = NumberingType.Simple

			level = abstractListNumberingDecimal.Levels(0)
			level.ParagraphProperties.LeftIndent = 150
			level.ParagraphProperties.FirstLineIndentType = ParagraphFirstLineIndent.Hanging
			level.ParagraphProperties.FirstLineIndent = 75
			level.Start = 1
			level.NumberingFormat = NumberingFormat.Decimal
			level.DisplayFormatString = "{0}."

			' Numbered list with letter format
			Dim abstractListNumberingLetter As AbstractNumberingList = document.AbstractNumberingLists.Add()
			abstractListNumberingLetter.NumberingType = NumberingType.Simple

			level = abstractListNumberingLetter.Levels(0)
			level.ParagraphProperties.LeftIndent = 150
			level.ParagraphProperties.FirstLineIndentType = ParagraphFirstLineIndent.Hanging
			level.ParagraphProperties.FirstLineIndent = 75
			level.Start = 1
			level.NumberingFormat = NumberingFormat.UpperLetter
			level.DisplayFormatString = "{0}."

			' Numbered list with roman format
			Dim abstractListNumberingRoman As AbstractNumberingList = document.AbstractNumberingLists.Add()
			abstractListNumberingRoman.NumberingType = NumberingType.Simple

			level = abstractListNumberingRoman.Levels(0)
			level.ParagraphProperties.LeftIndent = 150
			level.ParagraphProperties.FirstLineIndentType = ParagraphFirstLineIndent.Hanging
			level.ParagraphProperties.FirstLineIndent = 75
			level.Start = 1
			level.NumberingFormat = NumberingFormat.UpperRoman
			level.DisplayFormatString = "{0}."

			document.EndUpdate()
		End Sub

		Private Sub ApplyNextListToSelection(ByVal document As Document)
			document.BeginUpdate()

			Dim paragraphs As ParagraphCollection = document.GetParagraphs(document.Selection)

			For i As Integer = 0 To paragraphs.Count - 1
				Dim currentAbstractIndex As Integer = GetParagraphAbstractIndex(document, paragraphs(i))
				Dim previousParagraph As Paragraph = Nothing

				If i > 0 Then
					previousParagraph = paragraphs(i - 1)
				End If

				paragraphs(i).ListIndex = GetNextListIndex(document, currentAbstractIndex, previousParagraph)
			Next i

			document.EndUpdate()
		End Sub

		Private Function GetNextListIndex(ByVal document As Document, ByVal currentAbstractIndex As Integer, ByVal previousParagraph As Paragraph) As Integer
			currentAbstractIndex += 1

			If currentAbstractIndex = document.AbstractNumberingLists.Count Then
				Return -1
			Else
				If previousParagraph IsNot Nothing AndAlso currentAbstractIndex = GetParagraphAbstractIndex(document, previousParagraph) Then
					Return previousParagraph.ListIndex
				End If

				Dim newList As NumberingList = document.NumberingLists.Add(currentAbstractIndex)

				newList.Levels(0).SetOverrideStart(True)
				newList.Levels(0).NewStart = 1

				Return newList.Index
			End If
		End Function

		Private Function GetParagraphAbstractIndex(ByVal document As Document, ByVal paragraph As Paragraph) As Integer
			If (Not paragraph.IsInList) Then
				Return -1
			End If

			Return document.NumberingLists(paragraph.ListIndex).AbstractNumberingListIndex
		End Function
	End Class
End Namespace