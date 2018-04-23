using System;

using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Updating;
using DevExpress.Xpo;
using DevExpress.Data.Filtering;
using DevExpress.Persistent.BaseImpl;
using DevExpress.ExpressApp.Security;

using CustomFunctionCriteriaOperator.Module.BusinessObjects;

namespace CustomFunctionCriteriaOperator.Module.DatabaseUpdate {
   public class Updater : ModuleUpdater {
      public Updater(IObjectSpace objectSpace, Version currentDBVersion)
         : base(objectSpace, currentDBVersion) {
      }
      public override void UpdateDatabaseAfterUpdateSchema() {
         base.UpdateDatabaseAfterUpdateSchema();
         CreateAnonymousAccess();

         if (ObjectSpace.CreateCollection(typeof(Company)).Count == 0) {

            SecurityRole adminRole = ObjectSpace.FindObject<SecurityRole>(new BinaryOperator("Name", "Administrators"));
            if (adminRole == null) {
               adminRole = ObjectSpace.CreateObject<SecurityRole>();
               adminRole.Name = "Administrators";
            }
            SecurityRole userRole = ObjectSpace.FindObject<SecurityRole>(new BinaryOperator("Name", "Users"));
            if (userRole == null) {
               userRole = ObjectSpace.CreateObject<SecurityRole>();
               userRole.Name = "Users";
            }
            while (adminRole.PersistentPermissions.Count > 0) {
               ObjectSpace.Delete(adminRole.PersistentPermissions[0]);
            }
            while (userRole.PersistentPermissions.Count > 0) {
               ObjectSpace.Delete(userRole.PersistentPermissions[0]);
            }
            adminRole.Permissions.GrantRecursive(typeof(object), SecurityOperations.FullAccess);
            adminRole.CanEditModel = true;
            adminRole.Save();

            userRole.BeginUpdate();
            userRole.Permissions.GrantRecursive(typeof(object), SecurityOperations.FullAccess);
            userRole.Permissions.DenyRecursive(typeof(SecurityUser), SecurityOperations.ModificationAccess);
            userRole.Permissions.DenyRecursive(typeof(SecurityRole), SecurityOperations.FullAccess);
            userRole.Permissions.DenyRecursive(typeof(PermissionDescriptorBase), SecurityOperations.FullAccess);
            userRole.Permissions.DenyRecursive(typeof(IPermissionData), SecurityOperations.FullAccess);
            userRole.Permissions.DenyRecursive(typeof(TypePermissionDetails), SecurityOperations.FullAccess);
            userRole.CanEditModel = false;
            userRole.EndUpdate();
            userRole.Save();

            Employee admin = ObjectSpace.CreateObject<Employee>();
            admin.UserName = "Administrator";
            admin.SetPassword("");
            admin.Roles.Add(adminRole);
            admin.Save();

            Company company1 = ObjectSpace.CreateObject<Company>();
            company1.Name = "Company 1";
            company1.Employees.Add(admin);
            company1.Save();

            Employee user = ObjectSpace.CreateObject<Employee>();
            user.UserName = "Sam";
            user.SetPassword("");
            user.Roles.Add(userRole);
            user.Save();

            Employee user2 = ObjectSpace.CreateObject<Employee>();
            user2.UserName = "John";
            user2.SetPassword("");
            user2.Roles.Add(userRole);
            user2.Save();

            Company company2 = ObjectSpace.CreateObject<Company>();
            company2.Name = "Company 2";
            company2.Employees.Add(user);
            company2.Employees.Add(user2);
            company2.Save();
         }

      }
      private void CreateAnonymousAccess() {
         SecurityRole anonymousRole = ObjectSpace.FindObject<SecurityRole>(new BinaryOperator("Name", SecurityStrategy.AnonymousUserName));
         if (anonymousRole == null) {
            anonymousRole = ObjectSpace.CreateObject<SecurityRole>();
            anonymousRole.Name = SecurityStrategy.AnonymousUserName;
            anonymousRole.BeginUpdate();
            anonymousRole.Permissions[typeof(SecurityUser)].Grant(SecurityOperations.Read);
            anonymousRole.EndUpdate();
            anonymousRole.Save();
         }

         SecurityUser anonymousUser = ObjectSpace.FindObject<SecurityUser>(new BinaryOperator("UserName", SecurityStrategy.AnonymousUserName));
         if (anonymousUser == null) {
            anonymousUser = ObjectSpace.CreateObject<SecurityUser>();
            anonymousUser.UserName = SecurityStrategy.AnonymousUserName;
            anonymousUser.IsActive = true;
            anonymousUser.SetPassword("");
            anonymousUser.Roles.Add(anonymousRole);
            anonymousUser.Save();
         }
      }
   }
}
