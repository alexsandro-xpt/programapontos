using Nest;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProgramaPontos.ReadModel.ElasticSearch.Extensions
{
    public static class ElasticSearchIndexExtensions
    {
        public static void ThrowIfNotValid(this IResponse response)
        {
            if(!response.IsValid)
            {
                throw response.OriginalException;
            }

        }
    }
}
