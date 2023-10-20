namespace Kakao.Core.Models
{
    public class MenuModel
    {
        public string Id { get; set; }

        public MenuModel DataGen(string id)
        {
            Id = id;

            return this;
        }
    }
}
