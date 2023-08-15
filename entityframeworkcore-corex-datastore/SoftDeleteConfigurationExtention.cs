using CoreX.Domain;
using SoftDeleteServices.Configuration;

namespace EntityFrameworkCore.CoreX.Datastore
{
    public static class SoftDeleteConfigurationExtention
    {
        public static void AddSoftDeleteConfiguration(this CascadeSoftDeleteConfiguration<ISoftDelete> config)
        {
            config.GetSoftDeleteValue = entity => entity.Deleted;
            config.SetSoftDeleteValue = (entity, value) =>
            {
                entity.Deleted = value;
            };
        }
    }
}
