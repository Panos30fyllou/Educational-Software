using IES.Interfaces;

namespace IES.WebHost
{
    public class DbConfig : IDbConfig
    {
        public string ConnectionString { get; set; }
    }
}
