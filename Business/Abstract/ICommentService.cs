﻿using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICommentService
    {
        List<Comment> GetAll(int productId);
        void Add(Comment comment);
    }
}
