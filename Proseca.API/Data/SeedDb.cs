
using Microsoft.EntityFrameworkCore;
using Proseca.API.Data;
using Proseca.API.Helpers;
using Proseca.Shared.Entidades;
using Proseca.Shared.Enums;

namespace Proseca.Api.Data
{
    public class SeedDb
    {
        private readonly DataContext _context;
        private readonly IUserHelper _userHelper;

        public SeedDb(DataContext context, IUserHelper userHelper)
        {
            _context = context;
            _userHelper = userHelper;
        }

        public async Task SeedAsync()

        {
            await _context.Database.EnsureCreatedAsync();
            await CheckFincaAsync(); //encargado de hacer el chequeo cada vez q se ejecute la app
            await CheckRolesAsync(); //Validar roles de usuario
            await CheckUserAsync("123456","Luis","Zapata","zapata@gmail.com","3113476964",UserType.Admin);
            
           // await CheckUserAsync("123456", "Samuel", "Angulo", "samuel@gmail.com", "3117509186", UserType.Admin);


        }
        private async Task CheckRolesAsync()
        {
            await _userHelper.CheckRoleAsync(UserType.Admin.ToString());
            await _userHelper.CheckRoleAsync(UserType.User.ToString());
        }

        private async Task<User> CheckUserAsync(string document, string FullName, string SurName, string email, string phone, UserType userType)
        {
            var user = await _userHelper.GetUserAsync(email);
            if (user == null)
            {

                user = new User
                {

                    Document = document,
                    FullName = FullName,
                    SurName = SurName,
                    Email = email,
                    UserName = email,

                    PhoneNumber = phone,
                    UserType = userType,
                };

                await _userHelper.AddUserAsync(user, "123456");
                await _userHelper.AddUserToRoleAsync(user, userType.ToString());

                var token = await _userHelper.GenerateEmailConfirmationTokenAsync(user);
                await _userHelper.ConfirmEmailAsync(user, token);


            }

            return user;
        }




        public async Task CheckFincaAsync()
        {
            if (!_context.Fincas.Any())
            {

                _context.Fincas.Add(new Finca
                {
                    Nombre = "Vaquita",
                    Cantidad=20
                });
            }

            await _context.SaveChangesAsync();


        }
    }
}