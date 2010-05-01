using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Web;
using HOAHome.Models;
using System.ServiceModel;
using System.ServiceModel.Web;

namespace HOAHome.Services
{
   [ContractClass(typeof(IHoaServiceContract))]
    [ServiceContract]
    public interface IHoaService
    {
      
        [OperationContract]
        [WebInvoke( Method="GET",
            BodyStyle = WebMessageBodyStyle.WrappedRequest,
                ResponseFormat = WebMessageFormat.Json
                ,
                UriTemplate = "GetNeighborhoods/{latitude}/{longitude}"
                )]
        Neighborhood[] GetNeighborhoods(string latitude, string longitude);


        //[OperationContract]
        //[WebGet(
        //    BodyStyle = WebMessageBodyStyle.WrappedRequest,
        //        ResponseFormat = WebMessageFormat.Json
        //        , 
        //        UriTemplate = "Stuff"
        //        )]
        //string Stuff();
    }
    [ContractClassFor(typeof(IHoaService))]
    sealed class IHoaServiceContract : IHoaService
    {
        public Neighborhood[] GetNeighborhoods(string latitude, string longitude)
        {
            Contract.Requires(longitude != null && latitude != null, "Longitude and latitude can not be null");
            Contract.Ensures(Contract.Result<Neighborhood[]>() != null);
            return default(Neighborhood[]);
        }
    }
}