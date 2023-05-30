using UnityEngine;

namespace Project.Script.Editor
{
    public class GridSystem : MonoBehaviour
    {
        public int gridRow = 30, gridColumn = 25;
    
        private void OnDrawGizmos()
        {
            for (int i = 0; i < gridColumn; i++)
            {
                for (int j = 0; j < gridRow; j++)
                {
                    Gizmos.color = Color.green;
                    Gizmos.DrawLine(new Vector3(j, -1, -i), new Vector3(j+1, -1, -i));
                }
            }
            for (int i = 0; i < gridColumn; i++)
            {
                for (int j = 0; j < gridRow; j++)
                {
                    Gizmos.color = Color.blue;
                    Gizmos.DrawLine(new Vector3(j, -1, -i), new Vector3(j, -1, -i-1));
                }
            }
        
        }
    }
}
