using System.Collections.ObjectModel;
using StoreDemo.BLL;
using StoreDemo.WPF.Models;

namespace StoreDemo.WPF.WindowModels;

public class NewSaleWindowModel : BaseNotify
{
    private readonly Context _context;
    
    public ObservableCollection<User> Users { get; set; }
    public ObservableCollection<Good> Goods { get; set; }

    private User? _selectedUser;
    public User? SelectedUser
    {
        get => _selectedUser; 
        set => SetField(ref _selectedUser, value);
    }
    
    private Good? _selectedGood;
    public Good? SelectedGood
    {
        get => _selectedGood; 
        set => SetField(ref _selectedGood, value);
    }

    public LambdaCommand CommandSave { get; set; }
    public LambdaCommand CommandClear { get; set; }

    public NewSaleWindowModel()
    {
        _context = new Context();

        ListOfUsers sourceUsers = _context.Users;
        IEnumerable<User> users = sourceUsers
            .GetAllAsync()
            .ToBlockingEnumerable()
            .Select(Mappers.UIMapper.MapperBLLUserToUIUser);
        Users = new ObservableCollection<User>(users);

        var goods = _context
            .Goods
            .GetAllAsync()
            .ToBlockingEnumerable()
            .Select(Mappers.UIMapper.MapperBLLGoodToUIGood);
        Goods = new ObservableCollection<Good>(goods);

        CommandSave = new LambdaCommand(
            execute: async _ =>
            {
                var sale = new Sale()
                {
                    Date = DateTime.Now,
                    Good = SelectedGood,
                    User = SelectedUser
                };
                await _context.Sales.InsertAsync(Mappers.UIMapper.MapperUISaleToBLLSale(sale));
            },
            canExecute: _ => SelectedUser is not null && SelectedGood is not null
        );
        CommandClear = new LambdaCommand(
            execute: _ =>
            {
                SelectedUser = null;
                SelectedGood = null;
            },
            canExecute: _ => SelectedUser is not null || SelectedGood is not null
        );
    }
}