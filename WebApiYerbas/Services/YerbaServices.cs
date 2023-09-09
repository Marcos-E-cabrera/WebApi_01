using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using Microsoft.IdentityModel.Tokens;
using System.Reflection.PortableExecutable;
using WebApiYerbas.Models;

namespace WebApiYerbas.Services
{
    public class YerbaServices : IYerbaServices
    {
        private readonly YerbasApiRestContext _context;

        public YerbaServices(YerbasApiRestContext context) 
        {
            _context = context;
        }

        public async Task<IEnumerable<Yerba>> GetAsync() => await _context.Yerbas.ToListAsync();

        public async Task<Yerba?> GetByIdAsync(int id) => await  _context.Yerbas.FirstOrDefaultAsync(x  => x.Id == id);

        public async Task<bool> UpdateAsync(Yerba oYerba)
        {
            bool result = false;

            var dataYerba = await _context.Yerbas.FirstOrDefaultAsync(x => x.Id == oYerba.Id);

            if (dataYerba != null)
            {
                dataYerba.Nombre = oYerba.Nombre;
                dataYerba.Cantidad = oYerba.Cantidad;

                _context.SaveChanges();

                result = true;
            }   
            return result;
        }

        public async Task<int> AddAsync(Yerba oYerba)
        {
            int result = ValidarYerba(oYerba);
             
            if (result == 0)
            {
                var yerba = new Yerba()
                {
                    Nombre = oYerba.Nombre,
                    Cantidad = oYerba.Cantidad
                };

                _context.Add(yerba);
                _context.SaveChanges();
            }

            return result;
           }


        public async Task<bool> DeleteAsync(int id)
        {
            bool result = false;

            var oAux = await _context.Yerbas.FirstOrDefaultAsync(x => x.Id == id);

            if (oAux != null)
            {
                _context.Remove(oAux);
                _context.SaveChanges();
                result = true;
            }

            return result;
        }


        /// <summary>
        /// Valida si la yerba es valida para ser agregada
        /// </summary>
        /// <param name="oYerba"> yerba a agregar </param>
        /// <returns> 
        /// 0: OK, ERROR ( 1: Es NULL o Id ya usado, 2: Nombre vacio, 3: Cantidad menor a 0 ).
        /// </returns>
        private int ValidarYerba(Yerba oYerba)
        {
            int result = 0;

            var data = _context.Yerbas.FirstOrDefault(x => x.Id ==  oYerba.Id);
            if (oYerba == null || data != null)
            {
                result = 1;
            }
            else if (oYerba.Nombre.IsNullOrEmpty())
            {
                result = 2;
            }
            else if (oYerba.Cantidad <= 0)
            {
                result = 3;
            }
            return result;
        }

        public string GetErrorMessage(int errorCode)
        {
            switch (errorCode)
            {
                case 1:
                    return "Parametros no ingresados O ID ya usado";

                case 2:
                    return "Nombre no ingresado";

                case 3:
                    return "Cantidad inválida";

                default:
                    return "Error desconocido";
            }
        }

    }
}
