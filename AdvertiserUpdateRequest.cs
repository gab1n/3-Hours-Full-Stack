using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Sabio.Models.Requests
{
    public class AdvertiserUpdateRequest : AdvertiserAddRequest , IModelIdentifier
    {
        public int Id { get; set; }
    }
}
