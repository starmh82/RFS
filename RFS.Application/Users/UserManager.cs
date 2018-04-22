using RFS.Application.Dto;
using RFS.Repositories;
using System.Collections.Generic;
using System.Linq;

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
            foreach (var user in users) usersList.Add(new UserDto
            {
                Id = user.Id,
                CompanyName = user.CompanyName,
                Email = user.Email,
                IsActive = user.IsActive,
                LanguagePreferred = user.LanguagePreferred,
                Mobile = user.Mobile,
                Name = user.Name,
                NationalID = user.NationalID,
                UserName = user.UserName,
                UserType = user.UserType
            });

            return usersList;
        }

        public List<UserDto> GetAllEmployees()
        {
            var employees = userRepository.GetAllEmployees();

            List<UserDto> employeesList = new List<UserDto>();
            foreach (var user in employees) employeesList.Add(new UserDto
            {
                Id = user.Id,
                CompanyName = user.CompanyName,
                Email = user.Email,
                IsActive = user.IsActive,
                LanguagePreferred = user.LanguagePreferred,
                Mobile = user.Mobile,
                Name = user.Name,
                NationalID = user.NationalID,
                UserName = user.UserName,
                UserType = user.UserType
            });

            return employeesList;
        }
        public List<UserDto> GetAllClients()
        {
            var clients = userRepository.GetAllEmployees();

            List<UserDto> clientsList = new List<UserDto>();
            foreach (var user in clients) clientsList.Add(new UserDto
            {
                Id = user.Id,
                CompanyName = user.CompanyName,
                Email = user.Email,
                IsActive = user.IsActive,
                LanguagePreferred = user.LanguagePreferred,
                Mobile = user.Mobile,
                Name = user.Name,
                NationalID = user.NationalID,
                UserName = user.UserName,
                UserType = user.UserType
            });

            return clientsList;
        }


        public UserDto FindUser(string userName, string password)
        {
            var user = userRepository.Find(u => u.UserName.Equals(userName) && u.Password.Equals(password)).SingleOrDefault();
            if(user != null)
            {
                return new UserDto { Id = user.Id, UserName = user.UserName, Email = user.Email, Name = user.Name };
            }
            return null;
        }
    }
}
