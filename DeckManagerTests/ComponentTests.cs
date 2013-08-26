using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeckManager.Components;
using DeckManager.ManagerLogic.Enums;
using NUnit.Framework;
using Newtonsoft.Json;

namespace DeckManagerTests
{
    [TestFixture]
    public class ComponentTests
    {
        [Test]
        [Ignore]
        public void Dongwater()
        {
            var dong = new List<List<Resource>>
                {
                    new List<Resource> {Resource.Population, Resource.Population},
                    new List<Resource> {Resource.Population, Resource.Population},
                    new List<Resource> {Resource.Population},
                    new List<Resource> {Resource.Population},
                    new List<Resource> {Resource.Population},
                    new List<Resource> {Resource.Population},
                    new List<Resource> {Resource.Population},
                    new List<Resource> {Resource.Population},
                    new List<Resource> {Resource.Population, Resource.Morale},
                    new List<Resource> {Resource.Population, Resource.Fuel},
                    new List<Resource> {},
                    new List<Resource> {}
                };

            var json = JsonConvert.SerializeObject(dong, Formatting.Indented);
            using (var sr = new StreamWriter(@"..\..\TestContent\CivilianPile.json"))
            {
                sr.Write(json);
            }
        }
    }
}

