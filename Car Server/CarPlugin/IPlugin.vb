Public Interface IPlugin
    Event PluginLoaded(ByVal sender As Object, ByVal PluginName As String)
    ReadOnly Property PluginName As String
    ReadOnly Property PluginVersion As String
    Sub Init()
    Function ProcessCommand(ByVal command As Object)
    Event OnMessage(ByVal message As Object)

End Interface