using ProjectManager22.Domain.Dtos;
using System.Threading.Tasks;

namespace ProjectManager22.Domain.Interfaces.Services
{
    public interface IMemberDomainService
    {
        Task CreateAsync(MemberDto dto);
    }
}
