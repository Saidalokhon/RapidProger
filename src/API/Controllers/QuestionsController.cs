using API.DbContext;
using API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionsController : ControllerBase
    {
        private readonly RapidProgerDbContext _context;

        public QuestionsController(
            ILogger<QuestionsController> logger,
            RapidProgerDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("")]
        public IActionResult GetQuestions()
        {
            return BaseActionResult(() => _context.Questions
                .ToList());
        }

        [HttpPost]
        [Route("")]
        public IActionResult PostQuestion(Question question)
        {
            return BaseActionResult(() =>
            {
                _context.Questions.Add(question);
                _context.SaveChanges();
            });
        }

        [HttpPut]
        [Route("")]
        public IActionResult UpdateQuestion(Question question)
        {
            return BaseActionResult(() =>
            {
                var answers = _context.Answers.Where(x => x.QuestionId == question.Id);
                if (answers.Any()) _context.RemoveRange(answers);
                _context.Questions.Update(question);
                _context.SaveChanges();
            });
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult DeleteQuestion(int id)
        {
            return BaseActionResult(() =>
            {
                var question = _context.Questions.Find(id);
                if (question == null)
                {
                    throw new KeyNotFoundException($"No such record in the database (Id: {id})");
                }
                _context.Remove(question);
                _context.SaveChanges();
            });
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetQuestion(int id)
        {
            return BaseActionResult(() =>
            {
                var question = _context.Questions.Include(x => x.Answers).FirstOrDefault(x => x.Id == id);
                if (question == null)
                {
                    throw new KeyNotFoundException($"No such record in the database (Id: {id})");
                }

                return question;
            });
        }

        private IActionResult BaseActionResult(Action action)
        {
            try
            {
                action();
                return Ok();
            }
            catch (ArgumentNullException e)
            {
                return BadRequest(e.Message);
            }
            catch (KeyNotFoundException e)
            {
                return BadRequest(e.Message);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        private IActionResult BaseActionResult<T>(Func<T> action)
        {
            try
            {
                var result = action();
                if (result == null)
                {
                    return NotFound(result);
                }

                return Ok(result);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }
    }
}