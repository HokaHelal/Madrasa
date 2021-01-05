using Madrasa.Dto;
using Madrasa.Service.UnitOfWork;
using Madrasa.Shared.Errors;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Madrasa.API.Controllers
{
    public class ForumController : BaseApiController
    {
        private readonly IForumUow _unitOfWork;

        public ForumController(IForumUow unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpPost("new-topic")]
        public async Task<IActionResult> NewTopic(NewTopicDto newTopicDto)
        {
            var isAddedSuccessfully = await _unitOfWork.AddNewTopicAsync(newTopicDto);

            if (isAddedSuccessfully)
                return Ok();
            else
                throw new BadRequestException("unable to add new topic");
        }

        [HttpPost("new-post")]
        public async Task<IActionResult> NewPost(NewPostDto newPostDto)
        {
            var isAddedSuccessfully = await _unitOfWork.AddNewPostAsync(newPostDto);

            if (isAddedSuccessfully)
                return Ok();
            else
                throw new BadRequestException("unable to add new post");
        }
    }
}
