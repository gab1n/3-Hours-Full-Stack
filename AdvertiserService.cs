using Sabio.Data;
using Sabio.Data.Providers;
using Sabio.Models.Domain;
using Sabio.Models.Requests;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace Sabio.Services
{
    public class AdvertiserService : IAdvertiserService
    {
        private IDataProvider _data;

        public AdvertiserService(IDataProvider dataProvider)
        {
            _data = dataProvider;
        }

        public List<Advertiser> GetAll()
        {
            List<Advertiser> list = null;
            string procName = "dbo.Advertisers_SelectAll";

            _data.ExecuteCmd(procName, inputParamMapper: null,

                singleRecordMapper: delegate (IDataReader reader, short set)
                {
                    Advertiser anAdvertiser = new Advertiser();
                    int startingIndex = 0;
                    anAdvertiser.Id = reader.GetSafeInt32(startingIndex++);
                    anAdvertiser.ShortTitle = reader.GetSafeString(startingIndex++);
                    anAdvertiser.Title = reader.GetSafeString(startingIndex++);
                    anAdvertiser.ShortDescription = reader.GetSafeString(startingIndex++);
                    anAdvertiser.Content = reader.GetSafeString(startingIndex++);
                    anAdvertiser.CreatedBy = reader.GetSafeInt32(startingIndex++);
                    anAdvertiser.Slug = reader.GetSafeString(startingIndex++);
                    anAdvertiser.EntityTypeId = reader.GetSafeInt32(startingIndex++);
                    anAdvertiser.StatusId = reader.GetSafeInt32(startingIndex++);
                    anAdvertiser.DateCreated = reader.GetSafeDateTime(startingIndex++);
                    anAdvertiser.DateModified = reader.GetSafeDateTime(startingIndex++);
                    anAdvertiser.MetaDataId = reader.GetSafeInt32(startingIndex++);

                    if (list == null)
                    {
                        list = new List<Advertiser>();
                    }
                    list.Add(anAdvertiser);
                });
            return list;

        }

        public Advertiser Get(int id)
        {
            string procName = "[dbo].[Advertisers_SelectById]";
            Advertiser anAdvertiser = null;

            _data.ExecuteCmd(procName,
                delegate (SqlParameterCollection parameterCollection)
                {
                    parameterCollection.AddWithValue("@Id", id);
                }, delegate (IDataReader reader, short set)
                {
                    anAdvertiser = new Advertiser();
                    int startingIndex = 0;
                    anAdvertiser.Id = reader.GetSafeInt32(startingIndex++);
                    anAdvertiser.ShortTitle = reader.GetSafeString(startingIndex++);
                    anAdvertiser.Title = reader.GetSafeString(startingIndex++);
                    anAdvertiser.ShortDescription = reader.GetSafeString(startingIndex++);
                    anAdvertiser.Content = reader.GetSafeString(startingIndex++);
                    anAdvertiser.CreatedBy = reader.GetSafeInt32(startingIndex++);
                    anAdvertiser.Slug = reader.GetSafeString(startingIndex++);
                    anAdvertiser.EntityTypeId = reader.GetSafeInt32(startingIndex++);
                    anAdvertiser.StatusId = reader.GetSafeInt32(startingIndex++);
                    anAdvertiser.DateCreated = reader.GetSafeDateTime(startingIndex++);
                    anAdvertiser.DateModified = reader.GetSafeDateTime(startingIndex++);
                    anAdvertiser.MetaDataId = reader.GetSafeInt32(startingIndex++);

                });
            return anAdvertiser;

        }

        public int Add(AdvertiserAddRequest model)
        {
            int id = 0;

            string procName = "[dbo].[Advertisers_Insert]";
            _data.ExecuteNonQuery(procName,
                inputParamMapper: delegate (SqlParameterCollection col)
                {
                    col.AddWithValue("@ShortTitle", model.ShortTitle);
                    col.AddWithValue("@Title", model.Title);
                    col.AddWithValue("@ShortDescription", model.ShortDescription);
                    col.AddWithValue("@Content", model.Content);
                    col.AddWithValue("@CreatedBy", model.CreatedBy);
                    col.AddWithValue("@Slug", model.Slug);
                    col.AddWithValue("@EntityTypeId", model.EntityTypeId);
                    col.AddWithValue("@StatusId", model.StatusId);
                    col.AddWithValue("@MetaDataId", model.MetaDataId);

                    SqlParameter idOut = new SqlParameter("@Id", SqlDbType.Int);
                    idOut.Direction = ParameterDirection.Output;

                    col.Add(idOut);

                }, returnParameters: delegate (SqlParameterCollection returnCollection)
                {
                    object oId = returnCollection["@Id"].Value;
                    int.TryParse(oId.ToString(), out id);
                });
            return id;
        }

        public void Update(AdvertiserUpdateRequest model)
        {
            string procName = "[dbo].[Advertisers_Update]";
            _data.ExecuteNonQuery(procName,
                inputParamMapper: delegate (SqlParameterCollection col)
                {
                    col.AddWithValue("@Id", model.Id);
                    col.AddWithValue("@ShortTitle", model.ShortTitle);
                    col.AddWithValue("@Title", model.Title);
                    col.AddWithValue("@ShortDescription", model.ShortDescription);
                    col.AddWithValue("@Content", model.Content);
                    col.AddWithValue("@CreatedBy", model.CreatedBy);
                    col.AddWithValue("@Slug", model.Slug);
                    col.AddWithValue("@EntityTypeId", model.EntityTypeId);
                    col.AddWithValue("@StatusId", model.StatusId);
                    col.AddWithValue("@MetaDataId", model.MetaDataId);

                });
        }

        public void Delete(int id)
        {
            string procName = "[dbo].[Advertisers_Delete]";
            _data.ExecuteNonQuery(procName,
                inputParamMapper: delegate (SqlParameterCollection col)
                {
                    col.AddWithValue("@Id", id);
                });
        }

    }
}
