using APICase.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APICase.DAL.DataMapper
{
    public class AdresgegevensDataMapper : DataMapperBase<Adres, long>
    {
        public AdresgegevensDataMapper(AdresContext context) : base(context)
        { 
        }

        public override async Task<List<Adres>> FindAll()
        {
            return await adresContext.Adresgegevens.AsNoTracking().ToListAsync();
        }
        public override async Task<List<Adres>> FindAll(Adres adresFilter)
        {
            if (adresFilter.Straat == null && adresFilter.Huisnummer == null && adresFilter.PostCode == null && adresFilter.Plaats == null && adresFilter.Land == null)
            {
                return await FindAll();
            }

            return await adresContext.Adresgegevens.Where(
                a =>
                a.Straat == adresFilter.Straat ||
                a.Huisnummer == adresFilter.Huisnummer ||
                a.PostCode == adresFilter.PostCode ||
                a.Plaats == adresFilter.Plaats ||
                a.Land == adresFilter.Land
                ).AsNoTracking().ToListAsync();
        }
        public override async Task<Adres> Find(long key)
        {
            return await adresContext.Adresgegevens.SingleOrDefaultAsync(a => a.Id == key);
        }

        public override async Task Insert(Adres item)
        {
            adresContext.Adresgegevens.Add(item);
            await adresContext.SaveChangesAsync();
        }

        public override async Task Update(Adres item)
        {
            adresContext.Adresgegevens.Update(item);
            await adresContext.SaveChangesAsync();
        }
        public override async Task Delete(Adres item)
        {
            adresContext.Adresgegevens.Remove(item);
            await adresContext.SaveChangesAsync();
        }

        public override async Task<bool> Exists(Adres item)
        {
            return await adresContext.Adresgegevens.AnyAsync(a => 
            a.Straat.ToLower() == item.Straat.ToLower() &&
            a.Huisnummer.ToLower() == item.Huisnummer.ToLower() &&
            a.PostCode.ToLower() == item.PostCode.ToLower() &&
            a.Plaats.ToLower() == item.Plaats.ToLower() &&
            item.Land.ToLower() == item.Land.ToLower());
        }
    }
}
