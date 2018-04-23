Imports System
Imports System.Collections.Generic
Imports DevExpress.ExpressApp
Imports System.Reflection
Imports DevExpress.Persistent.BaseImpl

Partial Public NotInheritable Class [CustomFunctionCriteriaOperatorVBModule]
    Inherits ModuleBase
    Public Sub New()
        InitializeComponent()
        CurrentCompanyOidOperator.Register()
    End Sub
End Class
