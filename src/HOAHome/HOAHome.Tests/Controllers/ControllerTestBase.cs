using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HOAHome.Code.EntityFramework;
using HOAHome.Controllers;
using HOAHome.Code.Mvc;

namespace HOAHome.Tests.Controllers
{
    public class ControllerTestBase<T, Q>
        where T : CustomController<Q>, new()
        where Q : class,IEntity, new()
    {
        private T controller = new T();

        protected Moq.Mock<IPersistanceFramework> GetPersistanceMock()
        {
            var mock = new Moq.Mock<IPersistanceFramework>();
            CustomController_Accessor<Q>.AttachShadow(controller).Persistance = mock.Object;
            return mock;

        }

        protected T Controller
        {
            get
            {
                return this.controller;
            }
        }
    }
}
