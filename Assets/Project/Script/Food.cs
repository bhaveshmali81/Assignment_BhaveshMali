using UnityEngine;

namespace Project.Script
{
    public class Food : MonoBehaviour
    {
        public FoodCategory foodType;
    }

    public enum FoodCategory
    {
        None=0,
        Apple=10,
        Mango=20
    }
}
