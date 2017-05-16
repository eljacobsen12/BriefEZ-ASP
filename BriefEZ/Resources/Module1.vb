'BriefEZ
'Created By: Erik Jacobsen
'12/29/2015

Module Module1

    'Search Word Document for searchWord and replace with replacementWord
    Sub searchAndReplace(objWord As Word.Document, searchWord As String, replacementWord As String)
        Dim findObject As Word.Find = objWord.Find
        With findObject
            .ClearFormatting()
            .Text = searchWord
            .MatchWholeWord = True
            .MatchCase = False
            .Replacement.ClearFormatting()
            .Replacement.Text = replacementWord
            .Execute(Replace:=Word.WdReplace.wdReplaceAll)
        End With
    End Sub

    'Open word invisibly, replace bookmark with word, bookmark new text
    Sub replaceBookmark(bookmark As String, replacement As String)
        'Write text to the bookmark.
        Dim myRange As Word.Range
        'Clipboard.SetText(replacement, TextDataFormat.Rtf)
        myRange = APPealableForm.wordDoc.Bookmarks(bookmark).Range
        myRange.Text = replacement
        'myRange.Paste()
        APPealableForm.wordDoc.Bookmarks.Add(Name:=bookmark, Range:=myRange)
    End Sub

    Sub replaceBookmarkRTF(bookmark As String, replacement As String)
        'Write text to the bookmark.
        Dim myRange As Word.Range
        Clipboard.SetText(replacement, TextDataFormat.Rtf)
        myRange = APPealableForm.wordDoc.Bookmarks(bookmark).Range
        myRange.Paste()
        APPealableForm.wordDoc.Bookmarks.Add(Name:=bookmark, Range:=myRange)
    End Sub

    'Quit Word if Open
    Sub quitWord()
        Dim objWord As Word.Application
        objWord = GetObject(, "Word.Application")
        objWord.Quit(SaveChanges:=True)
    End Sub

    'Delete any unused Bookmarks
    Sub deleteBookmarks(wordDoc As Word.Document)
        Dim thisBookmark As Word.Bookmark
        Dim i As Integer = 0
        For Each thisBookmark In wordDoc.Bookmarks
            'Delete Unsused Issues
            If thisBookmark.Range.Text = "<<Issue0>>" Or thisBookmark.Range.Text = "<<Issue1>>" Or thisBookmark.Range.Text = "<<Issue2>>" Or thisBookmark.Range.Text = "<<Issue3>>" Or thisBookmark.Range.Text = "<<Issue4>>" Then
                thisBookmark.Range.Paragraphs(1).Range.Delete()
                'Delete Unused Arguments
            ElseIf thisBookmark.Range.Text = "<<ArgHeader0>>" Or thisBookmark.Range.Text = "<<ArgHeader1>>" Or thisBookmark.Range.Text = "<<ArgHeader2>>" Then
                thisBookmark.Range.Paragraphs(1).Range.Delete()
            ElseIf thisBookmark.Range.Text = "<<Arg0>>" Or thisBookmark.Range.Text = "<<Arg1>>" Or thisBookmark.Range.Text = "<<Arg2>>" Then
                thisBookmark.Range.Paragraphs(1).Range.Delete()
                'Delete Unused SubArgument
            ElseIf thisBookmark.Range.Text = "<<SubArg00>>" Or thisBookmark.Range.Text = "<<SubArg01>>" Or thisBookmark.Range.Text = "<<SubArg02>>" Then
                thisBookmark.Range.Paragraphs(1).Range.Delete()
            ElseIf thisBookmark.Range.Text = "<<SubArg10>>" Or thisBookmark.Range.Text = "<<SubArg11>>" Or thisBookmark.Range.Text = "<<SubArg12>>" Then
                thisBookmark.Range.Paragraphs(1).Range.Delete()
            ElseIf thisBookmark.Range.Text = "<<SubArg20>>" Or thisBookmark.Range.Text = "<<SubArg21>>" Or thisBookmark.Range.Text = "<<SubArg22>>" Then
                thisBookmark.Range.Paragraphs(1).Range.Delete()
            ElseIf thisBookmark.Range.Text = "<<SubArgHeader00>>" Or thisBookmark.Range.Text = "<<SubArgHeader01>>" Or thisBookmark.Range.Text = "<<SubArgHeader02>>" Then
                thisBookmark.Range.Paragraphs(1).Range.Delete()
            ElseIf thisBookmark.Range.Text = "<<SubArgHeader10>>" Or thisBookmark.Range.Text = "<<SubArgHeader11>>" Or thisBookmark.Range.Text = "<<SubArgHeader12>>" Then
                thisBookmark.Range.Paragraphs(1).Range.Delete()
            ElseIf thisBookmark.Range.Text = "<<SubArgHeader20>>" Or thisBookmark.Range.Text = "<<SubArgHeader21>>" Or thisBookmark.Range.Text = "<<SubArgHeader22>>" Then
                thisBookmark.Range.Paragraphs(1).Range.Delete()
            ElseIf thisBookmark.Range.Text = "<<StatementOfTheCase>>" Or thisBookmark.Range.Text = "<<StatementOfTheFacts>>" Or thisBookmark.Range.Text = "<<StatementOfTheGrounds>>" Or thisBookmark.Range.Text = "<<StandardOfReview>>" Then
                thisBookmark.Range.Previous(Unit:=Word.WdUnits.wdParagraph, Count:=1).Delete()
                thisBookmark.Range.Paragraphs(1).Range.Delete()
            End If
        Next
    End Sub

    'Insert Date
    Sub insertDate(wordDoc As Word.Document)
        'Get Insert Range
        Dim dateRange As Word.Range
        dateRange = wordDoc.Bookmarks("Date").Range
        'Get Current System Date
        Dim strDay As String
        Dim strDateFormat As String
        strDay = Format(Now, "dd")
        'Insert Date into Range in "12th day of January, 2016" format
        strDateFormat = ordinalDate(strDay) & " day of " & Format(Now, "MMMM, yyyy")
        dateRange.Text = strDateFormat
    End Sub

    'Change Date to Ordinal Format
    Function ordinalDate(dayToFormat As String) As String
        Dim newDay As String
        If dayToFormat = "01" Or dayToFormat = "02" Or dayToFormat = "03" Or dayToFormat = "04" Or dayToFormat = "05" Or dayToFormat = "06" Or dayToFormat = "07" Or dayToFormat = "08" Or dayToFormat = "09" Then
            dayToFormat = dayToFormat.Chars(2)
        End If
        If dayToFormat = "1" Or dayToFormat = "21" Or dayToFormat = "31" Then
            newDay = dayToFormat & "st"
        ElseIf dayToFormat = "2" Or dayToFormat = "22" Then
            newDay = dayToFormat & "nd"
        ElseIf dayToFormat = "3" Or dayToFormat = "23" Then
            newDay = dayToFormat & "rd"
        Else
            newDay = dayToFormat & "th"
        End If
        Return newDay
    End Function


    'Loop through array and insert into document
    Sub insertText(wordDoc As Word.Document, stringName As String)

        Dim i As Integer = 0
        Dim y As Integer = 0
        Dim rtfLength As Integer
        Dim strRTFToText As String
        Dim myRange As Word.Range
        Dim myStart As Integer
        Dim myEnd As Integer
        'Dim count As Integer
        Dim bookmarkStr As String

        If stringName = "Issues" Then
            While i < IssuesLoopForm.issueNum
                bookmarkStr = "Issue" & i
                If IssuesLoopForm.arrayIssues(i) <> "" Then
                    'Write text to the bookmark.
                    Clipboard.SetText(IssuesLoopForm.arrayIssues(i), TextDataFormat.Rtf)
                    myRange = APPealableForm.wordDoc.Bookmarks(bookmarkStr).Range
                    myRange.PasteAndFormat(Word.WdRecoveryType.wdFormatSurroundingFormattingWithEmphasis)
                    strRTFToText = rtftotext(IssuesLoopForm.arrayIssues(i))
                    rtfLength = RTrim(strRTFToText).Length
                    myStart = myRange.Start
                    myEnd = myStart + rtfLength
                    wordDoc.Range(Start:=myEnd - 1, [End]:=myEnd).Delete(Unit:=Word.WdUnits.wdCharacter, Count:=1)
                    myEnd = myEnd - 1
                    myRange = wordDoc.Range(Start:=myStart, [End]:=myEnd)
                    APPealableForm.wordDoc.Bookmarks.Add(Name:=bookmarkStr, Range:=myRange)
                    myRange.Font.AllCaps = True
                    i += 1
                Else
                    i += 1
                End If
            End While
            i = 0
        ElseIf stringName = "Arguments" Then
            While i < ArgumentsLoopForm.argNum
                bookmarkStr = "ArgHeader" & i
                If ArgumentsLoopForm.arrayArgsHeader(i) <> "" Then
                    Clipboard.SetText(ArgumentsLoopForm.arrayArgsHeader(i), TextDataFormat.Rtf)
                    myRange = APPealableForm.wordDoc.Bookmarks(bookmarkStr).Range
                    myRange.PasteAndFormat(Word.WdRecoveryType.wdFormatSurroundingFormattingWithEmphasis)
                    strRTFToText = rtftotext(ArgumentsLoopForm.arrayArgsHeader(i))
                    rtfLength = RTrim(strRTFToText).Length
                    myStart = myRange.Start
                    myEnd = myStart + rtfLength
                    wordDoc.Range(Start:=myEnd - 1, [End]:=myEnd).Delete(Unit:=Word.WdUnits.wdCharacter, Count:=1)
                    myEnd = myEnd - 1
                    myRange = wordDoc.Range(Start:=myStart, [End]:=myEnd)
                    APPealableForm.wordDoc.Bookmarks.Add(Name:=bookmarkStr, Range:=myRange)
                    myRange.Font.AllCaps = True
                    i += 1
                Else
                    i += 1
                End If
            End While
            i = 0
            While i < ArgumentsLoopForm.argNum
                bookmarkStr = "Arg" & i
                If ArgumentsLoopForm.arrayArgs(i) <> "" Then
                    Clipboard.SetText(ArgumentsLoopForm.arrayArgs(i), TextDataFormat.Rtf)
                    myRange = APPealableForm.wordDoc.Bookmarks(bookmarkStr).Range
                    myRange.PasteAndFormat(Word.WdRecoveryType.wdFormatSurroundingFormattingWithEmphasis)
                    strRTFToText = rtftotext(ArgumentsLoopForm.arrayArgs(i))
                    rtfLength = RTrim(strRTFToText).Length
                    myStart = myRange.Start
                    myEnd = myStart + rtfLength - 1
                    myRange = wordDoc.Range(Start:=myStart, [End]:=myEnd)
                    'wordDoc.Range(Start:=myEnd).Delete(Unit:=Word.WdUnits.wdCharacter, Count:=1)
                    APPealableForm.wordDoc.Bookmarks.Add(Name:=bookmarkStr, Range:=myRange)
                    i += 1
                Else
                    i += 1
                End If
            End While
            i = 0
        ElseIf stringName = "Cases" Then
            While i < CasesLoopForm.caseNum
                If CasesLoopForm.caseName(i) <> "" Then
                    wordDoc.TablesOfAuthorities.MarkAllCitations(LongCitation:=CasesLoopForm.caseName(i), ShortCitation:=CasesLoopForm.caseName(i), Category:=1)
                    i += 1
                Else
                    i += 1
                End If
            End While
            i = 0
        ElseIf stringName = "Statutes" Then
            While i < StatutesLoopForm.statNum
                If StatutesLoopForm.statName(i) <> "" Then
                    wordDoc.TablesOfAuthorities.MarkAllCitations(LongCitation:=StatutesLoopForm.statName(i), ShortCitation:=StatutesLoopForm.statName(i), Category:=2)
                    i += 1
                Else
                    i += 1
                End If
            End While
            i = 0
        ElseIf stringName = "SubArgs" Then
            While y < ArgumentsLoopForm.subNum0
                bookmarkStr = "SubArgHeader0" & y
                If ArgumentsLoopForm.arraySubArgsHeader0(y) <> "" Then
                    Clipboard.SetText(ArgumentsLoopForm.arraySubArgsHeader0(y), TextDataFormat.Rtf)
                    myRange = APPealableForm.wordDoc.Bookmarks(bookmarkStr).Range
                    myRange.PasteAndFormat(Word.WdRecoveryType.wdFormatSurroundingFormattingWithEmphasis)
                    strRTFToText = rtftotext(ArgumentsLoopForm.arraySubArgsHeader0(y))
                    rtfLength = RTrim(strRTFToText).Length
                    myStart = myRange.Start
                    myEnd = myStart + rtfLength
                    wordDoc.Range(Start:=myEnd - 1, [End]:=myEnd).Delete(Unit:=Word.WdUnits.wdCharacter, Count:=1)
                    myEnd = myEnd - 1
                    myRange = wordDoc.Range(Start:=myStart, [End]:=myEnd)
                    APPealableForm.wordDoc.Bookmarks.Add(Name:=bookmarkStr, Range:=myRange)
                    myRange.Font.AllCaps = True
                    y += 1
                Else
                    y += 1
                End If
            End While
            y = 0
            While y < ArgumentsLoopForm.subNum1
                bookmarkStr = "SubArgHeader1" & y
                If ArgumentsLoopForm.arraySubArgsHeader1(y) <> "" Then
                    Clipboard.SetText(ArgumentsLoopForm.arraySubArgsHeader1(y), TextDataFormat.Rtf)
                    myRange = APPealableForm.wordDoc.Bookmarks(bookmarkStr).Range
                    myRange.PasteAndFormat(Word.WdRecoveryType.wdFormatSurroundingFormattingWithEmphasis)
                    strRTFToText = rtftotext(ArgumentsLoopForm.arraySubArgsHeader1(y))
                    rtfLength = RTrim(strRTFToText).Length
                    myStart = myRange.Start
                    myEnd = myStart + rtfLength
                    wordDoc.Range(Start:=myEnd - 1, [End]:=myEnd).Delete(Unit:=Word.WdUnits.wdCharacter, Count:=1)
                    myEnd = myEnd - 1
                    myRange = wordDoc.Range(Start:=myStart, [End]:=myEnd)
                    APPealableForm.wordDoc.Bookmarks.Add(Name:=bookmarkStr, Range:=myRange)
                    myRange.Font.AllCaps = True
                    y += 1
                Else
                    y += 1
                End If
            End While
            y = 0
            While y < ArgumentsLoopForm.subNum2
                bookmarkStr = "SubArgHeader2" & y
                If ArgumentsLoopForm.arraySubArgsHeader2(y) <> "" Then
                    Clipboard.SetText(ArgumentsLoopForm.arraySubArgsHeader2(y), TextDataFormat.Rtf)
                    myRange = APPealableForm.wordDoc.Bookmarks(bookmarkStr).Range
                    myRange.PasteAndFormat(Word.WdRecoveryType.wdFormatSurroundingFormattingWithEmphasis)
                    strRTFToText = rtftotext(ArgumentsLoopForm.arraySubArgsHeader2(y))
                    rtfLength = RTrim(strRTFToText).Length
                    myStart = myRange.Start
                    myEnd = myStart + rtfLength
                    wordDoc.Range(Start:=myEnd - 1, [End]:=myEnd).Delete(Unit:=Word.WdUnits.wdCharacter, Count:=1)
                    myEnd = myEnd - 1
                    myRange = wordDoc.Range(Start:=myStart, [End]:=myEnd)
                    APPealableForm.wordDoc.Bookmarks.Add(Name:=bookmarkStr, Range:=myRange)
                    myRange.Font.AllCaps = True
                    y += 1
                Else
                    y += 1
                End If
            End While
            y = 0
            While y < ArgumentsLoopForm.subNum0
                bookmarkStr = "SubArg0" & y
                If ArgumentsLoopForm.arraySubArgs0(y) <> "" Then
                    Clipboard.SetText(ArgumentsLoopForm.arraySubArgs0(y), TextDataFormat.Rtf)
                    myRange = APPealableForm.wordDoc.Bookmarks(bookmarkStr).Range
                    myRange.PasteAndFormat(Word.WdRecoveryType.wdFormatSurroundingFormattingWithEmphasis)
                    strRTFToText = rtftotext(ArgumentsLoopForm.arraySubArgs0(y))
                    rtfLength = RTrim(strRTFToText).Length
                    myStart = myRange.Start
                    myEnd = myStart + rtfLength - 1
                    myRange = wordDoc.Range(Start:=myStart, [End]:=myEnd)
                    'wordDoc.Range(Start:=myEnd).Delete(Unit:=Word.WdUnits.wdCharacter, Count:=1)
                    APPealableForm.wordDoc.Bookmarks.Add(Name:=bookmarkStr, Range:=myRange)
                    y += 1
                Else
                    y += 1
                End If
            End While
            y = 0
            While y < ArgumentsLoopForm.subNum1
                bookmarkStr = "SubArg1" & y
                If ArgumentsLoopForm.arraySubArgs1(y) <> "" Then
                    Clipboard.SetText(ArgumentsLoopForm.arraySubArgs1(y), TextDataFormat.Rtf)
                    myRange = APPealableForm.wordDoc.Bookmarks(bookmarkStr).Range
                    myRange.PasteAndFormat(Word.WdRecoveryType.wdFormatSurroundingFormattingWithEmphasis)
                    strRTFToText = rtftotext(ArgumentsLoopForm.arraySubArgs1(y))
                    rtfLength = RTrim(strRTFToText).Length
                    myStart = myRange.Start
                    myEnd = myStart + rtfLength - 1
                    myRange = wordDoc.Range(Start:=myStart, [End]:=myEnd)
                    'wordDoc.Range(Start:=myEnd).Delete(Unit:=Word.WdUnits.wdCharacter, Count:=1)
                    APPealableForm.wordDoc.Bookmarks.Add(Name:=bookmarkStr, Range:=myRange)
                    y += 1
                Else
                    y += 1
                End If
            End While
            y = 0
            While y < ArgumentsLoopForm.subNum2
                bookmarkStr = "SubArg2" & y
                If ArgumentsLoopForm.arraySubArgs2(y) <> "" Then
                    Clipboard.SetText(ArgumentsLoopForm.arraySubArgs2(y), TextDataFormat.Rtf)
                    myRange = APPealableForm.wordDoc.Bookmarks(bookmarkStr).Range
                    myRange.PasteAndFormat(Word.WdRecoveryType.wdFormatSurroundingFormattingWithEmphasis)
                    strRTFToText = rtftotext(ArgumentsLoopForm.arraySubArgs2(y))
                    rtfLength = RTrim(strRTFToText).Length
                    myStart = myRange.Start
                    myEnd = myStart + rtfLength - 1
                    myRange = wordDoc.Range(Start:=myStart, [End]:=myEnd)
                    'wordDoc.Range(Start:=myEnd).Delete(Unit:=Word.WdUnits.wdCharacter, Count:=1)
                    APPealableForm.wordDoc.Bookmarks.Add(Name:=bookmarkStr, Range:=myRange)
                    y += 1
                Else
                    y += 1
                End If
            End While
        End If
    End Sub

    'Insert Table of Contents
    Sub insertTOC(wordDoc As Word.Document)
        Dim TOCrange As Word.Range
        TOCrange = wordDoc.Sections(2).Range.Paragraphs(2).Range
        wordDoc.TablesOfContents.Add(Range:=TOCrange, RightAlignPageNumbers:=True, IncludePageNumbers:=True, UseHyperlinks:=True, UseOutlineLevels:=True)
    End Sub

    'Insert Table of Authorities
    Public Sub insertTOA(wordDoc As Word.Document)
        Dim myCase, myStat As String
        Dim myRange As Word.Range

        myRange = wordDoc.Sections(3).Range.Paragraphs(2).Range
        wordDoc.TablesOfAuthorities.Add(Range:=myRange, Category:=2, Separator:=",", IncludeCategoryHeader:=True, PageNumberSeparator:=",", PageRangeSeparator:="-")
        wordDoc.TablesOfAuthorities(1).Range.Font.Size = 12
        myRange.InsertParagraphBefore()
        myRange = wordDoc.Sections(3).Range.Paragraphs(2).Range
        wordDoc.TablesOfAuthorities.Add(Range:=myRange, Category:=1, Separator:=",", IncludeCategoryHeader:=True, PageNumberSeparator:=",", PageRangeSeparator:="-")
        wordDoc.TablesOfAuthorities(2).Range.Font.Size = 12
        wordDoc.TablesOfAuthorities.Format = Word.WdToaFormat.wdTOATemplate
        wordDoc.TablesOfAuthoritiesCategories(1).Name = "Cases"
        wordDoc.TablesOfAuthoritiesCategories(2).Name = "Statutes"
        For Each myCase In CasesLoopForm.caseName
            wordDoc.TablesOfAuthorities.MarkAllCitations(ShortCitation:=myCase, Category:=1)
        Next
        For Each myStat In StatutesLoopForm.statName
            wordDoc.TablesOfAuthorities.MarkAllCitations(ShortCitation:=myStat, Category:=2)
        Next

        wordDoc.TablesOfAuthorities(1).Update()
    End Sub

    'Change Document Font
    Public Sub changeDocumentFont(document As Word.Document, font As String)
        document.Content.Font.Name = font
        document.Range.Font.Name = font
    End Sub

    'Convert RTF to Text to get Length of Text
    Private Function rtftotext(ByVal rtfstring As String) As String
        Dim rtf1 As New RichTextBox
        rtf1.Rtf = rtfstring
        Return RTFToPlainText(rtf1)
    End Function
    Private Function RTFToPlainText(ByVal rtfbox As RichTextBox) As String
        Dim str As String = String.Empty
        For Each line As String In rtfbox.Lines
            str += line & vbCrLf
        Next
        Return str
    End Function

    Private Function findSpellingErrors(ByRef document As Word.Document, myTextbox As RichTextBox) As Integer
        Dim ret As Integer = 0
        document.SpellingChecked = False
        Dim spellingErrors As Word.ProofreadingErrors = TryCast(document.SpellingErrors, Word.ProofreadingErrors)
        If spellingErrors IsNot Nothing Then
            Try
                ret = spellingErrors.Count
                For i As Integer = 1 To spellingErrors.Count
                    Dim itemError As Word.Range = spellingErrors.Item(i)
                    If itemError IsNot Nothing Then
                        Try
                            myTextbox.Find(itemError.Text, itemError.Start, RichTextBoxFinds.MatchCase Or RichTextBoxFinds.WholeWord)
                            myTextbox.SelectionColor = Color.Red
                        Finally
                            Runtime.InteropServices.Marshal.ReleaseComObject(itemError)
                        End Try
                    End If
                Next
            Finally
                Runtime.InteropServices.Marshal.ReleaseComObject(spellingErrors)
            End Try
        End If
        Return ret
    End Function


End Module
