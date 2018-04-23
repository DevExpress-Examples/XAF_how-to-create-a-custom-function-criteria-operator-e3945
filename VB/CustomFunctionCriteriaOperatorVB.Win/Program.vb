Imports System
Imports System.Configuration
Imports System.Windows.Forms

Imports DevExpress.Persistent.Base
Imports DevExpress.ExpressApp
Imports DevExpress.ExpressApp.Security
Imports DevExpress.ExpressApp.Win

Imports CustomFunctionCriteriaOperatorVB.Win

Public Class Program

    <STAThread()> _
    Public Shared Sub Main(ByVal arguments() As String)
#If EASYTEST Then
              DevExpress.ExpressApp.Win.EasyTest.EasyTestRemotingRegistration.Register()
#End If

        Application.EnableVisualStyles()
        Application.SetCompatibleTextRenderingDefault(False)
        EditModelPermission.AlwaysGranted = System.Diagnostics.Debugger.IsAttached
        Dim _application As CustomFunctionCriteriaOperatorVBWindowsFormsApplication = New CustomFunctionCriteriaOperatorVBWindowsFormsApplication()
        InMemoryDataStoreProvider.Register()
        _application.ConnectionString = InMemoryDataStoreProvider.ConnectionString
        Try
			'Uncomment this line when using the Middle Tier application server:
			'Dim _middleTierClientApplicationConfigurator As DevExpress.ExpressApp.MiddleTier.MiddleTierClientApplicationConfigurator = New DevExpress.ExpressApp.MiddleTier.MiddleTierClientApplicationConfigurator(winApplication)
            _application.Setup()
            _application.Start()
        Catch e As Exception
            _application.HandleException(e)
        End Try

    End Sub
End Class
