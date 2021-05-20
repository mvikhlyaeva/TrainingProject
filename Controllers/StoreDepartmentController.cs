using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TrainingProject.Application.Queries.StoreDepartments.GetStpreDepartment;
using TrainingProject.Core;
using TrainingProject.Domain;
using TrainingProject.tables;

namespace TrainingProject.Controllers
{

    [Route("api")]
    [ApiController]
    [Produces("application/json")]
    public class StoreDepartmentController : Controller
    {
        private readonly ApplicationContext _context;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public StoreDepartmentController(ApplicationContext context, IMapper mapper, IMediator mediator)
        {
            _context = context;
            _mapper = mapper;
            _mediator = mediator;
        }

        [HttpPost("StoreDeparments")]
        [ProducesResponseType(typeof(StoreDepartmentDomainModel), StatusCodes.Status200OK)]
        public async Task<IActionResult> AddStoreDepartments([FromBody] StoreDepartmentDomainModel SD, CancellationToken cancellationToken)
        {

            _context.storeDepartments.Add(_mapper.Map<StoreDepartment>(SD));
            await _context.SaveChangesAsync(cancellationToken);
            return Ok(SD);
        }

        [HttpPatch("store/{storeId}/department/{departmentId}")]
        //[ProducesResponseType(typeof(StoreDepartmentDomainModel.Scheme), StatusCodes.Status200OK)]
        public async Task<IActionResult> ChangeStoreDepartments(int storeId, int departmentId, SchemeType scheme, CancellationToken cancellationToken)
        {
            var StoreDepartment = await _context.storeDepartments.FirstOrDefaultAsync(sd => sd.StoreId == storeId && sd.DepartmentId == departmentId);
            if (StoreDepartment != null)
            {
                StoreDepartment.Scheme = scheme;
                await _context.SaveChangesAsync();
                return Ok(StoreDepartment.Scheme);
            }
            else return NotFound();
        }


        [HttpGet("store/{storeId}/department/{departmentId}")]
        public async Task<StoreDepartmentDomainModel> GetStoreDepartments(int storeId, int departmentId, CancellationToken cancellationToken)
        {
            return await _mediator.Send(new GetStoreDepartmentQuery(storeId, departmentId), cancellationToken);
        }

        [HttpDelete("store/{storeId}/department/{departmentId}")]
        [ProducesResponseType(typeof(StoreDepartment), StatusCodes.Status200OK)]
        public async Task<IActionResult> DeleteStoreDepartments(int storeId, int departmentId, CancellationToken cancellationToken)
        {

            var StoreDepartment = await _context.storeDepartments.FirstOrDefaultAsync(sd => sd.StoreId == storeId && sd.DepartmentId == departmentId);
            if (StoreDepartment != null) {
                _context.storeDepartments.Remove(StoreDepartment);
                await _context.SaveChangesAsync();
                return Ok(StoreDepartment);

            } 
            else return NotFound();

        }

    }
}
