using Dapper.FluentMap;
using Microsoft.Extensions.DependencyInjection;
using RiseFoodServiceWork.Mappers;
using System;
using System.Collections.Generic;
using System.Text;

namespace RiseFoodServiceWork.Extensions
{
    public static class Mappers
    {
        public static IServiceCollection MapperModels( this IServiceCollection services)
        {
            //Mapping models Dapper
            FluentMapper.Initialize(config =>
            {
                config.AddMap(new SupplieSqlMapping());
            });

            //Mapping models MongoDb
            SupplieMongoMapping.Mapper();

            return services;
        }
    }
}
