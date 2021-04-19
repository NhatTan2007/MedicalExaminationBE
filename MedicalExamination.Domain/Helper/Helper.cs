using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using AutoMapper;

namespace MedicalExamination.Domain.Helper
{
    public static class Helper
    {

        public static TDestination AutoDTO<TSource, TDestination>(TSource source)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<TSource, TDestination>();
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
    }
}
