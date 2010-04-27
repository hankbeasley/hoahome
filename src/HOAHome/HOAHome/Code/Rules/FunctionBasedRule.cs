//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;

//namespace HOAHome.Code.Rules
//{
//    public class FunctionBasedRule : IRuleThatNeedsServices
//    {
//        private Func<Dictionary<Type, object>, bool> _function;

//        public FunctionBasedRule(Func<Dictionary<Type, object>, bool> function)
//        {
//            _function = function;
//        }

//        public IEnumerable<Type> NeededServices
//        {
//            get { yield return IRuleThatNeedsServices}
//        }

//        public bool IsValidUsingService(Dictionary<Type, object> serviceBundle)
//        {
//            throw new NotImplementedException();
//        }

//        public bool IsValid
//        {
//            get { throw new NotImplementedException(); }
//        }

//        public string[] ParticipatingLogicalFields
//        {
//            get { throw new NotImplementedException(); }
//        }
//    }
//}