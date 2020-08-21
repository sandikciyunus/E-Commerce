using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CommentService : ICommentService
    {
        private ICommentDal _commentDal;
        public CommentService(ICommentDal commentDal)
        {
            _commentDal = commentDal;
        }
        public void Add(Comment comment)
        {
            _commentDal.Add(comment);
        }

        public List<Comment> GetAll(int productId)
        {
            return _commentDal.GetList(p=>p.ProductId==productId);
        }
    }
}
