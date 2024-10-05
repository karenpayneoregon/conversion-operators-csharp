using System.ComponentModel;
using DataGridViewCheckBoxApp1.Classes;
using DataGridViewCheckBoxApp1.Models;
using System.Text.Json;

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

namespace DataGridViewCheckBoxApp1;
public partial class Form2 : Form
{
    private BindingSource _bindingSource = new();
    private SortableBindingList<ProductContainer> _bindingList;
    public Form2()
    {
        InitializeComponent();
    }

    private void Form2_Load(object sender, EventArgs e)
    {
        _bindingList = new SortableBindingList<ProductContainer>(BogusOperations.Products1());
        _bindingSource.DataSource = _bindingList;
        dataGridView1.DataSource = _bindingSource;

        dataGridView1.Columns["ProductId"]!.Visible = false;

        dataGridView1.FixHeaders();
        dataGridView1.ExpandColumns();

        dataGridView1.Columns["UnitPrice"]!.DefaultCellStyle.Format = "C2";
        dataGridView1.Columns["UnitsInStock"]!.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

        _bindingList.ListChanged += _bindingList_ListChanged;
    }

    /// <summary>
    /// Handles the <see cref="SortableBindingList{T}.ListChanged"/> event of the <see cref="SortableBindingList{T}"/>.
    /// This method processes changes to the list, such as item changes, additions, and deletions.
    /// </summary>
    private void _bindingList_ListChanged(object? sender, System.ComponentModel.ListChangedEventArgs e)
    {
        if (e.ListChangedType == ListChangedType.ItemChanged)
        {
            if (e.PropertyDescriptor?.DisplayName == "Process")
            {
                // check/uncheck - handle it
            }
            else
            {
                // another property value changed
            }

        }
        else if (e.ListChangedType == ListChangedType.ItemAdded)
        {
            // handle add new row e.g. FluidValidation 
        }else if (e.ListChangedType == ListChangedType.ItemDeleted)
        {
            // If handling this make sure to also handle the DataGridView event
        }

    }

    /// <summary>
    /// Toggles the check state of the currently selected <see cref="ProductContainer"/> in the binding list.
    /// </summary>
    private void ToggleCurrentButton_Click(object sender, EventArgs e)
    {
        ProductContainer? current = _bindingList[_bindingSource.Position];
        current?.ToggleCheck();

    }

    /// <summary>
    /// Get all selected, lose the process column and write to a json file
    /// in the application folder
    /// </summary>
    private void GetAllCheckedButton_Click(object sender, EventArgs e)
    {
        List<ProductContainer> products = _bindingList.Where(pc => pc.Process).ToList();
        
        // explicit
        //List<ProductItem> results = products.Select(pc => (ProductItem)pc).ToList();

        // implicit 
        List<ProductItem> results = products
            .Select<Product, ProductItem>(container => container).ToList();

        
        if (results.Any())
        {
            // process checked
            File.WriteAllText("Products.json", JsonSerializer.Serialize(results, new JsonSerializerOptions
            {
                WriteIndented = true,
                Converters = { new FixedDecimalJsonConverter() }
            }));
        }
        else
        {
            // nothing checked
        }
    }

    /// <summary>
    /// Check/uncheck all
    /// </summary>
    private void CheckAllButton_Click(object sender, EventArgs e)
    {
        foreach (var container in _bindingList)
        {
            container.Process = DirectionCheckBox.Checked;
        }
    }
}
