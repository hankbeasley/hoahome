using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HOAHome.Code.EntityFramework;
using HOAHome.Code.Rules;
using HOAHome.Repositories;

namespace HOAHome.Code.Mvc
{
    public abstract class RepositoryController<T, TE> : Controller, IPersistanceContainer
        where T : HOAHome.Repositories.IRepositoryBase<TE>
        where TE : IEntity
    {
        protected T Repository { get; private set; }
        //public RepositoryController()
        //{
        //}


        public RepositoryController(T repository)
        {
            this.Repository = repository;
        }

        public virtual ActionResult Create()
        {
            return View();
        }
        public virtual ActionResult Edit(Guid id)
        {
            this.ViewData.Model = this.Repository.Get(id);
            return this.View("Create");
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public virtual ActionResult Edit(TE entity)
        {
            if (entity is IEntityWithRules<TE>)
            {
                ((IEntityWithRules<TE>)entity).Rules.AddErrorsToModelState(this.ModelState, this.Repository);
            }
            if (!this.ModelState.IsValid)
            {
                this.ViewData.Model = entity;
                return this.View("Create");
            }
            this.Repository.SaveChanges();
           
            return this.RedirectToAction("Details", new { entity.Id });
        }

        public virtual ActionResult Details(Guid id)
        {
            this.ViewData.Model = Repository.Get(id);
            return this.View();
        }

        public virtual ActionResult List()
        {
            this.ViewData.Model = this.Repository.GetAll();
            return View();
        }


        object IPersistanceContainer.Load(Guid id)
        {
            return this.Repository.Get(id);
        }
    }
}