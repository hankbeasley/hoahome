using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HOAHome.Models;
using System.Data.SqlClient;
using HOAHome.Code;

namespace HOAHome.Services
{
    public class GisService : IGisService
    {
        public Neighborhood[] GetIntersectingNeighborhoods(double latitude, double longitude)
        {
            List<Neighborhood> neighborhoods = new List<Neighborhood>();
            string sql = string.Format( @"
                    DECLARE @geog GEOGRAPHY
                    SET @geog = 'POINT({0} {1})'
                    select * from Neighborhood
                    where Geo.STIntersects(@geog)=1
                ", latitude, longitude);
            using(SqlConnection conn = new SqlConnection(Configuration.ConnectionString))
            using(SqlCommand cmd = new SqlCommand(sql, conn)){
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while(reader.Read()) {
                    var hood = new Neighborhood();
                    hood.Id = (Guid)reader["Id"];
                    hood.Name = (String)reader["Name"];
                    hood.KML = (String)reader["KML"];
                    hood.PrimaryContactId = (Guid) reader["PrimaryContactId"];
                    neighborhoods.Add(hood);
                }
            }
            return neighborhoods.ToArray();
        }
    }
}