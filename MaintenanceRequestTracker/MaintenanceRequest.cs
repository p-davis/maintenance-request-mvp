using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaintenanceRequestTracker
{
    class MaintenanceRequest
    {
        private int requestId;

        private string itemType;

        private string itemId;

        private string maintenanceType;

        private string description;

        private string status;

        private DateTime dateRequested;

        private DateTime? dateRequired;

        private string enteredBy;

        private DateTime lastModified;

        private string modifiedBy;

        private string comments;

        public int RequestId
        {
            get
            {
                return requestId;
            }

            set
            {
                requestId = value;
            }
        }

        public string ItemType
        {
            get
            {
                return itemType;
            }

            set
            {
                itemType = value;
            }
        }

        public string ItemId
        {
            get
            {
                return itemId;
            }

            set
            {
                itemId = value;
            }
        }

        public string MaintenanceType
        {
            get
            {
                return maintenanceType;
            }

            set
            {
                maintenanceType = value;
            }
        }

        public string Description
        {
            get
            {
                return description;
            }

            set
            {
                description = value;
            }
        }

        public string Status
        {
            get
            {
                return status;
            }

            set
            {
                status = value;
            }
        }

        public DateTime DateRequested
        {
            get
            {
                return dateRequested;
            }

            set
            {
                dateRequested = value;
            }
        }

        public DateTime? DateRequired
        {
            get
            {
                return dateRequired;
            }

            set
            {
                dateRequired = value;
            }
        }

        public string EnteredBy
        {
            get
            {
                return enteredBy;
            }

            set
            {
                enteredBy = value;
            }
        }

        public DateTime LastModified
        {
            get
            {
                return lastModified;
            }

            set
            {
                lastModified = value;
            }
        }

        public string ModifiedBy
        {
            get
            {
                return modifiedBy;
            }

            set
            {
                modifiedBy = value;
            }
        }

        public string Comments
        {
            get
            {
                return comments;
            }

            set
            {
                comments = value;
            }
        }

        public MaintenanceRequest()
        {

        }
    }
}
