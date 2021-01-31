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
  using System.Windows;

  /// <summary>
  /// App.xaml 的交互逻辑
  /// </summary>
  public partial class App
  {
    protected override void OnStartup(StartupEventArgs e_)
    {
      base.OnStartup(e_);

      var bootstrapper = new Bootstrapper();
      bootstrapper.Run();
    }
  }
}
