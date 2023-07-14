using UnityEngine;

namespace CharacterScripts
{
    public class Character : MonoBehaviour
    {
        public const int MINIMUM_HEALTH = 0;
        public const int MAXIMUM_HEALTH = 100;
        public int Health { get; private set; }

        public void DecreaseHealth(int damage)
        {
            Health -= Mathf.Clamp(damage, MINIMUM_HEALTH, MAXIMUM_HEALTH);
        }
    }
}