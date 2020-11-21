using CourtDatabase2.Data;
using CourtDatabase2.Services;
using CourtDatabase2.Services.Contracts;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace CourtDatabase2
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
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));
            services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<ApplicationDbContext>();
            services.AddControllersWithViews(options =>
            {
                options.Filters.Add(new AutoValidateAntiforgeryTokenAttribute());
            });
            services.AddRazorPages();
            services.AddTransient<IHeatEstateService, HeatEstateService>();
            services.AddTransient<ICourtTownService, CourtTownService>();
            services.AddTransient<ICourtService, CourtService>();
            services.AddTransient<ILegalActionService, LegalActionService>();
            services.AddTransient<ICourtCasesService, CourtCaseService>();
            services.AddTransient<ILawCaseService, LawCaseService>();
            services.AddTransient<ILawCaseService, LawCaseService>();
            services.AddTransient<IPaymentsService, PaymentsService>();
            services.AddTransient<ISeederService, SeederService>();
            services.AddTransient<IExpenseService, ExpenseService>();
            services.AddTransient<IExecutorService, ExecutorService>();
            services.AddTransient<IExecutorsCasesService, ExecutorsCasesService>();
            services.AddTransient<IDebitorsService, DebitorsService>();
            services.AddTransient<ICaseActionsService, CaseActionsService>();
            services.AddTransient<IInvoicesService, InvoicesService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });
        }
    }
}
