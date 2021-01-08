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
            var newTopicId = await _unitOfWork.AddNewTopicAsync(newTopicDto);

            return Ok(newTopicId);
        }

        [HttpPost("new-post")]
        public async Task<IActionResult> NewPost(NewPostDto newPostDto)
        {
            var newPostId = await _unitOfWork.AddNewPostAsync(newPostDto);

            return Ok(newPostId);

        }

        [HttpDelete("delete-topic")]
        public async Task<IActionResult> DeleteTopic(int id)
        {
            var isDeletedSuccessfully = await _unitOfWork.TopicRepository.DeleteAsync(id);

            if (isDeletedSuccessfully)
                return Ok();
            else
                throw new BadRequestException("unable to delete topic");
        }

        [HttpDelete("delete-post")]
        public async Task<IActionResult> DeletePost(int id)
        {
            var isDeletedSuccessfully = await _unitOfWork.PostRepository.DeleteAsync(id);

            if (isDeletedSuccessfully)
                return Ok();
            else
                throw new BadRequestException("unable to delete post");
        }

        [HttpGet("topic/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var topic = await _unitOfWork.GetTopicByIdAsync(id);

            return Ok(topic);
        }
        [HttpGet("topic/profile/{authorId}")]
        public async Task<IActionResult> GetTopicByAuthorId(int authorId)
        {
            var userTopics = await _unitOfWork.GetTopicByAuthorIdAsync(authorId);

            return Ok(userTopics);
        }
        [HttpGet("post/profile/{authorId}")]
        public async Task<IActionResult> GetPostByAuthorId(int authorId)
        {
            var userPosts = await _unitOfWork.GetPostByAuthorIdAsync(authorId);

            return Ok(userPosts);
        }
        [HttpGet("topic/class/{classId}")]
        public async Task<IActionResult> GetByClassId(int classId)
        {
            var userTopics = await _unitOfWork.GetTopicByClassIdAsync(classId);

            return Ok(userTopics);
        }
        [HttpGet("section/{sectionId}/class/{classId}")]
        public async Task<IActionResult> GetBySectionId(int sectionId, int classId)
        {
            var sectionTopics = await _unitOfWork.GetSectionTopicsById(sectionId, classId);

            return Ok(sectionTopics);
        }

        [HttpGet("topic/{topicId}/toggle-pin")]
        public async Task<IActionResult> TogglePin(int topicId)
        {
            var isPinned = await _unitOfWork.TogglePinAsync(topicId);

            return Ok(isPinned);
        }

        [HttpGet("topic/{classId}/get-latest")]
        public async Task<IActionResult> GetLatest(int classId)
        {
            var latestTopics = await _unitOfWork.GetLatestTopicsAsync(classId);

            return Ok(latestTopics);
        }

        [HttpGet("topic/toggle-like")]
        public async Task<IActionResult> ToggleLike([FromQuery] NewLikeDto newLikeDto)
        {
            var isLiked = await _unitOfWork.ToggleLike(newLikeDto);

            return Ok(isLiked);
        }

    }
}
