﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Zoo.Base
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class Zoo_Pr6Entities : DbContext
    {
        public Zoo_Pr6Entities()
            : base("name=Zoo_Pr6Entities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Animal> Animal { get; set; }
        public virtual DbSet<Cell> Cell { get; set; }
        public virtual DbSet<Employee> Employee { get; set; }
        public virtual DbSet<Event> Event { get; set; }
        public virtual DbSet<Feedback> Feedback { get; set; }
        public virtual DbSet<History_Family_Tree> History_Family_Tree { get; set; }
        public virtual DbSet<List_Family_Tree> List_Family_Tree { get; set; }
        public virtual DbSet<Login> Login { get; set; }
        public virtual DbSet<Loyalty_Program> Loyalty_Program { get; set; }
        public virtual DbSet<Med_History> Med_History { get; set; }
        public virtual DbSet<Med_Procedure> Med_Procedure { get; set; }
        public virtual DbSet<MedCard> MedCard { get; set; }
        public virtual DbSet<role> role { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<Visitor> Visitor { get; set; }
    }
}
