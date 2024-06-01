using BlogWeb.Mvc.Entities;
using BlogWeb.Mvc.Features.Queries.Article.GetAllArticles;
using BlogWeb.Mvc.Features.Queries.Article.GetArticlesByCategory;
using BlogWeb.Mvc.Models;
using BlogWeb.Mvc.Models.Enums;
using BlogWeb.Mvc.Models.ViewModels.Article;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace BlogWeb.Mvc.Controllers
{
    public class HomeController(IMediator _mediatr) : Controller
    {
        /// <summary>
        /// Tüm makalelerin anasayfaya geldiði uç nokta
        /// </summary>
        /// <param name="category"></param>
        /// <returns></returns>
        public async Task<IActionResult> Index(string? category = null)
        {
            List<ArticleModel> articleModels = new();
            if (category is not null)
            {
                if (category == "all")
                {
                    GetAllArticlesQueryRequest getAllArticlesQueryRequest = new();
                    articleModels = await _mediatr.Send(getAllArticlesQueryRequest);
                    return View(articleModels);
                }
                CategoryName categoryName = new();

                if (Enum.TryParse(category, true, out categoryName))
                {
                    GetArticlesByCategoryQueryRequest getArticlesByCategoryQueryRequest = new(categoryName);
                    articleModels = await _mediatr.Send(getArticlesByCategoryQueryRequest);
                    return View(articleModels);
                }
                else
                {
                    return View(articleModels);
                }
            }

            GetAllArticlesQueryRequest getAllArticlesQueryRequest2 = new();
            articleModels = await _mediatr.Send(getAllArticlesQueryRequest2);

            return View(articleModels);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
