using Mobilion.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Mobilion.Core.Abstract
{
    public interface IEntityRepository<Type> where Type: class,IEntity,new()
    {
        List<Type> GetList(Expression<Func<Type, bool>> filter = null);
        Type Get(Expression<Func<Type, bool>> filter);
        Type Add(Type entity);
        Type Update(Type entity);
        void Delete(Type entity);
    }
}
