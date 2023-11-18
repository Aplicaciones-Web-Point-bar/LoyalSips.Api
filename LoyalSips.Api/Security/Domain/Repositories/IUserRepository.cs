﻿using LoyalSips.Api.Security.Domain.Models;

namespace LoyalSips.Api.Security.Domain.Repositories;

public interface IUserRepositoryy
{
    Task<IEnumerable<User>> ListAsync();
    Task AddAsync(User user);
    Task<User> FindByIdAsync(int id);
    Task<User> FindByUsernameAsync(string username);
    public bool ExistsByUsername(string username);
    User FindById(int id);
    void Update(User user);
    void Remove(User user);
}