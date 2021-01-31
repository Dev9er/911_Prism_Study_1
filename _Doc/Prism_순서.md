[Wpf World : Prism Tutorial](https://www.youtube.com/playlist?list=PLl0ZDeqSI5YncbVGm6VsFuXYQFm_N9xZe)
# MahApps.Metro
## 1. Project Reference => Manage NuGet Packages
    - MahApps.Metro => MahApps.Metro.dll
## 2. MainWindow.xaml
    - xmlns:metro="http://metro.mahapps.com/winfx/xaml/controls"
    - Window => metro:MetroWindow
## 3. MainWindow.xaml.cs
    - MainWindow : Window => MainWindow : MetroWindow
    - using MahApps.Metro.Controls;
## 4. App.xaml
    <Application.Resources>
        <ResourceDictionary>
            <ResourceDictionary.MergedDictionaries>
                <ResourceDictionary Source="pack://application:,,,/MahApps.Metro;component/Styles/Controls.xml" />
                <ResourceDictionary Source="pack://application:,,,/MahApps.Metro;component/Styles/Fonts.xml" />
                <ResourceDictionary Source="pack://application:,,,/MahApps.Metro;component/Styles/Colors.xml" />
            </ResourceDictionary.MergedDictionaries>
        </ResourceDictionary>
    </Application.Resources>
## 5. Run
___

# MVVM : MvvmApp
## 1. Views Folders
    - MainWindow.xaml => Views Folder로 이동
    - App.xaml
        - StartupUri => StartupUri="Views/MainWindow.xaml"
    - MainWindow.xaml
        - x:Class => x:Class="MvvmApp.Views.MainWindow"
    - MainWindow.xaml.cs
        - namespace => namespace MvvmApp.Views
## 2. ViewModels Folders
    - MainWindowViewModel.cs
        ```C#
        namespace MvvmApp.ViewModels
        public class MainWindowViewModel : INotifyPropertyChanged
        {
            public event PropertyChangedEventHandler PropertyChanged;

            [NotifyPropertyChangedInvocator]
            protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName))
            }
        }
        ```
## 3. Models Folders
    - MainModel.cs
        ```C#
        namespace MvvmApp.Models
        public class MainModel : INotifyPropertyChanged
        {
            public event PropertyChangedEventHandler PropertyChanged;

            [NotifyPropertyChangedInvocator]
            protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName))
            }

            // Content Property 추가
            private string _content;
            public string Content
            {
                get { return _content; }
                set
                {
                    if (_content == value)
                        return;
                    _content = value;
                    OnPropertyChanged(nameof(Content));
                }
            }
        }
        ```
## 4. MainWindowViewModel.cs
    - MainModel Property 추가
        ```C#
            private MainModel _mainModel;
            public MainModel MainModel
            {
                get { return _mainModel; }
                set
                {
                    if (_mainModel == value)
                        return;
                    _mainModel = value;
                    OnPropertyChanged(nameof(MainModel));
                }
            }
        ``` 
## 5. MainWindow.xaml.cs
    - MainWindow 에 INotifyPropertyChanged 추가
        ```C#
        public class MainWindow : INotifyPropertyChanged
        {
            public event PropertyChangedEventHandler PropertyChanged;

            [NotifyPropertyChangedInvocator]
            protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName))
            }
        }
        ```
    - MainWindowViewModel Property 추가
        ```C#
            private MainWindowViewModel _mainWindowViewModel;
            public MainWindowViewModel MainWindowViewModel
            {
                get { return _mainWindowViewModel; }
                set
                {
                    if (_mainWindowViewModel == value)
                        return;
                    _mainWindowViewModel = value;
                    OnPropertyChanged(nameof(MainWindowViewModel));
                }
            }
        ```
    - MainWindow Constructor 에 MainWindowViewModel 추가
        ```C#
            public MainWindow()
            {
                InitializeComponent();
                MainWindowViewModel = new MainWindowViewModel();
                // MyMainWindowGrid.DataContext
            }
        ```
## 6. MainWindow.xaml
    - Grid 에 Name 속성 추가 for Data Context
    <Grid Name="MyMainWindowGrid">
## 7. MainWindow.xaml.cs
    - MainWindow Constructor 에서 Data Context 추가
        ```C#
            public MainWindow()
            {
                InitializeComponent();
                MainWindowViewModel = new MainWindowViewModel();
                MyMainWindowG       rid.DataContext = MainWindowViewModel;
            }
        ```
## 8. MainWindow.xaml
    - TextBlock Text MainModel Content Property에 Binding 하기
        ```xaml
        <TextBlock Text="{Binding MainModel.Content}" FontSize="30" FontWeight="Bold" HorizontalAlignment="Center" VerticalAlignment="Center"></TextBlock>
        ```
## 9. MainWindowViewModel.cs
    - Constructor에 MainModel 생성 추가
        ```C#
        public MainWindowViewModel()
        {
            MainModel = new MainModel();
        }
        ```
## 10. MainModel.cs
    - _content 에 값 대입
        ```C#
        private string _content = "Welcome to MVVM World";
        ```
## 11. Run
---

# PrismApp
## 1. Project Reference => Manage NuGet Packages
    - Prism.Core => Prism.dll
    - Prism.Wpf => Prism.Wpf.dll
    - Prism.DryIoc
## 2. Folders
    - Views
        - MainWindow.xaml => Views Folder로 이동 MainView.xaml
        - MainView.xaml
            - x:Class => x:Class="PrismApp.Views.MainView"
        - MainView.xaml.cs
            - namespace => namespace PrismApp.Views
    - ViewModels
        - MainViewModel.cs
    - Models
## 3. app.xaml
    - xmlns:prism="http://prismlibrary.com/"
    - Application => prism:PrismApplication
    - <Application.Resources> => <prism:PrismApplication.Resources>
    - // StartupUri
    - Error => To 4.
## 4. Project Reference => Manage NuGet Packages
    - Prism.DryIoc => Prism.DryIoc.Wpf.dll
## 5. app.xaml.cs
    - App : Application => App : PrismApplication
    - Implement Abstract PrismApplication Class
        ```C#
        protected override Window CreateShell()
        {
            return Container.Resolve<MainView>();
        }
        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {

        }
        ```
    - using Prism.Ioc;
    - using PrismApp.Views;
## 6. app.xaml
    - StartupUri="MainWindow.xaml" => 제거
## 7. MainWindow.xaml
    - prism:ViewModelLocator.AutoWireViewModel="True"
## 8. Run