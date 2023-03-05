using Common.Exceptions;
using FradiusDomain.Admin.Entities;

namespace FradiusDomain.Admin.UseCases.Interfaces;

public interface IAdminUseCases
{
    /**
     * Get AdminUser by Id.
     * <returns>The AdminUser if found, or null</returns>
     * <exception cref="BaseException">
     * Thrown when entity has invalid properties.
     * </exception>
     */
    public Task<AdminUser?> GetById(int id);

    /**
     * Get All AdminUser.
     * <returns>AdminUser list</returns>
     * <exception cref="BaseException">
     * Thrown when entity has invalid properties.
     * </exception>
     */
    public Task<List<AdminUser>> GetAll();

    /**
     * Create a new AdminUser.
     * <returns>The AdminUser created.</returns>
     * <exception cref="BaseException">
     * Thrown when entity has invalid properties.
     * </exception>
     */
    public Task<AdminUser> Create(string firstName, string lastName, string username, string password, string email,
        string? profileImage);
}