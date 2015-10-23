Imports NCUDataLayer
Imports NCUSecurity
Imports System.Data.SqlClient
Imports System.Data
Imports System.Configuration.ConfigurationManager

Partial Class request_forms_fdbk_form
    Inherits System.Web.UI.Page

    Dim dl As New NCUDataLayer()

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim bSpoofedInUser As Boolean = False
        Dim mainNav As UserControls_wucNavBar = Master.NavBar
        mainNav.BuildLibraryMenu()

        'If Request.QueryString("strid") <> "" Then

        'Dim strUserName As String = Request.QueryString("strid")
        'Dim strServName As String = Request.ServerVariables("server_name")

        'DropCookie(strUserName, strServName)

        'End If

        Dim bPublic = False
        If Len(Trim(CurrentLetmeinUserID())) = 0 Then bPublic = True
        If bPublic = True Then

            Dim iDomain As String = Request.ServerVariables("SERVER_NAME")
            ValidationCheck("UnivPeople", iDomain)

        Else

            dl.SqlSelect("SELECT first_name, last_name, degree_program_code, email_address_1 FROM learner_info INNER JOIN learner_programs ON learner_info.learner_id = learner_programs.learner_id where learner_info.learner_id = '" & CurrentLetmeinUserID() & "'")

            Dim dtLearners As DataTable = dl._DT
            Dim drLearners As DataRow = dl._DR

            If dtLearners.Rows.Count = 0 Then


                dl.SqlSelect("SELECT * FROM mentor_info where mentor_id = '" & CurrentLetmeinUserID() & "'")
                Dim dtMentors As DataTable = dl._DT
                Dim drMentors As DataRow = dl._DR

                If dtMentors.Rows.Count = 0 Then

                    dl.SqlSelect("SELECT * FROM staff_info where staff_id = '" & CurrentLetmeinUserID() & "'")
                    Dim dtStaff As DataTable = dl._DT
                    Dim drStaff As DataRow = dl._DR

                    If dtStaff.Rows.Count = 0 Then

                        Response.Write("Invalid User")

                    Else
                        drStaff = dtStaff.Rows(0)

                        Dim sStaff = drStaff("first_name") & " " & drStaff("last_name")
                        patron_name.Text = sStaff & ". Please let us know how we are doing by entering comments into the box below. If you have a reference question or are experiencing difficulties accessing the site or database, please complete the <a href=/ncu_kb/user/user_page.aspx />Ask a Librarian form</a>."
                        Session("sName") = drStaff("first_name") & " " & drStaff("last_name")
                        Session("sEmail") = drStaff("email_address")
                    End If

                Else

                    drMentors = dtMentors.Rows(0)
                    Dim sMentorName = drMentors("first_name") & " " & drMentors("last_name")
                    Session("sName") = drMentors("first_name") & " " & drMentors("last_name")
                    Session("sEmail") = drMentors("email_address_public")
                    patron_name.Text = sMentorName & ". Please let us know how we are doing by entering comments into the box below. If you have a reference question or are experiencing difficulties accessing the site or database, please complete the <a href=/ncu_kb/user/user_page.aspx />Ask a Librarian form</a>."

                End If

            Else
                drLearners = dtLearners.Rows(0)

                Dim sLearners = drLearners("first_name") & " " & drLearners("last_name")
                Session("sName") = drLearners("first_name") & " " & drLearners("last_name")
                Session("sEmail") = drLearners("email_address_1")
                Session("sDegProg") = drLearners("degree_program_code")

                patron_name.Text = sLearners & ". Please let us know how we are doing by entering comments into the box below. If you have a reference question or are experiencing difficulties accessing the site or database, please complete the <a href=/ncu_kb/user/user_page.aspx />Ask a Librarian form</a>."

            End If

        End If
    End Sub

    Protected Sub CommentButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles CommentButton.Click

        Dim iDomain As String = Request.ServerVariables("SERVER_NAME")
        'Dim connectionString As String = "Server=ncusqldvv01;Database=ncuelrc;User Id=admin_ncu;Password=qw12er34"

        Select Case iDomain
            Case "library.ncu.edu"


                Dim connectionString As String = "Server=IOSQLPR001\IOSQLPR001;Database=ncuelrc;User Id=admin_ncu;Password=qw12er34"
                Using sqlcon = New SqlConnection(connectionString)
                    sqlcon.Open()
                    Dim sqlInsert = "INSERT INTO feed_back (u_name, email_address, deg_prog, notes_comments, date_time, user_id) VALUES (@sName, @sEmail, @sDegprog, @Comments,'" + DateAndTime.Now + "','" + CurrentLetmeinUserID() + "')"

                    Dim cmd = New SqlCommand(sqlInsert, sqlcon)
                    cmd.Parameters.AddWithValue("@sName", Session("sName"))
                    cmd.Parameters.AddWithValue("@sEmail", Session("sEmail"))
                    If Session("sDegProg") = "" Then
                        cmd.Parameters.AddWithValue("@sDegProg", "")
                    Else
                        cmd.Parameters.AddWithValue("@sDegProg", Session("sDegProg"))
                    End If

                    cmd.Parameters.AddWithValue("@Comments", comments_box.Value)
                    'cmd.Parameters.AddWithValue("@DateAndTime.Now", subDate)
                    'cmd.Parameters.AddWithValue("@CurrentLetmeinUserId()", id)

                    cmd.ExecuteNonQuery()
                End Using


                Response.Write("Thank you for your comments. We will review them and get back to you as quickly as possible. Click this link to return to the <a href=/ >Northcentral University Library</a>")
                Response.End()

            Case "library02.ncu.edu"


                Dim connectionString As String = "Server=IOSQLPR001\IOSQLPR001;Database=ncuelrc;User Id=admin_ncu;Password=qw12er34"
                Using sqlcon = New SqlConnection(connectionString)
                    sqlcon.Open()
                    Dim sqlInsert = "INSERT INTO feed_back (u_name, email_address, deg_prog, notes_comments, date_time, user_id) VALUES (@sName, @sEmail, @sDegprog, @Comments,'" + DateAndTime.Now + "','" + CurrentLetmeinUserID() + "')"

                    Dim cmd = New SqlCommand(sqlInsert, sqlcon)
                    cmd.Parameters.AddWithValue("@sName", Session("sName"))
                    cmd.Parameters.AddWithValue("@sEmail", Session("sEmail"))
                    If Session("sDegProg") = "" Then
                        cmd.Parameters.AddWithValue("@sDegProg", "")
                    Else
                        cmd.Parameters.AddWithValue("@sDegProg", Session("sDegProg"))
                    End If

                    cmd.Parameters.AddWithValue("@Comments", comments_box.Value)
                    'cmd.Parameters.AddWithValue("@DateAndTime.Now", subDate)
                    'cmd.Parameters.AddWithValue("@CurrentLetmeinUserId()", id)

                    cmd.ExecuteNonQuery()
                End Using


                Response.Write("Thank you for your comments. We will review them and get back to you as quickly as possible. Click this link to return to the <a href=/ >Northcentral University Library</a>")
                Response.End()

            Case "beta-library.ncu.edu"

                Dim connectionString As String = "Server=ncusqlqav01;Database=ncuelrc;User Id=admin_ncu;Password=qw12er34"
                Using sqlcon = New SqlConnection(connectionString)
                    sqlcon.Open()
                    Dim sqlInsert = "INSERT INTO feed_back (u_name, email_address, deg_prog, notes_comments, date_time, user_id) VALUES (@sName, @sEmail, @sDegprog, @Comments,'" + DateAndTime.Now + "','" + CurrentLetmeinUserID() + "')"

                    Dim cmd = New SqlCommand(sqlInsert, sqlcon)
                    cmd.Parameters.AddWithValue("@sName", Session("sName"))
                    cmd.Parameters.AddWithValue("@sEmail", Session("sEmail"))
                    If Session("sDegProg") = "" Then
                        cmd.Parameters.AddWithValue("@sDegProg", "")
                    Else
                        cmd.Parameters.AddWithValue("@sDegProg", Session("sDegProg"))
                    End If

                    cmd.Parameters.AddWithValue("@Comments", comments_box.Value)
                    'cmd.Parameters.AddWithValue("@DateAndTime.Now", subDate)
                    'cmd.Parameters.AddWithValue("@CurrentLetmeinUserId()", id)

                    cmd.ExecuteNonQuery()
                End Using


                Response.Write("Thank you for your comments. We will review them and get back to you as quickly as possible. Click this link to return to the <a href=/ >Northcentral University Library</a>")
                Response.End()

            Case "dev-library.ncu.edu"


                Dim connectionString As String = "Server=ncusqldvv01;Database=ncuelrc;User Id=admin_ncu;Password=qw12er34"
                Using sqlcon = New SqlConnection(connectionString)
                    sqlcon.Open()
                    Dim sqlInsert = "INSERT INTO feed_back (u_name, email_address, deg_prog, notes_comments, date_time, user_id) VALUES (@sName, @sEmail, @sDegprog, @Comments,'" + DateAndTime.Now + "','" + CurrentLetmeinUserID() + "')"

                    Dim cmd = New SqlCommand(sqlInsert, sqlcon)
                    cmd.Parameters.AddWithValue("@sName", Session("sName"))
                    cmd.Parameters.AddWithValue("@sEmail", Session("sEmail"))
                    If Session("sDegProg") = "" Then
                        cmd.Parameters.AddWithValue("@sDegProg", "")
                    Else
                        cmd.Parameters.AddWithValue("@sDegProg", Session("sDegProg"))
                    End If

                    cmd.Parameters.AddWithValue("@Comments", comments_box.Value)
                    'cmd.Parameters.AddWithValue("@DateAndTime.Now", subDate)
                    'cmd.Parameters.AddWithValue("@CurrentLetmeinUserId()", id)

                    cmd.ExecuteNonQuery()
                End Using


                Response.Write("Thank you for your comments. We will review them and get back to you as quickly as possible. Click this link to return to the <a href=/ >Northcentral University Library</a>")
                Response.End()


        End Select


        'Dim dLib As New NCUDataLayer("elrc")
        'Dim dl As New NCUDataLayer("elrc")
        'Dim sFields() As String = {"u_name", "email_address", "deg_prog", "notes_comments", "date_time", "user_id"}
        'Dim sValues() As String = {Session("sName"), Session("sEmail"), Session("sDegProg"), comments_box.Value, DateAndTime.Now, CurrentLetmeinUserID()}

        'dLib.SqlInsert("feed_back", sFields, sValues)

        'Response.Write("Thank you for your comments. We will review them and get back to you as quickly as possible. Click this link to return to the <a href=/ >Northcentral University Library</a>")
        'Response.End()

        'Dim name = Session("sName")
        'Dim email = Session("sEmail")
        'Dim degprog = Session("sDegProg")
        'Dim sComments = comments_box.Value

        ' Using connection As New SqlConnection
        'Dim dl As New NCUDataLayer("elrc")
        'Dim _t = "Server=ncusqldvv01;Initial Catalog=ncuelrc;Persist Security Info=True;User ID=admin_ncu;Password=qw12er34;Connection Timeout=20;Min Pool Size=0;Max Pool Size=" & _ConnectionPool & ";"

        'Dim theSQL = "INSERT into feed_back(u_name, email_address, deg_prog, notes_comments, date_time, user_id) values(@Session(sName), @Session(sEmail), @Session(sDegprog), @sComments, DateAndTime.Now, CurrentLetmeinUserID())"

        'Using conn As New SqlConnection("server=ncusqldvv01;database=ncuelrc;Persist Security Info=True;uid=admin_ncu;Password=qw12er34;")

        '    Using comm As New SqlCommand()
        '        With comm
        '            .Connection = conn
        '            .CommandType = CommandType.Text
        '            .CommandText = theSQL
        '            .Parameters.AddWithValue("@Session(sName)", Session("sName"))
        '            .Parameters.AddWithValue("@Session(sEmail)", Session("sEmail"))
        '            .Parameters.AddWithValue("@Session(sDegProg)", Session("sDegProg"))
        '            .Parameters.AddWithValue("@Session(sComments)", Session("sComments"))
        '            .Parameters.AddWithValue("DateAndTime.Now", DateAndTime.Now)
        '            .Parameters.AddWithValue("CurrentLetmeinUserId", CurrentLetmeinUserID())
        '        End With

        '        'Try
        '        conn.Open()
        '        comm.ExecuteNonQuery()
        '        'Catch ex As SqlException


        '        'End Try



        '    End Using

        'End Using

        'Using insertcommand As New SqlCommand(theSQL, connection)
        'connection.Open()




        'End Using

        'dl.SqlExecute(theSQL)

        'Response.Write(dl.Results & " ,  " & dl.Severity & " , " & dl.SqlStatement)

        'Response.Write("Thank you for your comments. We will review them and get back to you as quickly as possible. Click this link to return to the <a href=/ >Northcentral University Library</a>")
        'Response.End()
        'End Using

    End Sub
End Class
