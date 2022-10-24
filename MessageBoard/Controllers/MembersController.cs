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
  public class MemberController : ControllerBase
  {
    private readonly MessageBoardContext _db;

    public MemberController(MessageBoardContext db)
    {
        _db=db;
    }

    private bool MemberExists(int id)
    {
      return _db.Members.Any(e => e.MemberId == id);
    }
    
    //Get: api/members/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Member>> GetMember(int id)
    {
      var member = await _db.Members.FindAsync(id);

      if (member == null)
      {
          return NotFound();
      }

      return member;
    }

    //Get api/members
    [HttpGet]
    public async Task<List<Member>> Get(string name, int id)
    {
        IQueryable<Member> query = _db.Members.AsQueryable();

        // DateTime myDate = myDataReader.GetDateTime(myColumnIndex);

        if (name != null)
        {
            query= query.Where(e => e.MemberName == name);
        }       
        
        // if (date != null)
        // {
        //     query= query.Where(entry => entry.MemberCreated.Date.ToString() == date.Date.ToString());
        // }
      return await query.ToListAsync();
    }

    //Post: api/Members
    [HttpPost]
    public async Task<ActionResult<Member>> Post(Member member)
    {
        _db.Members.Add(member);
        await _db.SaveChangesAsync();

        return CreatedAtAction(nameof(GetMember), new {id = member.MemberId}, member);
    }

    //Put: api/Members/5
    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, Member member)
    {
        if (id != member.MemberId)
        {
            return BadRequest();
        }

        _db.Entry(member).State = EntityState.Modified;

        try
        {
            await _db.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
          if (!MemberExists(id))
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
