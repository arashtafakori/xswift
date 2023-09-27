using XSwift.Base;

namespace XSwift.Domain
{
    public class PreventIfStartDateIsLaterThanEndDate<TEntity> :
        Validation
        where TEntity : BaseEntity<TEntity>
    {
        private DateTime _startDate;
        private DateTime _endDate;
        public PreventIfStartDateIsLaterThanEndDate(DateTime startDate, DateTime endDate)
        {
            _startDate = startDate;
            _endDate = endDate;
        }

        public override bool Resolve()
        {
            if(_startDate > _endDate) 
                return true;

            return false;
        }

        public override IIssue? GetIssue()
        {
            return new StartDateCanNotBeLaterThanEndDate(typeof(TEntity).Name);
        }
    }
}
