using Pisit.Utility;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace ERMM.GenericData
{
    public class Stats : MonoBehaviour
    {
        public enum StatAttribute
        {
            [DisplayText("Strength")]
            str,
            [DisplayText("Intelligence")]
            intg,
            [DisplayText("Agility")]
            agi,
            [DisplayText("Vitality")]
            vit,
            [DisplayText("Magic")]
            mag
        }

        // Attributes
        public int str = 10; // Strength
        public int intg = 10; // Intelligence, 'int' is a reserved keyword in C#, so we use 'intg' instead
        public int agi = 10; // Agility
        public int vit = 10; // Vitality
        public int mag = 10; // Magic

        #region Events
        public UnityEvent onStatUpdated;
        #endregion

        // Methods to modify each stat
        public void SetupStat(int str, int intg, int agi, int vit, int mag)
        {
            this.str = str;
            this.intg = intg;
            this.agi = agi;
            this.vit = vit;
            this.mag = mag;
            HandleStatUpdated();
        }
        public void ModifyStr(int amount)
        {
            str += amount;
            HandleStatUpdated();
        }

        public void ModifyIntg(int amount)
        {
            intg += amount;
            HandleStatUpdated();
        }

        public void ModifyAgi(int amount)
        {
            agi += amount;
            HandleStatUpdated();
        }

        public void ModifyVit(int amount)
        {
            vit += amount;
            HandleStatUpdated();
        }

        public void ModifyMag(int amount)
        {
            mag += amount;
            HandleStatUpdated();
        }

        public int GetStatAttribute(StatAttribute attribute)
        {
            switch (attribute)
            {
                case StatAttribute.str:
                    return str;
                case StatAttribute.intg:
                    return intg;
                case StatAttribute.agi:
                    return agi;
                case StatAttribute.vit:
                    return vit; 
                case StatAttribute.mag:
                    return mag;
                default:
                    return -1;
            }
        }

        public bool GetStatAttribute(out int value, string attributeKey)
        {
            StatAttribute targetAttribute;

            if (Enum.TryParse<StatAttribute>(attributeKey, true, out targetAttribute))
            {
                value = GetStatAttribute(targetAttribute);
                return true;
            }
            else
            {
                value = -1;
                return false;
            }    
        }

        #region Event Invoke
        void HandleStatUpdated()
        {
            onStatUpdated?.Invoke();
        }
        #endregion
    }
}
