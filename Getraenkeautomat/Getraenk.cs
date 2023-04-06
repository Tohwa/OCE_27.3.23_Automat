using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drinks
{

    internal class Drink
    {
        public float m_liquidVolume;
        public float m_kcalAmount;

        //Konstruktor
        /// <summary>
        /// Creates a drink.
        /// </summary>
        /// <param name="_volume">Amount of liquid inside the can in ml</param>
        /// <param name="_kcal">Amount of kcal per 100ml</param>
        public Drink(float _volume, float _kcal)
        {
            m_liquidVolume = _volume;
            m_kcalAmount = _kcal;
        }
    }
}
