using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Contracts;
using Microsoft.EntityFrameworkCore;

namespace Presestance.Repositories
{
    public class SpecificationEvaluator<T>
    {
        // Inside this Class Function Connect 
        public IQueryable<T> GetQuery<T> 
        (IQueryable<T> InputQuery, Spicification<T> spicification)
            where T : class
        {
            //Set DbSet
            var query = InputQuery;
            //Criteria
            if(spicification.Criteria != null)
            {
                query = query.Where(spicification.Criteria);
            }

            //Include => Relationship
           
                //foreach (var Item in spicification.IncludeExPression)
                //{
                //    query = query.Include(Item);
                //}
            
            query = spicification.IncludeExPression
                .Aggregate(query, (current, include) => current.Include(include));

            //Return Query



            #region For Sorting 

            if (spicification.OrderBy != null)
            {
                query = query.OrderBy(spicification.OrderBy);
            }
            else if (spicification.OrderByDescending is not null)
            {
                query = query.OrderByDescending(spicification.OrderByDescending);

            }
            #endregion

            return query;
        }


    }
}
