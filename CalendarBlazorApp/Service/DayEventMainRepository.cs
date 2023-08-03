using CalendarBlazorApp.Data;

namespace CalendarBlazorApp.Service
{
    public class DayEventMainRepository
    {
        private readonly DayEventDbContext _dbContext;

        public DayEventMainRepository()
        {
            _dbContext = new DayEventDbContext();
        }

        public DayEvent SaveOrUpdate(DayEvent model)
        {
            if (model.DayEventID > 0)
            {
                Update(model);
            }
            else
            {
                Create(model);
            }
            return model;
        }

        private int Create(DayEvent model)
        {
            _dbContext.Add(model);
            _dbContext.SaveChanges();
            return model.DayEventID;

        }

        private int Update(DayEvent model)
        {
            var ExistingEvent = _dbContext.DayEvent.Find(model.DayEventID);
            if (ExistingEvent != null)
            {
                ExistingEvent.Note = model.Note;
                ExistingEvent.FromDate = model.FromDate;
                ExistingEvent.ToDate = model.ToDate;
                _dbContext.SaveChanges();
            }
            return model.DayEventID;

        }
        public bool Delete(DayEvent model)
        {
            var existingEvent = _dbContext.DayEvent.Find(model.DayEventID);
            if (existingEvent != null)
            {
                _dbContext.Remove(existingEvent);
            }
            return true;
        }

        public IQueryable<DayEvent> GetDayEvent(DateTime eventDate)
        { 
            return _dbContext.Set<DayEvent>().Where(x => x.FromDate == eventDate);
        }

        public IQueryable<DayEvent> GetAllEvents(DateTime fromDate, DateTime toDate)
        {
            return _dbContext.Set<DayEvent>().Where(x => x.FromDate == fromDate && x.ToDate == toDate);
        }
        public DayEvent GetEvent(DateTime eventDate)
        {
            var result = _dbContext.DayEvent.Find(eventDate);
            return result;
        }
    }
}
