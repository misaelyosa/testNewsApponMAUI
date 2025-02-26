using NewsApp.Models;
using NewsApp.Services;

namespace NewsApp.Pages;

public partial class NewsPage : ContentPage
{
    public List<Article> ArticleList { get; set; }
    public List<Category> CategoryList = new List<Category>() { 
        new Category() {Name = "Breaking-news"},
        new Category() {Name = "World"},
        new Category() {Name = "Nation"},
        new Category() {Name = "Business"},
        new Category() {Name = "Entertainment"},
        new Category() {Name = "Sports"},
        new Category() {Name = "Science"},
        new Category() {Name = "Health"},
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
        await PassCategory("breaking-news");
    }

    public async Task PassCategory(string categoryName)
    {
        CvNews.ItemsSource = null;
        ArticleList.Clear();

        ApiService apiService = new ApiService();
        var newsResult = await apiService.GetNews(categoryName);
        foreach (var item in newsResult.Articles)
        {
            ArticleList.Add(item);
        }
        CvNews.ItemsSource = ArticleList;
    }

    private async void CvCategories_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        var itemSelected = e.CurrentSelection.FirstOrDefault() as Category;
        await PassCategory(itemSelected.Name);
    }
}