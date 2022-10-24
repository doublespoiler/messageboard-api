using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MessageBoard.Models;

namespace MessageBoard.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class MessagesController : ControllerBase
  {
    private readonly MessageBoardContext _db;

    public MessagesController(MessageBoardContext db)
    {
        _db=db;
    }

    private bool MessageExists(int id)
    {
      return _db.Messages.Any(e => e.MessageId == id);
    }
    
    //Get: api/messages/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Message>> GetMessage(int id)
    {
      var message = await _db.Messages.FindAsync(id);

      if (message == null)
      {
          return NotFound();
      }

      return message;
    }

    //Get api/messages
    [HttpGet]
    public async Task<List<Message>> Get(string title, string text, DateTime date)
    {
        IQueryable<Message> query = _db.Messages.AsQueryable();

        // DateTime myDate = myDataReader.GetDateTime(myColumnIndex);

        if (title != null)
        {
            query= query.Where(entry => entry.MessageTitle == title);
        }

        if (text != null)
        {
            query= query.Where(entry => entry.MessageText == text);
        }
        
        // if (date != null)
        // {
        //     query= query.Where(entry => entry.MessageCreated.Date.ToString() == date.Date.ToString());
        // }
      return await query.ToListAsync();
    }

    //Post: api/Messages
    [HttpPost]
    public async Task<ActionResult<Message>> Post(Message message)
    {
      _db.Messages.Add(message);
      await _db.SaveChangesAsync();

      return CreatedAtAction(nameof(GetMessage), new {id = message.MessageId}, message);
    }

    //Put: api/Messages/5
    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, Message message)
    {
        if (id != message.MessageId)
        {
            return BadRequest();
        }

        _db.Entry(message).State = EntityState.Modified;

        try
        {
            await _db.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
          if (!MessageExists(id))
          {
              return NotFound();
          }
          else
          {
              throw;
          }
        }
        return NoContent();
    }
  }
}
