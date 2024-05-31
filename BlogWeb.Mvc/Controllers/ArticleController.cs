using BlogWeb.Mvc.Entities;
using BlogWeb.Mvc.Features.Queries.Article.GetAllArticleDetail;
using BlogWeb.Mvc.Features.Queries.Article.GetAllArticles;
using BlogWeb.Mvc.Features.Queries.Article.GetArticlesByCategory;
using BlogWeb.Mvc.Models.Enums;
using BlogWeb.Mvc.Models.ViewModels.Article;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BlogWeb.Mvc.Controllers
{
    [AllowAnonymous]
    public class ArticleController(IMediator _mediatr) : BaseController
    {
        /// <summary>
        /// Tüm ilanları getirir
        /// </summary>
        /// <param name="category"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("GetAllArticles")]
        public async Task<IActionResult> GetAllArticles(string? category = null)
        {
            if (category is not null)
            {
                List<ArticleModel> articleModels = new();
                if (category == "all")
                {
                    GetAllArticlesQueryRequest getAllArticlesQueryRequest = new();
                    articleModels = await _mediatr.Send(getAllArticlesQueryRequest);
                    articleModels = articleModels.OrderBy(a => a.CreatedAt).ToList();
                    return View(articleModels);
                }
                CategoryName categoryName = new();

                if (Enum.TryParse(category, true, out categoryName))
                {
                    GetArticlesByCategoryQueryRequest getArticlesByCategoryQueryRequest = new(categoryName);
                    articleModels = await _mediatr.Send(getArticlesByCategoryQueryRequest);
                    articleModels = articleModels.OrderBy(a => a.CreatedAt).ToList();
                    return View(articleModels);
                }
                else
                {
                    return View(articleModels);
                }
            }
            GetAllArticlesQueryRequest getAllArticlesQueryRequest1 = new();
            List<ArticleModel> articleModel = await _mediatr.Send(getAllArticlesQueryRequest1);
            articleModel = articleModel.OrderBy(a => a.CreatedAt).ToList();
            return View(articleModel);
        }

        /// <summary>
        /// seçilen makalenin detaylarını getirir
        /// </summary>
        /// <param name="articleId"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("GetAllArticleDetail")]
        public async Task<IActionResult> GetAllArticleDetail(Guid articleId)
        {
            GetAllArticleDetailQueryRequest getAllArticleDetailQueryRequest = new(articleId);
            ArticleModel articleDetails = await _mediatr.Send(getAllArticleDetailQueryRequest);
            articleDetails.ArticleDetailModel.OrderBy(ad => ad.CreatedAt);
            return View(articleDetails);
        }

        //[HttpGet]
        //[Route("GetArticlesByCategory")]
        //public async Task<IActionResult> GetArticlesByCategory(string category)
        //{

        //}
    }
}
