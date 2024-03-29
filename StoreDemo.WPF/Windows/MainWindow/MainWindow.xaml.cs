using System.Windows;

namespace StoreDemo.WPF.Windows.MainWindow;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        
        Application.Current.Resources.Add("Owner", this);
    }
}