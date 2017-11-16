using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;

namespace UserManagementServer
{
    [ServiceContract]
    public interface IUserManagementService
    {
        [OperationContract]
        List<User> GetUsers();

        [OperationContract]
        void AddUser(User user);

        [OperationContract]
        void ModifyUser(string username, User newUser);

        [OperationContract]
        void DeleteUser(User user);

        [OperationContract]
        bool ExistsUser(string username);

        [OperationContract]
        bool IsUserConnected(string username);
    }
}
