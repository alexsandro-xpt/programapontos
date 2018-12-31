using Microsoft.AspNetCore.Mvc;
using ProgramaPontos.API.Extensions;
using ProgramaPontos.API.ViewModel;
using ProgramaPontos.Application.Services.Interfaces;
using System;
using System.Threading.Tasks;

namespace ProgramaPontos.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExtratoController : ControllerBase
    {
        private readonly IExtratoApplicationService extratoApplicationService;

        public ExtratoController(IExtratoApplicationService extratoApplicationService)
        {
            this.extratoApplicationService = extratoApplicationService;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ExtratoViewModel extratoViewModel)
        {
            return (await extratoApplicationService.CriarExtratoParticipante(extratoViewModel.Id, extratoViewModel.ParticipanteId)).ToActionResult();
        }

        [HttpPost]
        [Route("{participanteId}/adicionarpontosparticipante")]
        public async Task<IActionResult> AdicionarPontosParticipante(
            [FromRoute] Guid participanteId,
            PontosViewModel pontosViewModel)
        {
            return (await extratoApplicationService.AdicionarPontosParticipante(participanteId, pontosViewModel.Pontos)).ToActionResult();
        }

        [HttpPost]
        [Route("{participanteId}/removerpontosparticipante")]
        public async Task<IActionResult> RemoverPontosParticipante(
           [FromRoute] Guid participanteId,
           PontosViewModel pontosViewModel)
        {
            return (await extratoApplicationService.RemoverPontosParticipante(participanteId, pontosViewModel.Pontos)).ToActionResult();
        }

        [HttpPost]
        [Route("{participanteId}/quebrapontosparticipante")]
        public async Task<IActionResult> QuebraPontosParticipante(
           [FromRoute] Guid participanteId,
           PontosViewModel pontosViewModel)
        {
            return (await extratoApplicationService.EfetuarQuebraPontosParticipante(participanteId, pontosViewModel.Pontos)).ToActionResult();
        }

        [HttpGet]
        [Route("{participanteId}/extratoparticipante")]
        public async Task<IActionResult> Get(Guid participanteId)
        {
            return (await extratoApplicationService.RetornarExtratoParticipante(participanteId)).ToActionResult();


        }

        [HttpGet]
        [Route("{participanteId}/saldoparticipante")]
        public async Task<IActionResult> GetSaldoParticipante(Guid participanteId)
        {
            return (await extratoApplicationService.RetornarSaldoParticipante(participanteId)).ToActionResult();
        }
    }
}