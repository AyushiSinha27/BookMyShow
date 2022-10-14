using Movie_Data.repository;
using Movie_Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Movie_Business.services
{
  public class UserService
    {
        IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        // add User
        public void AddUser(User user)
        {
            _userRepository.adduser(user);
        }
        //update user

        public void UpdateUser(User user)
        {
            _userRepository.updateuser(user);
        }
        //delete User
        public void DeleteUser(int uid)
        {
            _userRepository.deleteuser(uid);
        }

        //get User

        public IEnumerable<User> GetUser()
        {
            return _userRepository.GetUser();
        }
        public User GetUserById(int userId)
        {

            return _userRepository.getUserById(userId);
        }
    }
}
