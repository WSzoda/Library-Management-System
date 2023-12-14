using Library.API.Data.Abstract;
using Library.Domain;
using Microsoft.EntityFrameworkCore;

namespace Library.API.Data.Concrete;

public class RoleRepository : IRoleRepository
{
    private readonly LibraryDbContext _context;

    public RoleRepository(LibraryDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Role>> GetAllRoles()
    {
        var roles = await _context.Roles.AsNoTracking().ToListAsync();
        return roles;
    }

    public async Task<Role> GetRoleById(int id)
    {
        var role = await _context.Roles.AsNoTracking().FirstOrDefaultAsync(r => r.Id == id);
        if(role == null) throw new Exception("Role not found");
        
        return role;
    }
}