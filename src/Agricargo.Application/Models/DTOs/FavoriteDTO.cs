using Agricargo.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agricargo.Application.Models.DTOs
{
    public class FavoriteDTO
    {
        public int? Id { get; set; }

        public int? TripId { get; set; }

        public TripDTO? Trip { get; set; }
    }
}
