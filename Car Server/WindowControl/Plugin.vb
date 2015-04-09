Public Class Plugin
    Implements CarPlugin.IPlugin
    Dim _pluginName As String = "Window Control"
    Dim _pluginVersion As String = "1.1"


    ' INTERIOR LIGHTS CONTROL PLUGIN
    ''' <summary>
    ''' Controls the interior lights. Ability to control each led light independantly, have a disco party for example!
    ''' </summary>
    ''' <remarks>gets window state from core system upon init. </remarks>
#Region "stuff i dont need"
    Public Event PluginLoaded(ByVal sender As Object, ByVal PluginName As String) Implements CarPlugin.IPlugin.PluginLoaded
    Public Event OnMessage(ByVal message As Object) Implements CarPlugin.IPlugin.OnMessage

    Public ReadOnly Property PluginName As String Implements CarPlugin.IPlugin.PluginName
        Get
            Return _pluginName
        End Get
    End Property
    Public ReadOnly Property PluginVersion As String Implements CarPlugin.IPlugin.PluginVersion
        Get
            Return String.Format("Version {0}", _pluginVersion)
        End Get
    End Property
    Public Sub Init() Implements CarPlugin.IPlugin.Init
        RaiseEvent PluginLoaded(Me, PluginName)
    End Sub

#End Region

    Public Function ProcessCommand(ByVal command As Object) As Object Implements CarPlugin.IPlugin.ProcessCommand
        Return "HI from window control, command was processed successfully"

    End Function






End Class
