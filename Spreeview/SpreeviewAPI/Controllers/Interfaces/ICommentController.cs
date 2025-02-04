using System.Security.Claims;
using System.Text;
using CommonLibrary.DataClasses.CommentModel;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.Net.Http.Headers;

namespace SpreeviewAPI.Controllers.Implementations;

public interface ICommentController
{
    Task<ActionResult> Index();
    Task<ActionResult> GetById(int id);
    Task<ActionResult> GetByUserId(int userId);
    Task<ActionResult> GetByReviewId(int reviewId);
    Task<ActionResult> Create(CommentInsertDTO commentDto);
    Task<ActionResult> Update(CommentUpdateDTO commentDto);
    Task<ActionResult> Delete(int id);
}