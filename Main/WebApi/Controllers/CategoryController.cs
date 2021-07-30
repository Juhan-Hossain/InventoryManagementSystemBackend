using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Repository.Entities;

namespace Web_Api.Controllers 
{
    [ApiController]
    [Route("[controller]")]
    public class CategoryController : ControllerBase
    {
        //Initializing Business Logic layer to Api Controller
        private readonly Business_logic_Layer.CategoryBLL _BLL;
        public CategoryController()
        {
            _BLL = new Business_logic_Layer.CategoryBLL();

        }

        [HttpGet]


        public ActionResult<List<Category>> GetAllCategorys()
        {
            var categories = _BLL.GetAllCategories();
            if (categories == null)
            {
                return NotFound("Invalid Request");
            }
            return Ok(categories);
        }



        [HttpGet]
        [Route("{id:int}")]

        public ActionResult<Category> GetCategoryById(int id)
        {
            var category = _BLL.GetCategoryById(id);
            if (category == null)
            {
                return NotFound("Invalid Id");
            }
            return Ok(category);
        }

        [HttpPost]


        public ActionResult<List<Category>> PostCategory(Category category)
        {
            var categories = _BLL.PostCategory(category);
            if (categories == null)
            {
                return NotFound("Invalid Request");
            }
            return Ok(categories);

        }

        [HttpDelete]
        [Route("{id:int}")]

        public ActionResult<List<Category>> DeleteCategoryById(int id)
        {
            var categories = _BLL.DeleteCategoryById(id);
            if (categories == null)
            {
                return NotFound("Invalid Request");
            }
            return Ok(categories);
        }

        [HttpPut]


        public ActionResult<List<Category>> PutCategory(Category category)
        {
            var categories = _BLL.PutCategory(category);
            if (categories == null)
            {
                return NotFound("Invalid Request");
            }
            return Ok(categories);
        }

    }
}
