using AutoMapper;
using BusinessModel;
using DataModel;

namespace DataLayer
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
            DataUser dobj = new DataUser();

            DALConvertUser.ConvertObject(bobj, dobj);
            Console.WriteLine($"\"B--->\"uname: {bobj.Username}, pwd: {bobj.Password}, Email: {bobj.Email}, Mobile: {bobj.Mobile}, cp: {bobj.ConfirmPassword}");
            Console.WriteLine($"\"D--->\"uname: {dobj.Username}, pwd: {dobj.Password}, Email: {dobj.Email}, Mobile: {dobj.Mobile}, ph: {dobj.Phone}");

            dobj.Username = "newMani";
            dobj.Password = "newPassword";
            dobj.Email = "newEmail";
            dobj.Mobile = "newMobile";
            dobj.Phone = "phone";

            IMapper mapper = AutoMapperConfig.Initialize();
            DataUser dobj1 = mapper.Map<DataUser>(bobj);

            Console.WriteLine($"\"B--->\"uname: {bobj.Username}, pwd: {bobj.Password}, Email: {bobj.Email}, Mobile: {bobj.Mobile}, cp: {bobj.ConfirmPassword}");
            Console.WriteLine($"\"D--->\"uname: {dobj1.Username}, pwd: {dobj1.Password}, Email: {dobj1.Email}, Mobile: {dobj1.Mobile}, ph: {dobj1.Phone}");

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
            {
                cfg.CreateMap<DataUser, BusinessUser>()
                    .ForMember(dest => dest.Username, opt => opt.MapFrom(src => src.Username))
                    .ForMember(dest => dest.Password, opt => opt.MapFrom(src => src.Password))
                    .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
                    .ForMember(dest => dest.Mobile, opt => opt.MapFrom(src => src.Mobile));
            });

            return config.CreateMapper();
        }
    }
}