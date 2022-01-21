using ProjectManager22.Domain.Entities;
using ProjectManager22.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManager22.Infra.Repositories
{
    public class MemberRepository : BaseRepository<Member>, IMemberRepository
    {
        public MemberRepository(ProjectManager22DbContext context) : base(context)
        {

        }
    }
}
