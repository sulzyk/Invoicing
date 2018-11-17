using Invoicing.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invoicing.DataAccess
{
    public class DataContext : DbContext
    {
        public DataContext() :base("DefaultConnection")
        {

        }

        private string _userName = "system";

        public string UserName
        {
            get { return _userName; }
            set { _userName = value; }
        }

        private DateTime _now = DateTime.Now;

        public DateTime Now
        {
            get { return _now; }
            set { _now = value; }
        }

        public DbSet<InvoiceHeader> InvoiceHeaders { get; set; }

        public DbSet<InvoiceSpecyfication> InvoiceSpecyfications { get; set; }

        public override int SaveChanges()
        {
            ChangeTracker.DetectChanges();

            ObjectContext ctx = ((IObjectContextAdapter)this).ObjectContext;

            foreach (var entity in ctx.ObjectStateManager.GetObjectStateEntries(EntityState.Modified))
            {
                BaseModel baseObject = entity.Entity as BaseModel;

                if (baseObject == null)
                {
                    continue;
                }

                baseObject.UpdatedDate = Now;
                baseObject.UpdatedUser = UserName;
            }

            foreach (var entity in ctx.ObjectStateManager.GetObjectStateEntries(EntityState.Added))
            {
                BaseModel baseObject = entity.Entity as BaseModel;

                if (baseObject == null)
                {
                    continue;
                }

                baseObject.CreatedDate = Now;
                baseObject.UpdatedDate = Now;
                baseObject.CreatedUser = UserName;
                baseObject.UpdatedUser = UserName;
            }

            return base.SaveChanges();
        }
    }
}
