using AutoMapper;
using System.Reflection;

namespace DataLayer
{
    #region "Mannual Mapping"
    /// <summary>
    /// Converts BusinessModel object to DataModel object (Mannual Maping)
    /// </summary>
    /// <param name="user"></param>
    /// <returns>DataModel object</returns>
    //private static DataUser ConvertToDataModel(BusinessUser user)
    //{
    //    DataUser dataUserObj = new DataUser
    //    {
    //        Username = user.Username,
    //        Email = user.Email,
    //        Mobile = user.Mobile,
    //        Password = user.Password
    //    };

    //    return dataUserObj;
    //}
    #endregion

    #region "Mapping without using AutoMapper"
    internal static class DALConvertUser
    {
        /// <summary>
        /// Generic Method that Converts BusinessModel object to DataModel object and viceversa (Without using AutoMapper)
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
    #endregion

    /// <summary>
    /// AutoMapper which is used to convert businessModelUser to dataModelUser and vice versa
    /// </summary>
    internal class AutoMapperConfig
    {
        /// <summary>
        /// AutoMapper method Which contains Mapping configurations and returns IMapper object
        /// </summary>
        /// <returns>IMapper mapper;</returns>
        internal static IMapper Initialize()
        {
            var config = new MapperConfiguration(cfg =>
            {
                // Multiple Configurations to enable twoside conversion
                cfg.CreateMap<BusinessModel.BusinessUser, DataModel.DataUser>();
                cfg.CreateMap<DataModel.DataUser, BusinessModel.BusinessUser>();
            });

            var mapper = new Mapper(config);
            return mapper;
        }
    }
}
