using RFS.Repositories;
using System.Collections.Generic;
using System.Linq;
using RFS.Application.Dto;
using System;

namespace RFS.Application
{
    public class UserService
    {
        public static UserService Instance { get; private set; }
        private readonly UserRepository userRepository;

        private UserService()
        {
            userRepository = new UserRepository();
        }
        static UserService()
        {
            Instance = new UserService();
        }

        public List<UserDto> GetAllUsers()
        {
            var users = userRepository.GetAll().ToList();

            List<UserDto> usersList = new List<UserDto>();
            foreach (var user in users) usersList.Add(new UserDto().FromIdentityUser(user));

            return usersList;
        }

        public void CreateEmployee(UserCreateDto model)
        {
            userRepository.Add(model.ToIdentityUser());
            userRepository.Save();
        }

        public List<UserDto> GetAllEmployees()
        {
            var employees = userRepository.GetAllEmployees();

            List<UserDto> employeesList = new List<UserDto>();
            foreach (var user in employees) employeesList.Add(new UserDto().FromIdentityUser(user));

            return employeesList;
        }
        public List<UserDto> GetAllClients()
        {
            var clients = userRepository.GetAllEmployees();

            List<UserDto> clientsList = new List<UserDto>();
            foreach (var user in clients) clientsList.Add(new UserDto().FromIdentityUser(user));

            return clientsList;
        }


        public UserDto FindUser(string userName, string password)
        {
            var user = userRepository.Find(u => u.UserName.Equals(userName) && u.Password.Equals(password)).SingleOrDefault();
            if (user != null)
            {
                return new UserDto { Id = user.Id, UserName = user.UserName, Email = user.Email, Name = user.Name };
            }
            return null;
        }

        public void UpdateEmployee(UserDto model)
        {
            var user = userRepository.Get(model.Id);
            userRepository.Update(model.UpdateIdentityUser(user));
            userRepository.Save();
        }

        public void Delete(UserDto model)
        {
            var user = userRepository.Get(model.Id);
            userRepository.Remove(user);
            userRepository.Save();
        }

        public UserDto GetUserByID(int ID)
        {
            var user = userRepository.Get(ID);
            if (user != null)
            {
                return new UserDto { Id = user.Id, UserName = user.UserName, Email = user.Email, Name = user.Name , CompanyName = user.CompanyName, IsActive = user.IsActive, LanguagePreferred = user.LanguagePreferred, Mobile = user.Mobile, NationalID = user.NationalID, Title =user.Title, UserType=user.UserType};
            }
            return null;
        }
        
    }
}
