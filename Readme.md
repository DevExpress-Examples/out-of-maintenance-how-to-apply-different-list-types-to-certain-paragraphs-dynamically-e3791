# How to apply different list types to certain paragraphs dynamically


<p>This example illustrates how to create lists of different types (bulleted and numbered lists with different formatting) and apply them to selected paragraphs dynamically. List types are defined and added to a document in the <strong>DefineAbstractLists()</strong> method, which is invoked at the application startup. After that, you can select several paragraphs and click the "Toggle selection list format" button, which will invoke the <strong>ApplyNextListToSelection()</strong> method. This method iterates through the collection of the selected paragraphs and applies an appropriate list index to each paragraph (see the <a href="http://documentation.devexpress.com/#CoreLibraries/DevExpressXtraRichEditAPINativeParagraph_ListIndextopic"><u>Paragraph.ListIndex Property</u></a>). Note that a new <a href="http://documentation.devexpress.com/#CoreLibraries/clsDevExpressXtraRichEditAPINativeNumberingListtopic"><u>NumberingList</u></a> is created in the <strong>GetNextListIndex()</strong> method if necessary.</p><p>The following examples demonstrate the basics of the Numbered List API:</p><p><a href="https://www.devexpress.com/Support/Center/p/E3402">How to create bulleted list in code</a><br />
<a href="https://www.devexpress.com/Support/Center/p/E3404">How to create a multilevel numbered list in code</a></p>

<br/>


