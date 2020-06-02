using GraphQlAirlines.Api.Types;
using HotChocolate;
using HotChocolate.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace GraphQlAirlines.Api
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddGraphQL(
                SchemaBuilder.New()
                    .AddDocumentFromFile("./schema.graphql")
                    .BindComplexType<QueryType>(r => r.To("Query"))
                    .BindResolver<QueryResolvers>(r => r.To<QueryType>())
                    .BindComplexType<RouteType>(r => r.To("Route"))
                    .BindResolver<RouteResolvers>(r => r.To<RouteType>())
                    .BindComplexType<AirlineType>(r => r.To("Airline"))
                    .BindResolver<AirlineResolvers>(r => r.To<AirlineType>())
                    .BindComplexType<AirportType>(r => r.To("Airport"))
                    .BindResolver<AirportResolvers>(r => r.To<AirportType>())
                    .BindComplexType<CountryType>(r => r.To("Country"))
                    .Create()
            );
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseGraphiQL();
            app.UseGraphQL();
        }
    }
}