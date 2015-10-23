#Region "History"
' Thomas Verry 1.27.10 Control creation
#End Region

Partial Class UserControls_wucHelpBox
    Inherits System.Web.UI.UserControl

#Region "Class Storage"
    Dim _dl As New NCUDataLayer
    Dim _sql As String = String.Empty
    Dim _errorMessage As String = String.Empty
    Dim _successMessage As String = String.Empty



#End Region
#Region "Public properties, events and methods"
    Public ReadOnly Property ErrorMessage() As String
        Get
            Return _errorMessage
        End Get
    End Property
    Public ReadOnly Property SuccessMessage() As String
        Get
            Return _successMessage
        End Get
    End Property

    Public Event ErrorMessageChanged()
    Public Event SuccessMessageChanged()

    Public Function Populate(ByVal screenName As String, ByVal fieldName As String, Optional ByVal isPostBack As Boolean = False) As Boolean
        If Not String.IsNullOrEmpty(fieldName) Then
            ltlHelpField.Text = "<h3>This screen has been opened in a new window. <br><span style=""font-weight:normal"">" & screenName & "</span>'s Help page for <span style=""font-weight:normal"">" & fieldName & "</span></h3>"
        Else
            ltlHelpField.Text = "<h3>This screen has been opened in a new window. <br>Help page for <span style=""font-weight:normal"">" & screenName & "</span> screen.</h3>"

        End If
        hfFieldName.Value = fieldName
        hfScreenName.Value = screenName
        hfUserId.Value = NCUSecurity.CurrentLetmeinUserID.ToString
        btnScreenLink.ToolTip = screenName
        'CType(apGenDoc.HeaderContainer.FindControl("imgHlpGenDoc"), Image).ToolTip = "You should put helpful information in this box."
        'CType(apGenDoc.HeaderContainer.FindControl("lblGenDoc"), Label).Attributes.Add("align", "left")

        If NCUSecurity.UserIsInGroup(_dl, "SecurityGd") Then
            hfSecurity.Value = "SecurityGd"
            CType(apGenDoc.ContentContainer.FindControl("pnlGeneralDoc"), Panel).Visible = False
        ElseIf NCUSecurity.UserIsInGroup(_dl, "DocumentWriter") Then
            hfSecurity.Value = "DocumentWriter"
            CType(apGenDoc.ContentContainer.FindControl("pnlGeneralDoc"), Panel).Visible = False
        Else
            hfSecurity.Value = "none"
            CType(apGenDoc.ContentContainer.FindControl("ftbGeneralDoc"), FreeTextBoxControls.FreeTextBox).Visible = False
            'ftbGeneralDoc.ReadOnly = True
        End If
        'hfSecurity.Value = "SecurityGd"
        'hfSecurity.Value = "DocumentWriter"
        'CType(apGenDoc.ContentContainer.FindControl("pnlGeneralDoc"), Panel).Visible = False


        GetGeneralDoc()
        GetUserNotes()

    End Function
#End Region
#Region "Private methods"
    ''' <summary>
    ''' GetGeneralDoc will fill the general doc field with the results from the database query
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub GetGeneralDoc()
        hfUniqueGdBlobID.Value = String.Empty

        _sql = "SELECT general_doc_blob, helpdoc_field_blob_id, tooltip_info FROM helpdoc_field_blobs WHERE field_name = '" & hfFieldName.Value & "' AND screen_name = '" & hfScreenName.Value & "'"

        Try
            If Not _dl.SqlSelect(_sql) Then
                _sql = "SELECT general_doc_blob, helpdoc_field_blob_id, tooltip_info FROM helpdoc_field_blobs WHERE field_name = '" & hfFieldName.Value & "' AND general = '1' "
                If _dl.SqlSelect(_sql) Then
                    If Not hfSecurity.Value = "none" Then
                        CType(apGenDoc.ContentContainer.FindControl("ftbGeneralDoc"), FreeTextBoxControls.FreeTextBox).Text = _dl._DR("general_doc_blob")
                        If Not String.IsNullOrEmpty(_dl._DR("tooltip_info")) Then
                            CType(apGenDoc.HeaderContainer.FindControl("imgHlpGenDoc"), System.Web.UI.WebControls.Image).ToolTip = _dl._DR("tooltip_info")
                        Else
                            CType(apGenDoc.HeaderContainer.FindControl("imgHlpGenDoc"), System.Web.UI.WebControls.Image).ToolTip = "No suggestions found."
                        End If
                        CType(apGenDoc.ContentContainer.FindControl("ftbGeneralDoc"), FreeTextBoxControls.FreeTextBox).Visible = True
                        CType(apGenDoc.ContentContainer.FindControl("pnlGeneralDoc"), System.Web.UI.WebControls.Panel).Visible = False

                    Else
                        CType(apGenDoc.ContentContainer.FindControl("ltlGeneralDoc"), System.Web.UI.WebControls.Literal).Text = _dl._DR("general_doc_blob")
                        CType(apGenDoc.ContentContainer.FindControl("pnlGeneralDoc"), System.Web.UI.WebControls.Panel).Visible = True
                        CType(apGenDoc.ContentContainer.FindControl("pnlGeneralDoc"), System.Web.UI.WebControls.Panel).Attributes.Add("align", "left")

                    End If
                        hfUniqueGdBlobID.Value = _dl._DR("helpdoc_field_blob_id")
                    ElseIf _dl.Severity > 0 Then
                        CType(apGenDoc.ContentContainer.FindControl("ftbGeneralDoc"), FreeTextBoxControls.FreeTextBox).Text = "There is no help documentation written for this screen. You may write help documentation."
                    CType(apGenDoc.ContentContainer.FindControl("ltlGeneralDoc"), System.Web.UI.WebControls.Literal).Text = "There is no help documentation for this screen"
                    If Not hfSecurity.Value = "none" Then
                        CType(apGenDoc.ContentContainer.FindControl("ftbGeneralDoc"), FreeTextBoxControls.FreeTextBox).Visible = True
                        If Not String.IsNullOrEmpty(_dl._DR("tooltip_info").ToString) Then
                            CType(apGenDoc.HeaderContainer.FindControl("imgHlpGenDoc"), System.Web.UI.WebControls.Image).ToolTip = _dl._DR("tooltip_info")
                        Else
                            CType(apGenDoc.HeaderContainer.FindControl("imgHlpGenDoc"), System.Web.UI.WebControls.Image).ToolTip = "No suggestions found."
                        End If
                        CType(apGenDoc.ContentContainer.FindControl("pnlGeneralDoc"), Panel).Visible = False

                    Else
                        CType(apGenDoc.ContentContainer.FindControl("pnlGeneralDoc"), Panel).Visible = True
                        CType(apGenDoc.ContentContainer.FindControl("pnlGeneralDoc"), Panel).Attributes.Add("align", "left")
                        CType(apGenDoc.ContentContainer.FindControl("ftbGeneralDoc"), FreeTextBoxControls.FreeTextBox).Visible = False
                    End If
                    Else
                        _errorMessage = "There was an error getting the general documentation. " & _dl.Results
                        RaiseEvent ErrorMessageChanged()
                    End If
            Else
                If Not hfSecurity.Value = "none" Then
                    CType(apGenDoc.ContentContainer.FindControl("ftbGeneralDoc"), FreeTextBoxControls.FreeTextBox).Text = _dl._DR("general_doc_blob")
                    CType(apGenDoc.ContentContainer.FindControl("ftbGeneralDoc"), FreeTextBoxControls.FreeTextBox).Visible = True
                    If Not String.IsNullOrEmpty(_dl._DR("tooltip_info").ToString) Then
                        CType(apGenDoc.HeaderContainer.FindControl("imgHlpGenDoc"), System.Web.UI.WebControls.Image).ToolTip = _dl._DR("tooltip_info")
                    Else
                        CType(apGenDoc.HeaderContainer.FindControl("imgHlpGenDoc"), System.Web.UI.WebControls.Image).ToolTip = "No suggestions found."
                    End If

                    CType(apGenDoc.ContentContainer.FindControl("pnlGeneralDoc"), Panel).Visible = False


                Else
                    CType(apGenDoc.ContentContainer.FindControl("ltlGeneralDoc"), Literal).Text = _dl._DR("general_doc_blob")
                    CType(apGenDoc.ContentContainer.FindControl("pnlGeneralDoc"), Panel).Visible = True
                    CType(apGenDoc.ContentContainer.FindControl("pnlGeneralDoc"), Panel).Attributes.Add("align", "left")
                End If
                hfUniqueGdBlobID.Value = _dl._DR("helpdoc_field_blob_id")
            End If

        Catch ex As Exception
            _errorMessage = "There was an error getting the general documentation. " & ex.Message & ":" & ex.StackTrace
            RaiseEvent ErrorMessageChanged()
        End Try
    End Sub
    ''' <summary>
    ''' GetUserNotes will fill the user notes field with the results from the database query
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub GetUserNotes()
        hfUniqueUsrBlobID.Value = String.Empty
        If Not hfSecurity.Value.Equals("none") Then
            _sql = "SELECT user_id, user_notes_blob, last_edited, helpdoc_user_blob_id FROM helpdoc_user_blobs WHERE field_name = '" & hfFieldName.Value & "' AND screen_name = '" & hfScreenName.Value & "' ORDER BY last_edited DESC"
        Else
            _sql = "SELECT user_notes_blob, helpdoc_user_blob_id FROM helpdoc_user_blobs WHERE field_name = '" & hfFieldName.Value & "' AND screen_name = '" & hfScreenName.Value & "' AND user_id = '" & hfUserId.Value & "'"
        End If

        Try
            If _dl.SqlSelect(_sql) Then
                If hfSecurity.Value.Equals("none") Then
                    CType(apUserDoc.ContentContainer.FindControl("ftbUserNotes"), FreeTextBoxControls.FreeTextBox).Text = _dl._DR("user_notes_blob")
                    hfUniqueUsrBlobID.Value = _dl._DR("helpdoc_user_blob_id")
                Else
                    CType(apUserDoc.ContentContainer.FindControl("ftbUserNotes"), FreeTextBoxControls.FreeTextBox).Text = "You have not written any notes for this page."
                    BuildDocReview(_dl._DT)
                End If

            ElseIf Not _dl._DT.Rows.Count = 0 Then

                _errorMessage = "There was an error getting user documentation. " & _dl.Results
                RaiseEvent ErrorMessageChanged()
            Else
                CType(apUserDoc.ContentContainer.FindControl("ftbUserNotes"), FreeTextBoxControls.FreeTextBox).Text = "You have not written any notes for this page."
                hfUniqueUsrBlobID.Value = String.Empty
                accEdit.Panes.Clear()
            End If
        Catch ex As Exception
            _errorMessage = "There was an error getting user documentation. " & ex.Message & ":" & ex.StackTrace
            RaiseEvent ErrorMessageChanged()
        End Try


    End Sub

    Public Sub BuildDocReview(ByVal dt As DataTable)
        Cache.Insert("user_ids", dt, Nothing, DateTime.Now.AddHours(1), System.Web.Caching.Cache.NoSlidingExpiration)
        accEdit.Panes.Clear()
        Dim index As Integer = 0
        For Each dr As DataRow In dt.Rows
            Dim userId As String = dr("user_id").ToString
            'If userId = NCUSecurity.CurrentLetmeinUserID Then
            If userId = hfUserId.Value Then

                CType(apUserDoc.ContentContainer.FindControl("ftbUserNotes"), FreeTextBoxControls.FreeTextBox).Text = dr("user_notes_blob")
                hfUniqueUsrBlobID.Value = dr("helpdoc_user_blob_id")
            Else

                Dim ftbThis As New FreeTextBoxControls.FreeTextBox
                Dim ltlNoEdtThis As New Literal
                Dim pnlNoEdtThis As New Panel
                Dim pnlThis As New Panel
                Dim imgThis As New Image
                Dim cbThis As New CheckBox
                Dim apThis As New AjaxControlToolkit.AccordionPane
                Dim lblThis As New Label
                Dim lblExThis As New Label
                Dim ltlThis As New Literal
                Dim tblThis As New Table
                Dim trThis As New TableRow
                Dim td1This As New TableCell
                Dim td2This As New TableCell
                Dim td3This As New TableCell


                ftbThis.ID = "ftbThis" & dr("user_id") & index
                ltlNoEdtThis.ID = "ltlNoEdtThis" & dr("user_id") & index
                pnlNoEdtThis.ID = "pnlNoEdtThis" & dr("user_id") & index
                pnlThis.ID = "pnlThis" & dr("user_id") & index
                imgThis.ID = "imgThis" & dr("user_id") & index
                cbThis.ID = "cbThis" & dr("user_id") & index
                apThis.ID = "apThis" & dr("user_id") & index
                lblThis.ID = "lblThis" & dr("user_id") & index
                lblExThis.ID = "lblExThis" & dr("user_id") & index
                ltlThis.ID = "ltlThis" & dr("user_id") & index



                If Not hfSecurity.Value.Equals("SecurityGd") Then
                    cbThis.Enabled = False
                    ftbThis.Visible = False
                Else
                    pnlNoEdtThis.Visible = False

                End If
                _sql = "SELECT first_name + ' ' + last_name As user_name FROM applicant_info WHERE learner_id = '" & dr("user_id") & "'"

                If _dl.SqlSelect(_sql) Then
                    lblThis.Text = "User - " & dr("user_id") & " - " & _dl._DR("user_name") & "      "
                Else
                    lblThis.Text = "User - " & dr("user_id") & "    "
                End If

                lblExThis.Text = "Expand"

                td1This.Width = 200
                td1This.Attributes.Add("align", "left")
                td2This.Width = 200
                td3This.Width = 200
                td3This.Attributes.Add("align", "right")

                lblThis.Font.Bold = True
                lblThis.Style.Add("font-size", "medium")

                ltlNoEdtThis.Text = dr("user_notes_blob")

                pnlNoEdtThis.Height = 200
                pnlNoEdtThis.Width = 617
                pnlNoEdtThis.Attributes.Add("align", "left")

                ftbThis.Text = dr("user_notes_blob")

                ftbThis.Height = 200
                ftbThis.Width = 617
                pnlThis.Controls.Add(ftbThis)
                pnlNoEdtThis.Controls.Add(ltlNoEdtThis)



                imgThis.ImageUrl = "~/images/addnew.gif"
                ltlThis.Text = "<span style=""Font-Size:small"">Delete User Comment  </span>"
                td1This.Controls.Add(imgThis)
                td1This.Controls.Add(lblExThis)
                td2This.Controls.Add(lblThis)

                td3This.Controls.Add(ltlThis)
                td3This.Controls.Add(cbThis)
                trThis.Controls.Add(td1This)
                trThis.Controls.Add(td2This)

                trThis.Controls.Add(td3This)
                tblThis.Controls.Add(trThis)

                'apThis.HeaderContainer.Controls.Add(lblThis)
                'apThis.HeaderContainer.Controls.Add(imgThis)
                'apThis.HeaderContainer.Controls.Add(ltlThis)
                'apThis.HeaderContainer.Controls.Add(cbThis)
                apThis.HeaderContainer.Controls.Add(tblThis)
                apThis.ContentContainer.Controls.Add(pnlThis)
                apThis.ContentContainer.Controls.Add(pnlNoEdtThis)

                accEdit.Panes.Add(apThis)

                index += 1
            End If
        Next

    End Sub

    Private Sub UpdateAllUsers()
        Dim dt As DataTable = CType(Cache("user_ids"), DataTable)
        Dim index As Integer = 0
        Try
            If Not dt Is Nothing Then
                For Each dr As DataRow In dt.Rows
                    If Not dr("user_id").Equals(hfUserId.Value) Then

                        Dim apThis As AjaxControlToolkit.AccordionPane = accEdit.FindControl("apThis" & dr("user_id") & index)
                        Dim cbThis As CheckBox = apThis.HeaderContainer.FindControl("cbThis" & dr("user_id") & index)
                        Dim pnlThis As Panel = apThis.ContentContainer.FindControl("pnlThis" & dr("user_id") & index)
                        Dim ftbThis As FreeTextBoxControls.FreeTextBox = pnlThis.FindControl("ftbThis" & dr("user_id") & index)
                        index += 1

                        If cbThis.Checked Then
                            _sql = "DELETE FROM helpdoc_user_blobs WHERE helpdoc_user_blob_id = " & dr("helpdoc_user_blob_id")
                        Else
                            _sql = "UPDATE helpdoc_user_blobs SET user_notes_blob = '" & ftbThis.Text & "', last_edited = '" & System.DateTime.Now & "' WHERE " & _
                            "helpdoc_user_blob_id = " & dr("helpdoc_user_blob_id")
                        End If

                        If _dl.SqlExecute(_sql) Then
                        Else
                            _errorMessage = "There was an error updating the documentation. For all users" & _dl.Results
                            RaiseEvent ErrorMessageChanged()
                        End If
                    End If

                Next
            Else
                _sql = "SELECT user_id, user_notes_blob, last_edited, helpdoc_user_blob_id FROM helpdoc_user_blobs WHERE field_name = '" & hfFieldName.Value & "' AND screen_name = '" & hfScreenName.Value & "' ORDER BY last_edited DESC"
                If _dl.SqlSelect(_sql) Then
                    Cache.Insert("user_ids", _dl._DT, Nothing, DateTime.Now.AddHours(1), System.Web.Caching.Cache.NoSlidingExpiration)
                    UpdateAllUsers()

                Else
                    _errorMessage = "There was an error updating the documentation. For all users2" & _dl.Results
                    RaiseEvent ErrorMessageChanged()
                End If

            End If

        Catch ex As Exception
            _errorMessage = "There was an error updating the documentation. For all users" & ex.Message & ":" & ex.StackTrace
            RaiseEvent ErrorMessageChanged()
        End Try

    End Sub
#End Region
#Region "Protected page events"
    Protected Sub CancleButtonClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Dim url As String = "HelpTestPage.aspx?user_id=" & hfUserId.Value & "&screen_name=" & hfScreenName.Value & "&field_name=" & hfFieldName.Value
        Response.Redirect(url)
    End Sub
    Protected Sub SaveButtonClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click
        _sql = String.Empty

        If Not String.IsNullOrEmpty(hfUniqueUsrBlobID.Value) Then
            If cbUserDoc.Checked Then
                _sql = "DELETE FROM helpdoc_user_blobs WHERE helpdoc_user_blob_id = " & hfUniqueUsrBlobID.Value
            Else
                _sql = "UPDATE helpdoc_user_blobs SET user_notes_blob = '" & CType(apUserDoc.ContentContainer.FindControl("ftbUserNotes"), FreeTextBoxControls.FreeTextBox).Text & "', last_edited = '" & System.DateTime.Now & "' WHERE " & _
                    "helpdoc_user_blob_id = " & CType(hfUniqueUsrBlobID.Value, Integer)
            End If
        ElseIf Not CType(apUserDoc.ContentContainer.FindControl("ftbUserNotes"), FreeTextBoxControls.FreeTextBox).Text.Equals("You have not written any notes for this page.") Then
            _sql = "INSERT INTO helpdoc_user_blobs (user_id, field_name, screen_name, user_notes_blob, last_edited) VALUES ('" & hfUserId.Value & "' ,'" & hfFieldName.Value & "', '" & _
            hfScreenName.Value & "', '" & CType(apUserDoc.ContentContainer.FindControl("ftbUserNotes"), FreeTextBoxControls.FreeTextBox).Text & "', '" & System.DateTime.Now() & "')"
        End If
        Try
            If Not String.IsNullOrEmpty(_sql) Then
                If _dl.SqlExecute(_sql) Then
                Else
                    _errorMessage = "There was an error updating the documentation. " & _dl.Results
                    RaiseEvent ErrorMessageChanged()
                End If
            End If
            _sql = String.Empty
            If Not hfSecurity.Value.Equals("none") Then
                If Not String.IsNullOrEmpty(hfUniqueGdBlobID.Value) Then
                    _sql = "UPDATE helpdoc_field_blobs SET general_doc_blob = '" & CType(apGenDoc.ContentContainer.FindControl("ftbGeneralDoc"), FreeTextBoxControls.FreeTextBox).Text & "', last_edited = '" & System.DateTime.Now & "' WHERE " & _
                        "helpdoc_field_blob_id = " & CType(hfUniqueGdBlobID.Value, Integer)
                ElseIf Not CType(apGenDoc.ContentContainer.FindControl("ftbGeneralDoc"), FreeTextBoxControls.FreeTextBox).Text.Equals("There is no help documentation written for this screen. You may write help documentation.") Then
                    _sql = "INSERT INTO helpdoc_field_blobs (last_edited_by, field_name, screen_name, general_doc_blob, last_edited, general) VALUES ('" & hfUserId.Value & "' ,'" & hfFieldName.Value & "', '" & _
                    hfScreenName.Value & "', '" & CType(apGenDoc.ContentContainer.FindControl("ftbGeneralDoc"), FreeTextBoxControls.FreeTextBox).Text & "', '" & System.DateTime.Now() & "', 0 )"
                End If
            End If

            If Not String.IsNullOrEmpty(_sql) Then
                If Not _dl.SqlExecute(_sql) Then
                    _errorMessage = "There was an error updating the documentation. " & _dl.Results
                    RaiseEvent ErrorMessageChanged()
                End If
                If hfSecurity.Value.Equals("SecurityGd") Then
                    UpdateAllUsers()
                End If
            End If
            Dim url As String = "HelpPage.aspx?user_id=" & hfUserId.Value & "&screen_name=" & hfScreenName.Value & "&field_name=" & hfFieldName.Value
            Response.Redirect(url)
        Catch ex As Exception
            _errorMessage = "There was an error updating the documentation. " & ex.Message & ":" & ex.StackTrace
            RaiseEvent ErrorMessageChanged()

        End Try

    End Sub

    Protected Sub ShowScreenDoc(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnScreenLink.Click
        Dim url As String = "HelpPage.aspx?user_id=" & hfUserId.Value & "&screen_name=" & hfScreenName.Value & "&field_name="
        Response.Redirect(url)
    End Sub
#End Region

End Class
