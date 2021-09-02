﻿using APICase.DAL.DataMapper;
using APICase.DAL.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APICase.Controllers
{
    [ApiController]
    [Route("adressen")]
    public class AdresController : ControllerBase
    {
        private readonly IDataMapper<Adres, long> _adresgegevensDataMapper;

        public AdresController(IDataMapper<Adres, long> adresgegevensDataMapper)
        {
            _adresgegevensDataMapper = adresgegevensDataMapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<Adres>>> GetAll()
        {
            List<Adres> adres = await _adresgegevensDataMapper.FindAll();

            return Ok(adres);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Adres>> Get(long id)
        {
            Adres adres = await _adresgegevensDataMapper.Find(id);

            if (adres == null)
            {
                return NotFound();
            }

            return adres;
        }

        [HttpPost]
        public async Task<ActionResult<Adres>> Create(Adres adres)
        {

            if (await _adresgegevensDataMapper.Exists(adres))
            {
                return BadRequest();
            }

            await _adresgegevensDataMapper.Insert(adres);

            return CreatedAtAction("Get", new { id = adres.Id }, adres);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(long id, Adres adres)
        {

            if (id != adres.Id || await _adresgegevensDataMapper.Exists(adres))
            {
                return BadRequest();
            }

            await _adresgegevensDataMapper.Update(adres);

            return NoContent();

        }


        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(long id) 
        {
            Adres adres = await _adresgegevensDataMapper.Find(id);

            if (adres == null)
            {
                return NotFound();
            }

            await _adresgegevensDataMapper.Delete(adres);

            return NoContent();
        }
    }
}
