﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CiviKey.Models;

namespace CiviKey.ViewModel
{
    public class VideoViewModel
    {
        tVideo _model;
        public VideoViewModel( CiviKeyEntities c, tVideo model )
        {
            _model = model;
        }
    }
}