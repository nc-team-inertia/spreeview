using AutoMapper;
using CommonLibrary.DataClasses.CommentModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SpreeviewAPI.Models;
using SpreeviewAPI.Services.Implementations;

namespace SpreeviewAPI.Controllers.Implementations;

[ApiController]
[Route("api/[controller]")]
public class CommentController : ControllerBase, ICommentController
{
    private readonly ICommentService _commentService;
    private readonly IMapper _mapper;
    private readonly UserManager<ApplicationUser> _userManager;

    public CommentController(ICommentService commentService, IMapper mapper, UserManager<ApplicationUser> userManager)
    {
        _commentService = commentService;
        _mapper = mapper;
        _userManager = userManager;
    }

    [HttpGet]
    public async Task<ActionResult> IndexAllComments()
    {
        var response = await _commentService.IndexAllComments();
        if (response == null) return NotFound("There were no comments found.");
        var responseDto = _mapper.Map<List<CommentGetDTO>>(response);
        return Ok(responseDto);
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult> GetCommentById(int id)
    {
        var response = await _commentService.FindCommentById(id);
        if (response == null) return NotFound("There is no comment with the associated ID.");
        var responseDto = _mapper.Map<CommentGetDTO>(response);
        return Ok(responseDto);
    }

    [HttpGet("user/{userId:int}")]
    public async Task<ActionResult> GetCommentsByUserId(int userId)
    {
        var response = await _commentService.FindCommentsByUserId(userId);
        if (response == null) return NotFound("There were no comments by the associated user ID.");
        var responseDto = _mapper.Map<List<CommentGetDTO>>(response);
        return Ok(responseDto);
    }

    [HttpGet("review/{reviewId:int}")]
    public async Task<ActionResult> GetCommentsByReviewId(int reviewId)
    {
        var response = await _commentService.FindCommentsByReviewId(reviewId);
        if (response == null) return NotFound("There were no comments with the associated review ID.");
        var responseDto = _mapper.Map<List<CommentGetDTO>>(response);
        return Ok(responseDto);
    }

    [Authorize]
    [HttpPost]
    public async Task<ActionResult> PostComment(CommentInsertDTO commentDto)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);
        
        // Get the current user
        var user = await _userManager.GetUserAsync(User);
        if (user == null) return Unauthorized();
        
        var comment = _mapper.Map<Comment>(commentDto);
        
        // Set the user id from the current user
        comment.UserId = user.Id;
        
        var response = await _commentService.CreateComment(comment);
        if (response == null) return BadRequest();
        var responseDto = _mapper.Map<CommentGetDTO>(response);
        return Ok(responseDto);
    }

    [Authorize]
    [HttpPut]
    public async Task<ActionResult> PutComment(CommentUpdateDTO commentDto)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);
        
        //TODO: Optimize this service / repository call path to avoid multiple database calls. 
        // We could do with check user owns review service method.
        
        //Get the comment if exists
        var exists = await _commentService.FindCommentById(commentDto.Id);
        if (exists == null) return NotFound("There were no comments with the associated ID.");
        
        // Get the current user
        var user = await _userManager.GetUserAsync(User);
        if (user == null) return Unauthorized();
        
        // Check if user owns the comment
        if (exists.UserId != user.Id) return Unauthorized();
        
        var response = await _commentService.UpdateComment(commentDto);
        var responseDto = _mapper.Map<CommentGetDTO>(response);
        return Ok(responseDto);
    }
    
    [Authorize]
    [HttpDelete("{id:int}")]
    public async Task<ActionResult> DeleteComment(int id)
    {
        //TODO: Optimize this service / repository call path to avoid multiple database calls. 
        // We could do with check user owns review service method.
        
        //Get comment if exists
        var exists = await _commentService.FindCommentById(id);
        if (exists == null) return NotFound("There were no comments with the associated ID.");
        
        // Get the current user
        var user = await _userManager.GetUserAsync(User);
        if (user == null) return Unauthorized();
        
        // Check if user owns the review
        if (exists.UserId != user.Id) return Unauthorized();
        
        var response = await _commentService.DeleteComment(id);
        return response ? NoContent() : NotFound("There were no comments with the associated ID.");
    }
}
