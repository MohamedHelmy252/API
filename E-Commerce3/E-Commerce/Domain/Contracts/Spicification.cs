using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Contracts
{
    public abstract class Spicification<T> where T : class
    {
        //To Take Condition and Include Expression We Must Create Constructor

        public Spicification(Expression<Func<T, bool>>? criteria)
        {
            this.Criteria = criteria;
        }


        //===========================================================================

        //Signature for 2 Properties

        //1- Criteria => Condition
        public Expression<Func<T, bool>>? Criteria { get; private set; }

        //2- Include
        public List<Expression<Func<T, Object>>> IncludeExPression { get; private set; } = new();
        //===========================================================================

        public void AddInclude(Expression<Func<T, Object>> expression)
        =>IncludeExPression.Add(expression);
        
    }


    }
