﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

using ThesisManagementProject.Entity;
using ThesisManagementProject.Models;

namespace ThesisManagementProject.DAOs
{
    internal class CommentDAO
    {

        public CommentDAO() { }

        public List<Comment> SelectList(Tasks tasks)
        {
            using (var dbContext = new AppDbContext())
            {
                var list = dbContext.Comment.Where(c => c.IdTask == tasks.IdTask).ToList();
                return list;
            }
        }
        public void Insert(Comment comment)
        {
            using (var dbContext = new AppDbContext())
            {
                dbContext.Comment.Add(comment);
                dbContext.SaveChanges();
            }
        }
        public Comment SelectOnlyByID(string idComment)
        {
            using (var dbContext = new AppDbContext())
            {
                var comment = dbContext.Comment.FirstOrDefault(c => c.IdComment == idComment);
                if (comment != null)
                {
                    return comment;
                }
                else
                {
                    return new Comment();
                }
            }
        }
    }
}
