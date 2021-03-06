﻿using UnityEngine;
using System.Collections;
using System;

[System.Serializable]
public class CountryBudget : ScriptableObject
{
    [System.Serializable]
    public class CountryIncome
    {
        public long TotalIncome;

        [Range(0.0f, 100.0f)]
        public float PersonalIncomeTaxRate;
        public long PersonalIncomeTax;

        [Range(0.0f, 100.0f)]
        public float BusinessTaxRate;
        [Range(0.0f, 100.0f)]
        public float SalesTaxRate;
        public long TradeIncome;
        
        public long TourismIncome;
        public long ForeignAidIncome;
        [Range(0.0f, 100.0f)]
        public float VATTaxRate;
        [Range(0.0f, 100.0f)]
        public float TransactionTaxRate;

    }
    [System.Serializable]
    public class CountryExpense
    {
        
        [Tooltip("The likelness the weapon will hit its target ")]
        [Range(-100.0f, 100.0f)]
        public float InfrastructureConstructionSpendingRate;
        public long InfrastructureConstruction;
        [Tooltip("The likelness the weapon will hit its target ")]
        [Range(-100.0f, 100.0f)]
        public float PrograngandaSpendingRate;
        public long Proganganda;
        [Tooltip("The likelness the weapon will hit its target ")]
        [Range(-100.0f, 100.0f)]
        public float EnvironmentSpendingRate;
        public long Environment;
        [Tooltip("The likelness the weapon will hit its target ")]
        [Range(-100.0f, 100.0f)]
        public float HealthCareSpendingRate;
        public long HealthCare;
        [Tooltip("The likelness the weapon will hit its target ")]
        [Range(-100.0f, 100.0f)]
        public float EducationSpendingRate;
        public long Education;
        [Tooltip("The likelness the weapon will hit its target ")]
        [Range(-100.0f, 100.0f)]
        public float TelecomSpendingRate;
        public long Telecom;
        [Tooltip("The likelness the weapon will hit its target ")]
        [Range(-100.0f, 100.0f)]
        public float ForeignAidSpendingRate;
        public long ForeignAid;
        [Tooltip("The likelness the weapon will hit its target ")]
        [Range(-100.0f, 100.0f)]
        public float ResearchSpendingRate;
        public long Research;
        [Tooltip("The likelness the weapon will hit its target ")]
        [Range(-100.0f, 100.0f)]
        public float TourismSpendingRate;
        public long Tourism;
        [Tooltip("The likelness the weapon will hit its target ")]
        [Range(-100.0f, 100.0f)]
        public long Agriculture;
        public float AgricultureSpendingRate;

        [Tooltip("The likelness the weapon will hit its target ")]
        [Range(-100.0f, 100.0f)]
        public long Aerospace;
        public float AerospaceSpendingRate;
        [Tooltip("The likelness the weapon will hit its target ")]
        [Range(-100.0f, 100.0f)]
        public long Commerce;
        public float CommerceSpendingRate;
        [Tooltip("The likelness the weapon will hit its target ")]
        [Range(-100.0f, 100.0f)]
        public long Energy;
        public float EnergySpendingRate;
    }
    [System.Serializable]
    public class CountryFixedExpense
    {
        [Tooltip("The likelness the weapon will hit its target ")]
        [Range(0.0f, 100.0f)]
        public float SocialWelfareSpendingRate;
        public long SocialWelfare;
        [Tooltip("The likelness the weapon will hit its target ")]
        [Range(0.0f, 100.0f)]
        public float SecurityMilitarySpendingRate;
        public long SecurityMilitary;
        [Tooltip("The likelness the weapon will hit its target ")]
        [Range(0.0f, 100.0f)]
        public float DiplomacySpendingRate;
        public long Diplomacy;
        [Tooltip("The likelness the weapon will hit its target ")]
        [Range(0.0f, 100.0f)]
        public float IntelSpendingRate;
        public long Intel;
        [Tooltip("The likelness the weapon will hit its target ")]
        [Range(0.0f, 100.0f)]
        public float TradeSpendingRate;
        public long Trade;
        [Tooltip("The likelness the weapon will hit its target ")]
        [Range(0.0f, 100.0f)]
        public float InfrastructureMainanceSpendingRate;
        public long InfrastructureMainance;
        [Tooltip("The likelness the weapon will hit its target ")]
        [Range(0.0f, 100.0f)]
        public float UnitProductionSpendingRate;
        public long UnitProduction;
        [Tooltip("The likelness the weapon will hit its target ")]
        [Range(0.0f, 100.0f)]
        public float DebtPaymentRate;
        public long DebtPayment;
        [Tooltip("The likelness the weapon will hit its target ")]
        [Range(0.0f, 100.0f)]
        public float CorruptionRate;
        public long Corruption;
    }

    [ContextMenuItem("CalculateCountriesPersonalIncome", "IncomeGenerator")]
    public CountryGovernment Country;

    public void IncomeGenerator()
    {
        var helper = new Helper();

        this.CurrencySymbol = Helpers.GetRegionCurrencySymbol(this.Country.LocalNameOfGovernment);
        this.CurrencyName = Helpers.GetRegionCurrency(this.Country.LocalNameOfGovernment);

        this.CountryIncomes.PersonalIncomeTax = this.Country.RawPopulation * (long)(PerCapitaIncome * this.CountryIncomes.PersonalIncomeTaxRate);
    }
    public string CurrencyName;
    public string CurrencySymbol;
    [ContextMenuItem("Balance Incomes", "BalanceIncomes")]
    public CountryIncome CountryIncomes;
    public void BalanceIncomes()
    {
        var helper = new Helper();

        this.CurrencySymbol = Helpers.GetRegionCurrencySymbol(this.Country.LocalNameOfGovernment);
        this.CurrencyName = Helpers.GetRegionCurrency(this.Country.LocalNameOfGovernment);

        this.CountryIncomes.TotalIncome = this.CountryIncomes.ForeignAidIncome + this.CountryIncomes.PersonalIncomeTax + this.CountryIncomes.TourismIncome + this.CountryIncomes.TradeIncome;
    }
    [ContextMenuItem("Balance Expense", "BalanceExpenses")]
    public CountryExpense CountryExpenses;
    public void BalanceExpenses()
    {
        var helper = new Helper();

        
        var defaultAllocationBudget = Math.Floor((decimal)this.CountryIncomes.TotalIncome / 18);
        var defaultSpendingRate = 5.5f;
     
        this.CountryExpenses.Agriculture = Convert.ToInt64(defaultAllocationBudget);
        this.CountryExpenses.AgricultureSpendingRate = defaultSpendingRate;
        //TitleOfEducation
        this.CountryExpenses.Education = Convert.ToInt64(defaultAllocationBudget);
        this.CountryExpenses.EducationSpendingRate = defaultSpendingRate;
        //TitleOfEnvironment
        this.CountryExpenses.Environment = Convert.ToInt64(defaultAllocationBudget);
        this.CountryExpenses.EnvironmentSpendingRate = defaultSpendingRate;
      
        //TitleOfHealth
        this.CountryExpenses.HealthCare = Convert.ToInt64(defaultAllocationBudget);
        this.CountryExpenses.HealthCareSpendingRate = defaultSpendingRate;
   
        //TitleOfCulture
        this.CountryExpenses.Proganganda = Convert.ToInt64(defaultAllocationBudget);
        this.CountryExpenses.PrograngandaSpendingRate = defaultSpendingRate;
        //TitleOfResearch
        this.CountryExpenses.Research = Convert.ToInt64(defaultAllocationBudget);
        this.CountryExpenses.ResearchSpendingRate = defaultSpendingRate;
        //TitleOfPopulation

        this.CountryExpenses.Tourism = Convert.ToInt64(defaultAllocationBudget);
        this.CountryExpenses.TourismSpendingRate = defaultSpendingRate;
        //TitleOfJustice
        this.CountryFixedExpenses.Corruption = Convert.ToInt64(defaultAllocationBudget);
        this.CountryFixedExpenses.CorruptionRate = defaultSpendingRate;
        //DFinical
        this.CountryFixedExpenses.DebtPayment = Convert.ToInt64(defaultAllocationBudget);
        this.CountryFixedExpenses.DebtPaymentRate = defaultSpendingRate;

        //TitleOfState
        this.CountryFixedExpenses.Diplomacy = Convert.ToInt64(defaultAllocationBudget);
        this.CountryFixedExpenses.DiplomacySpendingRate = defaultSpendingRate;
        this.CountryExpenses.ForeignAid = Convert.ToInt64(defaultAllocationBudget);
        this.CountryExpenses.ForeignAidSpendingRate = defaultSpendingRate;
        //TitleOfEnergy
        //TitleOfInternal
        this.CountryExpenses.Telecom = Convert.ToInt64(defaultAllocationBudget);
        this.CountryExpenses.TelecomSpendingRate = defaultSpendingRate;
        this.CountryExpenses.InfrastructureConstruction = Convert.ToInt64(defaultAllocationBudget);
        this.CountryExpenses.InfrastructureConstructionSpendingRate = defaultSpendingRate;
        this.CountryFixedExpenses.InfrastructureMainance = Convert.ToInt64(defaultAllocationBudget);
        this.CountryFixedExpenses.InfrastructureMainanceSpendingRate = defaultSpendingRate;
        if(this.CountryFixedExpenses.Intel != 0)
        {
            //TitleOfIntel
            //TitleOfStateSecertService
            this.CountryFixedExpenses.Intel = Convert.ToInt64(defaultAllocationBudget);
            this.CountryFixedExpenses.IntelSpendingRate = defaultSpendingRate;
        }
        //TitleOfMilitary
        //TitleOfStatePolice
        this.CountryFixedExpenses.SecurityMilitary = Convert.ToInt64(defaultAllocationBudget);
        this.CountryFixedExpenses.SecurityMilitarySpendingRate = defaultSpendingRate;
   
        this.CountryFixedExpenses.UnitProduction = Convert.ToInt64(defaultAllocationBudget);
        this.CountryFixedExpenses.UnitProductionSpendingRate = defaultSpendingRate;

        //TitleOfTrade
        this.CountryFixedExpenses.Trade = Convert.ToInt64(defaultAllocationBudget);
        this.CountryFixedExpenses.TradeSpendingRate = defaultSpendingRate;
        this.CountryFixedExpenses.SocialWelfare = Convert.ToInt64(defaultAllocationBudget);
        this.CountryFixedExpenses.SocialWelfareSpendingRate = defaultSpendingRate;

    }
    public CountryFixedExpense CountryFixedExpenses;
    public float CountryREERRate;
    public float inflationIndex;
    public ReserveCurrency CountryReserveCurrency;
    public float GoldReserves;
    public float CenteralBankRate;
    public float PerCapitaIncome;
    public long GNP;
    public long CashReserves;
    public bool HasSoverignWealthFund;
    public long WealthFundInvestment;
    public float WealthFundRate;
    /// <summary>
    /// The rate that the person incomes of the average person increases and increases the overall wealth of the country
    /// </summary>
    public float GdpPPPGrowthRate;
    public float CountryDebt;


    public void ProcessBudgetDay() {

    }
    public void ProcessBudgetMonth()
    {

    }
    public void ProcessYearBudgetRenew() { }
}
