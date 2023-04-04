using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Windows.Forms;


namespace ControlsUI
{
    /// <summary>
    /// IFinder es la interfase de una entidad que implementa métodos de búsqueda
    /// NO es una interfase de la entidad devuelta.
    /// Notar que las clases que implementan IFinder implementan los formularios de búsqueda
    /// </summary>
    public interface IDriver<T> 
    {
        /// <summary>
        /// Devuelve entidades que implementan IEntityToSearch por su llave primaria
        /// </summary>
        /// <param name="codkey"></param>
        /// <returns></returns>
        T getByKey(int? codkey);

        /// <summary>
        /// Devuelve entidades que implementan IEntityToSearch desde la base de datos usando un patron de busqueda(texto plano)
        /// </summary>
        /// <param name="nombre"></param>
        /// <returns></returns>
        List<T> GetByPattern(string pattern);

        

        T GetEntityTNinguno
        {
            get;
        }

        List<T> GetAll();


        
    }
}
