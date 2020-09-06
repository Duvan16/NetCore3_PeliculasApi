using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NetCore3_PeliculasApi.Helpers;
using NetTopologySuite;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;

namespace NetCore3_PeliculasApi.Tests { 
    public class BasePruebas
    {
        protected string usuarioPorDefectoId = "adadasdad-aasda-asda3-2312as1-123213213";
        protected string usuarioPorDefectoEmail = "miejemplo@hotmail.com";

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

        protected ControllerContext ConstruirControllerContext()
        {
            var usuario = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
            {
                new Claim(ClaimTypes.Name,usuarioPorDefectoEmail),
                new Claim(ClaimTypes.Email,usuarioPorDefectoEmail),
                new Claim(ClaimTypes.NameIdentifier,usuarioPorDefectoId)
            }));

            return new ControllerContext()
            {
                HttpContext = new DefaultHttpContext() { User = usuario }
            };
        }
    }
}
