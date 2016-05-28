using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using AutoMapper;
using FileObmen.Models.Entities;
using FileObmen.Models.ViewModels;

namespace FileObmen.Mappers
{
    public class CommonMapper : IMapper
    {
        static CommonMapper()
        {
            Mapper.CreateMap<FileEditModel, File>().Ignore(file => file.DeleteTime);
            Mapper.CreateMap<File, FileEditModel>();
            Mapper.CreateMap<RegisterModel, User>();
            Mapper.CreateMap<ProfileEditModel, User>();
            Mapper.CreateMap<User, ProfileEditModel>();
        }

        public object Map(object source, object destination)
        {
            return Mapper.Map(source, destination);
        }
    }

    public static class MapperTool
    {
        public static IMappingExpression<TSource, TDest>
            Ignore<TSource, TDest>(
            this IMappingExpression<TSource, TDest> expression,
            Expression<Func<TDest, object>> property)
        {
            expression.ForMember(property, opt => opt.Ignore());
            return expression;
        }
    }
}