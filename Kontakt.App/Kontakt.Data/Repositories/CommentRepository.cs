using Kontakt.App.Context;
using Kontakt.Core.Models;
using Kontakt.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kontakt.Data.Repositories
{
    public class CommentRepository : Repository<Comment>, ICommentRepository
    {
        public CommentRepository(KontaktDbContext context) : base(context)
        {
        }
    }
}
