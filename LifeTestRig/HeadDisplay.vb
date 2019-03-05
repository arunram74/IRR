Imports LifeTestRig.Bulb
Public Class HeadDisplay

    Dim m_LedRun, m_LedIdle, m_LedLoad, m_LedStop As LedBulb
    Dim m_lblStatus, m_lblPrjName, m_lblCup, m_lblCone, m_lblCreateDtTime, m_lblHead As Label
    Dim m_TransPic As TransPic
    Public MaChineSet As Integer

    Public MyBasePanel As Panel

    Public WithEvents HeadObj As HeadCls
    Public IsPairBonded As Boolean

    Dim WithEvents Tmr As Timer = New Timer

    Public Event Click(sender As HeadDisplay, e As EventArgs)

    Public Event MyStatusChanged(sender As HeadDisplay)

    'Public Enum MyStatus
    '    isRun
    '    isIdle
    '    isStopped
    '    isLoad
    '    isNone
    'End Enum
    Dim m_Status As ProjectCls.ProjectStatus
    Dim MyPrevStatus As ProjectCls.ProjectStatus = ProjectCls.ProjectStatus.Idle

    Public Sub New(ledRun As LedBulb,
                   ledIdle As LedBulb,
                   ledLoad As LedBulb,
                   ledStop As LedBulb,
                   lblStatus As Label,
                   lblPrjName As Label,
                   lblCup As Label,
                   lblCone As Label,
                   lblCreateDtTime As Label,
                   lblHead As Label,
                   trnsPic As TransPic,
                   BasePanel As Panel,
                   Head As HeadCls,
                                   MCSet As Integer)

        m_LedRun = ledRun
        m_LedIdle = ledIdle
        m_LedLoad = ledLoad
        m_LedStop = ledStop
        m_lblStatus = lblStatus
        m_lblPrjName = lblPrjName
        m_lblCup = lblCup
        m_lblCone = lblCone
        m_lblCreateDtTime = lblCreateDtTime
        m_lblHead = lblHead
        m_TransPic = trnsPic
        MaChineSet = MCSet


        MyBasePanel = BasePanel

        m_TransPic.Top = 0
        m_TransPic.Left = 0
        m_TransPic.Width = BasePanel.Width
        m_TransPic.Height = BasePanel.Height

        HeadObj = Head


        AddHandler m_TransPic.Click, AddressOf TranPicEvent


        Status = HeadObj.myProj.MyStatus
        If Not HeadObj.myProj.ProjectID = 0 Then
            m_lblPrjName.Text = HeadObj.myProj.ProjectIDTxt & "_" & HeadObj.myProj.B1Name & "_" & HeadObj.myProj.B2Name & "_" & HeadObj.myProj.B3Name & "_" & HeadObj.myProj.B4Name
        Else
            m_lblPrjName.Text = ""
        End If
        m_lblCup.Text = HeadObj.myProj.CupNo
        m_lblCone.Text = HeadObj.myProj.ConeNo
        m_lblCreateDtTime.Text = HeadObj.myProj.CreatedDate
        m_lblHead.Text = HeadObj.myProj.HeadName

        Tmr.Interval = 2000
        Tmr.Enabled = True

    End Sub

    Public Property Status As ProjectCls.ProjectStatus
        Get
            Status = m_Status
        End Get
        Set(value As ProjectCls.ProjectStatus)
            m_Status = value
            Select Case m_Status
                Case ProjectCls.ProjectStatus.Run
                    m_LedRun.On = True
                    m_lblStatus.Text = "Run"
                    m_lblStatus.BackColor = Color.GreenYellow
                    m_LedIdle.On = False
                    m_LedLoad.On = False
                    m_LedStop.On = False
                Case ProjectCls.ProjectStatus.Idle
                    m_LedRun.On = False
                    m_lblStatus.Text = "Idle"
                    m_lblStatus.BackColor = Color.OrangeRed
                    m_LedIdle.On = True
                    m_LedLoad.On = False
                    m_LedStop.On = False
                Case ProjectCls.ProjectStatus.Load
                    m_LedRun.On = False
                    m_lblStatus.Text = "Load"
                    m_lblStatus.BackColor = Color.Cyan
                    m_LedIdle.On = False
                    m_LedLoad.On = True
                    m_LedStop.On = False
                Case ProjectCls.ProjectStatus.Suspended
                    m_LedRun.On = False
                    m_lblStatus.Text = "Suspended"
                    m_lblStatus.BackColor = Color.Orange
                    m_LedIdle.On = False
                    m_LedLoad.On = False
                    m_LedStop.On = True
                Case ProjectCls.ProjectStatus.Started
                    m_LedRun.On = False
                    m_lblStatus.Text = "Starting"
                    m_lblStatus.BackColor = SystemColors.Control
                    m_LedIdle.On = False
                    m_LedLoad.On = False
                    m_LedStop.On = False
                Case Else
                    m_LedRun.On = False
                    m_lblStatus.Text = "Indeterminate"
                    m_lblStatus.BackColor = SystemColors.Control
                    m_LedIdle.On = False
                    m_LedLoad.On = False
                    m_LedStop.On = False
            End Select
        End Set
    End Property

    Public WriteOnly Property ProjectName As String
        Set(value As String)
            m_lblPrjName.Text = value
        End Set
    End Property

    Public WriteOnly Property Cup As String
        Set(value As String)
            m_lblCup.Text = value
        End Set
    End Property

    Public WriteOnly Property Cone As String
        Set(value As String)
            m_lblCone.Text = value
        End Set
    End Property

    Public WriteOnly Property CreateDateTime As String
        Set(value As String)
            m_lblCreateDtTime.Text = value
        End Set
    End Property

    Public WriteOnly Property HeadName As String
        Set(value As String)
            m_lblHead.Text = value
        End Set
    End Property

    Public Property Selected As Boolean
        Get
            Selected = m_TransPic.Selected
        End Get
        Set(value As Boolean)
            m_TransPic.Selected = value
            If value Then MyBasePanel.BackColor = Color.DarkGray Else MyBasePanel.BackColor = SystemColors.Control
        End Set
    End Property

    Private Sub TranPicEvent(sender As Object, e As EventArgs)
        RaiseEvent Click(Me, e)
    End Sub

    Private Sub Tmr_Tick(sender As Object, e As EventArgs) Handles Tmr.Tick
        Status = HeadObj.myProj.MyStatus
        If Not HeadObj.myProj.ProjectID = 0 Then
            m_lblPrjName.Text = HeadObj.myProj.ProjectIDTxt & "_" & HeadObj.myProj.B1Name & "_" & HeadObj.myProj.B2Name & "_" & HeadObj.myProj.B3Name & "_" & HeadObj.myProj.B4Name
            m_lblCup.Text = HeadObj.myProj.CupNo
            m_lblCone.Text = HeadObj.myProj.ConeNo
        Else
            m_lblPrjName.Text = ""
            m_lblCup.Text = ""
            m_lblCone.Text = ""
        End If

        m_lblCreateDtTime.Text = HeadObj.myProj.CreatedDate
        m_lblHead.Text = HeadObj.myProj.HeadName

        m_TransPic.BringToFront()

        If MyPrevStatus <> m_Status Then
            RaiseEvent MyStatusChanged(Me)
            MyPrevStatus = m_Status
        End If
    End Sub

    'Private Sub HeadObj_HeadStatusChanged() Handles HeadObj.HeadStatusChanged
    '    RaiseEvent MyStatusChanged(Me)
    'End Sub
End Class
