using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Data;
using TaskManager.Models.Note;

namespace TaskManager.Services
{
    public class NoteService
    {
        private readonly Guid _userId;

        public NoteService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateNote(NoteCreate model)
        {
            var entity =
                new Note()
                {
                    UserId = _userId,
                    NoteId = model.ActivityId,
                    Text = model.Text,
                    CreatedUtc = DateTimeOffset.Now,
                    TodoId = model.TodoId
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Notes.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<NoteListItem> GetNotes()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Notes
                    .Where(e => e.UserId == _userId)
                    .Select(
                        e =>
                        new NoteListItem
                        {
                            NoteId = e.NoteId,
                            Text = e.Text,
                        }
                        );
                return query.ToArray();
            }
        }

        public NoteDetail GetNoteById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Notes
                    .Where(e => e.UserId == _userId)
                    .Single(e => e.NoteId == id);
                return
                    new NoteDetail
                    {
                        NoteId = entity.NoteId,
                        Text = entity.Text,
                        CreatedUtc = entity.CreatedUtc,
                    };
            }
        }

        public bool UpdateNote(NoteEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Notes
                    .Single(e => e.NoteId == model.NoteId);

                entity.Text = model.Text;
                //entity.ActivityId = model.ActivityId;
                entity.TodoId = model.TodoId;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteNote(int noteId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Notes
                    .Single(e => e.NoteId == noteId);
                ctx.Notes.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}
