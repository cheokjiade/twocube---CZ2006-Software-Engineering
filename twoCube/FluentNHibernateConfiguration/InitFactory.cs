using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FluentNHibernate.Automapping;
using NHibernate;
using FluentNHibernate.Cfg;
using NHibernate.Cfg;
using System.IO;
using FluentNHibernate.Cfg.Db;
using NHibernate.Tool.hbm2ddl;

namespace twoCube.FluentNHibernateConfiguration
{
    public static class InitFactory
    {
        public static ISessionFactory sessionFactory;

        public static void create()
        {
            sessionFactory = CreateSessionFactory();
        }

        static AutoPersistenceModel CreateAutomappings()
        {
            // This is the actual automapping - use AutoMap to start automapping,
            // then pick one of the static methods to specify what to map (in this case
            // all the classes in the assembly that contains Employee), and then either
            // use the Setup and Where methods to restrict that behaviour, or (preferably)
            // supply a configuration instance of your definition to control the automapper.
            return AutoMap.AssemblyOf<Entities.Member>(new NTUsurveyAutoMappingConfiguration()).Conventions.Add<CascadeConvention>();

        }

        private static ISessionFactory CreateSessionFactory()
        {
            var connectionStr = "Server=127.0.0.1;Port=5432;Database=ntusurvey;User Id=ntusurvey;Password=password;";
            return Fluently
                 .Configure()
                 .Database(PostgreSQLConfiguration.Standard.ConnectionString(connectionStr))
                 .Mappings(m => m.AutoMappings.Add(CreateAutomappings))
                 .ExposeConfiguration(BuildSchema)
                 .BuildSessionFactory();

        }

        private static void BuildSchema(Configuration config)
        {
            // This NHibernate tool takes a configuration (with mapping info in)
            // and exports a database schema from it.
            var dbSchemaExport = new SchemaExport(config);
            //dbSchemaExport.Drop(false, true);
            dbSchemaExport.Create(false, true);
        }
    }
}