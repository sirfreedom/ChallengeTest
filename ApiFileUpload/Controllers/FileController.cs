using file.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Drawing;

namespace file.Controllers
{
    [Route("api/file")]
    [ApiController]
    public class FileController : ControllerBase
    {

        [HttpGet]
        public string Get() 
        {
            return "test";
        }


        [HttpPost]
        public ActionResult Post([FromForm] FileModel file)
        {
            ImageHelper.ImageHelper i = new ImageHelper.ImageHelper();
            string sReturn = string.Empty;
            JsonResult result;
            try
            {
                sReturn = i.ImageToBase64(i.resizeImage(i.StreamToImage(file.FormFile.OpenReadStream()),100,100));
                result = new JsonResult(sReturn);
                return result;  //StatusCode(StatusCodes.Status201Created);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,ex.Message);
            }
        }






	}
}
