
using Bogus;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProgramaPontos.Application.Services.Interfaces;
using ProgramaPontos.Infra.Ioc.AspNetCore;
using System;
using Xunit;

namespace ProgramaPontos.Application.Testes
{
    public class ParticipanteApplicationServiceTests : TestsBase
    {
        
        private readonly IParticipanteApplicationService participanteApplicationService;

        public ParticipanteApplicationServiceTests():base()
        {
           
            participanteApplicationService = ServiceProvider.GetService<IParticipanteApplicationService>();

        }
        [Fact(DisplayName ="Criar participante")]
        public void CriarParticipanteComSucesso()
        {
            //arrange...
            var nome = Faker.Name.FullName();
            var email = Faker.Internet.Email();

            //act...
            var resultado = CriarParticipante(nome, email);

            //assert...
            Assert.True(resultado.Resultado.Sucesso);

        }


        [Fact(DisplayName = "Criar participante sem nome")]
        public void CriarParticipanteSemNome()
        {
            //arrange...
            var nome = string.Empty;
            var email = Faker.Internet.Email();

            //act...
            var resultado = CriarParticipante(nome, email);

            //assert...
            Assert.False(resultado.Resultado.Sucesso, resultado.Resultado.Mensagem);

        }

        private (Resultado Resultado,Guid Id) CriarParticipante(string nome, string email)
        {
            var id = Guid.NewGuid();
            return (participanteApplicationService.CriarParticipante(new DTO.ParticipanteDTO()
            {
                Id = id,
                Nome = nome,
                Email = email

            }).Result, id);
        }

        [Fact(DisplayName ="Alterar nome participante")]
        public void AlterarNomeParticipante()
        {
            //arrange...
            var nome = Faker.Name.FullName();
            var email = Faker.Internet.Email();
            var resultadoCriacaoParticipante = CriarParticipante(nome,email);

            nome = Faker.Name.FullName();
            var id = resultadoCriacaoParticipante.Id;

            //act...
            var resultado = participanteApplicationService.AlterarNomeParticipante(id, nome)
                .Result;

            //assert...
            Assert.True(resultado.Sucesso, resultado.Mensagem);

        }

        [Fact(DisplayName = "Alterar nome participante para nome vazio")]
        public void AlterarNomeParticipanteParaNomeVazio()
        {
            //arrange...
            var nome = Faker.Name.FullName();
            var email = Faker.Internet.Email();
            var resultadoCriacaoParticipante = CriarParticipante(nome, email);

            nome = string.Empty;
            var id = resultadoCriacaoParticipante.Id;

            //act...
            var resultado = participanteApplicationService.AlterarNomeParticipante(id, nome)
                .Result;

            //assert...
            Assert.False(resultado.Sucesso, resultado.Mensagem);

        }

        [Fact(DisplayName = "Criar participante sem email")]
        public void CriarParticipanteSemEmail()
        {
            //arrange...
            var nome = Faker.Name.FullName();
            var email = string.Empty;

            //act...
            var resultado = participanteApplicationService.CriarParticipante(new DTO.ParticipanteDTO()
            {
                Id = Guid.NewGuid(),
                Nome = nome,
                Email = email
            }).Result; 

            //assert...
            Assert.False(resultado.Sucesso, resultado.Mensagem);

        }

        [Fact(DisplayName = "Remover email do participante")]
        public void RemoverEmailParticipante()
        {
            //arrange...
            var nome = Faker.Name.FullName();
            var email = Faker.Internet.Email();
            var resultadoCriacaoParticipante = CriarParticipante(nome, email);
            email = string.Empty;
            var id = resultadoCriacaoParticipante.Id;

            //act...
            var resultado = participanteApplicationService.AlterarEmailParticipante(id, email)
                .Result;

            //assert...
            Assert.False(resultado.Sucesso, resultado.Mensagem);

        }

    }
}
