using FluentValidation;
using PrestigePathway.Data.Models.ServiceDetail;
using PrestigePathway.DataAccessLayer.Models;

namespace PrestigePathway.Data.Abstractions;

public interface IServiceDetailService : IService<ServiceDetail, ServiceDetailResponse>
{
    //Booking specific-methods
}