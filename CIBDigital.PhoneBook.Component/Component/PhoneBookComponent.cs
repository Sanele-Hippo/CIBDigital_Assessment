using CIBDigital.PhoneBook.Model;
using Dapper;
using NLog;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CIBDigital.PhoneBook.Component
{
    public class PhoneBookComponent :IPhoneBookComponent
    {
        private readonly ISqlRepository _sqlRepository;
        private readonly ILogger _logger = LogManager.GetCurrentClassLogger();

        public PhoneBookComponent(ISqlRepository sqlRepository)
        {
            _sqlRepository = sqlRepository;
        }

        public async Task<List<PhoneBookModel>> Get()
        {
            var response = new List<PhoneBookModel>();
            try
            {
                response = await _sqlRepository.Get<PhoneBookModel>("[CIBDigital].[dbo].[sp_GetPhoneBookEntries]").ConfigureAwait(false);
            }
            catch(Exception ex)
            {
                _logger.Error(ex);
            }

            return response;
         }

        public async Task<bool> Add(PhoneBookModel model)
        {
            var response = false;
            try
            {
                var param = new DynamicParameters();
                param.Add("@Initial", model.Name);
                param.Add("@Name", model.Name);
                param.Add("@PhoneNumber", model.PhoneNumber);
                await _sqlRepository.Insert(param, "[CIBDigital].[dbo].[sp_InsertPhoneBookEntry]").ConfigureAwait(false);
               response = true;
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
            }

            return response;
        }
    }
}
