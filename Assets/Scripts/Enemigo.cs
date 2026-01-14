using System.Collections;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Apple;

public class Enemigo : MonoBehaviour
{
    [SerializeField] private Vector3 destination;
    [SerializeField] private Vector3 min, max;
    [SerializeField] private GameObject player;

    [SerializeField] private int childrenIndex;
    [SerializeField] private Transform path;

    [SerializeField] private float playerDetectionDistance;
    [SerializeField] private bool playerDetected;

    private Coroutine runningPatroll;
    private void Start()
    {
        //destination = RandomDestination();
        //GetComponent<NavMeshAgent>().SetDestination(destination);
        destination = path.GetChild(0).position;
        GetComponent<NavMeshAgent>().SetDestination(path.GetChild(0).position);
        runningPatroll = StartCoroutine(Patroll());
        StartCoroutine(DistanceDetection());
    }

    public void Update()
    {
        //if(playerDetected)
        //{
        //    StopCoroutine(Patroll());            
        //} else if(runningPatroll == null)
        //{
        //    StartCoroutine(Patroll());
        //}

        //if (Vector3.Distance(transform.position, destination)< 0.5f)
        //{
        //    destination = RandomDestination();
        //    GetComponent<NavMeshAgent>().SetDestination(destination);
        //}
    }


    #region Always Detect

    IEnumerator Follow()
    {
        while(true)
        {
            destination = player.transform.position;
            GetComponent<NavMeshAgent>().SetDestination(destination);
            yield return new WaitForEndOfFrame();
            yield return new WaitForSeconds(1f);
        }
    }
    #endregion

    #region Patroll Movement

    IEnumerator Patroll()
    {
        while(true)
        {
            if(Vector3.Distance(transform.position, destination) < 1f)
            {
                childrenIndex++;
                childrenIndex = childrenIndex % path.childCount;

                destination = path.GetChild(childrenIndex).position;
                GetComponent<NavMeshAgent>().SetDestination(destination);
            }
            yield return new WaitForSeconds(1);
        }
    }

    #endregion

    #region Distance detenction
        IEnumerator DistanceDetection()
        {
            while(true) 
            {
                if(Vector3.Distance(transform.position, player.transform.position) < playerDetectionDistance)
                {
                    if(runningPatroll != null)
                    {
                        StopCoroutine(Patroll());
                        runningPatroll = null;
                    }
                    
                    playerDetected = true;
                    destination = player.transform.position;
                    GetComponent<NavMeshAgent>().SetDestination(destination);
                } else
                {
                    playerDetected = false;
                    if(runningPatroll == null)
                    {
                        runningPatroll = StartCoroutine(Patroll());
                    }
                }
                yield return new WaitForSeconds(0.5f);
                Debug.Log(playerDetected);
             }
        }

    #endregion

    #region Collider Detection

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if(runningPatroll != null)
            {
                StopCoroutine(Patroll());
                runningPatroll = null;
            }
            StartCoroutine(DistanceDetection());
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            StopCoroutine(DistanceDetection());
            playerDetected = false;
            if(runningPatroll == null)
                runningPatroll = StartCoroutine(Patroll());
        }
    }
    #endregion


}

