using System.Collections.ObjectModel;
using System.Windows;
using StoreDemo.BLL;
using StoreDemo.WPF.Models;
using StoreDemo.WPF.Windows.NewSaleWindow;

namespace StoreDemo.WPF.WindowModels;

public class MainWindowModel : BaseNotify
{
    private readonly Context _context;
    
    public ObservableCollection<SaleInfo> Sales { get; set; }

    public LambdaCommand CommandNew { get; set; }
    public LambdaCommand CommandReload { get; set; }

    public MainWindowModel()
    {
        _context = new Context();

        ListOfSales sourceSales = _context.Sales;
        IEnumerable<SaleInfo> sales = sourceSales
            .GetAllAsync()
            .ToBlockingEnumerable()
            .Select(Mappers.UIMapper.MapperBllSaleToUISaleInfo);
        Sales = new ObservableCollection<SaleInfo>(sales);

        CommandNew = new LambdaCommand(
            execute: _ =>
            {
                var window = new NewSaleWindow
                {
                    Owner = (Window)Application.Current.Resources["Owner"]!
                };
                window.ShowDialog();
            });
        CommandReload = new LambdaCommand(
            execute: _ =>
        {
            ListOfSales sourceSales = _context.Sales;
            IEnumerable<SaleInfo> sales = sourceSales
                .GetAllAsync()
                .ToBlockingEnumerable()
                .Select(Mappers.UIMapper.MapperBllSaleToUISaleInfo);
            Sales.Clear();
            foreach (var sale in sales)
            {
                Sales.Add(sale);
            }
        });
    }
}