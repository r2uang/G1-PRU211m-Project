using Cinemachine;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private CinemachineVirtualCamera vcam;
    private GameObject tPlayer;
    void Start()
    {
        vcam = GetComponent<CinemachineVirtualCamera>();
    }

    // Update is called once per frame
    void Update()
    {
        if (tPlayer == null)
        {
            tPlayer = GameObject.FindWithTag("Player");
            Debug.Log("Spawn");
        }
        //if (PlayerManager.replayBt && tPlayer == null)
        //{
        //    SpawnPlayerManager spawnPlayerManager = gameObject.AddComponent<SpawnPlayerManager>();
        //    spawnPlayerManager.SpawnPlayer();
        //    if (SpawnPlayerManager.isCreated == true)
        //    {
        //        Debug.Log("Spawnn");
        //    }
        //    tPlayer = GameObject.FindWithTag("Player");
        //    Debug.Log("Found");
        //}
        vcam.LookAt = tPlayer.transform;
        vcam.Follow = tPlayer.transform;
    }
}
