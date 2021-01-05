using AutoMapper;
using Madrasa.Dto;
using Madrasa.Models;
using Madrasa.Repository;
using Madrasa.Shared.Generic;
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

        public async Task<bool> AddNewTopicAsync(NewTopicDto newTopicDto)
        {
            var newTopic = _mapper.Map<Topic>(newTopicDto);
            var isAdded = await TopicRepository.AddAsync(newTopic);
            if (isAdded)
                return await CommitAsync();
            else
                return isAdded;
        }

        public async Task<bool> AddNewPostAsync(NewPostDto newPostDto)
        {
            var newPost = _mapper.Map<Post>(newPostDto);
            var isAdded = await PostRepository.AddAsync(newPost);
            if (isAdded)
                return await CommitAsync();
            else
                return isAdded;
        }
    }
}
