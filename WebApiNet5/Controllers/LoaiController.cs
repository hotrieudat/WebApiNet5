using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using WebApiNet5.Data;
using WebApiNet5.Model;

namespace WebApiNet5.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoaiController : ControllerBase
    {
        private readonly MyDbContext MyDbContext;
        public LoaiController(MyDbContext context) 
        {
            MyDbContext = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var dsLoai = MyDbContext.Loais.ToList();
            return Ok(dsLoai);
        }

        [HttpGet("{id}")]
        public IActionResult GetAll(int id)
        {
            var loai = MyDbContext.Loais.SingleOrDefault(p => p.MaLoai == id);

            if (loai == null)
            {
                return NotFound();
            }

            return Ok(loai);
        }

        [HttpPost]
        public IActionResult CreateNew(LoaiModel model)
        {
            try
            {
                var loai = new Loai()
                {
                    TenLoai = model.TenLoai,
                };

                MyDbContext.Loais.Add(loai);
                MyDbContext.SaveChanges();

                return Ok(loai);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPut]
        public IActionResult UpdateLoaiById(int id, LoaiModel model)
        {
            var loai = MyDbContext.Loais.SingleOrDefault(p => p.MaLoai == id);

            if (loai == null)
            {
                return BadRequest();
            }

            loai.TenLoai = model.TenLoai;
            MyDbContext.SaveChanges();

            return NoContent();
        }
    }
}
