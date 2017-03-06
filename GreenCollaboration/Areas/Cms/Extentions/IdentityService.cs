using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using GreenCollaboration.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace GreenCollaboration.Areas.Cms.Extentions
{
    public class IdentityService

    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private static RoleManager<IdentityRole> _staticRoleManager;
        private static UserManager<ApplicationUser> _staticUserManager;

        public IdentityService(DbContext context)
        {
            _userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            _roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            _staticRoleManager = _roleManager;
            _staticUserManager = _userManager;
        }
        //Get Users
        public List<ApplicationUser> GetUsers()
        {
            var users = _userManager.Users.Include(u => u.Roles).ToList();
            return users;
        }

        //Get Roles
        public static List<IdentityRole> GetRoles()
        {
            return _staticRoleManager.Roles.ToList();
        }

        //Get Role Name
        public static string GetRoleName(string id)
        {
            return _staticRoleManager.Roles.First(r => r.Id == id).Name;
        }

        //Get Role Id
        public static string GetRoleId(string name)
        {
            return _staticRoleManager.Roles.First(r => r.Name == name).Id;
        }
        //Is User In Role
        public static bool IsUserInRole(string userid, string rolename)
        {
            return _staticUserManager.IsInRole(userid, rolename);
        }

        //Role Exists
        public bool RoleExists(string rolename)
        {
            return _roleManager.RoleExists(rolename);
        }

        //GetUserByEmail
        public ApplicationUser GetUserByEmail(string email)
        {
            var user = _userManager.FindByEmail(email);
            return user;
        }

        //GetUserByName
        public ApplicationUser GetUserByName(string name)
        {
            var user = _userManager.FindByName(name);
            return user;
        }
        //GetBy Id

        //Create User Without Phonenumber
        public bool CreateUser(string username, string email, string password)
        {
            var iResult = _userManager.Create(new ApplicationUser { Email = email, UserName = username.Replace(" ", "") }, password);
            return iResult.Succeeded;
        }
        //Create User With Phonenumber
        public bool CreateUser(string username, string email, string password, string phonenumber)
        {
            var iResult = _userManager.Create(new ApplicationUser { Email = email, UserName = username.Replace(" ", ""), PhoneNumber = phonenumber }, password);
            return iResult.Succeeded;
        }

        //Delete User
        public bool DeleteUser(string id)
        {
            var user = _userManager.FindById(id);
            var iResult = _userManager.Delete(user);
            return iResult.Succeeded;
        }
        //Create Role
        public bool CreateRole(string rolename)
        {
            var iResult = _roleManager.Create(new IdentityRole { Name = rolename });
            return iResult.Succeeded;
        }
        //Delete Role
        public bool DeleteRole(string roleName)
        {
            var role = _roleManager.FindByName(roleName);
            var users = role.Users;
            foreach (var user in users)
            {
                RemoveUserFromRole(user.UserId, role.Name);
            }
            var iResult = _roleManager.Delete(role);
            return iResult.Succeeded;
        }
        //Add User To Role
        public bool AddUserToRole(string userid, string rolename)
        {
            var iResult = _userManager.AddToRole(userid, rolename);
            return iResult.Succeeded;
        }
        //Remove Usser From Role
        public bool RemoveUserFromRole(string userid, string rolename)
        {
            var iResult = _userManager.RemoveFromRole(userid, rolename);
            return iResult.Succeeded;
        }
        //Get Role By Id
        public string GetRoleById(string id)
        {
            var rolename = _roleManager.FindById(id);
            return rolename.Name;
        }

        //Clear User Roles
        public void ClearUserRoles(string userId)
        {
            var user = _userManager.FindById(userId);
            var currentRoles = new List<IdentityUserRole>();
            currentRoles.AddRange(user.Roles);
            foreach (var role in currentRoles)
            {
                _userManager.RemoveFromRole(userId, role.RoleId);
            }
        }

        //IdentityService Create
        public static IdentityService Create(DbContext context)
        {
            return new IdentityService(context);
        }


    }
}



//nikolaj



//namespace GreenCollaboration.Areas.Cms.Extensions
//{
//    public class IdentityService
//    {
//        private readonly RoleManager<IdentityRole> _rolemanager;
//        private readonly UserManager<ApplicationUser> _userManager;
//        private static RoleManager<IdentityRole> _staticRoleManager;
//        private static UserManager<ApplicationUser> _staticUserManager;

//        public IdentityService(DbContext context)
//        {
//            _rolemanager = new RoleManager<IdentityRole>(
//                new RoleStore<IdentityRole>(context));
//            _userManager = new UserManager<ApplicationUser>(
//                new UserStore<ApplicationUser>(context));
//            _staticRoleManager = _rolemanager;
//            _staticUserManager = _userManager;
//        }

//        public static List<IdentityRole> GetRoles()
//        {
//            return _staticRoleManager.Roles.ToList();
//        }
//        public static string GetRoleName(string id)
//        {
//            return _staticRoleManager.Roles.First(r => r.Id == id).Name;
//        }

//        public static string GetRoleId(string name)
//        {
//            return _staticRoleManager.Roles.First(r => r.Name == name).Id;
//        }

//        public static bool IsUserInRole(string id, string role)
//        {
//            return _staticUserManager.IsInRole(id, role);
//        }

//        public bool RoleExists(string name)
//        {
//            return _rolemanager.RoleExists(name);
//        }

//        public ApplicationUser GetUserByEmail(string email)
//        {
//            var user = _userManager.FindByEmail(email);
//            return user;
//        }
//        public ApplicationUser GetUserByName(string name)
//        {
//            var user = _userManager.FindByName(name);
//            return user;
//        }
//        public bool CreateUser(string name, string email, string password)
//        {
//            var result = _userManager.Create(new ApplicationUser { UserName = name, Email = email }, password);
//            return result.Succeeded;
//        }

//        public bool CreateUser(string name, string email, string password, string phone)
//        {
//            var result = _userManager.Create(new ApplicationUser { Email = email, UserName = name, PhoneNumber = phone }, password);
//            return result.Succeeded;
//        }

//        public bool CreateRole(string roleName)
//        {
//            var idResult = _rolemanager.Create(new IdentityRole(roleName));
//            return idResult.Succeeded;
//        }

//        public bool DeleteRole(string roleName)
//        {
//            var role = _rolemanager.FindByName(roleName);
//            var users = role.Users;
//            foreach (var user in users)
//            {
//                RemoveUserInRole(user.UserId, role.Name);
//            }
//            var idResult = _rolemanager.Delete(role);
//            return idResult.Succeeded;
//        }

//        public bool AddUserToRole(string userId, string roleName)
//        {
//            var idResult = _userManager.AddToRole(userId, roleName);
//            return idResult.Succeeded;
//        }

//        public bool RemoveUserInRole(string userId, string roleName)
//        {
//            var idResult = _userManager.RemoveFromRole(userId, roleName);
//            return idResult.Succeeded;
//        }

//        public string GetRoleById(string id)
//        {
//            var rolename = _rolemanager.FindById(id);
//            return rolename.Name;
//        }

//        public void ClearUserRoles(string userId)
//        {
//            var user = _userManager.FindById(userId);
//            var currentRoles = new List<IdentityUserRole>();
//            currentRoles.AddRange(user.Roles);
//            foreach (var role in currentRoles)
//            {
//                _userManager.RemoveFromRole(userId, role.RoleId);
//            }
//        }

//        public List<ApplicationUser> GetUsers()
//        {
//            return _userManager.Users.Include(u => u.Roles).ToList();
//        }
//    }
//}
