using System;

namespace ProgramaPontos.Domain.Aggregates.ExtratoAggregate
{
    public class Movimentacao
    {
        public enum TipoMovimentacao
        {
            Entrada,
            Saida,
            Quebra
        }

        public DateTime Data { get; }
        public TipoMovimentacao Tipo { get; }
        public int Pontos { get; }

        public Movimentacao(DateTime data, TipoMovimentacao tipo, int pontos)
        {
            Data = data;
            Tipo = tipo;
            Pontos = pontos;
        }

    }
}