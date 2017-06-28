namespace WebApiDemos.WebApiSvc
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Position
    {
        public int PositionID { get; set; }

        public DateTime ReportedAt { get; set; }

        public float? Latitude { get; set; }

        public float? Longitude { get; set; }

        public float DistanceFromLast { get; set; }

        public int CruiseID { get; set; }

        public int? PlaceID { get; set; }

        public int? TimeZoneID { get; set; }
    }
}
