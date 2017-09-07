using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using static Assets.ContactGenerator;
using static Assets.CountryRelationsFactory;

namespace Assets
{
    [System.Serializable]
    public class Contact : ScriptableObject
    {


        [ContextMenuItem("Randomize Name", "Randomize")]
        public string ContactName;
        public string CountryName;
        public string NameRegion;
        public bool IsIntelTarget;
        public bool IsUnderArrest;
        public bool IsCompromised;
        public bool IsTerrorist;
        public bool IsDead;
        public bool IsMissing;
        public CountrySpokeLanguage ContactNativeLangauge;
        public Subregions ContactSubregion;
        public ContactSkill ContactSkill; //what they are good at
        public ContactVice ContactVice; // what there weakness is
        public ContactType ContactType; // what type they are ie there background before they became this
        public int Age;
        public int DobYear;
        public int DobMonth;
        public DateTime Dob;
        public TimeSpan DateArrested;
        public TimeSpan DateTargeted;
        public TimeSpan DateDied;
        public TimeSpan DateInService;
        public GeneProfile GeneProfile;
        public Family Family;
        public int YearsInService;
        public bool DoNotDelete;
        private void Randomize()
        {
            NameRegion = ContactSubregion.ToDescription();
            ContactName = ContactGenerator.GenerateARegionName(ContactGenerator.ContactGender.male, NameRegion);
        }
    }
}
