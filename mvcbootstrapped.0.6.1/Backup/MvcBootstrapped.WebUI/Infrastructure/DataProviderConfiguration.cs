//using System;
//using System.Collections.Generic;
//using System.Configuration;
//using System.Data.Entity;

//using ApplicationBoilerplate.DataProvider;
//using ApplicationBoilerplate.DependencyInjection;

//using MVCBootstrap.EntityFramework;

//namespace MVCBootstrap.WebUI.Infrastructure {

//    public class DataProviderConfiguration : IDependencyBuilder {

//        public void Configure(IDependencyContainer container) {
//            Database.SetInitializer<MembershipDbContext>(new CreateDatabaseIfNotExists<MembershipDbContext>());

//            container.RegisterPerRequest<IContext, Context>();
//            container.RegisterPerRequest<IUnitOfWork, UnitOfWork>();
//            container.RegisterPerRequest<DbContext, MembershipDbContext>(new Dictionary<String, Object> { { "connectString", ConfigurationManager.ConnectionStrings["DataProvider.MainDB"].ConnectionString } });

//            container.RegisterGeneric(typeof(IRepository<>), typeof(Repository<>));
//        }

//        public void ValidateRequirements(IList<ApplicationRequirement> feedback) {
//            if (ConfigurationManager.ConnectionStrings["DataProvider.MainDB"] == null) {
//                feedback.Add(new ApplicationRequirement {
//                    Feedback = @"No connection found for the application, please insert this into the application's web.config file:
//
//<configuration>
//	<connectionStrings>
//		<add name=""DataProvider.MainDB""
//			connectionString=""Data Source=SQLSERVERNAMEorSQLSERVERNAME\INSTANCE;Initial Catalog=DATABASE;User ID=USERNAME;password=PASSWORD""
//		/>
//	</connectionStrings>
//</configuration>
//
//Remember to replace the values in the connection string with values that matches your set-up.
//",
//                    Level = RequirementLevel.Fatal
//                });
//            }
//            else {
//                feedback.Add(new ApplicationRequirement { Feedback = "Connection string for the application located.", Level = RequirementLevel.Info });
//            }
//        }
//    }
//}