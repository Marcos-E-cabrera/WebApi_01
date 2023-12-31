﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using WebApiYerbas.Models;
using WebApiYerbas.Services;

namespace WebApiYerbas.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class YerbaController : Controller
    {
        private readonly IYerbaServices _yerbaServices;

        public YerbaController(IYerbaServices yerbaServices)
        {
            _yerbaServices = yerbaServices;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var oYerba = await _yerbaServices.GetAsync();
                if (oYerba == null)
                {
                    return NotFound();
                }

                return Ok(oYerba);
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    success = false,
                    message = ex.Message,
                    result = ""
                });
            }
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var oYerba = await _yerbaServices.GetByIdAsync(id);
                if (oYerba == null)
                {
                    return NotFound(new
                    {
                        success = false,
                        message = "ID No existente",
                        result = ""
                    });
                }

                return Ok(oYerba);
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    success = false,
                    message = ex.Message,
                    result = ""
                });
            }
        }


        [HttpPut]
        public async Task<IActionResult> Put(Yerba yerba)
        {
            try
            {
                var data = await _yerbaServices.UpdateAsync(yerba);
                if (data == 0)
                {
                    return Ok(new
                    {
                        success = true,
                        message = "Yerba actualizada con Éxito",
                        result = ""
                    });
                }
                else
                {
                    return BadRequest(new
                    {
                        success = false,
                        message = _yerbaServices.GetErrorMessage(data),
                        result = ""
                    });
                }
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    success = false,
                    message = ex.Message,
                    result = ""
                });
            }
        }


        [HttpPost]
        public IActionResult Post(Yerba yerba)
        {
            try
            {
                var data = _yerbaServices.Add(yerba);

                if (data == 0)
                {
                    return Ok(new
                    {
                        success = true,
                        message = "Yerba Creada con Éxito",
                        result = ""
                    });
                }
                else
                {
                    return BadRequest(new
                    {
                        success = false,
                        message = _yerbaServices.GetErrorMessage(data),
                        result = ""
                    });
                }
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    success = false,
                    message = ex.Message,
                    result = ""
                });
            }
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var data = await _yerbaServices.DeleteAsync(id);
                if (data == 0)
                {
                    return Ok(new
                    {
                        success = true,
                        message = "Yerba Eliminada con Éxito",
                        result = ""
                    });
                }
                else
                {
                    return BadRequest(new
                    {
                        success = false,
                        message = _yerbaServices.GetErrorMessage(data),
                        result = ""
                    });
                }
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    success = false,
                    message = ex.Message,
                    result = ""
                });
            }
        }


    }
}
    