#region File Info Header
/*________________________________________________________________________________________

  Copyright (C) 2011 Jason Zhang, eagleboost@msn.com

  * THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
  * EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
  * WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.

________________________________________________________________________________________*/
#endregion File Info Header

namespace PrismSplash
{
  using System.Threading;
  using System.Windows;
  using Microsoft.Practices.Composite.Events;
  using Microsoft.Practices.Composite.Modularity;
  using Microsoft.Practices.Composite.UnityExtensions;
  using Microsoft.Practices.Unity;
  using Splash.Events;
  using Splash.Interfaces;

  public class Bootstrapper : UnityBootstrapper
  {
    protected override void ConfigureContainer()
    {
      Container.RegisterType<IShell, Shell>(new ContainerControlledLifetimeManager());
      base.ConfigureContainer();
    }

    protected override DependencyObject CreateShell()
    {
      var shell = Container.Resolve<IShell>();
      return shell as DependencyObject;
    }

    #region Private Properties
    private IEventAggregator EventAggregator
    {
      get { return Container.Resolve<IEventAggregator>(); }
    }
    #endregion

    protected override void InitializeModules()
    {
      IModule splashModule = Container.Resolve<Splash.Module>();
      splashModule.Initialize();

      EventAggregator.GetEvent<MessageUpdateEvent>().Publish(new MessageUpdateEvent {Message = "Module1"});
      Thread.Sleep(2000); //simulate long loading of the module
      IModule customersModule = Container.Resolve<Module1.Module>();
      customersModule.Initialize();

      EventAggregator.GetEvent<MessageUpdateEvent>().Publish(new MessageUpdateEvent { Message = "Module2" });
      Thread.Sleep(2000); //simulate long loading of the module
      IModule locationModule = Container.Resolve<Module2.Module>();
      locationModule.Initialize();

      EventAggregator.GetEvent<MessageUpdateEvent>().Publish(new MessageUpdateEvent { Message = "Module3" });
      Thread.Sleep(2000); //simulate long loading of the module
      IModule ordersModule = Container.Resolve<Module3.Module>();
      ordersModule.Initialize();
    }
  }
}
