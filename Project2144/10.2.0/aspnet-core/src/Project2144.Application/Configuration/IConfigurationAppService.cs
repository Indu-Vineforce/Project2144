using Project2144.Configuration.Dto;
using System.Threading.Tasks;

namespace Project2144.Configuration;

public interface IConfigurationAppService
{
    Task ChangeUiTheme(ChangeUiThemeInput input);
}
