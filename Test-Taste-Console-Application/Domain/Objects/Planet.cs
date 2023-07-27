using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Test_Taste_Console_Application.Domain.DataTransferObjects;

namespace Test_Taste_Console_Application.Domain.Objects
{
    public class Planet
    {
        public string Id { get; set; }
        public float SemiMajorAxis { get; set; }
        //public ICollection<Moon> Moons { get; set; }
        //New property to store 
        //--public string Name { get; set; }
        public double Gravity { get; set; }
        public List<Moon> Moons { get; }
        public double AverageMoonGravity    // Modified
        {
            get
            {
                if (Moons.Count == 0)
                    return 0;

                else {
                    if ( Gravity != 0)
                    {
                        double totalMoonGravity = Moons.Sum(x => x.Gravity);
                        return totalMoonGravity / Moons.Count;
                    }
                    else
                    {
                      //  float power = G * ((Mass * p.Mass) / radius);
                    }
                }
                
            }
        }

        public Planet(PlanetDto planetDto)
        {
            Id = planetDto.Id;
            SemiMajorAxis = planetDto.SemiMajorAxis;
            Moons = new List<Moon>();
            if (planetDto.Moons != null)
            {
                foreach (MoonDto moonDto in planetDto.Moons)
                {
                    Moons.Add(new Moon(moonDto));
                }
            }
        }

        public Boolean HasMoons()
        {
            return (Moons != null && Moons.Count > 0);
        }
    }
}
