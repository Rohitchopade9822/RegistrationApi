using Microsoft.AspNetCore.Mvc;
using RegistrationApi.DBModel;
using RegistrationApi.Services;
using System.Net.WebSockets;

namespace RegistrationApi.Repository
{
    public class FeedbackRepository: IFeedback
    {
        private readonly MyAppDbContext _context;
        
        public FeedbackRepository(MyAppDbContext context)
        {
            _context = context;

        }

        public void AddFeedback(Feedback feedback)
        {
            feedback.FeedbackId = GetNextMaterialId();
            _context.Feedbacks.Add(feedback);
            _context.SaveChanges();
        }

        public void DeleteFeedback(int FeedbackId)
        {
            var id = _context.Feedbacks.Find(FeedbackId);
            if (id != null)
            {
                _context.Feedbacks.Remove(id);
                _context.SaveChanges();
            }

        }

        public Feedback GetFeedbackById(int id)
        {
            return _context.Feedbacks.Find(id);
        }

        public IEnumerable<Feedback> GetFeedbacks()
        {
            return _context.Feedbacks.ToList();
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public void UpdateFeedback(Feedback feedback)
        {
           _context.Feedbacks.Add(feedback);   
            _context.SaveChanges();
        }
    

        public int GetNextMaterialId()
        {

            var maxFeedbackId = _context.Feedbacks.Max(m => (int?)m.FeedbackId) ?? 0;
            return maxFeedbackId + 1;
        }

       
    }
}
