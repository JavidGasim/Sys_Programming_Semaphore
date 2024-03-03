using System.CodeDom;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text.Json;
using System.Windows;

namespace WpfApp9;


public partial class MainWindow : Window, INotifyPropertyChanged
{
    private ObservableCollection<Comment> comments;
    public ObservableCollection<Comment> Comments
    {
        get { return comments; }
        set { 
            comments = value;
            OnPropertyChanged();
        }
    }

    public event PropertyChangedEventHandler? PropertyChanged;
    public void OnPropertyChanged([CallerMemberName] string? propertyName = null)
                => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    public MainWindow()
    {
        InitializeComponent();

        DataContext = this;
    }

    private void TextBox_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
    {

    }

    private async void getall_btn_Click(object sender, RoutedEventArgs e)
    {
        Comments = new ObservableCollection<Comment>();
        HttpClient client = new HttpClient();
        var a = await client.GetStringAsync(url_txtbox.Text);

        await Task.Delay(5000);

        StaticOBC.Comment = JsonSerializer.Deserialize<ObservableCollection<Comment>>(a);
        Comments = StaticOBC.Comment;
    }

    private async void add_btn_Click(object sender, RoutedEventArgs e)
    {
        await Task.Delay(5000);
        AddWindow addWindow = new AddWindow();
        addWindow.ShowDialog();
    }

    private async void edit_btn_Click(object sender, RoutedEventArgs e)
    {
        Comment com = (Comment)items.SelectedItem;

        StaticOBC.Id = com.id; 

        await Task.Delay(5000);
        EditWindow editWindow = new EditWindow();
        editWindow.ShowDialog();
    }

    private async void remove_btn_Click(object sender, RoutedEventArgs e)
    {
        int remove_data = items.SelectedIndex;

        if (remove_data != -1)
        {
            await Task.Delay(5000);
            Comments.RemoveAt(remove_data);

        }
    }
}