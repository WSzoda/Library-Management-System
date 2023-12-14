using Library.Domain;

namespace Library.API.Data.Abstract;

public interface IRoleRepository
{
    Task<IEnumerable<Role>> GetAllRoles();
    Task<Role> GetRoleById(int id);
}