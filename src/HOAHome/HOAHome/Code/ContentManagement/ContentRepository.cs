using System;
using HOAHome.Code.EntityFramework;
using HOAHome.Models;
using System.Linq;

namespace HOAHome.Code.ContentManagement
{
    public class ContentRepository
    {
        private Guid _neighborhoodId;
        private IPersistanceFramework _persistance;
        public ContentRepository(Guid neighborhoodId, IPersistanceFramework persistance)
        {
            _neighborhoodId = neighborhoodId;
            _persistance = persistance;
        }

        public string GetContent(ContentType contentType)
        {
            return this._persistance.CreateQueryContext<Content>().Where(
                c => c.ContentTypeId == contentType.Id && c.NeighborhoodId == this._neighborhoodId).Select(c=>c.Text).FirstOrDefault();
        }

        public void SetContent(Guid contentTypeId, string content)
        {
            var contentEntity = this._persistance.CreateQueryContext<Content>().Where(
                c => c.ContentTypeId == contentTypeId && c.NeighborhoodId == this._neighborhoodId).FirstOrDefault();
            if (contentEntity == null)
            {
                contentEntity= this._persistance.Create<Content>();
                contentEntity.NeighborhoodId = _neighborhoodId;
                contentEntity.ContentTypeId = contentTypeId;
            }
            contentEntity.Text = content;
        }
        public void SaveChanges()
        {
            this._persistance.SaveChanges();
        }
    }
}