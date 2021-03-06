﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HOAHome.Repositories;
using Moq;

namespace HOAHome.Tests.Helpers
{
    public class FakeRepositoryFactory : IRepositoryFactory
    {
        public FakeRepositoryFactory()
        {   
            MockNeighborhoodRepository = new Mock<INeighborhoodRepository>();
            this.Neighborhood = MockNeighborhoodRepository.Object;

            MockHomeRepository = new Mock<IHomeRepository>();
            this.Home = MockHomeRepository.Object;
        }
        public Mock<INeighborhoodRepository> MockNeighborhoodRepository;
        public INeighborhoodRepository Neighborhood
        {
            get; set;
        }
        public Mock<IHomeRepository> MockHomeRepository;
        public IHomeRepository Home
        {
            get;
            set;
        }


        public Code.ContentManagement.IContentRepository ContentRepository(Guid nhid)
        {
            throw new NotImplementedException();
        }
    }
}
