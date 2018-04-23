Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports DevExpress.ExpressApp.Win

Imports CustomFunctionCriteriaOperatorVB.Module
Imports DevExpress.Data.Filtering
Imports DevExpress.Persistent.Base
Imports DevExpress.ExpressApp.Security
Imports DevExpress.ExpressApp


Partial Public Class CustomFunctionCriteriaOperatorVBWindowsFormsApplication
	Inherits WinApplication
	Public Sub New()
		InitializeComponent()
        DelayedViewItemsInitialization = True
	End Sub

	Private Sub CustomFunctionCriteriaOperatorVBWindowsFormsApplication_DatabaseVersionMismatch(ByVal sender As Object, ByVal e As DevExpress.ExpressApp.DatabaseVersionMismatchEventArgs) Handles MyBase.DatabaseVersionMismatch
        e.Updater.Update()
        e.Handled = True
    End Sub

    Private Sub CustomFunctionCriteriaOperatorVBWindowsFormsApplication_LastLogonParametersRead(ByVal sender As System.Object, ByVal e As DevExpress.ExpressApp.LastLogonParametersReadEventArgs) Handles MyBase.LastLogonParametersRead
        ' Just to read demo user name for logon.
        Dim logonParameters As AuthenticationStandardLogonParameters = TryCast(e.LogonObject, AuthenticationStandardLogonParameters)
        If logonParameters IsNot Nothing Then
            If String.IsNullOrEmpty(logonParameters.UserName) Then
                logonParameters.UserName = "Sam"
            End If
        End If
    End Sub
End Class
