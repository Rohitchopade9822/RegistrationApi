using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RegistrationApi.DBModel;
using RegistrationApi.Services;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

public class EnquiryRepository : IEnquiry
{
    private readonly MyAppDbContext _appDbContext;

    public EnquiryRepository(MyAppDbContext myAppDbContext)
    {
        _appDbContext= myAppDbContext;
    }

    public IEnumerable<Enquiry> GetAllEnquiry()
    {
        return _appDbContext.Enquiry.ToList();
    }

    public void AddEnquiry(Enquiry enquiry)
    {
       enquiry.EnquiryId= GetNextequiryId();
        _appDbContext.Enquiry.Add(enquiry);
    }

    public void DeleteEnquiry(int EnquiryId)
    {
        var equery= _appDbContext.Enquiry.Find(EnquiryId);

        if(equery != null)
        {
            _appDbContext.Enquiry.Remove(equery);

            _appDbContext.SaveChanges();
        }

    }

    public Enquiry GetEnquiryById(int id)
    {
       return _appDbContext.Enquiry.Find(id);
    }

    public void SaveChanges()
    {
        _appDbContext.SaveChanges();
    }

    public void UpdateEnquiry(Enquiry enquiry)
    {
        _appDbContext.Enquiry.Update(enquiry);
        _appDbContext.SaveChanges();    
    }

    private int GetNextequiryId()
    {
        var _MaxEnquiryId = _appDbContext.Enquiry.Max(m => (int?)m.EnquiryId) ?? 0;

        return _MaxEnquiryId + 1;
    }

    
}
