using Movie_Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Movie_Data.repository
{
    public interface IUserRepository
    {
        void adduser(User user);
        void deleteuser(int uid);
        void updateuser(User user);
       User getUserById(int userId);
        IEnumerable<User> GetUser();
    }
}
