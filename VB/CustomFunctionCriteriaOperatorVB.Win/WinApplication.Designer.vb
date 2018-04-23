Imports Microsoft.VisualBasic
Imports System

Partial Public Class CustomFunctionCriteriaOperatorVBWindowsFormsApplication
	''' <summary> 
	''' Required designer variable.
	''' </summary>
	Private components As System.ComponentModel.IContainer = Nothing

	''' <summary> 
	''' Clean up any resources being used.
	''' </summary>
	''' <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
	Protected Overrides Sub Dispose(ByVal disposing As Boolean)
		If disposing AndAlso (Not components Is Nothing) Then
			components.Dispose()
		End If
		MyBase.Dispose(disposing)
	End Sub

#Region "Component Designer generated code"

	''' <summary> 
	''' Required method for Designer support - do not modify 
	''' the contents of this method with the code editor.
	''' </summary>
	Private Sub InitializeComponent()
        Me.module1 = New DevExpress.ExpressApp.SystemModule.SystemModule
        Me.module2 = New DevExpress.ExpressApp.Win.SystemModule.SystemWindowsFormsModule
        Me.module5 = New DevExpress.ExpressApp.Validation.ValidationModule
        Me.module6 = New DevExpress.ExpressApp.Objects.BusinessClassLibraryCustomizationModule
        Me.module7 = New DevExpress.ExpressApp.Validation.Win.ValidationWindowsFormsModule
        Me.securityModule1 = New DevExpress.ExpressApp.Security.SecurityModule
        Me.CustomFunctionCriteriaOperatorVBModule1 = New CustomFunctionCriteriaOperatorVB.[Module].CustomFunctionCriteriaOperatorVBModule
        Me.module3 = New CustomFunctionCriteriaOperatorVB.[Module].CustomFunctionCriteriaOperatorVBModule
        Me.SecurityStrategyComplex1 = New DevExpress.ExpressApp.Security.SecurityStrategyComplex
        Me.AuthenticationStandard1 = New DevExpress.ExpressApp.Security.AuthenticationStandard
        Me.CustomFunctionCriteriaOperatorVBModule2 = New CustomFunctionCriteriaOperatorVB.[Module].CustomFunctionCriteriaOperatorVBModule
        Me.module4 = New CustomFunctionCriteriaOperatorVB.[Module].Win.CustomFunctionCriteriaOperatorVBWindowsFormsModule
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
        'CustomFunctionCriteriaOperatorVBWindowsFormsApplication
        '
        Me.ApplicationName = "CustomFunctionCriteriaOperatorVB"
        Me.Modules.Add(Me.module1)
        Me.Modules.Add(Me.module2)
        Me.Modules.Add(Me.module6)
        Me.Modules.Add(Me.securityModule1)
        Me.Modules.Add(Me.module3)
        Me.Modules.Add(Me.module4)
        Me.Modules.Add(Me.module5)
        Me.Modules.Add(Me.module7)
        Me.Security = Me.SecurityStrategyComplex1
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub

#End Region

	Private module1 As DevExpress.ExpressApp.SystemModule.SystemModule
    Private module2 As DevExpress.ExpressApp.Win.SystemModule.SystemWindowsFormsModule
	Private module3 As Global.CustomFunctionCriteriaOperatorVB.Module.CustomFunctionCriteriaOperatorVBModule
	Private module4 As Global.CustomFunctionCriteriaOperatorVB.Module.Win.CustomFunctionCriteriaOperatorVBWindowsFormsModule
	Private module5 As DevExpress.ExpressApp.Validation.ValidationModule
    Private module6 As DevExpress.ExpressApp.Objects.BusinessClassLibraryCustomizationModule
    Private module7 As DevExpress.ExpressApp.Validation.Win.ValidationWindowsFormsModule
    Private securityModule1 As DevExpress.ExpressApp.Security.SecurityModule
    Friend WithEvents SecurityStrategyComplex1 As DevExpress.ExpressApp.Security.SecurityStrategyComplex
    Friend WithEvents AuthenticationStandard1 As DevExpress.ExpressApp.Security.AuthenticationStandard
    Friend WithEvents CustomFunctionCriteriaOperatorVBModule1 As CustomFunctionCriteriaOperatorVB.Module.CustomFunctionCriteriaOperatorVBModule
    Friend WithEvents CustomFunctionCriteriaOperatorVBModule2 As CustomFunctionCriteriaOperatorVB.Module.CustomFunctionCriteriaOperatorVBModule
End Class
