using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RazorPagesMovie.Models
{
    public class Movie
    {
        /// <summary>
        /// 数据库需要 ID 字段以获取主键。
        /// </summary>
        public int Id { get; set; }



        [StringLength(60, MinimumLength = 3)]
        [Required]
        public string? Title { get; set; }


        /// <summary>
        /// [DataType] 属性，用于指定 ReleaseDate 属性中的数据类型。 通过此特性：
        /// 用户无需在日期字段中输入时间信息。
        /// 仅显示日期，而非时间信息。
        /// </summary>
        // [Display(Name = "Release Date")]
        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }

        /// <summary>
        /// Genre string 后的问号表示属性可为空。
        /// </summary>
        [RegularExpression(@"^[A-Z]+[a-zA-Z\s]*$")]
        [Required]
        [StringLength(30)]
        public string? Genre { get; set; }


        /// <summary>
        /// [Column(TypeName = "decimal(18, 2)")] 数据注释使 Entity Framework Core 可以将 Price 正确映射到数据库中的货币。 
        /// 有关详细信息，请参阅数据类型。
        /// </summary>
        [Range(1, 100)]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Price { get; set; }


        [RegularExpression(@"^[A-Z]+[a-zA-Z0-9""'\s-]*$")]
        [StringLength(5)]
        [Required]
        public string Rating { get; set; } = string.Empty;


        /*
         * [Required] 和 [MinimumLength] 特性指示属性必须具有一个值。 不阻止用户输入空格来满足此验证。
           [RegularExpression] 特性用于限制可输入的字符。 在上述代码中，Genre：           
                只能使用字母。
                第一个字母必须为大写。 允许使用空格，但不允许使用数字和特殊字符。

           RegularExpressionRating：           
               要求第一个字符为大写字母。
               允许在后续空格中使用特殊字符和数字。 “PG-13”对“分级”有效，但对于“Genre”无效。
           [Range] 特性将值限制在指定的范围内。           
           [StringLength] 特性可以设置字符串属性的最大长度，以及可选的最小长度。
           
           从本质上来说，需要值类型（如 decimal、int、float、DateTime），但不需要 [Required] 特性。
         */
    }
}


