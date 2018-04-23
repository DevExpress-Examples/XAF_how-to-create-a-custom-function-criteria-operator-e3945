Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports DevExpress.ExpressApp.Web

Imports CustomFunctionCriteriaOperatorVB.Module
Imports DevExpress.ExpressApp
Imports DevExpress.Data.Filtering
Imports DevExpress.ExpressApp.Security

Partial Public Class CustomFunctionCriteriaOperatorVBAspNetApplication
	Inherits WebApplication
	Private module1 As DevExpress.ExpressApp.SystemModule.SystemModule
    Private module2 As DevExpress.ExpressApp.Web.SystemModule.SystemAspNetModule
	Private module3 As CustomFunctionCriteriaOperatorVB.Module.CustomFunctionCriteriaOperatorVBModule
	Private module4 As CustomFunctionCriteriaOperatorVB.Module.Web.CustomFunctionCriteriaOperatorVBAspNetModule
	Private module5 As DevExpress.ExpressApp.Validation.ValidationModule
    Private module6 As DevExpress.ExpressApp.Objects.BusinessClassLibraryCustomizationModule
    Private securityModule1 As DevExpress.ExpressApp.Security.SecurityModule
    Friend WithEvents AuthenticationStandard1 As DevExpress.ExpressApp.Security.AuthenticationStandard

    Friend WithEvents SecurityStrategyComplex1 As DevExpress.ExpressApp.Security.SecurityStrategyComplex

	Public Sub New()
		InitializeComponent()
	End Sub

	Private Sub CustomFunctionCriteriaOperatorVBAspNetApplication_DatabaseVersionMismatch(ByVal sender As Object, ByVal e As DevExpress.ExpressApp.DatabaseVersionMismatchEventArgs) Handles MyBase.DatabaseVersionMismatch
        e.Updater.Update()
        e.Handled = True
    End Sub

	Private Sub InitializeComponent()
        Me.module1 = New DevExpress.ExpressApp.SystemModule.SystemModule
        Me.module2 = New DevExpress.ExpressApp.Web.SystemModule.SystemAspNetModule
        Me.module3 = New CustomFunctionCriteriaOperatorVB.[Module].CustomFunctionCriteriaOperatorVBModule
        Me.module4 = New CustomFunctionCriteriaOperatorVB.[Module].Web.CustomFunctionCriteriaOperatorVBAspNetModule
        Me.module5 = New DevExpress.ExpressApp.Validation.ValidationModule
        Me.module6 = New DevExpress.ExpressApp.Objects.BusinessClassLibraryCustomizationModule
        Me.securityModule1 = New DevExpress.ExpressApp.Security.SecurityModule
        Me.SecurityStrategyComplex1 = New DevExpress.ExpressApp.Security.SecurityStrategyComplex
        Me.AuthenticationStandard1 = New DevExpress.ExpressApp.Security.AuthenticationStandard
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'module5
        '
        Me.module5.AllowValidationDetailsAccess = True
        '
        'SecurityStrategyComplex1
        '
        Me.SecurityStrategyComplex1.Authentication = Me.AuthenticationStandard1
        Me.SecurityStrategyComplex1.RoleType = GetType(DevExpress.ExpressApp.Security.SecurityRole)
        Me.SecurityStrategyComplex1.UserType = GetType(DevExpress.ExpressApp.Security.SecurityUser)
        '
        'AuthenticationStandard1
        '
        Me.AuthenticationStandard1.LogonParametersType = GetType(DevExpress.ExpressApp.Security.AuthenticationStandardLogonParameters)
        '
        'CustomFunctionCriteriaOperatorVBAspNetApplication
        '
        Me.ApplicationName = "CustomFunctionCriteriaOperatorVB"
        Me.Modules.Add(Me.module1)
        Me.Modules.Add(Me.module2)
        Me.Modules.Add(Me.module6)
        Me.Modules.Add(Me.securityModule1)
        Me.Modules.Add(Me.module3)
        Me.Modules.Add(Me.module4)
        Me.Modules.Add(Me.module5)
        Me.Security = Me.SecurityStrategyComplex1
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub

    Private Sub CustomFunctionCriteriaOperatorVBAspNetApplication_LastLogonParametersRead(ByVal sender As System.Object, ByVal e As DevExpress.ExpressApp.LastLogonParametersReadEventArgs) Handles MyBase.LastLogonParametersRead
        ' Just to read demo user name for logon.
        Dim logonParameters As AuthenticationStandardLogonParameters = TryCast(e.LogonObject, AuthenticationStandardLogonParameters)
        If logonParameters IsNot Nothing Then
            If String.IsNullOrEmpty(logonParameters.UserName) Then
                logonParameters.UserName = "Sam"
            End If
        End If
    End Sub
End Class

