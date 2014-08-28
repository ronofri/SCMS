using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SCMS.RSolverTools
{
    public enum AlertType 
    {
        Error,
        Success,
        Warning,
        Info
    }

    public class AlertItem
    {
        public AlertItem(string msg)
        {
            Message = msg;

            Type = AlertType.Error;

        }

        public AlertItem(string msg, string type) 
        {
            Message = msg;

            switch (type) 
            {
                case "Error":
                    Type = AlertType.Error;
                    break;
                case "Success":
                    Type = AlertType.Success;
                    break;
                case "Warning":
                    Type = AlertType.Warning;
                    break;
                case "Info":
                    Type = AlertType.Info;
                    break;
            }
        }

        public string Message { get; set; }
        public AlertType Type { get; set; }
        public string StringType
        {
            get 
            {
                switch (this.Type) 
                {
                    case AlertType.Error:
                        return "error";
                    case AlertType.Success:
                        return "success";
                    case AlertType.Warning:
                        return "warning";
                    case AlertType.Info:
                        return "info";
                }
                return "";
            }
        } 
    }
}