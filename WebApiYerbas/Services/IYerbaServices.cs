using WebApiYerbas.Models;

namespace WebApiYerbas.Services
{
    public interface IYerbaServices 
    {

        /// <summary>
        /// Obtiene de manera asincrónica una colección de todas las yerbas disponibles.
        /// </summary>
        /// <returns>
        /// La tarea contiene una colección de yerbas si la operación se realiza con éxito.
        /// </returns>
        Task<IEnumerable<Yerba>> GetAsync();

        /// <summary>
        /// Obtiene de manera asincrónica una yerba por su ID.
        /// </summary>
        /// <param name="id">El ID de la yerba que se desea obtener.</param>
        /// <returns>
        /// La tarea contiene la yerba correspondiente si se encuentra, o null si no se encuentra ninguna yerba con el ID especificado.
        /// </returns>
        Task<Yerba?> GetByIdAsync(int id);

        /// <summary>
        /// Agrega de manera asincrónica una nueva yerba.
        /// </summary>
        /// <param name="oYerba">La yerba que se desea agregar.</param>
        /// <returns>
        /// La tarea devuelve true si la operación se realiza con éxito, de lo contrario, devuelve false.
        /// </returns>
        Task<int> AddAsync(Yerba oYerba);

        /// <summary>
        /// Actualiza de manera asincrónica una yerba existente por su ID.
        /// </summary>
        /// <param name="id">El ID de la yerba que se desea actualizar.</param>
        /// <param name="oYerba">La nueva información de la yerba.</param>
        /// <returns>
        /// La tarea devuelve true si la actualización se realiza con éxito, de lo contrario, devuelve false.
        /// </returns>
        Task<bool> UpdateAsync(Yerba oYerba);

        /// <summary>
        /// Elimina de manera asincrónica una yerba por su ID.
        /// </summary>
        /// <param name="id">El ID de la yerba que se desea eliminar.</param>
        /// <returns>
        /// La tarea devuelve true si la eliminación se realiza con éxito, de lo contrario, devuelve false.
        /// </returns>
        Task<bool> DeleteAsync(int id);

        public string GetErrorMessage(int errorCode);

    }
}
