using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HOAHome.Code.EntityFramework;

namespace HOAHome.Code.Mvc
{
    public abstract class CustomController<T> : Controller, IPersistanceContainer where T : IEntity, new ()
    {
        protected IPersistanceFramework Persistance = new PersistanceFramework(new Models.COHHomeEntities());

        public virtual ActionResult Details(Guid id)
        {
            this.ViewData.Model = Persistance.Get<T>(id);
            return this.View();
        }
        public virtual ActionResult Create()
        {
            return View();
        }
        [AcceptVerbs(HttpVerbs.Post)]
        public virtual ActionResult Create([Bind(Exclude = "Id")] T entity)
        {
            this.Validate(ActionType.Create, entity);

            if (this.ModelState.IsValid)
            {
                this.Persistance.AttachNew(entity);
                this.Persistance.SaveChanges();
                return GetCompletionResult(ActionType.Create, entity);
            }
            else
            {
                this.ViewData.Model = entity;
                return View();
            }
        }

        protected virtual void Validate(ActionType actionType, T entity)
        {
            //Nothing by default
        }

        public virtual ActionResult Edit(Guid id)
        {
            var entity = Persistance.Get<T>(id);
            this.ViewData.Model = entity;
            return GetInitialResult(ActionType.Edit, entity);
        }

        protected virtual ActionResult GetInitialResult(ActionType type, T entity)
        {
            return this.View();
        }

        public virtual ActionResult Delete(Guid id)
        {
            Persistance.Delete<T>(id);
            Persistance.SaveChanges();
            return GetCompletionResult(ActionType.Delete, new T());
        }

        public virtual ActionResult List()
        {
            this.ViewData.Model = this.Persistance.CreateQueryContext<T>();
            return View();
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public virtual ActionResult Edit(T entity)
        {
            if (!this.ModelState.IsValid) {
                this.ViewData.Model = entity;
                return this.View();
            }
            this.Persistance.SaveChanges();
            this.ViewData.Model = Persistance.Get<T>(entity.Id);
            return GetCompletionResult(ActionType.Edit, entity);
        }
        protected virtual ActionResult GetCompletionResult(ActionType type, T entity) {
            if (type == ActionType.Delete)
            {
                //todo: need to redirect instead
                return this.RedirectToAction("List");
            } if (type == ActionType.Edit)
            {
                return this.RedirectToAction("Details", new { Id = entity.Id }); ;
            }
            if (type ==ActionType.Create) {
                return this.RedirectToAction("Details", new { Id = entity.Id });
            }
            return View();
        }

        protected enum ActionType{
            Edit,
            Create,
            Delete
        }

        public virtual ActionResult CreateChild(Guid parentId)
        {
            return View();
        }
        [AcceptVerbs(HttpVerbs.Post)]
        public virtual ActionResult CreateChild(Guid parentId,[Bind(Exclude="Id")] T entity)
        {
            this.Persistance.AttachNew(entity);
            AssociateParent(parentId, entity);
            AdditionalBindings(entity, ActionType.Create);
            this.Persistance.SaveChanges();
            return GetCompletionResult(ActionType.Create, entity);
        }
        object IPersistanceContainer.Load(Guid id)
        {
            return Persistance.Get<T>(id);
        }
        protected virtual void AssociateParent(Guid parentId, T entity){
            throw new NotImplementedException();
        }
        protected virtual void AdditionalBindings(T entity, ActionType type) { }
    }
}