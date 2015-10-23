Imports FreeTextBoxControls

#Region "History"
' Creation - JCA - 12 March 2010 - New control to fully implement the FTB with spell check and toolbar customization
#End Region
<ValidationProperty("ValidationText")> _
Partial Class UserControls_wucHTMLSpell
    Inherits System.Web.UI.UserControl
#Region "Class Storage"
    Dim _errorMessage As String = String.Empty
    Dim _errorDetails As String = String.Empty
#End Region
#Region "Public Properties Events and Methods"
    Public ReadOnly Property ValidationText() As String
        Get
            'If String.IsNullOrEmpty(ftbHTMLEditor.HtmlStrippedText) Then
            '    Return Nothing
            'Else
            Return ftbHTMLEditor.HtmlStrippedText

            'End If
        End Get
    End Property

    Public ReadOnly Property ErrorMessage() As String
        Get
            Return _errorMessage
        End Get
    End Property

    Public ReadOnly Property ErrorDetails() As String
        Get
            Return _errorDetails
        End Get
    End Property
    Public Property Width() As Unit
        Get
            Return ftbHTMLEditor.Width
        End Get
        Set(ByVal value As Unit)
            ftbHTMLEditor.Width = value
        End Set
    End Property
    Public Property Height() As Unit
        Get
            Return ftbHTMLEditor.Height.ToString
        End Get
        Set(ByVal value As Unit)
            ftbHTMLEditor.Height = value
        End Set
    End Property
    Public ReadOnly Property TextContent() As String
        Get
            Return ftbHTMLEditor.HtmlStrippedText
        End Get
    End Property
    Public Property HTMLContent() As String
        Get
            Return ftbHTMLEditor.Text
        End Get
        Set(ByVal value As String)
            ftbHTMLEditor.Text = value
        End Set
    End Property
    Public WriteOnly Property SetReadOnly() As Boolean
        Set(ByVal value As Boolean)
            ftbHTMLEditor.ReadOnly = value
        End Set
    End Property
    Public Property EnableHtmlMode() As Boolean
        Get
            Return ftbHTMLEditor.EnableHtmlMode
        End Get
        Set(ByVal value As Boolean)
            ftbHTMLEditor.EnableHtmlMode = value
        End Set
    End Property

    Public Function Populate() As Boolean

    End Function
    Public Function Save() As Boolean

    End Function
    Public Function Insert() As Boolean

    End Function
    Public Function Delete() As Boolean

    End Function

    ' The following subroutines are for turning on the various buttons in the toolbar.
    Public Sub AddAllToolbars()

        Dim fontStyleToolbar As New Toolbar
        fontStyleToolbar.Items.Add(New ParagraphMenu)
        fontStyleToolbar.Items.Add(New FontFacesMenu)
        fontStyleToolbar.Items.Add(New FontSizesMenu)
        fontStyleToolbar.Items.Add(New FontForeColorsMenu)
        fontStyleToolbar.Items.Add(New FontForeColorPicker)
        fontStyleToolbar.Items.Add(New FontBackColorsMenu)
        fontStyleToolbar.Items.Add(New FontBackColorPicker)

        ftbHTMLEditor.Toolbars.Add(fontStyleToolbar)

        Dim fontFormatToolbar As New Toolbar
        fontFormatToolbar.Items.Add(New Bold)
        fontFormatToolbar.Items.Add(New Italic)
        fontFormatToolbar.Items.Add(New Underline)
        fontFormatToolbar.Items.Add(New StrikeThrough)
        fontFormatToolbar.Items.Add(New SuperScript)
        fontFormatToolbar.Items.Add(New SubScript)
        fontFormatToolbar.Items.Add(New RemoveFormat)

        ftbHTMLEditor.Toolbars.Add(fontFormatToolbar)

        Dim paragraphToolbar As New Toolbar
        paragraphToolbar.Items.Add(New JustifyLeft)
        paragraphToolbar.Items.Add(New JustifyCenter)
        paragraphToolbar.Items.Add(New JustifyRight)
        paragraphToolbar.Items.Add(New JustifyFull)
        paragraphToolbar.Items.Add(New ToolbarSeparator)
        paragraphToolbar.Items.Add(New BulletedList)
        paragraphToolbar.Items.Add(New NumberedList)
        paragraphToolbar.Items.Add(New Indent)
        paragraphToolbar.Items.Add(New Outdent)
        paragraphToolbar.Items.Add(New ToolbarSeparator)
        paragraphToolbar.Items.Add(New CreateLink)
        paragraphToolbar.Items.Add(New Unlink)
        paragraphToolbar.Items.Add(New InsertImage)

        ftbHTMLEditor.Toolbars.Add(paragraphToolbar)

        Dim fileToolbar As New Toolbar
        fileToolbar.Items.Add(New Cut)
        fileToolbar.Items.Add(New Copy)
        fileToolbar.Items.Add(New Paste)
        fileToolbar.Items.Add(New Delete)
        fileToolbar.Items.Add(New ToolbarSeparator)
        fileToolbar.Items.Add(New Undo)
        fileToolbar.Items.Add(New Redo)
        fileToolbar.Items.Add(New Print)
        fileToolbar.Items.Add(New Save)

        ftbHTMLEditor.Toolbars.Add(fileToolbar)

        Dim miscToolBar As New Toolbar
        miscToolBar.Items.Add(New InsertImageFromGallery)
        miscToolBar.Items.Add(New Preview)
        miscToolBar.Items.Add(New WordClean)
        miscToolBar.Items.Add(New SelectAll)
        Dim spellCheck As New FreeTextBoxControls.NetSpell
        miscToolBar.Items.Add(spellCheck)

        ftbHTMLEditor.Toolbars.Add(miscToolBar)
    End Sub

    Public Sub AddMiscToolbar()
        Dim miscToolBar As New Toolbar
        miscToolBar.Items.Add(New InsertImageFromGallery)
        miscToolBar.Items.Add(New Preview)
        miscToolBar.Items.Add(New WordClean)
        miscToolBar.Items.Add(New SelectAll)
        Dim spellCheck As New FreeTextBoxControls.NetSpell
        miscToolBar.Items.Add(spellCheck)

        ftbHTMLEditor.Toolbars.Add(miscToolBar)
    End Sub

    Public Sub AddFileToolbar()
        Dim fileToolbar As New Toolbar
        fileToolbar.Items.Add(New Cut)
        fileToolbar.Items.Add(New Copy)
        fileToolbar.Items.Add(New Paste)
        fileToolbar.Items.Add(New Delete)
        fileToolbar.Items.Add(New ToolbarSeparator)
        fileToolbar.Items.Add(New Undo)
        fileToolbar.Items.Add(New Redo)
        fileToolbar.Items.Add(New Print)
        fileToolbar.Items.Add(New Save)

        ftbHTMLEditor.Toolbars.Add(fileToolbar)
    End Sub

    Public Sub AddParagraphToolbar()
        Dim paragraphToolbar As New Toolbar
        paragraphToolbar.Items.Add(New JustifyLeft)
        paragraphToolbar.Items.Add(New JustifyCenter)
        paragraphToolbar.Items.Add(New JustifyRight)
        paragraphToolbar.Items.Add(New JustifyFull)
        paragraphToolbar.Items.Add(New ToolbarSeparator)
        paragraphToolbar.Items.Add(New BulletedList)
        paragraphToolbar.Items.Add(New NumberedList)
        paragraphToolbar.Items.Add(New Indent)
        paragraphToolbar.Items.Add(New Outdent)
        paragraphToolbar.Items.Add(New ToolbarSeparator)
        paragraphToolbar.Items.Add(New CreateLink)
        paragraphToolbar.Items.Add(New Unlink)
        paragraphToolbar.Items.Add(New InsertImage)

        ftbHTMLEditor.Toolbars.Add(paragraphToolbar)
    End Sub

    Public Sub AddFontFormatToolbar()
        Dim fontFormatToolbar As New Toolbar
        fontFormatToolbar.Items.Add(New Bold)
        fontFormatToolbar.Items.Add(New Italic)
        fontFormatToolbar.Items.Add(New Underline)
        fontFormatToolbar.Items.Add(New StrikeThrough)
        fontFormatToolbar.Items.Add(New SuperScript)
        fontFormatToolbar.Items.Add(New SubScript)
        fontFormatToolbar.Items.Add(New RemoveFormat)

        ftbHTMLEditor.Toolbars.Add(fontFormatToolbar)
    End Sub

    Public Sub AddFontStyleToolbar()
        Dim fontStyleToolbar As New Toolbar
        fontStyleToolbar.Items.Add(New ParagraphMenu)
        fontStyleToolbar.Items.Add(New FontFacesMenu)
        fontStyleToolbar.Items.Add(New FontSizesMenu)
        fontStyleToolbar.Items.Add(New FontForeColorsMenu)
        fontStyleToolbar.Items.Add(New FontForeColorPicker)
        fontStyleToolbar.Items.Add(New FontBackColorsMenu)
        fontStyleToolbar.Items.Add(New FontBackColorPicker)

        ftbHTMLEditor.Toolbars.Add(fontStyleToolbar)
    End Sub
    ''' <summary>
    ''' This subroutine takes a comma delimited string as an input and parses
    ''' it, adding the button associated with each element of the string to
    ''' a given toolbar and then adds that toolbar. This allows the user of the control to create as many
    ''' toolbars as they like with whatever buttons are available.
    ''' </summary>
    ''' <param name="buttons">Comma delimited string.</param>
    ''' <remarks></remarks>
    Public Sub CustomToolbar(ByVal buttons As String)

        Dim customToolbar As New Toolbar

        Dim buttonArray As String() = buttons.Split(",")

        For Each button As String In buttonArray
            Select Case button.ToLower
                Case "bold"
                    customToolbar.Items.Add(New Bold)
                Case "bulletedlist"
                    customToolbar.Items.Add(New BulletedList)
                Case "copy"
                    customToolbar.Items.Add(New Copy)
                Case "createlink"
                    customToolbar.Items.Add(New CreateLink)
                Case "cut"
                    customToolbar.Items.Add(New Cut)
                Case "delete"
                    customToolbar.Items.Add(New Delete)
                Case "fontbackcolor"
                    customToolbar.Items.Add(New FontBackColorsMenu)
                    customToolbar.Items.Add(New FontBackColorPicker)
                Case "fontfaces"
                    customToolbar.Items.Add(New FontFacesMenu)
                Case "fontforecolor"
                    customToolbar.Items.Add(New FontForeColorsMenu)
                    customToolbar.Items.Add(New FontForeColorPicker)
                Case "fontsizes"
                    customToolbar.Items.Add(New FontSizesMenu)
                Case "imagegallery"
                    customToolbar.Items.Add(New InsertImageFromGallery)
                Case "indent"
                    customToolbar.Items.Add(New Indent)
                Case "insertimage"
                    customToolbar.Items.Add(New InsertImage)
                Case "italic"
                    customToolbar.Items.Add(New Italic)
                Case "justifyleft"
                    customToolbar.Items.Add(New JustifyLeft)
                Case "justifycenter"
                    customToolbar.Items.Add(New JustifyCenter)
                Case "justifyright"
                    customToolbar.Items.Add(New JustifyRight)
                Case "justifyfull"
                    customToolbar.Items.Add(New JustifyFull)
                Case "paragraph"
                    customToolbar.Items.Add(New ParagraphMenu)
                Case "underline"
                    customToolbar.Items.Add(New Underline)
                Case "strikethrough"
                    customToolbar.Items.Add(New StrikeThrough)
                Case "superscript"
                    customToolbar.Items.Add(New SuperScript)
                Case "subscript"
                    customToolbar.Items.Add(New SubScript)
                Case "removeformat"
                    customToolbar.Items.Add(New RemoveFormat)
                Case "numberedlist"
                    customToolbar.Items.Add(New NumberedList)
                Case "outdent"
                    customToolbar.Items.Add(New Outdent)
                Case "separator"
                    customToolbar.Items.Add(New ToolbarSeparator)
                Case "unlink"
                    customToolbar.Items.Add(New Unlink)
                Case "paste"
                    customToolbar.Items.Add(New Paste)
                Case "undo"
                    customToolbar.Items.Add(New Undo)
                Case "redo"
                    customToolbar.Items.Add(New Redo)
                Case "print"
                    customToolbar.Items.Add(New Print)
                Case "save"
                    customToolbar.Items.Add(New Save)
                Case "preview"
                    customToolbar.Items.Add(New Preview)
                Case "wordclean"
                    customToolbar.Items.Add(New WordClean)
                Case "selectall"
                    customToolbar.Items.Add(New SelectAll)
                Case "spellcheck"
                    Dim spellCheck As New FreeTextBoxControls.NetSpell
                    customToolbar.Items.Add(spellCheck)
            End Select
        Next
        ftbHTMLEditor.Toolbars.Add(customToolbar)
    End Sub

    Public Sub ClearAllToolbars()
        ftbHTMLEditor.Toolbars.Clear()
    End Sub
#End Region
#Region "Private Methods"

#End Region
#Region "Protected Page Events"

#End Region
End Class
