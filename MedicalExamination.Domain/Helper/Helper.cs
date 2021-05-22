using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using AutoMapper;
using MedicalExamination.Domain.Models.MedicalRecord;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;
using MedicalExamination.Domain.Entities;
using MedicalExamination.Domain.Responses.User;
using MedicalExamination.Domain.Requests.User;

namespace MedicalExamination.Domain.Helper
{
    public static class Helper
    {
        public static string idTimeZoneUtc7 = "SE Asia Standard Time";
        private static DateTime baseDate = new DateTime(1970, 01, 01);
        public static string domain = "https://khamskdinhky.tech";
        public static TDestination AutoDTO<TSource, TDestination>(TSource source)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<TSource, TDestination>();
                cfg.CreateMap<AppIdentityUser, UserDetailsModel>().ForMember(u => u.UserId, act => act.MapFrom(src => src.Id));
                cfg.CreateMap<AppIdentityUser, UserInfoRes>().ForMember(u => u.UserId, act => act.MapFrom(src => src.Id));
                cfg.CreateMap<CreateUserReq, AppIdentityUser>()
                                    .ForMember(appUser => appUser.UserName,
                                                act => act.MapFrom(src => Helper.FormatUsername(src.UserName)));
                cfg.CreateMap<MedicalRecordDetails, string>().ConvertUsing(s => JsonConvert.SerializeObject(s));
                cfg.CreateMap<MedicalHistoryForm, string>().ConvertUsing(s => JsonConvert.SerializeObject(s));
                cfg.CreateMap<string, MedicalRecordDetails>().ConvertUsing(s => JsonConvert.DeserializeObject<MedicalRecordDetails>(s));
                cfg.CreateMap<string, MedicalHistoryForm>().ConvertUsing(s => JsonConvert.DeserializeObject<MedicalHistoryForm>(s));
            });

            IMapper mapper = config.CreateMapper();
            return mapper.Map<TSource, TDestination>(source);
        }

        public static string RemoveDoubleSpaces(string data)
        {
            return Regex.Replace(data.Trim(), @"\s+", " ");
        }

        public static string FormatPersonName(string data)
        {
            data = RemoveDoubleSpaces(data);
            string[] nameSplitArray = data.Split(" ");
            for (int i = 0; i < nameSplitArray.Length; i++)
            {
                char[] stringSplitToChar = nameSplitArray[i].ToCharArray();
                stringSplitToChar[0] = Char.ToUpper(stringSplitToChar[0]);
                nameSplitArray[i] = new string(stringSplitToChar);
            }
            return String.Join(" ", nameSplitArray);
        }

        public static string LowercaseString(string data)
        {
            return RemoveDoubleSpaces(data).ToLower();
        }

        public static string FormatUsername(string data)
        {
            data = RemoveDoubleSpaces(data).ToLower();
            return data.Replace(" ", "");
        }

        public static DateTime ConvertUTCToTimeZone(DateTime utcTime, string idTimeZone)
        {
            TimeZoneInfo cstZone = TimeZoneInfo.FindSystemTimeZoneById(idTimeZone);
            return TimeZoneInfo.ConvertTimeFromUtc(utcTime, cstZone);
        }

        public static DateTime TimeZoneConvertToUTC(DateTime time, string idTimeZone)
        {
            TimeZoneInfo cstZone = TimeZoneInfo.FindSystemTimeZoneById(idTimeZone);
            return TimeZoneInfo.ConvertTimeToUtc(time, cstZone);
        }

        public static double ConvertToTimeStamp(DateTime time)
        {
            return time.Subtract(baseDate).TotalSeconds;
        }

        public static DateTime GetDateTimeFromTimeStamp(double timeStamp)
        {
            return baseDate.AddSeconds(timeStamp);
        }

    }
}
