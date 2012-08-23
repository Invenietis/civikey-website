using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CiviKey.Models;
using CiviKey.Repositories;

namespace CiviKey.ViewModel
{
    public class ReleaseNoteViewModel
    {
        public RoadmapViewModel LinkedRoadmap { get; private set; }
        public DateTime ReleaseDate { get; private set; }
        public string HtmlContent { get; private set; }
        public string Version { get; private set; }
        public int Id { get; private set; }

        public ReleaseNoteViewModel( tReleaseNote model, PartnerRepository partnerRepo, ContactRepository contactRepo, ContactRelationRepository contactRelationRepo )
        {
            Id = model.Id;
            LinkedRoadmap = new RoadmapViewModel( model.tRoadMap, partnerRepo, contactRepo, contactRelationRepo );
            HtmlContent = model.HtmlContent;
            ReleaseDate = model.ReleaseDate;
            Version = model.Version;
        }
    }
}
