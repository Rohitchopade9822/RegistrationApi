using RegistrationApi.DBModel;

namespace RegistrationApi.Services
{
    public interface IFeedback
    {
        IEnumerable<Feedback> GetFeedbacks();

        void AddFeedback(Feedback feedback);

        void SaveChanges();

        void UpdateFeedback(Feedback feedback);

        void DeleteFeedback(int FeedbackId);

        int GetNextMaterialId();

        Feedback GetFeedbackById(int id);

    }
}
    