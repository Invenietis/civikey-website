using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CiviKey.Models;

namespace CiviKey.ViewModel
{
    public class CategoryViewModel : IEquatable<CategoryViewModel>
    {
        tCategory _model;

        public CategoryViewModel(tCategory model)
        {
            _model = model;
        }

        public int Id { get { return _model.Id; } }
        public string Name { get { return _model.Name; } }
        public string IconName { get { return _model.IconName; } }

        public override int GetHashCode()
        {
            return this.Name.GetHashCode();
        }

        public bool Equals(CategoryViewModel other)
        {
            return other.Name.Equals(this.Name);
        }
    }
}