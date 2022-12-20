using SoftDeleteServices.Configuration;

namespace CoreX.Structure
{
    public static class CascadeSoftDeleteConfigurationExtention
    {
        public static void AddSoftDeleteConfiguration(this CascadeSoftDeleteConfiguration<ICascadeSoftDelete> config)
        {
            config.GetSoftDeleteValue = entity => entity.SoftDeleteLevel;
            config.SetSoftDeleteValue = (entity, value) =>
            {
                entity.SoftDeleteLevel = value;
                entity.DeletationDate = DateTimeUtils.Now;
            };
        }
    }
}
