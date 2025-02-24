using NewsApp.Models;
using NewsApp.Services;

namespace NewsApp.Pages;

public partial class NewsPage : ContentPage
{
    public List<Article> ArticleList { get; set; }
	public NewsPage()
	{
		InitializeComponent();
        ArticleList = new List<Article>();
	}

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        ApiService apiService = new ApiService();
        var newsResult = await apiService.GetNews();
        foreach(var item in newsResult.Articles)
        {
            ArticleList.Add(item);
        }
        CvNews.ItemsSource = ArticleList;
    }
}