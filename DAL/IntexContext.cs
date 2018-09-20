using intex.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace intex.DAL
{
    public class IntexContext : DbContext
    {
        public IntexContext() : base("IntexContext")
        {
        }

        public DbSet<Assay> Assay { get; set; }
        public DbSet<AssayTest> AssayTest { get; set; }
        public DbSet<Compound> Compound { get; set; }
        public DbSet<CompoundSequence> CompoundSequence { get; set; }
        public DbSet<Customer> Customer { get; set; }
        public DbSet<Employee> Employee { get; set; }
        public DbSet<EmployeeTest> EmployeeTest { get; set; }
        public DbSet<Invoice> Invoice { get; set; }
        public DbSet<Material> Material { get; set; }
        public DbSet<Office> Office { get; set; }
        public DbSet<OrderedAssay> OrderedAssay { get; set; }
        public DbSet<Position> Position { get; set; }
        public DbSet<Sample> Sample { get; set; }
        public DbSet<Status> Status { get; set; }
        public DbSet<Test> Test { get; set; }
        public DbSet<TestInstance> TestInstance { get; set; }
        public DbSet<WorkOrderInfo> WorkOrderInfo { get; set; }

        //public System.Data.Entity.DbSet<intex.Models.WorkOrderInfo> WorkOrderInfoes { get; set; }

        public System.Data.Entity.DbSet<intex.Models.OrderedAssayInfo> OrderedAssayInfoes { get; set; }

        public System.Data.Entity.DbSet<intex.Models.TestInfo> TestInfoes { get; set; }
        public System.Data.Entity.DbSet<intex.Models.LabDashboardInfo> LabDashboardInfoes { get; set; }

        public System.Data.Entity.DbSet<intex.Models.LabCompoundInfo> LabCompoundInfoes { get; set; }

        public System.Data.Entity.DbSet<intex.Models.LabTestInfo> LabTestInfoes { get; set; }
        public System.Data.Entity.DbSet<intex.Models.Manager> Managers { get; set; }
        public System.Data.Entity.DbSet<intex.Models.AddWorkOrder> AddWorkOrders { get; set; }

        public System.Data.Entity.DbSet<intex.Models.StartWorkOrder> StartWorkOrders { get; set; }

        public System.Data.Entity.DbSet<intex.Models.WorkOrder> WorkOrders { get; set; }

        public System.Data.Entity.DbSet<intex.Models.ScheduleAssay> ScheduleAssays { get; set; }
        public System.Data.Entity.DbSet<intex.Models.LabAssayQuotes> LabAssayQuotes { get; set; }

        public System.Data.Entity.DbSet<intex.Models.LabAssaySchedule> LabAssaySchedules { get; set; }
    }
}