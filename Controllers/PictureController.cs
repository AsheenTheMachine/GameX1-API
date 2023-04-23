using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace GameX1API.Controllers { }


[Route("api/[controller]")]
[ApiController]
public class PictureController : BaseController
{
    [HttpGet]
    public IActionResult Index()
    {
        return Ok(HttpStatusCode.NotImplemented);
    }

    [HttpPost("new")]
    public async Task<IActionResult> CreatePicture([FromBody] Picture model)
    {
        #region Validation
        if (!ModelState.IsValid)
            return BadRequest(new { message = GetErrors() });
        #endregion

        int complete = 0;

        //save picture to database
        using (var context = new DataContext())
        {

            var pic = new Picture()
            {
                Url = model.Url,
            };

            await context.Picture.AddAsync(pic);
            complete = await context.SaveChangesAsync();
        }

        return Ok(complete);
    }

    [HttpPost("delete")]
    public async Task<IActionResult> DeletePicture(int id)
    {
        #region Validation
        if(id == 0)
            return BadRequest(new { message = "Id must be greater than 0" });
        #endregion

        int complete = 0;

        //save picture to database
        using (var context = new DataContext())
        {

            Picture pic = await context.Picture.FindAsync(id);

            context.Picture.Remove(pic);
            complete = await context.SaveChangesAsync();
        }

        return Ok(complete);
    }

    [HttpGet("get-single/{id}")]
    public async Task<IActionResult> GetSinglePictureById(int id)
    {
        #region Validation
        if (id == 0)
            return BadRequest(new { message = "Id must be greater than 0" });
        #endregion

        //save picture to database
        using (var context = new DataContext())
        {
            Picture pic = await context.Picture.FindAsync(id);

            return Ok(pic);
        }
    }

    /// <summary>
    /// Gets 5 pictures where the Id is greater than id
    /// </summary>
    /// <param name="id">Last id viewed by UI</param>
    /// <returns>A list of 5 Pictures</returns>
    [HttpGet("get-multiple/{id}")]
    public async Task<IActionResult> GetMultiplPictures(int id)
    {
        #region Validation
        if (!ModelState.IsValid)
            return BadRequest(new { message = GetErrors() });
        #endregion

        //save picture to database
        using (var context = new DataContext())
        {
            //fetch a list of pictures to present to UI
            List<Picture> pictures = await (from p in context.Picture
                                            where p.PictureId > id
                                            select p)
                                .Take(5)
                                .ToListAsync();

            return Ok(pictures);
        }
    }
}

