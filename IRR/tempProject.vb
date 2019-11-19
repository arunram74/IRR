Public Class TempProject
    'Public MachineName As String

    Public ProjectID As String
    Public ProjectIDTxt As String
    Public ProjectOwner As String
    Public TestID As String
    'Public MachineSize As Integer
    Public PartNo As Integer
    Public Make As String
    Public Lubrication As String
    Public HeadA As String
    Public HeadB As String
    Public HeadC As String
    Public HeadD As String

    Public HeadA_Enable As Boolean
    Public HeadB_Enable As Boolean
    Public HeadC_Enable As Boolean
    Public HeadD_Enable As Boolean



    Friend TankTemp As SingleLimits


    Friend Load As SingleLimits
    Friend Speed As SingleLimits
    Public MaxRev As Double
    Public MaxRevActive As Boolean



    Public RunLogRate As TimeSpan
    Public LoadLogRate As TimeSpan
    Public DispUpdateRate As TimeSpan


    Friend BA, SBA, Inlet_TempA, VibrationA As SingleLimits
    Friend BB, SBB, Inlet_TempB, VibrationB As SingleLimits
    Friend BC, SBC, Inlet_TempC, VibrationC As SingleLimits
    Friend BD, SBD, Inlet_TempD, VibrationD As SingleLimits

    Public isPrjDataAvailable As Boolean = False
    Public isParamDataAvailable As Boolean = False
    Public isBearingDataAvailable As Boolean = False   'complete filling 1st page, then goto next

    Public LoadDuration As TimeSpan 'Update these values
    Public RunDuration As TimeSpan

    Public NoOfLoadSteps As Integer = 0

End Class
