using UnityEngine;

public class RandomCoin : MonoBehaviour
{
        public GameObject coin1;
        public GameObject coin2;
        public GameObject coin3;
        public GameObject coin4;

        void Start()
        {
            //first coin
            
            createCoin(-24, -10, 10, 24, coin1);
            createCoin(-24, -10, -20, -10, coin2);
            createCoin(10, 24, 10, 24, coin3);
            createCoin(10, 24, -20, -10, coin4);

        }
        void createCoin(int x1, int x2, int z1, int z2, GameObject coin)
        {
            int x;
            int z;
            bool success = false;
            while (!success)
            {
                x = Random.Range(x1, x2);
                z = Random.Range(z1, z2);
                Vector3 checkPosition = new Vector3(x, 3f, z);
                Ray ray = new Ray(checkPosition, Vector3.down);
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit))
                {
                    if (hit.collider.gameObject.CompareTag("ground"))
                    {
                        checkPosition = new Vector3(x, 0.5f, z);
                        coin.transform.position = checkPosition;
                        success = true;
                    }
                }
            }
        }
    }