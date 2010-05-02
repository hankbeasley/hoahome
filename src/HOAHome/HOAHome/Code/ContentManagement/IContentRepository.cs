using System;
using HOAHome.Models;

namespace HOAHome.Code.ContentManagement
{
    public interface IContentRepository
    {
        string GetContent(ContentType contentType);
        void SetContent(Guid contentTypeId, string content);
        void SaveChanges();
    }
}