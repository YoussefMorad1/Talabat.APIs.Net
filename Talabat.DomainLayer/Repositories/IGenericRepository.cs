﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talabat.DomainLayer.Entities;
using Talabat.DomainLayer.Specifications;

namespace Talabat.DomainLayer.Repositories;

public interface IGenericRepository<T> where T : EntityBase
{
	#region Without Specifications
	Task<IEnumerable<T>> GetAllAsync();
	Task<T?> GetByIdAsync(int id); 
	#endregion

	#region With Specifications
	Task<IEnumerable<T>> GetAllWithSpecAsync(ISpecifications<T> spec);
	Task<T?> GetByIdAsyncWithSpecAsync(ISpecifications<T> spec); 
	#endregion

}
