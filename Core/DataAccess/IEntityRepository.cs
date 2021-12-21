using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Core.DataAccess
{
    //T: Çalışacağımız tiptir.
    //class: T Referans tip olabilir. >> Generic Constraint
    //IEntity: T ya IEntity olabilir ya da IEntity i implemente eden nesne olabilir. >> Generic Constraint
    //new(): newlenebilir olmalı. T IEntity olamaz. interfaceler newlenemez. >> Generic Constraint

    //T miz sadece veri tabanı nesneleriyle çalışan repository oldu.

    //Linqdaki expression verebilmenin syntaxı Expression<Func<T,bool>> filter=null
    //Bu sayede kategoriye göre getir, fiyata göre getir gibi metotlardan kurtuluyoruz.
    public interface IEntityRepository<T> where T:class,IEntity, new()
    {
        List<T> GetAll(Expression<Func<T, bool>> filter = null);
        T Get(Expression<Func<T, bool>> filter); //Tek bir data için.
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        //T GetById(int id); Expression dan dolayı artık buna ihtiyaç yok.
    }
}
