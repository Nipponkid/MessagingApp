using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Collections.Generic;

using MessagingApp.Data;
using MessagingApp.Data.Messages;
using MessagingApp.Domain;

namespace MessagingApp
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var user = new User(0, "user0@example.com");
            var contacts = new List<Contact>() { new Contact(0, user, "John", "Smith") };
            services.AddTransient(x => contacts);

            services.AddTransient<IUsersService, UsersService>();
            services.AddDbContext<MessagingAppDbContext>(options => options.UseInMemoryDatabase("Messaging_App_DB"));

            var messages = new List<Message>() {
                new Message(1, new User(1, "user1@example.com"), new User(2, "user2@example.com"), "How are you?"),
                new Message(2, new User(2, "user2@example.com"), new User(1, "user1@example.com"), "Good. You?")
            };
            services.AddTransient(x => messages);
            services.AddTransient<MessagesService, MessagesService>();

            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseDefaultFiles();
            app.UseStaticFiles();

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
