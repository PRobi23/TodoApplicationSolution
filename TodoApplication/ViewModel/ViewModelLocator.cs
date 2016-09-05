using Microsoft.Practices.ServiceLocation;
using GalaSoft.MvvmLight.Ioc;

namespace TodoApplication.ViewModel
{
    public class ViewModelLocator
    {
        private static ViewModelLocator _locator;

        /// <summary>
        /// Initializes a new instance of the ViewModelLocator class.
        /// </summary>
        private ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            SimpleIoc.Default.Register<MainViewModel>();
        }

        public static ViewModelLocator Instance => _locator ?? (_locator = new ViewModelLocator());

        public MainViewModel MainViewModel
        {
            get
            {
                return ServiceLocator.Current.GetInstance<MainViewModel>();
            }
        }

        public static void Cleanup()
        {
            // TODO Clear the ViewModels
        }
    }
}