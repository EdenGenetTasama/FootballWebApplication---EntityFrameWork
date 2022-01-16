using FootballWebApplication.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace FootballWebApplication.Controllers.api
{
    public class PlayerController : ApiController
    {
        FootBallContext DBContext = new FootBallContext();
        // GET: api/Player
        public IHttpActionResult Get()
        {
            try
            {
                List<Player> listOfPlayers = DBContext.Players.ToList();
                return Ok(new { listOfPlayers });
            }
            catch (SqlException ex)
            {
                return BadRequest(ex.Message);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: api/Player/5
        public async Task<IHttpActionResult> Get(int id)
        {
            try
            {
                Player playerById = await DBContext.Players.FindAsync(id);
                return Ok(new { playerById });
            }
            catch (SqlException ex)
            {
                return BadRequest(ex.Message);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST: api/Player
        public async Task<IHttpActionResult> Post([FromBody] Player player)
        {
            try
            {
                DBContext.Players.Add(player);
                await DBContext.SaveChangesAsync();
                return Ok(player);
            }
            catch (SqlException ex)
            {
                return BadRequest(ex.Message);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT: api/Player/5
        public async Task<IHttpActionResult> Put(int id, [FromBody] Player player)
        {
            try
            {
                Player playerThatFitId = await DBContext.Players.FindAsync(id);
                if (playerThatFitId != null)
                {
                    playerThatFitId.Name = player.Name;
                    playerThatFitId.LastName = player.LastName;
                    playerThatFitId.Posstion = player.Posstion;
                    playerThatFitId.Age = player.Age;
                    await DBContext.SaveChangesAsync();
                    return Ok(playerThatFitId);
                }

                return NotFound();
            }
            catch (SqlException ex)
            {
                return BadRequest(ex.Message);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE: api/Player/5
        public async Task<IHttpActionResult> Delete(int id)
        {
            try
            {
                Player playerToDelete = await DBContext.Players.FindAsync(id);
                if (playerToDelete != null)
                {
                    DBContext.Players.Remove(playerToDelete);
                    await DBContext.SaveChangesAsync();
                    return Ok("DELETED");
                }
                return NotFound();

            }
            catch (SqlException ex)
            {
                return BadRequest(ex.Message);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
