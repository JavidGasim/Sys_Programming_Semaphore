using System.Windows;

namespace WpfApp9;

public partial class EditWindow : Window
{
    public EditWindow()
    {
        InitializeComponent();
    }

    private async void edit_click_btn_Click(object sender, RoutedEventArgs e)
    {
        var a = StaticOBC.Comment.FirstOrDefault(o => o.id == StaticOBC.Id);

        a.name = name_txtbox.Text;
        a.email = email_txtbox.Text;
        a.body = body_txtbox.Text;

        await Task.Delay(5000);

        StaticOBC.Comment.Remove(StaticOBC.Comment.FirstOrDefault(o => o.id == StaticOBC.Id));    
        StaticOBC.Comment.Add(a);    

        this.Close();
    }
}
