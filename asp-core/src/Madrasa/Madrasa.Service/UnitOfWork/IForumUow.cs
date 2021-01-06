using Madrasa.Dto;
using Madrasa.Repository;
using Madrasa.Shared.Generic;
using System.Collections.Generic;
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
        Task<TopicDetailDto> GetTopicByIdAsync(int Id);
        Task<IEnumerable<TopicMainDto>> GetTopicByAuthorIdAsync(int authorId);
        Task<IEnumerable<MainForumDto>> GetTopicByClassIdAsync(int classId, int lastTopicsNum = 5);
        Task<bool> TogglePinAsync(int topicId);
        Task<IEnumerable<PostDetailDto>> GetPostByAuthorIdAsync(int authorId);
        Task<IEnumerable<TopicMainDto>> GetLatestTopicsAsync(int classId, int lastTopicsNum = 5);
        Task<IEnumerable<TopicMainDto>> GetTopicBySectionIdAsync(int sectionId);
    }
}
