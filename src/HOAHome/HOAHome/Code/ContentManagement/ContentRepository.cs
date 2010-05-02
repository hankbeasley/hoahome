using System;
using System.Diagnostics.Contracts;
using HOAHome.Code.EntityFramework;
using HOAHome.Models;
using System.Linq;

namespace HOAHome.Code.ContentManagement
{
    public class ContentRepository : IContentRepository
    {
        private readonly Guid _neighborhoodId;
        private readonly IPersistanceFramework _persistance;
        public ContentRepository(Guid neighborhoodId, IPersistanceFramework persistance)
        {
            Contract.Requires(persistance != null);
            _neighborhoodId = neighborhoodId;
            _persistance = persistance;
        }

        public string GetContent(ContentType contentType)
        {
            var content = this._persistance.CreateQueryContext<Content>().Where(
                c => c.ContentTypeId == contentType.Id && c.NeighborhoodId == this._neighborhoodId).Select(c=>c.Text).FirstOrDefault();
            if (content == null)
            {
                content = contentType.Name;
            }
            return content;
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