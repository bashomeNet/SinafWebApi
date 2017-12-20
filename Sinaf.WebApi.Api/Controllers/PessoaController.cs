using Sinaf.WebApi.Api.AutoMapper;
using Sinaf.WebApi.Api.DTOs;
using Sinaf.WebApi.Api.Filters;
using Sinaf.WebApi.Dominio;
using Sinaf.WebApi.Repositorio;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Sinaf.WebApi.Api.Controllers
{
    public class PessoaController : ApiController
    {

        static string connectionString = ConfigurationManager.ConnectionStrings["BaseSies"].ToString();

        PessoaRepositorio _repositorioPessoa = new PessoaRepositorio(connectionString);
        
        [Authorize]
        public IHttpActionResult Get()
        {
            if (_repositorioPessoa.Selecionar() != 0)
            {
                List<Pessoa> _listPessoa = _repositorioPessoa.listaPessoa;
                List<PessoaDTO> _listPessoaDTO = AutoMapperManager.Instance.Mapper.Map<List<Pessoa>, List<PessoaDTO>>(_listPessoa);
                return Ok(_listPessoaDTO);
            }

            return NotFound(); // Request.CreateResponse(HttpStatusCode.NotFound);
        }

        public IHttpActionResult Get(int id)
        {
            if (_repositorioPessoa.SelecionarPorId(id) != 0)
            {
                Pessoa _pessoa = _repositorioPessoa.pessoa;
                PessoaDTO _pessoaDTO = AutoMapperManager.Instance.Mapper.Map<Pessoa, PessoaDTO>(_pessoa);

                return Ok(_pessoaDTO);
            }

            return NotFound(); //Request.CreateResponse(HttpStatusCode.NotFound);
        }

        //WebApi 2.x
        [ApplyModelValidation] // Responsável pela validação do DTO(elimina o uso da verificação do model state)
        public IHttpActionResult Post([FromBody]PessoaDTO p_pessoaDTO)
        {
            try
            {
                if (p_pessoaDTO == null)
                {
                    return NotFound(); //Request.CreateResponse(HttpStatusCode.NotFound);
                }

                Pessoa _pessoa = AutoMapperManager.Instance.Mapper.Map<PessoaDTO, Pessoa>(p_pessoaDTO);

                _repositorioPessoa.pessoa = _pessoa;

                if (_repositorioPessoa.Incluir() != 0)
                {
                    return Created($"{Request.RequestUri}/{_repositorioPessoa.pessoa.cdpes}", _repositorioPessoa.pessoa); //Request.CreateResponse(HttpStatusCode.OK);
                }

                return NotFound(); //Request.CreateResponse(HttpStatusCode.NotFound);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);// Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        //WebApi 1.x
        /*public HttpResponseMessage Post([FromBody]Pessoa p_pessoa)
        {
            try
            {
                if (p_pessoa == null)
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound);
                }

                Pessoa _pessoa = p_pessoa;

                _repositorioPessoa.pessoa = _pessoa;

                if (_repositorioPessoa.Incluir() != 0)
                {
                    return Request.CreateResponse(HttpStatusCode.OK);
                }

                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);                
            }
            
        }*/

        [ApplyModelValidation] // Responsável pela validação do DTO(elimina o uso da verificação do model)
        public IHttpActionResult Put([FromBody]PessoaDTO p_pessoaDTO)
        {
            try
            {
                if (p_pessoaDTO == null)
                {
                    return BadRequest(); //Request.CreateResponse(HttpStatusCode.NotFound);
                }

                Pessoa _pessoa = AutoMapperManager.Instance.Mapper.Map<PessoaDTO,Pessoa>(p_pessoaDTO);

                _repositorioPessoa.pessoa = _pessoa;

                if (_repositorioPessoa.Alterar() != 0)
                {
                    return Ok();// Request.CreateResponse(HttpStatusCode.OK);
                }

                return NotFound();// Request.CreateResponse(HttpStatusCode.NotFound); ;
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        public IHttpActionResult Delete(int id)
        {
            try
            {
                //if (!id.HasValue)
                //{
                //    BadRequest();
                //}

                if (_repositorioPessoa.Deletar(id) != 0)
                {
                    return Ok(id); //Request.CreateResponse(HttpStatusCode.OK); 
                }

                return NotFound(); //Request.CreateResponse(HttpStatusCode.NotFound); ;
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
            
        }
    }
}
