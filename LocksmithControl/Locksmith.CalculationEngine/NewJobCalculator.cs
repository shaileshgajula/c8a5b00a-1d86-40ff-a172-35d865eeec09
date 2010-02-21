using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Locksmith.CalculationEngine
{
    [Serializable]
    public class NewJobCalculator
    {
        #region Private Members

        private double _gross;
        private double _grossMinusCost;
        private double _techCut;
        private double _techPayout;
        private double _company;
        private double _businessNet;
        private double _sumCash;     

        #endregion

        #region Ctor

        public NewJobCalculator(double total, double cost, PaymentMethods paymentMethod, JobPricing jobPricing)
        {
            Calculate(total, cost, paymentMethod, jobPricing);
        } 

        #endregion

        #region Private Methods

        private void Calculate(double total, double cost, PaymentMethods paymentMethod, JobPricing jobPricing)
        {
            //gross calc
            if (paymentMethod == PaymentMethods.Cash)
            {
                _gross = total;
            }
            else if (paymentMethod == PaymentMethods.Check)
            {
                _gross = total - (total * Globals.checkFee);
            }
            else
            {
                _gross = total - (total * Globals.creditCardFee);
            }

            //techCut calc
            if (jobPricing == JobPricing.Day)
            {
                _techCut = (_gross - cost) * 0.2;
            }
            else if (jobPricing == JobPricing.Night)
            {
                _techCut = (_gross - cost) * 0.35;
            }
            else
            {
                _techCut = (_gross - cost) * 0.5;
            }

            _grossMinusCost = _gross - cost;
            _techPayout = cost + _techCut;
            _company = _grossMinusCost * 0.5;
            _businessNet =  _gross - _techPayout - _company;
            _sumCash = _company + _businessNet;
        }

        #endregion

        #region Properties

        public double Gross
        {
            get { return _gross; }           
        }

        public double GrossMinusCost
        {
            get { return _grossMinusCost; }          
        }

        public double TechCut
        {
            get { return _techCut; }
        }

        public double TechPayout
        {
            get { return _techPayout; }
        }

        public double Company
        {
            get { return _company; }            
        }
        public double BusinessNet
        {
            get { return _businessNet; }         
        }

        public double SumCash
        {
            get { return _sumCash; }         
        }

        #endregion
    }
}
