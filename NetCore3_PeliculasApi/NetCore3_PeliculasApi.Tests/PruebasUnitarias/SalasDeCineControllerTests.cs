using Microsoft.VisualStudio.TestTools.UnitTesting;
using NetCore3_PeliculasApi.Controllers;
using NetCore3_PeliculasApi.DTOs;
using NetCore3_PeliculasApi.Entidades;
using NetTopologySuite;
using NetTopologySuite.Geometries;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NetCore3_PeliculasApi.Tests.PruebasUnitarias
{
    [TestClass]
    public class SalasDeCineControllerTests : BasePruebas
    {
        [TestMethod]
        public async Task GetMovieTheaters5KmsOrCloser()
        {
            var geometryFactory = NtsGeometryServices.Instance.CreateGeometryFactory(srid: 4326);

            using (var context = LocalDbDatabaseInitializer.GetDbContextLocalDb(false))
            {
                var theaters = new List<SalaDeCine>
                    {
                         new SalaDeCine{Nombre = "Agora", Ubicacion = geometryFactory.CreatePoint(new Coordinate(6.1615646,-75.607654))},
                    };

                context.AddRange(theaters);
               await context.SaveChangesAsync();
            }

            var filterMovieTheatersDTO = new SalaDeCineCercanoFiltroDTO()
            {
                DistanciaEnKms = 5,
                Latitud = -75.607654,
                Longitud = 6.1615646
            };

            using (var context = LocalDbDatabaseInitializer.GetDbContextLocalDb(false))
            {
                var mapper = ConfigurarAutoMapper();
                var controller = new SalasDeCineController(context, mapper, geometryFactory);
                var response = await controller.Cercanos(filterMovieTheatersDTO);
                var theatersFromController = response.Value;
                Assert.AreEqual(1, theatersFromController.Count);
            }

        }
    }
}
