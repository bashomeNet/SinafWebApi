using AutoMapper;
using Sinaf.WebApi.Api.DTOs;
using Sinaf.WebApi.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sinaf.WebApi.Api.AutoMapper
{
    public class AutoMapperManager
    {
        /*Implementado o designer patterns singleton*/

        private static readonly Lazy<AutoMapperManager> _instance
            = new Lazy<AutoMapperManager>(() =>
            {
                return new AutoMapperManager();
            });

        public static AutoMapperManager Instance
        {
            get
            {
                return _instance.Value;
            }
        }

        private MapperConfiguration _config;

        public IMapper Mapper
        {
            get
            {
                return _config.CreateMapper();
            }
        }

        private AutoMapperManager()
        {
            _config = new MapperConfiguration((cfg) =>
            {
                cfg.CreateMap<Pessoa, PessoaDTO>();
                cfg.CreateMap<PessoaDTO, Pessoa>();
            });
        }
    }
}