using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess
{
    public class Repository : MarshalByRefObject
    {
        public static List<User> Users { get; set; }
        public static List<Session> ConnectedUsers { get; set; }

        public void Initialize()
        {
            Users = new List<User>();
            ConnectedUsers = new List<Session>();
        }

        #region Users
        public bool ExistsUser(string username)
        {
            return Users.Where(u => u.Username.Equals(username)).ToList().Count() > 0;
        }

        public bool AreUsersCredentialsCorrect(User user)
        {
            return Users.Find(u => u.Username.Equals(user.Username)).Password.Equals(user.Password);
        }

        public User GetCompleteUser(User user)
        {
            return Users.Find(u => u.Equals(user));
        }

        public User GetUserFromUsername(string username)
        {
            return Users.Find(u => u.Username.Equals(username));
        }

        public void ModifyUser(string username, User newUser)
        {
            User user = this.GetUserFromUsername(username);
            user.Username = newUser.Username;
            user.Password = newUser.Password;
        }

        public List<Session> GetConnectedSessions()
        {
            return ConnectedUsers;
        }

        public void AddUser(User user)
        {
            Users.Add(user);
        }

        public void DeleteUser(User user)
        {
            Users.Remove(user);
            foreach (var userItem in Users)
            {
                if (userItem.Friends.Contains(user))
                {
                    userItem.Friends.Remove(user);
                }
                if (userItem.PendingFriendship.Contains(user))
                {
                    userItem.PendingFriendship.Remove(user);
                }
                if (userItem.PendingMessages.Exists(m => m.Sender.Equals(user)))
                {
                    userItem.PendingMessages.RemoveAll(m => m.Sender.Equals(user));
                }
            }
        }

        public List<User> GetRegisteredUsers()
        {
            return Users;
        }

        #endregion

        #region Session

        public bool IsUserConnected(User user)
        {
            return ConnectedUsers.Where(s => s.User.Equals(user)).ToList().Count() > 0;
        }

        public void ConnectUserSession(Session currentSession)
        {
            ConnectedUsers.Add(currentSession);
            this.GetUserFromUsername(currentSession.User.Username).TimesConnected = currentSession.User.TimesConnected;
        }

        public void SaveUser(User userToSave)
        {
            User user = this.GetUserFromUsername(userToSave.Username);
            user.Friends = userToSave.Friends;
            user.PendingFriendship = userToSave.PendingFriendship;
            user.PendingMessages = userToSave.PendingMessages;

            if(this.IsUserConnected(userToSave))
            {
                this.GetUserSession(user).User = user;
            }
        }

        private Session GetUserSession(User user)
        {
            return ConnectedUsers.Find(s => s.User.Equals(user));
        }

        public void DisconnectUser(User user)
        {
            ConnectedUsers.Remove(this.GetUserSession(user));
        }

        #endregion
    }
}
