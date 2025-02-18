using Microsoft.OData.Edm;
using Microsoft.OData.ModelBuilder;
using PrestigePathway.DataAccessLayer.Models;

namespace PrestigePathway.Api.Extensions
{
    public static class IEdmModelExtensions
    {
        public static  IEdmModel AddPrestigePathwayEdmModel(this ODataConventionModelBuilder modelBuilder)
        {
            modelBuilder.EntitySet<Client>("Client");
            modelBuilder.EntitySet<User>("User");
            modelBuilder.EntitySet<Location>("Location");
            modelBuilder.EntitySet<Booking>("Booking");
            modelBuilder.EntitySet<Staff>("Staff");
            modelBuilder.EntitySet<Partner>("Partner");

            modelBuilder.EntitySet<Service>("Service");
            modelBuilder.EntitySet<ServiceDetail>("ServiceDetail");
            modelBuilder.EntitySet<ServiceOption>("ServiceOption");
            modelBuilder.EntitySet<ServicePartner>("ServicePartner");
            modelBuilder.EntitySet<ServiceLocation>("ServiceLocation");
            modelBuilder.EntitySet<ServiceType>("ServiceType");


            modelBuilder.EntitySet<Payment>("Payment");
            modelBuilder.EntitySet<Promotion>("Promotion");
            modelBuilder.EntitySet<StaffAssistant>("StaffAssistant");
            modelBuilder.EntitySet<Staff>("Staff");
            modelBuilder.EntitySet<ServicePartner>("ServicePartner");

            modelBuilder.EntitySet<Testimonial>("Testimonial");

            return modelBuilder.GetEdmModel();
        }
        
    }
}
