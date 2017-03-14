/**
 * Spawner.cs
 * Created by Joao Borks [joao.borks@gmail.com]
 * Created on: 03/14/17
 */

using UnityEngine;

namespace com.JoaoBorks.Plugins
{
    public class FPSBenchmark : MonoBehaviour
    {
        [SerializeField]
        GameObject prefab;

        void Update()
        {
            if (prefab)
                Instantiate(prefab, transform.position, Random.rotation, transform);
            else
                Debug.LogWarning("Prefab not set on FPSBenchmark!");
        }
    }
}