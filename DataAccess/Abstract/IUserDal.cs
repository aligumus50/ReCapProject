using Core.DataAccess;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
    //Baseden aldık temel operasyonları.
    public interface IUserDal : IEntityRepository<User>
    {
        //Entity e ait özel operasyonlar sadece buraya yazılır.
    }
}
