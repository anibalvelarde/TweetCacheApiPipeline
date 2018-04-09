using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using Autofac.Core;

namespace TweetCacheApi.Ioc
{
    internal class Module : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.Register(c => new Services.TwitterServiceMock())
                .As<Services.ITwitterService>()
                .InstancePerLifetimeScope();
        }
    }
}
