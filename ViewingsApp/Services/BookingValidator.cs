using System.Linq;
using System.Collections.Generic;
using ViewingsApp.Models.Database;
using ViewingsApp.Models.Request;
using ViewingsApp.Models.ViewModel;

namespace ViewingsApp.Services
{
    public interface IBookingValidator
    {
        BookingValidation ValidateBooking(BookingRequest bookingRequest, IEnumerable<Agent> allAgents, IEnumerable<Property> allProperties);
    }
    
    public class BookingValidator : IBookingValidator
    {
        public BookingValidation ValidateBooking(BookingRequest bookingRequest, IEnumerable<Agent> allAgents, IEnumerable<Property> allProperties)
        {
            if(string.IsNullOrWhiteSpace(bookingRequest.Name))
            {
                return new BookingValidation
                {
                    IsValid = false, ErrorMessage = "You must provide a phonenumber"
                };
            }

            var agent = allAgents.First();
                if(!agent.IsFreeAt(bookingRequest.StartsAt))
                {
                    return new BookingValidation
                    {
                        IsValid = false, ErrorMessage = "Agent is not free at that time"
                    };
                }
            


            // if(string.IsNullOrWhiteSpace(bookingRequest.AgentId))
            // {
            //     return new BookingValidation
            //     {
            //         IsValid = false, ErrorMessage = "you must pick an agent"
            //     };
            // }

             if(string.IsNullOrWhiteSpace(bookingRequest.PhoneNumber))
            {
                return new BookingValidation
                {
                    IsValid = false, ErrorMessage = "You must provide a valid email address"
                };
            }

            if(bookingRequest.Name == "")
            {
                return new BookingValidation
                {
                    IsValid = false, ErrorMessage = "You must provide a name"
                };
            
            }
            return new BookingValidation
            {
                IsValid = true,
                ErrorMessage = ""

            };

            

     

        
        }
    }
}