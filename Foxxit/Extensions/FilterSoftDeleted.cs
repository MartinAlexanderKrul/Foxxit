using System;
using System.Linq;
using System.Reflection;
using Foxxit.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Foxxit.Extensions
{
    public static class FilterSoftDeleted
    {
        private static readonly MethodInfo SetSoftDeleteFilterMethod = typeof(FilterSoftDeleted)
           .GetMethods(BindingFlags.Public | BindingFlags.Static)
           .Single(t => t.IsGenericMethod && t.Name == "SetSoftDeleteFilter");

        public static void SetSoftDeleteFilter(this ModelBuilder modelBuilder, Type entityType)
        {
            SetSoftDeleteFilterMethod.MakeGenericMethod(entityType)
                .Invoke(null, new object[] { modelBuilder });
        }

        public static void SetSoftDeleteFilter<T>(this ModelBuilder modelBuilder)
            where T : class, ISoftDeletable
        {
            modelBuilder.Entity<T>().HasQueryFilter(x => !x.IsDeleted);
        }
    }
}