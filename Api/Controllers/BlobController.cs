using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using MediatR;
using AutoMapper;
using System.Net.Http.Headers;
using Application;
using Api.Dtos.FoundPetPosts;
using Application.Services;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlobController : ControllerBase
    {
        private readonly IBlobService _blobService;
        public BlobController(IBlobService blobService)
        {
            this._blobService = blobService ?? throw new ArgumentNullException(nameof(blobService));
        }


        [HttpPost, DisableRequestSizeLimit]
        public async Task<IActionResult> UploadAsync()
        {
            //var files = await Request.ReadFormAsync();
            var files = Request.Form.Files;

            if (files.Any(f => f.Length == 0))
            {
                return BadRequest();
            }   

            var filesUrls = new List<PictureDto>();

            foreach (var file in files)
            {
                var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                string fileURL = await _blobService.UploadAsync(file.OpenReadStream(), fileName, file.ContentType);
                filesUrls.Add(new PictureDto { Url = fileURL });
            }

            return Ok(new { filesUrls });
        }


        [HttpGet]
        [Route("{blobName}")]
        public async Task<IActionResult> GetPicture(string pictureName)
        {
            var data = await _blobService.GetPictureAsync(pictureName);
            return File(data.Content, data.ContentType);
        }

        [HttpGet]
        [Route("list")]
        public async Task<IActionResult> GetAllAsync()
        {
            return Ok(await _blobService.GetAllAsync());
        }


        [HttpDelete]
        [Route("{pictureName}")]
        public async Task<IActionResult> DeletePicture(string pictureName)
        {
            await _blobService.DeletePictureAsync(pictureName);
            return Ok();
        }

    }
}