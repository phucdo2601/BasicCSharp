using SalaryManagement.Infrastructure;
using SalaryManagement.Models;
using SalaryManagement.Requests;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SalaryManagement.Services.ConfigurationService
{
    public class ConfigurationService : IConfigurationService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ConfigurationService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public List<Configuration> GetConfigurations()
        {
            var configurations = _unitOfWork.Configuration.FindAll().ToList();
            return configurations;
        }

        public Configuration GetConfiguration(string configurationId)
        {
            var configuration = _unitOfWork.Configuration.Find(configurationId);
            return configuration;
        }

        public Configuration GetConfigurationByName(string name)
        {
            var configuration = _unitOfWork.Configuration.FindByCondition(e => e.Name.ToLower().Equals(name.ToLower())).FirstOrDefault();
            return configuration;
        }

        public int CreateConfiguration(string configurationId, ConfigurationRequest configurationRequest)
        {
            var configurationName = _unitOfWork.Configuration.FindByCondition(e => e.Name.ToLower().Equals(configurationRequest.Name.ToLower())).Select(e => e.Name).FirstOrDefault();
            if (configurationName != null) throw new Exception($"Name'{configurationName}' already exists");

            Configuration configuration = new()
            {
                ConfigurationId = configurationId,
                Name = configurationRequest.Name,
                Value = configurationRequest.Value
            };

            _unitOfWork.Configuration.Create(configuration);

            int created = _unitOfWork.Complete();

            return created;
        }

        public int UpdateConfiguration(string name, ConfigurationUpdateRequest configurationRequest)
        {
            int update = -1;

            var configuration = _unitOfWork.Configuration.FindByCondition(e => e.Name.ToLower().Equals(name.ToLower())).FirstOrDefault();

            if (configuration != null)
            {
                configuration.Value = configurationRequest.Value;

                _unitOfWork.Configuration.Update(configuration);

                update = _unitOfWork.Complete();
            }

            return update;
        }
    }
}
