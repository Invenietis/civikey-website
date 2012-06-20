using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CiviKey.Models;

namespace CiviKey.ViewModel
{
    public class NewsViewModel
    {
        tNew _model;

        public NewsViewModel( tNew model )
        {
            _model = model;
        }

        public string Title { get { return _model.Title; } }
        public string Content { get { return _model.Content; } }
        public int Id { get { return _model.Id; } }
        public DateTime CreationDate { get { return _model.CreationDate; } }
    }
}