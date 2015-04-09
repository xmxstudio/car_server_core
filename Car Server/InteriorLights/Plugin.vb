Imports System.Windows.Forms

Public Class Plugin
    Implements CarPlugin.IPlugin
    Dim _pluginName As String = "Interior Lights Control"
    Dim _pluginVersion As String = "1.0"


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
        Dim f As New Form
        f.Text = "Interior Lights"
        f.Dock = DockStyle.Fill
        f.BackColor = Drawing.Color.DarkGray
        Dim lbl As New Label
        lbl.Text = "CONTROL YOUR STUPID LIGHTS!!!!"
        lbl.AutoSize = 1
        lbl.Location = New System.Drawing.Point(20, 20)
        lbl.Font = New System.Drawing.Font("Verdana", 14, Drawing.FontStyle.Regular, Drawing.GraphicsUnit.Point)
        AddHandler lbl.Click, AddressOf clickLabel
        f.Controls.Add(lbl)
        Return f

    End Function


    Public Sub clickLabel()
        RaiseEvent OnMessage(New String() {"HI THERE YOU CLICKED THE LABEL ON INTERIOR LIGHTS CONTROL"})

    End Sub
End Class
