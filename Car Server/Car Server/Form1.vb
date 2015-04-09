Imports CarPlugin
Imports System.Reflection
Imports System.Security.Permissions
<PermissionSet(SecurityAction.Demand, Name:="FullTrust")> _
<System.Runtime.InteropServices.ComVisibleAttribute(True)> _
Public Class Form1

    Dim loadedPlugins As List(Of IPlugin)

    Public Delegate Sub delPluginLoaded(ByVal sender As Object, ByVal e As EventArgs)
    Public Sub PluginLoaded(ByVal sender As Object, ByVal e As EventArgs)
        Debug.Print("YAY IT WORKED " & CType(sender, IPlugin).PluginName)
    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        loadPlugins()
        displayLoadedPlugins()


    End Sub

    Public Sub pluginLoaded(ByVal sender As Object, ByVal pluginname As String)


        Debug.Print(sender.PluginName & " has been loaded")

    End Sub
    Public Sub loadPlugins()
        For Each plugin As String In FileIO.FileSystem.GetFiles(My.Application.Info.DirectoryPath & "\plugins\", FileIO.SearchOption.SearchTopLevelOnly, "*.dll")
            Try
                If plugin.ToLower.EndsWith("carplugin.dll") Then Continue For

                Dim asm As Assembly = Assembly.LoadFrom(plugin)
                Dim ptype As Type = asm.GetType(asm.GetName.Name & ".Plugin")
                Dim loadedPlugin As CarPlugin.IPlugin = CType(Activator.CreateInstance(ptype), IPlugin)
                loadedPlugins.Add(loadedPlugin)
                AddHandler loadedPlugin.OnMessage, AddressOf onmessage


            Catch ex As Exception
                MsgBox(ex.Message.ToString)

            End Try


        Next
    End Sub
    Public Sub displayLoadedPlugins()
        ListBox1.Items.Clear()
        For Each plugin As IPlugin In loadedPlugins
            ListBox1.Items.Add(plugin.PluginName.PadRight(40, " ") & plugin.PluginVersion & vbTab & Assembly.GetAssembly(plugin.GetType).Location)





        Next
    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        loadedPlugins = New List(Of IPlugin)

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        MsgBox(loadedPlugins.Item(0).ProcessCommand(New Object() {"sup"}))


    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click

    End Sub

    Private Sub ListBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListBox1.SelectedIndexChanged

    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Dim x As Form = DirectCast(loadedPlugins.Item(0).ProcessCommand(New Object() {}), Form)

        x.Show()

    End Sub

    Private Sub onmessage(ByVal message As Object)
        MsgBox(message(0))

    End Sub

End Class
