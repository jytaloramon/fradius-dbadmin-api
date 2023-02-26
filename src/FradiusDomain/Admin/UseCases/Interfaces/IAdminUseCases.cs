using Common.Exceptions;
using FradiusDomain.Admin.Entities;

namespace FradiusDomain.Admin.UseCases.Interfaces;

public interface IAdminUseCases
{
    /**
     * Create a new AdminUser.
     * <returns>The AdminUser created.</returns>
     * <exception cref="EntityValidationException">
     * Thrown when entity has invalid properties.
     * </exception>
     */
    public Task<AdminUser> Create(string fistName, string lastName, string username, string password, string email,
        string? profileImage);

    /**
     * Get AdminUser by Id.
     * <returns>The AdminUser if found, or null</returns>
     * <exception cref="EntityValidationException">
     * Thrown when entity has invalid properties.
     * </exception>
     */
    public Task<AdminUser?> GetById(int id);
    
    /**
     * Get All AdminUser.
     * <returns>AdminUser list</returns>
     */
    public Task<List<AdminUser>> GetAll();
}