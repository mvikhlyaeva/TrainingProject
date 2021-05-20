using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TrainingProject.DomainModels;
using TrainingProject.tables;

namespace TrainingProject.Controllers
{

    [Route("api")]
    [ApiController]
    public class StoreDepartmentController : Controller
    {
        private readonly ApplicationContext _context;
        private readonly IMapper _mapper;

        public StoreDepartmentController(ApplicationContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
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
                _context.storeDepartments.Update(StoreDepartment);
                await _context.SaveChangesAsync();
                return Ok(StoreDepartment.Scheme);
            }
            else return NotFound();
        }


        [HttpGet("store/{storeId}/department/{departmentId}")]
        public async Task<IActionResult> GetStoreDepartments(int storeId, int departmentId, CancellationToken cancellationToken)
        {

            var StoreDepartment = await _context.storeDepartments.FirstOrDefaultAsync(sd => sd.StoreId == storeId && sd.DepartmentId == departmentId);
            if (StoreDepartment != null) return Ok(_mapper.Map<StoreDepartmentDomainModel>(StoreDepartment));
            else return NotFound();

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
