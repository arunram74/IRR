Imports IRR.Bulb
Public Class HeadDisplay

    Dim m_LedRun, m_LedIdle, m_LedLoad, m_LedStop As LedBulb
    Dim m_lblStatus, m_lblBearningNo As Label
    Dim m_chkHeadActive As CheckBox
    Dim m_TransPic As TransPic
    Public HeadName As String

    Public MyBasePanel As Panel
    Public MyBottomPanel As Panel

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
                   lblBearingNo As Label,
                   chkHeadActive As CheckBox,
                   trnsPic As TransPic,
                   BasePanel As Panel,
                   BottomPanel As Panel,
                   HeadNameStr As String)

        m_LedRun = ledRun
        m_LedIdle = ledIdle
        m_LedLoad = ledLoad
        m_LedStop = ledStop
        m_lblStatus = lblStatus
        m_lblBearningNo = lblBearingNo
        m_chkHeadActive = chkHeadActive
        m_TransPic = trnsPic
        HeadName = HeadNameStr


        MyBasePanel = BasePanel
        MyBottomPanel = BottomPanel

        m_TransPic.Top = 0
        m_TransPic.Left = 0
        m_TransPic.Width = BasePanel.Width
        m_TransPic.Height = BasePanel.Height



        AddHandler m_TransPic.Click, AddressOf TranPicEvent
        AddHandler m_chkHeadActive.Click, AddressOf chkBoxEvent


        Status = Station.MC.myProj.MyStatus

        Select Case HeadName
            Case "A"
                m_lblBearningNo.Text = Station.MC.myProj.HeadA
                m_chkHeadActive.Checked = Station.MC.myProj.HeadA_Enable
            Case "B"
                m_lblBearningNo.Text = Station.MC.myProj.HeadB
                m_chkHeadActive.Checked = Station.MC.myProj.HeadB_Enable
            Case "C"
                m_lblBearningNo.Text = Station.MC.myProj.HeadC
                m_chkHeadActive.Checked = Station.MC.myProj.HeadC_Enable
            Case "D"
                m_lblBearningNo.Text = Station.MC.myProj.HeadD
                m_chkHeadActive.Checked = Station.MC.myProj.HeadD_Enable
        End Select


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
                Case ProjectCls.ProjectStatus.Disabled
                    m_LedRun.On = False
                    m_lblStatus.Text = "Disabled"
                    m_lblStatus.BackColor = Color.Bisque
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

    Public Property Selected As Boolean
        Get
            Selected = m_TransPic.Selected
        End Get
        Set(value As Boolean)
            m_TransPic.Selected = value
            If value And Not m_chkHeadActive.Checked Then MyBasePanel.BackColor = Color.DarkGray Else MyBasePanel.BackColor = SystemColors.Control
            If value And Not m_chkHeadActive.Checked Then MyBottomPanel.BackColor = Color.DarkGray Else MyBottomPanel.BackColor = SystemColors.Control

            If value And m_chkHeadActive.Checked Then MyBasePanel.BackColor = Color.PowderBlue ' Else MyBasePanel.BackColor = SystemColors.Control
            If value And m_chkHeadActive.Checked Then MyBottomPanel.BackColor = Color.PowderBlue 'Else MyBottomPanel.BackColor = SystemColors.Control

        End Set
    End Property

    Private Sub TranPicEvent(sender As Object, e As EventArgs)
        RaiseEvent Click(Me, e)
    End Sub

    Private Sub chkBoxEvent(sender As Object, e As EventArgs)

        If m_Status <> ProjectCls.ProjectStatus.Run And m_Status <> ProjectCls.ProjectStatus.Load Then
            m_chkHeadActive.Checked = Not m_chkHeadActive.Checked
            Selected = True
            Select Case HeadName
                Case "A"
                    Station.MC.myProj.HeadA_Enable = m_chkHeadActive.Checked
                Case "B"
                    Station.MC.myProj.HeadB_Enable = m_chkHeadActive.Checked
                Case "C"
                    Station.MC.myProj.HeadC_Enable = m_chkHeadActive.Checked
                Case "D"
                    Station.MC.myProj.HeadD_Enable = m_chkHeadActive.Checked
            End Select
        End If
    End Sub

    Private Sub Tmr_Tick(sender As Object, e As EventArgs) Handles Tmr.Tick
        Status = Station.MC.myProj.MyStatus
        If Not Station.MC.myProj.ProjectID = 0 Then

            Select Case HeadName
                Case "A"
                    m_lblBearningNo.Text = Station.MC.myProj.HeadA
                    m_chkHeadActive.Checked = Station.MC.myProj.HeadA_Enable
                    If Not Station.MC.myProj.HeadA_Enable Then Status = ProjectCls.ProjectStatus.Disabled
                Case "B"
                    m_lblBearningNo.Text = Station.MC.myProj.HeadB
                    m_chkHeadActive.Checked = Station.MC.myProj.HeadB_Enable
                    If Not Station.MC.myProj.HeadB_Enable Then Status = ProjectCls.ProjectStatus.Disabled

                Case "C"
                    m_lblBearningNo.Text = Station.MC.myProj.HeadC
                    m_chkHeadActive.Checked = Station.MC.myProj.HeadC_Enable
                    If Not Station.MC.myProj.HeadC_Enable Then Status = ProjectCls.ProjectStatus.Disabled

                Case "D"
                    m_lblBearningNo.Text = Station.MC.myProj.HeadD
                    m_chkHeadActive.Checked = Station.MC.myProj.HeadD_Enable
                    If Not Station.MC.myProj.HeadD_Enable Then Status = ProjectCls.ProjectStatus.Disabled

            End Select
        Else
            m_lblBearningNo.Text = ""
            '            m_chkHeadActive.Checked = False

        End If




        m_TransPic.BringToFront()
        m_chkHeadActive.BringToFront()

        If MyPrevStatus <> m_Status Then
            RaiseEvent MyStatusChanged(Me)
            MyPrevStatus = m_Status
        End If

    End Sub

    'Private Sub HeadObj_HeadStatusChanged() Handles Station.MC.HeadStatusChanged
    '    RaiseEvent MyStatusChanged(Me)
    'End Sub


End Class
