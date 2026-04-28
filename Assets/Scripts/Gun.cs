using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct AttachmentSockets
{
    public GameObject socket;
    public bool isOccupied;
}

public class Gun : MonoBehaviour
{
    [SerializeField] GameManager gameManager;
    [SerializeField] public AttachmentSockets[] sockets;

    public bool isGunEquipped = false;

    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Mouse1)) UseScope();

        if (Input.GetKey(KeyCode.H)) AttachAttachments();
    }


    public void AttachAttachments()
    {
        foreach(var attachment in gameManager.attachments)
        {
            for(int i = 0;i < sockets.Length; i++)
            {
                if (sockets[i].socket.name.Equals(attachment.tag))
                {
                    if(!sockets[i].isOccupied && isGunEquipped)
                    {
                        attachment.transform.SetParent(sockets[i].socket.transform);
                        attachment.transform.position = sockets[i].socket.transform.position;
                        attachment.transform.rotation = sockets[i].socket.transform.rotation;
                        sockets[i].isOccupied = true;
                    }
                }
            }  
        }
    }

    public void UseScope()
    {
        foreach(var socket in sockets)
        {
            if(socket.socket.name.Equals("Scope") && socket.isOccupied)
                socket.socket.GetComponentInChildren<IScopeHandler>().UsingScope();

            if (socket.socket.name.Equals("Grip") && socket.isOccupied)
                socket.socket.GetComponentInChildren<IGripHandler>().UsingGrip();

            if (socket.socket.name.Equals("Magazine") && socket.isOccupied)
                socket.socket.GetComponentInChildren<IMagHandler>().UsingMag();

            if (socket.socket.name.Equals("Muzzle") && socket.isOccupied)
                socket.socket.GetComponentInChildren<IMuzzleHandler>().UsingMuzzle();
        }
    }
}
