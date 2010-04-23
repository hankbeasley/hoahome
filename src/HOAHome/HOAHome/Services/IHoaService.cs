using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HOAHome.Models;
using System.ServiceModel;
using System.ServiceModel.Web;

namespace HOAHome.Services
{
   
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
}