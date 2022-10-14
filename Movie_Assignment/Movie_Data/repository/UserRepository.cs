using Microsoft.EntityFrameworkCore;
using Movie_Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Movie_Data.repository
{
   
        public class UserRepository : IUserRepository

        {
            MoviesDb _userdb;


            public UserRepository(MoviesDb userdb)
            {
                _userdb = userdb;
            }

            public void adduser(User user)
            {
                _userdb.users.Add(user);
                _userdb.SaveChanges();
            }

            public void updateuser(User user)
            {
                _userdb.Entry(user).State = EntityState.Modified;
                _userdb.SaveChanges();

            }

            public void deleteuser(int uid)
            {
                var user1 = _userdb.users.Find(uid);
                _userdb.users.Remove(user1);
                _userdb.SaveChanges();
            }

            public IEnumerable<User> GetUser()
            {
                return _userdb.users.ToList();
            }

        public User getUserById(int userId)
        {
            return _userdb.users.Find(userId);
        }
    }
    }
