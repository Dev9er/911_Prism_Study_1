# StockWinner 호출 순서
    - class App
        - RegisterTypes(IContainerRegistry containerRegistry)
        - ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
        - Window CreateShell()
            - return Container.Resolve<MainWindow>();
    - class MainWindow : Window
        - MainWindow()
    - class MainWindowViewModel : BindableBase
        - MainWindowViewModel(IRegionManager regionManager, IEventAggregator eventAggregator)
            - regionManager.RegisterViewWithRegion("MainWindowRegion", typeof(SplashView)); // Splash Screen
            - regionManager.RegisterViewWithRegion("MainWindowLeftRegion", typeof(SajuView));
            - regionManager.RegisterViewWithRegion("MainWindowRightRegion", typeof(EnglishView));
    - class MainWindow : Window
        -  SetProgramIcon()
    - class StockScreenModule : IModule
        - containerRegistry.RegisterForNavigation<MainView>();
        - containerRegistry.RegisterForNavigation<GroupView>();
        - containerRegistry.RegisterForNavigation<WorkView>();
        - containerRegistry.RegisterForNavigation<TableView>();
        - containerRegistry.RegisterForNavigation<MenuView>();
        - containerRegistry.RegisterForNavigation<TaskView>();
        - containerRegistry.RegisterForNavigation<InfoView>();
    - class StockScreenModule : IModule
        - OnInitialized(IContainerProvider containerProvider)
            - var regionManager = containerProvider.Resolve<IRegionManager>();
            - regionManager.RegisterViewWithRegion("CenterTopRegion", typeof(WorkView));
    - MainWindowViewModel : BindableBase
        - ChangeViewToMainView()
            _regionManager.RequestNavigate("MainWindowRegion", "MainView");
            _regionManager.RequestNavigate("RightTopRegion", "MenuView");
            _regionManager.RequestNavigate("LeftTopRegion", "GroupView");
            _regionManager.RequestNavigate("RightBottomRegion", "InfoView");
            _toMainViewEvent.Unsubscribe(ChangeViewToMainView);
    - class MainView : UserControl
        - public MainView()
    - class MenuView : UserControl
        - public MenuView()
    - class MainView : UserControl
        - OnClosing(CancelEventArgs e)    
    - class MainWindowViewModel : BindableBase
        - ClosingWindows()
---
    - ChangeScreenToMainView()
        _ regionManager.Regions.Remove("FourJuRegion");
        _ regionManager.Regions.Remove("MainWindowLeftRegion");
        _ regionManager.Regions.Remove("EnglishAnswerRegion");
        _ regionManager.Regions.Remove("MainWindowRightRegion");

















