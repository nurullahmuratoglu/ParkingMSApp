﻿using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace ParkingMSApp.Application
{
    public static class ServiceRegistration
    {
        public static void AddApplicationServices(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddMediatR(Assembly.GetExecutingAssembly());
            serviceCollection.AddAutoMapper(Assembly.GetExecutingAssembly());
        }
    }
}
