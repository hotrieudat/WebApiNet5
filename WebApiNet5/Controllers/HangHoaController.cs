using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using WebApiNet5.Model;

namespace WebApiNet5.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HangHoaController : ControllerBase
    {
        public static List<HangHoa> hangHoas = new List<HangHoa>();

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(hangHoas);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(string id)
        {
            try
            {
                var hangHoa = hangHoas.SingleOrDefault(p => p.MaHangHoa == id);

                if (hangHoa == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(hangHoa);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult Create(HangHoaVM hangHoaVM)
        {
            var hangHoa = new HangHoa()
            {
                MaHangHoa = Guid.NewGuid().ToString(),
                TenHangHoa = hangHoaVM.TenHangHoa,
                DonGia = hangHoaVM.DonGia
            };

            hangHoas.Add(hangHoa);

            return Ok(new
            {
                Success = true,
                Data = hangHoa, 
            });
        }

        [HttpPut("{id}")]
        public IActionResult Edit(string id, HangHoa hangHoaEdit)
        {
            try
            {
                var hangHoa = hangHoas.SingleOrDefault(p => p.MaHangHoa == id);

                if (hangHoa == null)
                {
                    return NotFound();
                }

                if (id != hangHoa.MaHangHoa)
                {
                    return BadRequest();
                }

                hangHoa.TenHangHoa = hangHoaEdit.TenHangHoa;
                hangHoa.DonGia = hangHoaEdit.DonGia;
                return Ok();
                
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("id")]
        public IActionResult Remove(string id)
        {
            try
            {
                var hangHoa = hangHoas.SingleOrDefault(p => p.MaHangHoa == id);

                if (hangHoa == null)
                {
                    return NotFound();
                }

                hangHoas.Remove(hangHoa);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
