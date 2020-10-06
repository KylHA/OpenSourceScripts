using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineUpdaterScript : MonoBehaviour
{
    public GameObject parentObj;
    public GameObject mesh;
    public int lineCount;

    public Material meshMaterial;
    LineRenderer ropeMesh;



    private void Start()
    {
        ropeMesh = this.GetComponent<LineRenderer>();

    }
    public void CreateMesh()
    {
       
        mesh.name = "RopeMesh";

        //mesh.AddComponent<LineUpdaterScript>();

        ropeMesh = mesh.AddComponent<LineRenderer>();

        MeshCollider ropemeshCollider = mesh.AddComponent<MeshCollider>();

        ropemeshCollider.convex = true;
        ropemeshCollider.isTrigger = true;

        ropeMesh.positionCount = lineCount;
        ropeMesh.startWidth = 2; ropeMesh.endWidth = 2;
        ropeMesh.material = meshMaterial;
        ropeMesh.numCapVertices = 90;

        Mesh meshCreatedRope = new Mesh();
        ropeMesh.BakeMesh(meshCreatedRope, true);
        ropemeshCollider.sharedMesh = meshCreatedRope;
    }

    void DrawLineRenderer_Update()
    {
        for (int i = 0; i < lineCount; i++)
        {
            ropeMesh.SetPosition(i, parentObj.transform.GetChild(i).position);
        }
    }

    private void Awake()
    {
        //CreateMesh();
    }

    // Update is called once per frame
    void Update()
    {
        DrawLineRenderer_Update();
    }
}
