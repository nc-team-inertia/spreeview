using CommonLibrary.DataClasses.CommentModel;
using SpreeviewAPI.Wrappers;

namespace SpreeviewFrontend.Services.ApiCommentService;

public interface IApiCommentService
{
    Task<ServiceObjectResponse<List<CommentGetDTO>>> GetCommentsByUserId(int userId);
}