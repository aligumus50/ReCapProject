using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Core.DataAccess.EntityFramework
{
    //TEntity: Bana çalışacağım tabloyu ver.
    //TContext: Bana çalışacağım contexti ver.

    //TEntity: IEntityden inherit edilmesi gerek.
    //TContext: DbContext den inherit edilmesi gerek.

    //IEntityRepository<TEntity> Tablom ne ise onun EntityReposunu alacak.

    //Bu base yapısı ile açtığımız her tabloya ekleme, silme, güncelleme, filtreli gibi temel işlemleri ayrı ayrı yapmayacağız.
    public class EfEntityRepositoryBase<TEntity, TContext>:IEntityRepository<TEntity> 
        where TEntity: class, IEntity, new()
        where TContext: DbContext, new()
    {
        public void Add(TEntity entity)
        {
            //context: veri kaynağı
            //Entry: eşleştir.

            //Veri kaynağımdan benim gönderdiğim entityi bi tane nesneye eşleştir.
            using (TContext context = new TContext())
            {
                var addedEntity = context.Entry(entity); //referansı yakala
                addedEntity.State = EntityState.Added; ///o eklenecek nesne
                context.SaveChanges(); //kaydet
            }
        }

        public void Delete(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                var deletedEntity = context.Entry(entity);
                deletedEntity.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            using (TContext context = new TContext())
            {
                return context.Set<TEntity>().SingleOrDefault(filter);
            }
        }

        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            using (TContext context = new TContext())
            {
                //context.Set<Car>().ToList() Db setteki Car a yerleş ve tabloyu listeye çevir. select * from cars
                //where(filter): filtreyi uygula.
                //Gelen filtre null ise sol taraf filtre vermişse sağ taraf çalışır.
                return filter == null ? context.Set<TEntity>().ToList() : context.Set<TEntity>().Where(filter).ToList();
            }
        }

        public void Update(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                var updatedEntity = context.Entry(entity);
                updatedEntity.State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
