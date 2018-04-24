using RFS.Repositories;
using System.Collections.Generic;
using System.Linq;
using RFS.Application.Dto;
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

        public List<UserListDto> GetAllUsers()
        {
            var users = userRepository.GetAll().ToList();

            List<UserListDto> usersList = new List<UserListDto>();
            foreach (var user in users) usersList.Add(new UserListDto
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

        public List<UserListDto> GetAllEmployees()
        {
            var employees = userRepository.GetAllEmployees();

            List<UserListDto> employeesList = new List<UserListDto>();
            foreach (var user in employees) employeesList.Add(new UserListDto
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
        public List<UserListDto> GetAllClients()
        {
            var clients = userRepository.GetAllEmployees();

            List<UserListDto> clientsList = new List<UserListDto>();
            foreach (var user in clients) clientsList.Add(new UserListDto
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


        public UserListDto FindUser(string userName, string password)
        {
            var user = userRepository.Find(u => u.UserName.Equals(userName) && u.Password.Equals(password)).SingleOrDefault();
            if (user != null)
            {
                return new UserListDto { Id = user.Id, UserName = user.UserName, Email = user.Email, Name = user.Name };
            }
            return null;
        }
    }
}
