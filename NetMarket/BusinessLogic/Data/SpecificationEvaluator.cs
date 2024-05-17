using Core.Entities;
using Core.Specifications;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Data
{
    public class SpecificationEvaluator<T> where T : ClaseBase
    {
        public static IQueryable<T> GetQuery(IQueryable<T> inputQuery,ISpecification<T> spect)
        { 
        if(spect.Criteria != null)
            {
                inputQuery = inputQuery.Where(spect.Criteria);
            }
            inputQuery = spect.Includes.Aggregate(inputQuery, (current, include) => current.Include(include));
            return inputQuery;
        }

       
    }
}
