using Microsoft.AspNetCore.Mvc;
using Model;
using Model.DTO;
using Services.IService;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/comments")]
    public class CommentAPIController: ControllerBase
    {
        private readonly ICommentSubmissionService _commentSubmissionService;
        private readonly ICommentViewerService _commentViewerService;
        private readonly IUserVerificationService _userVerificationService;
        public CommentAPIController(ICommentSubmissionService commentSubmissionService, ICommentViewerService commentViewerService, IUserVerificationService userVerificationService)
        {
            this._commentSubmissionService = commentSubmissionService;
            this._commentViewerService = commentViewerService;
            this._userVerificationService = userVerificationService;
        }


        [HttpPost("submit")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Produces("application/json")]
        public ActionResult Submit([FromBody] CommentSubmissionDTO dto)
        {
            if (!ModelState.IsValid)
            {
                var errorMessages = ModelState.Values.SelectMany(v => v.Errors)
                                             .Select(e => e.ErrorMessage)
                                             .ToList();
                return BadRequest(new { Status = 400, Errors = errorMessages });
            }

            int userId = dto.UserId;
            if (!_userVerificationService.UserExists(userId))
            {
                return BadRequest(new { Status = 404, Message = "User not found." });
            }

            Comment comment = new Comment(dto.Text);
            _commentSubmissionService.Submit(userId, comment);
            return Ok(new { Status = 200, Message = "Successfully submitted the comment." });
        }


        [HttpGet("view")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [Produces("application/json")]
        public ActionResult View()
        {
            ICollection<Comment> comments = _commentViewerService.View();

            return Ok(new { Status = 200, Comments = comments });
        }
    }
}
