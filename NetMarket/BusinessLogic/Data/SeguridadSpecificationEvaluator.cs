using Core.Specifications;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Data
{
    public class SeguridadSpecificationEvaluator<T> where T : IdentityUser
    {
        public static IQueryable<T> GetQuery(IQueryable<T> inputQuery, ISpecification<T> spect)
        {
            if (spect.Criteria != null)
            {
                inputQuery = inputQuery.Where(spect.Criteria);
            }

            if (spect.OrderBy != null)
            {
                inputQuery = inputQuery.OrderBy(spect.OrderBy);

            }
            if (spect.OrderByDescending != null)
            {
                inputQuery = inputQuery.OrderByDescending(spect.OrderByDescending);

            }

            if (spect.IsPagingEnable)
            {
                inputQuery = inputQuery.Skip(spect.Skip).Take(spect.Take);
            }
            inputQuery = spect.Includes.Aggregate(inputQuery, (current, include) => current.Include(include));
            return inputQuery;
        }
    }
}
