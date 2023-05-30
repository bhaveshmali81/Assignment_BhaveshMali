using System.Collections.Generic;
using UnityEngine;

namespace Project.Script
{
    public class FoodSpawner : MonoBehaviour
    {
        public List<Food> FoodList;
        int maxX=29, maxz=-24;
        public Snake _snake;
        void Start()
        {
            Invoke(nameof(SpawnFood),1f);
            _snake = FindObjectOfType<Snake>();
        }
    
        public void SpawnFood()
        {
            int randomIndex = Random.Range(0, FoodList.Count);
            Instantiate(FoodList[randomIndex], RandomPos(), Quaternion.identity);
        }
    
        public Vector3 RandomPos()
        {
            var pos=new Vector3(Random.Range(2, maxX),0,Random.Range(-2, maxz));
            while (_snake.IsOccupiedPos(pos))
            {
                pos = new Vector3(Random.Range(2, maxX), 0, Random.Range(-2, maxz));
            }

            return pos;
        }
    }
}
