using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CiviKey.Models;

namespace CiviKey.ViewModel
{
    public class CategoryViewModel
    {
        tCategory _model;

        public CategoryViewModel(tCategory model)
        {
            _model = model;
        }

        public string Name { get { return _model.Name; } }
    }
}