using BlogWeb.Mvc.Entities.Base;
using BlogWeb.Mvc.Models.Enums;

namespace BlogWeb.Mvc.Entities
{
    public class Category : BaseEntity
    {
        public CategoryName CategoryName { get; set; }

        public Category()
        {

        }

        public Category(CategoryName categoryName)
        {
            AssignGuidToId();
            CategoryName = categoryName;
        }

        public Category(Guid id, CategoryName categoryName)
        {
            SetId(id);
            CategoryName = categoryName;
        }

        public static Category Create(CategoryName categoryName)
            => new(categoryName);

        public static Category Create(Guid Id, CategoryName categoryName)
            => new(Id, categoryName);
    }
}
