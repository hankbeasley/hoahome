using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Web;

namespace HOAHome.Code.ContentManagement
{
    public class ContentBundle
    {
        private readonly Dictionary<Guid, string> _content =new Dictionary<Guid, string>();
        public string GetContent(Guid id)
        {
            return this._content[id];
        }

        public Guid[] GetIds()
        {
            Contract.Ensures(Contract.Result<Guid[]>() != null);
            return this._content.Keys.ToArray();
        }
        public void Add(Guid id, string content)
        {
            this._content.Add(id, content);
        }
    }
}