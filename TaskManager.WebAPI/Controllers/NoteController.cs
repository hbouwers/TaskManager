using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TaskManager.Models.Note;
using TaskManager.Services;

namespace TaskManager.WebAPI.Controllers
{
    [Authorize]
    public class NoteController : ApiController
    {
    /// <summary>
    /// Get All Notes
    /// </summary>
    /// <returns></returns>
        public IHttpActionResult Get()
        {
            NoteService noteService = CreateNoteService();
            var notes = noteService.GetNotes();
            return Ok(notes);
        }
        /// <summary>
        /// Create a Note
        /// </summary>
        /// <param name="note"></param>
        /// <returns></returns>
        public IHttpActionResult Post(NoteCreate note)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var service = CreateNoteService();
            if (!service.CreateNote(note))
                return InternalServerError();
            return Ok();
        }
        /// <summary>
        /// Get Note by NoteId
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IHttpActionResult Get(int id)
        {
            NoteService noteService = CreateNoteService();
            var note = noteService.GetNoteById(id);
            return Ok(note);
        }
        /// <summary>
        /// Update a Note
        /// </summary>
        /// <param name="note"></param>
        /// <returns></returns>
        public IHttpActionResult Put(NoteEdit note)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var service = CreateNoteService();
            if (!service.UpdateNote(note))
            {
                return InternalServerError();
            }

            return Ok();
        }
        /// <summary>
        /// Delete a Note by NoteId
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IHttpActionResult Delete(int id)
        {
            var service = CreateNoteService();
            if (!service.DeleteNote(id))
            {
                return InternalServerError();
            }
            return Ok();
        }

        private NoteService CreateNoteService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var noteService = new NoteService(userId);
            return noteService;
        }
    }
}