#Region "History"
' Creation - JCA - 23 February 2010
#End Region
Partial Class UserControls_wucNavBar
    Inherits System.Web.UI.UserControl
#Region "Class Storage"
    Dim _errorMessage As String = String.Empty
    Dim _errorDetails As String = String.Empty
    Dim _sql As String = String.Empty
    Dim _dl As New NCUDataLayer
    Dim _ncuDataPersist As New NCUDataPersist
    Dim _dlLib As New NCUDataLayer("elrc")
#End Region
#Region "Public Properties Events and Methods"
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

    Public ReadOnly Property LinkText() As String
        Get
            Return hfLinkText.Value
        End Get
    End Property

    Public Event ErrorMessageChanged()
    ''' <summary>
    ''' Allow a user to programmatically add drop down list items to the control.
    ''' </summary>
    ''' <param name="itemName">The text that shows up as the link</param>
    ''' <param name="itemLink">The target page for the link</param>
    ''' <param name="parentLink">An integer value (0-5) which determines which menu item to place the drop down under</param>
    ''' <remarks></remarks>
    Public Sub AddDropDownItem(ByVal itemName As String, ByVal itemLink As String, ByVal parentLink As Integer, Optional ByVal uniqueKey As String = "")
        If parentLink > 5 Or parentLink < 0 Then
            _errorMessage = "The value of parent link must be 0-5"
            RaiseEvent ErrorMessageChanged()
            Exit Sub
        End If

        If Not itemLink.Contains("http://") Then
            Dim literalThis As New Literal
            literalThis.ID = "ltlThis" & itemName & parentLink & uniqueKey
            literalThis.Text = "<li>"
            Dim literalThat As New Literal
            literalThat.ID = "ltlThat" & itemName & parentLink & uniqueKey
            literalThat.Text = "</li>"
            Dim link As New LinkButton : link.ID = "ddlink_" & itemLink & "_" & itemName & "_" & uniqueKey : link.Text = itemName
            AddHandler link.Click, AddressOf ProcessLink
            Dim phThis As New PlaceHolder
            Try
                phThis = Me.FindControl("phSecLink" & parentLink)
                phThis.Controls.Add(literalThis)
                phThis.Controls.Add(link)
                phThis.Controls.Add(literalThat)
            Catch ex As Exception
                _errorMessage = "There was an error adding the item to the drop down list."
                _errorDetails = ex.Message & ":" & ex.StackTrace
                RaiseEvent ErrorMessageChanged()
            End Try
        Else
            Dim literalThis As New Literal
            literalThis.ID = "ltlThis" & itemName & parentLink & uniqueKey
            literalThis.Text = "<li><a href = " & itemLink & ">" & itemName & "</a></li>"

            Dim phThis As New PlaceHolder
            Try
                phThis = Me.FindControl("phSecLink" & parentLink)
                phThis.Controls.Add(literalThis)
            Catch ex As Exception
                _errorMessage = "There was an error adding the item to the drop down list."
                _errorDetails = ex.Message & ":" & ex.StackTrace
                RaiseEvent ErrorMessageChanged()
            End Try
        End If

        Select Case parentLink
            Case 0
                ulLink0.Visible = True
            Case 1
                ulLink1.Visible = True
            Case 2
                ulLink2.Visible = True
            Case 3
                ulLink3.Visible = True
            Case 4
                ulLink4.Visible = True
            Case 5
                ulLink5.Visible = True
        End Select

    End Sub
    ''' <summary>
    ''' This sub is for adding third level links for the my favorites page listing.
    ''' </summary>
    ''' <param name="linkName"></param>
    ''' <param name="linkRef"></param>
    ''' <remarks></remarks>
    Public Sub AddFaves(ByVal linkName As String, ByVal linkRef As String)
        ulLink00.Visible = True

        Dim literalThis As New Literal
        literalThis.ID = "ltlThis" & linkName
        literalThis.Text = "<li>"
        Dim literalThat As New Literal
        literalThat.ID = "ltlThat" & linkName
        literalThat.Text = "</li>"
        Dim link As New LinkButton : link.ID = "favelink_" & linkRef & "_" & linkName : link.Text = linkName
        AddHandler link.Click, AddressOf ProcessLink

        phThrdLink0.Controls.Add(literalThis)
        phThrdLink0.Controls.Add(link)
        phThrdLink0.Controls.Add(literalThat)

    End Sub
    ''' <summary>
    ''' This sub allows the programmer to change the links in the main bar.
    ''' </summary>
    ''' <param name="linkName">The text for the given link</param>
    ''' <param name="linkRef">The destination for the given link</param>
    ''' <param name="linkNum">An integer value for which link you'd like to change (1-5 only)</param>
    ''' <remarks></remarks>
    Public Sub CreateLinks(ByVal linkName As String, ByVal linkRef As String, ByVal linkNum As Integer, Optional ByVal isEnabled As Boolean = True)
        If linkNum < 0 Or linkNum > 5 Then
            _errorMessage = "The linkNum must be 1-5!"
            RaiseEvent ErrorMessageChanged()
        End If

        linkRef = "" & linkRef & ""

        Try
            Dim phThis As PlaceHolder = Me.FindControl("phLink" & linkNum)
            Dim link As New LinkButton : link.ID = "link_" & linkRef & "_" & linkName : link.Text = linkName
            If isEnabled Then
                AddHandler link.Click, AddressOf ProcessLink
            End If
            phThis.Controls.Clear()
            phThis.Controls.Add(link)
        Catch ex As Exception
            _errorMessage = "There was an error changing the main links."
            _errorDetails = ex.Message & ":" & ex.StackTrace
            RaiseEvent ErrorMessageChanged()
        End Try
    End Sub
    ''' <summary>
    ''' Allow the user to clear out the entire navbar, except the main 
    ''' </summary>
    Public Sub ClearAll()
        Dim lit1 As New Literal : lit1.Text = "<a>&nbsp;</a>" : phLink1.Controls.Clear() : phLink1.Controls.Add(lit1)
        Dim lit2 As New Literal : lit2.Text = "<a>&nbsp;</a>" : phLink2.Controls.Clear() : phLink2.Controls.Add(lit2)
        Dim lit3 As New Literal : lit3.Text = "<a>&nbsp;</a>" : phLink3.Controls.Clear() : phLink3.Controls.Add(lit3)
        Dim lit4 As New Literal : lit4.Text = "<a>&nbsp;</a>" : phLink4.Controls.Clear() : phLink4.Controls.Add(lit4)
        Dim lit5 As New Literal : lit5.Text = "<a>&nbsp;</a>" : phLink5.Controls.Clear() : phLink5.Controls.Add(lit5)
        ulLink1.Visible = False
        ulLink2.Visible = False
        ulLink3.Visible = False
        ulLink4.Visible = False
        ulLink5.Visible = False
        phSecLink1.Controls.Clear()
        phSecLink2.Controls.Clear()
        phSecLink3.Controls.Clear()
        phSecLink4.Controls.Clear()
        phSecLink5.Controls.Clear()
    End Sub
    ''' <summary>
    ''' Allow the user to clear out the main navbar (this is the drop down under the home icon)
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub ClearMain()
        ulLink0.Visible = False
        ulLink00.Visible = False
        phSecLink0.Visible = False
        phThrdLink0.Controls.Clear()
    End Sub
    ''' <summary>
    ''' Allow the user to clear out only one item and its subitems from the navbar
    ''' </summary>
    Public Sub ClearOneMenu(ByVal menuIndex As Integer)
        If menuIndex < 0 Or menuIndex > 5 Then
            _errorMessage = "You must pass an index between 0 and 5."
            RaiseEvent ErrorMessageChanged()
            Exit Sub
        End If

        Dim lblThis As Label = FindControl("lblLink" & menuIndex)
        lblThis.Text = "<a></a>"
        Dim phThis As PlaceHolder = FindControl("phSecLink" & menuIndex)
        phThis.Controls.Clear()

        Select Case menuIndex
            Case 0
                ulLink0.Visible = False
                ulLink00.Visible = False
            Case 1
                ulLink1.Visible = False
            Case 2
                ulLink2.Visible = False
            Case 3
                ulLink3.Visible = False
            Case 4
                ulLink4.Visible = False
            Case 5
                ulLink5.Visible = False
        End Select
    End Sub

    Public Sub BuildMentorMenu()
        ClearAll()

        CreateLinks("Mentors", "/Mentors/Default.aspx", 1)
        AddDropDownItem("University Tasks", "/Mentors/Tasks/Default.aspx", 1)
        AddDropDownItem("People", "/Mentors/People/Default.aspx", 1)
        AddDropDownItem("Communication", "/Mentors/Communication/Default.aspx", 1)
        AddDropDownItem("Faculty Development", "/Mentors/Development/Default.aspx", 1)
        AddDropDownItem("References", "/Mentors/References/Default.aspx", 1)
        AddDropDownItem("Library", "/Mentors/Library/Default.aspx", 1)
        AddDropDownItem("Writing Support Services", "/Mentors/Writing/Default.aspx", 1)

        CreateLinks("My Learners", "/Mentors/Learners/Default.aspx", 2)
        AddDropDownItem("Dissertations", "/Mentors/Learners/Dissertations.aspx", 2)
        AddDropDownItem("Course Forums", "/Mentors/Learners/CourseForums.aspx", 2)
        AddDropDownItem("Short Form", "/Mentors/Learners/ShortForm.aspx", 2)

    End Sub

    Public Sub BuildLearnerMenu()
        ClearAll()

        CreateLinks("Learners", "/Learners/Default.aspx", 1)

        ' If the learner has fewer than 2 courses we want to display the new learners link to them for access to the tours and such.
        _sql = "SELECT Count(*) AS num FROM learner_courses WHERE learner_id = '" & NCUSecurity.CurrentLetmeinUserID & "'"
        Try
            If _dl.SqlSelect(_sql) Then
                If CType(_dl._DR("num"), Integer) < 2 Then
                    AddDropDownItem("For New Learners", "/Learners/NewLearners.aspx", 1)
                End If
            ElseIf _dl.Severity > 0 Then
                AddDropDownItem("For New Learners", "/Learners/NewLearners.aspx", 1)
            End If
        Catch ex As Exception
            _errorMessage = "There was an error getting course info."
            _errorDetails = ex.Message & ":" & ex.StackTrace
            RaiseEvent ErrorMessageChanged()
        End Try

        AddDropDownItem("My Information", "~/Learners/LearnerInformation/Profile.aspx", 1)
        Dim libLink As String = MakeBaseUrl("library")
        AddDropDownItem("Library", libLink, 1)
        AddDropDownItem("Writing Support Services", "~/Learners/Writing.aspx", 1)
        AddDropDownItem("Resources", "~/Learners/Resources/Default.aspx", 1)
        AddDropDownItem("People", "~/Learners/People/Default.aspx", 1)

        Dim ePortLink As String = "http://eportfolio.ncu.edu"
        AddDropDownItem("ePortfolio", ePortLink, 1)

        CreateLinks("Learner Programs", "~/Learners/LearnerPrograms/Default.aspx", 2)
        AddDropDownItem("Course Request", "~/Learners/LearnerPrograms/CourseRequest.aspx", 2)
        AddDropDownItem("Leave of Absence", "~/Learners/LearnerPrograms/Loa.aspx", 2)
        AddDropDownItem("Other Forms", "~/Learners/LearnerPrograms/Forms.aspx", 2)

        _sql = "SELECT * FROM learner_courses WHERE learner_id = '" & NCUSecurity.CurrentLetmeinUserID & "' AND completed_date IS NULL"

        If _dl.SqlSelect(_sql) Then
            For Each dr As DataRow In _dl._DT.Rows
                AddDropDownItem(dr("course_code"), "/Learners/CourseRoom/Default.aspx", 2, dr("learner_course_id"))
            Next
        End If

        CreateLinks("Financial", "~/Learners/Financial/Default.aspx", 3)
        AddDropDownItem("Statement", "~/Learners/Financial/Statement.aspx", 3)
        AddDropDownItem("Update Payment", "~/Learners/Financial/UpdatePayment.aspx", 3)
        AddDropDownItem("Technology Fee", "~/Learners/Financial/TechFee.aspx", 3)
    End Sub
    Public Sub BuildLibraryMenu()
        ClearAll()

        CreateLinksLib("RESEARCH RESOURCES", "/mm_template.aspx?parent_id=1", 1)

        AddDropDownItemLib("Databases", "/dw_template.aspx?parent_id=8", 1)
        AddDropDownItemLib("Find an Article", "/mm_template.aspx?parent_id=182", 1)
        AddDropDownItemLib("Find an E-Book", "/dw_template.aspx?parent_id=95", 1)
        AddDropDownItemLib1("Find a Resource", "http://xt6nc6eu9q.search.serialssolutions.com/", 1)
        AddDropDownItemLib("Dissertation Resources", "/dw_template.aspx?parent_id=96", 1)
        AddDropDownItemLib("Open Access Resources", "/mm_template.aspx?parent_id=11", 1)

        CreateLinksLib("RESEARCH HELP", "/mm_template.aspx?parent_id=9", 2)

        AddDropDownItemLib("Learn the Library!", "/dw_template.aspx?parent_id=170", 2)
        AddDropDownItemLib("Need Help With a Course?", "/research_help/default.aspx", 2)
        AddDropDownItemLib("Research Process", "/dw_template.aspx?parent_id=179", 2)
        AddDropDownItemLib("Information Literacy Tutorial", "http://library2.ncu.edu/Home/ILTutorial", 2)
        AddDropDownItemLib("Scholarly Publication", "/dw_template.aspx?parent_id=220", 2)
        AddDropDownItemLib("Library FAQs", "/ncu_kb/default.aspx", 2)

        CreateLinksLib("SERVICES", "/mm_template.aspx?parent_id=14", 3)

        AddDropDownItemLib("Ask a Librarian", "/ncu_kb/user/user_page.aspx", 3)
        AddDropDownItemLib("Research Consultations", "/ncu_kb/user/research_consult.aspx", 3)
        AddDropDownItemLib("Articles (Interlibrary Loan)", "http://illiad.ncu.edu/illiad/logon.html", 3)
        AddDropDownItemLib("Library Workshops", "/schedule/default.aspx", 3)
        AddDropDownItemLib("Library Disability Services", "/dw_template.aspx?parent_id=315", 3)
        'AddDropDownItemLib("Dissertation Center", "http://learners.ncu.edu/ncu_diss/default.aspx", 3)


        CreateLinksLib("ABOUT US", "/dw_template.aspx?parent_id=20", 4)

        AddDropDownItemLib("Library Mission Statement", "/dw_template.aspx?parent_id=219", 4)
        AddDropDownItemLib("Library News Blog", "/blog/?blog_arena_id=2", 4)
        AddDropDownItemLib("Contact Us", "/dw_template.aspx?parent_id=22", 4)
        AddDropDownItemLib("Library Alternatives", "/mm_template.aspx?parent_id=23", 4)
        AddDropDownItemLib("Library Policies", "http://learners.ncu.edu/public_images/elrc/Library%20Policies/index.htm", 4)

        CreateLinksLib("POPULAR DATABASES", "", 5)

        AddDropDownItemLib1("Ebrary", "http://site.ebrary.com/lib/ncent", 5)
        AddDropDownItemLib1("EBSCOHost", "http://search.ebscohost.com.proxy1.ncu.edu/login.aspx?authtype=ip,uid&profile=ehost", 5)
        AddDropDownItemLib1("Gale Academic OneFile", "http://infotrac.galegroup.com.proxy1.ncu.edu/itweb/pres1571?db=AONE", 5)
        AddDropDownItemLib1("ProQuest", "http://search.proquest.com.proxy1.ncu.edu/advanced", 5)
        AddDropDownItemLib1("RefWorks", "http://www.refworks.com.proxy1.ncu.edu/refworks", 5)
        AddDropDownItemLib1("SAGE", "http://online.sagepub.com.proxy1.ncu.edu/cgi/search", 5)
        AddDropDownItemLib1("ScienceDirect", "http://www.sciencedirect.com.proxy1.ncu.edu/science?_ob=MiamiSearchURL&_method=requestForm&_btn=Y&_acct=C000072328&_version=1&_urlVersion=1&_userid=7629509&md5=0ce9f93201a3b67add75e96bcadfee83", 5)
        AddDropDownItemLib1("SpringerLink", "http://link.springer.com.proxy1.ncu.edu/advanced-search", 5)
        AddDropDownItemLib1("Ulrichsweb", "http://www.ulrichsweb.serialssolutions.com.proxy1.ncu.edu/", 5)
        AddDropDownItemLib1("Web of Knowledge", "http://apps.webofknowledge.com.proxy1.ncu.edu/", 5)
    End Sub

    Public Sub CreateLinksLib(ByVal linkName As String, ByVal linkRef As String, ByVal linkNum As Integer, Optional ByVal isEnabled As Boolean = True)

        If linkNum < 0 Or linkNum > 5 Then
            _errorMessage = "The linkNum must be 1-5!"
            RaiseEvent ErrorMessageChanged()
        End If

        linkRef = "" & linkRef & ""

        Try
            Dim phThis As PlaceHolder = Me.FindControl("phLink" & linkNum)

            Dim literalThis As New Literal
            literalThis.ID = "ltlThis" & linkName
            literalThis.Text = "<a href = " & linkRef & ">" & linkName & "</a>"

            'Dim link As New LinkButton : link.ID = "link_" & linkRef & "_" & linkName : link.Text = linkName

            'If isEnabled Then
            'AddHandler link.Click, AddressOf ProcessLink
            'End If
            phThis.Controls.Clear()
            phThis.Controls.Add(literalThis)
        Catch ex As Exception
            _errorMessage = "There was an error changing the main links."
            _errorDetails = ex.Message & ":" & ex.StackTrace
            RaiseEvent ErrorMessageChanged()
        End Try
    End Sub

    Public Sub AddDropDownItemLib(ByVal itemName As String, ByVal itemLink As String, ByVal parentLink As Integer, Optional ByVal uniqueKey As String = "")
        If parentLink > 5 Or parentLink < 0 Then
            _errorMessage = "The value of parent link must be 0-5"
            RaiseEvent ErrorMessageChanged()
            Exit Sub
        End If

        Dim literalThis As New Literal
        literalThis.ID = "ltlThis" & itemName & parentLink & uniqueKey
        literalThis.Text = "<li><a href = " & itemLink & ">" & itemName & "</a></li>"

        Dim phThis As New PlaceHolder
        Try
            phThis = Me.FindControl("phSecLink" & parentLink)
            phThis.Controls.Add(literalThis)
        Catch ex As Exception
            _errorMessage = "There was an error adding the item to the drop down list."
            _errorDetails = ex.Message & ":" & ex.StackTrace
            RaiseEvent ErrorMessageChanged()
        End Try


        Select Case parentLink
            Case 0
                ulLink0.Visible = True
            Case 1
                ulLink1.Visible = True
            Case 2
                ulLink2.Visible = True
            Case 3
                ulLink3.Visible = True
            Case 4
                ulLink4.Visible = True
            Case 5
                ulLink5.Visible = True
        End Select

    End Sub

    Public Sub AddDropDownItemLib1(ByVal itemName As String, ByVal itemLink As String, ByVal parentLink As Integer, Optional ByVal uniqueKey As String = "")
        If parentLink > 5 Or parentLink < 0 Then
            _errorMessage = "The value of parent link must be 0-5"
            RaiseEvent ErrorMessageChanged()
            Exit Sub
        End If

        Dim literalThis As New Literal
        literalThis.ID = "ltlThis" & itemName & parentLink & uniqueKey
        literalThis.Text = "<li><a target=_blank href = " & itemLink & ">" & itemName & "</a></li>"

        Dim phThis As New PlaceHolder
        Try
            phThis = Me.FindControl("phSecLink" & parentLink)
            phThis.Controls.Add(literalThis)
        Catch ex As Exception
            _errorMessage = "There was an error adding the item to the drop down list."
            _errorDetails = ex.Message & ":" & ex.StackTrace
            RaiseEvent ErrorMessageChanged()
        End Try


        Select Case parentLink
            Case 0
                ulLink0.Visible = True
            Case 1
                ulLink1.Visible = True
            Case 2
                ulLink2.Visible = True
            Case 3
                ulLink3.Visible = True
            Case 4
                ulLink4.Visible = True
            Case 5
                ulLink5.Visible = True
        End Select

    End Sub


    Public Sub BuildCourseRoomMenu(ByVal courseCode As String)
        CreateLinks("Course Room - " & courseCode, "./Default.aspx", 5, False)
        AddDropDownItem("Overview", "./Overview.aspx", 5)
        AddDropDownItem("Essentials", "./Essentials.aspx", 5)
        AddDropDownItem("Mentor", "./Mentor.aspx", 5)
        AddDropDownItem("Activities", "./Activities.aspx", 5)
        AddDropDownItem("Discussion Forum", "./Forum.aspx", 5)
        AddDropDownItem("Learners", "./Learners.aspx", 5)
        AddDropDownItem("Books/Resources", "./Resources.aspx", 5)
        AddDropDownItem("Surveys", "./Surveys.aspx", 5)
        AddDropDownItem("Comments", "./Comments.aspx", 5)
    End Sub

    Public Sub BuildMentorCourseRoomMenu(ByVal courseCode As String)
        CreateLinks("Course Room - " & courseCode, "./Default.aspx", 5, False)
        AddDropDownItem("Learners", "./Learners.aspx", 5)
        AddDropDownItem("Syllabus", "./Syllabus.aspx", 5)
        AddDropDownItem("Chat", "./Chat.aspx", 5)
        AddDropDownItem("Course Discussion Forum", "./Forum.aspx", 5)
        AddDropDownItem("Outline", "./Outline.aspx", 5)
        AddDropDownItem("Coursework", "./Coursework.aspx", 5)
        AddDropDownItem("Resources", "./Resources.aspx", 5)
        AddDropDownItem("Comments", "./Comments.aspx", 5)
    End Sub

    Public Sub BuildTestingMenu()
        'CreateLinks("Test Pages", "/Default.aspx", 4)
        'AddDropDownItem("wucAddress", "/TestPages/AddressTest.aspx", 4)
        'AddDropDownItem("wucAssignedStaff", "/TestPages/AssignedStaffTest.aspx", 4)
        'AddDropDownItem("wucCalendar", "/TestPages/CalendarTest2.aspx", 4)
        'AddDropDownItem("wucFileUpload", "/TestPages/FileUploadTest.aspx", 4)
        'AddDropDownItem("wucHTMLSpell", "/TestPages/HTMLEditTest.aspx", 4)
        'AddDropDownItem("wucActiveCourses", "/TestPages/ActiveCourses.aspx", 4)
        'AddDropDownItem("wucAlerts", "/TestPages/AlertTest.aspx", 4)
        'AddDropDownItem("wucAnnouncements", "/TestPages/AnnouncementTest.aspx", 4)
        'AddDropDownItem("wucCourseRequest", "/TestPages/courseRequestTest.aspx", 4)
        'AddDropDownItem("wucHomeworkUpload", "/TestPages/HomeworkUploadtest", 4)
        'AddDropDownItem("wucGradCalc", "/TestPages/GradDateTest.aspx", 4)
        'AddDropDownItem("wucSurvey", "/TestPages/SurveyTest.aspx", 4)
    End Sub

    Public Sub BuildLearnerInfoMenu()
        CreateLinks("Learner Information", "~/Learners/LearnerInformation/Profile.aspx", 5)
        AddDropDownItem("Profile", "~/Learners/LearnerInformation/Profile.aspx", 5)
        'AddDropDownItem("Course Request", "~/Learners/CourseRequest.aspx", 5)
        AddDropDownItem("Degree Program", "~/Learners/LearnerInformation/DegreePlan.aspx", 5)
        AddDropDownItem("ePortfolio", "~/Learners/LearnerInformation/ePortfolio.aspx", 5)
        AddDropDownItem("Transcripts", "~/Learners/LearnerInformation/Transcripts.aspx", 5)
    End Sub
    Public Sub BuildAdminMenu()
        ClearAll()

        CreateLinks("Admin", "~/Admin/Default.aspx", 1)

        AddDropDownItem("Applicants", "~/Applicant/ApplicantSearch.aspx", 1)
        AddDropDownItem("Learners", "~/Learners/LearnerSearch.aspx", 1)
        AddDropDownItem("Mentors", "~/Mentors/MentorSearch.aspx", 1)
        AddDropDownItem("Staff", "~/Staff/StaffSearch.aspx", 1)
        AddDropDownItem("Security", "~/Security/SecurityCenter.aspx", 1)
    End Sub
    Public Sub Hide(ByVal opt As Boolean)
        mainNavHide.Visible = Not opt
    End Sub
#End Region
#Region "Private Methods"
    Private Function MakeBaseUrl(ByVal portal As String) As String
        Dim sServerNum As String = "00"
        Dim sServer As String = Server.MachineName
        sServerNum = Right(sServer, 2)
        Dim thisServer As String = Request.ServerVariables("server_name")

        Dim baseUrl As String = String.Empty
        If thisServer.Contains("beta") Then
            baseUrl = Trim("http://beta-" & portal & ".ncu.edu/")
        ElseIf thisServer.Contains("-") Then
            Dim serverName As String
            If portal = "library" Then
                baseUrl = "http://ed-library.ncu.edu"
            Else
                serverName = Left(thisServer, thisServer.IndexOf("-")) & "-" & portal
                serverName += Right(thisServer, thisServer.Length - thisServer.IndexOf("."))
                baseUrl = Trim("http://" & serverName & "/")
            End If
        Else
            baseUrl = Trim("http://" & portal & sServerNum & ".ncu.edu/")
        End If
        Return baseUrl
    End Function
#End Region
#Region "Protected Page Events"
    Protected Sub ProcessLink(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim lbtn As LinkButton = CType(sender, LinkButton)
        Dim lbtnID As String = lbtn.ID
        Dim link As String = lbtnID.Substring(lbtnID.IndexOf("_") + 1)
        Dim name As String = link.Substring(link.IndexOf("_") + 1)
        link = link.Substring(0, link.IndexOf("_"))
        Dim uniqueKey As String = name.Substring(name.IndexOf("_") + 1)
        If name.IndexOf("_") > 0 Then
            name = name.Substring(0, name.IndexOf("_"))
        End If

        If String.IsNullOrEmpty(uniqueKey) Then
            _ncuDataPersist.Store("linkName", name)
        Else
            _ncuDataPersist.Store("uniqueKey", uniqueKey)
        End If

        Response.Redirect(link)
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        BuildTestingMenu()
    End Sub
#End Region
End Class
