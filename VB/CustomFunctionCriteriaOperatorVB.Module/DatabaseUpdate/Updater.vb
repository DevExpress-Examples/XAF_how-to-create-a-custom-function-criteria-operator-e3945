Imports System
Imports System.Security.Principal

Imports DevExpress.Persistent.BaseImpl
Imports DevExpress.Persistent.Base.Security
Imports DevExpress.ExpressApp
Imports DevExpress.ExpressApp.Security
Imports DevExpress.ExpressApp.Updating
Imports DevExpress.Xpo
Imports DevExpress.Data.Filtering

Public Class Updater
    Inherits DevExpress.ExpressApp.Updating.ModuleUpdater
    Public Sub New(ByVal objectSpace As IObjectSpace, ByVal currentDBVersion As Version)
        MyBase.New(objectSpace, currentDBVersion)
    End Sub

    Public Overrides Sub UpdateDatabaseAfterUpdateSchema()
        MyBase.UpdateDatabaseAfterUpdateSchema()
        CreateAnonymousAccess()

        If ObjectSpace.CreateCollection(GetType(Company)).Count = 0 Then

            Dim adminRole As SecurityRole = ObjectSpace.FindObject(Of SecurityRole)(New BinaryOperator("Name", "Administrators"))
            If adminRole Is Nothing Then
                adminRole = ObjectSpace.CreateObject(Of SecurityRole)()
                adminRole.Name = "Administrators"
            End If
            Dim userRole As SecurityRole = ObjectSpace.FindObject(Of SecurityRole)(New BinaryOperator("Name", "Users"))
            If userRole Is Nothing Then
                userRole = ObjectSpace.CreateObject(Of SecurityRole)()
                userRole.Name = "Users"
            End If
            Do While adminRole.PersistentPermissions.Count > 0
                ObjectSpace.Delete(adminRole.PersistentPermissions(0))
            Loop
            Do While userRole.PersistentPermissions.Count > 0
                ObjectSpace.Delete(userRole.PersistentPermissions(0))
            Loop
            adminRole.Permissions.GrantRecursive(GetType(Object), SecurityOperations.FullAccess)
            adminRole.CanEditModel = True
            adminRole.Save()

            userRole.BeginUpdate()
            userRole.Permissions.GrantRecursive(GetType(Object), SecurityOperations.FullAccess)
            userRole.Permissions.DenyRecursive(GetType(SecurityUser), SecurityOperations.ModificationAccess)
            userRole.Permissions.DenyRecursive(GetType(SecurityRole), SecurityOperations.FullAccess)
            userRole.Permissions.DenyRecursive(GetType(PermissionDescriptorBase), SecurityOperations.FullAccess)
            userRole.Permissions.DenyRecursive(GetType(IPermissionData), SecurityOperations.FullAccess)
            userRole.Permissions.DenyRecursive(GetType(TypePermissionDetails), SecurityOperations.FullAccess)
            userRole.CanEditModel = False
            userRole.EndUpdate()
            userRole.Save()

            Dim admin As Employee = ObjectSpace.CreateObject(Of Employee)()
            admin.UserName = "Administrator"
            admin.SetPassword("")
            admin.Roles.Add(adminRole)
            admin.Save()

            Dim company1 As Company = ObjectSpace.CreateObject(Of Company)()
            company1.Name = "Company 1"
            company1.Employees.Add(admin)
            company1.Save()

            Dim user As Employee = ObjectSpace.CreateObject(Of Employee)()
            user.UserName = "Sam"
            user.SetPassword("")
            user.Roles.Add(userRole)
            user.Save()

            Dim user2 As Employee = ObjectSpace.CreateObject(Of Employee)()
            user2.UserName = "John"
            user2.SetPassword("")
            user2.Roles.Add(userRole)
            user2.Save()

            Dim company2 As Company = ObjectSpace.CreateObject(Of Company)()
            company2.Name = "Company 2"
            company2.Employees.Add(user)
            company2.Employees.Add(user2)
            company2.Save()
        End If

    End Sub
    Private Sub CreateAnonymousAccess()
        Dim anonymousRole As SecurityRole = ObjectSpace.FindObject(Of SecurityRole)(New BinaryOperator("Name", SecurityStrategy.AnonymousUserName))
        If anonymousRole Is Nothing Then
            anonymousRole = ObjectSpace.CreateObject(Of SecurityRole)()
            anonymousRole.Name = SecurityStrategy.AnonymousUserName
            anonymousRole.BeginUpdate()
            anonymousRole.Permissions(GetType(SecurityUser)).Grant(SecurityOperations.Read)
            anonymousRole.EndUpdate()
            anonymousRole.Save()
        End If

        Dim anonymousUser As SecurityUser = ObjectSpace.FindObject(Of SecurityUser)(New BinaryOperator("UserName", SecurityStrategy.AnonymousUserName))
        If anonymousUser Is Nothing Then
            anonymousUser = ObjectSpace.CreateObject(Of SecurityUser)()
            anonymousUser.UserName = SecurityStrategy.AnonymousUserName
            anonymousUser.IsActive = True
            anonymousUser.SetPassword("")
            anonymousUser.Roles.Add(anonymousRole)
            anonymousUser.Save()
        End If
    End Sub
End Class
