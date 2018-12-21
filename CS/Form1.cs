using System;
using System.Windows.Forms;
using DevExpress.XtraRichEdit.API.Native;

namespace RichEditSwitchListFormat
{
    public partial class Form1 : DevExpress.XtraEditors.XtraForm
    {
        public Form1()
        {
            InitializeComponent();

            richEditControl1.Text = StringSample.SampleText;
            DefineAbstractLists(richEditControl1.Document);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ApplyNextListToSelection(richEditControl1.Document);
        }

        private void DefineAbstractLists(Document document)
        {
            document.BeginUpdate();

            // Bulleted list
            AbstractNumberingList abstractListBulleted = document.AbstractNumberingLists.Add();
            abstractListBulleted.NumberingType = NumberingType.Bullet;

            ListLevel level = abstractListBulleted.Levels[0];
            level.ParagraphProperties.LeftIndent = 150;
            level.ParagraphProperties.FirstLineIndentType = ParagraphFirstLineIndent.Hanging;
            level.ParagraphProperties.FirstLineIndent = 75;
            level.CharacterProperties.FontName = "Symbol";
            level.DisplayFormatString = new string('\u00B7', 1);

            // Numbered list with decimal format
            AbstractNumberingList abstractListNumberingDecimal = document.AbstractNumberingLists.Add();
            abstractListNumberingDecimal.NumberingType = NumberingType.Simple;

            level = abstractListNumberingDecimal.Levels[0];
            level.ParagraphProperties.LeftIndent = 150;
            level.ParagraphProperties.FirstLineIndentType = ParagraphFirstLineIndent.Hanging;
            level.ParagraphProperties.FirstLineIndent = 75;
            level.Start = 1;
            level.NumberingFormat = NumberingFormat.Decimal;
            level.DisplayFormatString = "{0}.";

            // Numbered list with letter format
            AbstractNumberingList abstractListNumberingLetter = document.AbstractNumberingLists.Add();
            abstractListNumberingLetter.NumberingType = NumberingType.Simple;

            level = abstractListNumberingLetter.Levels[0];
            level.ParagraphProperties.LeftIndent = 150;
            level.ParagraphProperties.FirstLineIndentType = ParagraphFirstLineIndent.Hanging;
            level.ParagraphProperties.FirstLineIndent = 75;
            level.Start = 1;
            level.NumberingFormat = NumberingFormat.UpperLetter;
            level.DisplayFormatString = "{0}.";

            // Numbered list with roman format
            AbstractNumberingList abstractListNumberingRoman = document.AbstractNumberingLists.Add();
            abstractListNumberingRoman.NumberingType = NumberingType.Simple;

            level = abstractListNumberingRoman.Levels[0];
            level.ParagraphProperties.LeftIndent = 150;
            level.ParagraphProperties.FirstLineIndentType = ParagraphFirstLineIndent.Hanging;
            level.ParagraphProperties.FirstLineIndent = 75;
            level.Start = 1;
            level.NumberingFormat = NumberingFormat.UpperRoman;
            level.DisplayFormatString = "{0}.";

            document.EndUpdate();
        }

        private void ApplyNextListToSelection(Document document)
        {
            document.BeginUpdate();

            ReadOnlyParagraphCollection paragraphs = document.Paragraphs.Get(document.Selection);

            for (int i = 0; i < paragraphs.Count; i++)
            {
                int currentAbstractIndex = GetParagraphAbstractIndex(document, paragraphs[i]);
                Paragraph previousParagraph = null;

                if (i > 0)
                    previousParagraph = paragraphs[i - 1];

                paragraphs[i].ListIndex = GetNextListIndex(document, currentAbstractIndex, previousParagraph);
            }

            document.EndUpdate();
        }

        private int GetNextListIndex(Document document, int currentAbstractIndex, Paragraph previousParagraph)
        {
            currentAbstractIndex++;

            if (currentAbstractIndex == document.AbstractNumberingLists.Count)
            {
                return -1;
            }
            else
            {
                if (previousParagraph != null && currentAbstractIndex == GetParagraphAbstractIndex(document, previousParagraph))
                    return previousParagraph.ListIndex;

                NumberingList newList = document.NumberingLists.Add(currentAbstractIndex);

                newList.Levels[0].SetOverrideStart(true);
                newList.Levels[0].NewStart = 1;

                return newList.Index;
            }
        }

        private int GetParagraphAbstractIndex(Document document, Paragraph paragraph)
        {
            if (!paragraph.IsInList)
                return -1;

            return document.NumberingLists[paragraph.ListIndex].AbstractNumberingListIndex;
        }
    }
}