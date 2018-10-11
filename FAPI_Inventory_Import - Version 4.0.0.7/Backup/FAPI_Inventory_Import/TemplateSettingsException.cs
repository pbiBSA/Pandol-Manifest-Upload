using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FAPI_Inventory_Import
{
    class TemplateSettingsException :
        System.ApplicationException
    {
        public TemplateSettingsException(string message) :
            base(message) // pass the message up to the base class
        {

        }
    }

 }
