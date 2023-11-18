using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
public enum RoomType
{
    Room01,
    Room02,
    Room03
}

public class DoorDestination : MonoBehaviour
{
    public RoomType DesireType;

    [Header("=========DestinationRoom=========")]
    public Transform[] destinationRoom;
    public int desireRoomNumber;

    [SerializeField] private Transform destination;
    [SerializeField] public CinemachineVirtualCamera cinemachineVirtualCamera;

    public Transform GetDestination()
    {
        var vcam = cinemachineVirtualCamera;

        if (vcam != null)
        {
            vcam.Follow = transform;

            switch (DesireType)
            {
                case RoomType.Room01:
                    desireRoomNumber = 0;
                    vcam.Follow = destinationRoom[desireRoomNumber];
                    break;
                case RoomType.Room02:
                    desireRoomNumber = 1;
                    vcam.Follow = destinationRoom[desireRoomNumber];
                    break;
                case RoomType.Room03:
                    desireRoomNumber = 2;
                    vcam.Follow = destinationRoom[desireRoomNumber];
                    break;
            }

            return destination;
        }
        else
        {
            Debug.Log("CinemachineVirtualCamera not found!");
            return null;
        }
    }

    public void Update()
    {
        //var vcam = GetComponent<CinemachineVirtualCamera>();

        //if (desireRoomNumber < destinationRoom.Length)
        //{
        //    vcam.Follow = destinationRoom[desireRoomNumber];
        //}
    }
}