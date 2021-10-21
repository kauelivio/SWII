using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using TP01.Command;
using TP01.Entidades;

namespace TP01
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
            services.AddRazorPages();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();

                Author autor1 = new Author("John Green", "green@gmail.com", 'M');
                Author autor2 = new Author("Antoine de Saint-Exupéry", "antoine@gmail.com", 'M');
                Author autor3 = new Author("J. K. Rowling", "jk@gmail.com", 'F');
                Book livro1 = new Book("A culpa e das estrelas", autor1, 29.99, 3);
                Book livro2 = new Book("O Pequeno Principe", autor2, 59.99, 3);
                Book livro3 = new Book("Harry Potter", autor3, 44.99, 3);
                Book[] livros = new Book[3];
                Author[] authors = new Author[3];

                livros[0] = livro1;
                livros[1] = livro2;
                livros[2] = livro3;

                authors[0] = autor1;
                authors[1] = autor2;
                authors[2] = autor3;

                endpoints.MapGet("/NomeLivro", async context =>
                {
                    for (int i = 0; i < livros.Length; i++)
                    {
                        await context.Response.WriteAsync(livros[i].Name.ToString() + ", ");
                    }
                });
                endpoints.MapGet("/TextoAutor", async context =>
                {
                    for (int i = 0; i < authors.Length; i++)
                    {
                        await context.Response.WriteAsync(authors[i].ToString(authors[i]));
                    }
                    
                });
                endpoints.MapGet("/TextoLivro", async context =>
                {
                    for (int i = 0; i < livros.Length; i++)
                    {
                        await context.Response.WriteAsync(livros[i].ToString(livros[i]));
                    }
                });

                endpoints.MapGet("/ParaLer", LivrosParaLer);
            });
        }

        private Task ExibeFormulario(HttpContext context)
        {
            var html = CarregaArquivoHTML("formulario");
            return context.Response.WriteAsync(html);
        }

        private string CarregaArquivoHTML(string nomeArquivo)
        {
            var nomeCompletoArquivo = $"HTML/{nomeArquivo}.html";

            using (var arquivo = File.OpenText(nomeCompletoArquivo))
            {
                return arquivo.ReadToEnd();
            }
        }

        private Task LivrosParaLer(HttpContext context)
        {
            Author autor1 = new Author("John Green", "green@gmail.com", 'M');
            Author autor2 = new Author("Antoine de Saint-Exupéry", "antoine@gmail.com", 'M');
            Author autor3 = new Author("J. K. Rowling", "jk@gmail.com", 'F');
            Book livro1 = new Book("A culpa e das estrelas", autor1, 29.99, 3);
            Book livro2 = new Book("O Pequeno Principe", autor2, 59.99, 3);
            Book livro3 = new Book("Harry Potter", autor3, 44.99, 3);
            Book[] livros = new Book[3];

            livros[0] = livro1;
            livros[1] = livro2;
            livros[2] = livro3;

            var conteudo = CarregaArquivoHTML("para-ler");

            /*foreach (var test in livros)
            {
                conteudo = conteudo.Replace("#NOVO-ITEM#", $"<li>{test.Name} - {test.Authors.Name}</li>#NOVO-ITEM#");
            }*/

            for (int i = 0; i < livros.Length; i++)
            {
                conteudo = conteudo.Replace("#NOVO-ITEM#", $"<li>{livros[i].Name} - {livros[i].Authors.Name}</li>#NOVO-ITEM#");
            }
            
            return context.Response.WriteAsync(conteudo);
        }
    }
}
