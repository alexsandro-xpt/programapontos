﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProgramaPontos.API.Extensions;
using ProgramaPontos.API.ViewModel;
using ProgramaPontos.Application.Services;
using ProgramaPontos.Application.Services.Interfaces;

namespace ProgramaPontos.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParticipanteController : ControllerBase
    {
        private readonly IParticipanteApplicationService participanteApplicationService;

        public ParticipanteController(IParticipanteApplicationService participanteApplicationService)
        {
            this.participanteApplicationService = participanteApplicationService;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ParticipanteViewModel participanteViewModel)
        {
            var resultado = await participanteApplicationService.CriarParticipante(new Application.DTO.ParticipanteDTO()
            {
                Id = participanteViewModel.Id,
                Nome = participanteViewModel.Nome,
                Email = participanteViewModel.Email

            });

            return resultado.ToActionResult();

        }

        [HttpPut]
        [Route("{id}/alterarnome")]
        public async Task<IActionResult> AlterarNome([FromBody] AlterarNomeViewModel alterarNomeViewModel,[FromRoute] Guid id)
        {
            return 
                (await participanteApplicationService.AlterarNomeParticipante(id, alterarNomeViewModel.Nome))
                .ToActionResult();
        }

        [HttpPut]
        [Route("{id}/alteraremail")]
        public async Task<IActionResult> AlterarEmail([FromBody] AlterarEmailViewModel alterarEmailViewModel, [FromRoute] Guid id)
        {
            return
                (await participanteApplicationService.AlterarEmailParticipante(id, alterarEmailViewModel.Email))
                .ToActionResult();
        }

        [HttpGet]
        [Route("{email}/retornarporemail")]
        public async Task<IActionResult> RetornarPorEmail([FromRoute] string email)
        {
            return 
                ( await participanteApplicationService.RetornarParticipantePorEmail(email))
                .ToActionResult();
        }
    }
}