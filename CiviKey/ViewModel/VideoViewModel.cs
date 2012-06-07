using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CiviKey.Models;

namespace CiviKey.ViewModel
{
    public class VideoViewModel
    {
        tVideo _model;
        public VideoViewModel( tVideo model )
        {
            _model = model;
        }

        public int id { get { return _model.Id; } }
        public string Name { get { return _model.Name; } }
        public string VideoSource { get { return _model.VideoSource; } }
        public System.DateTime CreationDate { get { return _model.CreationDate; } }
    }
}