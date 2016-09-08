using Microsoft.Practices.ServiceLocation;
using GalaSoft.MvvmLight.Ioc;

namespace TodoApplication.ViewModel
{
    /// <summary>
    /// Helper for the better view model init.
    /// </summary>
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

        /// <summary>
        /// Gets the instance.
        /// </summary>
        /// <value>
        /// The instance.
        /// </value>
        public static ViewModelLocator Instance => _locator ?? (_locator = new ViewModelLocator());

        /// <summary>
        /// Gets the main view model.
        /// </summary>
        /// <value>
        /// The main view model.
        /// </value>
        public MainViewModel MainViewModel
        {
            get
            {
                return ServiceLocator.Current.GetInstance<MainViewModel>();
            }
        }

        /// <summary>
        /// Cleanups this instance.
        /// </summary>
        public static void Cleanup()
        {
            // TODO Clear the ViewModels
        }
    }
}