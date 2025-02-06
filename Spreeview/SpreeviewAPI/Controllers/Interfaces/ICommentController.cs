using CommonLibrary.DataClasses.CommentModel;
using Microsoft.AspNetCore.Mvc;

namespace SpreeviewAPI.Controllers.Implementations;

public interface ICommentController
{
    Task<ActionResult> IndexAllComments();
    Task<ActionResult> GetCommentById(int id);
    Task<ActionResult> GetCommentsByUserId(int userId);
    Task<ActionResult> GetCommentsByReviewId(int reviewId);
    Task<ActionResult> PostComment(CommentInsertDTO commentDto);
    Task<ActionResult> PutComment(CommentUpdateDTO commentDto);
    Task<ActionResult> DeleteComment(int id);
}
