using System;

namespace Enigma.ControlsUI
{
    /// <summary>
    /// Interface para las entidades que serán devueltas por el control de búsqueda
    /// Idealmente las entidades serán heredadas de BE_Base
    /// </summary>
    public interface IEntityToSearch : IComparable, ICombo
    {
        /// <summary>
        /// Se utiliza para comparar entidades que implementan IEntityDescriptor
        /// Compara la "Denominacion" de la entidad actual contra el patron (busqueda de texto simple)
        /// </summary>
        /// <param name="PatronDeBusqueda">Cadena de texto a comparar contra la denominacion</param>
        /// <returns>Devuelve true si la Denominacion de entidad actual contiene la cadena "patronABuscar"</returns>
        bool CompareDisplayMemberTo(string PatronDeBusqueda);
    }
}