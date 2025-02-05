using AutoMapper;
using CommonLibrary.DataClasses.CommentModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SpreeviewAPI.Services.Implementations;

namespace SpreeviewAPI.Controllers.Implementations;

[ApiController]
[Route("api/[controller]")]
public class CommentController : ControllerBase, ICommentController
{
    private readonly ICommentService _commentService;
    private readonly IMapper _mapper;

    public CommentController(ICommentService commentService, IMapper mapper)
    {
        _commentService = commentService;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<ActionResult> Index()
    {
        var response = await _commentService.Index();
        if (response == null) return NotFound();
        var responseDto = _mapper.Map<List<CommentGetDTO>>(response);
        return Ok(responseDto);
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult> GetById(int id)
    {
        var response = await _commentService.GetById(id);
        if (response == null) return NotFound();
        var responseDto = _mapper.Map<CommentGetDTO>(response);
        return Ok(responseDto);
    }

    [HttpGet("user/{userId:int}")]
    public async Task<ActionResult> GetByUserId(int userId)
    {
        var response = await _commentService.GetByUserId(userId);
        if (response == null) return NotFound();
        var responseDto = _mapper.Map<List<CommentGetDTO>>(response);
        return Ok(responseDto);
    }

    [HttpGet("review/{reviewId:int}")]
    public async Task<ActionResult> GetByReviewId(int reviewId)
    {
        var response = await _commentService.GetByReviewId(reviewId);
        if (response == null) return NotFound();
        var responseDto = _mapper.Map<List<CommentGetDTO>>(response);
        return Ok(responseDto);
    }

    [Authorize]
    [HttpPost]
    public async Task<ActionResult> Create(CommentInsertDTO commentDto)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);
        var comment = _mapper.Map<Comment>(commentDto);
        var response = await _commentService.Create(comment);
        if (response == null) return BadRequest();
        var responseDto = _mapper.Map<CommentGetDTO>(response);
        return Ok(responseDto);
    }

    [Authorize]
    [HttpPut]
    public async Task<ActionResult> Update(CommentUpdateDTO commentDto)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);
        var exists = await _commentService.GetById(commentDto.Id);
        if (exists == null) return NotFound();
        var response = await _commentService.Update(commentDto);
        if (response == null) return BadRequest();
        var responseDto = _mapper.Map<CommentGetDTO>(response);
        return Ok(responseDto);
    }
    
    [Authorize]
    [HttpDelete("{id:int}")]
    public async Task<ActionResult> Delete(int id)
    {
        var response = await _commentService.Delete(id);
        return response ? NoContent() : NotFound();
    }
}