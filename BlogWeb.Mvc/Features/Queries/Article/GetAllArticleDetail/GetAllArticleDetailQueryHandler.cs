using BlogWeb.Mvc.Abstractions;
using BlogWeb.Mvc.Entities;
using BlogWeb.Mvc.Models.ViewModels.Article;
using MediatR;

namespace BlogWeb.Mvc.Features.Queries.Article.GetAllArticleDetail
{
    public class GetAllArticleDetailQueryHandler(IRepository<Entities.Article> _repository) : IRequestHandler<GetAllArticleDetailQueryRequest, ArticleModel>
    {
        public async Task<ArticleModel> Handle(GetAllArticleDetailQueryRequest request, CancellationToken cancellationToken)
        {
            Entities.Article article = await _repository.GetAsync(a => a.Id == request.articleId, false, a => a.ArticleDetails);

            ArticleModel articleModel = new ArticleModel().ArticleMapper(article.Id, article.Title, article.Description, article.ImagePath, article.CreatedAt, article.ArticleDetails);
            
            return articleModel;
        }
    }
}
