using APICase.DAL.DataMapper;
using APICase.DAL.Models;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APICase.DAL.Test
{
    [TestClass]
    public class AdresgegevensDataMapperTest
    {

        private SqliteConnection _connection;
        private DbContextOptions<AdresContext> _options;


        [TestInitialize]
        public void TestInit()
        {
            _connection = new SqliteConnection("Filename=:memory:");
            _connection.Open();

            _options = new DbContextOptionsBuilder<AdresContext>()
                .UseSqlite(_connection)
                .Options;

            using (var ctx = new AdresContext(_options))
            {
                ctx.Database.EnsureCreated();
            }
        }

        [TestCleanup]
        public void TestCleanup()
        {
            _connection.Dispose();
        }

        [TestMethod]
        public async Task ShouldHaveDataOnCreation()
        {
            using var context = new AdresContext(_options);
            var mapper = new AdresgegevensDataMapper(context);

            var results = await context.Adresgegevens.ToListAsync();

            results.OrderBy(a => a.Id);

            Assert.AreEqual(2, results.Count);
            Assert.IsTrue(results.Any(a => a.Straat == "Riojagaard"));
            Assert.IsTrue(results.Any(a => a.Straat == "Burgemeester van Erpstraat"));
        }

        [TestMethod]
        public async Task InsertShouldInsertRightItems()
        {
            using var context = new AdresContext(_options);
            var mapper = new AdresgegevensDataMapper(context);


            Adres adres1 = new Adres()
            {
                Straat = "Prins bernhardstraat",
                Huisnummer = "5",
                PostCode = "4241KN",
                Plaats = "Schoonrewoerd",
                Land = "Nederland",
            };

            await mapper.Insert(adres1);

            var results = await context.Adresgegevens.ToListAsync();

            Assert.AreEqual(3, results.Count);
            CollectionAssert.Contains(results, adres1);
        }

        [TestMethod]
        public async Task FindallShouldReturnAllAdressen()
        {
            using var context = new AdresContext(_options);
            var mapper = new AdresgegevensDataMapper(context);

            Adres adres1 = new Adres()
            {
                Straat = "Riojagaard",
                Huisnummer = "6",
                PostCode = "3446WD",
                Plaats = "Woerden",
                Land = "Nederland"
            };

            List<Adres> results = await mapper.FindAll();

            Assert.AreEqual(2, results.Count);
            Assert.IsTrue(results.Any(a => a.Straat == "Riojagaard"));
            Assert.IsTrue(results.Any(a => a.Straat == "Burgemeester van Erpstraat"));
        }

        [TestMethod]
        public async Task FindShouldReturnOneAdres()
        {
            using var context = new AdresContext(_options);
            var mapper = new AdresgegevensDataMapper(context);


            Adres result = await mapper.Find(1);

            Adres adres1 = new Adres()
            {
                Id = 1,
                Straat = "Riojagaard",
                Huisnummer = "6",
                PostCode = "3446WD",
                Plaats = "Woerden",
                Land = "Nederland"
            };


            Assert.IsTrue(result.Straat == "Riojagaard");
            Assert.IsTrue(result.Plaats == "Woerden");
        }


        // update
        // delete
        // exists
    }
}
