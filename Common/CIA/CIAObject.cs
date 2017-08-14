
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets
{
    [Serializable]
    public class JsonCountryCIAModel
    {
        [JsonObject][Serializable]
        public class GenericText
        {
            public string text;
        }

        [JsonObject][Serializable]
        public class Background
        {
            public string text;
        }
        [JsonObject][Serializable]
        public class Introduction
        {
            public Background Background;
        }
        [JsonObject][Serializable]
        public class Location
        {
            public string text;
        }
        [JsonObject][Serializable]
        public class GeographicCoordinates
        {
            public string text;
        }
        [JsonObject][Serializable]
        public class MapReferences
        {
            public string text;
        }
        [JsonObject][Serializable]
        public class Total
        {
            public string text;
        }
        [JsonObject][Serializable]
        public class Land
        {
            public string text;
        }
        [JsonObject][Serializable]
        public class Water
        {
            public string text;
        }
        [JsonObject][Serializable]
        public class Area
        {
            public Total total;
            public Land land;
            public Water water;
        }
        [JsonObject][Serializable]
        public class AreaComparisonMap
        {
            public object text;
        }
        [JsonObject][Serializable]
        public class AreaComparative
        {
            public string text;
            public AreaComparisonMap AreacomparisonMap;
        }
        [JsonObject][Serializable]
        public class BorderCountries
        {
            public string text;
        }
        [JsonObject][Serializable]
        public class LandBoundaries
        {
            public double total;
            public BorderCountries bordercountries;
        }
        [JsonObject][Serializable]
        public class Coastline
        {
            public string text;
        }
        [JsonObject][Serializable]
        public class TerritorialSea
        {
            public string text;
        }
        [JsonObject][Serializable]
        public class ExclusiveFishingZone
        {
            public string text;
        }
        [JsonObject][Serializable]
        public class MaritimeClaims
        {
            public TerritorialSea territorialsea;
            public ExclusiveFishingZone exclusivefishingzone;
        }
        [JsonObject][Serializable]
        public class Climate
        {
            public string text;
        }
        [JsonObject][Serializable]
        public class Terrain
        {
            public string text;
        }
        [JsonObject][Serializable]
        public class LowestPoint
        {
            public string text;
        }
        [JsonObject][Serializable]
        public class HighestPoint
        {
            public string text;
        }
        [JsonObject][Serializable]
        public class ElevationExtremes
        {
            public LowestPoint lowestpoint;
            public HighestPoint highestpoint;
        }
        [JsonObject][Serializable]
        public class NaturalResources
        {
            public string text;
        }
        [JsonObject][Serializable]
        public class AgriculturalLand
        {
            public string text;
        }
        [JsonObject][Serializable]
        public class Forest
        {
            public string text;
        }
        [JsonObject][Serializable]
        public class Other
        {
            public string text;
        }
        [JsonObject][Serializable]
        public class LandUse
        {
            public AgriculturalLand agriculturalland;
            public Forest forest;
            public Other other;
        }
        [JsonObject][Serializable]
        public class IrrigatedLand
        {
            public string text;
        }
        [JsonObject][Serializable]
        public class TotalRenewableWaterResources
        {
            public string text;
        }
        [JsonObject][Serializable]
        public class PerCapita
        {
            public string text;
        }
        [JsonObject][Serializable]
        public class FreshwaterWithdrawalDomesticIndustrialAgricultural
        {
            public string total;
            public PerCapita percapita;
        }
        [JsonObject][Serializable]
        public class NaturalHazards
        {
            public string text;
        }
        [JsonObject][Serializable]
        public class EnvironmentCurrentIssues
        {
            public string text;
        }
        [JsonObject][Serializable]
        public class PartyTo
        {
            public string text;
        }
        [JsonObject][Serializable]
        public class SignedButNotRatified
        {
            public string text;
        }
        [JsonObject][Serializable]
        public class EnvironmentInternationalAgreements
        {
            public string text;
        }
        [JsonObject][Serializable]
        public class GeographyNote
        {
            public string text;
        }

        [Serializable]
        [JsonObject]
        public class Geography
        {
            public string Geographiccoordinates;

            public string Landboundaries;
            public string Coastline;
            public string Maritimeclaims;
            public string Climate;
            public string Terrain;
            public string Elevationextremes;
            public string Naturalresources;
            public string Landuse;
            public string Irrigatedland;
            public string Totalrenewable;
            public string Freshwaterwithdrawal;
            public string Naturalhazards;
            public string EnvironmentCurrentIssues;
            public string EnvironmentInternationalAgreements;
        }
        [JsonObject][Serializable]
        public class Noun
        {
            public string text;
        }
        [JsonObject][Serializable]
        public class Adjective
        {
            public string text;
        }
        [JsonObject][Serializable]
        public class Nationality
        {
            public Noun noun;
            public Adjective adjective;
        }
        [JsonObject][Serializable]
        public class Note
        {
            public string text;
        }
        [JsonObject][Serializable]
        public class EthnicGroups
        {
            public string text;
            public Note note;
        }
        [JsonObject][Serializable]
        public class Languages
        {
            public string text;
        }
        [JsonObject][Serializable]
        public class Religions
        {
            public string text;
        }
        [JsonObject][Serializable]
        public class Population
        {
            public string text;
        }


        [JsonObject][Serializable]
        public class Male
        {
            public string text;
        }
        [JsonObject][Serializable]
        public class Female
        {
            public string text;
        }
        [JsonObject][Serializable]
        public class MedianAge
        {
            public string total;
            public Male male;
            public Female female;
        }
        [JsonObject][Serializable]
        public class PopulationGrowthRate
        {
            public string text;
        }
        [JsonObject][Serializable]
        public class BirthRate
        {
            public string text;
        }
        [JsonObject][Serializable]
        public class DeathRate
        {
            public string text;
        }
        [JsonObject][Serializable]
        public class NetMigrationRate
        {
            public string text;
        }
        [JsonObject][Serializable]
        public class UrbanPopulation
        {
            public string text;
        }
        [JsonObject][Serializable]
        public class RateOfUrbanization
        {
            public string text;
        }
        [JsonObject][Serializable]
        public class Urbanization
        {
            public UrbanPopulation urbanpopulation;
            public RateOfUrbanization rateofurbanization;
        }
        [JsonObject][Serializable]
        public class MajorUrbanAreasPopulation
        {
            public string text;
        }
        [JsonObject][Serializable]
        public class AtBirth
        {
            public string text;
        }
        [JsonObject][Serializable]
        public class TotalPopulation
        {
            public string text;
        }


        [JsonObject][Serializable]
        public class LifeExpectancyAtBirth
        {
            public string totalpopulation;
            public string male;
            public string female;
        }
        [JsonObject][Serializable]
        public class TotalFertilityRate
        {
            public string text;
        }
        [JsonObject][Serializable]
        public class ContraceptivePrevalenceRate
        {
            public string text;
        }
        [JsonObject][Serializable]
        public class HealthExpenditures
        {
            public string text;
        }
        [JsonObject][Serializable]
        public class PhysiciansDensity
        {
            public string text;
        }
        [JsonObject][Serializable]
        public class HospitalBedDensity
        {
            public string text;
        }
        [JsonObject][Serializable]
        public class Improved
        {
            public string text;
        }
        [JsonObject][Serializable]
        public class Unimproved
        {
            public string text;
        }
        [JsonObject][Serializable]
        public class DrinkingWaterSource
        {
            public Improved improved;
            public Unimproved unimproved;
        }
        [JsonObject][Serializable]
        public class SanitationFacilityAccess
        {
            public string improved;
            public string unimproved;
        }
        [JsonObject][Serializable]
        public class HIVAIDSAdultPrevalenceRate
        {
            public string text;
        }
        [JsonObject][Serializable]
        public class HIVAIDSPeopleLivingWithHIVAIDS
        {
            public string text;
        }
        [JsonObject][Serializable]
        public class HIVAIDSDeaths
        {
            public string text;
        }
        [JsonObject][Serializable]
        public class ObesityAdultPrevalenceRate
        {
            public string text;
        }
        [JsonObject][Serializable]
        public class ChildrenUnderTheAgeOf5YearsUnderweight
        {
            public string text;
        }
        [JsonObject][Serializable]
        public class EducationExpenditures
        {
            public string text;
        }
        [JsonObject][Serializable]
        public class Definition
        {
            public string text;
        }
        [JsonObject][Serializable]
        public class Literacy
        {
            public Definition definition;
            public string totalpopulation;
            public string male;
            public string female;
        }
        [JsonObject][Serializable]
        public class SchoolLifeExpectancyPrimaryToTertiaryEducation
        {
            public string total;
            public string male;
            public string female;
        }
        [JsonObject][Serializable]
        public class TotalNumber
        {
            public string text;
        }
        [JsonObject][Serializable]
        public class Percentage
        {
            public string text;
        }
        [JsonObject][Serializable]
        public class ChildLaborChildrenAges514
        {
            public TotalNumber totalnumber;
            public Percentage percentage;
        }
        [JsonObject][Serializable]
        public class UnemploymentYouthAges1524
        {
            public string total;
            public string male;
            public string female;
        }
        [Serializable]
        [JsonObject]
        public class PeopleAndSociety
        {
            public string Nationality;
            public string Ethnicgroups;
            public string Languages;
            public string Religions;
            public string Population;
            public string Medianage;
            public string Populationgrowthrate;
            public string Birthrate;
            public string Deathrate;
            public string Netmigrationrate;
            public string Urbanization;
            public string Majorurbanareaspopulation;
            public string Lifeexpectancyatbirth;
            public string Totalfertilityrate;
            public string Contraceptiveprevalencerate;
            public string Healthexpenditures;
            public string Physiciansdensity;
            public string Hospitalbeddensity;
            public string Drinkingwatersource;
            public string Sanitationfacilityaccess;
            public string HIVAIDSadultprevalencerate;
            public string HIVAIDSpeoplelivingwith;
            public string Obesityadultprevalencerate;
            public string Educationexpenditures;
            public string SchoolLifeExpectancy;
            public string Literacy;
        }
        [JsonObject][Serializable]
        public class ConventionalLongForm
        {
            public string text;
        }
        [JsonObject][Serializable]
        public class ConventionalShortForm
        {
            public string text;
        }
        [JsonObject][Serializable]
        public class LocalLongForm
        {
            public string text;
        }
        [JsonObject][Serializable]
        public class LocalShortForm
        {
            public string text;
        }
        [JsonObject][Serializable]
        public class GovernmentType
        {
            public string text;
        }
        [JsonObject][Serializable]
        public class Name
        {
            public string text;
        }


        [JsonObject][Serializable]
        public class TimeDifference
        {
            public string text;
        }
        [JsonObject][Serializable]
        public class Capital
        {
            public string text;
        }
        [JsonObject][Serializable]
        public class AdministrativeDivisions
        {
            public string text;
        }
        [JsonObject][Serializable]
        public class Independence
        {
            public string text;
        }
        [JsonObject][Serializable]
        public class NationalHoliday
        {
            public string text;
        }
        [JsonObject][Serializable]
        public class Constitution
        {
            public string text;
        }
        [JsonObject][Serializable]
        public class LegalSystem
        {
            public string text;
        }
        [JsonObject][Serializable]
        public class InternationalLawOrganizationParticipation
        {
            public string text;
        }
        [JsonObject][Serializable]
        public class BirthrightCitizenship
        {
            public string text;
        }
        [JsonObject][Serializable]
        public class DualCitizenshipRecognized
        {
            public string text;
        }
        [JsonObject][Serializable]
        public class ResidencyRequirementForNaturalization
        {
            public string text;
        }
        [JsonObject][Serializable]
        public class Citizenship
        {
            public string birthrightcitizenship;
            public string dualcitizenshiprecognized;
            public string residencyrequirementfornaturalization;
        }
        [JsonObject][Serializable]
        public class Suffrage
        {
            public string text;
        }
        [JsonObject][Serializable]
        public class ChiefOfState
        {
            public string text;
        }
        [JsonObject][Serializable]
        public class HeadOfGovernment
        {
            public string text;
        }
        [JsonObject][Serializable]
        public class Cabinet
        {
            public string text;
        }
        [JsonObject][Serializable]
        public class ElectionsAppointments
        {
            public string text;
        }
        [JsonObject][Serializable]
        public class ElectionResults
        {
            public string text;
        }
        [JsonObject][Serializable]
        public class ExecutiveBranch
        {
            public string chiefofstate;
            public string headofgovernment;
            public string cabinet;
            public string electionsappointments;
            public string electionresults;
        }
        [JsonObject][Serializable]

        public class Description
        {
            public string text;
        }
        [JsonObject][Serializable]
        public class Elections
        {
            public string text;
        }
        [JsonObject][Serializable]
        public class LegislativeBranch
        {
            public string description;
            public string elections;
            public string electionresults;
        }
        [JsonObject][Serializable]
        public class HighestCourtS
        {
            public string text;
        }
        [JsonObject][Serializable]
        public class JudgeSelectionAndTermOfOffice
        {
            public string text;
        }
        [JsonObject][Serializable]
        public class SubordinateCourts
        {
            public string text;
        }
        [JsonObject][Serializable]
        public class JudicialBranch
        {
            public string highestcourt;
            public string subordinatecourts;
        }
        [JsonObject][Serializable]
        public class PoliticalPartiesAndLeaders
        {
            public string text;
        }
        [JsonObject][Serializable]
        public class PoliticalPressureGroupsAndLeaders
        {
            public string text;
        }
        [JsonObject][Serializable]
        public class InternationalOrganizationParticipation
        {
            public string text;
        }
        [JsonObject][Serializable]
        public class ChiefOfMission
        {
            public string text;
        }
        [JsonObject][Serializable]
        public class Chancery
        {
            public string text;
        }
        [JsonObject][Serializable]
        public class Telephone
        {
            public string text;
        }
        [JsonObject][Serializable]
        public class FAX
        {
            public string text;
        }
        [JsonObject][Serializable]
        public class ConsulateSGeneral
        {
            public string text;
        }
        [JsonObject][Serializable]
        public class DiplomaticRepresentationInTheUS
        {
            public string chiefofmission;
        }
        [JsonObject][Serializable]
        public class Embassy
        {
            public string text;
        }
        [JsonObject][Serializable]
        public class MailingAddress
        {
            public string text;
        }
        [JsonObject][Serializable]
        public class FlagDescription
        {
            public string text;
        }





        [Serializable]
        [JsonObject]
        public class Government
        {
            public string GovernmentShortName;
            public string GovernmentLongName;
            public string Governmenttype;
            public string Capital;
            public string Administrativedivisions;
            public string Independence;
            public string Nationalholiday;
            public string Constitution;
            public string Legalsystem;
            public string Internationallaworganizationparticipation;
            public string Citizenship;
            public string Suffrage;
            public ExecutiveBranch Executivebranch;
            public LegislativeBranch Legislativebranch;
            public JudicialBranch Judicialbranch;
            public PoliticalPartiesAndLeaders Politicalpartiesandleaders;
            public PoliticalPressureGroupsAndLeaders Politicalpressuregroupsandleaders;


        }
        [JsonObject][Serializable]
        public class EconomyOverview
        {
            public string text;
        }
        [JsonObject][Serializable]
        public class GDPPurchasingPowerParity
        {
            public string text;
        }
        [JsonObject][Serializable]
        public class GDPOfficialExchangeRate
        {
            public string text;
        }
        [JsonObject][Serializable]
        public class GDPRealGrowthRate
        {
            public string text;
        }
        [JsonObject][Serializable]
        public class GDPPerCapitaPPP
        {
            public string text;
        }
        [JsonObject][Serializable]
        public class GrossNationalSaving
        {
            public string text;
        }
        [JsonObject][Serializable]
        public class HouseholdConsumption
        {
            public string text;
        }
        [JsonObject][Serializable]
        public class GovernmentConsumption
        {
            public string text;
        }
        [JsonObject][Serializable]
        public class InvestmentInFixedCapital
        {
            public string text;
        }
        [JsonObject][Serializable]
        public class InvestmentInInventories
        {
            public string text;
        }
        [JsonObject][Serializable]
        public class ExportsOfGoodsAndServices
        {
            public string text;
        }
        [JsonObject][Serializable]
        public class ImportsOfGoodsAndServices
        {
            public string text;
        }
        [JsonObject][Serializable]
        public class GDPCompositionByEndUse
        {
            public string householdconsumption;
            public string governmentconsumption;
            public string investmentinfixedcapital;
            public string investmentininventories;
            public string exportsofgoodsandservices;
            public string importsofgoodsandservices;
        }
        [JsonObject][Serializable]
        public class Agriculture
        {
            public string text;
        }
        [JsonObject][Serializable]
        public class Industry
        {
            public string text;
        }
        [JsonObject][Serializable]
        public class Services
        {
            public string text;
        }
        [JsonObject][Serializable]
        public class GDPCompositionBySectorOfOrigin
        {
            public string agriculture;
            public string industry;
            public string services;
        }
        [JsonObject][Serializable]
        public class AgricultureProducts
        {
            public string text;
        }
        [JsonObject][Serializable]
        public class Industries
        {
            public string text;
        }
        [JsonObject][Serializable]
        public class IndustrialProductionGrowthRate
        {
            public string text;
        }
        [JsonObject][Serializable]
        public class LaborForce
        {
            public string text;
        }
        [JsonObject][Serializable]
        public class ConstructionAndPublicWorks
        {
            public string text;
        }
        [JsonObject][Serializable]
        public class Trade
        {
            public string text;
        }

        [JsonObject][Serializable]
        public class LaborForceByOccupation
        {
            public string agriculture;
            public string industry;
            public ConstructionAndPublicWorks constructionand;
            public Trade trade;
            public Government government;
            public string other;
        }
        [JsonObject][Serializable]
        public class UnemploymentRate
        {
            public string text;
        }
        [JsonObject][Serializable]
        public class PopulationBelowPovertyLine
        {
            public string text;
        }
        [JsonObject][Serializable]
        public class Lowest10
        {
            public string text;
        }
        [JsonObject][Serializable]
        public class Highest10
        {
            public string text;
        }




        [JsonObject][Serializable]
        public class Revenues
        {
            public string text;
        }
        [JsonObject][Serializable]
        public class Expenditures
        {
            public string text;
        }
        [JsonObject][Serializable]
        public class Budget
        {
            public Revenues revenues;
            public Expenditures expenditures;
        }
        [JsonObject][Serializable]
        public class TaxesAndOtherRevenues
        {
            public string text;
        }
        [JsonObject][Serializable]
        public class BudgetSurplusOrDeficit
        {
            public string text;
        }
        [JsonObject][Serializable]
        public class PublicDebt
        {
            public string text;
        }
        [JsonObject][Serializable]
        public class FiscalYear
        {
            public string text;
        }
        [JsonObject][Serializable]
        public class InflationRateConsumerPrices
        {
            public string text;
        }
        [JsonObject][Serializable]
        public class CentralBankDiscountRate
        {
            public string text;
        }
        [JsonObject][Serializable]
        public class CommercialBankPrimeLendingRate
        {
            public string text;
        }
        [JsonObject][Serializable]
        public class StockOfNarrowMoney
        {
            public string text;
        }
        [JsonObject][Serializable]
        public class StockOfBroadMoney
        {
            public string text;
        }
        [JsonObject][Serializable]
        public class StockOfDomesticCredit
        {
            public string text;
        }
        [JsonObject][Serializable]
        public class MarketValueOfPubliclyTradedShares
        {
            public string text;
        }
        [JsonObject][Serializable]
        public class CurrentAccountBalance
        {
            public string text;
        }
        [JsonObject][Serializable]
        public class Exports
        {
            public string text;
        }
        [JsonObject][Serializable]
        public class ExportsCommodities
        {
            public string text;
        }
        [JsonObject][Serializable]
        public class ExportsPartners
        {
            public string text;
        }
        [JsonObject][Serializable]
        public class Imports
        {
            public string text;
        }
        [JsonObject][Serializable]
        public class ImportsCommodities
        {
            public string text;
        }
        [JsonObject][Serializable]
        public class ImportsPartners
        {
            public string text;
        }
        [JsonObject][Serializable]
        public class ReservesOfForeignExchangeAndGold
        {
            public string text;
        }
        [JsonObject][Serializable]
        public class DebtExternal
        {
            public string text;
        }
        [JsonObject][Serializable]
        public class StockOfDirectForeignInvestmentAtHome
        {
            public string text;
        }
        [JsonObject][Serializable]
        public class StockOfDirectForeignInvestmentAbroad
        {
            public string text;
        }
        [JsonObject][Serializable]
        public class ExchangeRates
        {
            public string text;
        }

        [Serializable]
        [JsonObject]
        public class Economy
        {
            public string Economyoverview;
            public double GDPpurchasingpowerparity;
            public double GDPofficialexchangerate;
            public string GDPrealgrowthrate;
            public string GDPpercapita;
            public string Grossnationalsaving;
            public string GDPcomposition;
            public string GDPcompositionsectoroforigin;
            public string Agricultureproducts;
            public string Industries;
            public string Industrialproductiongrowthrate;
            public string Laborforce;
            public string Laborforcebyoccupation;
            public string Unemploymentrate;
            public string Populationbelowpovertyline;
            public string Householdincomeorconsumptionbypercentageshare;
            public string DistributionoffamilyincomeGiniindex;
            public string Budget;
            public string Taxesandotherrevenues;
            public string Budgetsurplus;
            public string Publicdebt;
            public string Fiscalyear;
            public string Inflationrate;
            public string Centralbankdiscountrate;
            public string Commercialbankprimelendingrate;
            public string Stockofnarrowmoney;
            public string Stockofbroadmoney;
            public string Stockofdomesticcredit;
            public string Marketvalueofpubliclytradedshares;
            public string Currentaccountbalance;
            public string Exports;
            public string Exportscommodities;
            public string Exportspartners;
            public string Imports;
            public string Importscommodities;
            public string Importspartners;
            public string Reservesofforeignexchangeandgold;
            public string Debtexternal;
            public string Stockofdirectforeigninvestmentathome;
            public string Stockofdirectforeigninvestmentabroad;
            public string Exchangerates;
        }
        [JsonObject][Serializable]
        public class ElectricityProduction
        {
            public string text;
        }
        [JsonObject][Serializable]
        public class ElectricityConsumption
        {
            public string text;
        }
        [JsonObject][Serializable]
        public class ElectricityExports
        {
            public string text;
        }
        [JsonObject][Serializable]
        public class ElectricityImports
        {
            public string text;
        }
        [JsonObject][Serializable]
        public class ElectricityInstalledGeneratingCapacity
        {
            public string text;
        }
        [JsonObject][Serializable]
        public class ElectricityFromFossilFuels
        {
            public string text;
        }
        [JsonObject][Serializable]
        public class ElectricityFromNuclearFuels
        {
            public string text;
        }
        [JsonObject][Serializable]
        public class ElectricityFromHydroelectricPlants
        {
            public string text;
        }
        [JsonObject][Serializable]
        public class ElectricityFromOtherRenewableSources
        {
            public string text;
        }
        [JsonObject][Serializable]
        public class CrudeOilProduction
        {
            public string text;
        }
        [JsonObject][Serializable]
        public class CrudeOilExports
        {
            public string text;
        }
        [JsonObject][Serializable]
        public class CrudeOilImports
        {
            public string text;
        }
        [JsonObject][Serializable]
        public class CrudeOilProvedReserves
        {
            public string text;
        }
        [JsonObject][Serializable]
        public class RefinedPetroleumProductsProduction
        {
            public string text;
        }
        [JsonObject][Serializable]
        public class RefinedPetroleumProductsConsumption
        {
            public string text;
        }
        [JsonObject][Serializable]
        public class RefinedPetroleumProductsExports
        {
            public string text;
        }
        [JsonObject][Serializable]
        public class RefinedPetroleumProductsImports
        {
            public string text;
        }
        [JsonObject][Serializable]
        public class NaturalGasProduction
        {
            public string text;
        }
        [JsonObject][Serializable]
        public class NaturalGasConsumption
        {
            public string text;
        }
        [JsonObject][Serializable]
        public class NaturalGasExports
        {
            public string text;
        }
        [JsonObject][Serializable]
        public class NaturalGasImports
        {
            public string text;
        }
        [JsonObject][Serializable]
        public class NaturalGasProvedReserves
        {
            public string text;
        }
        [JsonObject][Serializable]
        public class CarbonDioxideEmissionsFromConsumptionOfEnergy
        {
            public string text;
        }
        [Serializable]
        [JsonObject]
        public class Energy
        {
            public ElectricityProduction Electricityproduction;
            public ElectricityConsumption Electricityconsumption;
            public ElectricityExports Electricityexports;
            public ElectricityImports Electricitymports;
            public ElectricityInstalledGeneratingCapacity Electricityinstalledgeneratingcapacity;
            public ElectricityFromFossilFuels Electricityfromfossilfuels;
            public ElectricityFromNuclearFuels Electricityfromnuclearfuels;
            public ElectricityFromHydroelectricPlants Electricityfromhydroelectricplants;
            public ElectricityFromOtherRenewableSources Electricityfromotherrenewablesources;
            public CrudeOilProduction Crudeoilproduction;
            public CrudeOilExports Crudeoilexports;
            public CrudeOilImports Crudeoilimports;
            public CrudeOilProvedReserves Crudeoilprovedreserves;
            public RefinedPetroleumProductsProduction Refinedpetroleumproductsproduction;
            public RefinedPetroleumProductsConsumption Refinedpetroleumproductsconsumption;
            public RefinedPetroleumProductsExports Refinedpetroleumproductsexports;
            public RefinedPetroleumProductsImports Refinedpetroleumproductsimports;
            public NaturalGasProduction Naturalgasproduction;
            public NaturalGasConsumption Naturalgasconsumption;
            public NaturalGasExports Naturalgasexports;
            public NaturalGasImports Naturalgasimports;
            public NaturalGasProvedReserves Naturalgasprovedreserves;
            public CarbonDioxideEmissionsFromConsumptionOfEnergy Carbondioxideemissionsfromconsumptionofenergy;
        }
        [JsonObject][Serializable]
        public class TotalSubscriptions
        {
            public string text;
        }
        [JsonObject][Serializable]
        public class SubscriptionsPer100Inhabitants
        {
            public string text;
        }
        [JsonObject][Serializable]
        public class TelephonesFixedLines
        {
            public TotalSubscriptions totalsubscriptions;
            public SubscriptionsPer100Inhabitants subscriptionsper100inhabitants;
        }
        [JsonObject][Serializable]
        public class TelephonesMobileCellular
        {
            public string total;
            public string subscriptionsper100inhabitants;
        }
        [JsonObject][Serializable]
        public class GeneralAssessment
        {
            public string text;
        }
        [JsonObject][Serializable]
        public class Domestic
        {
            public string text;
        }
        [JsonObject][Serializable]
        public class International
        {
            public string text;
        }
        [JsonObject][Serializable]
        public class TelephoneSystem
        {
            public GeneralAssessment generalassessment;
            public Domestic domestic;
            public International international;
        }
        [JsonObject][Serializable]
        public class BroadcastMedia
        {
            public string text;
        }
        [JsonObject][Serializable]
        public class RadioBroadcastStations
        {
            public string text;
        }
        [JsonObject][Serializable]
        public class TelevisionBroadcastStations
        {
            public string text;
        }
        [JsonObject][Serializable]
        public class InternetCountryCode
        {
            public string text;
        }
        [JsonObject][Serializable]
        public class PercentOfPopulation
        {
            public string text;
        }
        [JsonObject][Serializable]
        public class InternetUsers
        {
            public string total;
            public PercentOfPopulation percentofpopulation;
        }
        [Serializable]
        [JsonObject]
        public class Communications
        {
            public TelephonesFixedLines Telephonesfixedlines;
            public TelephonesMobileCellular Telephonesmobilecellular;
            public TelephoneSystem Telephonesystem;
            public BroadcastMedia Broadcastmedia;
            public RadioBroadcastStations Radiobroadcaststations;
            public TelevisionBroadcastStations Televisionbroadcaststations;
            public InternetCountryCode Internetcountrycode;
            public InternetUsers Internetusers;
        }
        [JsonObject][Serializable]
        public class Airports
        {
            public string text;
        }
        [JsonObject][Serializable]
        public class Over3047M
        {
            public string text;
        }
        [JsonObject][Serializable]
        public class Over2438To3047M
        {
            public string text;
        }
        [JsonObject][Serializable]
        public class Over1524To2437M
        {
            public string text;
        }
        [JsonObject][Serializable]
        public class Over914To1523M
        {
            public string text;
        }
        [JsonObject][Serializable]
        public class Under914M
        {
            public string text;
        }
        [JsonObject][Serializable]
        public class AirportsWithPavedRunways
        {
            public string total;
            public Over3047M totalVeryBig;
            public Over2438To3047M totalBig;
            public Over1524To2437M totalMed;
            public Over914To1523M totalMedSmall;
            public Under914M under914m;
        }
        [JsonObject][Serializable]
        public class AirportsWithUnpavedRunways
        {
            public string total;
        }
        [JsonObject][Serializable]
        public class Heliports
        {
            public string text;
        }
        [JsonObject][Serializable]
        public class Pipelines
        {
            public string text;
        }
        [JsonObject][Serializable]
        public class StandardGauge
        {
            public string text;
        }
        [JsonObject][Serializable]
        public class NarrowGauge
        {
            public string text;
        }
        [JsonObject][Serializable]
        public class Railways
        {
            public string total;
            public StandardGauge standardgauge;
            public NarrowGauge narrowgauge;
        }
        [JsonObject][Serializable]
        public class Paved
        {
            public string text;
        }
        [JsonObject][Serializable]
        public class Unpaved
        {
            public string text;
        }
        [JsonObject][Serializable]
        public class Roadways
        {
            public string total;
            public Paved paved;
            public Unpaved unpaved;
        }
        [JsonObject][Serializable]
        public class ByType
        {
            public string text;
        }
        [JsonObject][Serializable]
        public class ForeignOwned
        {
            public string text;
        }
        [JsonObject][Serializable]
        public class MerchantMarine
        {
            public string total;
            public ByType bytype;
            public ForeignOwned foreignowned;
        }
        [JsonObject][Serializable]
        public class MajorSeaportS
        {
            public string text;
        }
        [JsonObject][Serializable]
        public class LNGTerminalSExport
        {
            public string text;
        }
        [JsonObject][Serializable]
        public class PortsAndTerminals
        {
            public MajorSeaportS majorseaport;
            public LNGTerminalSExport LNGterminal;
        }
        [Serializable]
        [JsonObject]
        public class Transportation
        {
            public Airports Airports;
            public AirportsWithPavedRunways Airportswithpavedrunways;
            public AirportsWithUnpavedRunways Airportswithunpavedrunways;
            public Heliports Heliports;
            public Pipelines Pipelines;
            public Railways Railways;
            public Roadways Roadways;
            public MerchantMarine Merchantmarine;
            public PortsAndTerminals Portsandterminals;
        }
        [JsonObject][Serializable]
        public class MilitaryBranches
        {
            public string text;
        }
        [JsonObject][Serializable]
        public class MilitaryServiceAgeAndObligation
        {
            public string text;
        }
        [JsonObject][Serializable]
        public class MalesAge1649
        {
            public string text;
        }
        [JsonObject][Serializable]
        public class FemalesAge1649
        {
            public string text;
        }
        [JsonObject][Serializable]
        public class ManpowerAvailableForMilitaryService
        {
            public MalesAge1649 malesage1649;
            public FemalesAge1649 femalesage1649;
        }
        [JsonObject][Serializable]
        public class ManpowerFitForMilitaryService
        {
            public string malesage1649;
            public string femalesage1649;
        }
        [JsonObject][Serializable]
        public class ManpowerReachingMilitarilySignificantAgeAnnually
        {
            public string male;
            public string female;
        }
     
        [JsonObject][Serializable]
        public class MilitaryExpenditures
        {
            public string text;
        }
        
        [JsonObject][Serializable]
        public class Military
        {
            public string Militarybranches;
            public bool HasArmy;
            public bool HasAirForce;
            public bool HasMarines;
            public bool HasNavy;
            public string Militaryserviceageandobligation;
            public bool Conscription;
            public string Manpoweravailableformilitaryservice;
            public string Manpowerfitformilitaryservice;
            public string Manpowerreachingmilitarilysignificantageannually;
            public string Militaryexpenditures;
            public double MilitarySpendingRateOfBudget;
            public double MilitarySpendingPerYear;
            public bool HasGuardsCorps { get; internal set; }
            public bool HasCoastGuard { get; internal set; }
            public bool HasMissileDefense { get; internal set; }
            public bool HasInternalForce { get; internal set; }
            public bool HasStrageticForce { get; internal set; }
            public bool HasTriadForce { get; internal set; }
        }
        [JsonObject][Serializable]
        public class DisputesInternational
        {
            public string text;
        }
        [JsonObject][Serializable]
        public class RefugeesCountryOfOrigin
        {
            public string text;
        }
        [JsonObject][Serializable]
        public class IDPs
        {
            public string text;
        }
        [JsonObject][Serializable]
        public class RefugeesAndInternallyDisplacedPersons
        {
            public RefugeesCountryOfOrigin refugees;
            public IDPs IDPs;
        }
        [JsonObject][Serializable]
        public class CurrentSituation
        {
            public string text;
        }
        [JsonObject][Serializable]
        public class TierRating
        {
            public string text;
        }
        [JsonObject][Serializable]
        public class TraffickingInPersons
        {
            public CurrentSituation currentsituation;
            public TierRating tierrating;
        }
        [Serializable]
        [JsonObject]
        public class TransnationalIssues
        {
            public DisputesInternational Disputesinternational;
            public RefugeesAndInternallyDisplacedPersons Refugeesandinternallydisplacedpersons;
            public TraffickingInPersons Traffickinginpersons;
        }

        [Serializable]
        [JsonObject]
        public class CountryCiaDbObject 
        {

            [ContextMenuItem("Fill CIA Data", "FillCIAData")]
            [JsonProperty]
            public string CountryName;
            [JsonProperty]
            public string Introduction;
            public Geography Geography;
            public PeopleAndSociety PeopleandSociety;
            public Government Government;
            public Economy Economy;
            public Energy Energ;
            public Communications Communications;
            public Transportation Transportation;
            public Military Military;
            public TransnationalIssues TransnationalIssues;
            private void FillCIAData()
            {
                CountryName = "";
                Introduction = "";
            }
        }
    }
}
