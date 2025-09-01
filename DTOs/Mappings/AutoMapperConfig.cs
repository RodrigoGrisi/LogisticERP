using LogisticERP.DTOs.Mappings;

namespace Application.Mappings
{
    public static class AutoMapperConfig
    {
        public static IServiceCollection AddMappings(this IServiceCollection services)
        {
            services.AddAutoMapper(cfg =>
            {
                cfg.AddProfile<MotoristaDTOMappingProfile>();
            });

            return services;
        }
    }
}
