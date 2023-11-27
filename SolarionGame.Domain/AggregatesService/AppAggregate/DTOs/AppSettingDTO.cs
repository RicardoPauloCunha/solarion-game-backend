namespace SolarionGame.Domain.AggregatesService.AppAggregate.DTOs
{
    public class AppSettingDTO
    {
        public string Id { get; set; }
        public string Version { get; set; }

        public AppSettingDTO(string id, string version)
        {
            Id = id;
            Version = version;
        }
    }
}
