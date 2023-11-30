using System;
using UnityEngine;

namespace Achievement
{
    public class AchievementCorridor : MonoBehaviour
    {
        public static Action plateformTranslation;
    
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                plateformTranslation.Invoke();
            }
        }
    }
}
