using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Web;
using HOAHome.Code.Rules.Services;
using HOAHome.Code.EntityFramework;

namespace HOAHome.Code.Rules
{
    public class UniqueFieldRule<T, TF> : IRuleThatNeedsServices where T:class, IEntity
    {
        private readonly string _fieldName;
        private readonly T _entity;
        private readonly Func<T, TF> _getFieldValueFunction;
        //private readonly Func<Guid, TF, bool> _existsFunction;

        public UniqueFieldRule(string fieldName, T entity, Func<T,TF> getFieldValueFunction)
        {
            Contract.Requires(fieldName != null);
            Contract.Requires(entity != null);
            Contract.Requires(getFieldValueFunction != null);
           
            _fieldName = fieldName;
            _entity = entity;
            _getFieldValueFunction = getFieldValueFunction;
           // _existsFunction = existsFunction;
        }

        public bool IsValid
        {
            get
            {
                throw new InvalidOperationException("Must use service bundle overload");
            }
        }

        public string[] ParticipatingLogicalFields
        {
            get { return new []{this._fieldName}; }
        }

        public string GetErrorMessage()
        {
            return string.Format("{0} already exist in the system.", this._getFieldValueFunction(this._entity));
        }

        public IEnumerable<Type> NeededServices
        {
            get { yield return typeof (IAlreadyExistService); }
        }

        bool IRuleThatNeedsServices.IsValidUsingService(Dictionary<Type, object> serviceBundle)
        {
            if (!serviceBundle.ContainsKey(typeof(IAlreadyExistService)))
            {
                throw new InvalidOperationException("Requried service not supplied");
            }
            var existService = (IAlreadyExistService) serviceBundle[typeof (IAlreadyExistService)];
            object fieldValue = this._getFieldValueFunction(this._entity);
            if (fieldValue == null)
            {
                throw new ApplicationException("fieldValue cannot be null");
            }
            //Contract.Assume(this._fieldName != null);
            return !existService.Exist(this._entity.Id, this._fieldName, fieldValue);
        }
        [ContractInvariantMethod]
        private void ObjectInvariant()
        {
            Contract.Invariant(this._fieldName != null);
        }
    }
}