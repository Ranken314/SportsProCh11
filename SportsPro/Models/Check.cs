namespace SportsPro.Models
{
    public class Check
    {
        public static string EmailExists(SportsProContext context, string email)
        {
            string msg = "";
            var customer = context.Customers.FirstOrDefault(
                c => c.Email.ToLower() == email.ToLower());
            if (customer != null)
            {
                msg = "Email address already in use";
            }
            return msg;
        }
    }
}
