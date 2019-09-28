using System.Collections.Generic;
using Sabio.Models.Domain;
using Sabio.Models.Requests;

namespace Sabio.Services
{
    public interface IAdvertiserService
    {
        List<Advertiser> GetAll();

        Advertiser Get(int id);

        int Add(AdvertiserAddRequest model);

        void Update(AdvertiserUpdateRequest model);

        void Delete(int id);
    }
}