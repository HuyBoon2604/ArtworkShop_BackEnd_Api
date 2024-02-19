﻿using ArtWorkShop.Repositories.Services;
using AWS.Models;
using backend_not_clear.DTO.UserDTO;
using backend_not_clear.DTO.UserDTO.SearchUserID;

namespace AWS.Repositories.Interfaces
{
    public interface IUser
    {
        Task<List<Usertb>> GetAllUsers();
        Task<Usertb> Registration(RegisterDTO request);
        Task<string> Login(LoginDTO request);
        Task<List<Usertb>> SearchByName(SearchByFullNameDTO name);
        Task<bool> Dellete(RemoveDTO id);
        Task<Usertb> getUserByID(SearchUserID id);

        Task<Usertb> Update(string id, UpdateDTO user);
    }
}
