using Microsoft.AspNetCore.Mvc;
using ProjectManager22.Domain.Dtos;
using ProjectManager22.Domain.Interfaces.Services;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectManager22.Web.Controllers.API
{
    [ApiController]
    [Route("api/member")]
    public class MemberAPIController : ControllerBase
    {
        private readonly IMemberDomainService _memberDomainService;

        public MemberAPIController(IMemberDomainService memberDomainService)
        {
            _memberDomainService = memberDomainService;
        }

        [HttpPost("create")]
        public async Task<IActionResult> RegisterMemberAsync([FromBody] MemberDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.Values.SelectMany(x => x.Errors).FirstOrDefault());
            
            await _memberDomainService.CreateAsync(dto);

            return Created("", null);
        }
    }
}
