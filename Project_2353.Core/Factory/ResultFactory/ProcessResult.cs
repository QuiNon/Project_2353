namespace Project_2353.Core.Factory.ResultFactory
{
    public abstract class IProcessResult
    {
        public abstract SuccessDeleteResult SuccessDeleteResult(string message = "Data delete successful");
        public abstract SuccessUpdateResult SuccessUpdateResult(string message = "Data update successful");
        public abstract SuccessAddResult SuccessAddResult(string message = "Data add successful");
        public abstract SuccessAddResult SuccessProcessResult(string message = "Process successful");
        public abstract FailDeleteResult FailDeleteResult(string message = "Data could not be deleted");
        public abstract FailUpdateResult FailUpdateResult(string message = "Data could not be updated");
        public abstract FailAddResult FailAddResult(string message = "Data could not be deleted"); 
        public abstract FailAddResult FailProcessResult(string message = "Process failed"); 
    }

    public class _ProcessResult : IProcessResult
    {
        public override SuccessDeleteResult SuccessDeleteResult(string message = "")
        {
            return new SuccessDeleteResult(message);
        }

        public override SuccessUpdateResult SuccessUpdateResult(string message = "")
        {
            return new SuccessUpdateResult(message);
        }

        public override SuccessAddResult SuccessAddResult(string message = "")
        {
            return new SuccessAddResult(message);
        }
        public override SuccessAddResult SuccessProcessResult(string message = "")
        {
            return new SuccessAddResult(message);
        }

        public override FailDeleteResult FailDeleteResult(string message = "")
        {
            return new FailDeleteResult(message);
        }

        public override FailUpdateResult FailUpdateResult(string message = "")
        {
            return new FailUpdateResult(message);
        }

        public override FailAddResult FailAddResult(string message = "")
        {
            return new FailAddResult(message);
        }
        public override FailAddResult FailProcessResult(string message = "")
        {
            return new FailAddResult(message);
        }
 
    }

    public abstract class ProcessResult
    {
        public ProcessResult(string message)
        {
            returnMessage = message;
        }

        public ProcessResult(string message, object obj)
        {
            returnMessage = message;
            returnObj = obj;
        } 
        public abstract bool State { get; set; } 
        public abstract string returnMessage { get; set; } 
        public abstract object returnObj { get; set; }
    }

    public class SuccessDeleteResult : ProcessResult
    {
        public SuccessDeleteResult(string message = "") : base(message)
        {
            returnMessage = message;
        } 

        public override bool State
        {
            get => true;
            set { }
        } 

        public override string returnMessage { get; set; } 
        public override object returnObj { get; set; }
    }

    public class SuccessUpdateResult : ProcessResult
    {
        public SuccessUpdateResult(string message = "") : base(message)
        {
            returnMessage = message;
        } 

        public override bool State
        {
            get => true;
            set { }
        } 

        public override string returnMessage { get; set; } 
        public override object returnObj { get; set; }
    }

    public class SuccessAddResult : ProcessResult
    {
        public SuccessAddResult(string message = "") : base(message)
        {
            returnMessage = message;
        } 

        public override bool State
        {
            get => true;
            set { }
        } 

        public override string returnMessage { get; set; } 
        public override object returnObj { get; set; }
    }
    public class SuccessProcessResult : ProcessResult
    {
        public SuccessProcessResult(string message = "") : base(message)
        {
            returnMessage = message;
        } 

        public override bool State
        {
            get => true;
            set { }
        } 

        public override string returnMessage { get; set; } 
        public override object returnObj { get; set; }
    }

    /*****************************************************************************************************************/
    /*****************************************************************************************************************/
    /*****************************************************************************************************************/

    public class FailDeleteResult : ProcessResult
    {
        public FailDeleteResult(string message = "") : base(message)
        {
            returnMessage = message;
        } 

        public override bool State
        {
            get => false;
            set { }
        } 

        public override string returnMessage { get; set; } 
        public override object returnObj { get; set; }
    }

    public class FailUpdateResult : ProcessResult
    {
        public FailUpdateResult(string message = "") : base(message)
        {
            returnMessage = message;
        } 

        public override bool State
        {
            get => false;
            set { }
        } 

        public override string returnMessage { get; set; } 
        public override object returnObj { get; set; }
    }

    public class FailAddResult : ProcessResult
    {
        public FailAddResult(string message = "") : base(message)
        {
            returnMessage = message;
        } 

        public override bool State
        {
            get => false;
            set { }
        } 

        public override string returnMessage { get; set; } 
        public override object returnObj { get; set; }
    }
    public class FailProcessResult : ProcessResult
    {
        public FailProcessResult(string message = "") : base(message)
        {
            returnMessage = message;
        } 

        public override bool State
        {
            get => false;
            set { }
        } 

        public override string returnMessage { get; set; } 
        public override object returnObj { get; set; }
    }
 
}