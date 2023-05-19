using System;
using System.Threading.Tasks;
using Refactoring.Web.DomainModels;

namespace Refactoring.Web.Services
{
    public interface IOrderService
    {
    }

    public class OrderService
    {
        private readonly Order _order;

        public OrderService(Order order)
        {
            _order = order;
            _order.Id = Guid.NewGuid().ToString();
            _order.CreatedOn = DateTime.Now;
            _order.UpdatedOn = DateTime.Now;
        }

        public async Task ProcessOrder()
        {
            if (_order.District.ToLower() == "downtown" && (DateTime.Now.DayOfWeek == DayOfWeek.Saturday ||
                                                            DateTime.Now.DayOfWeek == DayOfWeek.Sunday))
            {
                PrintAdvert(null, true);
            }

            var advert = await CreateAdvert(_order.District.ToLower());
            _order.Advert = advert;
            _order.Status = "Complete";

            PrintAdvert(advert, false);
        }


        private async Task<Advert> CreateAdvert(string district)
        {
            var advert = new Advert();
            advert.CreatedOn = DateTime.Now;
            if (district == "cambridge")
            {
                advert.Heading = "Cambridge Bakery";
                advert.Content = "Custom Birthday and Wedding Cakes";
                if (DateTime.Now.DayOfWeek == DayOfWeek.Tuesday)
                {
                    var result = await ChamberOfCommerceApi.GetFor("Middleton");
                    advert.ImageUrl = result.ThumbnailUrl;
                }
            }
            else if (district == "middleton")
            {
                var svc = new DealService();
                var deal = svc.GenerateDeal(DateTime.Now);
                var biz = svc.GetRandomLocalBusiness();
                advert.Heading = "Middleton " + biz;
                advert.Content = "Get " + deal * 100 + "Percent off your next purchase!";
                var result = await ChamberOfCommerceApi.GetFor("Middleton");
                advert.ImageUrl = result.ThumbnailUrl;

            }
            else if (district == "county")
            {
                advert.Heading = "County Diner";
                advert.Content = "Kids eat free every Thursday night";

            }
            else if (district == "downtown")
            {
                advert.Heading = "Downtown Coffee Roasters";
                advert.Content = "Get a free coffee drink when you buy 1lb of coffee beans";
            }
            
            return advert;
        }

        private void PrintAdvert(Advert advert, bool IsDefaultAdvert)
        {
            if (IsDefaultAdvert)
            {
                Console.WriteLine("Printing Default Advert");
            }
            else
            {
                Console.WriteLine("Printing Custom Advert: " + advert.Heading);
            }

            System.Threading.Thread.Sleep(3000);
        }

        public Order GetOrder()
        {
            return _order;
        }
    }
}
