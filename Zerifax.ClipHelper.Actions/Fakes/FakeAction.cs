using System.Collections.Generic;


namespace Zerifax.Actions
{
    public abstract class FakeAction
    {
        protected Plugins.InlineInvokeProxy CPH { get; }
        protected Dictionary<string,object> args { get; }
    }
}