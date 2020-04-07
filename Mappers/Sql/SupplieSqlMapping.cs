using Dapper.FluentMap.Mapping;
using RiseFoodServiceWork.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RiseFoodServiceWork.Mappers
{
    public class SupplieSqlMapping : EntityMap<Supplie>
    {
        public SupplieSqlMapping()
        {
            Map(s => s.Id).ToColumn("IN_ID");
            Map(s => s.Code).ToColumn("IN_COD");
            Map(s => s.Name).ToColumn("IN_NOM");
            Map(s => s.Price).ToColumn("IN_VALOR");
            Map(s => s.Category).ToColumn("Category");
        }
    }
}
