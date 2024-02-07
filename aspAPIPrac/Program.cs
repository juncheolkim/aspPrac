
using MySql.Data.MySqlClient;
using SqlKata.Compilers;
using SqlKata.Execution;

namespace aspAPIPrac
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddTransient<QueryFactory>((e) =>
            {
                var connection = new MySqlConnection(
                    "Host=172.17.0.2;Port=3306;User=root;Password=0000;Database=Dummy;SslMode=None"
                    );

                var compiler = new MySqlCompiler();

                return new QueryFactory(connection, compiler);
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            //app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
