using System.Windows;

namespace WpfApp9;

public partial class AddWindow : Window
{
    public AddWindow()
    {
        InitializeComponent();
    }

    private async void add_click_btn_Click(object sender, RoutedEventArgs e)
    {
        Comment comment = new Comment();
        comment.id = Convert.ToInt32(id_txtbox.Text);
        comment.postId = Convert.ToInt32(postid_txtbox.Text);
        comment.name = name_txtbox.Text;
        comment.email = email_txtbox.Text;
        comment.body = body_txtbox.Text;

        await Task.Delay(5000);
        StaticOBC.Comment.Add(comment);
        
        this.Close();
    }
}
