<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPageDevices = New System.Windows.Forms.TabPage()
        Me.ButtonDevicesTargetEdit = New System.Windows.Forms.Button()
        Me.ButtonDevicesTargetSearch = New System.Windows.Forms.Button()
        Me.LabelDevicesDestination = New System.Windows.Forms.Label()
        Me.LabelDevicesTarget = New System.Windows.Forms.Label()
        Me.TextBoxDevicesTarget = New System.Windows.Forms.TextBox()
        Me.ComboBoxDevicesDestination = New System.Windows.Forms.ComboBox()
        Me.LabelDevicesTargetType = New System.Windows.Forms.Label()
        Me.ComboBoxDevicesTargetType = New System.Windows.Forms.ComboBox()
        Me.LabelDevicesAction = New System.Windows.Forms.Label()
        Me.LabelDevicesScope = New System.Windows.Forms.Label()
        Me.ComboBoxDevicesAction = New System.Windows.Forms.ComboBox()
        Me.ComboBoxDevicesScope = New System.Windows.Forms.ComboBox()
        Me.TabPageUsers = New System.Windows.Forms.TabPage()
        Me.ComboBoxUsersGroupDestination = New System.Windows.Forms.ComboBox()
        Me.ComboBoxUsersTarget = New System.Windows.Forms.ComboBox()
        Me.LabelUsersDestination = New System.Windows.Forms.Label()
        Me.ComboBoxUsersDestination = New System.Windows.Forms.ComboBox()
        Me.LabelUsersTarget = New System.Windows.Forms.Label()
        Me.TextBoxUsersTarget = New System.Windows.Forms.TextBox()
        Me.LabelUsersScope = New System.Windows.Forms.Label()
        Me.ComboBoxUsersScope = New System.Windows.Forms.ComboBox()
        Me.LabelUsersAction = New System.Windows.Forms.Label()
        Me.ComboBoxUsersAction = New System.Windows.Forms.ComboBox()
        Me.ButtonUsersTargetEdit = New System.Windows.Forms.Button()
        Me.ButtonUsersTargetSearch = New System.Windows.Forms.Button()
        Me.TabPageFiles = New System.Windows.Forms.TabPage()
        Me.TextBoxFilesTargetUser = New System.Windows.Forms.TextBox()
        Me.TextBoxFilesDocumentID = New System.Windows.Forms.TextBox()
        Me.TextBoxFilesUserWithAccess = New System.Windows.Forms.TextBox()
        Me.LabelFilesTargetUser = New System.Windows.Forms.Label()
        Me.LabelFilesUserWithAccess = New System.Windows.Forms.Label()
        Me.LabelFilesAction = New System.Windows.Forms.Label()
        Me.ComboBoxFilesAction = New System.Windows.Forms.ComboBox()
        Me.LabelFilesDocumentID = New System.Windows.Forms.Label()
        Me.TabPageDataTransfer = New System.Windows.Forms.TabPage()
        Me.GroupBoxDataTransferSourceUser = New System.Windows.Forms.GroupBox()
        Me.ComboBoxDataTransferSourceUserRetainRoleShared = New System.Windows.Forms.ComboBox()
        Me.TextBoxDataTransferSourceUser = New System.Windows.Forms.TextBox()
        Me.LabelDataTransferSourceUserRetainRole = New System.Windows.Forms.Label()
        Me.LabelDataTransferSourceUserRetainRoleShared = New System.Windows.Forms.Label()
        Me.ComboBoxDataTransferSourceUserRetainRole = New System.Windows.Forms.ComboBox()
        Me.GroupBoxDataTransferDestinationUser = New System.Windows.Forms.GroupBox()
        Me.LabelDataTransferDestinationUserGainRoleShared = New System.Windows.Forms.Label()
        Me.TextBoxDataTransferDestinationUser = New System.Windows.Forms.TextBox()
        Me.ComboBoxDataTransferDestinationUserGainRoleShared = New System.Windows.Forms.ComboBox()
        Me.LabelDataTransferScope = New System.Windows.Forms.Label()
        Me.ComboBoxDataTransferScope = New System.Windows.Forms.ComboBox()
        Me.TextBoxDataTransferDocumentID = New System.Windows.Forms.TextBox()
        Me.LabelDataTransferDocumentID = New System.Windows.Forms.Label()
        Me.TabPageCourses = New System.Windows.Forms.TabPage()
        Me.ButtonCoursesUsersEdit = New System.Windows.Forms.Button()
        Me.ButtonCoursesUsersSearch = New System.Windows.Forms.Button()
        Me.ButtonCoursesCourseIDEdit = New System.Windows.Forms.Button()
        Me.ButtonCoursesCourseIDSearch = New System.Windows.Forms.Button()
        Me.TextBoxCoursesUser = New System.Windows.Forms.TextBox()
        Me.TextBoxCoursesCourseID = New System.Windows.Forms.TextBox()
        Me.LabelCoursesCourseID = New System.Windows.Forms.Label()
        Me.LabelCoursesUser = New System.Windows.Forms.Label()
        Me.LabelCoursesScope = New System.Windows.Forms.Label()
        Me.ComboBoxCoursesScope = New System.Windows.Forms.ComboBox()
        Me.LabelCoursesAction = New System.Windows.Forms.Label()
        Me.ComboBoxCoursesAction = New System.Windows.Forms.ComboBox()
        Me.TabPageUserReport = New System.Windows.Forms.TabPage()
        Me.GroupBoxUserReportFilters = New System.Windows.Forms.GroupBox()
        Me.CheckBoxUserReportFiltersNeverLoggedIn = New System.Windows.Forms.CheckBox()
        Me.TextBoxUserReportFiltersLastLogin = New System.Windows.Forms.TextBox()
        Me.ComboBoxUserReportFiltersLastLogin = New System.Windows.Forms.ComboBox()
        Me.LabelUserReportFiltersLastLogin = New System.Windows.Forms.Label()
        Me.CheckBoxUserReportFiltersLastLogin = New System.Windows.Forms.CheckBox()
        Me.TextBoxUserReportFiltersStorage = New System.Windows.Forms.TextBox()
        Me.ComboBoxUserReportFiltersStorage = New System.Windows.Forms.ComboBox()
        Me.LabelUserReportFiltersStorage = New System.Windows.Forms.Label()
        Me.CheckBoxUserReportFiltersStorage = New System.Windows.Forms.CheckBox()
        Me.TextBoxUserReportFiltersCreated = New System.Windows.Forms.TextBox()
        Me.ComboBoxUserReportFiltersCreated = New System.Windows.Forms.ComboBox()
        Me.LabelUserReportFIltersCreated = New System.Windows.Forms.Label()
        Me.CheckBoxUserReportFiltersCreated = New System.Windows.Forms.CheckBox()
        Me.ComboBoxUserReportFiltersArchived = New System.Windows.Forms.ComboBox()
        Me.CheckBoxUserReportFiltersArchived = New System.Windows.Forms.CheckBox()
        Me.ComboBoxUserReportFiltersSuspended = New System.Windows.Forms.ComboBox()
        Me.CheckBoxUserReportFiltersSuspended = New System.Windows.Forms.CheckBox()
        Me.GroupBoxUserReportAttributes = New System.Windows.Forms.GroupBox()
        Me.CheckBoxUserReportAttributesLastLogin = New System.Windows.Forms.CheckBox()
        Me.CheckBoxUserReportAttributesCreated = New System.Windows.Forms.CheckBox()
        Me.CheckBoxUserReportAttributesStorage = New System.Windows.Forms.CheckBox()
        Me.CheckBoxUserReportAttributesArchived = New System.Windows.Forms.CheckBox()
        Me.CheckBoxUserReportAttributesSuspended = New System.Windows.Forms.CheckBox()
        Me.CheckBoxUserReportAttributesName = New System.Windows.Forms.CheckBox()
        Me.TabPageAbout = New System.Windows.Forms.TabPage()
        Me.PictureBoxAboutGAMGUIIcon = New System.Windows.Forms.PictureBox()
        Me.LabelAboutVersion = New System.Windows.Forms.Label()
        Me.LabelAboutDescription = New System.Windows.Forms.Label()
        Me.LinkLabelAboutGAMGitHub = New System.Windows.Forms.LinkLabel()
        Me.LinkLabelAboutGAMGUIGitHub = New System.Windows.Forms.LinkLabel()
        Me.ButtonRun = New System.Windows.Forms.Button()
        Me.ButtonShowCommand = New System.Windows.Forms.Button()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.ButtonFind = New System.Windows.Forms.Button()
        Me.RichTextBox1 = New System.Windows.Forms.RichTextBox()
        Me.ButtonCopy = New System.Windows.Forms.Button()
        Me.ComboBoxFind = New System.Windows.Forms.ComboBox()
        Me.TextBoxFind = New System.Windows.Forms.TextBox()
        Me.GroupBoxFind = New System.Windows.Forms.GroupBox()
        Me.ButtonReload = New System.Windows.Forms.Button()
        Me.DirectorySearcher1 = New System.DirectoryServices.DirectorySearcher()
        Me.TabControl1.SuspendLayout()
        Me.TabPageDevices.SuspendLayout()
        Me.TabPageUsers.SuspendLayout()
        Me.TabPageFiles.SuspendLayout()
        Me.TabPageDataTransfer.SuspendLayout()
        Me.GroupBoxDataTransferSourceUser.SuspendLayout()
        Me.GroupBoxDataTransferDestinationUser.SuspendLayout()
        Me.TabPageCourses.SuspendLayout()
        Me.TabPageUserReport.SuspendLayout()
        Me.GroupBoxUserReportFilters.SuspendLayout()
        Me.GroupBoxUserReportAttributes.SuspendLayout()
        Me.TabPageAbout.SuspendLayout()
        CType(Me.PictureBoxAboutGAMGUIIcon, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBoxFind.SuspendLayout()
        Me.SuspendLayout()
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPageDevices)
        Me.TabControl1.Controls.Add(Me.TabPageUsers)
        Me.TabControl1.Controls.Add(Me.TabPageFiles)
        Me.TabControl1.Controls.Add(Me.TabPageDataTransfer)
        Me.TabControl1.Controls.Add(Me.TabPageCourses)
        Me.TabControl1.Controls.Add(Me.TabPageUserReport)
        Me.TabControl1.Controls.Add(Me.TabPageAbout)
        Me.TabControl1.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabControl1.Location = New System.Drawing.Point(15, 16)
        Me.TabControl1.Margin = New System.Windows.Forms.Padding(4)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(738, 156)
        Me.TabControl1.TabIndex = 0
        '
        'TabPageDevices
        '
        Me.TabPageDevices.Controls.Add(Me.ButtonDevicesTargetEdit)
        Me.TabPageDevices.Controls.Add(Me.ButtonDevicesTargetSearch)
        Me.TabPageDevices.Controls.Add(Me.LabelDevicesDestination)
        Me.TabPageDevices.Controls.Add(Me.LabelDevicesTarget)
        Me.TabPageDevices.Controls.Add(Me.TextBoxDevicesTarget)
        Me.TabPageDevices.Controls.Add(Me.ComboBoxDevicesDestination)
        Me.TabPageDevices.Controls.Add(Me.LabelDevicesTargetType)
        Me.TabPageDevices.Controls.Add(Me.ComboBoxDevicesTargetType)
        Me.TabPageDevices.Controls.Add(Me.LabelDevicesAction)
        Me.TabPageDevices.Controls.Add(Me.LabelDevicesScope)
        Me.TabPageDevices.Controls.Add(Me.ComboBoxDevicesAction)
        Me.TabPageDevices.Controls.Add(Me.ComboBoxDevicesScope)
        Me.TabPageDevices.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabPageDevices.Location = New System.Drawing.Point(4, 25)
        Me.TabPageDevices.Margin = New System.Windows.Forms.Padding(4)
        Me.TabPageDevices.Name = "TabPageDevices"
        Me.TabPageDevices.Padding = New System.Windows.Forms.Padding(4)
        Me.TabPageDevices.Size = New System.Drawing.Size(730, 127)
        Me.TabPageDevices.TabIndex = 0
        Me.TabPageDevices.Text = "Devices"
        Me.TabPageDevices.UseVisualStyleBackColor = True
        '
        'ButtonDevicesTargetEdit
        '
        Me.ButtonDevicesTargetEdit.Image = Global.GAM4.My.Resources.Resources.edit_16x16
        Me.ButtonDevicesTargetEdit.Location = New System.Drawing.Point(664, 32)
        Me.ButtonDevicesTargetEdit.Margin = New System.Windows.Forms.Padding(4)
        Me.ButtonDevicesTargetEdit.Name = "ButtonDevicesTargetEdit"
        Me.ButtonDevicesTargetEdit.Size = New System.Drawing.Size(28, 28)
        Me.ButtonDevicesTargetEdit.TabIndex = 8
        Me.ToolTip1.SetToolTip(Me.ButtonDevicesTargetEdit, "Edit")
        Me.ButtonDevicesTargetEdit.UseVisualStyleBackColor = True
        '
        'ButtonDevicesTargetSearch
        '
        Me.ButtonDevicesTargetSearch.Image = CType(resources.GetObject("ButtonDevicesTargetSearch.Image"), System.Drawing.Image)
        Me.ButtonDevicesTargetSearch.Location = New System.Drawing.Point(693, 32)
        Me.ButtonDevicesTargetSearch.Margin = New System.Windows.Forms.Padding(4)
        Me.ButtonDevicesTargetSearch.Name = "ButtonDevicesTargetSearch"
        Me.ButtonDevicesTargetSearch.Size = New System.Drawing.Size(28, 28)
        Me.ButtonDevicesTargetSearch.TabIndex = 9
        Me.ToolTip1.SetToolTip(Me.ButtonDevicesTargetSearch, "Search")
        Me.ButtonDevicesTargetSearch.UseVisualStyleBackColor = True
        '
        'LabelDevicesDestination
        '
        Me.LabelDevicesDestination.AutoSize = True
        Me.LabelDevicesDestination.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelDevicesDestination.Location = New System.Drawing.Point(7, 75)
        Me.LabelDevicesDestination.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LabelDevicesDestination.Name = "LabelDevicesDestination"
        Me.LabelDevicesDestination.Size = New System.Drawing.Size(81, 16)
        Me.LabelDevicesDestination.TabIndex = 10
        Me.LabelDevicesDestination.Text = "Destination"
        '
        'LabelDevicesTarget
        '
        Me.LabelDevicesTarget.AutoSize = True
        Me.LabelDevicesTarget.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelDevicesTarget.Location = New System.Drawing.Point(352, 11)
        Me.LabelDevicesTarget.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LabelDevicesTarget.Name = "LabelDevicesTarget"
        Me.LabelDevicesTarget.Size = New System.Drawing.Size(50, 16)
        Me.LabelDevicesTarget.TabIndex = 6
        Me.LabelDevicesTarget.Text = "Target"
        '
        'TextBoxDevicesTarget
        '
        Me.TextBoxDevicesTarget.Location = New System.Drawing.Point(356, 35)
        Me.TextBoxDevicesTarget.Margin = New System.Windows.Forms.Padding(4)
        Me.TextBoxDevicesTarget.Name = "TextBoxDevicesTarget"
        Me.TextBoxDevicesTarget.Size = New System.Drawing.Size(365, 23)
        Me.TextBoxDevicesTarget.TabIndex = 7
        '
        'ComboBoxDevicesDestination
        '
        Me.ComboBoxDevicesDestination.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.ComboBoxDevicesDestination.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.ComboBoxDevicesDestination.BackColor = System.Drawing.SystemColors.Window
        Me.ComboBoxDevicesDestination.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.ComboBoxDevicesDestination.ForeColor = System.Drawing.SystemColors.WindowText
        Me.ComboBoxDevicesDestination.FormattingEnabled = True
        Me.ComboBoxDevicesDestination.Location = New System.Drawing.Point(10, 95)
        Me.ComboBoxDevicesDestination.Margin = New System.Windows.Forms.Padding(4)
        Me.ComboBoxDevicesDestination.Name = "ComboBoxDevicesDestination"
        Me.ComboBoxDevicesDestination.Size = New System.Drawing.Size(711, 24)
        Me.ComboBoxDevicesDestination.TabIndex = 11
        '
        'LabelDevicesTargetType
        '
        Me.LabelDevicesTargetType.AutoSize = True
        Me.LabelDevicesTargetType.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelDevicesTargetType.Location = New System.Drawing.Point(219, 11)
        Me.LabelDevicesTargetType.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LabelDevicesTargetType.Name = "LabelDevicesTargetType"
        Me.LabelDevicesTargetType.Size = New System.Drawing.Size(85, 16)
        Me.LabelDevicesTargetType.TabIndex = 4
        Me.LabelDevicesTargetType.Text = "Target Type"
        '
        'ComboBoxDevicesTargetType
        '
        Me.ComboBoxDevicesTargetType.BackColor = System.Drawing.SystemColors.Window
        Me.ComboBoxDevicesTargetType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBoxDevicesTargetType.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.ComboBoxDevicesTargetType.ForeColor = System.Drawing.SystemColors.WindowText
        Me.ComboBoxDevicesTargetType.FormattingEnabled = True
        Me.ComboBoxDevicesTargetType.Items.AddRange(New Object() {"Asset ID", "Serial Number", "MAC Address"})
        Me.ComboBoxDevicesTargetType.Location = New System.Drawing.Point(223, 34)
        Me.ComboBoxDevicesTargetType.Margin = New System.Windows.Forms.Padding(4)
        Me.ComboBoxDevicesTargetType.Name = "ComboBoxDevicesTargetType"
        Me.ComboBoxDevicesTargetType.Size = New System.Drawing.Size(125, 24)
        Me.ComboBoxDevicesTargetType.TabIndex = 5
        '
        'LabelDevicesAction
        '
        Me.LabelDevicesAction.AutoSize = True
        Me.LabelDevicesAction.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelDevicesAction.Location = New System.Drawing.Point(94, 11)
        Me.LabelDevicesAction.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LabelDevicesAction.Name = "LabelDevicesAction"
        Me.LabelDevicesAction.Size = New System.Drawing.Size(49, 16)
        Me.LabelDevicesAction.TabIndex = 2
        Me.LabelDevicesAction.Text = "Action"
        '
        'LabelDevicesScope
        '
        Me.LabelDevicesScope.AutoSize = True
        Me.LabelDevicesScope.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelDevicesScope.Location = New System.Drawing.Point(7, 11)
        Me.LabelDevicesScope.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LabelDevicesScope.Name = "LabelDevicesScope"
        Me.LabelDevicesScope.Size = New System.Drawing.Size(46, 16)
        Me.LabelDevicesScope.TabIndex = 0
        Me.LabelDevicesScope.Text = "Scope"
        '
        'ComboBoxDevicesAction
        '
        Me.ComboBoxDevicesAction.BackColor = System.Drawing.SystemColors.Window
        Me.ComboBoxDevicesAction.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBoxDevicesAction.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.ComboBoxDevicesAction.ForeColor = System.Drawing.SystemColors.WindowText
        Me.ComboBoxDevicesAction.FormattingEnabled = True
        Me.ComboBoxDevicesAction.Items.AddRange(New Object() {"Get Info", "Move", "Enable", "Disable", "Clear Profiles", "Powerwash", "Deprovision"})
        Me.ComboBoxDevicesAction.Location = New System.Drawing.Point(98, 34)
        Me.ComboBoxDevicesAction.Margin = New System.Windows.Forms.Padding(4)
        Me.ComboBoxDevicesAction.Name = "ComboBoxDevicesAction"
        Me.ComboBoxDevicesAction.Size = New System.Drawing.Size(117, 24)
        Me.ComboBoxDevicesAction.TabIndex = 3
        '
        'ComboBoxDevicesScope
        '
        Me.ComboBoxDevicesScope.BackColor = System.Drawing.SystemColors.Window
        Me.ComboBoxDevicesScope.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBoxDevicesScope.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.ComboBoxDevicesScope.ForeColor = System.Drawing.SystemColors.WindowText
        Me.ComboBoxDevicesScope.FormattingEnabled = True
        Me.ComboBoxDevicesScope.Items.AddRange(New Object() {"Single", "Multiple"})
        Me.ComboBoxDevicesScope.Location = New System.Drawing.Point(10, 34)
        Me.ComboBoxDevicesScope.Margin = New System.Windows.Forms.Padding(4)
        Me.ComboBoxDevicesScope.Name = "ComboBoxDevicesScope"
        Me.ComboBoxDevicesScope.Size = New System.Drawing.Size(80, 24)
        Me.ComboBoxDevicesScope.TabIndex = 1
        '
        'TabPageUsers
        '
        Me.TabPageUsers.Controls.Add(Me.ComboBoxUsersGroupDestination)
        Me.TabPageUsers.Controls.Add(Me.ComboBoxUsersTarget)
        Me.TabPageUsers.Controls.Add(Me.LabelUsersDestination)
        Me.TabPageUsers.Controls.Add(Me.ComboBoxUsersDestination)
        Me.TabPageUsers.Controls.Add(Me.LabelUsersTarget)
        Me.TabPageUsers.Controls.Add(Me.TextBoxUsersTarget)
        Me.TabPageUsers.Controls.Add(Me.LabelUsersScope)
        Me.TabPageUsers.Controls.Add(Me.ComboBoxUsersScope)
        Me.TabPageUsers.Controls.Add(Me.LabelUsersAction)
        Me.TabPageUsers.Controls.Add(Me.ComboBoxUsersAction)
        Me.TabPageUsers.Controls.Add(Me.ButtonUsersTargetEdit)
        Me.TabPageUsers.Controls.Add(Me.ButtonUsersTargetSearch)
        Me.TabPageUsers.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabPageUsers.Location = New System.Drawing.Point(4, 25)
        Me.TabPageUsers.Margin = New System.Windows.Forms.Padding(4)
        Me.TabPageUsers.Name = "TabPageUsers"
        Me.TabPageUsers.Padding = New System.Windows.Forms.Padding(4)
        Me.TabPageUsers.Size = New System.Drawing.Size(730, 127)
        Me.TabPageUsers.TabIndex = 1
        Me.TabPageUsers.Text = "Users"
        Me.TabPageUsers.UseVisualStyleBackColor = True
        '
        'ComboBoxUsersGroupDestination
        '
        Me.ComboBoxUsersGroupDestination.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.ComboBoxUsersGroupDestination.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.ComboBoxUsersGroupDestination.BackColor = System.Drawing.SystemColors.Window
        Me.ComboBoxUsersGroupDestination.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.ComboBoxUsersGroupDestination.ForeColor = System.Drawing.SystemColors.WindowText
        Me.ComboBoxUsersGroupDestination.FormattingEnabled = True
        Me.ComboBoxUsersGroupDestination.Location = New System.Drawing.Point(10, 95)
        Me.ComboBoxUsersGroupDestination.Margin = New System.Windows.Forms.Padding(4)
        Me.ComboBoxUsersGroupDestination.Name = "ComboBoxUsersGroupDestination"
        Me.ComboBoxUsersGroupDestination.Size = New System.Drawing.Size(711, 24)
        Me.ComboBoxUsersGroupDestination.TabIndex = 10
        '
        'ComboBoxUsersTarget
        '
        Me.ComboBoxUsersTarget.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.ComboBoxUsersTarget.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.ComboBoxUsersTarget.BackColor = System.Drawing.SystemColors.Window
        Me.ComboBoxUsersTarget.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.ComboBoxUsersTarget.ForeColor = System.Drawing.SystemColors.WindowText
        Me.ComboBoxUsersTarget.FormattingEnabled = True
        Me.ComboBoxUsersTarget.Items.AddRange(New Object() {"CTAG", "MAC Address", "Serial Number"})
        Me.ComboBoxUsersTarget.Location = New System.Drawing.Point(234, 34)
        Me.ComboBoxUsersTarget.Margin = New System.Windows.Forms.Padding(4)
        Me.ComboBoxUsersTarget.Name = "ComboBoxUsersTarget"
        Me.ComboBoxUsersTarget.Size = New System.Drawing.Size(487, 24)
        Me.ComboBoxUsersTarget.TabIndex = 5
        '
        'LabelUsersDestination
        '
        Me.LabelUsersDestination.AutoSize = True
        Me.LabelUsersDestination.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelUsersDestination.Location = New System.Drawing.Point(7, 75)
        Me.LabelUsersDestination.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LabelUsersDestination.Name = "LabelUsersDestination"
        Me.LabelUsersDestination.Size = New System.Drawing.Size(81, 16)
        Me.LabelUsersDestination.TabIndex = 9
        Me.LabelUsersDestination.Text = "Destination"
        '
        'ComboBoxUsersDestination
        '
        Me.ComboBoxUsersDestination.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.ComboBoxUsersDestination.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.ComboBoxUsersDestination.BackColor = System.Drawing.SystemColors.Window
        Me.ComboBoxUsersDestination.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.ComboBoxUsersDestination.ForeColor = System.Drawing.SystemColors.WindowText
        Me.ComboBoxUsersDestination.FormattingEnabled = True
        Me.ComboBoxUsersDestination.Location = New System.Drawing.Point(10, 95)
        Me.ComboBoxUsersDestination.Margin = New System.Windows.Forms.Padding(4)
        Me.ComboBoxUsersDestination.Name = "ComboBoxUsersDestination"
        Me.ComboBoxUsersDestination.Size = New System.Drawing.Size(711, 24)
        Me.ComboBoxUsersDestination.TabIndex = 21
        '
        'LabelUsersTarget
        '
        Me.LabelUsersTarget.AutoSize = True
        Me.LabelUsersTarget.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelUsersTarget.Location = New System.Drawing.Point(231, 11)
        Me.LabelUsersTarget.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LabelUsersTarget.Name = "LabelUsersTarget"
        Me.LabelUsersTarget.Size = New System.Drawing.Size(50, 16)
        Me.LabelUsersTarget.TabIndex = 4
        Me.LabelUsersTarget.Text = "Target"
        '
        'TextBoxUsersTarget
        '
        Me.TextBoxUsersTarget.Location = New System.Drawing.Point(234, 35)
        Me.TextBoxUsersTarget.Margin = New System.Windows.Forms.Padding(4)
        Me.TextBoxUsersTarget.Name = "TextBoxUsersTarget"
        Me.TextBoxUsersTarget.Size = New System.Drawing.Size(487, 23)
        Me.TextBoxUsersTarget.TabIndex = 6
        '
        'LabelUsersScope
        '
        Me.LabelUsersScope.AutoSize = True
        Me.LabelUsersScope.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelUsersScope.Location = New System.Drawing.Point(7, 11)
        Me.LabelUsersScope.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LabelUsersScope.Name = "LabelUsersScope"
        Me.LabelUsersScope.Size = New System.Drawing.Size(46, 16)
        Me.LabelUsersScope.TabIndex = 0
        Me.LabelUsersScope.Text = "Scope"
        '
        'ComboBoxUsersScope
        '
        Me.ComboBoxUsersScope.BackColor = System.Drawing.SystemColors.Window
        Me.ComboBoxUsersScope.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBoxUsersScope.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.ComboBoxUsersScope.ForeColor = System.Drawing.SystemColors.WindowText
        Me.ComboBoxUsersScope.FormattingEnabled = True
        Me.ComboBoxUsersScope.Items.AddRange(New Object() {"User", "Users", "OU"})
        Me.ComboBoxUsersScope.Location = New System.Drawing.Point(10, 34)
        Me.ComboBoxUsersScope.Margin = New System.Windows.Forms.Padding(4)
        Me.ComboBoxUsersScope.Name = "ComboBoxUsersScope"
        Me.ComboBoxUsersScope.Size = New System.Drawing.Size(58, 24)
        Me.ComboBoxUsersScope.TabIndex = 1
        '
        'LabelUsersAction
        '
        Me.LabelUsersAction.AutoSize = True
        Me.LabelUsersAction.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelUsersAction.Location = New System.Drawing.Point(73, 11)
        Me.LabelUsersAction.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LabelUsersAction.Name = "LabelUsersAction"
        Me.LabelUsersAction.Size = New System.Drawing.Size(49, 16)
        Me.LabelUsersAction.TabIndex = 2
        Me.LabelUsersAction.Text = "Action"
        '
        'ComboBoxUsersAction
        '
        Me.ComboBoxUsersAction.BackColor = System.Drawing.SystemColors.Window
        Me.ComboBoxUsersAction.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBoxUsersAction.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.ComboBoxUsersAction.ForeColor = System.Drawing.SystemColors.WindowText
        Me.ComboBoxUsersAction.FormattingEnabled = True
        Me.ComboBoxUsersAction.Items.AddRange(New Object() {"Get Info", "Recent Devices", "Show Files", "Move", "Enable", "Suspend", "Archive", "Unarchive", "Add to Group", "Remove from Group"})
        Me.ComboBoxUsersAction.Location = New System.Drawing.Point(76, 34)
        Me.ComboBoxUsersAction.Margin = New System.Windows.Forms.Padding(4)
        Me.ComboBoxUsersAction.Name = "ComboBoxUsersAction"
        Me.ComboBoxUsersAction.Size = New System.Drawing.Size(150, 24)
        Me.ComboBoxUsersAction.TabIndex = 3
        '
        'ButtonUsersTargetEdit
        '
        Me.ButtonUsersTargetEdit.Image = Global.GAM4.My.Resources.Resources.edit_16x16
        Me.ButtonUsersTargetEdit.Location = New System.Drawing.Point(664, 32)
        Me.ButtonUsersTargetEdit.Margin = New System.Windows.Forms.Padding(4)
        Me.ButtonUsersTargetEdit.Name = "ButtonUsersTargetEdit"
        Me.ButtonUsersTargetEdit.Size = New System.Drawing.Size(28, 28)
        Me.ButtonUsersTargetEdit.TabIndex = 7
        Me.ToolTip1.SetToolTip(Me.ButtonUsersTargetEdit, "Edit")
        Me.ButtonUsersTargetEdit.UseVisualStyleBackColor = True
        '
        'ButtonUsersTargetSearch
        '
        Me.ButtonUsersTargetSearch.Image = CType(resources.GetObject("ButtonUsersTargetSearch.Image"), System.Drawing.Image)
        Me.ButtonUsersTargetSearch.Location = New System.Drawing.Point(693, 32)
        Me.ButtonUsersTargetSearch.Margin = New System.Windows.Forms.Padding(4)
        Me.ButtonUsersTargetSearch.Name = "ButtonUsersTargetSearch"
        Me.ButtonUsersTargetSearch.Size = New System.Drawing.Size(28, 28)
        Me.ButtonUsersTargetSearch.TabIndex = 8
        Me.ToolTip1.SetToolTip(Me.ButtonUsersTargetSearch, "Search")
        Me.ButtonUsersTargetSearch.UseVisualStyleBackColor = True
        '
        'TabPageFiles
        '
        Me.TabPageFiles.Controls.Add(Me.TextBoxFilesTargetUser)
        Me.TabPageFiles.Controls.Add(Me.TextBoxFilesDocumentID)
        Me.TabPageFiles.Controls.Add(Me.TextBoxFilesUserWithAccess)
        Me.TabPageFiles.Controls.Add(Me.LabelFilesTargetUser)
        Me.TabPageFiles.Controls.Add(Me.LabelFilesUserWithAccess)
        Me.TabPageFiles.Controls.Add(Me.LabelFilesAction)
        Me.TabPageFiles.Controls.Add(Me.ComboBoxFilesAction)
        Me.TabPageFiles.Controls.Add(Me.LabelFilesDocumentID)
        Me.TabPageFiles.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabPageFiles.Location = New System.Drawing.Point(4, 25)
        Me.TabPageFiles.Name = "TabPageFiles"
        Me.TabPageFiles.Size = New System.Drawing.Size(730, 127)
        Me.TabPageFiles.TabIndex = 2
        Me.TabPageFiles.Text = "Files"
        Me.TabPageFiles.UseVisualStyleBackColor = True
        '
        'TextBoxFilesTargetUser
        '
        Me.TextBoxFilesTargetUser.Location = New System.Drawing.Point(496, 95)
        Me.TextBoxFilesTargetUser.Margin = New System.Windows.Forms.Padding(4)
        Me.TextBoxFilesTargetUser.Name = "TextBoxFilesTargetUser"
        Me.TextBoxFilesTargetUser.Size = New System.Drawing.Size(225, 23)
        Me.TextBoxFilesTargetUser.TabIndex = 7
        '
        'TextBoxFilesDocumentID
        '
        Me.TextBoxFilesDocumentID.Location = New System.Drawing.Point(138, 34)
        Me.TextBoxFilesDocumentID.Margin = New System.Windows.Forms.Padding(4)
        Me.TextBoxFilesDocumentID.Name = "TextBoxFilesDocumentID"
        Me.TextBoxFilesDocumentID.Size = New System.Drawing.Size(350, 23)
        Me.TextBoxFilesDocumentID.TabIndex = 3
        '
        'TextBoxFilesUserWithAccess
        '
        Me.TextBoxFilesUserWithAccess.Location = New System.Drawing.Point(496, 34)
        Me.TextBoxFilesUserWithAccess.Margin = New System.Windows.Forms.Padding(4)
        Me.TextBoxFilesUserWithAccess.Name = "TextBoxFilesUserWithAccess"
        Me.TextBoxFilesUserWithAccess.Size = New System.Drawing.Size(225, 23)
        Me.TextBoxFilesUserWithAccess.TabIndex = 5
        '
        'LabelFilesTargetUser
        '
        Me.LabelFilesTargetUser.AutoSize = True
        Me.LabelFilesTargetUser.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelFilesTargetUser.Location = New System.Drawing.Point(493, 75)
        Me.LabelFilesTargetUser.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LabelFilesTargetUser.Name = "LabelFilesTargetUser"
        Me.LabelFilesTargetUser.Size = New System.Drawing.Size(83, 16)
        Me.LabelFilesTargetUser.TabIndex = 6
        Me.LabelFilesTargetUser.Text = "Target User"
        '
        'LabelFilesUserWithAccess
        '
        Me.LabelFilesUserWithAccess.AutoSize = True
        Me.LabelFilesUserWithAccess.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelFilesUserWithAccess.Location = New System.Drawing.Point(493, 11)
        Me.LabelFilesUserWithAccess.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LabelFilesUserWithAccess.Name = "LabelFilesUserWithAccess"
        Me.LabelFilesUserWithAccess.Size = New System.Drawing.Size(146, 16)
        Me.LabelFilesUserWithAccess.TabIndex = 4
        Me.LabelFilesUserWithAccess.Text = "User with Edit Access"
        '
        'LabelFilesAction
        '
        Me.LabelFilesAction.AutoSize = True
        Me.LabelFilesAction.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelFilesAction.Location = New System.Drawing.Point(7, 11)
        Me.LabelFilesAction.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LabelFilesAction.Name = "LabelFilesAction"
        Me.LabelFilesAction.Size = New System.Drawing.Size(49, 16)
        Me.LabelFilesAction.TabIndex = 0
        Me.LabelFilesAction.Text = "Action"
        '
        'ComboBoxFilesAction
        '
        Me.ComboBoxFilesAction.BackColor = System.Drawing.SystemColors.Window
        Me.ComboBoxFilesAction.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBoxFilesAction.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.ComboBoxFilesAction.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboBoxFilesAction.ForeColor = System.Drawing.SystemColors.WindowText
        Me.ComboBoxFilesAction.FormattingEnabled = True
        Me.ComboBoxFilesAction.Items.AddRange(New Object() {"Get Info", "Untrash", "Assign Owner", "Add Editor", "Add Reader", "Remove Access"})
        Me.ComboBoxFilesAction.Location = New System.Drawing.Point(10, 34)
        Me.ComboBoxFilesAction.Margin = New System.Windows.Forms.Padding(4)
        Me.ComboBoxFilesAction.Name = "ComboBoxFilesAction"
        Me.ComboBoxFilesAction.Size = New System.Drawing.Size(120, 24)
        Me.ComboBoxFilesAction.TabIndex = 1
        '
        'LabelFilesDocumentID
        '
        Me.LabelFilesDocumentID.AutoSize = True
        Me.LabelFilesDocumentID.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelFilesDocumentID.Location = New System.Drawing.Point(135, 11)
        Me.LabelFilesDocumentID.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LabelFilesDocumentID.Name = "LabelFilesDocumentID"
        Me.LabelFilesDocumentID.Size = New System.Drawing.Size(90, 16)
        Me.LabelFilesDocumentID.TabIndex = 2
        Me.LabelFilesDocumentID.Text = "Document ID"
        '
        'TabPageDataTransfer
        '
        Me.TabPageDataTransfer.Controls.Add(Me.GroupBoxDataTransferSourceUser)
        Me.TabPageDataTransfer.Controls.Add(Me.GroupBoxDataTransferDestinationUser)
        Me.TabPageDataTransfer.Controls.Add(Me.LabelDataTransferScope)
        Me.TabPageDataTransfer.Controls.Add(Me.ComboBoxDataTransferScope)
        Me.TabPageDataTransfer.Controls.Add(Me.TextBoxDataTransferDocumentID)
        Me.TabPageDataTransfer.Controls.Add(Me.LabelDataTransferDocumentID)
        Me.TabPageDataTransfer.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabPageDataTransfer.Location = New System.Drawing.Point(4, 25)
        Me.TabPageDataTransfer.Name = "TabPageDataTransfer"
        Me.TabPageDataTransfer.Size = New System.Drawing.Size(730, 127)
        Me.TabPageDataTransfer.TabIndex = 3
        Me.TabPageDataTransfer.Text = "Data Transfer"
        Me.TabPageDataTransfer.UseVisualStyleBackColor = True
        '
        'GroupBoxDataTransferSourceUser
        '
        Me.GroupBoxDataTransferSourceUser.Controls.Add(Me.ComboBoxDataTransferSourceUserRetainRoleShared)
        Me.GroupBoxDataTransferSourceUser.Controls.Add(Me.TextBoxDataTransferSourceUser)
        Me.GroupBoxDataTransferSourceUser.Controls.Add(Me.LabelDataTransferSourceUserRetainRole)
        Me.GroupBoxDataTransferSourceUser.Controls.Add(Me.LabelDataTransferSourceUserRetainRoleShared)
        Me.GroupBoxDataTransferSourceUser.Controls.Add(Me.ComboBoxDataTransferSourceUserRetainRole)
        Me.GroupBoxDataTransferSourceUser.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBoxDataTransferSourceUser.Location = New System.Drawing.Point(326, 11)
        Me.GroupBoxDataTransferSourceUser.Name = "GroupBoxDataTransferSourceUser"
        Me.GroupBoxDataTransferSourceUser.Size = New System.Drawing.Size(225, 107)
        Me.GroupBoxDataTransferSourceUser.TabIndex = 4
        Me.GroupBoxDataTransferSourceUser.TabStop = False
        Me.GroupBoxDataTransferSourceUser.Text = "Source User"
        '
        'ComboBoxDataTransferSourceUserRetainRoleShared
        '
        Me.ComboBoxDataTransferSourceUserRetainRoleShared.BackColor = System.Drawing.SystemColors.Window
        Me.ComboBoxDataTransferSourceUserRetainRoleShared.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBoxDataTransferSourceUserRetainRoleShared.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.ComboBoxDataTransferSourceUserRetainRoleShared.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboBoxDataTransferSourceUserRetainRoleShared.ForeColor = System.Drawing.SystemColors.WindowText
        Me.ComboBoxDataTransferSourceUserRetainRoleShared.FormattingEnabled = True
        Me.ComboBoxDataTransferSourceUserRetainRoleShared.Items.AddRange(New Object() {"None", "Current", "Reader", "Editor"})
        Me.ComboBoxDataTransferSourceUserRetainRoleShared.Location = New System.Drawing.Point(96, 74)
        Me.ComboBoxDataTransferSourceUserRetainRoleShared.Margin = New System.Windows.Forms.Padding(4)
        Me.ComboBoxDataTransferSourceUserRetainRoleShared.Name = "ComboBoxDataTransferSourceUserRetainRoleShared"
        Me.ComboBoxDataTransferSourceUserRetainRoleShared.Size = New System.Drawing.Size(120, 24)
        Me.ComboBoxDataTransferSourceUserRetainRoleShared.TabIndex = 4
        '
        'TextBoxDataTransferSourceUser
        '
        Me.TextBoxDataTransferSourceUser.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBoxDataTransferSourceUser.Location = New System.Drawing.Point(7, 23)
        Me.TextBoxDataTransferSourceUser.Margin = New System.Windows.Forms.Padding(4)
        Me.TextBoxDataTransferSourceUser.Name = "TextBoxDataTransferSourceUser"
        Me.TextBoxDataTransferSourceUser.Size = New System.Drawing.Size(150, 23)
        Me.TextBoxDataTransferSourceUser.TabIndex = 0
        '
        'LabelDataTransferSourceUserRetainRole
        '
        Me.LabelDataTransferSourceUserRetainRole.AutoSize = True
        Me.LabelDataTransferSourceUserRetainRole.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelDataTransferSourceUserRetainRole.Location = New System.Drawing.Point(7, 52)
        Me.LabelDataTransferSourceUserRetainRole.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LabelDataTransferSourceUserRetainRole.Name = "LabelDataTransferSourceUserRetainRole"
        Me.LabelDataTransferSourceUserRetainRole.Size = New System.Drawing.Size(72, 16)
        Me.LabelDataTransferSourceUserRetainRole.TabIndex = 1
        Me.LabelDataTransferSourceUserRetainRole.Text = "Retain Role"
        '
        'LabelDataTransferSourceUserRetainRoleShared
        '
        Me.LabelDataTransferSourceUserRetainRoleShared.AutoSize = True
        Me.LabelDataTransferSourceUserRetainRoleShared.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelDataTransferSourceUserRetainRoleShared.Location = New System.Drawing.Point(93, 51)
        Me.LabelDataTransferSourceUserRetainRoleShared.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LabelDataTransferSourceUserRetainRoleShared.Name = "LabelDataTransferSourceUserRetainRoleShared"
        Me.LabelDataTransferSourceUserRetainRoleShared.Size = New System.Drawing.Size(127, 16)
        Me.LabelDataTransferSourceUserRetainRoleShared.TabIndex = 3
        Me.LabelDataTransferSourceUserRetainRoleShared.Text = "Retain Role (Shared)"
        '
        'ComboBoxDataTransferSourceUserRetainRole
        '
        Me.ComboBoxDataTransferSourceUserRetainRole.BackColor = System.Drawing.SystemColors.Window
        Me.ComboBoxDataTransferSourceUserRetainRole.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBoxDataTransferSourceUserRetainRole.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.ComboBoxDataTransferSourceUserRetainRole.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboBoxDataTransferSourceUserRetainRole.ForeColor = System.Drawing.SystemColors.WindowText
        Me.ComboBoxDataTransferSourceUserRetainRole.FormattingEnabled = True
        Me.ComboBoxDataTransferSourceUserRetainRole.Items.AddRange(New Object() {"None", "Reader", "Editor"})
        Me.ComboBoxDataTransferSourceUserRetainRole.Location = New System.Drawing.Point(10, 75)
        Me.ComboBoxDataTransferSourceUserRetainRole.Margin = New System.Windows.Forms.Padding(4)
        Me.ComboBoxDataTransferSourceUserRetainRole.Name = "ComboBoxDataTransferSourceUserRetainRole"
        Me.ComboBoxDataTransferSourceUserRetainRole.Size = New System.Drawing.Size(78, 24)
        Me.ComboBoxDataTransferSourceUserRetainRole.TabIndex = 2
        '
        'GroupBoxDataTransferDestinationUser
        '
        Me.GroupBoxDataTransferDestinationUser.Controls.Add(Me.LabelDataTransferDestinationUserGainRoleShared)
        Me.GroupBoxDataTransferDestinationUser.Controls.Add(Me.TextBoxDataTransferDestinationUser)
        Me.GroupBoxDataTransferDestinationUser.Controls.Add(Me.ComboBoxDataTransferDestinationUserGainRoleShared)
        Me.GroupBoxDataTransferDestinationUser.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBoxDataTransferDestinationUser.Location = New System.Drawing.Point(557, 11)
        Me.GroupBoxDataTransferDestinationUser.Name = "GroupBoxDataTransferDestinationUser"
        Me.GroupBoxDataTransferDestinationUser.Size = New System.Drawing.Size(165, 107)
        Me.GroupBoxDataTransferDestinationUser.TabIndex = 5
        Me.GroupBoxDataTransferDestinationUser.TabStop = False
        Me.GroupBoxDataTransferDestinationUser.Text = "Destination User"
        '
        'LabelDataTransferDestinationUserGainRoleShared
        '
        Me.LabelDataTransferDestinationUserGainRoleShared.AutoSize = True
        Me.LabelDataTransferDestinationUserGainRoleShared.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelDataTransferDestinationUserGainRoleShared.Location = New System.Drawing.Point(7, 52)
        Me.LabelDataTransferDestinationUserGainRoleShared.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LabelDataTransferDestinationUserGainRoleShared.Name = "LabelDataTransferDestinationUserGainRoleShared"
        Me.LabelDataTransferDestinationUserGainRoleShared.Size = New System.Drawing.Size(116, 16)
        Me.LabelDataTransferDestinationUserGainRoleShared.TabIndex = 1
        Me.LabelDataTransferDestinationUserGainRoleShared.Text = "Gain Role (Shared)"
        '
        'TextBoxDataTransferDestinationUser
        '
        Me.TextBoxDataTransferDestinationUser.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBoxDataTransferDestinationUser.Location = New System.Drawing.Point(7, 23)
        Me.TextBoxDataTransferDestinationUser.Margin = New System.Windows.Forms.Padding(4)
        Me.TextBoxDataTransferDestinationUser.Name = "TextBoxDataTransferDestinationUser"
        Me.TextBoxDataTransferDestinationUser.Size = New System.Drawing.Size(150, 23)
        Me.TextBoxDataTransferDestinationUser.TabIndex = 0
        '
        'ComboBoxDataTransferDestinationUserGainRoleShared
        '
        Me.ComboBoxDataTransferDestinationUserGainRoleShared.BackColor = System.Drawing.SystemColors.Window
        Me.ComboBoxDataTransferDestinationUserGainRoleShared.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBoxDataTransferDestinationUserGainRoleShared.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.ComboBoxDataTransferDestinationUserGainRoleShared.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboBoxDataTransferDestinationUserGainRoleShared.ForeColor = System.Drawing.SystemColors.WindowText
        Me.ComboBoxDataTransferDestinationUserGainRoleShared.FormattingEnabled = True
        Me.ComboBoxDataTransferDestinationUserGainRoleShared.Items.AddRange(New Object() {"None", "Source", "Reader", "Editor"})
        Me.ComboBoxDataTransferDestinationUserGainRoleShared.Location = New System.Drawing.Point(10, 75)
        Me.ComboBoxDataTransferDestinationUserGainRoleShared.Margin = New System.Windows.Forms.Padding(4)
        Me.ComboBoxDataTransferDestinationUserGainRoleShared.Name = "ComboBoxDataTransferDestinationUserGainRoleShared"
        Me.ComboBoxDataTransferDestinationUserGainRoleShared.Size = New System.Drawing.Size(113, 24)
        Me.ComboBoxDataTransferDestinationUserGainRoleShared.TabIndex = 2
        '
        'LabelDataTransferScope
        '
        Me.LabelDataTransferScope.AutoSize = True
        Me.LabelDataTransferScope.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelDataTransferScope.Location = New System.Drawing.Point(7, 11)
        Me.LabelDataTransferScope.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LabelDataTransferScope.Name = "LabelDataTransferScope"
        Me.LabelDataTransferScope.Size = New System.Drawing.Size(46, 16)
        Me.LabelDataTransferScope.TabIndex = 0
        Me.LabelDataTransferScope.Text = "Scope"
        '
        'ComboBoxDataTransferScope
        '
        Me.ComboBoxDataTransferScope.BackColor = System.Drawing.SystemColors.Window
        Me.ComboBoxDataTransferScope.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBoxDataTransferScope.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.ComboBoxDataTransferScope.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboBoxDataTransferScope.ForeColor = System.Drawing.SystemColors.WindowText
        Me.ComboBoxDataTransferScope.FormattingEnabled = True
        Me.ComboBoxDataTransferScope.Items.AddRange(New Object() {"All", "Folder", "All But Folder"})
        Me.ComboBoxDataTransferScope.Location = New System.Drawing.Point(10, 34)
        Me.ComboBoxDataTransferScope.Margin = New System.Windows.Forms.Padding(4)
        Me.ComboBoxDataTransferScope.Name = "ComboBoxDataTransferScope"
        Me.ComboBoxDataTransferScope.Size = New System.Drawing.Size(104, 24)
        Me.ComboBoxDataTransferScope.TabIndex = 1
        '
        'TextBoxDataTransferDocumentID
        '
        Me.TextBoxDataTransferDocumentID.Location = New System.Drawing.Point(10, 88)
        Me.TextBoxDataTransferDocumentID.Margin = New System.Windows.Forms.Padding(4)
        Me.TextBoxDataTransferDocumentID.Name = "TextBoxDataTransferDocumentID"
        Me.TextBoxDataTransferDocumentID.Size = New System.Drawing.Size(309, 23)
        Me.TextBoxDataTransferDocumentID.TabIndex = 3
        '
        'LabelDataTransferDocumentID
        '
        Me.LabelDataTransferDocumentID.AutoSize = True
        Me.LabelDataTransferDocumentID.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelDataTransferDocumentID.Location = New System.Drawing.Point(7, 68)
        Me.LabelDataTransferDocumentID.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LabelDataTransferDocumentID.Name = "LabelDataTransferDocumentID"
        Me.LabelDataTransferDocumentID.Size = New System.Drawing.Size(150, 16)
        Me.LabelDataTransferDocumentID.TabIndex = 2
        Me.LabelDataTransferDocumentID.Text = "Document ID of Folder"
        '
        'TabPageCourses
        '
        Me.TabPageCourses.Controls.Add(Me.ButtonCoursesUsersEdit)
        Me.TabPageCourses.Controls.Add(Me.ButtonCoursesUsersSearch)
        Me.TabPageCourses.Controls.Add(Me.ButtonCoursesCourseIDEdit)
        Me.TabPageCourses.Controls.Add(Me.ButtonCoursesCourseIDSearch)
        Me.TabPageCourses.Controls.Add(Me.TextBoxCoursesUser)
        Me.TabPageCourses.Controls.Add(Me.TextBoxCoursesCourseID)
        Me.TabPageCourses.Controls.Add(Me.LabelCoursesCourseID)
        Me.TabPageCourses.Controls.Add(Me.LabelCoursesUser)
        Me.TabPageCourses.Controls.Add(Me.LabelCoursesScope)
        Me.TabPageCourses.Controls.Add(Me.ComboBoxCoursesScope)
        Me.TabPageCourses.Controls.Add(Me.LabelCoursesAction)
        Me.TabPageCourses.Controls.Add(Me.ComboBoxCoursesAction)
        Me.TabPageCourses.Location = New System.Drawing.Point(4, 25)
        Me.TabPageCourses.Name = "TabPageCourses"
        Me.TabPageCourses.Size = New System.Drawing.Size(730, 127)
        Me.TabPageCourses.TabIndex = 4
        Me.TabPageCourses.Text = "Courses"
        Me.TabPageCourses.UseVisualStyleBackColor = True
        '
        'ButtonCoursesUsersEdit
        '
        Me.ButtonCoursesUsersEdit.Image = Global.GAM4.My.Resources.Resources.edit_16x16
        Me.ButtonCoursesUsersEdit.Location = New System.Drawing.Point(664, 91)
        Me.ButtonCoursesUsersEdit.Margin = New System.Windows.Forms.Padding(4)
        Me.ButtonCoursesUsersEdit.Name = "ButtonCoursesUsersEdit"
        Me.ButtonCoursesUsersEdit.Size = New System.Drawing.Size(28, 28)
        Me.ButtonCoursesUsersEdit.TabIndex = 10
        Me.ToolTip1.SetToolTip(Me.ButtonCoursesUsersEdit, "Edit")
        Me.ButtonCoursesUsersEdit.UseVisualStyleBackColor = True
        '
        'ButtonCoursesUsersSearch
        '
        Me.ButtonCoursesUsersSearch.Image = CType(resources.GetObject("ButtonCoursesUsersSearch.Image"), System.Drawing.Image)
        Me.ButtonCoursesUsersSearch.Location = New System.Drawing.Point(693, 91)
        Me.ButtonCoursesUsersSearch.Margin = New System.Windows.Forms.Padding(4)
        Me.ButtonCoursesUsersSearch.Name = "ButtonCoursesUsersSearch"
        Me.ButtonCoursesUsersSearch.Size = New System.Drawing.Size(28, 28)
        Me.ButtonCoursesUsersSearch.TabIndex = 11
        Me.ToolTip1.SetToolTip(Me.ButtonCoursesUsersSearch, "Search")
        Me.ButtonCoursesUsersSearch.UseVisualStyleBackColor = True
        '
        'ButtonCoursesCourseIDEdit
        '
        Me.ButtonCoursesCourseIDEdit.Image = Global.GAM4.My.Resources.Resources.edit_16x16
        Me.ButtonCoursesCourseIDEdit.Location = New System.Drawing.Point(664, 31)
        Me.ButtonCoursesCourseIDEdit.Margin = New System.Windows.Forms.Padding(4)
        Me.ButtonCoursesCourseIDEdit.Name = "ButtonCoursesCourseIDEdit"
        Me.ButtonCoursesCourseIDEdit.Size = New System.Drawing.Size(28, 28)
        Me.ButtonCoursesCourseIDEdit.TabIndex = 4
        Me.ToolTip1.SetToolTip(Me.ButtonCoursesCourseIDEdit, "Edit")
        Me.ButtonCoursesCourseIDEdit.UseVisualStyleBackColor = True
        '
        'ButtonCoursesCourseIDSearch
        '
        Me.ButtonCoursesCourseIDSearch.Image = CType(resources.GetObject("ButtonCoursesCourseIDSearch.Image"), System.Drawing.Image)
        Me.ButtonCoursesCourseIDSearch.Location = New System.Drawing.Point(693, 31)
        Me.ButtonCoursesCourseIDSearch.Margin = New System.Windows.Forms.Padding(4)
        Me.ButtonCoursesCourseIDSearch.Name = "ButtonCoursesCourseIDSearch"
        Me.ButtonCoursesCourseIDSearch.Size = New System.Drawing.Size(28, 28)
        Me.ButtonCoursesCourseIDSearch.TabIndex = 5
        Me.ToolTip1.SetToolTip(Me.ButtonCoursesCourseIDSearch, "Search")
        Me.ButtonCoursesCourseIDSearch.UseVisualStyleBackColor = True
        '
        'TextBoxCoursesUser
        '
        Me.TextBoxCoursesUser.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBoxCoursesUser.Location = New System.Drawing.Point(161, 94)
        Me.TextBoxCoursesUser.Name = "TextBoxCoursesUser"
        Me.TextBoxCoursesUser.Size = New System.Drawing.Size(179, 23)
        Me.TextBoxCoursesUser.TabIndex = 9
        '
        'TextBoxCoursesCourseID
        '
        Me.TextBoxCoursesCourseID.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBoxCoursesCourseID.Location = New System.Drawing.Point(90, 34)
        Me.TextBoxCoursesCourseID.Name = "TextBoxCoursesCourseID"
        Me.TextBoxCoursesCourseID.Size = New System.Drawing.Size(250, 23)
        Me.TextBoxCoursesCourseID.TabIndex = 3
        '
        'LabelCoursesCourseID
        '
        Me.LabelCoursesCourseID.AutoSize = True
        Me.LabelCoursesCourseID.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelCoursesCourseID.Location = New System.Drawing.Point(87, 11)
        Me.LabelCoursesCourseID.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LabelCoursesCourseID.Name = "LabelCoursesCourseID"
        Me.LabelCoursesCourseID.Size = New System.Drawing.Size(70, 16)
        Me.LabelCoursesCourseID.TabIndex = 2
        Me.LabelCoursesCourseID.Text = "Course ID"
        '
        'LabelCoursesUser
        '
        Me.LabelCoursesUser.AutoSize = True
        Me.LabelCoursesUser.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelCoursesUser.Location = New System.Drawing.Point(158, 71)
        Me.LabelCoursesUser.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LabelCoursesUser.Name = "LabelCoursesUser"
        Me.LabelCoursesUser.Size = New System.Drawing.Size(36, 16)
        Me.LabelCoursesUser.TabIndex = 8
        Me.LabelCoursesUser.Text = "User"
        '
        'LabelCoursesScope
        '
        Me.LabelCoursesScope.AutoSize = True
        Me.LabelCoursesScope.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelCoursesScope.Location = New System.Drawing.Point(7, 11)
        Me.LabelCoursesScope.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LabelCoursesScope.Name = "LabelCoursesScope"
        Me.LabelCoursesScope.Size = New System.Drawing.Size(46, 16)
        Me.LabelCoursesScope.TabIndex = 0
        Me.LabelCoursesScope.Text = "Scope"
        '
        'ComboBoxCoursesScope
        '
        Me.ComboBoxCoursesScope.BackColor = System.Drawing.SystemColors.Window
        Me.ComboBoxCoursesScope.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBoxCoursesScope.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.ComboBoxCoursesScope.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboBoxCoursesScope.ForeColor = System.Drawing.SystemColors.WindowText
        Me.ComboBoxCoursesScope.FormattingEnabled = True
        Me.ComboBoxCoursesScope.Items.AddRange(New Object() {"Single", "Multiple"})
        Me.ComboBoxCoursesScope.Location = New System.Drawing.Point(10, 34)
        Me.ComboBoxCoursesScope.Margin = New System.Windows.Forms.Padding(4)
        Me.ComboBoxCoursesScope.Name = "ComboBoxCoursesScope"
        Me.ComboBoxCoursesScope.Size = New System.Drawing.Size(73, 24)
        Me.ComboBoxCoursesScope.TabIndex = 1
        '
        'LabelCoursesAction
        '
        Me.LabelCoursesAction.AutoSize = True
        Me.LabelCoursesAction.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelCoursesAction.Location = New System.Drawing.Point(7, 71)
        Me.LabelCoursesAction.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LabelCoursesAction.Name = "LabelCoursesAction"
        Me.LabelCoursesAction.Size = New System.Drawing.Size(49, 16)
        Me.LabelCoursesAction.TabIndex = 6
        Me.LabelCoursesAction.Text = "Action"
        '
        'ComboBoxCoursesAction
        '
        Me.ComboBoxCoursesAction.BackColor = System.Drawing.SystemColors.Window
        Me.ComboBoxCoursesAction.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBoxCoursesAction.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.ComboBoxCoursesAction.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboBoxCoursesAction.ForeColor = System.Drawing.SystemColors.WindowText
        Me.ComboBoxCoursesAction.FormattingEnabled = True
        Me.ComboBoxCoursesAction.Items.AddRange(New Object() {"Get Info", "Show Members", "Archive", "Unarchive", "Assign Owner", "Add Teacher", "Add Student", "Remove Teacher", "Remove Student", "Add Students", "Remove Students"})
        Me.ComboBoxCoursesAction.Location = New System.Drawing.Point(10, 94)
        Me.ComboBoxCoursesAction.Margin = New System.Windows.Forms.Padding(4)
        Me.ComboBoxCoursesAction.Name = "ComboBoxCoursesAction"
        Me.ComboBoxCoursesAction.Size = New System.Drawing.Size(144, 24)
        Me.ComboBoxCoursesAction.TabIndex = 7
        '
        'TabPageUserReport
        '
        Me.TabPageUserReport.Controls.Add(Me.GroupBoxUserReportFilters)
        Me.TabPageUserReport.Controls.Add(Me.GroupBoxUserReportAttributes)
        Me.TabPageUserReport.Location = New System.Drawing.Point(4, 25)
        Me.TabPageUserReport.Name = "TabPageUserReport"
        Me.TabPageUserReport.Size = New System.Drawing.Size(730, 127)
        Me.TabPageUserReport.TabIndex = 5
        Me.TabPageUserReport.Text = "User Report"
        Me.TabPageUserReport.UseVisualStyleBackColor = True
        '
        'GroupBoxUserReportFilters
        '
        Me.GroupBoxUserReportFilters.Controls.Add(Me.CheckBoxUserReportFiltersNeverLoggedIn)
        Me.GroupBoxUserReportFilters.Controls.Add(Me.TextBoxUserReportFiltersLastLogin)
        Me.GroupBoxUserReportFilters.Controls.Add(Me.ComboBoxUserReportFiltersLastLogin)
        Me.GroupBoxUserReportFilters.Controls.Add(Me.LabelUserReportFiltersLastLogin)
        Me.GroupBoxUserReportFilters.Controls.Add(Me.CheckBoxUserReportFiltersLastLogin)
        Me.GroupBoxUserReportFilters.Controls.Add(Me.TextBoxUserReportFiltersStorage)
        Me.GroupBoxUserReportFilters.Controls.Add(Me.ComboBoxUserReportFiltersStorage)
        Me.GroupBoxUserReportFilters.Controls.Add(Me.LabelUserReportFiltersStorage)
        Me.GroupBoxUserReportFilters.Controls.Add(Me.CheckBoxUserReportFiltersStorage)
        Me.GroupBoxUserReportFilters.Controls.Add(Me.TextBoxUserReportFiltersCreated)
        Me.GroupBoxUserReportFilters.Controls.Add(Me.ComboBoxUserReportFiltersCreated)
        Me.GroupBoxUserReportFilters.Controls.Add(Me.LabelUserReportFIltersCreated)
        Me.GroupBoxUserReportFilters.Controls.Add(Me.CheckBoxUserReportFiltersCreated)
        Me.GroupBoxUserReportFilters.Controls.Add(Me.ComboBoxUserReportFiltersArchived)
        Me.GroupBoxUserReportFilters.Controls.Add(Me.CheckBoxUserReportFiltersArchived)
        Me.GroupBoxUserReportFilters.Controls.Add(Me.ComboBoxUserReportFiltersSuspended)
        Me.GroupBoxUserReportFilters.Controls.Add(Me.CheckBoxUserReportFiltersSuspended)
        Me.GroupBoxUserReportFilters.Location = New System.Drawing.Point(262, 14)
        Me.GroupBoxUserReportFilters.Name = "GroupBoxUserReportFilters"
        Me.GroupBoxUserReportFilters.Size = New System.Drawing.Size(456, 101)
        Me.GroupBoxUserReportFilters.TabIndex = 1
        Me.GroupBoxUserReportFilters.TabStop = False
        Me.GroupBoxUserReportFilters.Text = "Filters"
        '
        'CheckBoxUserReportFiltersNeverLoggedIn
        '
        Me.CheckBoxUserReportFiltersNeverLoggedIn.AutoSize = True
        Me.CheckBoxUserReportFiltersNeverLoggedIn.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CheckBoxUserReportFiltersNeverLoggedIn.Location = New System.Drawing.Point(298, 75)
        Me.CheckBoxUserReportFiltersNeverLoggedIn.Name = "CheckBoxUserReportFiltersNeverLoggedIn"
        Me.CheckBoxUserReportFiltersNeverLoggedIn.Size = New System.Drawing.Size(119, 20)
        Me.CheckBoxUserReportFiltersNeverLoggedIn.TabIndex = 16
        Me.CheckBoxUserReportFiltersNeverLoggedIn.Text = "Never Logged In"
        Me.CheckBoxUserReportFiltersNeverLoggedIn.UseVisualStyleBackColor = True
        '
        'TextBoxUserReportFiltersLastLogin
        '
        Me.TextBoxUserReportFiltersLastLogin.Enabled = False
        Me.TextBoxUserReportFiltersLastLogin.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBoxUserReportFiltersLastLogin.Location = New System.Drawing.Point(136, 74)
        Me.TextBoxUserReportFiltersLastLogin.Name = "TextBoxUserReportFiltersLastLogin"
        Me.TextBoxUserReportFiltersLastLogin.Size = New System.Drawing.Size(40, 23)
        Me.TextBoxUserReportFiltersLastLogin.TabIndex = 10
        '
        'ComboBoxUserReportFiltersLastLogin
        '
        Me.ComboBoxUserReportFiltersLastLogin.BackColor = System.Drawing.SystemColors.Window
        Me.ComboBoxUserReportFiltersLastLogin.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBoxUserReportFiltersLastLogin.Enabled = False
        Me.ComboBoxUserReportFiltersLastLogin.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.ComboBoxUserReportFiltersLastLogin.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboBoxUserReportFiltersLastLogin.ForeColor = System.Drawing.SystemColors.WindowText
        Me.ComboBoxUserReportFiltersLastLogin.FormattingEnabled = True
        Me.ComboBoxUserReportFiltersLastLogin.Items.AddRange(New Object() {">", "<"})
        Me.ComboBoxUserReportFiltersLastLogin.Location = New System.Drawing.Point(87, 73)
        Me.ComboBoxUserReportFiltersLastLogin.Margin = New System.Windows.Forms.Padding(4)
        Me.ComboBoxUserReportFiltersLastLogin.Name = "ComboBoxUserReportFiltersLastLogin"
        Me.ComboBoxUserReportFiltersLastLogin.Size = New System.Drawing.Size(35, 24)
        Me.ComboBoxUserReportFiltersLastLogin.TabIndex = 9
        '
        'LabelUserReportFiltersLastLogin
        '
        Me.LabelUserReportFiltersLastLogin.AutoSize = True
        Me.LabelUserReportFiltersLastLogin.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelUserReportFiltersLastLogin.Location = New System.Drawing.Point(177, 77)
        Me.LabelUserReportFiltersLastLogin.Name = "LabelUserReportFiltersLastLogin"
        Me.LabelUserReportFiltersLastLogin.Size = New System.Drawing.Size(63, 16)
        Me.LabelUserReportFiltersLastLogin.TabIndex = 11
        Me.LabelUserReportFiltersLastLogin.Text = "years ago"
        '
        'CheckBoxUserReportFiltersLastLogin
        '
        Me.CheckBoxUserReportFiltersLastLogin.AutoSize = True
        Me.CheckBoxUserReportFiltersLastLogin.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CheckBoxUserReportFiltersLastLogin.Location = New System.Drawing.Point(6, 75)
        Me.CheckBoxUserReportFiltersLastLogin.Name = "CheckBoxUserReportFiltersLastLogin"
        Me.CheckBoxUserReportFiltersLastLogin.Size = New System.Drawing.Size(83, 20)
        Me.CheckBoxUserReportFiltersLastLogin.TabIndex = 8
        Me.CheckBoxUserReportFiltersLastLogin.Text = "Last Login"
        Me.CheckBoxUserReportFiltersLastLogin.UseVisualStyleBackColor = True
        '
        'TextBoxUserReportFiltersStorage
        '
        Me.TextBoxUserReportFiltersStorage.Enabled = False
        Me.TextBoxUserReportFiltersStorage.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBoxUserReportFiltersStorage.Location = New System.Drawing.Point(136, 22)
        Me.TextBoxUserReportFiltersStorage.Name = "TextBoxUserReportFiltersStorage"
        Me.TextBoxUserReportFiltersStorage.Size = New System.Drawing.Size(40, 23)
        Me.TextBoxUserReportFiltersStorage.TabIndex = 2
        Me.TextBoxUserReportFiltersStorage.Text = "0"
        '
        'ComboBoxUserReportFiltersStorage
        '
        Me.ComboBoxUserReportFiltersStorage.BackColor = System.Drawing.SystemColors.Window
        Me.ComboBoxUserReportFiltersStorage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBoxUserReportFiltersStorage.Enabled = False
        Me.ComboBoxUserReportFiltersStorage.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.ComboBoxUserReportFiltersStorage.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboBoxUserReportFiltersStorage.ForeColor = System.Drawing.SystemColors.WindowText
        Me.ComboBoxUserReportFiltersStorage.FormattingEnabled = True
        Me.ComboBoxUserReportFiltersStorage.Items.AddRange(New Object() {"=", ">", "<"})
        Me.ComboBoxUserReportFiltersStorage.Location = New System.Drawing.Point(87, 21)
        Me.ComboBoxUserReportFiltersStorage.Margin = New System.Windows.Forms.Padding(4)
        Me.ComboBoxUserReportFiltersStorage.Name = "ComboBoxUserReportFiltersStorage"
        Me.ComboBoxUserReportFiltersStorage.Size = New System.Drawing.Size(35, 24)
        Me.ComboBoxUserReportFiltersStorage.TabIndex = 1
        '
        'LabelUserReportFiltersStorage
        '
        Me.LabelUserReportFiltersStorage.AutoSize = True
        Me.LabelUserReportFiltersStorage.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelUserReportFiltersStorage.Location = New System.Drawing.Point(177, 25)
        Me.LabelUserReportFiltersStorage.Name = "LabelUserReportFiltersStorage"
        Me.LabelUserReportFiltersStorage.Size = New System.Drawing.Size(22, 16)
        Me.LabelUserReportFiltersStorage.TabIndex = 3
        Me.LabelUserReportFiltersStorage.Text = "GB"
        '
        'CheckBoxUserReportFiltersStorage
        '
        Me.CheckBoxUserReportFiltersStorage.AutoSize = True
        Me.CheckBoxUserReportFiltersStorage.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CheckBoxUserReportFiltersStorage.Location = New System.Drawing.Point(6, 23)
        Me.CheckBoxUserReportFiltersStorage.Name = "CheckBoxUserReportFiltersStorage"
        Me.CheckBoxUserReportFiltersStorage.Size = New System.Drawing.Size(71, 20)
        Me.CheckBoxUserReportFiltersStorage.TabIndex = 0
        Me.CheckBoxUserReportFiltersStorage.Text = "Storage"
        Me.CheckBoxUserReportFiltersStorage.UseVisualStyleBackColor = True
        '
        'TextBoxUserReportFiltersCreated
        '
        Me.TextBoxUserReportFiltersCreated.Enabled = False
        Me.TextBoxUserReportFiltersCreated.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBoxUserReportFiltersCreated.Location = New System.Drawing.Point(136, 48)
        Me.TextBoxUserReportFiltersCreated.Name = "TextBoxUserReportFiltersCreated"
        Me.TextBoxUserReportFiltersCreated.Size = New System.Drawing.Size(40, 23)
        Me.TextBoxUserReportFiltersCreated.TabIndex = 6
        '
        'ComboBoxUserReportFiltersCreated
        '
        Me.ComboBoxUserReportFiltersCreated.BackColor = System.Drawing.SystemColors.Window
        Me.ComboBoxUserReportFiltersCreated.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBoxUserReportFiltersCreated.Enabled = False
        Me.ComboBoxUserReportFiltersCreated.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.ComboBoxUserReportFiltersCreated.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboBoxUserReportFiltersCreated.ForeColor = System.Drawing.SystemColors.WindowText
        Me.ComboBoxUserReportFiltersCreated.FormattingEnabled = True
        Me.ComboBoxUserReportFiltersCreated.Items.AddRange(New Object() {">", "<"})
        Me.ComboBoxUserReportFiltersCreated.Location = New System.Drawing.Point(87, 47)
        Me.ComboBoxUserReportFiltersCreated.Margin = New System.Windows.Forms.Padding(4)
        Me.ComboBoxUserReportFiltersCreated.Name = "ComboBoxUserReportFiltersCreated"
        Me.ComboBoxUserReportFiltersCreated.Size = New System.Drawing.Size(35, 24)
        Me.ComboBoxUserReportFiltersCreated.TabIndex = 5
        '
        'LabelUserReportFIltersCreated
        '
        Me.LabelUserReportFIltersCreated.AutoSize = True
        Me.LabelUserReportFIltersCreated.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelUserReportFIltersCreated.Location = New System.Drawing.Point(177, 51)
        Me.LabelUserReportFIltersCreated.Name = "LabelUserReportFIltersCreated"
        Me.LabelUserReportFIltersCreated.Size = New System.Drawing.Size(63, 16)
        Me.LabelUserReportFIltersCreated.TabIndex = 7
        Me.LabelUserReportFIltersCreated.Text = "years ago"
        '
        'CheckBoxUserReportFiltersCreated
        '
        Me.CheckBoxUserReportFiltersCreated.AutoSize = True
        Me.CheckBoxUserReportFiltersCreated.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CheckBoxUserReportFiltersCreated.Location = New System.Drawing.Point(6, 49)
        Me.CheckBoxUserReportFiltersCreated.Name = "CheckBoxUserReportFiltersCreated"
        Me.CheckBoxUserReportFiltersCreated.Size = New System.Drawing.Size(71, 20)
        Me.CheckBoxUserReportFiltersCreated.TabIndex = 4
        Me.CheckBoxUserReportFiltersCreated.Text = "Created"
        Me.CheckBoxUserReportFiltersCreated.UseVisualStyleBackColor = True
        '
        'ComboBoxUserReportFiltersArchived
        '
        Me.ComboBoxUserReportFiltersArchived.BackColor = System.Drawing.SystemColors.Window
        Me.ComboBoxUserReportFiltersArchived.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBoxUserReportFiltersArchived.Enabled = False
        Me.ComboBoxUserReportFiltersArchived.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.ComboBoxUserReportFiltersArchived.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboBoxUserReportFiltersArchived.ForeColor = System.Drawing.SystemColors.WindowText
        Me.ComboBoxUserReportFiltersArchived.FormattingEnabled = True
        Me.ComboBoxUserReportFiltersArchived.Items.AddRange(New Object() {"True", "False"})
        Me.ComboBoxUserReportFiltersArchived.Location = New System.Drawing.Point(394, 47)
        Me.ComboBoxUserReportFiltersArchived.Margin = New System.Windows.Forms.Padding(4)
        Me.ComboBoxUserReportFiltersArchived.Name = "ComboBoxUserReportFiltersArchived"
        Me.ComboBoxUserReportFiltersArchived.Size = New System.Drawing.Size(55, 24)
        Me.ComboBoxUserReportFiltersArchived.TabIndex = 15
        '
        'CheckBoxUserReportFiltersArchived
        '
        Me.CheckBoxUserReportFiltersArchived.AutoSize = True
        Me.CheckBoxUserReportFiltersArchived.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CheckBoxUserReportFiltersArchived.Location = New System.Drawing.Point(298, 49)
        Me.CheckBoxUserReportFiltersArchived.Name = "CheckBoxUserReportFiltersArchived"
        Me.CheckBoxUserReportFiltersArchived.Size = New System.Drawing.Size(75, 20)
        Me.CheckBoxUserReportFiltersArchived.TabIndex = 14
        Me.CheckBoxUserReportFiltersArchived.Text = "Archived"
        Me.CheckBoxUserReportFiltersArchived.UseVisualStyleBackColor = True
        '
        'ComboBoxUserReportFiltersSuspended
        '
        Me.ComboBoxUserReportFiltersSuspended.BackColor = System.Drawing.SystemColors.Window
        Me.ComboBoxUserReportFiltersSuspended.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBoxUserReportFiltersSuspended.Enabled = False
        Me.ComboBoxUserReportFiltersSuspended.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.ComboBoxUserReportFiltersSuspended.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboBoxUserReportFiltersSuspended.ForeColor = System.Drawing.SystemColors.WindowText
        Me.ComboBoxUserReportFiltersSuspended.FormattingEnabled = True
        Me.ComboBoxUserReportFiltersSuspended.Items.AddRange(New Object() {"True", "False"})
        Me.ComboBoxUserReportFiltersSuspended.Location = New System.Drawing.Point(394, 21)
        Me.ComboBoxUserReportFiltersSuspended.Margin = New System.Windows.Forms.Padding(4)
        Me.ComboBoxUserReportFiltersSuspended.Name = "ComboBoxUserReportFiltersSuspended"
        Me.ComboBoxUserReportFiltersSuspended.Size = New System.Drawing.Size(55, 24)
        Me.ComboBoxUserReportFiltersSuspended.TabIndex = 13
        '
        'CheckBoxUserReportFiltersSuspended
        '
        Me.CheckBoxUserReportFiltersSuspended.AutoSize = True
        Me.CheckBoxUserReportFiltersSuspended.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CheckBoxUserReportFiltersSuspended.Location = New System.Drawing.Point(298, 23)
        Me.CheckBoxUserReportFiltersSuspended.Name = "CheckBoxUserReportFiltersSuspended"
        Me.CheckBoxUserReportFiltersSuspended.Size = New System.Drawing.Size(89, 20)
        Me.CheckBoxUserReportFiltersSuspended.TabIndex = 12
        Me.CheckBoxUserReportFiltersSuspended.Text = "Suspended"
        Me.CheckBoxUserReportFiltersSuspended.UseVisualStyleBackColor = True
        '
        'GroupBoxUserReportAttributes
        '
        Me.GroupBoxUserReportAttributes.Controls.Add(Me.CheckBoxUserReportAttributesLastLogin)
        Me.GroupBoxUserReportAttributes.Controls.Add(Me.CheckBoxUserReportAttributesCreated)
        Me.GroupBoxUserReportAttributes.Controls.Add(Me.CheckBoxUserReportAttributesStorage)
        Me.GroupBoxUserReportAttributes.Controls.Add(Me.CheckBoxUserReportAttributesArchived)
        Me.GroupBoxUserReportAttributes.Controls.Add(Me.CheckBoxUserReportAttributesSuspended)
        Me.GroupBoxUserReportAttributes.Controls.Add(Me.CheckBoxUserReportAttributesName)
        Me.GroupBoxUserReportAttributes.Location = New System.Drawing.Point(9, 14)
        Me.GroupBoxUserReportAttributes.Name = "GroupBoxUserReportAttributes"
        Me.GroupBoxUserReportAttributes.Size = New System.Drawing.Size(225, 101)
        Me.GroupBoxUserReportAttributes.TabIndex = 0
        Me.GroupBoxUserReportAttributes.TabStop = False
        Me.GroupBoxUserReportAttributes.Text = "Attributes"
        '
        'CheckBoxUserReportAttributesLastLogin
        '
        Me.CheckBoxUserReportAttributesLastLogin.AutoSize = True
        Me.CheckBoxUserReportAttributesLastLogin.Checked = True
        Me.CheckBoxUserReportAttributesLastLogin.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CheckBoxUserReportAttributesLastLogin.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CheckBoxUserReportAttributesLastLogin.Location = New System.Drawing.Point(111, 75)
        Me.CheckBoxUserReportAttributesLastLogin.Name = "CheckBoxUserReportAttributesLastLogin"
        Me.CheckBoxUserReportAttributesLastLogin.Size = New System.Drawing.Size(83, 20)
        Me.CheckBoxUserReportAttributesLastLogin.TabIndex = 5
        Me.CheckBoxUserReportAttributesLastLogin.Text = "Last Login"
        Me.CheckBoxUserReportAttributesLastLogin.UseVisualStyleBackColor = True
        '
        'CheckBoxUserReportAttributesCreated
        '
        Me.CheckBoxUserReportAttributesCreated.AutoSize = True
        Me.CheckBoxUserReportAttributesCreated.Checked = True
        Me.CheckBoxUserReportAttributesCreated.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CheckBoxUserReportAttributesCreated.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CheckBoxUserReportAttributesCreated.Location = New System.Drawing.Point(111, 49)
        Me.CheckBoxUserReportAttributesCreated.Name = "CheckBoxUserReportAttributesCreated"
        Me.CheckBoxUserReportAttributesCreated.Size = New System.Drawing.Size(71, 20)
        Me.CheckBoxUserReportAttributesCreated.TabIndex = 4
        Me.CheckBoxUserReportAttributesCreated.Text = "Created"
        Me.CheckBoxUserReportAttributesCreated.UseVisualStyleBackColor = True
        '
        'CheckBoxUserReportAttributesStorage
        '
        Me.CheckBoxUserReportAttributesStorage.AutoSize = True
        Me.CheckBoxUserReportAttributesStorage.Checked = True
        Me.CheckBoxUserReportAttributesStorage.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CheckBoxUserReportAttributesStorage.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CheckBoxUserReportAttributesStorage.Location = New System.Drawing.Point(111, 23)
        Me.CheckBoxUserReportAttributesStorage.Name = "CheckBoxUserReportAttributesStorage"
        Me.CheckBoxUserReportAttributesStorage.Size = New System.Drawing.Size(71, 20)
        Me.CheckBoxUserReportAttributesStorage.TabIndex = 3
        Me.CheckBoxUserReportAttributesStorage.Text = "Storage"
        Me.CheckBoxUserReportAttributesStorage.UseVisualStyleBackColor = True
        '
        'CheckBoxUserReportAttributesArchived
        '
        Me.CheckBoxUserReportAttributesArchived.AutoSize = True
        Me.CheckBoxUserReportAttributesArchived.Checked = True
        Me.CheckBoxUserReportAttributesArchived.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CheckBoxUserReportAttributesArchived.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CheckBoxUserReportAttributesArchived.Location = New System.Drawing.Point(6, 49)
        Me.CheckBoxUserReportAttributesArchived.Name = "CheckBoxUserReportAttributesArchived"
        Me.CheckBoxUserReportAttributesArchived.Size = New System.Drawing.Size(75, 20)
        Me.CheckBoxUserReportAttributesArchived.TabIndex = 1
        Me.CheckBoxUserReportAttributesArchived.Text = "Archived"
        Me.CheckBoxUserReportAttributesArchived.UseVisualStyleBackColor = True
        '
        'CheckBoxUserReportAttributesSuspended
        '
        Me.CheckBoxUserReportAttributesSuspended.AutoSize = True
        Me.CheckBoxUserReportAttributesSuspended.Checked = True
        Me.CheckBoxUserReportAttributesSuspended.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CheckBoxUserReportAttributesSuspended.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CheckBoxUserReportAttributesSuspended.Location = New System.Drawing.Point(6, 23)
        Me.CheckBoxUserReportAttributesSuspended.Name = "CheckBoxUserReportAttributesSuspended"
        Me.CheckBoxUserReportAttributesSuspended.Size = New System.Drawing.Size(89, 20)
        Me.CheckBoxUserReportAttributesSuspended.TabIndex = 0
        Me.CheckBoxUserReportAttributesSuspended.Text = "Suspended"
        Me.CheckBoxUserReportAttributesSuspended.UseVisualStyleBackColor = True
        '
        'CheckBoxUserReportAttributesName
        '
        Me.CheckBoxUserReportAttributesName.AutoSize = True
        Me.CheckBoxUserReportAttributesName.Checked = True
        Me.CheckBoxUserReportAttributesName.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CheckBoxUserReportAttributesName.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CheckBoxUserReportAttributesName.Location = New System.Drawing.Point(6, 75)
        Me.CheckBoxUserReportAttributesName.Name = "CheckBoxUserReportAttributesName"
        Me.CheckBoxUserReportAttributesName.Size = New System.Drawing.Size(59, 20)
        Me.CheckBoxUserReportAttributesName.TabIndex = 2
        Me.CheckBoxUserReportAttributesName.Text = "Name"
        Me.CheckBoxUserReportAttributesName.UseVisualStyleBackColor = True
        '
        'TabPageAbout
        '
        Me.TabPageAbout.Controls.Add(Me.LabelAboutDescription)
        Me.TabPageAbout.Controls.Add(Me.PictureBoxAboutGAMGUIIcon)
        Me.TabPageAbout.Controls.Add(Me.LabelAboutVersion)
        Me.TabPageAbout.Controls.Add(Me.LinkLabelAboutGAMGUIGitHub)
        Me.TabPageAbout.Controls.Add(Me.LinkLabelAboutGAMGitHub)
        Me.TabPageAbout.Location = New System.Drawing.Point(4, 25)
        Me.TabPageAbout.Name = "TabPageAbout"
        Me.TabPageAbout.Size = New System.Drawing.Size(730, 127)
        Me.TabPageAbout.TabIndex = 6
        Me.TabPageAbout.Text = "About"
        Me.TabPageAbout.UseVisualStyleBackColor = True
        '
        'PictureBoxAboutGAMGUIIcon
        '
        Me.PictureBoxAboutGAMGUIIcon.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBoxAboutGAMGUIIcon.ErrorImage = Global.GAM4.My.Resources.Resources.gamgui_100x100
        Me.PictureBoxAboutGAMGUIIcon.Image = CType(resources.GetObject("PictureBoxAboutGAMGUIIcon.Image"), System.Drawing.Image)
        Me.PictureBoxAboutGAMGUIIcon.InitialImage = CType(resources.GetObject("PictureBoxAboutGAMGUIIcon.InitialImage"), System.Drawing.Image)
        Me.PictureBoxAboutGAMGUIIcon.Location = New System.Drawing.Point(13, 12)
        Me.PictureBoxAboutGAMGUIIcon.Name = "PictureBoxAboutGAMGUIIcon"
        Me.PictureBoxAboutGAMGUIIcon.Size = New System.Drawing.Size(100, 100)
        Me.PictureBoxAboutGAMGUIIcon.TabIndex = 9
        Me.PictureBoxAboutGAMGUIIcon.TabStop = False
        '
        'LabelAboutVersion
        '
        Me.LabelAboutVersion.AutoSize = True
        Me.LabelAboutVersion.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelAboutVersion.Location = New System.Drawing.Point(119, 15)
        Me.LabelAboutVersion.Name = "LabelAboutVersion"
        Me.LabelAboutVersion.Size = New System.Drawing.Size(151, 23)
        Me.LabelAboutVersion.TabIndex = 8
        Me.LabelAboutVersion.Text = "GAM GUI 4.1.1"
        '
        'LabelAboutDescription
        '
        Me.LabelAboutDescription.AutoSize = True
        Me.LabelAboutDescription.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelAboutDescription.Location = New System.Drawing.Point(301, 15)
        Me.LabelAboutDescription.Name = "LabelAboutDescription"
        Me.LabelAboutDescription.Size = New System.Drawing.Size(416, 96)
        Me.LabelAboutDescription.TabIndex = 5
        Me.LabelAboutDescription.Text = resources.GetString("LabelAboutDescription.Text")
        '
        'LinkLabelAboutGAMGitHub
        '
        Me.LinkLabelAboutGAMGitHub.AutoSize = True
        Me.LinkLabelAboutGAMGitHub.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LinkLabelAboutGAMGitHub.Location = New System.Drawing.Point(119, 66)
        Me.LinkLabelAboutGAMGitHub.Name = "LinkLabelAboutGAMGitHub"
        Me.LinkLabelAboutGAMGitHub.Size = New System.Drawing.Size(87, 18)
        Me.LinkLabelAboutGAMGitHub.TabIndex = 6
        Me.LinkLabelAboutGAMGitHub.TabStop = True
        Me.LinkLabelAboutGAMGitHub.Text = "GAM GitHub"
        '
        'LinkLabelAboutGAMGUIGitHub
        '
        Me.LinkLabelAboutGAMGUIGitHub.AutoSize = True
        Me.LinkLabelAboutGAMGUIGitHub.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LinkLabelAboutGAMGUIGitHub.Location = New System.Drawing.Point(119, 45)
        Me.LinkLabelAboutGAMGUIGitHub.Name = "LinkLabelAboutGAMGUIGitHub"
        Me.LinkLabelAboutGAMGUIGitHub.Size = New System.Drawing.Size(118, 18)
        Me.LinkLabelAboutGAMGUIGitHub.TabIndex = 0
        Me.LinkLabelAboutGAMGUIGitHub.TabStop = True
        Me.LinkLabelAboutGAMGUIGitHub.Text = "GAM GUI GitHub"
        '
        'ButtonRun
        '
        Me.ButtonRun.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonRun.ForeColor = System.Drawing.SystemColors.ControlText
        Me.ButtonRun.Location = New System.Drawing.Point(686, 185)
        Me.ButtonRun.Name = "ButtonRun"
        Me.ButtonRun.Size = New System.Drawing.Size(67, 42)
        Me.ButtonRun.TabIndex = 5
        Me.ButtonRun.Text = "Run"
        Me.ToolTip1.SetToolTip(Me.ButtonRun, "Shift + Enter")
        Me.ButtonRun.UseVisualStyleBackColor = True
        '
        'ButtonShowCommand
        '
        Me.ButtonShowCommand.Location = New System.Drawing.Point(552, 185)
        Me.ButtonShowCommand.Name = "ButtonShowCommand"
        Me.ButtonShowCommand.Size = New System.Drawing.Size(128, 42)
        Me.ButtonShowCommand.TabIndex = 4
        Me.ButtonShowCommand.Text = "Show Command"
        Me.ButtonShowCommand.UseVisualStyleBackColor = True
        '
        'ButtonFind
        '
        Me.ButtonFind.Image = CType(resources.GetObject("ButtonFind.Image"), System.Drawing.Image)
        Me.ButtonFind.Location = New System.Drawing.Point(367, 15)
        Me.ButtonFind.Margin = New System.Windows.Forms.Padding(4)
        Me.ButtonFind.Name = "ButtonFind"
        Me.ButtonFind.Size = New System.Drawing.Size(28, 28)
        Me.ButtonFind.TabIndex = 2
        Me.ToolTip1.SetToolTip(Me.ButtonFind, "Find")
        Me.ButtonFind.UseVisualStyleBackColor = True
        '
        'RichTextBox1
        '
        Me.RichTextBox1.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RichTextBox1.Location = New System.Drawing.Point(15, 234)
        Me.RichTextBox1.Margin = New System.Windows.Forms.Padding(4)
        Me.RichTextBox1.Name = "RichTextBox1"
        Me.RichTextBox1.ReadOnly = True
        Me.RichTextBox1.Size = New System.Drawing.Size(738, 314)
        Me.RichTextBox1.TabIndex = 6
        Me.RichTextBox1.Text = ""
        '
        'ButtonCopy
        '
        Me.ButtonCopy.Location = New System.Drawing.Point(423, 185)
        Me.ButtonCopy.Name = "ButtonCopy"
        Me.ButtonCopy.Size = New System.Drawing.Size(54, 42)
        Me.ButtonCopy.TabIndex = 2
        Me.ButtonCopy.Text = "Copy"
        Me.ButtonCopy.UseVisualStyleBackColor = True
        '
        'ComboBoxFind
        '
        Me.ComboBoxFind.BackColor = System.Drawing.SystemColors.Window
        Me.ComboBoxFind.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBoxFind.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.ComboBoxFind.ForeColor = System.Drawing.SystemColors.WindowText
        Me.ComboBoxFind.FormattingEnabled = True
        Me.ComboBoxFind.Items.AddRange(New Object() {"OU", "User", "File", "Group"})
        Me.ComboBoxFind.Location = New System.Drawing.Point(7, 18)
        Me.ComboBoxFind.Margin = New System.Windows.Forms.Padding(4)
        Me.ComboBoxFind.Name = "ComboBoxFind"
        Me.ComboBoxFind.Size = New System.Drawing.Size(80, 24)
        Me.ComboBoxFind.TabIndex = 0
        '
        'TextBoxFind
        '
        Me.TextBoxFind.Location = New System.Drawing.Point(95, 18)
        Me.TextBoxFind.Margin = New System.Windows.Forms.Padding(4)
        Me.TextBoxFind.Name = "TextBoxFind"
        Me.TextBoxFind.Size = New System.Drawing.Size(269, 23)
        Me.TextBoxFind.TabIndex = 1
        '
        'GroupBoxFind
        '
        Me.GroupBoxFind.Controls.Add(Me.ButtonFind)
        Me.GroupBoxFind.Controls.Add(Me.ComboBoxFind)
        Me.GroupBoxFind.Controls.Add(Me.TextBoxFind)
        Me.GroupBoxFind.Location = New System.Drawing.Point(15, 179)
        Me.GroupBoxFind.Name = "GroupBoxFind"
        Me.GroupBoxFind.Size = New System.Drawing.Size(402, 48)
        Me.GroupBoxFind.TabIndex = 1
        Me.GroupBoxFind.TabStop = False
        Me.GroupBoxFind.Text = "Find"
        '
        'ButtonReload
        '
        Me.ButtonReload.Location = New System.Drawing.Point(483, 185)
        Me.ButtonReload.Name = "ButtonReload"
        Me.ButtonReload.Size = New System.Drawing.Size(63, 42)
        Me.ButtonReload.TabIndex = 3
        Me.ButtonReload.Text = "Reload"
        Me.ButtonReload.UseVisualStyleBackColor = True
        '
        'DirectorySearcher1
        '
        Me.DirectorySearcher1.ClientTimeout = System.TimeSpan.Parse("-00:00:01")
        Me.DirectorySearcher1.ServerPageTimeLimit = System.TimeSpan.Parse("-00:00:01")
        Me.DirectorySearcher1.ServerTimeLimit = System.TimeSpan.Parse("-00:00:01")
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(766, 561)
        Me.Controls.Add(Me.ButtonReload)
        Me.Controls.Add(Me.GroupBoxFind)
        Me.Controls.Add(Me.ButtonCopy)
        Me.Controls.Add(Me.RichTextBox1)
        Me.Controls.Add(Me.ButtonRun)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.ButtonShowCommand)
        Me.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MaximizeBox = False
        Me.Name = "Form1"
        Me.ShowIcon = False
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.Text = "GAM GUI"
        Me.TabControl1.ResumeLayout(False)
        Me.TabPageDevices.ResumeLayout(False)
        Me.TabPageDevices.PerformLayout()
        Me.TabPageUsers.ResumeLayout(False)
        Me.TabPageUsers.PerformLayout()
        Me.TabPageFiles.ResumeLayout(False)
        Me.TabPageFiles.PerformLayout()
        Me.TabPageDataTransfer.ResumeLayout(False)
        Me.TabPageDataTransfer.PerformLayout()
        Me.GroupBoxDataTransferSourceUser.ResumeLayout(False)
        Me.GroupBoxDataTransferSourceUser.PerformLayout()
        Me.GroupBoxDataTransferDestinationUser.ResumeLayout(False)
        Me.GroupBoxDataTransferDestinationUser.PerformLayout()
        Me.TabPageCourses.ResumeLayout(False)
        Me.TabPageCourses.PerformLayout()
        Me.TabPageUserReport.ResumeLayout(False)
        Me.GroupBoxUserReportFilters.ResumeLayout(False)
        Me.GroupBoxUserReportFilters.PerformLayout()
        Me.GroupBoxUserReportAttributes.ResumeLayout(False)
        Me.GroupBoxUserReportAttributes.PerformLayout()
        Me.TabPageAbout.ResumeLayout(False)
        Me.TabPageAbout.PerformLayout()
        CType(Me.PictureBoxAboutGAMGUIIcon, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBoxFind.ResumeLayout(False)
        Me.GroupBoxFind.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents TabPageDevices As TabPage
    Friend WithEvents TabPageUsers As TabPage
    Friend WithEvents ComboBoxDevicesScope As ComboBox
    Friend WithEvents ComboBoxDevicesAction As ComboBox
    Friend WithEvents LabelDevicesAction As Label
    Friend WithEvents LabelDevicesScope As Label
    Friend WithEvents ComboBoxDevicesTargetType As ComboBox
    Friend WithEvents LabelDevicesTargetType As Label
    Friend WithEvents TextBoxDevicesTarget As TextBox
    Friend WithEvents LabelDevicesTarget As Label
    Friend WithEvents ButtonDevicesTargetSearch As Button
    Friend WithEvents ToolTip1 As ToolTip
    Friend WithEvents ButtonDevicesTargetEdit As Button
    Friend WithEvents RichTextBox1 As RichTextBox
    Friend WithEvents ComboBoxDevicesDestination As ComboBox
    Friend WithEvents ButtonRun As Button
    Friend WithEvents ButtonShowCommand As Button
    Friend WithEvents ButtonCopy As Button
    Friend WithEvents LabelUsersTarget As Label
    Friend WithEvents TextBoxUsersTarget As TextBox
    Friend WithEvents LabelUsersScope As Label
    Friend WithEvents ComboBoxUsersScope As ComboBox
    Friend WithEvents LabelUsersAction As Label
    Friend WithEvents ComboBoxUsersAction As ComboBox
    Friend WithEvents TabPageFiles As TabPage
    Friend WithEvents ComboBoxFind As ComboBox
    Friend WithEvents TextBoxFind As TextBox
    Friend WithEvents ButtonFind As Button
    Friend WithEvents GroupBoxFind As GroupBox
    Friend WithEvents ButtonUsersTargetEdit As Button
    Friend WithEvents ButtonUsersTargetSearch As Button
    Friend WithEvents LabelDevicesDestination As Label
    Friend WithEvents LabelUsersDestination As Label
    Friend WithEvents ComboBoxUsersDestination As ComboBox
    Friend WithEvents ButtonReload As Button
    Friend WithEvents ComboBoxUsersTarget As ComboBox
    Friend WithEvents LabelFilesTargetUser As Label
    Friend WithEvents LabelFilesUserWithAccess As Label
    Friend WithEvents LabelFilesAction As Label
    Friend WithEvents ComboBoxFilesAction As ComboBox
    Friend WithEvents LabelFilesDocumentID As Label
    Friend WithEvents TabPageDataTransfer As TabPage
    Friend WithEvents TextBoxFilesUserWithAccess As TextBox
    Friend WithEvents TextBoxFilesDocumentID As TextBox
    Friend WithEvents TextBoxFilesTargetUser As TextBox
    Friend WithEvents TextBoxDataTransferDestinationUser As TextBox
    Friend WithEvents TextBoxDataTransferDocumentID As TextBox
    Friend WithEvents TextBoxDataTransferSourceUser As TextBox
    Friend WithEvents LabelDataTransferScope As Label
    Friend WithEvents ComboBoxDataTransferScope As ComboBox
    Friend WithEvents LabelDataTransferDocumentID As Label
    Friend WithEvents LabelDataTransferSourceUserRetainRole As Label
    Friend WithEvents ComboBoxDataTransferSourceUserRetainRole As ComboBox
    Friend WithEvents LabelDataTransferSourceUserRetainRoleShared As Label
    Friend WithEvents ComboBoxDataTransferSourceUserRetainRoleShared As ComboBox
    Friend WithEvents LabelDataTransferDestinationUserGainRoleShared As Label
    Friend WithEvents ComboBoxDataTransferDestinationUserGainRoleShared As ComboBox
    Friend WithEvents GroupBoxDataTransferDestinationUser As GroupBox
    Friend WithEvents GroupBoxDataTransferSourceUser As GroupBox
    Friend WithEvents TabPageCourses As TabPage
    Friend WithEvents TabPageUserReport As TabPage
    Friend WithEvents LabelCoursesUser As Label
    Friend WithEvents LabelCoursesScope As Label
    Friend WithEvents ComboBoxCoursesScope As ComboBox
    Friend WithEvents LabelCoursesAction As Label
    Friend WithEvents ComboBoxCoursesAction As ComboBox
    Friend WithEvents TextBoxCoursesUser As TextBox
    Friend WithEvents TextBoxCoursesCourseID As TextBox
    Friend WithEvents LabelCoursesCourseID As Label
    Friend WithEvents ButtonCoursesCourseIDEdit As Button
    Friend WithEvents ButtonCoursesCourseIDSearch As Button
    Friend WithEvents ButtonCoursesUsersEdit As Button
    Friend WithEvents ButtonCoursesUsersSearch As Button
    Friend WithEvents DirectorySearcher1 As DirectoryServices.DirectorySearcher
    Friend WithEvents ComboBoxUsersGroupDestination As ComboBox
    Friend WithEvents GroupBoxUserReportAttributes As GroupBox
    Friend WithEvents GroupBoxUserReportFilters As GroupBox
    Friend WithEvents CheckBoxUserReportAttributesName As CheckBox
    Friend WithEvents CheckBoxUserReportAttributesCreated As CheckBox
    Friend WithEvents CheckBoxUserReportAttributesStorage As CheckBox
    Friend WithEvents CheckBoxUserReportAttributesArchived As CheckBox
    Friend WithEvents CheckBoxUserReportAttributesSuspended As CheckBox
    Friend WithEvents CheckBoxUserReportAttributesLastLogin As CheckBox
    Friend WithEvents CheckBoxUserReportFiltersSuspended As CheckBox
    Friend WithEvents ComboBoxUserReportFiltersArchived As ComboBox
    Friend WithEvents CheckBoxUserReportFiltersArchived As CheckBox
    Friend WithEvents ComboBoxUserReportFiltersSuspended As ComboBox
    Friend WithEvents TextBoxUserReportFiltersCreated As TextBox
    Friend WithEvents ComboBoxUserReportFiltersCreated As ComboBox
    Friend WithEvents LabelUserReportFIltersCreated As Label
    Friend WithEvents CheckBoxUserReportFiltersCreated As CheckBox
    Friend WithEvents TextBoxUserReportFiltersStorage As TextBox
    Friend WithEvents ComboBoxUserReportFiltersStorage As ComboBox
    Friend WithEvents LabelUserReportFiltersStorage As Label
    Friend WithEvents CheckBoxUserReportFiltersStorage As CheckBox
    Friend WithEvents TextBoxUserReportFiltersLastLogin As TextBox
    Friend WithEvents ComboBoxUserReportFiltersLastLogin As ComboBox
    Friend WithEvents LabelUserReportFiltersLastLogin As Label
    Friend WithEvents CheckBoxUserReportFiltersLastLogin As CheckBox
    Friend WithEvents CheckBoxUserReportFiltersNeverLoggedIn As CheckBox
    Friend WithEvents TabPageAbout As TabPage
    Friend WithEvents LinkLabelAboutGAMGUIGitHub As LinkLabel
    Friend WithEvents LabelAboutDescription As Label
    Friend WithEvents LinkLabelAboutGAMGitHub As LinkLabel
    Friend WithEvents PictureBoxAboutGAMGUIIcon As PictureBox
    Friend WithEvents LabelAboutVersion As Label
End Class
