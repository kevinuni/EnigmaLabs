using System.Collections;

namespace System.Runtime.CompilerServices
{
    ///// <summary>
    ///// Agregar este codigo para evitar el error System.Runtime.CompilerServices.ExtensionAttribute..ctor
    ///// al usar extensiones (cryptic error)
    ///// </summary>
    //public class ExtensionAttribute : Attribute { }
}

namespace Util.DataTable
{
    public static class DataTableExtension
    {
        public static System.Data.DataTable ToDataTable(this IEnumerable list)
        {
            return CollectionManager.ToDataTable(list);
        }
    }
}