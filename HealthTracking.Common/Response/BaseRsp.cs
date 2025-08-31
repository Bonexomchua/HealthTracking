using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthTracking.Common.Response
{
    public class BaseRsp
    {

        #region -- Properties --

        public bool Success { get; private set; }
        public string Code { get; set; }
        public string Message
        {
            get
            {
                if (Success)
                {
                    return msg;
                }
                else
                {
                    return Dev ? msg : err;
                }
            }
        }

        public string Variant
        {
            get
            {
                return Success ? "success" : "error";
            }
        }
        public string Title
        {
            get
            {
                return Success ? "Success" : titleError;
            }
        }

        public static bool Dev { get; set; }

        #endregion

        #region -- Methods --

        //Constructor
        public BaseRsp()
        {
            Success = true;
            msg = string.Empty;
            titleError = "Error";

            Dev = true; // TODO

            if (string.IsNullOrEmpty(err))
            {
                err = "Please update common error in Custom Settings";
            }
        }

        /// <summary>
        /// Initialize
        /// </summary>
        /// <param name="message">Message</param>
        public BaseRsp(string message) : this()
        {
            msg = message;
        }

        /// <summary>
        /// Initialize
        /// </summary>
        /// <param name="message">Message</param>
        /// <param name="titleError">Title error</param>
        public BaseRsp(string message, string titleError) : this(message)
        {
            this.titleError = titleError;
        }

        /// <summary>
        /// Set error
        /// </summary>
        /// <param name="message">Message</param>
        public void SetError(string message)
        {
            Success = false;
            msg = message;
        }

        /// <summary>
        /// Set error
        /// </summary>
        /// <param name="code">Error code</param>
        /// <param name="message">Message</param>
        public void SetError(string code, string message)
        {
            Success = false;
            Code = code;
            msg = message;
        }

        /// <summary>
        /// Set message
        /// </summary>
        /// <param name="message">Message</param>
        public void SetMessage(string message)
        {
            msg = message;
        }

        /// <summary>
        /// Test error
        /// </summary>
        public void TestError()
        {
            SetError("We are testing to show error message, please ignore it...");
        }

        #endregion

        #region -- Fields --

        private readonly string err;
        private readonly string titleError;
        private string msg;

        #endregion
    }
}
