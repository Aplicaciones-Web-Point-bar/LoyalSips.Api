namespace LoyalSips.Api.LoyalSips.Domain.Models;

public class Point
{
        //Quien recibe los puntos 
        //public User Id { get; set; }
        public int Id { get; set;}
        public int Total { get; set; }
        public int Sale { get; set; }
        public string Description { get; set; }
        public int OwnerId { get; set; }

        //Quien da los puntos 
        //public Bar Id { get; set; }
}