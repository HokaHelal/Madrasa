using Madrasa.Dto;
using Madrasa.Repository;
using Madrasa.Shared.Generic;
using System.Threading.Tasks;

namespace Madrasa.Service.UnitOfWork
{
    public interface IForumUow : IGenericUnitOfWork
    {
        ITopicRepository TopicRepository { get; }
        IPostRepository PostRepository { get; }
        ISectionRepository SectionRepository { get; }

        Task<bool> AddNewTopicAsync(NewTopicDto newTopicDto);
        Task<bool> AddNewPostAsync(NewPostDto newPostDto);
    }
}
