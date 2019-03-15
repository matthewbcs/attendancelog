using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeAttendanceManager.Repository
{
    public class DbContextFiles
    {
          #region Unit of work

    public interface IMyDbContext : System.IDisposable
    {
        System.Data.Entity.DbSet<AttendanceStatu> AttendanceStatus { get; set; } // AttendanceStatus
        System.Data.Entity.DbSet<Employee> Employees { get; set; } // Employee
        System.Data.Entity.DbSet<EmployeeAnnualLeave> EmployeeAnnualLeaves { get; set; } // EmployeeAnnualLeave
        System.Data.Entity.DbSet<EmployeeAttendance> EmployeeAttendances { get; set; } // EmployeeAttendance

        int SaveChanges();
        System.Threading.Tasks.Task<int> SaveChangesAsync();
        System.Threading.Tasks.Task<int> SaveChangesAsync(System.Threading.CancellationToken cancellationToken);
        System.Data.Entity.Infrastructure.DbChangeTracker ChangeTracker { get; }
        System.Data.Entity.Infrastructure.DbContextConfiguration Configuration { get; }
        System.Data.Entity.Database Database { get; }
        System.Data.Entity.Infrastructure.DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;
        System.Data.Entity.Infrastructure.DbEntityEntry Entry(object entity);
        System.Collections.Generic.IEnumerable<System.Data.Entity.Validation.DbEntityValidationResult> GetValidationErrors();
        System.Data.Entity.DbSet Set(System.Type entityType);
        System.Data.Entity.DbSet<TEntity> Set<TEntity>() where TEntity : class;
        string ToString();
    }

    #endregion

    #region Database context

    [System.CodeDom.Compiler.GeneratedCode("EF.Reverse.POCO.Generator", "2.37.2.0")]
    public class MyDbContext : System.Data.Entity.DbContext, IMyDbContext
    {
        public System.Data.Entity.DbSet<AttendanceStatu> AttendanceStatus { get; set; } // AttendanceStatus
        public System.Data.Entity.DbSet<Employee> Employees { get; set; } // Employee
        public System.Data.Entity.DbSet<EmployeeAnnualLeave> EmployeeAnnualLeaves { get; set; } // EmployeeAnnualLeave
        public System.Data.Entity.DbSet<EmployeeAttendance> EmployeeAttendances { get; set; } // EmployeeAttendance

        static MyDbContext()
        {
            System.Data.Entity.Database.SetInitializer<MyDbContext>(null);
        }

        public MyDbContext()
            : base("Name=EmployeeManagerConnectionString")
        {
        }

        public MyDbContext(string connectionString)
            : base(connectionString)
        {
        }

        public MyDbContext(string connectionString, System.Data.Entity.Infrastructure.DbCompiledModel model)
            : base(connectionString, model)
        {
        }

        public MyDbContext(System.Data.Common.DbConnection existingConnection, bool contextOwnsConnection)
            : base(existingConnection, contextOwnsConnection)
        {
        }

        public MyDbContext(System.Data.Common.DbConnection existingConnection, System.Data.Entity.Infrastructure.DbCompiledModel model, bool contextOwnsConnection)
            : base(existingConnection, model, contextOwnsConnection)
        {
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }

        //public bool IsSqlParameterNull(System.Data.SqlClient.SqlParameter param)
        //{
        //    var sqlValue = param.SqlValue;
        //    var nullableValue = sqlValue as System.Data.SqlTypes.INullable;
        //    if (nullableValue != null)
        //        return nullableValue.IsNull;
        //    return (sqlValue == null || sqlValue == System.DBNull.Value);
        //}

        protected override void OnModelCreating(System.Data.Entity.DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Configurations.Add(new AttendanceStatuConfiguration());
            modelBuilder.Configurations.Add(new EmployeeConfiguration());
            modelBuilder.Configurations.Add(new EmployeeAnnualLeaveConfiguration());
            modelBuilder.Configurations.Add(new EmployeeAttendanceConfiguration());
        }

        public static System.Data.Entity.DbModelBuilder CreateModel(System.Data.Entity.DbModelBuilder modelBuilder, string schema)
        {
            modelBuilder.Configurations.Add(new AttendanceStatuConfiguration(schema));
            modelBuilder.Configurations.Add(new EmployeeConfiguration(schema));
            modelBuilder.Configurations.Add(new EmployeeAnnualLeaveConfiguration(schema));
            modelBuilder.Configurations.Add(new EmployeeAttendanceConfiguration(schema));
            return modelBuilder;
        }
    }
    #endregion

    #region Database context factory

    public class MyDbContextFactory : System.Data.Entity.Infrastructure.IDbContextFactory<MyDbContext>
    {
        public MyDbContext Create()
        {
            return new MyDbContext();
        }
    }

    #endregion

    #region Fake Database context

    [System.CodeDom.Compiler.GeneratedCode("EF.Reverse.POCO.Generator", "2.37.2.0")]
    public class FakeMyDbContext : IMyDbContext
    {
        public System.Data.Entity.DbSet<AttendanceStatu> AttendanceStatus { get; set; }
        public System.Data.Entity.DbSet<Employee> Employees { get; set; }
        public System.Data.Entity.DbSet<EmployeeAnnualLeave> EmployeeAnnualLeaves { get; set; }
        public System.Data.Entity.DbSet<EmployeeAttendance> EmployeeAttendances { get; set; }

        public FakeMyDbContext()
        {
            _changeTracker = null;
            _configuration = null;
            _database = null;

            AttendanceStatus = new FakeDbSet<AttendanceStatu>("AttendanceStatusId");
            Employees = new FakeDbSet<Employee>("EmployeeId");
            EmployeeAnnualLeaves = new FakeDbSet<EmployeeAnnualLeave>("EmployeeAnnualLeaveId");
            EmployeeAttendances = new FakeDbSet<EmployeeAttendance>("EmployeeAttendanceId");
        }

        public int SaveChangesCount { get; private set; }
        public int SaveChanges()
        {
            ++SaveChangesCount;
            return 1;
        }

        public System.Threading.Tasks.Task<int> SaveChangesAsync()
        {
            ++SaveChangesCount;
            return System.Threading.Tasks.Task<int>.Factory.StartNew(() => 1);
        }

        public System.Threading.Tasks.Task<int> SaveChangesAsync(System.Threading.CancellationToken cancellationToken)
        {
            ++SaveChangesCount;
            return System.Threading.Tasks.Task<int>.Factory.StartNew(() => 1, cancellationToken);
        }

        protected virtual void Dispose(bool disposing)
        {
        }

        public void Dispose()
        {
            Dispose(true);
        }

        private System.Data.Entity.Infrastructure.DbChangeTracker _changeTracker;
        public System.Data.Entity.Infrastructure.DbChangeTracker ChangeTracker { get { return _changeTracker; } }
        private System.Data.Entity.Infrastructure.DbContextConfiguration _configuration;
        public System.Data.Entity.Infrastructure.DbContextConfiguration Configuration { get { return _configuration; } }
        private System.Data.Entity.Database _database;
        public System.Data.Entity.Database Database { get { return _database; } }
        public System.Data.Entity.Infrastructure.DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class
        {
            throw new System.NotImplementedException();
        }
        public System.Data.Entity.Infrastructure.DbEntityEntry Entry(object entity)
        {
            throw new System.NotImplementedException();
        }
        public System.Collections.Generic.IEnumerable<System.Data.Entity.Validation.DbEntityValidationResult> GetValidationErrors()
        {
            throw new System.NotImplementedException();
        }
        public System.Data.Entity.DbSet Set(System.Type entityType)
        {
            throw new System.NotImplementedException();
        }
        public System.Data.Entity.DbSet<TEntity> Set<TEntity>() where TEntity : class
        {
            throw new System.NotImplementedException();
        }
        public override string ToString()
        {
            throw new System.NotImplementedException();
        }

    }

    // ************************************************************************
    // Fake DbSet
    // Implementing Find:
    //      The Find method is difficult to implement in a generic fashion. If
    //      you need to test code that makes use of the Find method it is
    //      easiest to create a test DbSet for each of the entity types that
    //      need to support find. You can then write logic to find that
    //      particular type of entity, as shown below:
    //      public class FakeBlogDbSet : FakeDbSet<Blog>
    //      {
    //          public override Blog Find(params object[] keyValues)
    //          {
    //              var id = (int) keyValues.Single();
    //              return this.SingleOrDefault(b => b.BlogId == id);
    //          }
    //      }
    //      Read more about it here: https://msdn.microsoft.com/en-us/data/dn314431.aspx
    [System.CodeDom.Compiler.GeneratedCode("EF.Reverse.POCO.Generator", "2.37.2.0")]
    public class FakeDbSet<TEntity> : System.Data.Entity.DbSet<TEntity>, IQueryable, System.Collections.Generic.IEnumerable<TEntity>, System.Data.Entity.Infrastructure.IDbAsyncEnumerable<TEntity> where TEntity : class
    {
        private readonly System.Reflection.PropertyInfo[] _primaryKeys;
        private readonly System.Collections.ObjectModel.ObservableCollection<TEntity> _data;
        private readonly IQueryable _query;

        public FakeDbSet()
        {
            _data = new System.Collections.ObjectModel.ObservableCollection<TEntity>();
            _query = _data.AsQueryable();
        }

        public FakeDbSet(params string[] primaryKeys)
        {
            _primaryKeys = typeof(TEntity).GetProperties().Where(x => primaryKeys.Contains(x.Name)).ToArray();
            _data = new System.Collections.ObjectModel.ObservableCollection<TEntity>();
            _query = _data.AsQueryable();
        }

        public override TEntity Find(params object[] keyValues)
        {
            if (_primaryKeys == null)
                throw new System.ArgumentException("No primary keys defined");
            if (keyValues.Length != _primaryKeys.Length)
                throw new System.ArgumentException("Incorrect number of keys passed to Find method");

            var keyQuery = this.AsQueryable();
            keyQuery = keyValues
                .Select((t, i) => i)
                .Aggregate(keyQuery,
                    (current, x) =>
                        current.Where(entity => _primaryKeys[x].GetValue(entity, null).Equals(keyValues[x])));

            return keyQuery.SingleOrDefault();
        }

        public override System.Threading.Tasks.Task<TEntity> FindAsync(System.Threading.CancellationToken cancellationToken, params object[] keyValues)
        {
            return System.Threading.Tasks.Task<TEntity>.Factory.StartNew(() => Find(keyValues), cancellationToken);
        }

        public override System.Threading.Tasks.Task<TEntity> FindAsync(params object[] keyValues)
        {
            return System.Threading.Tasks.Task<TEntity>.Factory.StartNew(() => Find(keyValues));
        }

        public override System.Collections.Generic.IEnumerable<TEntity> AddRange(System.Collections.Generic.IEnumerable<TEntity> entities)
        {
            if (entities == null) throw new System.ArgumentNullException("entities");
            var items = entities.ToList();
            foreach (var entity in items)
            {
                _data.Add(entity);
            }
            return items;
        }

        public override TEntity Add(TEntity item)
        {
            if (item == null) throw new System.ArgumentNullException("item");
            _data.Add(item);
            return item;
        }

        public override System.Collections.Generic.IEnumerable<TEntity> RemoveRange(System.Collections.Generic.IEnumerable<TEntity> entities)
        {
            if (entities == null) throw new System.ArgumentNullException("entities");
            var items = entities.ToList();
            foreach (var entity in items)
            {
                _data.Remove(entity);
            }
            return items;
        }

        public override TEntity Remove(TEntity item)
        {
            if (item == null) throw new System.ArgumentNullException("item");
            _data.Remove(item);
            return item;
        }

        public override TEntity Attach(TEntity item)
        {
            if (item == null) throw new System.ArgumentNullException("item");
            _data.Add(item);
            return item;
        }

        public override TEntity Create()
        {
            return System.Activator.CreateInstance<TEntity>();
        }

        public override TDerivedEntity Create<TDerivedEntity>()
        {
            return System.Activator.CreateInstance<TDerivedEntity>();
        }

        public override System.Collections.ObjectModel.ObservableCollection<TEntity> Local
        {
            get { return _data; }
        }

        System.Type IQueryable.ElementType
        {
            get { return _query.ElementType; }
        }

        System.Linq.Expressions.Expression IQueryable.Expression
        {
            get { return _query.Expression; }
        }

        IQueryProvider IQueryable.Provider
        {
            get { return new FakeDbAsyncQueryProvider<TEntity>(_query.Provider); }
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return _data.GetEnumerator();
        }

        System.Collections.Generic.IEnumerator<TEntity> System.Collections.Generic.IEnumerable<TEntity>.GetEnumerator()
        {
            return _data.GetEnumerator();
        }

        System.Data.Entity.Infrastructure.IDbAsyncEnumerator<TEntity> System.Data.Entity.Infrastructure.IDbAsyncEnumerable<TEntity>.GetAsyncEnumerator()
        {
            return new FakeDbAsyncEnumerator<TEntity>(_data.GetEnumerator());
        }
    }

    [System.CodeDom.Compiler.GeneratedCode("EF.Reverse.POCO.Generator", "2.37.2.0")]
    public class FakeDbAsyncQueryProvider<TEntity> : System.Data.Entity.Infrastructure.IDbAsyncQueryProvider
    {
        private readonly IQueryProvider _inner;

        public FakeDbAsyncQueryProvider(IQueryProvider inner)
        {
            _inner = inner;
        }

        public IQueryable CreateQuery(System.Linq.Expressions.Expression expression)
        {
            var m = expression as System.Linq.Expressions.MethodCallExpression;
            if (m != null)
            {
                var resultType = m.Method.ReturnType; // it shoud be IQueryable<T>
                var tElement = resultType.GetGenericArguments()[0];
                var queryType = typeof(FakeDbAsyncEnumerable<>).MakeGenericType(tElement);
                return (IQueryable) System.Activator.CreateInstance(queryType, expression);
            }
            return new FakeDbAsyncEnumerable<TEntity>(expression);
        }

        public IQueryable<TElement> CreateQuery<TElement>(System.Linq.Expressions.Expression expression)
        {
            var queryType = typeof(FakeDbAsyncEnumerable<>).MakeGenericType(typeof(TElement));
            return (IQueryable<TElement>)System.Activator.CreateInstance(queryType, expression);
        }

        public object Execute(System.Linq.Expressions.Expression expression)
        {
            return _inner.Execute(expression);
        }

        public TResult Execute<TResult>(System.Linq.Expressions.Expression expression)
        {
            return _inner.Execute<TResult>(expression);
        }

        public System.Threading.Tasks.Task<object> ExecuteAsync(System.Linq.Expressions.Expression expression, System.Threading.CancellationToken cancellationToken)
        {
            return System.Threading.Tasks.Task.FromResult(Execute(expression));
        }

        public System.Threading.Tasks.Task<TResult> ExecuteAsync<TResult>(System.Linq.Expressions.Expression expression, System.Threading.CancellationToken cancellationToken)
        {
            return System.Threading.Tasks.Task.FromResult(Execute<TResult>(expression));
        }
    }

    [System.CodeDom.Compiler.GeneratedCode("EF.Reverse.POCO.Generator", "2.37.2.0")]
    public class FakeDbAsyncEnumerable<T> : EnumerableQuery<T>, System.Data.Entity.Infrastructure.IDbAsyncEnumerable<T>, IQueryable<T>
    {
        public FakeDbAsyncEnumerable(System.Collections.Generic.IEnumerable<T> enumerable)
            : base(enumerable)
        { }

        public FakeDbAsyncEnumerable(System.Linq.Expressions.Expression expression)
            : base(expression)
        { }

        public System.Data.Entity.Infrastructure.IDbAsyncEnumerator<T> GetAsyncEnumerator()
        {
            return new FakeDbAsyncEnumerator<T>(this.AsEnumerable().GetEnumerator());
        }

        System.Data.Entity.Infrastructure.IDbAsyncEnumerator System.Data.Entity.Infrastructure.IDbAsyncEnumerable.GetAsyncEnumerator()
        {
            return GetAsyncEnumerator();
        }

        IQueryProvider IQueryable.Provider
        {
            get { return new FakeDbAsyncQueryProvider<T>(this); }
        }
    }

    [System.CodeDom.Compiler.GeneratedCode("EF.Reverse.POCO.Generator", "2.37.2.0")]
    public class FakeDbAsyncEnumerator<T> : System.Data.Entity.Infrastructure.IDbAsyncEnumerator<T>
    {
        private readonly System.Collections.Generic.IEnumerator<T> _inner;

        public FakeDbAsyncEnumerator(System.Collections.Generic.IEnumerator<T> inner)
        {
            _inner = inner;
        }

        public void Dispose()
        {
            _inner.Dispose();
        }

        public System.Threading.Tasks.Task<bool> MoveNextAsync(System.Threading.CancellationToken cancellationToken)
        {
            return System.Threading.Tasks.Task.FromResult(_inner.MoveNext());
        }

        public T Current
        {
            get { return _inner.Current; }
        }

        object System.Data.Entity.Infrastructure.IDbAsyncEnumerator.Current
        {
            get { return Current; }
        }
    }

    #endregion

    #region POCO classes

    // AttendanceStatus
    [System.CodeDom.Compiler.GeneratedCode("EF.Reverse.POCO.Generator", "2.37.2.0")]
    public class AttendanceStatu
    {
        public int AttendanceStatusId { get; set; } // AttendanceStatusId (Primary key)
        public string Status { get; set; } // Status (length: 100)
        public bool IsDeleted { get; set; } // IsDeleted
        public int StatusHourValue { get; set; } // StatusHourValue

        // Reverse navigation

        /// <summary>
        /// Child EmployeeAttendances where [EmployeeAttendance].[AttendanceStatusId] point to this entity (FK_303)
        /// </summary>
        public virtual System.Collections.Generic.ICollection<EmployeeAttendance> EmployeeAttendances { get; set; } // EmployeeAttendance.FK_303

        public AttendanceStatu()
        {
            EmployeeAttendances = new System.Collections.Generic.List<EmployeeAttendance>();
        }
    }

    // Employee
    [System.CodeDom.Compiler.GeneratedCode("EF.Reverse.POCO.Generator", "2.37.2.0")]
    public class Employee
    {
        public int EmployeeId { get; set; } // EmployeeId (Primary key)
        public string Firstname { get; set; } // firstname (length: 200)
        public string Surname { get; set; } // surname (length: 200)
        public System.DateTime AddedOnUtc { get; set; } // AddedOnUtc
        public bool IsDeleted { get; set; } // IsDeleted
        public int? TotalAnnualLeaveCount { get; set; } // TotalAnnualLeaveCount
        public int RemainingAnnualLeaveCount { get; set; } // RemainingAnnualLeaveCount

        // Reverse navigation

        /// <summary>
        /// Child EmployeeAnnualLeaves where [EmployeeAnnualLeave].[EmployeeId] point to this entity (FK_289)
        /// </summary>
        public virtual System.Collections.Generic.ICollection<EmployeeAnnualLeave> EmployeeAnnualLeaves { get; set; } // EmployeeAnnualLeave.FK_289
        /// <summary>
        /// Child EmployeeAttendances where [EmployeeAttendance].[EmployeeId] point to this entity (FK_306)
        /// </summary>
        public virtual System.Collections.Generic.ICollection<EmployeeAttendance> EmployeeAttendances { get; set; } // EmployeeAttendance.FK_306

        public Employee()
        {
            EmployeeAnnualLeaves = new System.Collections.Generic.List<EmployeeAnnualLeave>();
            EmployeeAttendances = new System.Collections.Generic.List<EmployeeAttendance>();
        }
    }

    // EmployeeAnnualLeave
    [System.CodeDom.Compiler.GeneratedCode("EF.Reverse.POCO.Generator", "2.37.2.0")]
    public class EmployeeAnnualLeave
    {
        public int EmployeeAnnualLeaveId { get; set; } // EmployeeAnnualLeaveId (Primary key)
        public System.DateTime AnnualLeaveDateOnUtc { get; set; } // AnnualLeaveDateOnUtc
        public System.DateTime AddedOnUtc { get; set; } // AddedOnUtc
        public int EmployeeId { get; set; } // EmployeeId
        public bool IsHalfDay { get; set; } // IsHalfDay

        public bool? AnnualLeaveAm { get; set; } // 
        public bool? AnnualLeavePm { get; set; } // 

        // Foreign keys

        /// <summary>
        /// Parent Employee pointed by [EmployeeAnnualLeave].([EmployeeId]) (FK_289)
        /// </summary>
        public virtual Employee Employee { get; set; } // FK_289
    }

    // EmployeeAttendance
    [System.CodeDom.Compiler.GeneratedCode("EF.Reverse.POCO.Generator", "2.37.2.0")]
    public class EmployeeAttendance
    {
        public int EmployeeAttendanceId { get; set; } // EmployeeAttendanceId (Primary key)
        public System.DateTime AttendanceDate { get; set; } // AttendanceDate
        public System.DateTime DateAddedOnUtc { get; set; } // DateAddedOnUtc
        public bool IsDeleted { get; set; } // IsDeleted
        public int? AttendanceStatusId { get; set; } // AttendanceStatusId
        public int EmployeeId { get; set; } // EmployeeId

       

        // Foreign keys

        /// <summary>
        /// Parent AttendanceStatu pointed by [EmployeeAttendance].([AttendanceStatusId]) (FK_303)
        /// </summary>
        public virtual AttendanceStatu AttendanceStatu { get; set; } // FK_303

        /// <summary>
        /// Parent Employee pointed by [EmployeeAttendance].([EmployeeId]) (FK_306)
        /// </summary>
        public virtual Employee Employee { get; set; } // FK_306
    }

    #endregion

    #region POCO Configuration

    // AttendanceStatus
    [System.CodeDom.Compiler.GeneratedCode("EF.Reverse.POCO.Generator", "2.37.2.0")]
    public class AttendanceStatuConfiguration : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<AttendanceStatu>
    {
        public AttendanceStatuConfiguration()
            : this("dbo")
        {
        }

        public AttendanceStatuConfiguration(string schema)
        {
            ToTable("AttendanceStatus", schema);
            HasKey(x => x.AttendanceStatusId);

            Property(x => x.AttendanceStatusId).HasColumnName(@"AttendanceStatusId").HasColumnType("int").IsRequired().HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            Property(x => x.Status).HasColumnName(@"Status").HasColumnType("varchar").IsRequired().IsUnicode(false).HasMaxLength(100);
            Property(x => x.IsDeleted).HasColumnName(@"IsDeleted").HasColumnType("bit").IsRequired();
            Property(x => x.StatusHourValue).HasColumnName(@"StatusHourValue").HasColumnType("int").IsOptional();
        }
    }

    // Employee
    [System.CodeDom.Compiler.GeneratedCode("EF.Reverse.POCO.Generator", "2.37.2.0")]
    public class EmployeeConfiguration : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<Employee>
    {
        public EmployeeConfiguration()
            : this("dbo")
        {
        }

        public EmployeeConfiguration(string schema)
        {
            ToTable("Employee", schema);
            HasKey(x => x.EmployeeId);

            Property(x => x.EmployeeId).HasColumnName(@"EmployeeId").HasColumnType("int").IsRequired().HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            Property(x => x.Firstname).HasColumnName(@"firstname").HasColumnType("varchar").IsRequired().IsUnicode(false).HasMaxLength(200);
            Property(x => x.Surname).HasColumnName(@"surname").HasColumnType("varchar").IsRequired().IsUnicode(false).HasMaxLength(200);
            Property(x => x.AddedOnUtc).HasColumnName(@"AddedOnUtc").HasColumnType("datetime2").IsRequired();
            Property(x => x.IsDeleted).HasColumnName(@"IsDeleted").HasColumnType("bit").IsRequired();
            Property(x => x.TotalAnnualLeaveCount).HasColumnName(@"TotalAnnualLeaveCount").HasColumnType("int").IsOptional();
            Property(x => x.RemainingAnnualLeaveCount).HasColumnName(@"RemainingAnnualLeaveCount").HasColumnType("int").IsRequired();
        }
    }

    // EmployeeAnnualLeave
    [System.CodeDom.Compiler.GeneratedCode("EF.Reverse.POCO.Generator", "2.37.2.0")]
    public class EmployeeAnnualLeaveConfiguration : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<EmployeeAnnualLeave>
    {
        public EmployeeAnnualLeaveConfiguration()
            : this("dbo")
        {
        }

        public EmployeeAnnualLeaveConfiguration(string schema)
        {
            ToTable("EmployeeAnnualLeave", schema);
            HasKey(x => x.EmployeeAnnualLeaveId);

            Property(x => x.EmployeeAnnualLeaveId).HasColumnName(@"EmployeeAnnualLeaveId").HasColumnType("int").IsRequired().HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            Property(x => x.AnnualLeaveDateOnUtc).HasColumnName(@"AnnualLeaveDateOnUtc").HasColumnType("datetime2").IsRequired();
            Property(x => x.AddedOnUtc).HasColumnName(@"AddedOnUtc").HasColumnType("datetime2").IsRequired();
            Property(x => x.EmployeeId).HasColumnName(@"EmployeeId").HasColumnType("int").IsRequired();
            Property(x => x.IsHalfDay).HasColumnName(@"IsHalfDay").HasColumnType("bit").IsRequired();
            Property(x => x.AnnualLeaveAm).HasColumnName(@"AnnualLeaveAm").HasColumnType("bit").IsOptional();
            Property(x => x.AnnualLeavePm).HasColumnName(@"AnnualLeavePm").HasColumnType("bit").IsOptional();

            // Foreign keys
            HasRequired(a => a.Employee).WithMany(b => b.EmployeeAnnualLeaves).HasForeignKey(c => c.EmployeeId).WillCascadeOnDelete(false); // FK_289
        }
    }

    // EmployeeAttendance
    [System.CodeDom.Compiler.GeneratedCode("EF.Reverse.POCO.Generator", "2.37.2.0")]
    public class EmployeeAttendanceConfiguration : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<EmployeeAttendance>
    {
        public EmployeeAttendanceConfiguration()
            : this("dbo")
        {
        }

        public EmployeeAttendanceConfiguration(string schema)
        {
            ToTable("EmployeeAttendance", schema);
            HasKey(x => x.EmployeeAttendanceId);

            Property(x => x.EmployeeAttendanceId).HasColumnName(@"EmployeeAttendanceId").HasColumnType("int").IsRequired().HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            Property(x => x.AttendanceDate).HasColumnName(@"AttendanceDate").HasColumnType("datetime2").IsRequired();
            Property(x => x.DateAddedOnUtc).HasColumnName(@"DateAddedOnUtc").HasColumnType("datetime2").IsRequired();
            Property(x => x.IsDeleted).HasColumnName(@"IsDeleted").HasColumnType("bit").IsRequired();
            Property(x => x.AttendanceStatusId).HasColumnName(@"AttendanceStatusId").HasColumnType("int").IsOptional();
            Property(x => x.EmployeeId).HasColumnName(@"EmployeeId").HasColumnType("int").IsRequired();

            // Foreign keys
            HasOptional(a => a.AttendanceStatu).WithMany(b => b.EmployeeAttendances).HasForeignKey(c => c.AttendanceStatusId).WillCascadeOnDelete(false); // FK_303
            HasRequired(a => a.Employee).WithMany(b => b.EmployeeAttendances).HasForeignKey(c => c.EmployeeId).WillCascadeOnDelete(false); // FK_306
        }
    }

    #endregion
    }
}
