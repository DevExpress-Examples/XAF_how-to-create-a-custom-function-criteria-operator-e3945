Imports System.ComponentModel

Imports DevExpress.Xpo
Imports DevExpress.Data.Filtering

Imports DevExpress.ExpressApp
Imports DevExpress.Persistent.Base
Imports DevExpress.Persistent.BaseImpl
Imports DevExpress.Persistent.Validation

Namespace CustomFunctionCriteriaOperator.Module.BusinessObjects
   <DefaultClassOptions, RuleCriteria("", DefaultContexts.Save, "Company.Oid = CurrentCompanyOid()")> _
   Public Class ValidatedObject
	   Inherits BaseObject

	  Public Sub New(ByVal session As Session)
		  MyBase.New(session)
	  End Sub
	  Public Overrides Sub AfterConstruction()
		 MyBase.AfterConstruction()
	  End Sub
'INSTANT VB NOTE: The variable company was renamed since Visual Basic does not allow variables and other class members to have the same name:
	  Private company_Renamed As Company
	  Public Property Company() As Company
		 Get
			Return company_Renamed
		 End Get
		 Set(ByVal value As Company)
			SetPropertyValue("Company", company_Renamed, value)
		 End Set
	  End Property
'INSTANT VB NOTE: The variable name was renamed since Visual Basic does not allow variables and other class members to have the same name:
	  Private name_Renamed As String
	  Public Property Name() As String
		  Get
			  Return name_Renamed
		  End Get
		  Set(ByVal value As String)
			  SetPropertyValue("Name", name_Renamed, value)
		  End Set
	  End Property
   End Class

End Namespace
