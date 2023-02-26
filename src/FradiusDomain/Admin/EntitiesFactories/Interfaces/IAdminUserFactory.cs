using FradiusDomain.Admin.Entities;
using Common.Exceptions;

namespace FradiusDomain.Admin.EntitiesFactories.Interfaces;

public interface IAdminUserFactory
{
    /**
     * Create a new AdminUser.
     * <returns>The AdminUser Created.</returns>
     * <exception cref="EntityValidationException">
     * Thrown when entity has invalid properties.
     * </exception>
     */
    public AdminUser Create(string fistName, string lastName, string username, string password, string email,
        string? profileImage, bool isActive);
}