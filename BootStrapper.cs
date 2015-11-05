using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace MVVMEditComboBoxItemsSample
{
    class BootStrapper
    {
        public static void Initialize()
        {
            //initialize all the services needed for dependency injection
            //we use the unity framework for dependency injection, but you can choose others
            ServiceProvider.RegisterServiceLocator(new UnityServiceLocator());  

            //register the IModalDialog using an instance of the CustomerViewDialog
            //this sets up the view

        }
    }
}
