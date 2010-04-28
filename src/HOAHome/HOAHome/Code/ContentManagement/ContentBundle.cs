using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HOAHome.Code.ContentManagement
{
    public class ContentBundle
    {
        private Dictionary<Guid, string> _content =new Dictionary<Guid, string>();
        public string GetContent(Guid id)
        {
            return this._content[id];
        }

        public Guid[] GetIds()
        {
            return this._content.Keys.ToArray();
        }
        public void Add(Guid id, string content)
        {
            this._content.Add(id, content);
        }
    }
}