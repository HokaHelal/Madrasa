using AutoMapper;
using AutoMapper.QueryableExtensions;
using Madrasa.Dto;
using Madrasa.Models;
using Madrasa.Repository;
using Madrasa.Shared.Errors;
using Madrasa.Shared.Generic;
using Microsoft.EntityFrameworkCore;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Madrasa.Service.UnitOfWork
{
    public class ForumUow : GenericUnitOfWork, IForumUow
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public ITopicRepository TopicRepository => new TopicRepository(_context);

        public IPostRepository PostRepository => new PostRepository(_context);

        public ISectionRepository SectionRepository => new SectionRepository(_context);

        public ForumUow(DataContext context, IMapper mapper) : base(context)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<int> AddNewTopicAsync(NewTopicDto newTopicDto)
        {
            var newTopic = _mapper.Map<Topic>(newTopicDto);
            var isAdded = await TopicRepository.AddAsync(newTopic);
            if (isAdded && await CommitAsync())
                return newTopic.Id;
            else
                throw new BadRequestException("unable to add new post");
        }

        public async Task<int> AddNewPostAsync(NewPostDto newPostDto)
        {
            var newPost = _mapper.Map<Post>(newPostDto);
            var isAdded = await PostRepository.AddAsync(newPost);
            if (isAdded && await CommitAsync())
                return newPost.Id;
            else
                throw new BadRequestException("unable to add new post");
        }

        public async Task<TopicDetailDto> GetTopicByIdAsync(int Id)
        {
            var topic = await _context.Topics
                .Include(u => u.Author).Include(l => l.UserLikes)
                .Include(p => p.Posts.OrderBy(o => o.Created)).ThenInclude(l => l.UserLikes)
                .ProjectTo<TopicDetailDto>(_mapper.ConfigurationProvider)
                .SingleOrDefaultAsync(i => i.id == Id);
           
            return topic;
        }

        public async Task<IEnumerable<TopicMainDto>> GetTopicByAuthorIdAsync(int authorId)
        {
            var userTopics = await _context.Topics
                            .Include(l => l.Section)
                            .OrderByDescending(o => o.Created)
                            .Where(i => i.AuthorId == authorId).ToListAsync();

            var retUserTopics = _mapper.Map<IEnumerable<TopicMainDto>>(userTopics);

            return retUserTopics;
        }

        public async Task<IEnumerable<MainForumDto>> GetTopicByClassIdAsync(int classId, int lastTopicsNum = 5)
        {
            var userPosts = await _context.Sections
                                       .Include(t => t.Topics
                                                      .Where(c => c.ClassId == classId)
                                                      .Take(lastTopicsNum)
                                                      .OrderByDescending(o => o.Created))
                                       .ThenInclude(a => a.Author)
                                       .OrderBy(o => o.OrderNum)
                                       .ToListAsync();

            var reMainForum = _mapper.Map<IEnumerable<MainForumDto>>(userPosts);

            return reMainForum;
        }

        public async Task<bool> TogglePinAsync(int topicId)
        {
            var topic = await TopicRepository.GetByIdAsync(topicId);
            topic.IsPinned = !topic.IsPinned;
            TopicRepository.Update(topic);
            var isCommitted = await CommitAsync();

            if (isCommitted)            
                return topic.IsPinned;
            else
                throw new BadRequestException("Unable to pin/unpin topic");
        }

        public async Task<IEnumerable<PostDetailDto>> GetPostByAuthorIdAsync(int authorId)
        {
            var userPosts = await _context.Posts
                                       .Include(t => t.Topic)
                                       .Include(l => l.UserLikes)
                                       .Where(i => i.AuthorId == authorId)
                                       .OrderByDescending(o => o.Created)
                                       .ToListAsync();

            var retUserTopics = _mapper.Map<IEnumerable<PostDetailDto>>(userPosts);

            return retUserTopics;
        }

        public async Task<IEnumerable<TopicMainDto>> GetLatestTopicsAsync(int classId, int lastTopicsNum = 5)
        {
            var userPosts = await _context.Topics
                                  .Include(s=>s.Section).Include(a => a.Author)
                                  .Where(c => c.ClassId == classId)
                                  .Take(lastTopicsNum)
                                  .OrderByDescending(o => o.Created)
                                  .ToListAsync();

            var retLastTopics = _mapper.Map<IEnumerable<TopicMainDto>>(userPosts);

            return retLastTopics;
        }

        public async Task<IEnumerable<TopicMainDto>> GetTopicBySectionIdAsync(int sectionId)
        {
            var userPosts = await _context.Topics
                                            .Include(s => s.Section).Include(a => a.Author)
                                            .Where(c => c.SectionId == sectionId)
                                            .OrderByDescending(o => o.Created)
                                            .ToListAsync();

            var retLastTopics = _mapper.Map<IEnumerable<TopicMainDto>>(userPosts);

            return retLastTopics;
        }

        public async Task<bool> ToggleLike(NewLikeDto newLike)
        {
            bool isLiked = false;
            var user = await _context.Users.FindAsync(newLike.userId);

            if (newLike.isTopic)
            {
                var userLike = await _context.Topics
                    .Include(p => p.UserLikes.Where(x => x.Id == newLike.userId))
                    .SingleOrDefaultAsync(t => t.Id == newLike.threadId);

                if (userLike?.UserLikes?.Count != 0)                
                    userLike.UserLikes.Remove(user);
                else
                {
                    userLike.UserLikes.Add(user);
                    isLiked = true;
                }
            }
            else
            {
                var userLike = await _context.Posts
                    .Include(p => p.UserLikes.Where(x => x.Id == newLike.userId))
                    .SingleOrDefaultAsync(t => t.Id == newLike.threadId);

                if (userLike?.UserLikes?.Count != 0)
                    userLike.UserLikes.Remove(user);
                else
                {
                    userLike.UserLikes.Add(user);
                    isLiked = true;
                }
            }

            if (await CommitAsync())
                return isLiked;
            else
                throw new BadRequestException("unable to toggle like");
          
        }

    }
}
