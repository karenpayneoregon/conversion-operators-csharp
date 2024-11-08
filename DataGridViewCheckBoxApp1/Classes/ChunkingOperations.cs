using System.Data;
using System.Drawing.Printing;

namespace DataGridViewCheckBoxApp1.Classes;

internal class ChunkingOperations
{
    private static List<List<DataRow>> Split(DataTable table, int pageSize)
        => table.AsEnumerable()
            .Select((row, index) => new { Row = row, Index = index, })
            .GroupBy(x => x.Index / pageSize)
            .Select(x => x.Select(v => v.Row).ToList())
            .ToList();

    public static List<DataTable> Pagination(DataTable table, int pageSize, string tableName)
    {
        List<List<DataRow>> rows = Split(table, pageSize);
        List<DataTable> tables = [];
        int tableIndex = 1;
        foreach (List<DataRow> row in rows)
        {
            using var newTable = table.Clone();
            newTable.TableName = $"{tableName}_{tableIndex++}";
            foreach (DataRow dataRow in row)
            {
                newTable.ImportRow(dataRow);
            }
            tables.Add(newTable);
        }
        return tables;
    }

    public static void Example()
    {
        DataTable table = BogusOperations.ProductsDataTable();
        var rowCount = table.Rows.Count;
        List<DataTable> result = Pagination(table, 100, "Products");
    }

    public static void Sizing()
    {

    }

}


