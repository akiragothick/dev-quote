using DevQuote.API.Base;
using DevQuote.API.Controllers.Base;
using DevQuote.API.DataTransferObject;
using DevQuote.API.Models.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevQuote.API.Controllers
{
    //Direct to DataTransferObject
    public class ProfessionalController : ControllerGeneric<Response<Professional>>
    {
        private readonly DevQuoteDBContext _context;

        public ProfessionalController(DevQuoteDBContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<Response<Professional>>> GetAll()
        {
            entity.DataList = InitMapper.mapper.Map<List<Professional>>(await _context.Professional.ToListAsync());

            return entity;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Response<Professional>>> Get(int id)
        {
            entity.Data = InitMapper.mapper.Map<Professional>(await _context.Professional.FindAsync(id));

            if (entity.Data == null)
            {
                entity.Message.NotFound();
                return entity;
            }

            return entity;
        }

        [HttpPost]
        public async Task<ActionResult<Response<Professional>>> PostProfessional(Professional professional)
        {
            entity.Message = ValidateDto(professional, new List<string>() {
                nameof(professional.name),
                nameof(professional.monthPay)
            });

            if (entity.Message.ExistsMessages())
                return entity;

            _context.Professional.Add(InitMapper.mapper.Map<Models.Professional>(professional));
            await _context.SaveChangesAsync();

            entity.Message.Success();

            return entity;
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Response<Professional>>> PutProfessional(int id, Professional professional)
        {
            if (id != professional.id)
            {
                entity.Message.BadRequest();
                return entity;
            }

            _context.Entry(InitMapper.mapper.Map<Models.Professional>(professional)).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProfessionalExists(id))
                {
                    entity.Message.NotFound();
                    return entity;
                }
                else
                {
                    entity.Message.Error();
                    return entity;
                }
            }

            entity.Data = InitMapper.mapper.Map<Professional>(await _context.Professional.FindAsync(id));
            entity.Message.Success();

            return entity;
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Response<Professional>>> Delete(int id)
        {
            var professional = await _context.Professional.FindAsync(id);

            if (professional == null)
            {
                entity.Message.NotFound();
                return entity;
            }

            _context.Professional.Remove(professional);
            await _context.SaveChangesAsync();

            entity.Message.Success();

            return entity;
        }

        private bool ProfessionalExists(int id)
        {
            return _context.Professional.Any(e => e.id == id);
        }
    }
}