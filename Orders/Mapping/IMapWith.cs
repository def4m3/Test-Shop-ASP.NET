﻿using AutoMapper;

namespace Orders.Mapping
{
    public interface IMapWith<T>
    {
        void Mapping(Profile profile) => profile.CreateMap(typeof(T), GetType());
    }
}
