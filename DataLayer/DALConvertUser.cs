using System.Reflection;
using AutoMapper;

namespace DataLayer
{
    public static class DALConvertUser
    {
        /// <summary>
        /// Generic Method that Converts BusinessModel object to DataModel object and viceversa
        ///  //ref: https://www.geeksforgeeks.org/c-sharp-type-getproperties-method/
        ///  //ref: https://learn.microsoft.com/en-us/dotnet/api/system.type?view=net-7.0
        /// </summary>
        /// <typeparam name="TArg1"></typeparam>
        /// <typeparam name="TArg2"></typeparam>
        /// <param name="arg1"></param>
        /// <returns></returns>
        public static TArg2 ConvertObject<TArg1, TArg2>(TArg1? arg1, TArg2? arg2)
            where TArg1 : new()
            where TArg2 : new()
        {
            if (arg1 == null || arg2 == null)
            {
                return arg2;
            }
            else
            {
                PropertyInfo[] arg1Props = typeof(TArg1).GetProperties();
                PropertyInfo[] arg2Props = typeof(TArg2).GetProperties();

                foreach (var arg1Prop in arg1Props)
                {
                    var matchingArg2Props = arg2Props.FirstOrDefault(prop => prop.Name == arg1Prop.Name);
                    if (matchingArg2Props != null)
                    {
                        var bValue = arg1Prop.GetValue(arg1);
                        matchingArg2Props.SetValue(arg2, bValue);
                    }
                }
            }
            return arg2;
        }

        //public class AutoMapperConfig
        //{
        //    public static IMapper Initialize()
        //    {
        //        var config = new MapperConfiguration(cfg =>
        //        {
        //            cfg.CreateMap<SourceObject, DestinationObject>()
        //                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
        //                .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => $"{src.Name} ({src.Age} years old)"));
        //        });

        //        return config.CreateMapper();
        //    }
        //}

        //IMapper mapper = AutoMapperConfig.Initialize();

        //SourceObject sourceObject = new SourceObject
        //{
        //    Id = 1,
        //    Name = "John Doe",
        //    Age = 30
        //};

        //DestinationObject destinationObject = mapper.Map<DestinationObject>(sourceObject);

        #region "different logics for generic method"

        ///
        /// approach i tried to use
        /// 
        //typeof(dto).Username = typeof(TDTO).GetProperty("Username").GetValue(typeof(TDTO), null);

        /// Primary approach as Perform mapping logic
        /// primary approach to perform logic
        /// Here, you can manually map the properties from BO to DTO or use a library like AutoMapper
        //PropertyInfo[] boProperties = typeof(TBO).GetProperties();
        //PropertyInfo[] dtoProperties = typeof(TDTO).GetProperties();
        //foreach (var boProp in boProperties)
        //{
        //    var matchingDtoProp = dtoProperties.FirstOrDefault(p => p.Name == boProp.Name);
        //    if (matchingDtoProp != null)
        //    {
        //        var boValue = boProp.GetValue(bo);
        //        matchingDtoProp.SetValue(dto, boValue);
        //    }
        //}

        ///
        ///Another Approach
        ///
        //if (bo is null || dto is null)
        //    return dto;

        //if (bo is BusinessObjectA && dto is DataObjectA)
        //{
        //    var boA = bo as BusinessObjectA;
        //    var dtoA = dto as DataObjectA;

        //    dtoA.PropertyA = boA.PropertyA;
        //    dtoA.PropertyB = boA.PropertyB;
        //    // Assign other properties as needed
        //}

        ///
        /// Finally implemented Approach
        /// 
        //else if (arg1 is DataUser && arg2 is User)
        //{
        //    PropertyInfo[] dprops = typeof(TArg1).GetProperties();
        //    PropertyInfo[] bprops = typeof(TArg2).GetProperties();

        //    foreach (var dp in dprops)
        //    {
        //        var matchingDtoProp = bprops.FirstOrDefault(p => p.Name == dp.Name);
        //        if (matchingDtoProp != null)
        //        {
        //            var bValue = dp.GetValue(arg1);
        //            matchingDtoProp.SetValue(arg2, bValue);
        //        }
        //    }
        //}
        #endregion
    }
}
