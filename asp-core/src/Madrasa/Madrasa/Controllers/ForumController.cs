﻿using Madrasa.Dto;
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
        [HttpGet("topic/section/{sectionId}")]
        public async Task<IActionResult> GetBySectionId(int sectionId)
        {
            var sectionTopics = await _unitOfWork.GetTopicBySectionIdAsync(sectionId);

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
    }
}
