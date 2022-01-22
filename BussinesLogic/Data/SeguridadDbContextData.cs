using System;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Microsoft.AspNetCore.Identity;

namespace BussinesLogic.Data
{
	public class SeguridadDbContextData
	{
		public static async Task SeedUserAsync(UserManager<Usuario> userManager)
        {
			if(!userManager.Users.Any())
            {
                var usuario = new Usuario
                {
                    Nombre = "Antonio",
                    Apellido = "Nicasio",
                    UserName = "anicasio",
                    Email = "antonio.nicasio.herrera@gmail.com",
                    Direccion = new Direccion
                    {
                        Calle = "Diego Rivera",
                        Ciudad = "Tijuana",
                        CodigoPostal = "2200",
                    }
                };

                await userManager.CreateAsync(usuario, "Mandalor1anrule$");
            }
        }
	}
}

