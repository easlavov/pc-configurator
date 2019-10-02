namespace PCConfigurator.Application.Configurations
{
    using PCConfigurator.Application.Components;

    public class ConfigurationWriteModel
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public ComponentViewModel[] Components { get; set; }
    }
}
