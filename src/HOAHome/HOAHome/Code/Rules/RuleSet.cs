using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HOAHome.Code.EntityFramework;
using HOAHome.Code.Rules.Services;

namespace HOAHome.Code.Rules
{
    public class RuleSet<T> : IValidatableRegardingPersistence
    {
        private readonly T _entity;
        private readonly List<IRule> _persistenceRelatedRules;
        private readonly List<IRule> _brokenRules = new List<IRule>();

        //public RuleSet(List<IRule> persistenceRelatedRules)
        //{
        //    _persistenceRelatedRules = persistenceRelatedRules;
        //}
        public RuleSet(T entity, params IRule[] persistenceRelatedRules)
        {
            Contract.Requires(persistenceRelatedRules != null);
            _entity = entity;
            _persistenceRelatedRules = new List<IRule>();
            this._persistenceRelatedRules.AddRange(persistenceRelatedRules);
        }
        //public bool IsValidRegardingPersistence
        //{
        //    get { throw new NotImplementedException(); }
        //}

        public IList<IRule> BrokenRulesRegardingPersistence
        {
            get { return _brokenRules; }
        }

        public IList<IRule> PersistenceRelatedRules
        {
            get { return this._persistenceRelatedRules; }
        }
        

        public bool ValidateAllRules(Dictionary<Type, object> serviceBundle)
        {
            bool valid = true;
            foreach (var rule in _persistenceRelatedRules)
            {
                if (rule is IRuleThatNeedsServices)
                {
                    var serviceRule = (IRuleThatNeedsServices) rule;
                    if (!serviceRule.IsValidUsingService(serviceBundle))
                    {
                        this._brokenRules.Add(rule);
                        valid = false;
                        
                    }
                } else
                {
                    if (!rule.IsValid)
                    {
                        this._brokenRules.Add(rule);
                        valid = false;
                        
                    }
                }
            }
            return valid;
        }

        public void AddErrorsToModelState(ModelStateDictionary modelState, object service)
        {

            bool valid = this.ValidateAllRules(new Dictionary<Type, object> { { typeof(IAlreadyExistService), service } });
            if (!valid)
            {
               
                foreach (var rule in this._brokenRules)
                {
                    string field = null;
                    if (rule.ParticipatingLogicalFields.Length > 0)
                    {
                        field = rule.ParticipatingLogicalFields[0];
                    }
                    modelState.AddModelError(field, rule.GetErrorMessage());
                }
            }
        }
    }
}