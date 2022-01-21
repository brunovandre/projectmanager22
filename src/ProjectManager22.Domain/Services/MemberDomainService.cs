using ProjectManager22.Domain.Dtos;
using ProjectManager22.Domain.Entities;
using ProjectManager22.Domain.Interfaces.Repositories;
using ProjectManager22.Domain.Interfaces.Services;
using System.Threading.Tasks;

namespace ProjectManager22.Domain.Services
{
    public class MemberDomainService : IMemberDomainService
    {
        private readonly IMemberRepository _memberRepository;

        public MemberDomainService(IMemberRepository memberRepository)
        {
            _memberRepository = memberRepository;
        }

        public async Task CreateAsync(MemberDto dto)
        {
            var member = new Member(dto.Nome, dto.Atribuicao);

            await _memberRepository.InsertAndSaveChangesAsync(member);
        }
    }
}
