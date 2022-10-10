

using SecondHandCarBidProject.AdminUI.DTO.CarDetailDtos;

namespace SecondHandCarBidProject.AdminUI.DTO
{
    public class FlyPageFactory
    {
        public enum PageSelectTable
        {
            Bid,
            Car,
        }
        public object CreatePage(PageSelectTable SelectTable)
        {
            IFlyPage flypage;
            switch (SelectTable)
            {
                case PageSelectTable.Bid:
                    flypage = new Test1DAL();
                    break;
                case PageSelectTable.Car:
                    flypage = new Test2DAL();
                    break;
                default:
                    flypage = new Test1DAL();
                    break;
            }
            flypage.Set();
            return flypage.Get();

        }
    }
    public class Test1DAL : IFlyPage
    {
        public CarPropertyDTO ListTestClass2 { get; set; }
        public Test1DAL()
        {
            ListTestClass2 = new CarPropertyDTO();
            //ListTestClass2.ClassList = new List<ListTest>();
            //ListTestClass2.SimpleList = new List<string>();

        }
        object IFlyPage.Get()
        {
            return ListTestClass2;
        }

        void IFlyPage.Set()
        {
            ListTestClass2 = new CarPropertyDTO()
            {
                CarId = Guid.NewGuid(),
                CarPropertyValueId = 1,
                CarPropertyValues = null,
                Cars = null,
                CreatedBy = 1,
                ModifiedBy = 1,
                IsActive = true,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now,
            };
        }
    }
    public class Test2DAL : IFlyPage
    {
        public CarPropertyValueDTO ListTestClass2 { get; set; }
        public Test2DAL()
        {
            ListTestClass2 = new CarPropertyValueDTO();
            //ListTestClass2.ClassList = new List<ListTest>();
            //ListTestClass2.SimpleList = new List<string>();

        }
        object IFlyPage.Get()
        {
            return ListTestClass2;
        }

        void IFlyPage.Set()
        {
            ListTestClass2 = new CarPropertyValueDTO()
            {
                Id = Guid.NewGuid(),
                IsActive = false,
                PropertValue = "Dizel",
                TopPropertyValueId = Guid.NewGuid()
            };
        }
    }
}
