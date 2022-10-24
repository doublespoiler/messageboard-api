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
  public class GroupsController : ControllerBase
  {
    private readonly MessageBoardContext _db;

    public GroupsController(MessageBoardContext db)
    {
        _db=db;
    }

    private bool GroupExists(int id)
    {
      return _db.Groups.Any(e => e.GroupId == id);
    }
    
    //Get: api/groups/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Group>> GetGroup(int id)
    {
      var group = await _db.Groups.FindAsync(id);

      if (group == null)
      {
          return NotFound();
      }

      return group;
    }

    //Get api/groups
    [HttpGet]
    public async Task<List<Group>> Get(string title, string topic)
    {
        IQueryable<Group> query = _db.Groups.AsQueryable();

        // DateTime myDate = myDataReader.GetDateTime(myColumnIndex);

        if (title != null)
        {
            query= query.Where(entry => entry.GroupTitle == title);
        }

        if (topic != null)
        {
            query= query.Where(entry => entry.GroupTopic == topic);
        }
        
        // if (date != null)
        // {
        //     query= query.Where(entry => entry.GroupCreated.Date.ToString() == date.Date.ToString());
        // }
      return await query.ToListAsync();
    }

    //Post: api/Groups
    [HttpPost]
    public async Task<ActionResult<Group>> Post(Group group)
    {
        _db.Groups.Add(group);
        await _db.SaveChangesAsync();

        return CreatedAtAction(nameof(GetGroup), new {id = group.GroupId}, group);
    }

    //Put: api/Groups/5
    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, Group group)
    {
        if (id != group.GroupId)
        {
            return BadRequest();
        }

        _db.Entry(group).State = EntityState.Modified;

        try
        {
            await _db.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
          if (!GroupExists(id))
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
