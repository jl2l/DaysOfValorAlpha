﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


#pragma warning disable 0168 // variable declared but not used.
#pragma warning disable 0219 // variable assigned but not used.
#pragma warning disable 0414 // private field assigned but not used.

namespace Assets
{
    public class GlobalWarGameDbContext
    {
        public enum MapDisplayLevels
        {
            Relations = 0,
            Player = 1,
            SelectedCountry = 2,
            MiniMap = 3
        }

        public List<Tuple<CountryRelationsFactory.CountryBias, string, string[], CountryRelationsFactory.CountryGovernmentTypes>> GetCountriesByBias(CountryRelationsFactory.CountryBias bias)
        {
            return StubCountryBiasList().Where(e => e.Item1 == bias).ToList(); //TODO opmize this for static caching
        }

        public Tuple<CountryRelationsFactory.CountryBias, string, string[], CountryRelationsFactory.CountryGovernmentTypes> GetCountryBiasDetailsByName(string countryName)
        {
            var countryTuple = StubCountryBiasList().FirstOrDefault(e => e.Item2 == countryName);
            return countryTuple;
        }


        //this is to seed the intially relations matrix countries will have there bias and then there current allies 
        public static List<Tuple<CountryRelationsFactory.CountryBias, string, string[], CountryRelationsFactory.CountryGovernmentTypes>> StubCountryBiasList()
        {
            var rnd = new Random();
            var internalRegionFirst = new List<Tuple<CountryRelationsFactory.CountryBias, string, string[], CountryRelationsFactory.CountryGovernmentTypes>>();

            internalRegionFirst = new List<Tuple<CountryRelationsFactory.CountryBias, string, string[], CountryRelationsFactory.CountryGovernmentTypes>>
            {
                new Tuple<CountryRelationsFactory.CountryBias, string, string[],CountryRelationsFactory.CountryGovernmentTypes>(CountryRelationsFactory.CountryBias.islamInstable, "Afghanistan", new string[] {"United States of America", "China", "India" }, CountryRelationsFactory.CountryGovernmentTypes.IslamicRepublic),
                new Tuple<CountryRelationsFactory.CountryBias, string, string[],CountryRelationsFactory.CountryGovernmentTypes>(CountryRelationsFactory.CountryBias.formersoviet, "Albania", new string[] {"China", "United States of America",  "Russia"}, CountryRelationsFactory.CountryGovernmentTypes.IslamicRepublic),
                new Tuple<CountryRelationsFactory.CountryBias, string, string[],CountryRelationsFactory.CountryGovernmentTypes>(CountryRelationsFactory.CountryBias.islamStable, "Algeria", new string[] {"China", "United States of America",  "Russia"}, CountryRelationsFactory.CountryGovernmentTypes.IslamicRepublic),
                new Tuple<CountryRelationsFactory.CountryBias, string, string[],CountryRelationsFactory.CountryGovernmentTypes>(CountryRelationsFactory.CountryBias.africaninstable, "Angola", new string[] {"China", "United States of America",  "Russia"}, CountryRelationsFactory.CountryGovernmentTypes.IslamicRepublic),
                new Tuple<CountryRelationsFactory.CountryBias, string, string[],CountryRelationsFactory.CountryGovernmentTypes>(CountryRelationsFactory.CountryBias.formereuro, "Antigua and Barbuda", new string[] {"China", "United States of America",  "Russia"}, CountryRelationsFactory.CountryGovernmentTypes.IslamicRepublic),
                new Tuple<CountryRelationsFactory.CountryBias, string, string[],CountryRelationsFactory.CountryGovernmentTypes>(CountryRelationsFactory.CountryBias.southamericandemocracy, "Argentina", new string[] {"Brazil", "United States of America", "China" }, CountryRelationsFactory.CountryGovernmentTypes.ConstitutionalDemocracy),
                new Tuple<CountryRelationsFactory.CountryBias, string, string[],CountryRelationsFactory.CountryGovernmentTypes>(CountryRelationsFactory.CountryBias.formersovietAuthoratian, "Armenia", new string[] {"China", "United States of America",  "Russia"}, CountryRelationsFactory.CountryGovernmentTypes.IslamicRepublic),
                new Tuple<CountryRelationsFactory.CountryBias, string, string[],CountryRelationsFactory.CountryGovernmentTypes>(CountryRelationsFactory.CountryBias.formereuro, "Aruba", new string[] {"China", "United States of America",  "Russia"}, CountryRelationsFactory.CountryGovernmentTypes.IslamicRepublic),
                new Tuple<CountryRelationsFactory.CountryBias, string, string[],CountryRelationsFactory.CountryGovernmentTypes>(CountryRelationsFactory.CountryBias.formereuro, "Australia", new string[] {"China", "United States of America",  "Russia"}, CountryRelationsFactory.CountryGovernmentTypes.IslamicRepublic),
                new Tuple<CountryRelationsFactory.CountryBias, string, string[],CountryRelationsFactory.CountryGovernmentTypes>(CountryRelationsFactory.CountryBias.europeandemocracy, "Austria", new string[] {"China", "United States of America",  "Russia"}, CountryRelationsFactory.CountryGovernmentTypes.IslamicRepublic),
                new Tuple<CountryRelationsFactory.CountryBias, string, string[],CountryRelationsFactory.CountryGovernmentTypes>(CountryRelationsFactory.CountryBias.formersovietAuthoratian, "Azerbaijan", new string[] {"China", "United States of America",  "Russia"}, CountryRelationsFactory.CountryGovernmentTypes.IslamicRepublic),
                new Tuple<CountryRelationsFactory.CountryBias, string, string[],CountryRelationsFactory.CountryGovernmentTypes>(CountryRelationsFactory.CountryBias.citystateisland, "Andorra", new string[] {"China", "United States of America",  "Russia"}, CountryRelationsFactory.CountryGovernmentTypes.IslamicRepublic),
                 new Tuple<CountryRelationsFactory.CountryBias, string, string[],CountryRelationsFactory.CountryGovernmentTypes>(CountryRelationsFactory.CountryBias.superpower, "European Union", new string[] {"China", "United States of America",  "Russia"}, CountryRelationsFactory.CountryGovernmentTypes.IslamicRepublic),

                
                
                //B
                new Tuple<CountryRelationsFactory.CountryBias, string, string[],CountryRelationsFactory.CountryGovernmentTypes>(CountryRelationsFactory.CountryBias.formereuro, "Bahamas", new string[] {"China", "United States of America",  "Russia"}, CountryRelationsFactory.CountryGovernmentTypes.IslamicRepublic),
                new Tuple<CountryRelationsFactory.CountryBias, string, string[],CountryRelationsFactory.CountryGovernmentTypes>(CountryRelationsFactory.CountryBias.islamInstable, "Bahrain", new string[] {"China", "United States of America",  "Russia"}, CountryRelationsFactory.CountryGovernmentTypes.IslamicRepublic),
                new Tuple<CountryRelationsFactory.CountryBias, string, string[],CountryRelationsFactory.CountryGovernmentTypes>(CountryRelationsFactory.CountryBias.islamInstable, "Bangladesh", new string[] {"China", "United States of America",  "Russia"}, CountryRelationsFactory.CountryGovernmentTypes.IslamicRepublic),
                new Tuple<CountryRelationsFactory.CountryBias, string, string[],CountryRelationsFactory.CountryGovernmentTypes>(CountryRelationsFactory.CountryBias.formereuro, "Barbados", new string[] {"China", "United States of America",  "Russia"}, CountryRelationsFactory.CountryGovernmentTypes.IslamicRepublic),
                new Tuple<CountryRelationsFactory.CountryBias, string, string[],CountryRelationsFactory.CountryGovernmentTypes>(CountryRelationsFactory.CountryBias.formersovietAuthoratian, "Belarus", new string[] {"China", "United States of America",  "Russia"}, CountryRelationsFactory.CountryGovernmentTypes.IslamicRepublic),
                 new Tuple<CountryRelationsFactory.CountryBias, string, string[],CountryRelationsFactory.CountryGovernmentTypes>(CountryRelationsFactory.CountryBias.citystateisland, "Bermuda", new string[] {"China", "United States of America",  "Russia"}, CountryRelationsFactory.CountryGovernmentTypes.IslamicRepublic),

                new Tuple<CountryRelationsFactory.CountryBias, string, string[],CountryRelationsFactory.CountryGovernmentTypes>(CountryRelationsFactory.CountryBias.europeandemocracy, "Belgium", new string[] {"China", "United States of America",  "Russia"}, CountryRelationsFactory.CountryGovernmentTypes.IslamicRepublic),
                new Tuple<CountryRelationsFactory.CountryBias, string, string[],CountryRelationsFactory.CountryGovernmentTypes>(CountryRelationsFactory.CountryBias.southamericansocialist, "Belize", new string[] {"China", "United States of America",  "Russia"}, CountryRelationsFactory.CountryGovernmentTypes.IslamicRepublic),
                new Tuple<CountryRelationsFactory.CountryBias, string, string[],CountryRelationsFactory.CountryGovernmentTypes>(CountryRelationsFactory.CountryBias.africaninstable, "Benin", new string[] {"China", "United States of America",  "Russia"}, CountryRelationsFactory.CountryGovernmentTypes.IslamicRepublic),
                new Tuple<CountryRelationsFactory.CountryBias, string, string[],CountryRelationsFactory.CountryGovernmentTypes>(CountryRelationsFactory.CountryBias.chinaAndAllies, "Bhutan", new string[] {"China", "United States of America",  "Russia"}, CountryRelationsFactory.CountryGovernmentTypes.IslamicRepublic),
                new Tuple<CountryRelationsFactory.CountryBias, string, string[],CountryRelationsFactory.CountryGovernmentTypes>(CountryRelationsFactory.CountryBias.southamericansocialist, "Bolivia", new string[] {"China", "United States of America",  "Russia"}, CountryRelationsFactory.CountryGovernmentTypes.IslamicRepublic),
                new Tuple<CountryRelationsFactory.CountryBias, string, string[],CountryRelationsFactory.CountryGovernmentTypes>(CountryRelationsFactory.CountryBias.formersoviet, "Bosnia and Herzegovina", new string[] {"China", "United States of America",  "Russia"}, CountryRelationsFactory.CountryGovernmentTypes.IslamicRepublic),
                new Tuple<CountryRelationsFactory.CountryBias, string, string[],CountryRelationsFactory.CountryGovernmentTypes>(CountryRelationsFactory.CountryBias.africanstable, "Botswana", new string[] {"China", "United States of America",  "Russia"}, CountryRelationsFactory.CountryGovernmentTypes.IslamicRepublic),
                new Tuple<CountryRelationsFactory.CountryBias, string, string[],CountryRelationsFactory.CountryGovernmentTypes>(CountryRelationsFactory.CountryBias.southamericandemocracy, "Brazil", new string[] {"China", "United States of America",  "Russia"}, CountryRelationsFactory.CountryGovernmentTypes.IslamicRepublic),
                new Tuple<CountryRelationsFactory.CountryBias, string, string[],CountryRelationsFactory.CountryGovernmentTypes>(CountryRelationsFactory.CountryBias.islamStable, "Brunei", new string[] {"China", "United States of America",  "Russia"}, CountryRelationsFactory.CountryGovernmentTypes.IslamicRepublic),
                new Tuple<CountryRelationsFactory.CountryBias, string, string[],CountryRelationsFactory.CountryGovernmentTypes>(CountryRelationsFactory.CountryBias.formersoviet, "Bulgaria", new string[] {"China", "United States of America",  "Russia"}, CountryRelationsFactory.CountryGovernmentTypes.IslamicRepublic),
                new Tuple<CountryRelationsFactory.CountryBias, string, string[],CountryRelationsFactory.CountryGovernmentTypes>(CountryRelationsFactory.CountryBias.africaninstable, "Burkina Faso", new string[] {"China", "United States of America",  "Russia"}, CountryRelationsFactory.CountryGovernmentTypes.IslamicRepublic),
                new Tuple<CountryRelationsFactory.CountryBias, string, string[],CountryRelationsFactory.CountryGovernmentTypes>(CountryRelationsFactory.CountryBias.chinaAndAllies, "Burma", new string[] {"China", "United States of America",  "Russia"}, CountryRelationsFactory.CountryGovernmentTypes.IslamicRepublic),
                new Tuple<CountryRelationsFactory.CountryBias, string, string[],CountryRelationsFactory.CountryGovernmentTypes>(CountryRelationsFactory.CountryBias.africaninstable, "Burundi", new string[] {"China", "United States of America",  "Russia"}, CountryRelationsFactory.CountryGovernmentTypes.IslamicRepublic),
                //C
                new Tuple<CountryRelationsFactory.CountryBias, string, string[],CountryRelationsFactory.CountryGovernmentTypes>(CountryRelationsFactory.CountryBias.citystateisland, "Cayman Islands", new string[] {"China", "United States of America",  "Russia"}, CountryRelationsFactory.CountryGovernmentTypes.IslamicRepublic),

                new Tuple<CountryRelationsFactory.CountryBias, string, string[],CountryRelationsFactory.CountryGovernmentTypes>(CountryRelationsFactory.CountryBias.chinaAndAllies, "Cambodia", new string[] {"China", "United States of America",  "Russia"}, CountryRelationsFactory.CountryGovernmentTypes.IslamicRepublic),
                new Tuple<CountryRelationsFactory.CountryBias, string, string[],CountryRelationsFactory.CountryGovernmentTypes>(CountryRelationsFactory.CountryBias.africaninstable, "Cameroon", new string[] {"China", "United States of America",  "Russia"}, CountryRelationsFactory.CountryGovernmentTypes.IslamicRepublic),
                new Tuple<CountryRelationsFactory.CountryBias, string, string[],CountryRelationsFactory.CountryGovernmentTypes>(CountryRelationsFactory.CountryBias.westerndemocracy, "Canada", new string[] {"China", "United States of America",  "Russia"}, CountryRelationsFactory.CountryGovernmentTypes.IslamicRepublic),
                new Tuple<CountryRelationsFactory.CountryBias, string, string[],CountryRelationsFactory.CountryGovernmentTypes>(CountryRelationsFactory.CountryBias.citystateisland, "Cape Verde", new string[] {"China", "United States of America",  "Russia"}, CountryRelationsFactory.CountryGovernmentTypes.IslamicRepublic),
               new Tuple<CountryRelationsFactory.CountryBias, string, string[],CountryRelationsFactory.CountryGovernmentTypes>(CountryRelationsFactory.CountryBias.citystateisland, "Cabo Verde", new string[] {"China", "United States of America",  "Russia"}, CountryRelationsFactory.CountryGovernmentTypes.IslamicRepublic),
                new Tuple<CountryRelationsFactory.CountryBias, string, string[],CountryRelationsFactory.CountryGovernmentTypes>(CountryRelationsFactory.CountryBias.africaninstable, "Central African Republic", new string[] {"China", "United States of America",  "Russia"}, CountryRelationsFactory.CountryGovernmentTypes.IslamicRepublic),
                new Tuple<CountryRelationsFactory.CountryBias, string, string[],CountryRelationsFactory.CountryGovernmentTypes>(CountryRelationsFactory.CountryBias.africaninstable, "Chad", new string[] {"China", "United States of America",  "Russia"}, CountryRelationsFactory.CountryGovernmentTypes.IslamicRepublic),
                new Tuple<CountryRelationsFactory.CountryBias, string, string[],CountryRelationsFactory.CountryGovernmentTypes>(CountryRelationsFactory.CountryBias.southamericandemocracy, "Chile", new string[] {"China", "United States of America",  "Russia"}, CountryRelationsFactory.CountryGovernmentTypes.IslamicRepublic),
                new Tuple<CountryRelationsFactory.CountryBias, string, string[],CountryRelationsFactory.CountryGovernmentTypes>(CountryRelationsFactory.CountryBias.chinaAndAllies, "China", new string[] {"China", "United States of America",  "Russia"}, CountryRelationsFactory.CountryGovernmentTypes.IslamicRepublic),
                new Tuple<CountryRelationsFactory.CountryBias, string, string[],CountryRelationsFactory.CountryGovernmentTypes>(CountryRelationsFactory.CountryBias.southamericandemocracy, "Colombia", new string[] {"China", "United States of America",  "Russia"}, CountryRelationsFactory.CountryGovernmentTypes.IslamicRepublic),
                new Tuple<CountryRelationsFactory.CountryBias, string, string[],CountryRelationsFactory.CountryGovernmentTypes>(CountryRelationsFactory.CountryBias.formereuro, "Comoros", new string[] {"China", "United States of America",  "Russia"}, CountryRelationsFactory.CountryGovernmentTypes.IslamicRepublic),
                new Tuple<CountryRelationsFactory.CountryBias, string, string[],CountryRelationsFactory.CountryGovernmentTypes>(CountryRelationsFactory.CountryBias.southamericansocialist, "Costa Rica", new string[] {"China", "United States of America",  "Russia"}, CountryRelationsFactory.CountryGovernmentTypes.IslamicRepublic),
                new Tuple<CountryRelationsFactory.CountryBias, string, string[],CountryRelationsFactory.CountryGovernmentTypes>(CountryRelationsFactory.CountryBias.africaninstable, "Democratic Republic of the  Congo", new string[] {"China", "United States of America",  "Russia"}, CountryRelationsFactory.CountryGovernmentTypes.IslamicRepublic),
                new Tuple<CountryRelationsFactory.CountryBias, string, string[],CountryRelationsFactory.CountryGovernmentTypes>(CountryRelationsFactory.CountryBias.africaninstable, "DRC", new string[] {"China", "United States of America",  "Russia"}, CountryRelationsFactory.CountryGovernmentTypes.IslamicRepublic),
                new Tuple<CountryRelationsFactory.CountryBias, string, string[],CountryRelationsFactory.CountryGovernmentTypes>(CountryRelationsFactory.CountryBias.africaninstable, "Republic of the Congo", new string[] {"China", "United States of America",  "Russia"}, CountryRelationsFactory.CountryGovernmentTypes.IslamicRepublic),

                new Tuple<CountryRelationsFactory.CountryBias, string, string[],CountryRelationsFactory.CountryGovernmentTypes>(CountryRelationsFactory.CountryBias.africaninstable, "Congo (Brazzaville)", new string[] {"China", "United States of America",  "Russia"}, CountryRelationsFactory.CountryGovernmentTypes.IslamicRepublic),

                new Tuple<CountryRelationsFactory.CountryBias, string, string[],CountryRelationsFactory.CountryGovernmentTypes>(CountryRelationsFactory.CountryBias.africaninstable, "Cote d'Ivoire", new string[] {"China", "United States of America",  "Russia"}, CountryRelationsFactory.CountryGovernmentTypes.IslamicRepublic),
                new Tuple<CountryRelationsFactory.CountryBias, string, string[],CountryRelationsFactory.CountryGovernmentTypes>(CountryRelationsFactory.CountryBias.europeansocialdemocracy, "Croatia", new string[] {"China", "United States of America",  "Russia"}, CountryRelationsFactory.CountryGovernmentTypes.IslamicRepublic),
                new Tuple<CountryRelationsFactory.CountryBias, string, string[],CountryRelationsFactory.CountryGovernmentTypes>(CountryRelationsFactory.CountryBias.southamericansocialist, "Cuba", new string[] {"China", "United States of America",  "Russia"}, CountryRelationsFactory.CountryGovernmentTypes.IslamicRepublic),
                new Tuple<CountryRelationsFactory.CountryBias, string, string[],CountryRelationsFactory.CountryGovernmentTypes>(CountryRelationsFactory.CountryBias.formereuro, "Curacao", new string[] {"China", "United States of America",  "Russia"}, CountryRelationsFactory.CountryGovernmentTypes.IslamicRepublic),
                new Tuple<CountryRelationsFactory.CountryBias, string, string[],CountryRelationsFactory.CountryGovernmentTypes>(CountryRelationsFactory.CountryBias.europeandemocracy, "Cyprus", new string[] {"China", "United States of America",  "Russia"}, CountryRelationsFactory.CountryGovernmentTypes.IslamicRepublic),
                new Tuple<CountryRelationsFactory.CountryBias, string, string[],CountryRelationsFactory.CountryGovernmentTypes>(CountryRelationsFactory.CountryBias.europeandemocracy, "Czech Republic", new string[] {"China", "United States of America",  "Russia"}, CountryRelationsFactory.CountryGovernmentTypes.IslamicRepublic),
                //D
                new Tuple<CountryRelationsFactory.CountryBias, string, string[],CountryRelationsFactory.CountryGovernmentTypes>(CountryRelationsFactory.CountryBias.europeandemocracy, "Denmark", new string[] {"China", "United States of America",  "Russia"}, CountryRelationsFactory.CountryGovernmentTypes.IslamicRepublic),
                new Tuple<CountryRelationsFactory.CountryBias, string, string[],CountryRelationsFactory.CountryGovernmentTypes>(CountryRelationsFactory.CountryBias.islamStable, "Djibouti", new string[] {"China", "United States of America",  "Russia"}, CountryRelationsFactory.CountryGovernmentTypes.IslamicRepublic),
                new Tuple<CountryRelationsFactory.CountryBias, string, string[],CountryRelationsFactory.CountryGovernmentTypes>(CountryRelationsFactory.CountryBias.formereuro, "Dominica", new string[] {"China", "United States of America",  "Russia"}, CountryRelationsFactory.CountryGovernmentTypes.IslamicRepublic),
                new Tuple<CountryRelationsFactory.CountryBias, string, string[],CountryRelationsFactory.CountryGovernmentTypes>(CountryRelationsFactory.CountryBias.southamericandemocracy, "Dominican Republic", new string[] {"China", "United States of America",  "Russia"}, CountryRelationsFactory.CountryGovernmentTypes.IslamicRepublic),
                //E
                new Tuple<CountryRelationsFactory.CountryBias, string, string[],CountryRelationsFactory.CountryGovernmentTypes>(CountryRelationsFactory.CountryBias.formereuro, "East Timor", new string[] {"China", "United States of America",  "Russia"}, CountryRelationsFactory.CountryGovernmentTypes.IslamicRepublic),
                new Tuple<CountryRelationsFactory.CountryBias, string, string[],CountryRelationsFactory.CountryGovernmentTypes>(CountryRelationsFactory.CountryBias.southamericansocialist, "Ecuador", new string[] {"China", "United States of America",  "Russia"}, CountryRelationsFactory.CountryGovernmentTypes.IslamicRepublic),
                new Tuple<CountryRelationsFactory.CountryBias, string, string[],CountryRelationsFactory.CountryGovernmentTypes>(CountryRelationsFactory.CountryBias.islamStable, "Egypt", new string[] {"China", "United States of America",  "Russia"}, CountryRelationsFactory.CountryGovernmentTypes.IslamicRepublic),
                new Tuple<CountryRelationsFactory.CountryBias, string, string[],CountryRelationsFactory.CountryGovernmentTypes>(CountryRelationsFactory.CountryBias.southamericansocialist, "El Salvador", new string[] {"China", "United States of America",  "Russia"}, CountryRelationsFactory.CountryGovernmentTypes.IslamicRepublic),
                new Tuple<CountryRelationsFactory.CountryBias, string, string[],CountryRelationsFactory.CountryGovernmentTypes>(CountryRelationsFactory.CountryBias.africaninstable, "Equatorial Guinea", new string[] {"China", "United States of America",  "Russia"}, CountryRelationsFactory.CountryGovernmentTypes.IslamicRepublic),
                new Tuple<CountryRelationsFactory.CountryBias, string, string[],CountryRelationsFactory.CountryGovernmentTypes>(CountryRelationsFactory.CountryBias.africanstable, "Eritrea", new string[] {"China", "United States of America",  "Russia"}, CountryRelationsFactory.CountryGovernmentTypes.IslamicRepublic),
                new Tuple<CountryRelationsFactory.CountryBias, string, string[],CountryRelationsFactory.CountryGovernmentTypes>(CountryRelationsFactory.CountryBias.formersoviet, "Estonia", new string[] {"China", "United States of America",  "Russia"}, CountryRelationsFactory.CountryGovernmentTypes.IslamicRepublic),
                new Tuple<CountryRelationsFactory.CountryBias, string, string[],CountryRelationsFactory.CountryGovernmentTypes>(CountryRelationsFactory.CountryBias.africanstable, "Ethiopia", new string[] {"China", "United States of America",  "Russia"}, CountryRelationsFactory.CountryGovernmentTypes.IslamicRepublic),
                new Tuple<CountryRelationsFactory.CountryBias, string, string[],CountryRelationsFactory.CountryGovernmentTypes>(CountryRelationsFactory.CountryBias.citystateisland, "Fiji", new string[] {"China", "United States of America",  "Russia"}, CountryRelationsFactory.CountryGovernmentTypes.IslamicRepublic),
                 new Tuple<CountryRelationsFactory.CountryBias, string, string[],CountryRelationsFactory.CountryGovernmentTypes>(CountryRelationsFactory.CountryBias.citystateisland, "Falkland Islands", new string[] {"China", "United States of America",  "Russia"}, CountryRelationsFactory.CountryGovernmentTypes.IslamicRepublic),


                new Tuple<CountryRelationsFactory.CountryBias, string, string[],CountryRelationsFactory.CountryGovernmentTypes>(CountryRelationsFactory.CountryBias.europeansocialdemocracy, "Finland", new string[] {"China", "United States of America",  "Russia"}, CountryRelationsFactory.CountryGovernmentTypes.IslamicRepublic),
                new Tuple<CountryRelationsFactory.CountryBias, string, string[],CountryRelationsFactory.CountryGovernmentTypes>(CountryRelationsFactory.CountryBias.europeandemocracy, "France", new string[] {"China", "United States of America",  "Russia"}, CountryRelationsFactory.CountryGovernmentTypes.IslamicRepublic),
                new Tuple<CountryRelationsFactory.CountryBias, string, string[],CountryRelationsFactory.CountryGovernmentTypes>(CountryRelationsFactory.CountryBias.africaninstable, "Gabon", new string[] {"China", "United States of America",  "Russia"}, CountryRelationsFactory.CountryGovernmentTypes.IslamicRepublic),
                new Tuple<CountryRelationsFactory.CountryBias, string, string[],CountryRelationsFactory.CountryGovernmentTypes>(CountryRelationsFactory.CountryBias.africanstable, "Gambia", new string[] {"China", "United States of America",  "Russia"}, CountryRelationsFactory.CountryGovernmentTypes.IslamicRepublic),
                new Tuple<CountryRelationsFactory.CountryBias, string, string[],CountryRelationsFactory.CountryGovernmentTypes>(CountryRelationsFactory.CountryBias.formersoviet, "Georgia", new string[] {"China", "United States of America",  "Russia"}, CountryRelationsFactory.CountryGovernmentTypes.IslamicRepublic),
                new Tuple<CountryRelationsFactory.CountryBias, string, string[],CountryRelationsFactory.CountryGovernmentTypes>(CountryRelationsFactory.CountryBias.africanstable, "Ghana", new string[] {"China", "United States of America",  "Russia"}, CountryRelationsFactory.CountryGovernmentTypes.IslamicRepublic),
                 new Tuple<CountryRelationsFactory.CountryBias, string, string[],CountryRelationsFactory.CountryGovernmentTypes>(CountryRelationsFactory.CountryBias.westerndemocracy, "Germany", new string[] {"China", "United States of America",  "Russia"}, CountryRelationsFactory.CountryGovernmentTypes.IslamicRepublic),

                new Tuple<CountryRelationsFactory.CountryBias, string, string[],CountryRelationsFactory.CountryGovernmentTypes>(CountryRelationsFactory.CountryBias.europeandemocracy, "Greece", new string[] {"China", "United States of America",  "Russia"}, CountryRelationsFactory.CountryGovernmentTypes.IslamicRepublic),
                new Tuple<CountryRelationsFactory.CountryBias, string, string[],CountryRelationsFactory.CountryGovernmentTypes>(CountryRelationsFactory.CountryBias.formereuro, "Grenada", new string[] {"China", "United States of America",  "Russia"}, CountryRelationsFactory.CountryGovernmentTypes.IslamicRepublic),
                     new Tuple<CountryRelationsFactory.CountryBias, string, string[],CountryRelationsFactory.CountryGovernmentTypes>(CountryRelationsFactory.CountryBias.formereuro, "Greenland", new string[] {"China", "United States of America",  "Russia"}, CountryRelationsFactory.CountryGovernmentTypes.IslamicRepublic),

                new Tuple<CountryRelationsFactory.CountryBias, string, string[],CountryRelationsFactory.CountryGovernmentTypes>(CountryRelationsFactory.CountryBias.islamInstable, "Gaza Strip", new string[] {"China", "United States of America",  "Russia"}, CountryRelationsFactory.CountryGovernmentTypes.IslamicRepublic),

                new Tuple<CountryRelationsFactory.CountryBias, string, string[],CountryRelationsFactory.CountryGovernmentTypes>(CountryRelationsFactory.CountryBias.southamericansocialist, "Guatemala", new string[] {"China", "United States of America",  "Russia"}, CountryRelationsFactory.CountryGovernmentTypes.IslamicRepublic),
                new Tuple<CountryRelationsFactory.CountryBias, string, string[],CountryRelationsFactory.CountryGovernmentTypes>(CountryRelationsFactory.CountryBias.africaninstable, "Guinea", new string[] {"China", "United States of America",  "Russia"}, CountryRelationsFactory.CountryGovernmentTypes.IslamicRepublic),
                new Tuple<CountryRelationsFactory.CountryBias, string, string[],CountryRelationsFactory.CountryGovernmentTypes>(CountryRelationsFactory.CountryBias.africaninstable, "Guinea-Bissau", new string[] {"China", "United States of America",  "Russia"}, CountryRelationsFactory.CountryGovernmentTypes.IslamicRepublic),
                new Tuple<CountryRelationsFactory.CountryBias, string, string[],CountryRelationsFactory.CountryGovernmentTypes>(CountryRelationsFactory.CountryBias.southamericandemocracy, "Guyana", new string[] {"China", "United States of America",  "Russia"}, CountryRelationsFactory.CountryGovernmentTypes.IslamicRepublic),
                new Tuple<CountryRelationsFactory.CountryBias, string, string[],CountryRelationsFactory.CountryGovernmentTypes>(CountryRelationsFactory.CountryBias.southamericandemocracy, "Haiti", new string[] {"China", "United States of America",  "Russia"}, CountryRelationsFactory.CountryGovernmentTypes.IslamicRepublic),
                new Tuple<CountryRelationsFactory.CountryBias, string, string[],CountryRelationsFactory.CountryGovernmentTypes>(CountryRelationsFactory.CountryBias.citystateisland, "Holy See", new string[] {"China", "United States of America",  "Russia"}, CountryRelationsFactory.CountryGovernmentTypes.IslamicRepublic),
                new Tuple<CountryRelationsFactory.CountryBias, string, string[],CountryRelationsFactory.CountryGovernmentTypes>(CountryRelationsFactory.CountryBias.southamericansocialist, "Honduras", new string[] {"China", "United States of America",  "Russia"}, CountryRelationsFactory.CountryGovernmentTypes.IslamicRepublic),

                new Tuple<CountryRelationsFactory.CountryBias, string, string[],CountryRelationsFactory.CountryGovernmentTypes>(CountryRelationsFactory.CountryBias.europeandemocracy, "Hungary", new string[] {"China", "United States of America",  "Russia"}, CountryRelationsFactory.CountryGovernmentTypes.IslamicRepublic),
                new Tuple<CountryRelationsFactory.CountryBias, string, string[],CountryRelationsFactory.CountryGovernmentTypes>(CountryRelationsFactory.CountryBias.europeandemocracy, "Iceland", new string[] {"China", "United States of America",  "Russia"}, CountryRelationsFactory.CountryGovernmentTypes.IslamicRepublic),
                new Tuple<CountryRelationsFactory.CountryBias, string, string[],CountryRelationsFactory.CountryGovernmentTypes>(CountryRelationsFactory.CountryBias.regionalpower, "India", new string[] {"China", "United States of America",  "Russia"}, CountryRelationsFactory.CountryGovernmentTypes.IslamicRepublic),
                new Tuple<CountryRelationsFactory.CountryBias, string, string[],CountryRelationsFactory.CountryGovernmentTypes>(CountryRelationsFactory.CountryBias.islamStable, "Indonesia", new string[] {"China", "United States of America",  "Russia"}, CountryRelationsFactory.CountryGovernmentTypes.IslamicRepublic),
                new Tuple<CountryRelationsFactory.CountryBias, string, string[],CountryRelationsFactory.CountryGovernmentTypes>(CountryRelationsFactory.CountryBias.islamStable, "Iran", new string[] {"China", "United States of America",  "Russia"},  CountryRelationsFactory.CountryGovernmentTypes.IslamicRepublic),
                new Tuple<CountryRelationsFactory.CountryBias, string, string[],CountryRelationsFactory.CountryGovernmentTypes>(CountryRelationsFactory.CountryBias.islamInstable, "Iraq", new string[] {"China", "United States of America",  "Russia"},  CountryRelationsFactory.CountryGovernmentTypes.IslamicRepublic),
                new Tuple<CountryRelationsFactory.CountryBias, string, string[],CountryRelationsFactory.CountryGovernmentTypes>(CountryRelationsFactory.CountryBias.europeandemocracy, "Ireland", new string[] {"China", "United States of America",  "Russia"}, CountryRelationsFactory.CountryGovernmentTypes.IslamicRepublic),

                new Tuple<CountryRelationsFactory.CountryBias, string, string[],CountryRelationsFactory.CountryGovernmentTypes>(CountryRelationsFactory.CountryBias.citystateisland, "Israel", new string[] {"China", "United States of America",  "Russia"}, CountryRelationsFactory.CountryGovernmentTypes.IslamicRepublic),
                new Tuple<CountryRelationsFactory.CountryBias, string, string[],CountryRelationsFactory.CountryGovernmentTypes>(CountryRelationsFactory.CountryBias.europeandemocracy, "Italy", new string[] {"China", "United States of America",  "Russia"}, CountryRelationsFactory.CountryGovernmentTypes.IslamicRepublic),
                new Tuple<CountryRelationsFactory.CountryBias, string, string[],CountryRelationsFactory.CountryGovernmentTypes>(CountryRelationsFactory.CountryBias.formereuro, "Jamaica", new string[] {"China", "United States of America",  "Russia"}, CountryRelationsFactory.CountryGovernmentTypes.IslamicRepublic),
                new Tuple<CountryRelationsFactory.CountryBias, string, string[],CountryRelationsFactory.CountryGovernmentTypes>(CountryRelationsFactory.CountryBias.notchinaAsian, "Japan", new string[] {"China", "United States of America",  "Russia"}, CountryRelationsFactory.CountryGovernmentTypes.IslamicRepublic),
                new Tuple<CountryRelationsFactory.CountryBias, string, string[],CountryRelationsFactory.CountryGovernmentTypes>(CountryRelationsFactory.CountryBias.islamStable, "Jordan", new string[] {"China", "United States of America",  "Russia"}, CountryRelationsFactory.CountryGovernmentTypes.IslamicRepublic),
                new Tuple<CountryRelationsFactory.CountryBias, string, string[],CountryRelationsFactory.CountryGovernmentTypes>(CountryRelationsFactory.CountryBias.formersoviet, "Kazakhstan", new string[] {"China", "United States of America",  "Russia"}, CountryRelationsFactory.CountryGovernmentTypes.IslamicRepublic),
                new Tuple<CountryRelationsFactory.CountryBias, string, string[],CountryRelationsFactory.CountryGovernmentTypes>(CountryRelationsFactory.CountryBias.africanstable, "Kenya", new string[] {"China", "United States of America",  "Russia"}, CountryRelationsFactory.CountryGovernmentTypes.IslamicRepublic),
                new Tuple<CountryRelationsFactory.CountryBias, string, string[],CountryRelationsFactory.CountryGovernmentTypes>(CountryRelationsFactory.CountryBias.chinaAndAllies, "North Korea", new string[] {"China", "United States of America",  "Russia"}, CountryRelationsFactory.CountryGovernmentTypes.IslamicRepublic),
                new Tuple<CountryRelationsFactory.CountryBias, string, string[],CountryRelationsFactory.CountryGovernmentTypes>(CountryRelationsFactory.CountryBias.notchinaAsian, "South Korea", new string[] {"China", "United States of America",  "Russia"}, CountryRelationsFactory.CountryGovernmentTypes.IslamicRepublic),
                new Tuple<CountryRelationsFactory.CountryBias, string, string[],CountryRelationsFactory.CountryGovernmentTypes>(CountryRelationsFactory.CountryBias.europeandemocracy, "Kosovo", new string[] {"China", "United States of America",  "Russia"}, CountryRelationsFactory.CountryGovernmentTypes.IslamicRepublic),
                new Tuple<CountryRelationsFactory.CountryBias, string, string[],CountryRelationsFactory.CountryGovernmentTypes>(CountryRelationsFactory.CountryBias.islamStable, "Kuwait", new string[] {"China", "United States of America",  "Russia"}, CountryRelationsFactory.CountryGovernmentTypes.IslamicRepublic),
                new Tuple<CountryRelationsFactory.CountryBias, string, string[],CountryRelationsFactory.CountryGovernmentTypes>(CountryRelationsFactory.CountryBias.formersoviet, "Kyrgyzstan", new string[] {"China", "United States of America",  "Russia"}, CountryRelationsFactory.CountryGovernmentTypes.IslamicRepublic),
                new Tuple<CountryRelationsFactory.CountryBias, string, string[],CountryRelationsFactory.CountryGovernmentTypes>(CountryRelationsFactory.CountryBias.chinaAndAllies, "Laos", new string[] {"China", "United States of America",  "Russia"}, CountryRelationsFactory.CountryGovernmentTypes.IslamicRepublic),
                new Tuple<CountryRelationsFactory.CountryBias, string, string[],CountryRelationsFactory.CountryGovernmentTypes>(CountryRelationsFactory.CountryBias.formersoviet, "Latvia", new string[] {"China", "United States of America",  "Russia"}, CountryRelationsFactory.CountryGovernmentTypes.IslamicRepublic),
                new Tuple<CountryRelationsFactory.CountryBias, string, string[],CountryRelationsFactory.CountryGovernmentTypes>(CountryRelationsFactory.CountryBias.islamInstable, "Lebanon", new string[] {"China", "United States of America",  "Russia"}, CountryRelationsFactory.CountryGovernmentTypes.IslamicRepublic),
                new Tuple<CountryRelationsFactory.CountryBias, string, string[],CountryRelationsFactory.CountryGovernmentTypes>(CountryRelationsFactory.CountryBias.africanstable, "Lesotho", new string[] {"China", "United States of America",  "Russia"}, CountryRelationsFactory.CountryGovernmentTypes.IslamicRepublic),
                new Tuple<CountryRelationsFactory.CountryBias, string, string[],CountryRelationsFactory.CountryGovernmentTypes>(CountryRelationsFactory.CountryBias.africanstable, "Liberia", new string[] {"China", "United States of America",  "Russia"}, CountryRelationsFactory.CountryGovernmentTypes.IslamicRepublic),
                new Tuple<CountryRelationsFactory.CountryBias, string, string[],CountryRelationsFactory.CountryGovernmentTypes>(CountryRelationsFactory.CountryBias.islamInstable, "Libya", new string[] {"China", "United States of America",  "Russia"}, CountryRelationsFactory.CountryGovernmentTypes.IslamicRepublic),
                new Tuple<CountryRelationsFactory.CountryBias, string, string[],CountryRelationsFactory.CountryGovernmentTypes>(CountryRelationsFactory.CountryBias.citystateisland, "Liechtenstein", new string[] {"China", "United States of America",  "Russia"}, CountryRelationsFactory.CountryGovernmentTypes.IslamicRepublic),
                new Tuple<CountryRelationsFactory.CountryBias, string, string[],CountryRelationsFactory.CountryGovernmentTypes>(CountryRelationsFactory.CountryBias.formersoviet, "Lithuania", new string[] {"China", "United States of America",  "Russia"}, CountryRelationsFactory.CountryGovernmentTypes.IslamicRepublic),
                new Tuple<CountryRelationsFactory.CountryBias, string, string[],CountryRelationsFactory.CountryGovernmentTypes>(CountryRelationsFactory.CountryBias.citystateisland, "Luxembourg", new string[] {"China", "United States of America",  "Russia"}, CountryRelationsFactory.CountryGovernmentTypes.IslamicRepublic),
                //M
                new Tuple<CountryRelationsFactory.CountryBias, string, string[],CountryRelationsFactory.CountryGovernmentTypes>(CountryRelationsFactory.CountryBias.citystateisland, "Macau", new string[] {"China", "United States of America",  "Russia"}, CountryRelationsFactory.CountryGovernmentTypes.IslamicRepublic),
                new Tuple<CountryRelationsFactory.CountryBias, string, string[],CountryRelationsFactory.CountryGovernmentTypes>(CountryRelationsFactory.CountryBias.formersoviet, "Macedonia", new string[] {"China", "United States of America",  "Russia"}, CountryRelationsFactory.CountryGovernmentTypes.IslamicRepublic),
                new Tuple<CountryRelationsFactory.CountryBias, string, string[],CountryRelationsFactory.CountryGovernmentTypes>(CountryRelationsFactory.CountryBias.africanstable, "Madagascar", new string[] {"China", "United States of America",  "Russia"}, CountryRelationsFactory.CountryGovernmentTypes.IslamicRepublic),
                new Tuple<CountryRelationsFactory.CountryBias, string, string[],CountryRelationsFactory.CountryGovernmentTypes>(CountryRelationsFactory.CountryBias.africaninstable, "Malawi", new string[] {"China", "United States of America",  "Russia"}, CountryRelationsFactory.CountryGovernmentTypes.IslamicRepublic),
                new Tuple<CountryRelationsFactory.CountryBias, string, string[],CountryRelationsFactory.CountryGovernmentTypes>(CountryRelationsFactory.CountryBias.islamStable, "Malaysia", new string[] {"China", "United States of America",  "Russia"}, CountryRelationsFactory.CountryGovernmentTypes.IslamicRepublic),
                new Tuple<CountryRelationsFactory.CountryBias, string, string[],CountryRelationsFactory.CountryGovernmentTypes>(CountryRelationsFactory.CountryBias.citystateisland, "Maldives", new string[] {"China", "United States of America",  "Russia"}, CountryRelationsFactory.CountryGovernmentTypes.IslamicRepublic),
                new Tuple<CountryRelationsFactory.CountryBias, string, string[],CountryRelationsFactory.CountryGovernmentTypes>(CountryRelationsFactory.CountryBias.civilwar, "Mali", new string[] {"China", "United States of America",  "Russia"}, CountryRelationsFactory.CountryGovernmentTypes.IslamicRepublic),
                new Tuple<CountryRelationsFactory.CountryBias, string, string[],CountryRelationsFactory.CountryGovernmentTypes>(CountryRelationsFactory.CountryBias.citystateisland, "Malta", new string[] {"China", "United States of America",  "Russia"}, CountryRelationsFactory.CountryGovernmentTypes.IslamicRepublic),
                new Tuple<CountryRelationsFactory.CountryBias, string, string[],CountryRelationsFactory.CountryGovernmentTypes>(CountryRelationsFactory.CountryBias.africaninstable, "Mauritania", new string[] {"China", "United States of America",  "Russia"}, CountryRelationsFactory.CountryGovernmentTypes.IslamicRepublic),
                new Tuple<CountryRelationsFactory.CountryBias, string, string[],CountryRelationsFactory.CountryGovernmentTypes>(CountryRelationsFactory.CountryBias.africanstable, "Mauritius", new string[] {"China", "United States of America",  "Russia"}, CountryRelationsFactory.CountryGovernmentTypes.IslamicRepublic),
                new Tuple<CountryRelationsFactory.CountryBias, string, string[],CountryRelationsFactory.CountryGovernmentTypes>(CountryRelationsFactory.CountryBias.southamericandemocracy, "Mexico", new string[] {"China", "United States of America",  "Russia"}, CountryRelationsFactory.CountryGovernmentTypes.IslamicRepublic),
                new Tuple<CountryRelationsFactory.CountryBias, string, string[],CountryRelationsFactory.CountryGovernmentTypes>(CountryRelationsFactory.CountryBias.citystateisland, "Micronesia", new string[] {"China", "United States of America",  "Russia"}, CountryRelationsFactory.CountryGovernmentTypes.IslamicRepublic),
                new Tuple<CountryRelationsFactory.CountryBias, string, string[],CountryRelationsFactory.CountryGovernmentTypes>(CountryRelationsFactory.CountryBias.formersoviet, "Moldova", new string[] {"China", "United States of America",  "Russia"}, CountryRelationsFactory.CountryGovernmentTypes.IslamicRepublic),
                new Tuple<CountryRelationsFactory.CountryBias, string, string[],CountryRelationsFactory.CountryGovernmentTypes>(CountryRelationsFactory.CountryBias.citystateisland, "Monaco", new string[] {"China", "United States of America",  "Russia"}, CountryRelationsFactory.CountryGovernmentTypes.IslamicRepublic),
                new Tuple<CountryRelationsFactory.CountryBias, string, string[],CountryRelationsFactory.CountryGovernmentTypes>(CountryRelationsFactory.CountryBias.chinaAndAllies, "Mongolia", new string[] {"China", "United States of America",  "Russia"}, CountryRelationsFactory.CountryGovernmentTypes.IslamicRepublic),
                new Tuple<CountryRelationsFactory.CountryBias, string, string[],CountryRelationsFactory.CountryGovernmentTypes>(CountryRelationsFactory.CountryBias.europeandemocracy, "Montenegro", new string[] {"China", "United States of America",  "Russia"}, CountryRelationsFactory.CountryGovernmentTypes.IslamicRepublic),
                new Tuple<CountryRelationsFactory.CountryBias, string, string[],CountryRelationsFactory.CountryGovernmentTypes>(CountryRelationsFactory.CountryBias.islamStable, "Morocco", new string[] {"China", "United States of America",  "Russia"}, CountryRelationsFactory.CountryGovernmentTypes.IslamicRepublic),
                new Tuple<CountryRelationsFactory.CountryBias, string, string[],CountryRelationsFactory.CountryGovernmentTypes>(CountryRelationsFactory.CountryBias.africanstable, "Mozambique", new string[] {"China", "United States of America",  "Russia"}, CountryRelationsFactory.CountryGovernmentTypes.IslamicRepublic),
                new Tuple<CountryRelationsFactory.CountryBias, string, string[],CountryRelationsFactory.CountryGovernmentTypes>(CountryRelationsFactory.CountryBias.africanstable, "Namibia", new string[] {"China", "United States of America",  "Russia"}, CountryRelationsFactory.CountryGovernmentTypes.IslamicRepublic),
                new Tuple<CountryRelationsFactory.CountryBias, string, string[],CountryRelationsFactory.CountryGovernmentTypes>(CountryRelationsFactory.CountryBias.citystateisland, "Nauru", new string[] {"China", "United States of America",  "Russia"}, CountryRelationsFactory.CountryGovernmentTypes.IslamicRepublic),
                new Tuple<CountryRelationsFactory.CountryBias, string, string[],CountryRelationsFactory.CountryGovernmentTypes>(CountryRelationsFactory.CountryBias.notchinaAsian, "Nepal", new string[] {"China", "United States of America",  "Russia"}, CountryRelationsFactory.CountryGovernmentTypes.IslamicRepublic),
                new Tuple<CountryRelationsFactory.CountryBias, string, string[],CountryRelationsFactory.CountryGovernmentTypes>(CountryRelationsFactory.CountryBias.europeansocialdemocracy, "Netherlands", new string[] {"China", "United States of America",  "Russia"}, CountryRelationsFactory.CountryGovernmentTypes.IslamicRepublic),
                new Tuple<CountryRelationsFactory.CountryBias, string, string[],CountryRelationsFactory.CountryGovernmentTypes>(CountryRelationsFactory.CountryBias.westerndemocracy, "New Zealand", new string[] {"China", "United States of America",  "Russia"}, CountryRelationsFactory.CountryGovernmentTypes.IslamicRepublic),
                new Tuple<CountryRelationsFactory.CountryBias, string, string[],CountryRelationsFactory.CountryGovernmentTypes>(CountryRelationsFactory.CountryBias.southamericansocialist, "Nicaragua", new string[] {"China", "United States of America",  "Russia"}, CountryRelationsFactory.CountryGovernmentTypes.IslamicRepublic),
                new Tuple<CountryRelationsFactory.CountryBias, string, string[],CountryRelationsFactory.CountryGovernmentTypes>(CountryRelationsFactory.CountryBias.africaninstable, "Niger", new string[] {"China", "United States of America",  "Russia"}, CountryRelationsFactory.CountryGovernmentTypes.IslamicRepublic),
                new Tuple<CountryRelationsFactory.CountryBias, string, string[],CountryRelationsFactory.CountryGovernmentTypes>(CountryRelationsFactory.CountryBias.civilwar, "Nigeria", new string[] {"China", "United States of America",  "Russia"}, CountryRelationsFactory.CountryGovernmentTypes.IslamicRepublic),
                new Tuple<CountryRelationsFactory.CountryBias, string, string[],CountryRelationsFactory.CountryGovernmentTypes>(CountryRelationsFactory.CountryBias.europeansocialdemocracy, "Norway", new string[] {"China", "United States of America",  "Russia"}, CountryRelationsFactory.CountryGovernmentTypes.IslamicRepublic),
                new Tuple<CountryRelationsFactory.CountryBias, string, string[],CountryRelationsFactory.CountryGovernmentTypes>(CountryRelationsFactory.CountryBias.islamStable, "Oman", new string[] {"China", "United States of America",  "Russia"}, CountryRelationsFactory.CountryGovernmentTypes.IslamicRepublic),
                new Tuple<CountryRelationsFactory.CountryBias, string, string[],CountryRelationsFactory.CountryGovernmentTypes>(CountryRelationsFactory.CountryBias.islamInstable, "Pakistan", new string[] {"China", "United States of America",  "Russia"}, CountryRelationsFactory.CountryGovernmentTypes.IslamicRepublic),
                new Tuple<CountryRelationsFactory.CountryBias, string, string[],CountryRelationsFactory.CountryGovernmentTypes>(CountryRelationsFactory.CountryBias.citystateisland, "Palau", new string[] {"China", "United States of America",  "Russia"}, CountryRelationsFactory.CountryGovernmentTypes.IslamicRepublic),
                new Tuple<CountryRelationsFactory.CountryBias, string, string[],CountryRelationsFactory.CountryGovernmentTypes>(CountryRelationsFactory.CountryBias.southamericansocialist, "Panama", new string[] {"China", "United States of America",  "Russia"}, CountryRelationsFactory.CountryGovernmentTypes.IslamicRepublic),
                new Tuple<CountryRelationsFactory.CountryBias, string, string[],CountryRelationsFactory.CountryGovernmentTypes>(CountryRelationsFactory.CountryBias.citystateisland, "Papua New Guinea", new string[] {"China", "United States of America",  "Russia"}, CountryRelationsFactory.CountryGovernmentTypes.IslamicRepublic),
                new Tuple<CountryRelationsFactory.CountryBias, string, string[],CountryRelationsFactory.CountryGovernmentTypes>(CountryRelationsFactory.CountryBias.citystateisland, "Palestine", new string[] {"China", "United States of America",  "Russia"}, CountryRelationsFactory.CountryGovernmentTypes.IslamicRepublic),
                new Tuple<CountryRelationsFactory.CountryBias, string, string[],CountryRelationsFactory.CountryGovernmentTypes>(CountryRelationsFactory.CountryBias.southamericandemocracy, "Paraguay", new string[] {"China", "United States of America",  "Russia"}, CountryRelationsFactory.CountryGovernmentTypes.IslamicRepublic),
                new Tuple<CountryRelationsFactory.CountryBias, string, string[],CountryRelationsFactory.CountryGovernmentTypes>(CountryRelationsFactory.CountryBias.southamericansocialist, "Peru", new string[] {"China", "United States of America",  "Russia"}, CountryRelationsFactory.CountryGovernmentTypes.IslamicRepublic),
                new Tuple<CountryRelationsFactory.CountryBias, string, string[],CountryRelationsFactory.CountryGovernmentTypes>(CountryRelationsFactory.CountryBias.notchinaAsian, "Philippines", new string[] {"China", "United States of America",  "Russia"}, CountryRelationsFactory.CountryGovernmentTypes.IslamicRepublic),
                new Tuple<CountryRelationsFactory.CountryBias, string, string[],CountryRelationsFactory.CountryGovernmentTypes>(CountryRelationsFactory.CountryBias.formersoviet, "Poland", new string[] {"China", "United States of America",  "Russia"}, CountryRelationsFactory.CountryGovernmentTypes.IslamicRepublic),
                new Tuple<CountryRelationsFactory.CountryBias, string, string[],CountryRelationsFactory.CountryGovernmentTypes>(CountryRelationsFactory.CountryBias.europeandemocracy, "Portugal", new string[] {"China", "United States of America",  "Russia"}, CountryRelationsFactory.CountryGovernmentTypes.IslamicRepublic),
                new Tuple<CountryRelationsFactory.CountryBias, string, string[],CountryRelationsFactory.CountryGovernmentTypes>(CountryRelationsFactory.CountryBias.islamStable, "Qatar", new string[] {"China", "United States of America",  "Russia"}, CountryRelationsFactory.CountryGovernmentTypes.IslamicRepublic),
                new Tuple<CountryRelationsFactory.CountryBias, string, string[],CountryRelationsFactory.CountryGovernmentTypes>(CountryRelationsFactory.CountryBias.formersoviet, "Romania", new string[] {"China", "United States of America",  "Russia"}, CountryRelationsFactory.CountryGovernmentTypes.IslamicRepublic),
                new Tuple<CountryRelationsFactory.CountryBias, string, string[],CountryRelationsFactory.CountryGovernmentTypes>(CountryRelationsFactory.CountryBias.russiaAndAllies, "Russia", new string[] {"China", "United States of America",  "Russia"}, CountryRelationsFactory.CountryGovernmentTypes.IslamicRepublic),
                new Tuple<CountryRelationsFactory.CountryBias, string, string[],CountryRelationsFactory.CountryGovernmentTypes>(CountryRelationsFactory.CountryBias.africaninstable, "Rwanda", new string[] {"China", "United States of America",  "Russia"}, CountryRelationsFactory.CountryGovernmentTypes.IslamicRepublic),
                  new Tuple<CountryRelationsFactory.CountryBias, string, string[],CountryRelationsFactory.CountryGovernmentTypes>(CountryRelationsFactory.CountryBias.citystateisland, "Saint Kitts and Nevis", new string[] {"China", "United States of America",  "Russia"}, CountryRelationsFactory.CountryGovernmentTypes.IslamicRepublic),

                new Tuple<CountryRelationsFactory.CountryBias, string, string[],CountryRelationsFactory.CountryGovernmentTypes>(CountryRelationsFactory.CountryBias.citystateisland, "Saint Kitts and Nevins", new string[] {"China", "United States of America",  "Russia"}, CountryRelationsFactory.CountryGovernmentTypes.IslamicRepublic),
                new Tuple<CountryRelationsFactory.CountryBias, string, string[],CountryRelationsFactory.CountryGovernmentTypes>(CountryRelationsFactory.CountryBias.citystateisland, "Saint Lucia", new string[] {"China", "United States of America",  "Russia"}, CountryRelationsFactory.CountryGovernmentTypes.IslamicRepublic),
                new Tuple<CountryRelationsFactory.CountryBias, string, string[],CountryRelationsFactory.CountryGovernmentTypes>(CountryRelationsFactory.CountryBias.citystateisland, "Saint Vincent and the Grenadines", new string[] {"China", "United States of America",  "Russia"}, CountryRelationsFactory.CountryGovernmentTypes.IslamicRepublic),
                new Tuple<CountryRelationsFactory.CountryBias, string, string[],CountryRelationsFactory.CountryGovernmentTypes>(CountryRelationsFactory.CountryBias.citystateisland, "Samoa", new string[] {"China", "United States of America",  "Russia"}, CountryRelationsFactory.CountryGovernmentTypes.IslamicRepublic),
                new Tuple<CountryRelationsFactory.CountryBias, string, string[],CountryRelationsFactory.CountryGovernmentTypes>(CountryRelationsFactory.CountryBias.citystateisland, "San Marino", new string[] {"China", "United States of America",  "Russia"}, CountryRelationsFactory.CountryGovernmentTypes.IslamicRepublic),
                new Tuple<CountryRelationsFactory.CountryBias, string, string[],CountryRelationsFactory.CountryGovernmentTypes>(CountryRelationsFactory.CountryBias.citystateisland, "Sao Tome and Principe", new string[] {"China", "United States of America",  "Russia"}, CountryRelationsFactory.CountryGovernmentTypes.IslamicRepublic),
                 new Tuple<CountryRelationsFactory.CountryBias, string, string[],CountryRelationsFactory.CountryGovernmentTypes>(CountryRelationsFactory.CountryBias.islamInstable, "Saudi Arabia", new string[] {"China", "United States of America",  "Russia"}, CountryRelationsFactory.CountryGovernmentTypes.IslamicRepublic),
                  new Tuple<CountryRelationsFactory.CountryBias, string, string[],CountryRelationsFactory.CountryGovernmentTypes>(CountryRelationsFactory.CountryBias.africaninstable, "Senegal", new string[] {"China", "United States of America",  "Russia"}, CountryRelationsFactory.CountryGovernmentTypes.IslamicRepublic),
                  new Tuple<CountryRelationsFactory.CountryBias, string, string[],CountryRelationsFactory.CountryGovernmentTypes>(CountryRelationsFactory.CountryBias.formersoviet, "Serbia", new string[] {"China", "United States of America",  "Russia"}, CountryRelationsFactory.CountryGovernmentTypes.IslamicRepublic),
                  new Tuple<CountryRelationsFactory.CountryBias, string, string[],CountryRelationsFactory.CountryGovernmentTypes>(CountryRelationsFactory.CountryBias.citystateisland, "Seychelles", new string[] {"China", "United States of America",  "Russia"}, CountryRelationsFactory.CountryGovernmentTypes.IslamicRepublic),
                  new Tuple<CountryRelationsFactory.CountryBias, string, string[],CountryRelationsFactory.CountryGovernmentTypes>(CountryRelationsFactory.CountryBias.africaninstable, "Sierra Leone", new string[] {"China", "United States of America",  "Russia"}, CountryRelationsFactory.CountryGovernmentTypes.IslamicRepublic),
                  new Tuple<CountryRelationsFactory.CountryBias, string, string[],CountryRelationsFactory.CountryGovernmentTypes>(CountryRelationsFactory.CountryBias.citystateisland, "Singapore", new string[] {"China", "United States of America",  "Russia"}, CountryRelationsFactory.CountryGovernmentTypes.IslamicRepublic),
                   new Tuple<CountryRelationsFactory.CountryBias, string, string[],CountryRelationsFactory.CountryGovernmentTypes>(CountryRelationsFactory.CountryBias.citystateisland, "Saint Maarten", new string[] {"China", "United States of America",  "Russia"}, CountryRelationsFactory.CountryGovernmentTypes.IslamicRepublic),

                new Tuple<CountryRelationsFactory.CountryBias, string, string[],CountryRelationsFactory.CountryGovernmentTypes>(CountryRelationsFactory.CountryBias.citystateisland, "Saint Martin", new string[] {"China", "United States of America",  "Russia"}, CountryRelationsFactory.CountryGovernmentTypes.IslamicRepublic),
                  new Tuple<CountryRelationsFactory.CountryBias, string, string[],CountryRelationsFactory.CountryGovernmentTypes>(CountryRelationsFactory.CountryBias.formersoviet, "Slovakia", new string[] {"China", "United States of America",  "Russia"}, CountryRelationsFactory.CountryGovernmentTypes.IslamicRepublic),
                  new Tuple<CountryRelationsFactory.CountryBias, string, string[],CountryRelationsFactory.CountryGovernmentTypes>(CountryRelationsFactory.CountryBias.formersoviet, "Slovenia", new string[] {"China", "United States of America",  "Russia"}, CountryRelationsFactory.CountryGovernmentTypes.IslamicRepublic),
                   new Tuple<CountryRelationsFactory.CountryBias, string, string[],CountryRelationsFactory.CountryGovernmentTypes>(CountryRelationsFactory.CountryBias.citystateisland, "Saint Helena", new string[] {"China", "United States of America",  "Russia"}, CountryRelationsFactory.CountryGovernmentTypes.IslamicRepublic),

                   new Tuple<CountryRelationsFactory.CountryBias, string, string[],CountryRelationsFactory.CountryGovernmentTypes>(CountryRelationsFactory.CountryBias.citystateisland, "Spratly Islands", new string[] {"China", "United States of America",  "Russia"}, CountryRelationsFactory.CountryGovernmentTypes.IslamicRepublic),
                new Tuple<CountryRelationsFactory.CountryBias, string, string[],CountryRelationsFactory.CountryGovernmentTypes>(CountryRelationsFactory.CountryBias.citystateisland, "Solomon Islands", new string[] {"China", "United States of America",  "Russia"}, CountryRelationsFactory.CountryGovernmentTypes.IslamicRepublic),
                  new Tuple<CountryRelationsFactory.CountryBias, string, string[],CountryRelationsFactory.CountryGovernmentTypes>(CountryRelationsFactory.CountryBias.civilwar, "Somalia", new string[] {"China", "United States of America",  "Russia"}, CountryRelationsFactory.CountryGovernmentTypes.IslamicRepublic),
                  new Tuple<CountryRelationsFactory.CountryBias, string, string[],CountryRelationsFactory.CountryGovernmentTypes>(CountryRelationsFactory.CountryBias.africanstable, "South Africa", new string[] {"China", "United States of America",  "Russia"}, CountryRelationsFactory.CountryGovernmentTypes.IslamicRepublic),
                  new Tuple<CountryRelationsFactory.CountryBias, string, string[],CountryRelationsFactory.CountryGovernmentTypes>(CountryRelationsFactory.CountryBias.africaninstable, "South Sudan", new string[] {"China", "United States of America",  "Russia"}, CountryRelationsFactory.CountryGovernmentTypes.IslamicRepublic),
                  new Tuple<CountryRelationsFactory.CountryBias, string, string[],CountryRelationsFactory.CountryGovernmentTypes>(CountryRelationsFactory.CountryBias.europeansocialdemocracy, "Spain", new string[] {"China", "United States of America",  "Russia"}, CountryRelationsFactory.CountryGovernmentTypes.IslamicRepublic),
                  new Tuple<CountryRelationsFactory.CountryBias, string, string[],CountryRelationsFactory.CountryGovernmentTypes>(CountryRelationsFactory.CountryBias.citystateisland, "Sri Lanka", new string[] {"China", "United States of America",  "Russia"}, CountryRelationsFactory.CountryGovernmentTypes.IslamicRepublic),
                  new Tuple<CountryRelationsFactory.CountryBias, string, string[],CountryRelationsFactory.CountryGovernmentTypes>(CountryRelationsFactory.CountryBias.islamStable, "Sudan", new string[] {"China", "United States of America",  "Russia"}, CountryRelationsFactory.CountryGovernmentTypes.IslamicRepublic),
                  new Tuple<CountryRelationsFactory.CountryBias, string, string[],CountryRelationsFactory.CountryGovernmentTypes>(CountryRelationsFactory.CountryBias.southamericandemocracy, "Suriname", new string[] {"China", "United States of America",  "Russia"}, CountryRelationsFactory.CountryGovernmentTypes.IslamicRepublic),
                  new Tuple<CountryRelationsFactory.CountryBias, string, string[],CountryRelationsFactory.CountryGovernmentTypes>(CountryRelationsFactory.CountryBias.africanstable, "Swaziland", new string[] {"China", "United States of America",  "Russia"}, CountryRelationsFactory.CountryGovernmentTypes.IslamicRepublic),
                  new Tuple<CountryRelationsFactory.CountryBias, string, string[],CountryRelationsFactory.CountryGovernmentTypes>(CountryRelationsFactory.CountryBias.europeansocialdemocracy, "Sweden", new string[] {"China", "United States of America",  "Russia"}, CountryRelationsFactory.CountryGovernmentTypes.IslamicRepublic),
                  new Tuple<CountryRelationsFactory.CountryBias, string, string[],CountryRelationsFactory.CountryGovernmentTypes>(CountryRelationsFactory.CountryBias.europeandemocracy, "Switzerland", new string[] {"China", "United States of America",  "Russia"}, CountryRelationsFactory.CountryGovernmentTypes.IslamicRepublic),
                  new Tuple<CountryRelationsFactory.CountryBias, string, string[],CountryRelationsFactory.CountryGovernmentTypes>(CountryRelationsFactory.CountryBias.civilwar, "Syria", new string[] {"China", "United States of America",  "Russia"}, CountryRelationsFactory.CountryGovernmentTypes.IslamicRepublic),
                  new Tuple<CountryRelationsFactory.CountryBias, string, string[],CountryRelationsFactory.CountryGovernmentTypes>(CountryRelationsFactory.CountryBias.citystateisland, "Taiwan", new string[] {"China", "United States of America",  "Russia"}, CountryRelationsFactory.CountryGovernmentTypes.IslamicRepublic),
                  new Tuple<CountryRelationsFactory.CountryBias, string, string[],CountryRelationsFactory.CountryGovernmentTypes>(CountryRelationsFactory.CountryBias.formersovietAuthoratian, "Tajikistan", new string[] {"China", "United States of America",  "Russia"}, CountryRelationsFactory.CountryGovernmentTypes.IslamicRepublic),
                  new Tuple<CountryRelationsFactory.CountryBias, string, string[],CountryRelationsFactory.CountryGovernmentTypes>(CountryRelationsFactory.CountryBias.africanstable, "Tanzania", new string[] {"China", "United States of America",  "Russia"}, CountryRelationsFactory.CountryGovernmentTypes.IslamicRepublic),
                  new Tuple<CountryRelationsFactory.CountryBias, string, string[],CountryRelationsFactory.CountryGovernmentTypes>(CountryRelationsFactory.CountryBias.notchinaAsian, "Thailand", new string[] {"China", "United States of America",  "Russia"}, CountryRelationsFactory.CountryGovernmentTypes.IslamicRepublic),
                  new Tuple<CountryRelationsFactory.CountryBias, string, string[],CountryRelationsFactory.CountryGovernmentTypes>(CountryRelationsFactory.CountryBias.citystateisland, "Timor-Leste", new string[] {"China", "United States of America",  "Russia"}, CountryRelationsFactory.CountryGovernmentTypes.IslamicRepublic),
                  new Tuple<CountryRelationsFactory.CountryBias, string, string[],CountryRelationsFactory.CountryGovernmentTypes>(CountryRelationsFactory.CountryBias.africaninstable, "Togo", new string[] {"China", "United States of America",  "Russia"}, CountryRelationsFactory.CountryGovernmentTypes.IslamicRepublic),
                  new Tuple<CountryRelationsFactory.CountryBias, string, string[],CountryRelationsFactory.CountryGovernmentTypes>(CountryRelationsFactory.CountryBias.africaninstable, "Tonga", new string[] {"China", "United States of America",  "Russia"}, CountryRelationsFactory.CountryGovernmentTypes.IslamicRepublic),
                  new Tuple<CountryRelationsFactory.CountryBias, string, string[],CountryRelationsFactory.CountryGovernmentTypes>(CountryRelationsFactory.CountryBias.citystateisland, "Trinidad and Tobago", new string[] {"China", "United States of America",  "Russia"}, CountryRelationsFactory.CountryGovernmentTypes.IslamicRepublic),
                  new Tuple<CountryRelationsFactory.CountryBias, string, string[],CountryRelationsFactory.CountryGovernmentTypes>(CountryRelationsFactory.CountryBias.citystateisland, "Turks and Caicos Islands", new string[] {"China", "United States of America",  "Russia"}, CountryRelationsFactory.CountryGovernmentTypes.IslamicRepublic),
                  new Tuple<CountryRelationsFactory.CountryBias, string, string[],CountryRelationsFactory.CountryGovernmentTypes>(CountryRelationsFactory.CountryBias.islamInstable, "Tunisia", new string[] {"China", "United States of America",  "Russia"}, CountryRelationsFactory.CountryGovernmentTypes.IslamicRepublic),
                  new Tuple<CountryRelationsFactory.CountryBias, string, string[],CountryRelationsFactory.CountryGovernmentTypes>(CountryRelationsFactory.CountryBias.islamStable, "Turkey", new string[] {"China", "United States of America",  "Russia"}, CountryRelationsFactory.CountryGovernmentTypes.IslamicRepublic),
                  new Tuple<CountryRelationsFactory.CountryBias, string, string[],CountryRelationsFactory.CountryGovernmentTypes>(CountryRelationsFactory.CountryBias.formersovietAuthoratian, "Turkmenistan", new string[] {"China", "United States of America",  "Russia"}, CountryRelationsFactory.CountryGovernmentTypes.IslamicRepublic),
                  new Tuple<CountryRelationsFactory.CountryBias, string, string[],CountryRelationsFactory.CountryGovernmentTypes>(CountryRelationsFactory.CountryBias.citystateisland, "Tuvalu", new string[] {"China", "United States of America",  "Russia"}, CountryRelationsFactory.CountryGovernmentTypes.IslamicRepublic),
                  new Tuple<CountryRelationsFactory.CountryBias, string, string[],CountryRelationsFactory.CountryGovernmentTypes>(CountryRelationsFactory.CountryBias.africanstable, "Uganda", new string[] {"China", "United States of America",  "Russia"}, CountryRelationsFactory.CountryGovernmentTypes.IslamicRepublic),
                  new Tuple<CountryRelationsFactory.CountryBias, string, string[],CountryRelationsFactory.CountryGovernmentTypes>(CountryRelationsFactory.CountryBias.civilwar, "Ukraine", new string[] {"China", "United States of America",  "Russia"}, CountryRelationsFactory.CountryGovernmentTypes.IslamicRepublic),
                  new Tuple<CountryRelationsFactory.CountryBias, string, string[],CountryRelationsFactory.CountryGovernmentTypes>(CountryRelationsFactory.CountryBias.islamStable, "United Arab Emirates", new string[] {"China", "United States of America",  "Russia"}, CountryRelationsFactory.CountryGovernmentTypes.IslamicRepublic),
                  new Tuple<CountryRelationsFactory.CountryBias, string, string[],CountryRelationsFactory.CountryGovernmentTypes>(CountryRelationsFactory.CountryBias.europeandemocracy, "United Kingdom", new string[] {"China", "United States of America",  "Russia"}, CountryRelationsFactory.CountryGovernmentTypes.IslamicRepublic),
                  new Tuple<CountryRelationsFactory.CountryBias, string, string[],CountryRelationsFactory.CountryGovernmentTypes>(CountryRelationsFactory.CountryBias.superpower, "United States of America", new string[] {"China", "United States of America",  "Russia"}, CountryRelationsFactory.CountryGovernmentTypes.IslamicRepublic),
                  new Tuple<CountryRelationsFactory.CountryBias, string, string[],CountryRelationsFactory.CountryGovernmentTypes>(CountryRelationsFactory.CountryBias.southamericandemocracy, "Uruguay", new string[] {"China", "United States of America",  "Russia"}, CountryRelationsFactory.CountryGovernmentTypes.IslamicRepublic),
                  new Tuple<CountryRelationsFactory.CountryBias, string, string[],CountryRelationsFactory.CountryGovernmentTypes>(CountryRelationsFactory.CountryBias.formersovietAuthoratian, "Uzbekistan", new string[] {"China", "United States of America",  "Russia"}, CountryRelationsFactory.CountryGovernmentTypes.IslamicRepublic),

                   new Tuple<CountryRelationsFactory.CountryBias, string, string[],CountryRelationsFactory.CountryGovernmentTypes>(CountryRelationsFactory.CountryBias.africaninstable, "Western Sahara", new string[] {"China", "United States of America",  "Russia"}, CountryRelationsFactory.CountryGovernmentTypes.IslamicRepublic),

                new Tuple<CountryRelationsFactory.CountryBias, string, string[],CountryRelationsFactory.CountryGovernmentTypes>(CountryRelationsFactory.CountryBias.citystateisland, "Vanuatu", new string[] {"China", "United States of America",  "Russia"}, CountryRelationsFactory.CountryGovernmentTypes.IslamicRepublic),
                  new Tuple<CountryRelationsFactory.CountryBias, string, string[],CountryRelationsFactory.CountryGovernmentTypes>(CountryRelationsFactory.CountryBias.southamericansocialist, "Venezuela", new string[] {"China", "United States of America",  "Russia"}, CountryRelationsFactory.CountryGovernmentTypes.IslamicRepublic),
                  new Tuple<CountryRelationsFactory.CountryBias, string, string[],CountryRelationsFactory.CountryGovernmentTypes>(CountryRelationsFactory.CountryBias.notchinaAsian, "Vietnam", new string[] {"China", "United States of America",  "Russia"}, CountryRelationsFactory.CountryGovernmentTypes.IslamicRepublic),
                  new Tuple<CountryRelationsFactory.CountryBias, string, string[],CountryRelationsFactory.CountryGovernmentTypes>(CountryRelationsFactory.CountryBias.civilwar, "Yemen", new string[] {"China", "United States of America",  "Russia"}, CountryRelationsFactory.CountryGovernmentTypes.IslamicRepublic),
                  new Tuple<CountryRelationsFactory.CountryBias, string, string[],CountryRelationsFactory.CountryGovernmentTypes>(CountryRelationsFactory.CountryBias.africaninstable, "Zambia", new string[] {"China", "United States of America",  "Russia"}, CountryRelationsFactory.CountryGovernmentTypes.IslamicRepublic),

                new Tuple<CountryRelationsFactory.CountryBias, string, string[],CountryRelationsFactory.CountryGovernmentTypes>(CountryRelationsFactory.CountryBias.africaninstable, "Zimbabwe", new string[] {"China", "United States of America",  "Russia"}, CountryRelationsFactory.CountryGovernmentTypes.IslamicRepublic),
                };
            return internalRegionFirst;
        }



        public string IsUS(string isUnitedStates)
        {
            if (isUnitedStates == "US" || isUnitedStates == "USA" || isUnitedStates == "U.S.A" || isUnitedStates == "United States")
            {
                return "United States of America";
            }
            else { return isUnitedStates; }
        }

        //this is to seed the intially relations matrix countries will have there bias and then there current allies 
        //public List<Tuple<CountryRelationsFactory.CountryBias, string, string[], CountryRelationsFactory.CountryGovernmentTypes>> CountryBiasList(List<JsonCountryCIAModel.CountryCiaDbObject> jsonCIAUnit)
        //{
        //    var internalRegionFirst = new List<Tuple<CountryRelationsFactory.CountryBias, string, string[], CountryRelationsFactory.CountryGovernmentTypes>>();

        //    jsonCIAUnit.ForEach(e =>
        //    {
        //        List<string> countriallies = new List<string>();
        //        var countryName = e.CountryName;
        //        var stubBias = GetCountryBiasDetailsByName(countryName);

        //        if (GetCountryBiasDetailsByName(countryName).Item1 == null)
        //        {
        //            return;
        //        }

        //        var CountryBias = stubBias.Item1;
        //        var CountryType = stubBias.fourth;
        //        string[] CountryTradingAllies = stubBias.third;

        //        //var alliesPercenat = e.Economy.Exportspartners;
        //        if (e.Economy.Importspartners.Length != 0)
        //        {
        //            //France 10.8 %, Italy 8.6 %, Spain 8.6 %, Germany 6.5 %, US 4.9 % 
        //            e.Economy.Importspartners.Split(',').ToList<string>().ForEach(country =>
        //            {
        //                var output = country.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries); //France 10.8%, South Africa 12%,
        //                string countryname = string.Empty;
        //                double pecernt = 0;
        //                try
        //                {
        //                    if (output.Length > 0)
        //                    {
        //                        if (output[0].Contains("NA%"))
        //                        {
        //                            return;
        //                        }
        //                        if (output.Length == 2)
        //                        {
        //                            countryname = IsUS(output[0]).Trim();
        //                            double.TryParse(output[1], out pecernt);
        //                        }
        //                        else
        //                        {
        //                            try
        //                            {
        //                                decimal? num = decimal.Parse(output[1].TrimEnd(new char[] { '%', ' ' })) / 100M;
        //                                if (num != null)
        //                                {
        //                                    var c = output[0];
        //                                    countryname = IsUS(c);
        //                                }
        //                            }
        //                            catch (Exception d)
        //                            {
        //                                countryname = output[0] + " " + output[1];
        //                            }
        //                        }
        //                    }
        //                }
        //                catch (Exception i)
        //                {
        //                    var f = i;
        //                }
        //                countriallies.Add(countryname);
        //            });

        //        }
        //        CountryTradingAllies = countriallies.ToArray();
        //        try
        //        {
        //            //Chinaa , (2014)

        //            internalRegionFirst.Add(new Tuple<CountryRelationsFactory.CountryBias, string, string[], CountryRelationsFactory.CountryGovernmentTypes>(CountryBias, countryName, CountryTradingAllies, CountryType));

        //        }
        //        catch (Exception d)
        //        {
        //            var f = countryName;
        //        }

        //    });
        //    return internalRegionFirst;
        //}

    }
}