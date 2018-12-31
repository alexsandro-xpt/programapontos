using ProgramaPontos.Application.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;

using Xunit;

namespace ProgramaPontos.Application.Testes
{
    public class ExtratoApplicationServiceTests : TestsBase
    {
        private readonly IExtratoApplicationService extratoApplicationService;
        private readonly IParticipanteApplicationService participanteApplicationService;

        public ExtratoApplicationServiceTests()
        {
            extratoApplicationService = ServiceProvider.GetService<IExtratoApplicationService>();
            participanteApplicationService = ServiceProvider.GetService<IParticipanteApplicationService>();
        }

        private Guid CriarParticipanteRetornaId()
        {
            var participanteId = Guid.NewGuid();
      

            participanteApplicationService.CriarParticipante(new DTO.ParticipanteDTO()
            {
                Id = participanteId,
                Nome= Faker.Name.FullName(),
                Email = Faker.Internet.Email()
            }).Wait();


            return participanteId;
        }

        [Fact(DisplayName ="Criar Extrato")]
        public void CriarExtrato()
        {
            //arrange...
            var participanteId = CriarParticipanteRetornaId();
            var extratoId = Guid.NewGuid();

            //act...
            var resultado = extratoApplicationService.CriarExtratoParticipante(extratoId,participanteId).Result;

            //assert...
            Assert.True(resultado.Sucesso, resultado.Mensagem);
        }

        [Fact(DisplayName = "Adicionar Pontos Participante")]
        public void AdicionarPontosParticipante()
        {
            //arrange...
            var participanteId = CriarParticipanteRetornaId();
            CriarExtratoParticipante(participanteId);

            //act...
            var resultado = extratoApplicationService.AdicionarPontosParticipante(participanteId, 30).Result ;

            //assert...
            Assert.True(resultado.Sucesso);


        }

        private void CriarExtratoParticipante(Guid participanteId)
        {
            extratoApplicationService.CriarExtratoParticipante(Guid.NewGuid(), participanteId).Wait();


            var tentativas = 1;
            var continua = true;

            while (continua)
            {
                
                var resultado= extratoApplicationService.RetornarExtratoParticipante(participanteId).Result;
                continua = (resultado.Dados == null) && tentativas<10;
                tentativas += 1;

                System.Threading.Thread.Sleep(1000);
            }

            
          
        }

        [Fact(DisplayName = "Remover Pontos Participante")] 
        public void RemoverPontosParticipante()
        {
            //arrange...
            var participanteId = CriarParticipanteRetornaId();
            CriarExtratoParticipante(participanteId);
            extratoApplicationService.AdicionarPontosParticipante(participanteId, 30);

            //act...
            var resultado = extratoApplicationService.RemoverPontosParticipante(participanteId, 5).Result;

            //assert...
            Assert.True(resultado.Sucesso);
        }

        [Fact(DisplayName ="Quebra Pontos Participante")]
        public void QuebraPontosParticipante()
        {
            var participanteId = CriarParticipanteRetornaId();
            CriarExtratoParticipante(participanteId);

            var resultado = extratoApplicationService.EfetuarQuebraPontosParticipante(participanteId, 100).Result;

            Assert.True(resultado.Sucesso);
        }

        [Fact(DisplayName = "Remover Pontos Alem Do Saldo")]
        public void RemoverPontosAlemDoSaldo()
        {
            var participanteId = CriarParticipanteRetornaId();
            CriarExtratoParticipante(participanteId);
            extratoApplicationService.AdicionarPontosParticipante(participanteId, 30);

            var resultado = extratoApplicationService.RemoverPontosParticipante(participanteId, 50).Result;

            Assert.False(resultado.Sucesso);

            
        }

        [Fact(DisplayName = "Retornar Saldo Participante")]
        public void RetornarSaldoParticipante()
        {
            //arrange...
            var participanteId = CriarParticipanteRetornaId();
            var pontosAdicionados = 30;
            var pontosRetirados = 25;
            var saldo = pontosAdicionados - pontosRetirados;
            CriarExtratoParticipante(participanteId);
            extratoApplicationService.AdicionarPontosParticipante(participanteId, 30);
            extratoApplicationService.RemoverPontosParticipante(participanteId, 25);

            //act...
            var resultado = extratoApplicationService.RetornarSaldoParticipante(participanteId).Result;
            //assert...
            Assert.True(resultado.Sucesso && resultado.Dados == saldo);


        }
    }
}
