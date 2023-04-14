using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RazorPagesMovie.Data;
using RazorPagesMovie.Models;

namespace RazorPagesMovie.Pages.Movies
{
    public class IndexModel : PageModel
    {
        private readonly RazorPagesMovie.Data.RazorPagesMovieContext _context;

        public IndexModel(RazorPagesMovie.Data.RazorPagesMovieContext context)
        {
            _context = context;
        }

        public IList<Movie> Movie { get;set; } = default!;

        /// <summary>
        /// 包含用户在搜索文本框中输入的文本
        /// [BindProperty] 会绑定名称与属性相同的表单值和查询字符串。
        /// 在 HTTP GET 请求中进行绑定需要 [BindProperty(SupportsGet = true)]
        /// </summary>
        [BindProperty(SupportsGet = true)]
        public string? SearchString { get; set; }

        /// <summary>
        /// Genres：包含流派列表。 Genres 使用户能够从列表中选择一种流派。
        /// SelectList 需要 using Microsoft.AspNetCore.Mvc.Rendering;
        /// </summary>
        public SelectList? Genres { get; set; }

        /// <summary>
        /// MovieGenre：包含用户选择的特定流派。 例如，“Western”。
        /// </summary>
        [BindProperty(SupportsGet = true)]
        public string? MovieGenre { get; set; }


        // 导航到电影页面，并向 URL 追加一个如 ?searchString=Ghost 的查询字符串。
        // https://localhost:5001/Movies?searchString=Ghost
        public async Task OnGetAsync()
        {

            // 下面的代码是一种 LINQ 查询，可从数据库中检索所有流派。
            IQueryable<string> genreQuery = from m in _context.Movie
                                            orderby m.Genre
                                            select m.Genre;
            // 下面的代码是一种 LINQ 查询，可从数据库中检索所有流派。
            Genres = new SelectList(await genreQuery.Distinct().ToListAsync());


            // 此时仅对查询进行了定义，还没有对数据库运行查询。
            var movies = from m in _context.Movie select m;

            // 如果 SearchString 属性不为 null 或空，则电影查询会修改为根据搜索字符串进行筛选：
            if (!string.IsNullOrEmpty(SearchString))
            {
                // 在对 LINQ 查询进行定义或通过调用方法（如 Where、Contains 或 OrderBy）进行修改后，此查询不会执行。
                // s => s.Title.Contains() 代码是 Lambda 表达式
                movies = movies.Where(s => s.Title.Contains(SearchString));
               
            }


            if (!string.IsNullOrEmpty(MovieGenre))
            {
                movies = movies.Where(x => x.Genre == MovieGenre);
            }


         

            // 表达式的计算会延迟，直到循环访问其实现的值或者调用 ToListAsync 方法为止。
            Movie = await movies.ToListAsync();
            //SearchString=string.Empty;

        }
    }
}
