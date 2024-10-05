using DataGridViewCheckBoxApp1.Models;
using System.Data;

namespace DataGridViewCheckBoxApp1.Classes;
public static class BindingSourceExtensions
{
    /// <summary>
    /// Retrieves the current <see cref="DataRow"/> from the specified <paramref name="sender"/>.
    /// </summary>
    /// <param name="sender">The <see cref="BindingSource"/> instance.</param>
    /// <returns>The current <see cref="DataRow"/> from the <paramref name="sender"/>.</returns>
    public static DataRow CurrentRow(this BindingSource sender)
    {
        return ((DataRowView)sender.Current).Row;
    }

    /// <summary>
    /// Retrieves the <see cref="DataTable"/> that the specified <paramref name="sender"/> is bound to.
    /// </summary>
    /// <param name="sender">The <see cref="BindingSource"/> instance.</param>
    /// <returns>The <see cref="DataTable"/> that the <paramref name="sender"/> is bound to.</returns>
    public static DataTable DataTable(this BindingSource sender)
        => (DataTable)sender.DataSource;

    /// <summary>
    /// Toggles the <see cref="ProductContainer.Process"/> property of the specified <paramref name="sender"/>.
    /// </summary>
    /// <param name="sender">The <see cref="ProductContainer"/> instance whose <see cref="ProductContainer.Process"/> property is to be toggled.</param>
    public static void ToggleCheck(this ProductContainer? sender)
    {
        if (sender != null) sender.Process = !sender.Process;
    }

    /// <summary>
    /// Determines whether the <see cref="ProductContainer.Process"/> property of the specified <paramref name="sender"/> is checked.
    /// </summary>
    /// <param name="sender">The <see cref="ProductContainer"/> instance whose <see cref="ProductContainer.Process"/> property is to be checked.</param>
    /// <returns><c>true</c> if the <see cref="ProductContainer.Process"/> property is checked; otherwise, <c>false</c>.</returns>
    public static bool IsChecked(this ProductContainer? sender)
    {
        return sender!.Process;
    }
}
