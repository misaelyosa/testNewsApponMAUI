using NewsApp.Models;
using NewsApp.Services;

namespace NewsApp.Pages;

public partial class NewsPage : ContentPage
{
    public List<Article> ArticleList { get; set; }
    public List<Category> CategoryList = new List<Category>() { 
        new Category() {Name = "breaking-news"},
        new Category() {Name = "world"},
        new Category() {Name = "nation"},
        new Category() {Name = "business"},
        new Category() {Name = "entertainment"},
        new Category() {Name = "sports"},
        new Category() {Name = "science"},
        new Category() {Name = "health"},
    };
	public NewsPage()
	{
		InitializeComponent();
        ArticleList = new List<Article>();
        CvCategories.ItemsSource = CategoryList;
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