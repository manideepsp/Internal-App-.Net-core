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

            string s1 = "hai";
            string s2 = "hello";
            //DALConvertUser.ConvertObject(s1, s2);
            //Console.WriteLine($"s1: {s1}, s2: {s2}");

            int a = 10;
            int b = 20;
            //Utils.ConvertUser.ConvertObject(a, b);
        }
    }
    public class AutoMapperConfig
    {
        public static IMapper Initialize()
        {
            var config = new MapperConfiguration(cfg =>
                cfg.CreateMap<BusinessUser, DataUser>()
            );
            var mapper = new Mapper(config);
            return mapper;
        }
    }
}