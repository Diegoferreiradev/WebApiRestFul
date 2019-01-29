using House.ApiRestFul.AcessoDados.Entity.Context;
using House.ApiRestFul.Api.AutoMapper;
using House.ApiRestFul.Api.DTOs;
using House.ApiRestFul.Api.Filters;
using House.ApiRestFul.Dominio;
using House.ApiRestFul.Repositorios.Entity;
using House.Comum.Repositorios.Interfaces;
using System;
using System.Collections.Generic;
using System.Net;
using System.Web.Http;

namespace House.ApiRestFul.Api.Controllers
{
    public class AlunosController : ApiController
    {
        private IRepositorioHouse<Aluno, int> _repositorioAlunos
            = new RepositorioAlunos(new ApiRestFulDbContext());

        public IHttpActionResult Get()
        {
            List<Aluno> alunos = _repositorioAlunos.Selecionar();
            List<AlunoDTO> dtos = AutoMapperManager.Instance.Mapper.Map<List<Aluno>, List<AlunoDTO>>(alunos);
            return Ok(dtos);
        }

        public IHttpActionResult Get(int? id)
        {
            if (!id.HasValue)
            {
                return BadRequest();
            }
            Aluno aluno = _repositorioAlunos.SelecionarPorId(id.Value);
            if (aluno == null)
            {
                return NotFound();
            }
            AlunoDTO dto = AutoMapperManager.Instance.Mapper.Map<Aluno, AlunoDTO>(aluno);
            return Content(HttpStatusCode.Found, aluno);
        }

        [ApplyModelValidation]
        public IHttpActionResult Post([FromBody]AlunoDTO dto)
        {

            try
            {
                Aluno aluno = AutoMapperManager.Instance.Mapper.Map<AlunoDTO, Aluno>(dto);
                _repositorioAlunos.Inserir(aluno);
                return Created($"{Request.RequestUri}/{aluno.Id}", aluno);

            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }

        }

        [ApplyModelValidation]
        public IHttpActionResult Put(int? id, [FromBody] AlunoDTO dto)
        {
            try
            {
                if (!id.HasValue)
                {
                    return BadRequest();
                }
                Aluno aluno = AutoMapperManager.Instance.Mapper.Map<AlunoDTO, Aluno>(dto);
                aluno.Id = id.Value;
                _repositorioAlunos.Atualizar(aluno);
                return Ok();
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        public IHttpActionResult Delete(int? id)
        {
            try
            {
                if (!id.HasValue)
                {
                    return BadRequest();
                }
                Aluno aluno = _repositorioAlunos.SelecionarPorId(id.Value);
                if (aluno == null)
                {
                    return NotFound();
                }

                _repositorioAlunos.ExcluirPorId(id.Value);
                return Ok();
            }
            catch (Exception ex)
            {

                return InternalServerError(ex);
            }
        }
    }
}
