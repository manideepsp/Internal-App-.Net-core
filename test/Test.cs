using AutoMapper;
using BusinessModel;
using DataModel;

namespace Test
{
    public static class TestClass
    {
        public static void Checkmethod()
        {
            BusinessUser bobj = new BusinessUser
            {
                Username = "mani",
                Password = "password",
                ConfirmPassword = "password",
                Email = "email@dwa.cd",
                Mobile = "9999999999",
                //Phone = "phone"
            };

            IMapper mapper = AutoMapperConfig.Initialize();
            DataUser dobj = mapper.Map<DataUser>(bobj);

            Console.WriteLine($"\"B--->\"uname: {bobj.Username}, pwd: {bobj.Password}, Email: {bobj.Email}, Mobile: {bobj.Mobile}, cp: {bobj.ConfirmPassword}");
            Console.WriteLine($"\"D--->\"uname: {dobj.Username}, pwd: {dobj.Password}, Email: {dobj.Email}, Mobile: {dobj.Mobile}, ph: {dobj.Phone}");

            dobj.Username = "changed";

            BusinessUser bobj1 = mapper.Map<BusinessUser>(dobj);

            Console.WriteLine($"\"B--->\"uname: {bobj1.Username}, pwd: {bobj1.Password}, Email: {bobj1.Email}, Mobile: {bobj1.Mobile}, cp: {bobj1.ConfirmPassword}");
            Console.WriteLine($"\"D--->\"uname: {dobj.Username}, pwd: {dobj.Password}, Email: {dobj.Email}, Mobile: {dobj.Mobile}, ph: {dobj.Phone}");

            string s1 = "hai";
            string s2 = "hello";
            //DALConvertUser.ConvertObject(s1, s2);
            //Console.WriteLine($"s1: {s1}, s2: {s2}");

            int a = 10;
            int b = 20;
            //Utils.ConvertUser.ConvertObject(a, b);
        }
    }
    {
        //public static IMapper InitializeRev()
        //{
        //    var configrev = new MapperConfiguration(cfg =>
        //       cfg.CreateMap<DataUser, BusinessUser>()
        //   );
        //    var mapperrev = new Mapper(configrev);
        //    return mapperrev;
        //}
    }
}