using CoreX.Base;

namespace CoreX.Domain
{
    public class PreventIfStartDateIsLaterThanEndDate<TEntity> :
        IValidation
        where TEntity : BaseEntity
    {
        private DateTime _startDate;
        private DateTime _endDate;
        public PreventIfStartDateIsLaterThanEndDate(DateTime startDate, DateTime endDate)
        {
            _startDate = startDate;
            _endDate = endDate;
        }

        public bool Check()
        {
            if(_startDate > _endDate) 
                return true;

            return false;
        }

        public IIssue? GetIssue()
        {
            return new StartDateCanNotBeLaterThanEndDate(typeof(TEntity).Name);
        }
    }
}
