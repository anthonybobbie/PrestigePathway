using Microsoft.AspNetCore.OData.Routing.Controllers;
using PrestigePathway.DataAccessLayer.Models;
using PrestigePathway.DataAccessLayer;

namespace PrestigePathway.Api.Controllers.OData
{
    public class BookingController : ODataBaseController<Booking>
    {
        public BookingController(SocialServicesDbContext context) : base(context) { }
    }

    public class ClientController : ODataBaseController<Client>
    {
        public ClientController(SocialServicesDbContext context) : base(context) { }
    }

    public class ServiceLocationController : ODataBaseController<ServiceLocation>
    {
        public ServiceLocationController(SocialServicesDbContext context) : base(context) { }
    }

    public class LocationController : ODataBaseController<Location>
    {
        public LocationController(SocialServicesDbContext context) : base(context) { }
    }

    public class ServiceController : ODataBaseController<Service>
    {
        public ServiceController(SocialServicesDbContext context) : base(context) { }
    }

    public class ServiceOptionController : ODataBaseController<ServiceOption>
    {
        public ServiceOptionController(SocialServicesDbContext context) : base(context) { }
    }

    public class ServicePartnerController : ODataBaseController<ServicePartner>
    {
        public ServicePartnerController(SocialServicesDbContext context) : base(context) { }
    }

    public class ServiceTypeController : ODataBaseController<ServiceType>
    {
        public ServiceTypeController(SocialServicesDbContext context) : base(context) { }
    }

    public class UserController : ODataBaseController<User>
    {
        public UserController(SocialServicesDbContext context) : base(context) { }
    }

    public class StaffAssistantController : ODataBaseController<StaffAssistant>
    {
        public StaffAssistantController(SocialServicesDbContext context) : base(context) { }
    }

    public class StaffController : ODataBaseController<Staff>
    {
        public StaffController(SocialServicesDbContext context) : base(context) { }
    }

    public class TestimonialController : ODataBaseController<Testimonial>
    {
        public TestimonialController(SocialServicesDbContext context) : base(context) { }
    }

    public class PromotionController : ODataBaseController<Promotion>
    {
        public PromotionController(SocialServicesDbContext context) : base(context) { }
    }

    public class PaymentController : ODataBaseController<Payment>
    {
        public PaymentController(SocialServicesDbContext context) : base(context) { }
    }

    public class PartnerController : ODataBaseController<Payment>
    {
        public PartnerController(SocialServicesDbContext context) : base(context) { }
    }







}
