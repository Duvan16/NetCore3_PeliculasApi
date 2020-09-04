using AutoMapper;
using Microsoft.EntityFrameworkCore;
using NetCore3_PeliculasApi.Helpers;
using NetTopologySuite;
using System;
using System.Collections.Generic;
using System.Text;

namespace NetCore3_PeliculasApi.Tests { 
    public class BasePruebas
    {
        protected ApplicationDbContext ConstruirContext(string nombreDB)
        {
            var opciones = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(nombreDB).Options;

            var dbContext = new ApplicationDbContext(opciones);
            return dbContext;
        }

        protected IMapper ConfigurarAutoMapper()
        {
            var config = new MapperConfiguration(options =>
           {
               var geometryFactory = NtsGeometryServices.Instance.CreateGeometryFactory(srid: 4326);
               options.AddProfile(new AutoMapperProfiles(geometryFactory));
           });

            return config.CreateMapper();
        }
    }
}
