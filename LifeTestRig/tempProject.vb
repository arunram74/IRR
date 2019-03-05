Public Class TempProject
    Public MachineName As String
    Public HeadName As String

    Public ProjectID As String
    Public ProjectIDTxt As String
    Public ProjectOwner As String
    Public ProjectName As String
    Public BearingCount As Integer
    Public BearingType As String
    Public MachineSize As Integer
    Public CupNo As String
    Public ConeNo As String
    Public PVNo As String
    Public TestType As String
    Public B1Name As Integer
    Public B2Name As Integer
    Public B3Name As Integer
    Public B4Name As Integer


    Friend Vibration As SingleLimits
    Friend OutTankTemp As SingleLimits
    Friend InTankTemp As SingleLimits
    Friend Load As SingleLimits
    Friend Speed As SingleLimits
    Public MaxRev As Double
    Public MaxRevActive As Boolean



    Public RunLogRate As TimeSpan
    Public LoadLogRate As TimeSpan
    Public DispUpdateRate As TimeSpan


    Friend B1, B2, B3, B4 As SingleLimits

    Public isPrjDataAvailable As Boolean = False
    Public isParamDataAvailable As Boolean = False
    Public isBearingDataAvailable As Boolean = False   'complete filling 1st page, then goto next

    Public LoadDuration As TimeSpan 'Update these values
    Public RunDuration As TimeSpan

    Public NoOfLoadSteps As Integer = 0

End Class
