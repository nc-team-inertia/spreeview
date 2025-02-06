using CommonLibrary.DataClasses.CommentModel;
using CommonLibrary.DataClasses.ReviewModel;
using SpreeviewAPI.Wrappers;

namespace SpreeviewFrontend.Services.ApiCommentService;

public interface IApiCommentService
{
	Task<ServiceObjectResponse<List<CommentGetDTO>>> GetReviewComments(int episodeId);
	Task<ServiceObjectResponse<CommentGetDTO?>> PostReviewComment(CommentInsertDTO comment);
}