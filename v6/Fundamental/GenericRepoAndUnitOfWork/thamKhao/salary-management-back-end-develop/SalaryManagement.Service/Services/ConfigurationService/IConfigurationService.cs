using SalaryManagement.Models;
using SalaryManagement.Requests;
using System.Collections.Generic;

namespace SalaryManagement.Services.ConfigurationService
{
    public interface IConfigurationService
    {
        List<Configuration> GetConfigurations();
        Configuration GetConfiguration(string configurationId);
        Configuration GetConfigurationByName(string name);
        int CreateConfiguration(string configurationId, ConfigurationRequest configurationRequest);
        int UpdateConfiguration(string name, ConfigurationUpdateRequest configurationRequest);
    }
}
