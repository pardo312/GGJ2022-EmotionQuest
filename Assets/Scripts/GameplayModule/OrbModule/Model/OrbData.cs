using UnityEngine;
using UnityEngine.UI;

namespace EmotionQuest.GameplayModule.OrbModule
{
    [System.Serializable]
    public struct OrbData
    {
        public TypeOfOrb typeOfOrb;
        public SizeOfOrb sizeOfOrb;

        public bool CompareOrbData(OrbData other)
        {
            if (other.typeOfOrb != this.typeOfOrb)
                return false;
            if (other.sizeOfOrb != this.sizeOfOrb)
                return false;
            return true;
        }
    }
}