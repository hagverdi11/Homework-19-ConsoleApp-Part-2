﻿using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Repostories.Interfaces
{
    public interface IRepository <T> where T: BaseEntity
    {
        void Create(T data);
        void Update(T data);
        void Delete(T data);
        T Get(Predicate<T> predicate);
        List<T> GetAll(Predicate<T> predicate);
    }
}
