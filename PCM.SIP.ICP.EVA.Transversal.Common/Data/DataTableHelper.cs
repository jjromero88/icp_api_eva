using System.Data;

namespace PCM.SIP.ICP.EVA.Transversal.Common.Data
{
    public static class DataTableHelper
    {
        public static DataTable ConvertToDataTable<T>(List<T> items)
        {
            var table = new DataTable();

            try
            {
                if (items == null || !items.Any())
                {
                    return table;
                }

                var props = typeof(T).GetProperties();

                // Añadir columnas al DataTable basadas en las propiedades del objeto
                foreach (var prop in props)
                {
                    table.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
                }

                // Añadir filas al DataTable
                foreach (var item in items)
                {
                    var values = new object[props.Length];
                    for (var i = 0; i < props.Length; i++)
                    {
                        values[i] = props[i].GetValue(item);
                    }
                    table.Rows.Add(values);
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error converting list to DataTable: {ex.Message}", ex);
            }

            return table;
        }
    }
}
