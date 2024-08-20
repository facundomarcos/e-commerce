using Core.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Data
{
    public class SeguridadDbContextData
    {
        public static async Task SeedUserAsync(
            UserManager<Usuario> userManager,
            RoleManager<IdentityRole> roleManager
            )
        {
            if (!userManager.Users.Any())
            {
                var usuario = new Usuario
                {
                    Nombre = "Facundo",
                    Apellido = "Marcos",
                    UserName = "facundomarcos",
                    Email = "facundomarcos@live.com.ar",
                    Direccion = new Direccion
                    {
                        Calle = "Los Patos 2522",
                        Ciudad = "La Plata",
                        CodigoPostal = "1900"

                    }
                };
                await userManager.CreateAsync(usuario, "Q1w2e3r4$");
            }

            if(!roleManager.Roles.Any())
            {
                var role = new IdentityRole
                {
                    Name = "ADMIN"
                };
                await roleManager.CreateAsync(role);
            }
        }
    }
}
