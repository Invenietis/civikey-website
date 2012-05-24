using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CiviKey.Models;

namespace CiviKey.ViewModel
{
    public class VideoViewModel
    {
        tDemo _model;
        public VideoViewModel(CiviKeyEntities c, tDemo model)
        {
            _model = model;
        }
    }
}