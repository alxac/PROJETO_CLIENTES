using AutoMapper;

namespace CrossCutting.Mappings
{
    public class ConfigureIMapper
    {
        public static IMapper GetMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new DtOToModelProfile());
            });

            return config.CreateMapper();
        }

        public class AutoMapperFixture : ConfigureIMapper, IDisposable
        {
            public void Dispose() { }
        }
    }
}
