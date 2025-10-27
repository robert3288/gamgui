Imports System.CodeDom
Imports System.ComponentModel
Imports System.IO
Imports System.Net.Mail
Imports System.Security
Imports System.Security.Cryptography
Imports System.Windows.Forms.VisualStyles.VisualStyleElement
Imports System.Windows.Forms.VisualStyles.VisualStyleElement.ToolBar
Imports Microsoft.VisualBasic.ApplicationServices

Public Class Form1

    Private OrgUnitPaths As New List(Of String)
    Private groupList As New List(Of String)

    Private Async Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Make sure the form sees key presses before controls
        Me.KeyPreview = True

        ' Default selections
        ComboBoxDevicesScope.SelectedItem = "Single"
        ComboBoxDevicesAction.SelectedItem = "Get Info"
        ComboBoxDevicesTargetType.SelectedItem = "Asset ID"
        ComboBoxUsersScope.SelectedItem = "User"
        ComboBoxUsersAction.SelectedItem = "Get Info"
        ComboBoxFilesAction.SelectedItem = "Get Info"
        ComboBoxDataTransferScope.SelectedItem = "All"
        ComboBoxDataTransferSourceUserRetainRole.SelectedItem = "None"
        ComboBoxDataTransferSourceUserRetainRoleShared.SelectedItem = "Current"
        ComboBoxDataTransferDestinationUserGainRoleShared.SelectedItem = "Source"
        ComboBoxCoursesScope.SelectedItem = "Single"
        ComboBoxCoursesAction.SelectedItem = "Get Info"
        ComboBoxFind.SelectedItem = "OU"
        ComboBoxUserReportFiltersSuspended.SelectedItem = "True"
        ComboBoxUserReportFiltersArchived.SelectedItem = "True"
        ComboBoxUserReportFiltersStorage.SelectedItem = "="
        ComboBoxUserReportFiltersLastLogin.SelectedItem = ">"
        ComboBoxUserReportFiltersCreated.SelectedItem = ">"

        ' Force all tabs to initialize
        For Each tab As TabPage In TabControl1.TabPages
            tab.Show()     ' Force layout
            tab.Hide()     ' Hide again
        Next
        TabControl1.SelectedIndex = 0 ' Go back to your default tab

        ' Load data asynchronously (don’t block UI)
        Await LoadGoogleDataAsync()
    End Sub

    Private Async Function LoadGoogleDataAsync() As Task
        ' Run both tasks in parallel
        Dim ouTask = Task.Run(Function() LoadOUs())
        Dim groupsTask = Task.Run(Function() LoadGroups())

        Await Task.WhenAll(ouTask, groupsTask)

        ' Update UI on the main thread
        Me.Invoke(Sub()
                      Try
                          ComboBoxDevicesDestination.DataSource = ouTask.Result
                          ComboBoxUsersDestination.DataSource = ouTask.Result
                          ComboBoxUsersTarget.DataSource = ouTask.Result
                          ComboBoxUsersTarget.BindingContext = New BindingContext()

                          ComboBoxUsersGroupDestination.DataSource = groupsTask.Result
                      Catch ex As Exception
                          RichTextBox1.Text = "Error binding data: " & ex.Message
                      End Try
                  End Sub)
    End Function

    Private Function LoadOUs() As List(Of String)
        OrgUnitPaths.Clear()
        Try
            Dim psi As New ProcessStartInfo() With {
            .FileName = "cmd.exe",
            .Arguments = "/c gam print orgs fields orgUnitPath",
            .RedirectStandardOutput = True,
            .UseShellExecute = False,
            .CreateNoWindow = True
        }

            Using proc As Process = Process.Start(psi)
                Using reader As IO.StreamReader = proc.StandardOutput
                    While Not reader.EndOfStream
                        Dim line As String = reader.ReadLine().Trim()
                        If line <> "orgUnitPath" AndAlso line <> "" Then
                            OrgUnitPaths.Add(line)
                        End If
                    End While
                End Using
            End Using
        Catch ex As Exception
            ' You could log this if needed
        End Try

        Return OrgUnitPaths
    End Function

    Private Function LoadGroups() As List(Of String)
        groupList.Clear()
        Try
            Dim psi As New ProcessStartInfo() With {
            .FileName = "cmd.exe",
            .Arguments = "/c gam print groups",
            .RedirectStandardOutput = True,
            .UseShellExecute = False,
            .CreateNoWindow = True
        }

            Using proc As Process = Process.Start(psi)
                Using reader As IO.StreamReader = proc.StandardOutput
                    While Not reader.EndOfStream
                        Dim line As String = reader.ReadLine().Trim()
                        If line <> "email" AndAlso line <> "" Then
                            groupList.Add(line)
                        End If
                    End While
                End Using
            End Using
        Catch ex As Exception
            ' You could log this if needed
        End Try

        Return groupList
    End Function

    Private Sub Form1_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        ' Make sure a control inside TabControl1 has focus
        If TabControl1.ContainsFocus Then
            ' Only trigger if the focused control is a TextBox
            Dim focusedCtrl As Control = Me.ActiveControl
            If TypeOf focusedCtrl Is System.Windows.Forms.TextBox Then
                If e.KeyCode = Keys.Enter Then
                    e.SuppressKeyPress = True
                    If e.Shift Then
                        ButtonRun.PerformClick()
                    Else
                        ButtonShowCommand.PerformClick()
                    End If
                End If
            End If
        End If
    End Sub


    ' Store original states here
    Private originalStates As New Dictionary(Of Control, Boolean)

    Private Sub SnapshotAndDisable(parent As Control)
        For Each ctrl As Control In parent.Controls
            ' Save original state
            If Not originalStates.ContainsKey(ctrl) Then
                originalStates(ctrl) = ctrl.Enabled
            End If

            ' Skip RichTextBox1 and ButtonCopy
            If ctrl IsNot RichTextBox1 AndAlso ctrl IsNot ButtonCopy Then
                ' Only disable if it's not a container
                If Not TypeOf ctrl Is TabPage AndAlso
               Not TypeOf ctrl Is Panel AndAlso
               Not TypeOf ctrl Is GroupBox AndAlso
               Not TypeOf ctrl Is TabControl Then
                    ctrl.Enabled = False
                End If
            End If

            ' Recurse into child containers
            If ctrl.HasChildren Then
                SnapshotAndDisable(ctrl)
            End If
        Next
    End Sub

    Private Sub RestoreStates()
        For Each kvp In originalStates
            kvp.Key.Enabled = kvp.Value
        Next
        originalStates.Clear()
    End Sub



    Private Sub ComboBoxDeviceScope_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBoxDevicesScope.SelectedIndexChanged
        Dim scope = ComboBoxDevicesScope.SelectedItem?.ToString()

        ' Always remove Get Info first
        If ComboBoxDevicesAction.Items.Contains("Get Info") AndAlso Not scope = "Single" Then
            ComboBoxDevicesAction.Items.Remove("Get Info")
        End If

        If scope = "Multiple" Then
            ' Action combo box
            If ComboBoxDevicesAction.SelectedItem Is Nothing OrElse ComboBoxDevicesAction.SelectedItem.ToString() = "Get Info" Then
                ComboBoxDevicesAction.SelectedItem = "Move"
            End If

            ' Target type combo box
            ComboBoxDevicesTargetType.Items.Add("CSV")
            ComboBoxDevicesTargetType.SelectedItem = "CSV"
            ComboBoxDevicesTargetType.Items.Remove("Asset ID")
            ComboBoxDevicesTargetType.Items.Remove("Serial Number")
            ComboBoxDevicesTargetType.Items.Remove("MAC Address")
            ComboBoxDevicesTargetType.Enabled = False

            ' Target text box
            If IO.File.Exists("C:\GAMWork\assetIDs.csv") Then
                TextBoxDevicesTarget.Text = "C:\GAMWork\assetIDs.csv"
            Else
                TextBoxDevicesTarget.Text = ""
            End If
            ButtonDevicesTargetSearch.Visible = True
            ButtonDevicesTargetEdit.Visible = True
            TextBoxDevicesTarget.Size = New Size(305, 23)

            ' Clear previous text
            RichTextBox1.Clear()
            ' Append normal text
            RichTextBox1.AppendText("The CSV file must use ")
            ' Append bold text
            Dim start As Integer = RichTextBox1.TextLength
            RichTextBox1.AppendText("assetid")
            RichTextBox1.Select(start, "assetid".Length)
            RichTextBox1.SelectionFont = New Font(RichTextBox1.Font, FontStyle.Bold)
            ' Reset font to normal and append the rest
            RichTextBox1.SelectionStart = RichTextBox1.TextLength
            RichTextBox1.SelectionLength = 0
            RichTextBox1.SelectionFont = New Font(RichTextBox1.Font, FontStyle.Regular)
            RichTextBox1.AppendText(" for the header and only contain asset IDs (not serial numbers) ")

        ElseIf scope = "Single" Then
            ' Action combo box
            If Not ComboBoxDevicesAction.Items.Contains("Get Info") Then
                ComboBoxDevicesAction.Items.Insert(0, "Get Info")
                'ComboBoxDeviceAction.SelectedItem = "Get Info"
            End If

            ' Target type combo box
            ComboBoxDevicesTargetType.Enabled = True
            ComboBoxDevicesTargetType.Items.Remove("CSV")

            If Not ComboBoxDevicesTargetType.Items.Contains("Asset ID") Then
                ComboBoxDevicesTargetType.Items.Insert(0, "Asset ID")
            End If

            If Not ComboBoxDevicesTargetType.Items.Contains("Serial Number") Then
                ComboBoxDevicesTargetType.Items.Insert(1, "Serial Number")
            End If

            If Not ComboBoxDevicesTargetType.Items.Contains("MAC Address") Then
                ComboBoxDevicesTargetType.Items.Insert(2, "MAC Address")
            End If

            If ComboBoxDevicesTargetType.SelectedItem = "" Then
                ComboBoxDevicesTargetType.SelectedItem = "Asset ID"
            End If

            ' Target text box
            TextBoxDevicesTarget.Text = ""
            ButtonDevicesTargetSearch.Visible = False
            ButtonDevicesTargetEdit.Visible = False
            TextBoxDevicesTarget.Size = New Size(365, 23)
        End If
    End Sub

    Private Sub TextBoxDeviceTarget_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBoxDevicesTarget.KeyPress
        ' Only restrict input if ComboBoxDeviceScope.SelectedItem is "Single"
        If ComboBoxDevicesScope.SelectedItem = "Single" Then
            ' Allow control keys (like Backspace, Delete, Enter, etc.)
            If Char.IsControl(e.KeyChar) Then
                Return
            End If

            ' Allow letters and digits only
            If Not Char.IsLetterOrDigit(e.KeyChar) Then
                e.Handled = True ' Block the key
            End If
        End If
    End Sub

    Private Sub ButtonDeviceSearch_Click(sender As Object, e As EventArgs) Handles ButtonDevicesTargetSearch.Click
        ' Create a new OpenFileDialog
        Dim openFileDialog As New OpenFileDialog()

        ' Set the dialog title
        openFileDialog.Title = "Select a CSV file"

        ' Set the initial directory to the user's desktop
        openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop)

        ' Only allow CSV files
        openFileDialog.Filter = "CSV Files (*.csv)|*.csv"

        ' Prevent multiple selection
        openFileDialog.Multiselect = False

        ' Show the dialog and check if the user clicked OK
        If openFileDialog.ShowDialog() = DialogResult.OK Then
            ' Put the selected file path in the textbox
            TextBoxDevicesTarget.Text = openFileDialog.FileName
        End If
    End Sub

    Private Sub ButtonDeviceEdit_Click(sender As Object, e As EventArgs) Handles ButtonDevicesTargetEdit.Click
        Dim filePath As String = TextBoxDevicesTarget.Text

        If IO.File.Exists(filePath) Then
            Try
                Process.Start(New ProcessStartInfo(filePath) With {.UseShellExecute = True})
            Catch ex As Exception
                RichTextBox1.Text = "Error opening file: " & ex.Message
            End Try
        Else
            ' Clear previous text
            RichTextBox1.Clear()
            ' Append normal text
            RichTextBox1.AppendText("The CSV file in the ")
            ' Append "Target" in bold
            Dim start As Integer = RichTextBox1.TextLength
            RichTextBox1.AppendText("Target")
            RichTextBox1.Select(start, "Target".Length)
            RichTextBox1.SelectionFont = New Font(RichTextBox1.Font, FontStyle.Bold)
            ' Reset font to normal and append the rest
            RichTextBox1.SelectionStart = RichTextBox1.TextLength
            RichTextBox1.SelectionLength = 0
            RichTextBox1.SelectionFont = New Font(RichTextBox1.Font, FontStyle.Regular)
            RichTextBox1.AppendText(" text box does not exist")
        End If
    End Sub

    Private Sub ComboBoxDeviceAction_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBoxDevicesAction.SelectedIndexChanged
        If Not ComboBoxDevicesAction.SelectedItem = "Move" Then
            ComboBoxDevicesDestination.Enabled = False
        Else
            ComboBoxDevicesDestination.Enabled = True
        End If
    End Sub

    Private Async Sub ButtonRun_Click(sender As Object, e As EventArgs) Handles ButtonRun.Click
        ' RUN > DEVICES
        If TabControl1.SelectedTab Is TabPageDevices Then
            Dim device As String = TextBoxDevicesTarget.Text
            Dim destination As String = ComboBoxDevicesDestination.Text
            Dim command As String = ""
            ' RUN > DEVICES > SINGLE > GET INFO
            If ComboBoxDevicesScope.SelectedItem = "Single" AndAlso ComboBoxDevicesAction.SelectedItem = "Get Info" Then
                Select Case ComboBoxDevicesTargetType.SelectedItem?.ToString()
                    ' RUN > DEVICES > SINGLE > GET INFO > ASSET ID
                    Case "Asset ID"
                        command = "gam cros_query asset_id:" & device & " info | findstr " & Chr(34) &
                              "macAddress serialNumber lastSync ipAddress wanIpAddress email: osVersion autoUpdateExpiration orgUnitPath annotatedAssetId" & Chr(34)
                    ' RUN > DEVICES > SINGLE > GET INFO > SERIAL NUMBER
                    Case "Serial Number"
                        command = "gam cros_sn " & device & " info | findstr " & Chr(34) &
                              "macAddress serialNumber lastSync ipAddress wanIpAddress email: osVersion autoUpdateExpiration orgUnitPath annotatedAssetId" & Chr(34)
                    ' RUN > DEVICES > SINGLE > GET INFO > MAC ADDRESS
                    Case "MAC Address"
                        command = "gam info cros query:wifi_mac:" & device & " | findstr " & Chr(34) &
                              "macAddress serialNumber lastSync ipAddress wanIpAddress email: osVersion autoUpdateExpiration orgUnitPath annotatedAssetId" & Chr(34)
                End Select

                If command <> "" Then
                    Try
                        ' Take snapshot & disable controls
                        SnapshotAndDisable(Me)


                        ' Run the GAM command in a background task
                        Dim output As String = Await Task.Run(Function()
                                                                  Dim psi As New ProcessStartInfo() With {
                                                                  .FileName = "cmd.exe",
                                                                  .Arguments = "/c " & command,
                                                                  .RedirectStandardOutput = True,
                                                                  .UseShellExecute = False,
                                                                  .CreateNoWindow = True
                                                              }
                                                                  Using proc As Process = Process.Start(psi)
                                                                      Using reader As IO.StreamReader = proc.StandardOutput
                                                                          Return reader.ReadToEnd()
                                                                      End Using
                                                                  End Using
                                                              End Function)

                        ' Back on UI thread — update RichTextBox
                        RichTextBox1.Text = output
                    Catch ex As Exception
                        RichTextBox1.Text = "Error running GAM: " & ex.Message

                    Finally
                        ' Restore all original Enabled states
                        RestoreStates()

                    End Try
                End If
                ' RUN > DEVICES > SINGLE > MOVE
            ElseIf ComboBoxDevicesScope.SelectedItem = "Single" AndAlso ComboBoxDevicesAction.SelectedItem = "Move" Then
                ' Decide which GAM command to run
                Select Case ComboBoxDevicesTargetType.SelectedItem?.ToString()
                    ' RUN > DEVICES > SINGLE > MOVE > ASSET ID
                    Case "Asset ID"
                        command = "gam update cros query:asset_id:" & device & " ou " & Chr(34) & destination & Chr(34) & ""
                    ' RUN > DEVICES > SINGLE > MOVE > SERIAL NUMBER
                    Case "Serial Number"
                        command = "gam update cros query:id:" & device & " ou " & Chr(34) & destination & Chr(34) & ""
                    ' RUN > DEVICES > SINGLE > MOVE > MAC ADDRESS
                    Case "MAC Address"
                        command = "gam update cros query:wifi_mac:" & device & " ou " & Chr(34) & destination & Chr(34) & ""
                End Select

                If command <> "" Then
                    Try
                        ' Take snapshot & disable controls
                        SnapshotAndDisable(Me)

                        ' Run the GAM command in a background task
                        Dim output As String = Await Task.Run(Function()
                                                                  Dim psi As New ProcessStartInfo() With {
                                                                  .FileName = "cmd.exe",
                                                                  .Arguments = "/c " & command,
                                                                  .RedirectStandardOutput = True,
                                                                  .UseShellExecute = False,
                                                                  .CreateNoWindow = True
                                                              }
                                                                  Using proc As Process = Process.Start(psi)
                                                                      Using reader As IO.StreamReader = proc.StandardOutput
                                                                          Return reader.ReadToEnd()
                                                                      End Using
                                                                  End Using
                                                              End Function)

                        ' Back on UI thread — update RichTextBox
                        RichTextBox1.Text = output
                    Catch ex As Exception
                        RichTextBox1.Text = "Error running GAM: " & ex.Message

                    Finally
                        ' Restore all original Enabled states
                        RestoreStates()
                    End Try
                End If
                ' RUN > DEVICES > SINGLE > ENABLE
            ElseIf ComboBoxDevicesScope.SelectedItem = "Single" AndAlso ComboBoxDevicesAction.SelectedItem = "Enable" Then
                Select Case ComboBoxDevicesTargetType.SelectedItem?.ToString()
                    ' RUN > DEVICES > SINGLE > ENABLE > ASSET ID
                    Case "Asset ID"
                        command = "gam update cros query:asset_id:" & device & " action reenable"
                    ' RUN > DEVICES > SINGLE > ENABLE > SERIAL NUMBER
                    Case "Serial Number"
                        command = "gam update cros cros_sn " & device & " action reenable"
                    ' RUN > DEVICES > SINGLE > ENABLE > MAC ADDRESS
                    Case "MAC Address"
                        command = "gam update cros query:wifi_mac:" & device & " action reenable"
                End Select

                If command <> "" Then
                    Try
                        ' Take snapshot & disable controls
                        SnapshotAndDisable(Me)

                        ' Run the GAM command in a background task
                        Dim output As String = Await Task.Run(Function()
                                                                  Dim psi As New ProcessStartInfo() With {
                                                                  .FileName = "cmd.exe",
                                                                  .Arguments = "/c " & command,
                                                                  .RedirectStandardOutput = True,
                                                                  .UseShellExecute = False,
                                                                  .CreateNoWindow = True
                                                              }
                                                                  Using proc As Process = Process.Start(psi)
                                                                      Using reader As IO.StreamReader = proc.StandardOutput
                                                                          Return reader.ReadToEnd()
                                                                      End Using
                                                                  End Using
                                                              End Function)

                        ' Back on UI thread — update RichTextBox
                        RichTextBox1.Text = output
                    Catch ex As Exception
                        RichTextBox1.Text = "Error running GAM: " & ex.Message

                    Finally
                        ' Restore all original Enabled states
                        RestoreStates()
                    End Try
                End If
                ' RUN > DEVICES > SINGLE > DISABLE
            ElseIf ComboBoxDevicesScope.SelectedItem = "Single" AndAlso ComboBoxDevicesAction.SelectedItem = "Disable" Then
                Select Case ComboBoxDevicesTargetType.SelectedItem?.ToString()
                    ' RUN > DEVICES > SINGLE > DISABLE > ASSET ID
                    Case "Asset ID"
                        command = "gam update cros query:asset_id:" & device & " action disable"
                    ' RUN > DEVICES > SINGLE > DISABLE > SERIAL NUMBER
                    Case "Serial Number"
                        command = "gam update cros cros_sn " & device & " action disable"
                    ' RUN > DEVICES > SINGLE > DISABLE > MAC ADDRESS
                    Case "MAC Address"
                        command = "gam update cros query:wifi_mac:" & device & " action disable"
                End Select

                If command <> "" Then
                    Try
                        ' Take snapshot & disable controls
                        SnapshotAndDisable(Me)

                        ' Run the GAM command in a background task
                        Dim output As String = Await Task.Run(Function()
                                                                  Dim psi As New ProcessStartInfo() With {
                                                                  .FileName = "cmd.exe",
                                                                  .Arguments = "/c " & command,
                                                                  .RedirectStandardOutput = True,
                                                                  .UseShellExecute = False,
                                                                  .CreateNoWindow = True
                                                              }
                                                                  Using proc As Process = Process.Start(psi)
                                                                      Using reader As IO.StreamReader = proc.StandardOutput
                                                                          Return reader.ReadToEnd()
                                                                      End Using
                                                                  End Using
                                                              End Function)

                        ' Back on UI thread — update RichTextBox
                        RichTextBox1.Text = output
                    Catch ex As Exception
                        RichTextBox1.Text = "Error running GAM: " & ex.Message

                    Finally
                        ' Restore all original Enabled states
                        RestoreStates()
                    End Try
                End If
                ' RUN > DEVICES > SINGLE > CLEAR PROFILES
            ElseIf ComboBoxDevicesScope.SelectedItem = "Single" AndAlso ComboBoxDevicesAction.SelectedItem = "Clear Profiles" Then
                Select Case ComboBoxDevicesTargetType.SelectedItem?.ToString()
                    ' RUN > DEVICES > SINGLE > CLEAR PROFILES > ASSET ID
                    Case "Asset ID"
                        command = "gam issuecommand cros query:asset_id:" & device & " command wipe_users doit"
                    ' RUN > DEVICES > SINGLE > CLEAR PROFILES > SERIAL NUMBER
                    Case "Serial Number"
                        command = "gam issuecommand cros query:id:" & device & " command wipe_users doit"
                    ' RUN > DEVICES > SINGLE > CLEAR PROFILES > MAC ADDRESS
                    Case "MAC Address"
                        command = "gam issuecommand cros query:wifi_mac:" & device & " command wipe_users doit"
                End Select

                If command <> "" Then
                    Try
                        ' Take snapshot & disable controls
                        SnapshotAndDisable(Me)

                        ' Run the GAM command in a background task
                        Dim output As String = Await Task.Run(Function()
                                                                  Dim psi As New ProcessStartInfo() With {
                                                                  .FileName = "cmd.exe",
                                                                  .Arguments = "/c " & command,
                                                                  .RedirectStandardOutput = True,
                                                                  .UseShellExecute = False,
                                                                  .CreateNoWindow = True
                                                              }
                                                                  Using proc As Process = Process.Start(psi)
                                                                      Using reader As IO.StreamReader = proc.StandardOutput
                                                                          Return reader.ReadToEnd()
                                                                      End Using
                                                                  End Using
                                                              End Function)

                        ' Back on UI thread — update RichTextBox
                        RichTextBox1.Text = output
                    Catch ex As Exception
                        RichTextBox1.Text = "Error running GAM: " & ex.Message

                    Finally
                        ' Restore all original Enabled states
                        RestoreStates()
                    End Try
                End If
                ' RUN > DEVICES > SINGLE > POWERWASH
            ElseIf ComboBoxDevicesScope.SelectedItem = "Single" AndAlso ComboBoxDevicesAction.SelectedItem = "Powerwash" Then
                Select Case ComboBoxDevicesTargetType.SelectedItem?.ToString()
                    ' RUN > DEVICES > SINGLE > POWERWASH > ASSET ID
                    Case "Asset ID"
                        command = "gam issuecommand cros query:asset_id:" & device & " command remote_powerwash times_to_check_status 10 doit"
                    ' RUN > DEVICES > SINGLE > POWERWASH > SERIAL NUMBER
                    Case "Serial Number"
                        command = "gam issuecommand cros query:id:" & device & " command remote_powerwash times_to_check_status 10 doit"
                    ' RUN > DEVICES > SINGLE > POWERWASH > MAC ADDRESS
                    Case "MAC Address"
                        command = "gam issuecommand cros query:wifi_mac:" & device & " command remote_powerwash times_to_check_status 10 doit"
                End Select

                If command <> "" Then
                    Try
                        ' Take snapshot & disable controls
                        SnapshotAndDisable(Me)

                        ' Run the GAM command in a background task
                        Dim output As String = Await Task.Run(Function()
                                                                  Dim psi As New ProcessStartInfo() With {
                                                                  .FileName = "cmd.exe",
                                                                  .Arguments = "/c " & command,
                                                                  .RedirectStandardOutput = True,
                                                                  .UseShellExecute = False,
                                                                  .CreateNoWindow = True
                                                              }
                                                                  Using proc As Process = Process.Start(psi)
                                                                      Using reader As IO.StreamReader = proc.StandardOutput
                                                                          Return reader.ReadToEnd()
                                                                      End Using
                                                                  End Using
                                                              End Function)

                        ' Back on UI thread — update RichTextBox
                        RichTextBox1.Text = output
                    Catch ex As Exception
                        RichTextBox1.Text = "Error running GAM: " & ex.Message

                    Finally
                        ' Restore all original Enabled states
                        RestoreStates()
                    End Try
                End If
                ' RUN > DEVICES > SINGLE > DEPROVISION
            ElseIf ComboBoxDevicesScope.SelectedItem = "Single" AndAlso ComboBoxDevicesAction.SelectedItem = "Deprovision" Then
                ' Ask for confirmation first
                Dim result As DialogResult = MessageBox.Show(
                    "This cannot be undone without physical access to the Chromebook. Are you sure?",
                    "Confirm Deprovision",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning
                )

                If result = DialogResult.Yes Then
                    Select Case ComboBoxDevicesTargetType.SelectedItem?.ToString()
                        ' RUN > DEVICES > SINGLE > DEPROVISION > ASSET ID
                        Case "Asset ID"
                            command = "gam update cros query:asset_id:" & device & " action deprovision_retiring_device acknowledge_device_touch_requirement"
                        ' RUN > DEVICES > SINGLE > DEPROVISION > SERIAL NUMBER
                        Case "Serial Number"
                            command = "gam update cros query:id:" & device & " action deprovision_retiring_device acknowledge_device_touch_requirement"
                        ' RUN > DEVICES > SINGLE > DEPROVISION > MAC ADDRESS
                        Case "MAC Address"
                            command = "gam update cros query:wifi_mac:" & device & " action deprovision_retiring_device acknowledge_device_touch_requirement"
                    End Select

                    If command <> "" Then
                        Try
                            ' Take snapshot & disable controls
                            SnapshotAndDisable(Me)

                            ' Run the GAM command in a background task
                            Dim output As String = Await Task.Run(Function()
                                                                      Dim psi As New ProcessStartInfo() With {
                                                                  .FileName = "cmd.exe",
                                                                  .Arguments = "/c " & command,
                                                                  .RedirectStandardOutput = True,
                                                                  .UseShellExecute = False,
                                                                  .CreateNoWindow = True
                                                              }
                                                                      Using proc As Process = Process.Start(psi)
                                                                          Using reader As IO.StreamReader = proc.StandardOutput
                                                                              Return reader.ReadToEnd()
                                                                          End Using
                                                                      End Using
                                                                  End Function)

                            ' Back on UI thread — update RichTextBox
                            RichTextBox1.Text = output
                        Catch ex As Exception
                            RichTextBox1.Text = "Error running GAM: " & ex.Message

                        Finally
                            ' Restore all original Enabled states
                            RestoreStates()
                        End Try
                    End If
                End If
                ' RUN > DEVICES > MULTIPLE
            ElseIf ComboBoxDevicesScope.SelectedItem = "Multiple" Then
                Select Case ComboBoxDevicesAction.SelectedItem?.ToString()
                    ' RUN > DEVICES > MULTIPLE > MOVE
                    Case "Move"
                        command = "gam csv " & Chr(34) & device & Chr(34) & " gam update cros query:asset_id:~~assetid~~ ou " & Chr(34) & destination & Chr(34) & ""
                    ' RUN > DEVICES > MULTIPLE > ENABLE
                    Case "Enable"
                        command = "gam csv " & Chr(34) & device & Chr(34) & " gam update cros query:asset_id:~~assetid~~ action reenable"
                    ' RUN > DEVICES > MULTIPLE > DISABLE
                    Case "Disable"
                        command = "gam csv " & Chr(34) & device & Chr(34) & " gam update cros query:asset_id:~~assetid~~ action disable"
                    ' RUN > DEVICES > MULTIPLE > CLEAR PROFILES
                    Case "Clear Profiles"
                        command = "gam csv " & Chr(34) & device & Chr(34) & " gam issuecommand cros query:asset_id:~~assetid~~ command wipe_users doit"
                    ' RUN > DEVICES > MULTIPLE > POWERWASH
                    Case "Powerwash"
                        command = "gam csv " & Chr(34) & device & Chr(34) & " gam issuecommand cros query:asset_id:~~assetid~~ command remote_powerwash times_to_check_status 10 doit"
                    ' RUN > DEVICES > MULTIPLE > DEPROVISION
                    Case "Deprovision"
                        ' Ask for confirmation first
                        Dim result As DialogResult = MessageBox.Show(
                            "This cannot be undone without physical access to the Chromebooks. Are you sure?",
                            "Confirm Deprovision",
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Warning
                        )

                        If result = DialogResult.Yes Then
                            command = "gam csv " & Chr(34) & device & Chr(34) & " gam update cros query:asset_id:~~assetid~~ action deprovision_retiring_device acknowledge_device_touch_requirement"
                        Else
                            RichTextBox1.Text = "Deprovision command has been cancelled"
                        End If
                End Select

                If command <> "" Then
                    Try
                        ' Take snapshot & disable controls
                        SnapshotAndDisable(Me)

                        ' Run the GAM command in a background task
                        Dim output As String = Await Task.Run(Function()
                                                                  Dim psi As New ProcessStartInfo() With {
                                                                  .FileName = "cmd.exe",
                                                                  .Arguments = "/c " & command,
                                                                  .RedirectStandardOutput = True,
                                                                  .UseShellExecute = False,
                                                                  .CreateNoWindow = True
                                                              }
                                                                  Using proc As Process = Process.Start(psi)
                                                                      Using reader As IO.StreamReader = proc.StandardOutput
                                                                          Return reader.ReadToEnd()
                                                                      End Using
                                                                  End Using
                                                              End Function)

                        ' Back on UI thread — update RichTextBox
                        RichTextBox1.Text = output
                    Catch ex As Exception
                        RichTextBox1.Text = "Error running GAM: " & ex.Message

                    Finally
                        ' Restore all original Enabled states
                        RestoreStates()
                    End Try
                End If
            End If

        ElseIf TabControl1.SelectedTab Is TabPageUsers Then
            ' RUN > USERS
            Dim user As String = TextBoxUsersTarget.Text
            Dim group As String = ComboBoxUsersGroupDestination.Text
            Dim target As String = TextBoxUsersTarget.Text
            Dim targetOU As String = ComboBoxUsersTarget.Text
            Dim filePath As String = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), user & ".csv")
            Dim command As String = ""
            Dim commandShowFiles As String = ""
            Dim destination As String = ComboBoxUsersDestination.Text

            ' RUN > USERS > USER
            If ComboBoxUsersScope.SelectedItem = "User" Then
                Select Case ComboBoxUsersAction.SelectedItem?.ToString()
                    ' RUN > USERS > USER > GET INFO
                    Case "Get Info"
                        command = "gam info user " & user & " | findstr " & Chr(34) & "Full login Creation Archived Path location title Account" & Chr(34) _
                                  & " && echo. && echo GOOGLE CLASSROOMS - TEACHER && gam print courses teacher " & user & " fields coursestate,name,id" _
                                  & " && echo. && echo GOOGLE CLASSROOMS - STUDENT && gam print courses student " & user & " fields coursestate,name,id" _
                                  & " && echo. && echo GROUPS && gam print groups member " & user & " fields description"
                    ' RUN > USERS > USER > RECENT DEVICES
                    Case "Recent Devices"
                        command = "gam print cros query recent_user:" & user & " serialnumber assetid"
                    ' RUN > USERS > USER > SHOW FILES
                    Case "Show Files"
                        commandShowFiles = "gam user " & user & " print filetree fields id,trashed,explicitlytrashed,size,mimetype,owners,parents > """ & filePath & """"
                    ' RUN > USERS > USER > MOVE
                    Case "Move"
                        command = "gam update user " & user & " org " & Chr(34) & destination & Chr(34) & ""
                    ' RUN > USERS > USER > ENABLE
                    Case "Enable"
                        command = "gam update user " & user & " suspended off"
                    ' RUN > USERS > USER > SUSPEND
                    Case "Suspend"
                        command = "gam update user " & user & " suspended on"
                    ' RUN > USERS > USER > ARCHIVE
                    Case "Archive"
                        command = "gam update user " & user & " archived on"
                    ' RUN > USERS > USER > UNARCHIVE
                    Case "Unarchive"
                        command = "gam update user " & user & " archived off"
                    ' RUN > USERS > USER > ADD TO GROUP
                    Case "Add to Group"
                        command = "gam user " & user & " add group " & group & ""
                    ' RUN > USERS > USER > REMOVE FROM GROUP
                    Case "Remove from Group"
                        command = "gam user " & user & " delete group " & group & ""
                End Select
                ' RUN > USERS > USERS
            ElseIf ComboBoxUsersScope.SelectedItem = "Users" Then
                Select Case ComboBoxUsersAction.SelectedItem?.ToString()
                    ' RUN > USERS > USERS > MOVE
                    Case "Move"
                        command = "gam csv " & Chr(34) & user & Chr(34) & " gam update user ~email org " & Chr(34) & destination & Chr(34)
                    ' RUN > USERS > USERS > ENABLE
                    Case "Enable"
                        command = "gam csv " & Chr(34) & user & Chr(34) & " gam update user ~email suspended off"
                    ' RUN > USERS > USERS > SUSPEND
                    Case "Suspend"
                        command = "gam csv " & Chr(34) & user & Chr(34) & " gam update user ~email suspended on"
                    ' RUN > USERS > USERS > ARCHIVE
                    Case "Archive"
                        command = "gam csv " & user & " gam update user ~email archived on"
                    ' RUN > USERS > USERS > UNARCHIVE
                    Case "Unarchive"
                        command = "gam csv " & user & " gam update user ~email archived off"
                    ' RUN > USERS > USERS > ADD TO GROUP
                    Case "Add to Group"
                        command = "gam csv " & Chr(34) & user & Chr(34) & " gam user ~email add group " & group & ""
                    ' RUN > USERS > USERS > REMOVE FROM GROUP
                    Case "Remove from Group"
                        command = "gam csv " & Chr(34) & user & Chr(34) & " gam user ~email delete group " & group & ""

                End Select
                ' RUN > USERS > OU
            ElseIf ComboBoxUsersScope.SelectedItem = "OU" Then
                Select Case ComboBoxUsersAction.SelectedItem?.ToString()
                    ' RUN > USERS > OU > GET INFO
                    Case "Get Info"
                        'command = "gam info org " & Chr(34) & targetOU & Chr(34) & ""
                        command = "gam print users query " & Chr(34) & "orgUnitPath='" & targetOU & "'" & Chr(34) & " fields primaryEmail,first_name,last_name,archived,suspended,creationTime,lastLoginTime"
                    ' RUN > USERS > OU > MOVE
                    Case "Move"
                        command = "gam org " & Chr(34) & targetOU & Chr(34) & " update user org " & Chr(34) & destination & Chr(34) & ""
                End Select
            End If

            If command <> "" Then
                Try
                    ' Take snapshot & disable controls
                    SnapshotAndDisable(Me)

                    ' Run the GAM command in a background task
                    Dim output As String = Await Task.Run(Function()
                                                              Dim psi As New ProcessStartInfo() With {
                                                                  .FileName = "cmd.exe",
                                                                  .Arguments = "/c " & command,
                                                                  .RedirectStandardOutput = True,
                                                                  .UseShellExecute = False,
                                                                  .CreateNoWindow = True
                                                              }
                                                              Using proc As Process = Process.Start(psi)
                                                                  Using reader As IO.StreamReader = proc.StandardOutput
                                                                      Return reader.ReadToEnd()
                                                                  End Using
                                                              End Using
                                                          End Function)

                    ' Back on UI thread — update RichTextBox
                    RichTextBox1.Text = output
                Catch ex As Exception
                    RichTextBox1.Text = "Error running GAM: " & ex.Message
                Finally
                    ' Restore all original Enabled states
                    RestoreStates()
                End Try
            End If

            If commandShowFiles <> "" Then
                Try
                    ' Take snapshot & disable controls
                    SnapshotAndDisable(Me)

                    ' Run the GAM command in a background task
                    Dim output As String = Await Task.Run(Function()
                                                              Dim psi As New ProcessStartInfo() With {
                                                                  .FileName = "cmd.exe",
                                                                  .Arguments = "/c " & commandShowFiles,
                                                                  .RedirectStandardOutput = True,
                                                                  .UseShellExecute = False,
                                                                  .CreateNoWindow = True
                                                              }
                                                              Using proc As Process = Process.Start(psi)
                                                                  Using reader As IO.StreamReader = proc.StandardOutput
                                                                      Return reader.ReadToEnd()
                                                                  End Using
                                                              End Using
                                                          End Function)

                    ' Back on UI thread — update RichTextBox
                    RichTextBox1.Text = filePath

                    ' Now open the CSV with the default application
                    Process.Start(New ProcessStartInfo(filePath) With {.UseShellExecute = True})

                Catch ex As Exception
                    RichTextBox1.Text = "Error running GAM: " & ex.Message
                Finally
                    ' Restore all original Enabled states
                    RestoreStates()
                End Try
            End If
        ElseIf TabControl1.SelectedTab Is TabPageFiles Then
            ' RUN > FILES
            Dim documentID As String = TextBoxFilesDocumentID.Text
            Dim userWithAccess As String = TextBoxFilesUserWithAccess.Text
            Dim targetUser As String = TextBoxFilesTargetUser.Text
            Dim command As String = ""

            Select Case ComboBoxFilesAction.SelectedItem?.ToString()
                ' RUN > FILES > GET INFO
                Case "Get Info"
                    ' Document ID text box can't be blank
                    If TextBoxFilesDocumentID.Text = "" Then
                        ' Clear previous text
                        RichTextBox1.Clear()
                        ' Append normal text
                        RichTextBox1.AppendText("Use ")
                        ' Append text in bold
                        Dim start As Integer = RichTextBox1.TextLength
                        RichTextBox1.AppendText("Find")
                        RichTextBox1.Select(start, "Find".Length)
                        RichTextBox1.SelectionFont = New Font(RichTextBox1.Font, FontStyle.Bold)
                        ' Reset font to normal and append the rest
                        RichTextBox1.SelectionStart = RichTextBox1.TextLength
                        RichTextBox1.SelectionLength = 0
                        RichTextBox1.SelectionFont = New Font(RichTextBox1.Font, FontStyle.Regular)
                        RichTextBox1.AppendText(" to get a file's Document ID")

                        ' STOP execution
                        Return
                        ' User with Access text box can't be blank
                    ElseIf TextBoxFilesUserWithAccess.Text = "" Then
                        ' Clear previous text
                        RichTextBox1.Clear()
                        ' Append normal text
                        RichTextBox1.AppendText("The ")
                        ' Append text in bold
                        Dim start As Integer = RichTextBox1.TextLength
                        RichTextBox1.AppendText("User with Access")
                        RichTextBox1.Select(start, "User with Access".Length)
                        RichTextBox1.SelectionFont = New Font(RichTextBox1.Font, FontStyle.Bold)
                        ' Reset font to normal and append the rest
                        RichTextBox1.SelectionStart = RichTextBox1.TextLength
                        RichTextBox1.SelectionLength = 0
                        RichTextBox1.SelectionFont = New Font(RichTextBox1.Font, FontStyle.Regular)
                        RichTextBox1.AppendText(" text box must contain the email address of a user that has read or write access to the file")

                        ' STOP execution
                        Return
                    Else
                        command = "gam user " & userWithAccess & " show fileinfo " & documentID & " filepath | findstr " & Chr(34) & "path: createdTime lastModifyingUser: displayName: emailAddress: modifiedTime: role: writersCanShare: Permissions: trashed: explicitlyTrashed:" & Chr(34) & ""
                    End If
                ' RUN > FILES > UNTRASH
                Case "Untrash"
                    ' Document ID text box can't be blank
                    If TextBoxFilesDocumentID.Text = "" Then
                        ' Clear previous text
                        RichTextBox1.Clear()
                        ' Append normal text
                        RichTextBox1.AppendText("Use ")
                        ' Append text in bold
                        Dim start As Integer = RichTextBox1.TextLength
                        RichTextBox1.AppendText("Find")
                        RichTextBox1.Select(start, "Find".Length)
                        RichTextBox1.SelectionFont = New Font(RichTextBox1.Font, FontStyle.Bold)
                        ' Reset font to normal and append the rest
                        RichTextBox1.SelectionStart = RichTextBox1.TextLength
                        RichTextBox1.SelectionLength = 0
                        RichTextBox1.SelectionFont = New Font(RichTextBox1.Font, FontStyle.Regular)
                        RichTextBox1.AppendText(" to get a file's Document ID")

                        ' STOP execution
                        Return
                        ' User with Access text box can't be blank
                    ElseIf TextBoxFilesUserWithAccess.Text = "" Then
                        ' Clear previous text
                        RichTextBox1.Clear()
                        ' Append normal text
                        RichTextBox1.AppendText("The ")
                        ' Append text in bold
                        Dim start As Integer = RichTextBox1.TextLength
                        RichTextBox1.AppendText("User with Access")
                        RichTextBox1.Select(start, "User with Access".Length)
                        RichTextBox1.SelectionFont = New Font(RichTextBox1.Font, FontStyle.Bold)
                        ' Reset font to normal and append the rest
                        RichTextBox1.SelectionStart = RichTextBox1.TextLength
                        RichTextBox1.SelectionLength = 0
                        RichTextBox1.SelectionFont = New Font(RichTextBox1.Font, FontStyle.Regular)
                        RichTextBox1.AppendText(" text box must contain the email address of a user that has read or write access to the file")

                        ' STOP execution
                        Return
                    Else
                        command = "gam user " & userWithAccess & " untrash drivefile " & documentID & ""
                    End If
                ' RUN > FILES > ASSIGN OWNER
                Case "Assign Owner"
                    ' Document ID text box can't be blank
                    If TextBoxFilesDocumentID.Text = "" Then
                        ' Clear previous text
                        RichTextBox1.Clear()
                        ' Append normal text
                        RichTextBox1.AppendText("Use ")
                        ' Append text in bold
                        Dim start As Integer = RichTextBox1.TextLength
                        RichTextBox1.AppendText("Find")
                        RichTextBox1.Select(start, "Find".Length)
                        RichTextBox1.SelectionFont = New Font(RichTextBox1.Font, FontStyle.Bold)
                        ' Reset font to normal and append the rest
                        RichTextBox1.SelectionStart = RichTextBox1.TextLength
                        RichTextBox1.SelectionLength = 0
                        RichTextBox1.SelectionFont = New Font(RichTextBox1.Font, FontStyle.Regular)
                        RichTextBox1.AppendText(" to get a file's Document ID")

                        ' STOP execution
                        Return
                        ' User with Access text box can't be blank
                    ElseIf TextBoxFilesUserWithAccess.Text = "" Then
                        ' Clear previous text
                        RichTextBox1.Clear()
                        ' Append normal text
                        RichTextBox1.AppendText("The ")
                        ' Append text in bold
                        Dim start As Integer = RichTextBox1.TextLength
                        RichTextBox1.AppendText("User with Access")
                        RichTextBox1.Select(start, "User with Access".Length)
                        RichTextBox1.SelectionFont = New Font(RichTextBox1.Font, FontStyle.Bold)
                        ' Reset font to normal and append the rest
                        RichTextBox1.SelectionStart = RichTextBox1.TextLength
                        RichTextBox1.SelectionLength = 0
                        RichTextBox1.SelectionFont = New Font(RichTextBox1.Font, FontStyle.Regular)
                        RichTextBox1.AppendText(" text box must contain the email address of a user that has read or write access to the file")

                        ' STOP execution
                        Return
                        ' Target user text box can't be blank
                    ElseIf TextBoxFilesTargetUser.Text = "" Then
                        ' Clear previous text
                        RichTextBox1.Clear()
                        ' Append normal text
                        RichTextBox1.AppendText("The ")
                        ' Append text in bold
                        Dim start As Integer = RichTextBox1.TextLength
                        RichTextBox1.AppendText("Target User")
                        RichTextBox1.Select(start, "Target User".Length)
                        RichTextBox1.SelectionFont = New Font(RichTextBox1.Font, FontStyle.Bold)
                        ' Reset font to normal and append the rest
                        RichTextBox1.SelectionStart = RichTextBox1.TextLength
                        RichTextBox1.SelectionLength = 0
                        RichTextBox1.SelectionFont = New Font(RichTextBox1.Font, FontStyle.Regular)
                        RichTextBox1.AppendText(" text box must contain the email address of the user who will get ownership")

                        ' STOP execution
                        Return
                    Else
                        command = "gam user " & userWithAccess & " add drivefileacl " & documentID & " user " & targetUser & " role owner”
                    End If
                ' RUN > FILES > ADD EDITOR
                Case "Add Editor"
                    ' Document ID text box can't be blank
                    If TextBoxFilesDocumentID.Text = "" Then
                        ' Clear previous text
                        RichTextBox1.Clear()
                        ' Append normal text
                        RichTextBox1.AppendText("Use ")
                        ' Append text in bold
                        Dim start As Integer = RichTextBox1.TextLength
                        RichTextBox1.AppendText("Find")
                        RichTextBox1.Select(start, "Find".Length)
                        RichTextBox1.SelectionFont = New Font(RichTextBox1.Font, FontStyle.Bold)
                        ' Reset font to normal and append the rest
                        RichTextBox1.SelectionStart = RichTextBox1.TextLength
                        RichTextBox1.SelectionLength = 0
                        RichTextBox1.SelectionFont = New Font(RichTextBox1.Font, FontStyle.Regular)
                        RichTextBox1.AppendText(" to get a file's Document ID")

                        ' STOP execution
                        Return
                        ' User with Access text box can't be blank
                    ElseIf TextBoxFilesUserWithAccess.Text = "" Then
                        ' Clear previous text
                        RichTextBox1.Clear()
                        ' Append normal text
                        RichTextBox1.AppendText("The ")
                        ' Append text in bold
                        Dim start As Integer = RichTextBox1.TextLength
                        RichTextBox1.AppendText("User with Access")
                        RichTextBox1.Select(start, "User with Access".Length)
                        RichTextBox1.SelectionFont = New Font(RichTextBox1.Font, FontStyle.Bold)
                        ' Reset font to normal and append the rest
                        RichTextBox1.SelectionStart = RichTextBox1.TextLength
                        RichTextBox1.SelectionLength = 0
                        RichTextBox1.SelectionFont = New Font(RichTextBox1.Font, FontStyle.Regular)
                        RichTextBox1.AppendText(" text box must contain the email address of a user that has read or write access to the file")

                        ' STOP execution
                        Return
                        ' Target user text box can't be blank
                    ElseIf TextBoxFilesTargetUser.Text = "" Then
                        ' Clear previous text
                        RichTextBox1.Clear()
                        ' Append normal text
                        RichTextBox1.AppendText("The ")
                        ' Append text in bold
                        Dim start As Integer = RichTextBox1.TextLength
                        RichTextBox1.AppendText("Target User")
                        RichTextBox1.Select(start, "Target User".Length)
                        RichTextBox1.SelectionFont = New Font(RichTextBox1.Font, FontStyle.Bold)
                        ' Reset font to normal and append the rest
                        RichTextBox1.SelectionStart = RichTextBox1.TextLength
                        RichTextBox1.SelectionLength = 0
                        RichTextBox1.SelectionFont = New Font(RichTextBox1.Font, FontStyle.Regular)
                        RichTextBox1.AppendText(" text box must contain the email address of the user who will get editor access")

                        ' STOP execution
                        Return
                    Else
                        command = "gam user " & userWithAccess & " add drivefileacl " & documentID & " user " & targetUser & " role editor”
                    End If
                ' RUN > FILES > ADD READER
                Case "Add Reader"
                    ' Document ID text box can't be blank
                    If TextBoxFilesDocumentID.Text = "" Then
                        ' Clear previous text
                        RichTextBox1.Clear()
                        ' Append normal text
                        RichTextBox1.AppendText("Use ")
                        ' Append text in bold
                        Dim start As Integer = RichTextBox1.TextLength
                        RichTextBox1.AppendText("Find")
                        RichTextBox1.Select(start, "Find".Length)
                        RichTextBox1.SelectionFont = New Font(RichTextBox1.Font, FontStyle.Bold)
                        ' Reset font to normal and append the rest
                        RichTextBox1.SelectionStart = RichTextBox1.TextLength
                        RichTextBox1.SelectionLength = 0
                        RichTextBox1.SelectionFont = New Font(RichTextBox1.Font, FontStyle.Regular)
                        RichTextBox1.AppendText(" to get a file's Document ID")

                        ' STOP execution
                        Return
                        ' User with Access text box can't be blank
                    ElseIf TextBoxFilesUserWithAccess.Text = "" Then
                        ' Clear previous text
                        RichTextBox1.Clear()
                        ' Append normal text
                        RichTextBox1.AppendText("The ")
                        ' Append text in bold
                        Dim start As Integer = RichTextBox1.TextLength
                        RichTextBox1.AppendText("User with Access")
                        RichTextBox1.Select(start, "User with Access".Length)
                        RichTextBox1.SelectionFont = New Font(RichTextBox1.Font, FontStyle.Bold)
                        ' Reset font to normal and append the rest
                        RichTextBox1.SelectionStart = RichTextBox1.TextLength
                        RichTextBox1.SelectionLength = 0
                        RichTextBox1.SelectionFont = New Font(RichTextBox1.Font, FontStyle.Regular)
                        RichTextBox1.AppendText(" text box must contain the email address of a user that has read or write access to the file")

                        ' STOP execution
                        Return
                        ' Target user text box can't be blank
                    ElseIf TextBoxFilesTargetUser.Text = "" Then
                        ' Clear previous text
                        RichTextBox1.Clear()
                        ' Append normal text
                        RichTextBox1.AppendText("The ")
                        ' Append text in bold
                        Dim start As Integer = RichTextBox1.TextLength
                        RichTextBox1.AppendText("Target User")
                        RichTextBox1.Select(start, "Target User".Length)
                        RichTextBox1.SelectionFont = New Font(RichTextBox1.Font, FontStyle.Bold)
                        ' Reset font to normal and append the rest
                        RichTextBox1.SelectionStart = RichTextBox1.TextLength
                        RichTextBox1.SelectionLength = 0
                        RichTextBox1.SelectionFont = New Font(RichTextBox1.Font, FontStyle.Regular)
                        RichTextBox1.AppendText(" text box must contain the email address of the user who will get read access")

                        ' STOP execution
                        Return
                    Else
                        command = "gam user " & userWithAccess & " add drivefileacl " & documentID & " user " & targetUser & " role reader”
                    End If
                ' RUN > FILES > REMOVE ACCESS
                Case "Remove Access"
                    ' Document ID text box can't be blank
                    If TextBoxFilesDocumentID.Text = "" Then
                        ' Clear previous text
                        RichTextBox1.Clear()
                        ' Append normal text
                        RichTextBox1.AppendText("Use ")
                        ' Append text in bold
                        Dim start As Integer = RichTextBox1.TextLength
                        RichTextBox1.AppendText("Find")
                        RichTextBox1.Select(start, "Find".Length)
                        RichTextBox1.SelectionFont = New Font(RichTextBox1.Font, FontStyle.Bold)
                        ' Reset font to normal and append the rest
                        RichTextBox1.SelectionStart = RichTextBox1.TextLength
                        RichTextBox1.SelectionLength = 0
                        RichTextBox1.SelectionFont = New Font(RichTextBox1.Font, FontStyle.Regular)
                        RichTextBox1.AppendText(" to get a file's Document ID")

                        ' STOP execution
                        Return
                        ' User with Access text box can't be blank
                    ElseIf TextBoxFilesUserWithAccess.Text = "" Then
                        ' Clear previous text
                        RichTextBox1.Clear()
                        ' Append normal text
                        RichTextBox1.AppendText("The ")
                        ' Append text in bold
                        Dim start As Integer = RichTextBox1.TextLength
                        RichTextBox1.AppendText("User with Access")
                        RichTextBox1.Select(start, "User with Access".Length)
                        RichTextBox1.SelectionFont = New Font(RichTextBox1.Font, FontStyle.Bold)
                        ' Reset font to normal and append the rest
                        RichTextBox1.SelectionStart = RichTextBox1.TextLength
                        RichTextBox1.SelectionLength = 0
                        RichTextBox1.SelectionFont = New Font(RichTextBox1.Font, FontStyle.Regular)
                        RichTextBox1.AppendText(" text box must contain the email address of a user that has read or write access to the file")

                        ' STOP execution
                        Return
                        ' Target user text box can't be blank
                    ElseIf TextBoxFilesTargetUser.Text = "" Then
                        ' Clear previous text
                        RichTextBox1.Clear()
                        ' Append normal text
                        RichTextBox1.AppendText("The ")
                        ' Append text in bold
                        Dim start As Integer = RichTextBox1.TextLength
                        RichTextBox1.AppendText("Target User")
                        RichTextBox1.Select(start, "Target User".Length)
                        RichTextBox1.SelectionFont = New Font(RichTextBox1.Font, FontStyle.Bold)
                        ' Reset font to normal and append the rest
                        RichTextBox1.SelectionStart = RichTextBox1.TextLength
                        RichTextBox1.SelectionLength = 0
                        RichTextBox1.SelectionFont = New Font(RichTextBox1.Font, FontStyle.Regular)
                        RichTextBox1.AppendText(" text box must contain the email address of the user who will lose access")

                        ' STOP execution
                        Return
                    Else
                        command = "gam user " & userWithAccess & " delete drivefileacl " & documentID & " " & targetUser & ""
                    End If
            End Select

            If command <> "" Then
                Try
                    ' Take snapshot & disable controls
                    SnapshotAndDisable(Me)

                    ' Run the GAM command in a background task
                    Dim output As String = Await Task.Run(Function()
                                                              Dim psi As New ProcessStartInfo() With {
                                                                  .FileName = "cmd.exe",
                                                                  .Arguments = "/c " & command,
                                                                  .RedirectStandardOutput = True,
                                                                  .UseShellExecute = False,
                                                                  .CreateNoWindow = True
                                                              }
                                                              Using proc As Process = Process.Start(psi)
                                                                  Using reader As IO.StreamReader = proc.StandardOutput
                                                                      Return reader.ReadToEnd()
                                                                  End Using
                                                              End Using
                                                          End Function)

                    ' Back on UI thread — update RichTextBox
                    RichTextBox1.Text = output
                Catch ex As Exception
                    RichTextBox1.Text = "Error running GAM: " & ex.Message
                Finally
                    ' Restore all original Enabled states
                    RestoreStates()
                End Try
            End If
            ' RUN > DATA TRANSFER
        ElseIf TabControl1.SelectedTab Is TabPageDataTransfer Then
            Dim documentID As String = TextBoxDataTransferDocumentID.Text
            Dim sourceUser As String = TextBoxDataTransferSourceUser.Text
            Dim destinationUser As String = TextBoxDataTransferDestinationUser.Text
            Dim retainRole As String = ComboBoxDataTransferSourceUserRetainRole.Text
            Dim retainRoleShared As String = ComboBoxDataTransferSourceUserRetainRoleShared.Text
            Dim gainRoleShared As String = ComboBoxDataTransferDestinationUserGainRoleShared.Text
            Dim command As String = ""

            Select Case ComboBoxDataTransferScope.SelectedItem?.ToString()
                ' RUN > DATA TRANSFER > ALL
                Case "All"
                    command = "gam user " & sourceUser & " transfer drive " & destinationUser & " retainrole " & retainRole & " nonowner_retainrole " & retainRoleShared & " nonowner_targetrole " & gainRoleShared & ""
                ' RUN > DATA TRANSFER > FOLDER
                Case "Folder"
                    command = "gam user " & sourceUser & " transfer drive " & destinationUser & " select " & documentID & " retainrole " & retainRole & ""
                ' RUN > DATA TRANSFER > ALL BUT FOLDER
                Case "All But Folder"
                    command = "gam user " & sourceUser & " transfer drive " & destinationUser & " skipids " & documentID & " retainrole " & retainRole & " nonowner_retainrole " & retainRoleShared & " nonowner_targetrole " & gainRoleShared & "”
            End Select

            If command <> "" Then
                Try
                    ' Run the GAM command in a new window
                    Process.Start("CMD", "/K" & command & "")
                Catch ex As Exception
                    RichTextBox1.Text = "Error running GAM: " & ex.Message
                End Try
            End If
        ElseIf TabControl1.SelectedTab Is TabPageCourses Then
            Dim courseID As String = TextBoxCoursesCourseID.Text
            Dim user As String = TextBoxCoursesUser.Text
            Dim command As String = ""

            Select Case ComboBoxCoursesScope.SelectedItem?.ToString()
                ' RUN > COURSES > SINGLE
                Case "Single"
                    Select Case ComboBoxCoursesAction.SelectedItem?.ToString()
                        ' RUN > COURSES > SINGLE > GET INFO
                        Case "Get Info"
                            command = "gam info course " & courseID & ""
                        ' RUN > COURSES > SINGLE > SHOW MEMBERS
                        Case "Show Members"
                            command = "echo GOOGLE CLASSROOM - TEACHER && gam config csv_output_header_filter courseId,courseName,profile.emailAddress print course-participants course " & courseID & " show teachers" _
                                  & " && echo. && echo GOOGLE CLASSROOM - STUDENT && gam config csv_output_header_filter courseId,courseName,profile.emailAddress print course-participants course " & courseID & " show students"
                        ' RUN > COURSES > SINGLE > ARCHIVE
                        Case "Archive"
                            command = "gam update course " & courseID & " state archived"
                        ' RUN > COURSES > SINGLE > UNARCHIVE
                        Case "Unarchive"
                            command = "gam update course " & courseID & " state active"
                        ' RUN > COURSES > SINGLE > ASSIGN OWNER
                        Case "Assign Owner"
                            command = "gam update course " & courseID & " owner " & user & ""
                        ' RUN > COURSES > SINGLE > ADD TEACHER
                        Case "Add Teacher"
                            command = "gam course " & courseID & " add teacher " & user & ""
                        ' RUN > COURSES > SINGLE > ADD STUDENT
                        Case "Add Student"
                            command = "gam course " & courseID & " add student " & user & ""
                        ' RUN > COURSES > SINGLE > REMOVE TEACHER
                        Case "Remove Teacher"
                            command = "gam course " & courseID & " remove teacher " & user & ""
                        ' RUN > COURSES > SINGLE > REMOVE STUDENT
                        Case "Remove Student"
                            command = "gam course " & courseID & " remove student " & user & ""
                        ' RUN > COURSES > SINGLE > ADD STUDENTS
                        Case "Add Students"
                            command = "gam csv " & Chr(34) & user & Chr(34) & " gam course " & courseID & " add student ~email"
                        ' RUN > COURSES > SINGLE > REMOVE STUDENTS
                        Case "Remove Students"
                            command = "gam csv " & Chr(34) & user & Chr(34) & " gam course " & courseID & " remove student ~email"
                    End Select
                ' RUN > COURSES > MULTIPLE
                Case "Multiple"
                    Select Case ComboBoxCoursesAction.SelectedItem?.ToString()
                        ' RUN > COURSES > MULIPLE > ARCHIVE
                        Case "Archive"
                            command = "gam csv " & Chr(34) & courseID & Chr(34) & " gam update course ~courseID state archived"
                        ' RUN > COURSES > MULIPLE > UNARCHIVE
                        Case "Unarchive"
                            command = "gam csv " & Chr(34) & courseID & Chr(34) & " gam update course ~courseID state active"
                        ' RUN > COURSES > MULIPLE > ASSIGN OWNER
                        Case "Assign Owner"
                            command = "gam csv " & Chr(34) & courseID & Chr(34) & " gam update course ~courseID owner " & user & ""
                        ' RUN > COURSES > MULIPLE > ADD TEACHER
                        Case "Add Teacher"
                            command = "gam csv " & Chr(34) & courseID & Chr(34) & " gam course ~courseID add teacher " & user & ""
                        ' RUN > COURSES > MULIPLE > ADD STUDENT
                        Case "Add Student"
                            command = "gam csv " & Chr(34) & courseID & Chr(34) & " gam course ~courseID add student " & user & ""
                        ' RUN > COURSES > MULIPLE > REMOVE TEACHER
                        Case "Remove Teacher"
                            command = "gam csv " & Chr(34) & courseID & Chr(34) & " gam course ~courseID remove teacher " & user & ""
                        ' RUN > COURSES > MULIPLE > REMOVE STUDENT
                        Case "Remove Student"
                            command = "gam csv " & Chr(34) & courseID & Chr(34) & " gam course ~courseID remove student " & user & ""
                    End Select
            End Select

            If command <> "" Then
                Try
                    ' Take snapshot & disable controls
                    SnapshotAndDisable(Me)

                    ' Run the GAM command in a background task
                    Dim output As String = Await Task.Run(Function()
                                                              Dim psi As New ProcessStartInfo() With {
                                                                  .FileName = "cmd.exe",
                                                                  .Arguments = "/c " & command,
                                                                  .RedirectStandardOutput = True,
                                                                  .UseShellExecute = False,
                                                                  .CreateNoWindow = True
                                                              }
                                                              Using proc As Process = Process.Start(psi)
                                                                  Using reader As IO.StreamReader = proc.StandardOutput
                                                                      Return reader.ReadToEnd()
                                                                  End Using
                                                              End Using
                                                          End Function)

                    ' Back on UI thread — update RichTextBox
                    RichTextBox1.Text = output
                Catch ex As Exception
                    RichTextBox1.Text = "Error running GAM: " & ex.Message
                Finally
                    ' Restore all original Enabled states
                    RestoreStates()
                End Try
            End If
            ' RUN > USER REPORT
        ElseIf TabControl1.SelectedTab Is TabPageUserReport Then
            Dim storageCombo As String = ComboBoxUserReportFiltersStorage.Text
            Dim storageText As String = TextBoxUserReportFiltersStorage.Text

            Dim lastLoginText As String = TextBoxUserReportFiltersLastLogin.Text
            Dim lastLoginCombo As String = ""
            If ComboBoxUserReportFiltersLastLogin.Text = ">" Then
                lastLoginCombo = "<"
            ElseIf ComboBoxUserReportFiltersLastLogin.Text = "<" Then
                lastLoginCombo = ">"
            End If

            Dim createdText As String = TextBoxUserReportFiltersCreated.Text
            Dim createdCombo As String = ""
            If ComboBoxUserReportFiltersCreated.Text = ">" Then
                createdCombo = "<"
            ElseIf ComboBoxUserReportFiltersCreated.Text = "<" Then
                createdCombo = ">"
            End If

            Dim fileName As String = "GAM_User_Report_" & DateTime.Now.ToString("yyyyMMdd_HHmm") & ".csv"
            Dim filePath As String = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), fileName)

            ' Start command and prepare parameter list
            Dim command As String = "gam report users"
            Dim parameters As New List(Of String)

            ' Add parameters based on checked boxes
            If CheckBoxUserReportAttributesName.Checked Then
                parameters.Add("accounts:first_name")
                parameters.Add("accounts:last_name")
            End If
            If CheckBoxUserReportAttributesSuspended.Checked Then
                parameters.Add("accounts:is_suspended")
            End If
            If CheckBoxUserReportAttributesArchived.Checked Then
                parameters.Add("accounts:is_archived")
            End If
            If CheckBoxUserReportAttributesLastLogin.Checked Then
                parameters.Add("accounts:last_login_time")
            End If
            If CheckBoxUserReportAttributesCreated.Checked Then
                parameters.Add("accounts:creation_time")
            End If
            If CheckBoxUserReportAttributesStorage.Checked Then
                parameters.Add("accounts:drive_used_quota_in_mb")
            End If

            ' Join all parameters with commas
            If parameters.Count > 0 Then
                command &= " parameters " & String.Join(",", parameters)
            End If

            If CheckBoxUserReportAttributesStorage.Checked Then
                command &= " convertmbtogb"
            End If

            Dim filters As New List(Of String)

            ' Add filters based on checked boxes
            If CheckBoxUserReportFiltersSuspended.Checked Then
                filters.Add("accounts:is_suspended==" & ComboBoxUserReportFiltersSuspended.Text)
            End If
            If CheckBoxUserReportFiltersArchived.Checked Then
                filters.Add("accounts:is_archived==" & ComboBoxUserReportFiltersArchived.Text)
            End If
            If CheckBoxUserReportFiltersStorage.Checked Then
                If storageCombo = "=" Then
                    storageCombo = "=="
                End If
                storageText &= "000"
                filters.Add("accounts:drive_used_quota_in_mb" & storageCombo & storageText)
            End If
            If CheckBoxUserReportFiltersLastLogin.Checked Then
                filters.Add("accounts:last_login_time" & lastLoginCombo & "#filtertimelogin#")
            ElseIf CheckBoxUserReportFiltersNeverLoggedIn.Checked Then
                filters.Add("accounts:last_login_time==#filtertimenever#")
            End If
            If CheckBoxUserReportFiltersCreated.Checked Then
                filters.Add("accounts:creation_time" & createdCombo & "#filtertimecreated#")
            End If

            ' Append to command if any filters exist
            If filters.Count > 0 Then
                command &= " filters " & Chr(34) & String.Join(",", filters) & Chr(34)
            End If

            If CheckBoxUserReportFiltersLastLogin.Checked Then
                command &= " filtertimelogin -" & lastLoginText & "y"
            ElseIf CheckBoxUserReportFiltersNeverLoggedIn.Checked Then
                command &= " filtertimenever never"
            End If

            If CheckBoxUserReportFiltersCreated.Checked Then
                command &= " filtertimecreated -" & createdText & "y"
            End If

            ' Append output redirect
            command &= " > """ & filePath & """"

            If command <> "" Then
                Try
                    ' Show where the file will be exported to
                    RichTextBox1.Text = filePath

                    ' Run the GAM command in a new window
                    Process.Start("CMD", "/K" & command & "")
                Catch ex As Exception
                    RichTextBox1.Text = "Error running GAM: " & ex.Message
                End Try
            End If
        End If
    End Sub

    Private Sub ButtonShowCommand_Click(sender As Object, e As EventArgs) Handles ButtonShowCommand.Click
        ' SHOW COMMAND > DEVICES
        If TabControl1.SelectedTab Is TabPageDevices Then
            Dim device As String = TextBoxDevicesTarget.Text
            Dim destination As String = ComboBoxDevicesDestination.Text
            Dim command As String = ""

            ' SHOW COMMAND > DEVICES > SINGLE > GET INFO
            If ComboBoxDevicesScope.SelectedItem = "Single" AndAlso ComboBoxDevicesAction.SelectedItem = "Get Info" Then
                Select Case ComboBoxDevicesTargetType.SelectedItem?.ToString()
                    Case "Asset ID"
                        command = "gam cros_query asset_id:" & device & " info | findstr " & Chr(34) &
                              "macAddress serialNumber lastSync ipAddress wanIpAddress email: osVersion autoUpdateExpiration orgUnitPath annotatedAssetId" & Chr(34)

                    Case "Serial Number"
                        command = "gam cros_sn " & device & " info | findstr " & Chr(34) &
                              "macAddress serialNumber lastSync ipAddress wanIpAddress email: osVersion autoUpdateExpiration orgUnitPath annotatedAssetId" & Chr(34)

                    Case "MAC Address"
                        command = "gam info cros query:wifi_mac:" & device & " | findstr " & Chr(34) &
                              "macAddress serialNumber lastSync ipAddress wanIpAddress email: osVersion autoUpdateExpiration orgUnitPath annotatedAssetId" & Chr(34)
                End Select
                ' SHOW COMMAND > DEVICES > SINGLE > MOVE
            ElseIf ComboBoxDevicesScope.SelectedItem = "Single" AndAlso ComboBoxDevicesAction.SelectedItem = "Move" Then
                Select Case ComboBoxDevicesTargetType.SelectedItem?.ToString()
                    Case "Asset ID"
                        command = "gam update cros query:asset_id:" & device & " ou " & Chr(34) & destination & Chr(34)
                    Case "Serial Number"
                        command = "gam update cros query:id:" & device & " ou " & Chr(34) & destination & Chr(34)
                    Case "MAC Address"
                        command = "gam update cros query:wifi_mac:" & device & " ou " & Chr(34) & destination & Chr(34)
                End Select
                ' SHOW COMMAND > DEVICES > SINGLE > ENABLE
            ElseIf ComboBoxDevicesScope.SelectedItem = "Single" AndAlso ComboBoxDevicesAction.SelectedItem = "Enable" Then
                Select Case ComboBoxDevicesTargetType.SelectedItem?.ToString()
                    Case "Asset ID"
                        command = "gam update cros query:asset_id:" & device & " action reenable"
                    Case "Serial Number"
                        command = "gam update cros cros_sn " & device & " action reenable"
                    Case "MAC Address"
                        command = "gam update cros query:wifi_mac:" & device & " action reenable"
                End Select
                ' SHOW COMMAND > DEVICES > SINGLE > DISABLE
            ElseIf ComboBoxDevicesScope.SelectedItem = "Single" AndAlso ComboBoxDevicesAction.SelectedItem = "Disable" Then
                Select Case ComboBoxDevicesTargetType.SelectedItem?.ToString()
                    Case "Asset ID"
                        command = "gam update cros query:asset_id:" & device & " action disable"
                    Case "Serial Number"
                        command = "gam update cros cros_sn " & device & " action disable"
                    Case "MAC Address"
                        command = "gam update cros query:wifi_mac:" & device & " action disable"
                End Select
                ' SHOW COMMAND > DEVICES > SINGLE > CLEAR PROFILES
            ElseIf ComboBoxDevicesScope.SelectedItem = "Single" AndAlso ComboBoxDevicesAction.SelectedItem = "Clear Profiles" Then
                Select Case ComboBoxDevicesTargetType.SelectedItem?.ToString()
                    Case "Asset ID"
                        command = "gam issuecommand cros query:asset_id:" & device & " command wipe_users doit"
                    Case "Serial Number"
                        command = "gam issuecommand cros query:id:" & device & " command wipe_users doit"
                    Case "MAC Address"
                        command = "gam issuecommand cros query:wifi_mac:" & device & " command wipe_users doit"
                End Select
                ' SHOW COMMAND > DEVICES > SINGLE > POWERWASH
            ElseIf ComboBoxDevicesScope.SelectedItem = "Single" AndAlso ComboBoxDevicesAction.SelectedItem = "Powerwash" Then
                Select Case ComboBoxDevicesTargetType.SelectedItem?.ToString()
                    Case "Asset ID"
                        command = "gam issuecommand cros query:asset_id:" & device & " command remote_powerwash times_to_check_status 10 doit"
                    Case "Serial Number"
                        command = "gam issuecommand cros query:id:" & device & " command remote_powerwash times_to_check_status 10 doit"
                    Case "MAC Address"
                        command = "gam issuecommand cros query:wifi_mac:" & device & " command remote_powerwash times_to_check_status 10 doit"
                End Select
                ' SHOW COMMAND > DEVICES > SINGLE > DEPROVISION
            ElseIf ComboBoxDevicesScope.SelectedItem = "Single" AndAlso ComboBoxDevicesAction.SelectedItem = "Deprovision" Then
                Select Case ComboBoxDevicesTargetType.SelectedItem?.ToString()
                    Case "Asset ID"
                        command = "gam update cros query:asset_id:" & device & " action deprovision_retiring_device acknowledge_device_touch_requirement"
                    Case "Serial Number"
                        command = "gam update cros query:id:" & device & " action deprovision_retiring_device acknowledge_device_touch_requirement"
                    Case "MAC Address"
                        command = "gam update cros query:wifi_mac:" & device & " action deprovision_retiring_device acknowledge_device_touch_requirement"
                End Select
                ' SHOW COMMAND > DEVICES > MULTIPLE
            ElseIf ComboBoxDevicesScope.SelectedItem = "Multiple" Then
                Select Case ComboBoxDevicesAction.SelectedItem?.ToString()
                    ' SHOW COMMAND > DEVICES > MULTIPLE > MOVE
                    Case "Move"
                        command = "gam csv " & Chr(34) & device & Chr(34) & " gam update cros query:asset_id:~~assetid~~ ou " & Chr(34) & destination & Chr(34) & ""
                    ' SHOW COMMAND > DEVICES > MULTIPLE > ENABLE
                    Case "Enable"
                        command = "gam csv " & Chr(34) & device & Chr(34) & " gam update cros query:asset_id:~~assetid~~ action reenable"
                    ' SHOW COMMAND > DEVICES > MULTIPLE > DISABLE
                    Case "Disable"
                        command = "gam csv " & Chr(34) & device & Chr(34) & " gam update cros query:asset_id:~~assetid~~ action disable"
                    ' SHOW COMMAND > DEVICES > MULTIPLE > CLEAR PROFILES
                    Case "Clear Profiles"
                        command = "gam csv " & Chr(34) & device & Chr(34) & " gam issuecommand cros query:asset_id:~~assetid~~ command wipe_users doit"
                   ' SHOW COMMAND > DEVICES > MULTIPLE > POWERWASH
                    Case "Powerwash"
                        command = "gam csv " & Chr(34) & device & Chr(34) & " gam issuecommand cros query:asset_id:~~assetid~~ command remote_powerwash times_to_check_status 10 doit"
                   ' SHOW COMMAND > DEVICES > MULTIPLE > DEPROVISION
                    Case "Deprovision"
                        command = "gam csv " & Chr(34) & device & Chr(34) & " gam update cros query:asset_id:~~assetid~~ action deprovision_retiring_device acknowledge_device_touch_requirement"
                End Select
            End If


            ' Show the command
            If command <> "" Then
                RichTextBox1.Text = command
            End If
            ' SHOW COMMAND > USERS
        ElseIf TabControl1.SelectedTab Is TabPageUsers Then
            Dim user As String = TextBoxUsersTarget.Text
            Dim group As String = ComboBoxUsersGroupDestination.Text
            Dim destination As String = ComboBoxUsersDestination.Text
            Dim target As String = TextBoxUsersTarget.Text
            Dim targetOU As String = ComboBoxUsersTarget.Text
            Dim filePath As String = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), user & ".csv")
            Dim command As String = ""

            ' SHOW COMMAND > USERS > USER
            If ComboBoxUsersScope.SelectedItem = "User" Then
                Select Case ComboBoxUsersAction.SelectedItem?.ToString()
                    ' SHOW COMMAND > USERS > USER > GET INFO
                    Case "Get Info"
                        command = "gam info user " & user & " | findstr " & Chr(34) & "Full login Creation Archived Path location title Account" & Chr(34) _
                                  & " && echo. && echo GOOGLE CLASSROOMS - TEACHER && gam print courses teacher " & user & " fields coursestate,name,id" _
                                  & " && echo. && echo GOOGLE CLASSROOMS - STUDENT && gam print courses student " & user & " fields coursestate,name,id" _
                                  & " && echo. && echo GROUPS && gam print groups member " & user & " fields description"
                    ' SHOW COMMAND > USERS > USER > RECENT DEVICES
                    Case "Recent Devices"
                        command = "gam print cros query recent_user:" & user & " serialnumber assetid"
                    ' SHOW COMMAND > USERS > USER > SHOW FILES
                    Case "Show Files"
                        command = "gam user " & user & " print filetree fields id,trashed,explicitlytrashed,size,mimetype,owners,parents > """ & filePath & """"
                    ' SHOW COMMAND > USERS > USER > MOVE
                    Case "Move"
                        command = "gam update user " & user & " org " & Chr(34) & destination & Chr(34) & ""
                    ' SHOW COMMAND > USERS > USER > ENABLE
                    Case "Enable"
                        command = "gam update user " & user & " suspended off"
                    ' SHOW COMMAND > USERS > USER > SUSPEND
                    Case "Suspend"
                        command = "gam update user " & user & " suspended on"
                    ' SHOW COMMAND > USERS > USER > ARCHIVE
                    Case "Archive"
                        command = "gam update user " & user & " archived on"
                    ' SHOW COMMAND > USERS > USER > UNARCHIVE
                    Case "Unarchive"
                        command = "gam update user " & user & " archived off"
                    ' SHOW COMMAND > USERS > USER > ADD TO GROUP
                    Case "Add to Group"
                        command = "gam user " & user & " add group " & group & ""
                    ' SHOW COMMAND > USERS > USER > REMOVE FROM GROUP
                    Case "Remove from Group"
                        command = "gam user " & user & " delete group " & group & ""
                End Select
                ' SHOW COMMAND > USERS > USERS
            ElseIf ComboBoxUsersScope.SelectedItem = "Users" Then
                Select Case ComboBoxUsersAction.SelectedItem?.ToString()
                    ' SHOW COMMAND > USERS > USERS > MOVE
                    Case "Move"
                        command = "gam csv " & Chr(34) & user & Chr(34) & " gam update user ~email org " & Chr(34) & destination & Chr(34)
                    ' SHOW COMMAND > USERS > USERS > ENABLE
                    Case "Enable"
                        command = "gam csv " & Chr(34) & user & Chr(34) & " gam update user ~email suspended off"
                    ' SHOW COMMAND > USERS > USERS > SUSPEND
                    Case "Suspend"
                        command = "gam csv " & Chr(34) & user & Chr(34) & " gam update user ~email suspended on"
                    ' SHOW COMMAND > USERS > USERS > ARCHIVE
                    Case "Archive"
                        command = "gam csv " & user & " gam update user ~email archived on"
                    ' SHOW COMMAND > USERS > USERS > UNARCHIVE
                    Case "Unarchive"
                        command = "gam csv " & user & " gam update user ~email archived off"
                    ' SHOW COMMAND > USERS > USERS > ADD TO GROUP
                    Case "Add to Group"
                        command = "gam csv " & Chr(34) & user & Chr(34) & " gam user ~email add group " & group & ""
                    ' SHOW COMMAND > USERS > USERS > REMOVE FROM GROUP
                    Case "Remove from Group"
                        command = "gam csv " & Chr(34) & user & Chr(34) & " gam user ~email delete group " & group & ""
                End Select
                ' SHOW COMMAND > USERS > OU
            ElseIf ComboBoxUsersScope.SelectedItem = "OU" Then
                Select Case ComboBoxUsersAction.SelectedItem?.ToString()
                    ' SHOW COMMAND > USERS > OU > GET INFO
                    Case "Get Info"
                        'command = "gam info org " & Chr(34) & targetOU & Chr(34) & ""
                        command = "gam print users query " & Chr(34) & "orgUnitPath='" & targetOU & "'" & Chr(34) & " fields primaryEmail,first_name,last_name,archived,suspended,creationTime,lastLoginTime"
                    ' SHOW COMMAND > USERS > OU > MOVE
                    Case "Move"
                        command = "gam org " & Chr(34) & targetOU & Chr(34) & " update user org " & Chr(34) & destination & Chr(34) & ""
                End Select
            End If

            ' Show the command
            If command <> "" Then
                RichTextBox1.Text = command
            End If
        ElseIf TabControl1.SelectedTab Is TabPageFiles Then
            ' SHOW COMMAND > FILES
            Dim documentID As String = TextBoxFilesDocumentID.Text
            Dim userWithAccess As String = TextBoxFilesUserWithAccess.Text
            Dim targetUser As String = TextBoxFilesTargetUser.Text
            Dim command As String = ""

            Select Case ComboBoxFilesAction.SelectedItem?.ToString()
                ' SHOW COMMAND > FILES > GET INFO
                Case "Get Info"
                    command = "gam user " & userWithAccess & " show fileinfo " & documentID & " filepath | findstr " & Chr(34) & "path: createdTime lastModifyingUser: displayName: emailAddress: modifiedTime: role: writersCanShare: Permissions: trashed: explicitlyTrashed:" & Chr(34) & ""
                ' SHOW COMMAND > FILES > UNTRASH
                Case "Untrash"
                    command = "gam user " & userWithAccess & " untrash drivefile " & documentID & ""
                ' SHOW COMMAND > FILES > ASSIGN OWNER
                Case "Assign Owner"
                    command = "gam user " & userWithAccess & " add drivefileacl " & documentID & " user " & targetUser & " role owner”
                ' SHOW COMMAND > FILES > ADD EDITOR
                Case "Add Editor"
                    command = "gam user " & userWithAccess & " add drivefileacl " & documentID & " user " & targetUser & " role editor”
                ' SHOW COMMAND > FILES > ADD READER
                Case "Add Reader"
                    command = "gam user " & userWithAccess & " add drivefileacl " & documentID & " user " & targetUser & " role reader”
                ' SHOW COMMAND > FILES > REMOVE ACCESS
                Case "Remove Access"
                    command = "gam user " & userWithAccess & " delete drivefileacl " & documentID & " " & targetUser & ""
            End Select

            ' Show the command
            If command <> "" Then
                RichTextBox1.Text = command
            End If
            ' SHOW COMMAND > DATA TRANSFER
        ElseIf TabControl1.SelectedTab Is TabPageDataTransfer Then
            Dim documentID As String = TextBoxDataTransferDocumentID.Text
            Dim sourceUser As String = TextBoxDataTransferSourceUser.Text
            Dim destinationUser As String = TextBoxDataTransferDestinationUser.Text
            Dim retainRole As String = ComboBoxDataTransferSourceUserRetainRole.Text
            Dim retainRoleShared As String = ComboBoxDataTransferSourceUserRetainRoleShared.Text
            Dim gainRoleShared As String = ComboBoxDataTransferDestinationUserGainRoleShared.Text
            Dim command As String = ""

            Select Case ComboBoxDataTransferScope.SelectedItem?.ToString()
                ' SHOW COMMAND > DATA TRANSFER > ALL
                Case "All"
                    command = "gam user " & sourceUser & " transfer drive " & destinationUser & " retainrole " & retainRole & " nonowner_retainrole " & retainRoleShared & " nonowner_targetrole " & gainRoleShared & ""
                ' SHOW COMMAND > DATA TRANSFER > FOLDER
                Case "Folder"
                    command = "gam user " & sourceUser & " transfer drive " & destinationUser & " select " & documentID & " retainrole " & retainRole & ""
                ' SHOW COMMAND > DATA TRANSFER > ALL BUT FOLDER
                Case "All But Folder"
                    command = "gam user " & sourceUser & " transfer drive " & destinationUser & " skipids " & documentID & " retainrole " & retainRole & " nonowner_retainrole " & retainRoleShared & " nonowner_targetrole " & gainRoleShared & "”
            End Select

            ' Show the command
            If command <> "" Then
                RichTextBox1.Text = command
            End If
            ' SHOW COMMAND > COURSES
        ElseIf TabControl1.SelectedTab Is TabPageCourses Then
            Dim courseID As String = TextBoxCoursesCourseID.Text
            Dim user As String = TextBoxCoursesUser.Text
            Dim command As String = ""

            Select Case ComboBoxCoursesScope.SelectedItem?.ToString()
                ' SHOW COMMAND > COURSES > SINGLE
                Case "Single"
                    Select Case ComboBoxCoursesAction.SelectedItem?.ToString()
                        ' SHOW COMMAND > COURSES > SINGLE > GET INFO
                        Case "Get Info"
                            command = "gam info course " & courseID & ""
                        ' SHOW COMMAND > COURSES > SINGLE > SHOW MEMBERS
                        Case "Show Members"
                            command = "echo GOOGLE CLASSROOM - TEACHER && gam config csv_output_header_filter courseId,courseName,profile.emailAddress print course-participants course " & courseID & " show teachers" _
                                  & " && echo. && echo GOOGLE CLASSROOM - STUDENT && gam config csv_output_header_filter courseId,courseName,profile.emailAddress print course-participants course " & courseID & " show students"
                        ' SHOW COMMAND > COURSES > SINGLE > ARCHIVE
                        Case "Archive"
                            command = "gam update course " & courseID & " state archived"
                        ' SHOW COMMAND > COURSES > SINGLE > UNARCHIVE
                        Case "Unarchive"
                            command = "gam update course " & courseID & " state active"
                        ' SHOW COMMAND > COURSES > SINGLE > ASSIGN OWNER
                        Case "Assign Owner"
                            command = "gam update course " & courseID & " owner " & user & ""
                        ' SHOW COMMAND > COURSES > SINGLE > ADD TEACHER
                        Case "Add Teacher"
                            command = "gam course " & courseID & " add teacher " & user & ""
                        ' SHOW COMMAND > COURSES > SINGLE > ADD STUDENT
                        Case "Add Student"
                            command = "gam course " & courseID & " add student " & user & ""
                        ' SHOW COMMAND > COURSES > SINGLE > REMOVE TEACHER
                        Case "Remove Teacher"
                            command = "gam course " & courseID & " remove teacher " & user & ""
                        ' SHOW COMMAND > COURSES > SINGLE > REMOVE STUDENT
                        Case "Remove Student"
                            command = "gam course " & courseID & " remove student " & user & ""
                        ' SHOW COMMAND > COURSES > SINGLE > ADD STUDENTS
                        Case "Add Students"
                            command = "gam csv " & Chr(34) & user & Chr(34) & " gam course " & courseID & " add student ~email"
                        ' SHOW COMMAND > COURSES > SINGLE > REMOVE STUDENTS
                        Case "Remove Students"
                            command = "gam csv " & Chr(34) & user & Chr(34) & " gam course " & courseID & " remove student ~email"
                    End Select
                ' SHOW COMMAND > COURSES > MULTIPLE
                Case "Multiple"
                    Select Case ComboBoxCoursesAction.SelectedItem?.ToString()
                        ' SHOW COMMAND > COURSES > MULIPLE > ARCHIVE
                        Case "Archive"
                            command = "gam csv " & Chr(34) & courseID & Chr(34) & " gam update course ~courseID state archived"
                        ' SHOW COMMAND > COURSES > MULIPLE > UNARCHIVE
                        Case "Unarchive"
                            command = "gam csv " & Chr(34) & courseID & Chr(34) & " gam update course ~courseID state active"
                        ' SHOW COMMAND > COURSES > MULIPLE > ASSIGN OWNER
                        Case "Assign Owner"
                            command = "gam csv " & Chr(34) & courseID & Chr(34) & " gam update course ~courseID " & user & ""
                        ' SHOW COMMAND > COURSES > MULIPLE > ADD TEACHER
                        Case "Add Teacher"
                            command = "gam csv " & Chr(34) & courseID & Chr(34) & " gam course ~courseID add teacher " & user & ""
                        ' SHOW COMMAND > COURSES > MULIPLE > ADD STUDENT
                        Case "Add Student"
                            command = "gam csv " & Chr(34) & courseID & Chr(34) & " gam course ~courseID add student " & user & ""
                        ' SHOW COMMAND > COURSES > MULIPLE > REMOVE TEACHER
                        Case "Remove Teacher"
                            command = "gam csv " & Chr(34) & courseID & Chr(34) & " gam course ~courseID remove teacher " & user & ""
                        ' SHOW COMMAND > COURSES > MULIPLE > REMOVE STUDENT
                        Case "Remove Student"
                            command = "gam csv " & Chr(34) & courseID & Chr(34) & " gam course ~courseID remove teacher " & user & ""
                    End Select
            End Select

            ' Show the command
            If command <> "" Then
                RichTextBox1.Text = command
            End If
            ' SHOW COMMAND > USER REPORT
        ElseIf TabControl1.SelectedTab Is TabPageUserReport Then
            Dim storageCombo As String = ComboBoxUserReportFiltersStorage.Text
            Dim storageText As String = TextBoxUserReportFiltersStorage.Text

            Dim lastLoginText As String = TextBoxUserReportFiltersLastLogin.Text
            Dim lastLoginCombo As String = ""
            If ComboBoxUserReportFiltersLastLogin.Text = ">" Then
                lastLoginCombo = "<"
            ElseIf ComboBoxUserReportFiltersLastLogin.Text = "<" Then
                lastLoginCombo = ">"
            End If

            Dim createdText As String = TextBoxUserReportFiltersCreated.Text
            Dim createdCombo As String = ""
            If ComboBoxUserReportFiltersCreated.Text = ">" Then
                createdCombo = "<"
            ElseIf ComboBoxUserReportFiltersCreated.Text = "<" Then
                createdCombo = ">"
            End If

            Dim fileName As String = "GAM_User_Report_" & DateTime.Now.ToString("yyyyMMdd_HHmm") & ".csv"
            Dim filePath As String = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), fileName)

            ' Start command and prepare parameter list
            Dim command As String = "gam report users"
            Dim parameters As New List(Of String)

            ' Add parameters based on checked boxes
            If CheckBoxUserReportAttributesName.Checked Then
                parameters.Add("accounts:first_name")
                parameters.Add("accounts:last_name")
            End If
            If CheckBoxUserReportAttributesSuspended.Checked Then
                parameters.Add("accounts:is_suspended")
            End If
            If CheckBoxUserReportAttributesArchived.Checked Then
                parameters.Add("accounts:is_archived")
            End If
            If CheckBoxUserReportAttributesLastLogin.Checked Then
                parameters.Add("accounts:last_login_time")
            End If
            If CheckBoxUserReportAttributesCreated.Checked Then
                parameters.Add("accounts:creation_time")
            End If
            If CheckBoxUserReportAttributesStorage.Checked Then
                parameters.Add("accounts:drive_used_quota_in_mb")
            End If

            ' Join all parameters with commas
            If parameters.Count > 0 Then
                command &= " parameters " & String.Join(",", parameters)
            End If

            If CheckBoxUserReportAttributesStorage.Checked Then
                command &= " convertmbtogb"
            End If

            Dim filters As New List(Of String)

            ' Add filters based on checked boxes
            If CheckBoxUserReportFiltersSuspended.Checked Then
                filters.Add("accounts:is_suspended==" & ComboBoxUserReportFiltersSuspended.Text)
            End If
            If CheckBoxUserReportFiltersArchived.Checked Then
                filters.Add("accounts:is_archived==" & ComboBoxUserReportFiltersArchived.Text)
            End If
            If CheckBoxUserReportFiltersStorage.Checked Then
                If storageCombo = "=" Then
                    storageCombo = "=="
                End If
                storageText &= "000"
                filters.Add("accounts:drive_used_quota_in_mb" & storageCombo & storageText)
            End If
            If CheckBoxUserReportFiltersLastLogin.Checked Then
                filters.Add("accounts:last_login_time" & lastLoginCombo & "#filtertimelogin#")
            ElseIf CheckBoxUserReportFiltersNeverLoggedIn.Checked Then
                filters.Add("accounts:last_login_time==#filtertimenever#")
            End If
            If CheckBoxUserReportFiltersCreated.Checked Then
                filters.Add("accounts:creation_time" & createdCombo & "#filtertimecreated#")
            End If

            ' Append to command if any filters exist
            If filters.Count > 0 Then
                command &= " filters " & Chr(34) & String.Join(",", filters) & Chr(34)
            End If

            If CheckBoxUserReportFiltersLastLogin.Checked Then
                command &= " filtertimelogin -" & lastLoginText & "y"
            ElseIf CheckBoxUserReportFiltersNeverLoggedIn.Checked Then
                command &= " filtertimenever never"
            End If

            If CheckBoxUserReportFiltersCreated.Checked Then
                command &= " filtertimecreated -" & createdText & "y"
            End If

            ' Append output redirect
            command &= " > """ & filePath & """"

            ' Show the command
            If command <> "" Then
                    RichTextBox1.Text = command
                End If
            End If
    End Sub

    Private Sub ButtonOutputCopy_Click(sender As Object, e As EventArgs) Handles ButtonCopy.Click
        If Not String.IsNullOrEmpty(RichTextBox1.Text) Then
            Clipboard.SetText(RichTextBox1.Text)
        End If
    End Sub

    Private Async Sub ButtonFind_Click(sender As Object, e As EventArgs) Handles ButtonFind.Click
        Dim searchText As String = TextBoxFind.Text.Trim()
        If searchText = "" Then
            RichTextBox1.Text = "Enter a search term."
            Return
        End If

        ' FIND OU
        If ComboBoxFind.SelectedItem = "OU" Then
            ' Run OU search in a background task
            Dim results As List(Of String) = Await Task.Run(Function()
                                                                Dim matches As New List(Of String)
                                                                For Each ou As String In OrgUnitPaths
                                                                    If ou.IndexOf(searchText, StringComparison.OrdinalIgnoreCase) >= 0 Then
                                                                        matches.Add(ou)
                                                                    End If
                                                                Next
                                                                Return matches
                                                            End Function)

            ' Update RichTextBox on UI thread
            If results.Count > 0 Then
                RichTextBox1.Text = String.Join(Environment.NewLine, results)
            Else
                RichTextBox1.Text = "No matches found For: " & searchText
            End If

            ' FIND USER
        ElseIf ComboBoxFind.SelectedItem = "User" Then
            Dim query As String = If(searchText.Contains("@"), "email:" & searchText, "name:" & searchText)

            Try
                ' Run GAM process in background to avoid freezing
                Dim output As String = Await Task.Run(Function()
                                                          Dim psi As New ProcessStartInfo() With {
                                                         .FileName = "cmd.exe",
                                                         .Arguments = "/c gam print users query """ & query & """ fields primaryEmail,fullname",
                                                         .RedirectStandardOutput = True,
                                                         .UseShellExecute = False,
                                                         .CreateNoWindow = True
                                                     }

                                                          Using proc As Process = Process.Start(psi)
                                                              Using reader As IO.StreamReader = proc.StandardOutput
                                                                  Return reader.ReadToEnd()
                                                              End Using
                                                          End Using
                                                      End Function)

                ' Update RichTextBox on UI thread
                If Not String.IsNullOrWhiteSpace(output) Then
                    RichTextBox1.Text = output.Trim()
                Else
                    RichTextBox1.Text = "No users found matching: " & searchText
                End If

            Catch ex As Exception
                RichTextBox1.Text = "Error running GAM: " & ex.Message
            End Try
            ' FIND FILE
        ElseIf ComboBoxFind.SelectedItem = "File" Then
            Dim docName As String = TextBoxFind.Text.Trim()
            If docName = "" Then
                MessageBox.Show("Enter a search keyword for the file.")
                Return
            End If

            ' Prompt for a user who likely has access to the file
            Dim user As String = InputBox("Enter the email of a user who has access to the file:", "User Required")
            If String.IsNullOrWhiteSpace(user) Then
                RichTextBox1.Text = "No user entered. Cannot search for files without a user."
                Return
            End If

            Try
                ' Run GAM command in background to avoid freezing UI
                Dim output As String = Await Task.Run(Function()
                                                          Dim psi As New ProcessStartInfo() With {
                                                     .FileName = "cmd.exe",
                                                     .Arguments = "/c gam user " & user & " show filelist query " &
                                                                   Chr(34) & "fullText contains " & Chr(39) & docName & Chr(39) & Chr(34) &
                                                                   " title id",
                                                     .RedirectStandardOutput = True,
                                                     .UseShellExecute = False,
                                                     .CreateNoWindow = True
                                                 }

                                                          Using proc As Process = Process.Start(psi)
                                                              Using reader As IO.StreamReader = proc.StandardOutput
                                                                  Return reader.ReadToEnd()
                                                              End Using
                                                          End Using
                                                      End Function)

                ' Display results in RichTextBox
                If String.IsNullOrWhiteSpace(output) Then
                    RichTextBox1.Text = $"No files found for '{docName}' for user {user}."
                Else
                    RichTextBox1.Text = output
                End If

            Catch ex As Exception
                RichTextBox1.Text = "Error running GAM: " & ex.Message
            End Try
            ' FIND GROUP
        ElseIf ComboBoxFind.SelectedItem = "Group" Then
            ' Run group search in a background task
            Dim results As List(Of String) = Await Task.Run(Function()
                                                                Dim matches As New List(Of String)
                                                                For Each group As String In groupList
                                                                    If group.IndexOf(searchText, StringComparison.OrdinalIgnoreCase) >= 0 Then
                                                                        matches.Add(group)
                                                                    End If
                                                                Next
                                                                Return matches
                                                                End Function)

            ' Update RichTextBox on UI thread
            If results.Count > 0 Then
                RichTextBox1.Text = String.Join(Environment.NewLine, results)
            Else
                RichTextBox1.Text = "No matches found For: " & searchText
            End If
        End If
    End Sub

    Private Sub ComboBoxUsersScope_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBoxUsersScope.SelectedIndexChanged
        Dim scope = ComboBoxUsersScope.SelectedItem?.ToString()

        ' Always remove Get Info
        If ComboBoxUsersAction.Items.Contains("Get Info") AndAlso Not scope = "User" Then
            ComboBoxUsersAction.Items.Remove("Get Info")
        End If

        ' Always remove Recent Devices
        If ComboBoxUsersAction.Items.Contains("Recent Devices") AndAlso Not scope = "User" Then
            ComboBoxUsersAction.Items.Remove("Recent Devices")
        End If

        ' Always remove Show Files
        If ComboBoxUsersAction.Items.Contains("Show Files") AndAlso Not scope = "User" Then
            ComboBoxUsersAction.Items.Remove("Show Files")
        End If

        ' Always remove Add to Group
        If ComboBoxUsersAction.Items.Contains("Add to Group") AndAlso Not scope = "User" AndAlso Not scope = "Users" Then
            ComboBoxUsersAction.Items.Remove("Add to Group")
        End If

        ' Always remove Remove from Group
        If ComboBoxUsersAction.Items.Contains("Remove from Group") AndAlso Not scope = "User" AndAlso Not scope = "Users" Then
            ComboBoxUsersAction.Items.Remove("Remove from Group")
        End If

        If scope = "User" Then
            ' Action combo box
            If Not ComboBoxUsersAction.Items.Contains("Get Info") Then
                ComboBoxUsersAction.Items.Insert(0, "Get Info")
            End If
            If Not ComboBoxUsersAction.Items.Contains("Recent Devices") Then
                ComboBoxUsersAction.Items.Insert(1, "Recent Devices")
            End If
            If Not ComboBoxUsersAction.Items.Contains("Show Files") Then
                ComboBoxUsersAction.Items.Insert(2, "Show Files")
            End If
            If Not ComboBoxUsersAction.Items.Contains("Move") Then
                ComboBoxUsersAction.Items.Insert(3, "Move")
            End If
            If Not ComboBoxUsersAction.Items.Contains("Enable") Then
                ComboBoxUsersAction.Items.Insert(4, "Enable")
            End If
            If Not ComboBoxUsersAction.Items.Contains("Suspend") Then
                ComboBoxUsersAction.Items.Insert(5, "Suspend")
            End If
            If Not ComboBoxUsersAction.Items.Contains("Archive") Then
                ComboBoxUsersAction.Items.Insert(6, "Archive")
            End If
            If Not ComboBoxUsersAction.Items.Contains("Unarchive") Then
                ComboBoxUsersAction.Items.Insert(7, "Unarchive")
            End If
            If Not ComboBoxUsersAction.Items.Contains("Add to Group") Then
                ComboBoxUsersAction.Items.Insert(8, "Add to Group")
            End If
            If Not ComboBoxUsersAction.Items.Contains("Remove from Group") Then
                ComboBoxUsersAction.Items.Insert(9, "Remove from Group")
            End If

            If ComboBoxUsersAction.SelectedItem = "" Then
                ComboBoxUsersAction.SelectedItem = "Get Info"
            End If

            ' Target text box
            TextBoxUsersTarget.Visible = True
            TextBoxUsersTarget.Text = ""
            ButtonUsersTargetSearch.Visible = False
            ButtonUsersTargetEdit.Visible = False
            TextBoxUsersTarget.Size = New Size(487, 23)

            ' Target combo box
            ComboBoxUsersTarget.Visible = False

        ElseIf scope = "Users" Then
            ' Action combo box
            If ComboBoxUsersAction.Items.Contains("Get Info") Then
                ComboBoxUsersAction.Items.Remove("Get Info")
            End If
            If ComboBoxUsersAction.Items.Contains("Recent Devices") Then
                ComboBoxUsersAction.Items.Remove("Recent Devices")
            End If

            If Not ComboBoxUsersAction.Items.Contains("Move") Then
                ComboBoxUsersAction.Items.Insert(0, "Move")
            End If
            If Not ComboBoxUsersAction.Items.Contains("Enable") Then
                ComboBoxUsersAction.Items.Insert(1, "Enable")
            End If
            If Not ComboBoxUsersAction.Items.Contains("Suspend") Then
                ComboBoxUsersAction.Items.Insert(2, "Suspend")
            End If
            If Not ComboBoxUsersAction.Items.Contains("Archive") Then
                ComboBoxUsersAction.Items.Insert(3, "Archive")
            End If
            If Not ComboBoxUsersAction.Items.Contains("Unarchive") Then
                ComboBoxUsersAction.Items.Insert(4, "Unarchive")
            End If
            If Not ComboBoxUsersAction.Items.Contains("Add to Group") Then
                ComboBoxUsersAction.Items.Insert(5, "Add to Group")
            End If
            If Not ComboBoxUsersAction.Items.Contains("Remove from Group") Then
                ComboBoxUsersAction.Items.Insert(6, "Remove from Group")
            End If

            If ComboBoxUsersAction.SelectedItem = "" Then
                ComboBoxUsersAction.SelectedItem = "Move"
            End If

            ' Target text box
            TextBoxUsersTarget.Visible = True
            If IO.File.Exists("C:\GAMWork\users.csv") Then
                TextBoxUsersTarget.Text = "C:\GAMWork\users.csv"
            Else
                TextBoxUsersTarget.Text = ""
            End If
            ButtonUsersTargetSearch.Visible = True
            ButtonUsersTargetEdit.Visible = True
            TextBoxUsersTarget.Size = New Size(428, 23)

            ' Target combo box
            ComboBoxUsersTarget.Visible = False

            ' Clear previous text
            RichTextBox1.Clear()
            ' Append normal text
            RichTextBox1.AppendText("The CSV file must use ")
            ' Append bold text
            Dim start As Integer = RichTextBox1.TextLength
            RichTextBox1.AppendText("email")
            RichTextBox1.Select(start, "email".Length)
            RichTextBox1.SelectionFont = New Font(RichTextBox1.Font, FontStyle.Bold)
            ' Reset font to normal and append the rest
            RichTextBox1.SelectionStart = RichTextBox1.TextLength
            RichTextBox1.SelectionLength = 0
            RichTextBox1.SelectionFont = New Font(RichTextBox1.Font, FontStyle.Regular)
            RichTextBox1.AppendText(" for the header and only contain email addresses")
        ElseIf scope = "OU" Then
            ' Action combo box
            If Not ComboBoxUsersAction.Items.Contains("Get Info") Then
                ComboBoxUsersAction.Items.Insert(0, "Get Info")
            End If
            If Not ComboBoxUsersAction.Items.Contains("Move") Then
                ComboBoxUsersAction.Items.Insert(1, "Move")
            End If
            If ComboBoxUsersAction.Items.Contains("Recent Devices") Then
                ComboBoxUsersAction.Items.Remove("Recent Devices")
            End If
            If ComboBoxUsersAction.Items.Contains("Enable") Then
                ComboBoxUsersAction.Items.Remove("Enable")
            End If
            If ComboBoxUsersAction.Items.Contains("Suspend") Then
                ComboBoxUsersAction.Items.Remove("Suspend")
            End If
            If ComboBoxUsersAction.Items.Contains("Archive") Then
                ComboBoxUsersAction.Items.Remove("Archive")
            End If
            If ComboBoxUsersAction.Items.Contains("Unarchive") Then
                ComboBoxUsersAction.Items.Remove("Unarchive")
            End If
            If ComboBoxUsersAction.Items.Contains("Add to Group") Then
                ComboBoxUsersAction.Items.Remove("Add to Group")
            End If
            If ComboBoxUsersAction.Items.Contains("Remove from Group") Then
                ComboBoxUsersAction.Items.Remove("Remove from Group")
            End If

            If ComboBoxUsersAction.SelectedItem = "" Then
                ComboBoxUsersAction.SelectedItem = "Get Info"
            End If

            ' Target combo box
            ComboBoxUsersTarget.Visible = True

            ' Target text box
            TextBoxUsersTarget.Visible = False
            ButtonUsersTargetSearch.Visible = False
            ButtonUsersTargetEdit.Visible = False
            TextBoxUsersTarget.Size = New Size(428, 23)
        End If
    End Sub

    Private Sub ComboBoxFilesAction_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBoxFilesAction.SelectedIndexChanged
        ' Default disabled
        TextBoxFilesTargetUser.Enabled = False

        ' Enable only if action is not "Get Info" AND not "Untrash"
        If ComboBoxFilesAction.SelectedItem.ToString() <> "Get Info" AndAlso ComboBoxFilesAction.SelectedItem.ToString() <> "Untrash" Then
            TextBoxFilesTargetUser.Enabled = True
        End If

        ' Change labels of text boxes if assigning an owner
        If ComboBoxFilesAction.SelectedItem = "Assign Owner" Then
            LabelFilesUserWithAccess.Text = "Current Owner"
            LabelFilesTargetUser.Text = "New Owner"
        Else
            LabelFilesUserWithAccess.Text = "User with Edit Access"
            LabelFilesTargetUser.Text = "Target User"
        End If
    End Sub

    Private Async Sub ButtonReload_Click(sender As Object, e As EventArgs) Handles ButtonReload.Click
        ' Take snapshot & disable controls
        SnapshotAndDisable(Me)

        OrgUnitPaths.Clear()

        Try
            ' Run GAM in the background
            Dim result As List(Of String) = Await Task.Run(Function()
                                                               Dim list As New List(Of String)
                                                               Dim psi As New ProcessStartInfo()
                                                               psi.FileName = "cmd.exe"
                                                               psi.Arguments = "/c gam print orgs fields orgUnitPath"
                                                               psi.RedirectStandardOutput = True
                                                               psi.UseShellExecute = False
                                                               psi.CreateNoWindow = True

                                                               Using proc As Process = Process.Start(psi)
                                                                   Using reader As IO.StreamReader = proc.StandardOutput
                                                                       While Not reader.EndOfStream
                                                                           Dim line As String = reader.ReadLine().Trim()
                                                                           If line <> "orgUnitPath" AndAlso line <> "" Then
                                                                               list.Add(line)
                                                                           End If
                                                                       End While
                                                                   End Using
                                                               End Using

                                                               Return list
                                                           End Function)

            ' Update UI after background work
            OrgUnitPaths.AddRange(result)

            ComboBoxDevicesDestination.DataSource = Nothing
            ComboBoxDevicesDestination.DataSource = OrgUnitPaths

            ComboBoxUsersDestination.DataSource = Nothing
            ComboBoxUsersDestination.DataSource = OrgUnitPaths

            ComboBoxUsersTarget.DataSource = Nothing
            ComboBoxUsersTarget.DataSource = OrgUnitPaths

            ' Make UsersTarget selection independent of UsersDestination
            ComboBoxUsersTarget.BindingContext = New BindingContext()
        Catch ex As Exception
            RichTextBox1.Text = "Error retrieving OUs: " & ex.Message
        Finally
            ' Restore all original Enabled states
            RestoreStates()
        End Try

        groupList.Clear()

        ' Load all groups from Google Workspace
        Try
            Dim psi As New ProcessStartInfo()
            psi.FileName = "cmd.exe"
            psi.Arguments = "/c gam print groups"
            psi.RedirectStandardOutput = True
            psi.UseShellExecute = False
            psi.CreateNoWindow = True

            Using proc As Process = Process.Start(psi)
                Using reader As IO.StreamReader = proc.StandardOutput
                    While Not reader.EndOfStream
                        Dim line As String = reader.ReadLine().Trim()
                        ' Skip header line if present
                        If line <> "email" AndAlso line <> "" Then
                            groupList.Add(line)
                        End If
                    End While
                End Using
            End Using

            ' Add all Google groups to data sources
            ComboBoxUsersGroupDestination.DataSource = Nothing       ' Clear previous binding
            ComboBoxUsersGroupDestination.DataSource = groupList     ' Bind the list
        Catch ex As Exception
            RichTextBox1.Text = "Error retrieving groups: " & ex.Message
        End Try
    End Sub

    Private Sub ComboBoxUsersAction_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBoxUsersAction.SelectedIndexChanged
        ' Destination box only needed for Move
        If ComboBoxUsersAction.SelectedItem = "Move" Then
            ComboBoxUsersDestination.Enabled = True
            ComboBoxUsersDestination.Visible = True
            ComboBoxUsersGroupDestination.Visible = False

            ' Clear previous text
            RichTextBox1.Clear()
            ' Append normal text
            RichTextBox1.AppendText("Users in the ")
            ' Append bold text
            Dim start As Integer = RichTextBox1.TextLength
            RichTextBox1.AppendText("Target")
            RichTextBox1.Select(start, "Target".Length)
            RichTextBox1.SelectionFont = New Font(RichTextBox1.Font, FontStyle.Bold)
            ' Reset font to normal and append the rest
            RichTextBox1.SelectionStart = RichTextBox1.TextLength
            RichTextBox1.SelectionLength = 0
            RichTextBox1.SelectionFont = New Font(RichTextBox1.Font, FontStyle.Regular)
            RichTextBox1.AppendText(" OU will be moved to the ")
            ' Append bold text
            Dim start2 As Integer = RichTextBox1.TextLength
            RichTextBox1.AppendText("Destination")
            RichTextBox1.Select(start2, "Destination".Length)
            RichTextBox1.SelectionFont = New Font(RichTextBox1.Font, FontStyle.Bold)
            ' Reset font to normal and append the rest
            RichTextBox1.SelectionStart = RichTextBox1.TextLength
            RichTextBox1.SelectionLength = 0
            RichTextBox1.SelectionFont = New Font(RichTextBox1.Font, FontStyle.Regular)
            RichTextBox1.AppendText(" OU")
        ElseIf ComboBoxUsersAction.SelectedItem = "Add to Group" OrElse ComboBoxUsersAction.SelectedItem = "Remove from Group" Then
            ComboBoxUsersDestination.Enabled = False
            ComboBoxUsersDestination.Visible = False
            ComboBoxUsersGroupDestination.Visible = True
        Else
            ComboBoxUsersDestination.Enabled = False
            ComboBoxUsersDestination.Visible = True
            ComboBoxUsersGroupDestination.Visible = False
        End If
    End Sub

    Private Sub TabControl1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles TabControl1.SelectedIndexChanged
        If TabControl1.SelectedTab Is TabPageFiles OrElse TabControl1.SelectedTab Is TabPageDataTransfer Then
            ComboBoxFind.SelectedItem = "File"
        Else
            ComboBoxFind.SelectedItem = "OU"
        End If

    End Sub

    Private Sub TextBoxFind_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBoxFind.KeyDown
        If e.KeyCode = Keys.Enter Then
            ButtonFind.PerformClick()
            e.SuppressKeyPress = True
        End If
    End Sub

    Private Sub TextBoxDevicesTarget_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBoxDevicesTarget.KeyDown
        If e.KeyCode = Keys.Enter AndAlso e.Modifiers = Keys.Shift Then
            ' Shift + Enter
            ButtonRun.PerformClick()
            e.SuppressKeyPress = True
        ElseIf e.KeyCode = Keys.Enter AndAlso e.Modifiers = Keys.None Then
            ' Enter
            ButtonShowCommand.PerformClick()
            e.SuppressKeyPress = True
        End If
    End Sub

    Private Sub TextBoxUsersTarget_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBoxUsersTarget.KeyDown
        If e.KeyCode = Keys.Enter AndAlso e.Modifiers = Keys.Shift Then
            ' Shift + Enter
            ButtonRun.PerformClick()
            e.SuppressKeyPress = True
        ElseIf e.KeyCode = Keys.Enter AndAlso e.Modifiers = Keys.None Then
            ' Enter
            ButtonShowCommand.PerformClick()
            e.SuppressKeyPress = True
        End If
    End Sub

    Private Sub ComboBoxDevicesDestination_KeyDown(sender As Object, e As KeyEventArgs) Handles ComboBoxDevicesDestination.KeyDown
        If e.KeyCode = Keys.Enter AndAlso e.Modifiers = Keys.Shift Then
            ' Shift + Enter
            ButtonRun.PerformClick()
            e.SuppressKeyPress = True
        ElseIf e.KeyCode = Keys.Enter AndAlso e.Modifiers = Keys.None Then
            ' Enter
            ButtonShowCommand.PerformClick()
            e.SuppressKeyPress = True
        End If
    End Sub

    Private Sub ComboBoxUsersTarget_KeyDown(sender As Object, e As KeyEventArgs) Handles ComboBoxUsersTarget.KeyDown
        If e.KeyCode = Keys.Enter AndAlso e.Modifiers = Keys.Shift Then
            ' Shift + Enter
            ButtonRun.PerformClick()
            e.SuppressKeyPress = True
        ElseIf e.KeyCode = Keys.Enter AndAlso e.Modifiers = Keys.None Then
            ' Enter
            ButtonShowCommand.PerformClick()
            e.SuppressKeyPress = True
        End If
    End Sub

    Private Sub ComboBoxUsersDestination_KeyDown(sender As Object, e As KeyEventArgs) Handles ComboBoxUsersDestination.KeyDown
        If e.KeyCode = Keys.Enter AndAlso e.Modifiers = Keys.Shift Then
            ' Shift + Enter
            ButtonRun.PerformClick()
            e.SuppressKeyPress = True
        ElseIf e.KeyCode = Keys.Enter AndAlso e.Modifiers = Keys.None Then
            ' Enter
            ButtonShowCommand.PerformClick()
            e.SuppressKeyPress = True
        End If
    End Sub

    Private Sub ComboBoxDataTransferScope_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBoxDataTransferScope.SelectedIndexChanged
        ' Default disabled
        TextBoxDataTransferDocumentID.Enabled = False
        ComboBoxDataTransferSourceUserRetainRoleShared.Enabled = False
        ComboBoxDataTransferDestinationUserGainRoleShared.Enabled = False

        ' Enable Document ID text box only if Scope is "Folder" or "All But Folder"
        If ComboBoxDataTransferScope.SelectedItem.ToString() = "Folder" OrElse
           ComboBoxDataTransferScope.SelectedItem.ToString() = "All But Folder" Then
            TextBoxDataTransferDocumentID.Enabled = True
        Else
            TextBoxDataTransferDocumentID.Enabled = False
        End If

        ' Enable Source User Retain Role Shared combo box only if Scope is "All" or "All But Folder"
        If ComboBoxDataTransferScope.SelectedItem.ToString() = "All" OrElse
           ComboBoxDataTransferScope.SelectedItem.ToString() = "All But Folder" Then
            ComboBoxDataTransferSourceUserRetainRoleShared.Enabled = True
        Else
            ComboBoxDataTransferSourceUserRetainRoleShared.Enabled = False
        End If

        ' Enable Destination User Gain Role (Shared) combo box only if Scope is "All" or "All But Folder"
        If ComboBoxDataTransferScope.SelectedItem.ToString() = "All" OrElse
           ComboBoxDataTransferScope.SelectedItem.ToString() = "All But Folder" Then
            ComboBoxDataTransferDestinationUserGainRoleShared.Enabled = True
        Else
            ComboBoxDataTransferDestinationUserGainRoleShared.Enabled = False
        End If
    End Sub

    Private Sub ComboBoxCoursesScope_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBoxCoursesScope.SelectedIndexChanged
        Dim scope = ComboBoxCoursesScope.SelectedItem?.ToString()

        ' Always remove Get Info
        If ComboBoxCoursesAction.Items.Contains("Get Info") AndAlso Not scope = "Single" Then
            ComboBoxCoursesAction.Items.Remove("Get Info")
        End If

        ' Always remove Show Members
        If ComboBoxCoursesAction.Items.Contains("Show Members") AndAlso Not scope = "Single" Then
            ComboBoxCoursesAction.Items.Remove("Show Members")
        End If

        ' Always remove Add Students
        If ComboBoxCoursesAction.Items.Contains("Add Students") AndAlso Not scope = "Single" Then
            ComboBoxCoursesAction.Items.Remove("Add Students")
        End If

        ' Always remove Remove Students
        If ComboBoxCoursesAction.Items.Contains("Remove Students") AndAlso Not scope = "Single" Then
            ComboBoxCoursesAction.Items.Remove("Remove Students")
        End If

        If scope = "Single" Then
            LabelCoursesCourseID.Text = "Course ID"

            ' Action combo box
            If Not ComboBoxCoursesAction.Items.Contains("Get Info") Then
                ComboBoxCoursesAction.Items.Insert(0, "Get Info")
            End If
            If Not ComboBoxCoursesAction.Items.Contains("Show Members") Then
                ComboBoxCoursesAction.Items.Insert(1, "Show Members")
            End If
            If Not ComboBoxCoursesAction.Items.Contains("Archive") Then
                ComboBoxCoursesAction.Items.Insert(2, "Archive")
            End If
            If Not ComboBoxCoursesAction.Items.Contains("Unarchive") Then
                ComboBoxCoursesAction.Items.Insert(3, "Unarchive")
            End If
            If Not ComboBoxCoursesAction.Items.Contains("Assign Owner") Then
                ComboBoxCoursesAction.Items.Insert(4, "Assign Owner")
            End If
            If Not ComboBoxCoursesAction.Items.Contains("Add Teacher") Then
                ComboBoxCoursesAction.Items.Insert(5, "Add Teacher")
            End If
            If Not ComboBoxCoursesAction.Items.Contains("Remove Teacher") Then
                ComboBoxCoursesAction.Items.Insert(6, "Remove Teacher")
            End If
            If Not ComboBoxCoursesAction.Items.Contains("Add Student") Then
                ComboBoxCoursesAction.Items.Insert(7, "Add Student")
            End If
            If Not ComboBoxCoursesAction.Items.Contains("Remove Student") Then
                ComboBoxCoursesAction.Items.Insert(8, "Remove Student")
            End If
            If Not ComboBoxCoursesAction.Items.Contains("Add Students") Then
                ComboBoxCoursesAction.Items.Insert(9, "Add Students")
            End If
            If Not ComboBoxCoursesAction.Items.Contains("Remove Students") Then
                ComboBoxCoursesAction.Items.Insert(10, "Remove Students")
            End If

            If ComboBoxCoursesAction.SelectedItem = "" Then
                ComboBoxCoursesAction.SelectedItem = "Get Info"
            End If

            If Not ComboBoxCoursesAction.SelectedItem = "Add Students" AndAlso Not ComboBoxCoursesAction.SelectedItem = "Remove Students" Then
                ' Clear output
                RichTextBox1.Clear()
            End If

            ' Courses CourseID text box
            TextBoxCoursesCourseID.Text = ""
            ButtonCoursesCourseIDSearch.Visible = False
            ButtonCoursesCourseIDEdit.Visible = False
            TextBoxCoursesCourseID.Size = New Size(250, 23)
        ElseIf scope = "Multiple" Then
            LabelCoursesCourseID.Text = "Course IDs"

            If ComboBoxCoursesAction.Items.Contains("Get Info") Then
                ComboBoxCoursesAction.Items.Remove("Get Info")
            End If
            If ComboBoxCoursesAction.Items.Contains("Add Students") Then
                ComboBoxCoursesAction.Items.Remove("Add Students")
            End If
            If ComboBoxCoursesAction.Items.Contains("Remove Students") Then
                ComboBoxCoursesAction.Items.Remove("Remove Students")
            End If
            If Not ComboBoxCoursesAction.Items.Contains("Archive") Then
                ComboBoxCoursesAction.Items.Insert(0, "Archive")
            End If
            If Not ComboBoxCoursesAction.Items.Contains("Unarchive") Then
                ComboBoxCoursesAction.Items.Insert(1, "Unarchive")
            End If
            If Not ComboBoxCoursesAction.Items.Contains("Assign Owner") Then
                ComboBoxCoursesAction.Items.Insert(2, "Assign Owner")
            End If
            If Not ComboBoxCoursesAction.Items.Contains("Add Teacher") Then
                ComboBoxCoursesAction.Items.Insert(3, "Add Teacher")
            End If
            If Not ComboBoxCoursesAction.Items.Contains("Add Student") Then
                ComboBoxCoursesAction.Items.Insert(4, "Add Student")
            End If
            If Not ComboBoxCoursesAction.Items.Contains("Remove Teacher") Then
                ComboBoxCoursesAction.Items.Insert(5, "Remove Teacher")
            End If
            If Not ComboBoxCoursesAction.Items.Contains("Remove Student") Then
                ComboBoxCoursesAction.Items.Insert(6, "Remove Student")
            End If

            If ComboBoxCoursesAction.SelectedItem = "" Then
                ComboBoxCoursesAction.SelectedItem = "Archive"
            End If

            ' Courses CourseID text box
            If IO.File.Exists("C:\GAMWork\courseIDs.csv") Then
                TextBoxCoursesCourseID.Text = "C:\GAMWork\courseIDs.csv"
            Else
                TextBoxUsersTarget.Text = ""
            End If
            ButtonCoursesCourseIDSearch.Visible = True
            ButtonCoursesCourseIDEdit.Visible = True
            TextBoxCoursesCourseID.Size = New Size(567, 23)

            ' Clear previous text
            RichTextBox1.Clear()
            ' Append normal text
            RichTextBox1.AppendText("The CSV file must use ")
            ' Append bold text
            Dim start As Integer = RichTextBox1.TextLength
            RichTextBox1.AppendText("courseID")
            RichTextBox1.Select(start, "courseID".Length)
            RichTextBox1.SelectionFont = New Font(RichTextBox1.Font, FontStyle.Bold)
            ' Reset font to normal and append the rest
            RichTextBox1.SelectionStart = RichTextBox1.TextLength
            RichTextBox1.SelectionLength = 0
            RichTextBox1.SelectionFont = New Font(RichTextBox1.Font, FontStyle.Regular)
            RichTextBox1.AppendText(" for the header and only contain course IDs")
        End If
    End Sub

    ' Form-level variable to track previous selection
    Private previousCoursesAction As String = ""

    Private Sub ComboBoxCoursesAction_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBoxCoursesAction.SelectedIndexChanged
        Dim action = ComboBoxCoursesAction.SelectedItem?.ToString()

        ' Always disable TextBoxCoursesUser by default
        TextBoxCoursesUser.Enabled = False

        ' Actions that use a single user
        Dim singleUserActions As String() = {"Assign Owner", "Add Teacher", "Add Student", "Remove Teacher", "Remove Student"}

        ' --- Clear TextBox if coming from Add/Remove Students to something else ---
        If (previousCoursesAction = "Add Students" OrElse previousCoursesAction = "Remove Students") AndAlso (action <> "Add Students" AndAlso action <> "Remove Students") Then
            TextBoxCoursesUser.Text = ""
            RichTextBox1.Clear()
        End If

        ' --- Handle Single User Actions ---
        If singleUserActions.Contains(action) Then
            TextBoxCoursesUser.Size = New Size(179, 23)
            LabelCoursesUser.Text = "User"
            TextBoxCoursesUser.Enabled = True

            ' Hide buttons
            ButtonCoursesUsersEdit.Visible = False
            ButtonCoursesUsersSearch.Visible = False

            ' RichTextBox cleared already above if needed
            ' TextBox text preserved unless cleared above

            ' --- Handle Add/Remove Students ---
        ElseIf action = "Add Students" OrElse action = "Remove Students" Then
            TextBoxCoursesUser.Enabled = True
            TextBoxCoursesUser.Size = New Size(496, 23)
            LabelCoursesUser.Text = "Users"

            ' Always set CSV path if exists
            If IO.File.Exists("C:\GAMWork\users.csv") Then
                TextBoxCoursesUser.Text = "C:\GAMWork\users.csv"
            Else
                TextBoxCoursesUser.Text = ""
            End If

            ' Show buttons
            ButtonCoursesUsersEdit.Visible = True
            ButtonCoursesUsersSearch.Visible = True

            ' Update RichTextBox
            RichTextBox1.Clear()
            RichTextBox1.AppendText("The CSV file must use ")
            Dim start As Integer = RichTextBox1.TextLength
            RichTextBox1.AppendText("email")
            RichTextBox1.Select(start, "email".Length)
            RichTextBox1.SelectionFont = New Font(RichTextBox1.Font, FontStyle.Bold)
            RichTextBox1.SelectionStart = RichTextBox1.TextLength
            RichTextBox1.SelectionLength = 0
            RichTextBox1.SelectionFont = New Font(RichTextBox1.Font, FontStyle.Regular)
            RichTextBox1.AppendText(" for the header and only contain email addresses")

            ' --- Other Actions ---
        Else
            TextBoxCoursesUser.Enabled = False
            TextBoxCoursesUser.Size = New Size(179, 23)

            ' Hide buttons
            ButtonCoursesUsersEdit.Visible = False
            ButtonCoursesUsersSearch.Visible = False
        End If

        ' Update previous action
        previousCoursesAction = action
    End Sub




    Private Sub ButtonCoursesCourseIDSearch_Click(sender As Object, e As EventArgs) Handles ButtonCoursesCourseIDSearch.Click
        ' Create a new OpenFileDialog
        Dim openFileDialog As New OpenFileDialog()

        ' Set the dialog title
        openFileDialog.Title = "Select a CSV file"

        ' Set the initial directory to the user's desktop
        openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop)

        ' Only allow CSV files
        openFileDialog.Filter = "CSV Files (*.csv)|*.csv"

        ' Prevent multiple selection
        openFileDialog.Multiselect = False

        ' Show the dialog and check if the user clicked OK
        If openFileDialog.ShowDialog() = DialogResult.OK Then
            ' Put the selected file path in the textbox
            TextBoxCoursesCourseID.Text = openFileDialog.FileName
        End If
    End Sub

    Private Sub ButtonCoursesCourseIDEdit_Click(sender As Object, e As EventArgs) Handles ButtonCoursesCourseIDEdit.Click
        Dim filePath As String = TextBoxCoursesCourseID.Text

        If IO.File.Exists(filePath) Then
            Try
                Process.Start(New ProcessStartInfo(filePath) With {.UseShellExecute = True})
            Catch ex As Exception
                RichTextBox1.Text = "Error opening file: " & ex.Message
            End Try
        Else
            ' Clear previous text
            RichTextBox1.Clear()
            ' Append normal text
            RichTextBox1.AppendText("The CSV file in the ")
            ' Append "Target" in bold
            Dim start As Integer = RichTextBox1.TextLength
            RichTextBox1.AppendText("Course ID")
            RichTextBox1.Select(start, "Course ID".Length)
            RichTextBox1.SelectionFont = New Font(RichTextBox1.Font, FontStyle.Bold)
            ' Reset font to normal and append the rest
            RichTextBox1.SelectionStart = RichTextBox1.TextLength
            RichTextBox1.SelectionLength = 0
            RichTextBox1.SelectionFont = New Font(RichTextBox1.Font, FontStyle.Regular)
            RichTextBox1.AppendText(" text box does not exist")
        End If
    End Sub

    Private Sub ButtonCoursesUsersEdit_Click(sender As Object, e As EventArgs) Handles ButtonCoursesUsersEdit.Click
        Dim filePath As String = TextBoxCoursesUser.Text

        If IO.File.Exists(filePath) Then
            Try
                Process.Start(New ProcessStartInfo(filePath) With {.UseShellExecute = True})
            Catch ex As Exception
                RichTextBox1.Text = "Error opening file: " & ex.Message
            End Try
        Else
            ' Clear previous text
            RichTextBox1.Clear()
            ' Append normal text
            RichTextBox1.AppendText("The CSV file in the ")
            ' Append "Target" in bold
            Dim start As Integer = RichTextBox1.TextLength
            RichTextBox1.AppendText("Users")
            RichTextBox1.Select(start, "Users".Length)
            RichTextBox1.SelectionFont = New Font(RichTextBox1.Font, FontStyle.Bold)
            ' Reset font to normal and append the rest
            RichTextBox1.SelectionStart = RichTextBox1.TextLength
            RichTextBox1.SelectionLength = 0
            RichTextBox1.SelectionFont = New Font(RichTextBox1.Font, FontStyle.Regular)
            RichTextBox1.AppendText(" text box does not exist")
        End If
    End Sub

    Private Sub ButtonCoursesUsersSearch_Click(sender As Object, e As EventArgs) Handles ButtonCoursesUsersSearch.Click
        ' Create a new OpenFileDialog
        Dim openFileDialog As New OpenFileDialog()

        ' Set the dialog title
        openFileDialog.Title = "Select a CSV file"

        ' Set the initial directory to the user's desktop
        openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop)

        ' Only allow CSV files
        openFileDialog.Filter = "CSV Files (*.csv)|*.csv"

        ' Prevent multiple selection
        openFileDialog.Multiselect = False

        ' Show the dialog and check if the user clicked OK
        If openFileDialog.ShowDialog() = DialogResult.OK Then
            ' Put the selected file path in the textbox
            TextBoxCoursesUser.Text = openFileDialog.FileName
        End If
    End Sub

    Private Sub ButtonUsersTargetEdit_Click(sender As Object, e As EventArgs) Handles ButtonUsersTargetEdit.Click
        Dim filePath As String = TextBoxUsersTarget.Text

        If IO.File.Exists(filePath) Then
            Try
                Process.Start(New ProcessStartInfo(filePath) With {.UseShellExecute = True})
            Catch ex As Exception
                RichTextBox1.Text = "Error opening file: " & ex.Message
            End Try
        Else
            ' Clear previous text
            RichTextBox1.Clear()
            ' Append normal text
            RichTextBox1.AppendText("The CSV file in the ")
            ' Append "Target" in bold
            Dim start As Integer = RichTextBox1.TextLength
            RichTextBox1.AppendText("Target")
            RichTextBox1.Select(start, "Target".Length)
            RichTextBox1.SelectionFont = New Font(RichTextBox1.Font, FontStyle.Bold)
            ' Reset font to normal and append the rest
            RichTextBox1.SelectionStart = RichTextBox1.TextLength
            RichTextBox1.SelectionLength = 0
            RichTextBox1.SelectionFont = New Font(RichTextBox1.Font, FontStyle.Regular)
            RichTextBox1.AppendText(" text box does not exist")
        End If
    End Sub

    Private Sub ButtonUsersTargetSearch_Click(sender As Object, e As EventArgs) Handles ButtonUsersTargetSearch.Click
        ' Create a new OpenFileDialog
        Dim openFileDialog As New OpenFileDialog()

        ' Set the dialog title
        openFileDialog.Title = "Select a CSV file"

        ' Set the initial directory to the user's desktop
        openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop)

        ' Only allow CSV files
        openFileDialog.Filter = "CSV Files (*.csv)|*.csv"

        ' Prevent multiple selection
        openFileDialog.Multiselect = False

        ' Show the dialog and check if the user clicked OK
        If openFileDialog.ShowDialog() = DialogResult.OK Then
            ' Put the selected file path in the textbox
            TextBoxUsersTarget.Text = openFileDialog.FileName
        End If
    End Sub

    Private Sub CheckBoxReportFiltersStorage_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBoxUserReportFiltersStorage.CheckedChanged
        If CheckBoxUserReportFiltersStorage.Checked Then
            CheckBoxUserReportAttributesStorage.Checked = True
            ComboBoxUserReportFiltersStorage.Enabled = True
            TextBoxUserReportFiltersStorage.Enabled = True
        Else
            ComboBoxUserReportFiltersStorage.Enabled = False
            TextBoxUserReportFiltersStorage.Enabled = False
        End If
    End Sub

    Private Sub CheckBoxReportAttributesStorage_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBoxUserReportAttributesStorage.CheckedChanged
        If CheckBoxUserReportAttributesStorage.Checked = False Then
            CheckBoxUserReportFiltersStorage.Checked = False
        End If
    End Sub

    Private Sub CheckBoxReportFiltersLastLogin_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBoxUserReportFiltersLastLogin.CheckedChanged
        If CheckBoxUserReportFiltersLastLogin.Checked Then
            CheckBoxUserReportAttributesLastLogin.Checked = True
            CheckBoxUserReportFiltersNeverLoggedIn.Checked = False
            ComboBoxUserReportFiltersLastLogin.Enabled = True
            TextBoxUserReportFiltersLastLogin.Enabled = True
        Else
            ComboBoxUserReportFiltersLastLogin.Enabled = False
            TextBoxUserReportFiltersLastLogin.Enabled = False
        End If
    End Sub

    Private Sub CheckBoxReportAttributesLastLoginDate_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBoxUserReportAttributesLastLogin.CheckedChanged
        If CheckBoxUserReportAttributesLastLogin.Checked = False Then
            CheckBoxUserReportFiltersLastLogin.Checked = False
            CheckBoxUserReportFiltersNeverLoggedIn.Checked = False
        End If
    End Sub

    Private Sub CheckBoxReportFiltersCreated_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBoxUserReportFiltersCreated.CheckedChanged
        If CheckBoxUserReportFiltersCreated.Checked Then
            CheckBoxUserReportAttributesCreated.Checked = True
            ComboBoxUserReportFiltersCreated.Enabled = True
            TextBoxUserReportFiltersCreated.Enabled = True
        Else
            ComboBoxUserReportFiltersCreated.Enabled = False
            TextBoxUserReportFiltersCreated.Enabled = False
        End If
    End Sub

    Private Sub CheckBoxReportAttributesCreationDate_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBoxUserReportAttributesCreated.CheckedChanged
        If CheckBoxUserReportAttributesCreated.Checked = False Then
            CheckBoxUserReportFiltersCreated.Checked = False
        End If
    End Sub

    Private Sub CheckBoxReportFiltersArchived_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBoxUserReportFiltersArchived.CheckedChanged
        If CheckBoxUserReportFiltersArchived.Checked Then
            CheckBoxUserReportAttributesArchived.Checked = True
            ComboBoxUserReportFiltersArchived.Enabled = True
        Else
            ComboBoxUserReportFiltersArchived.Enabled = False
        End If
    End Sub

    Private Sub CheckBoxReportAttributesArchived_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBoxUserReportAttributesArchived.CheckedChanged
        If CheckBoxUserReportAttributesArchived.Checked = False Then
            CheckBoxUserReportFiltersArchived.Checked = False
        End If
    End Sub

    Private Sub CheckBoxReportFiltersSuspended_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBoxUserReportFiltersSuspended.CheckedChanged
        If CheckBoxUserReportFiltersSuspended.Checked Then
            CheckBoxUserReportAttributesSuspended.Checked = True
            ComboBoxUserReportFiltersSuspended.Enabled = True
        Else
            ComboBoxUserReportFiltersSuspended.Enabled = False
        End If
    End Sub

    Private Sub CheckBoxReportAttributesSuspended_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBoxUserReportAttributesSuspended.CheckedChanged
        If CheckBoxUserReportAttributesSuspended.Checked = False Then
            CheckBoxUserReportFiltersSuspended.Checked = False
        End If
    End Sub
    Private Sub TextBoxUserReportFiltersStorage_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBoxUserReportFiltersStorage.KeyPress
        ' Allow only digits and control characters (like Backspace)
        If Not Char.IsDigit(e.KeyChar) AndAlso Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub TextBoxUserReportFiltersLastLogin_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBoxUserReportFiltersLastLogin.KeyPress
        ' Allow only digits and control characters (like Backspace)
        If Not Char.IsDigit(e.KeyChar) AndAlso Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub TextBoxUserReportFiltersCreated_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBoxUserReportFiltersCreated.KeyPress
        ' Allow only digits and control characters (like Backspace)
        If Not Char.IsDigit(e.KeyChar) AndAlso Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub CheckBoxUserReportFiltersNeverLoggedIn_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBoxUserReportFiltersNeverLoggedIn.CheckedChanged
        If CheckBoxUserReportFiltersNeverLoggedIn.Checked = True Then
            CheckBoxUserReportFiltersLastLogin.Checked = False
            CheckBoxUserReportAttributesLastLogin.Checked = True
        End If
    End Sub

    Private Sub LinkLabelAboutGAMGitHub_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabelAboutGAMGitHub.LinkClicked
        ' URL you want to open
        Dim url As String = "https://github.com/GAM-team/GAM"

        ' Open the default web browser
        Try
            Process.Start(New ProcessStartInfo(url) With {.UseShellExecute = True})
        Catch ex As Exception
            MessageBox.Show("Unable to open link: " & ex.Message)
        End Try
    End Sub

    Private Sub LinkLabelAboutGAMGUIGitHub_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabelAboutGAMGUIGitHub.LinkClicked
        ' URL you want to open
        Dim url As String = "https://github.com/robert3288/gamgui"

        ' Open the default web browser
        Try
            Process.Start(New ProcessStartInfo(url) With {.UseShellExecute = True})
        Catch ex As Exception
            MessageBox.Show("Unable to open link: " & ex.Message)
        End Try
    End Sub
End Class