using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RopeCreator : MonoBehaviour
{
    public GameObject parentObject;
    public GameObject partPrefab;
   // public GameObject presserPrefab;
    public int ropePartCount;
    public Material meshMaterial;

    public void Spawn()
    {
        GameObject lineMesh = new GameObject();
        LineUpdaterScript lineUpdater = lineMesh.AddComponent<LineUpdaterScript>();
        lineUpdater.mesh=lineMesh;
        lineUpdater.lineCount = ropePartCount;
        lineUpdater.meshMaterial = meshMaterial;
        lineUpdater.CreateMesh();


        parentObject = SpawnEmptyParent();


        GameObject firstPart = createParts(parentObject.transform);

        firstPart.transform.eulerAngles = new Vector3(-90, 0, 0);

        DestroyImmediate(firstPart.GetComponent<CharacterJoint>());

        firstPart.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;



        for (int i = 0; i < ropePartCount-1; i++)
        {
            GameObject ropeParts = createParts(parentObject.transform.GetChild(i));
            ropeParts.transform.eulerAngles = new Vector3(-90, 0, 0);

            ropeParts.GetComponent<CharacterJoint>().connectedBody = parentObject.transform.GetChild(i).GetComponent<Rigidbody>();
        }

        parentObject.transform.GetChild(parentObject.transform.childCount - 1).GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;

        lineUpdater.parentObj = parentObject;

        foreach (Transform ropePart in parentObject.transform)
            ropePart.GetComponent<MeshRenderer>().enabled = false;
        

    }

    GameObject createParts(Transform _obj)
    {
        return Instantiate(partPrefab, new Vector3(_obj.position.x, _obj.position.y, _obj.position.z + 2f), Quaternion.identity, parentObject.transform);
    }
    
    GameObject SpawnEmptyParent()
    {
        GameObject ropeHolder = new GameObject();
        ropeHolder.name = "Holder";
        return ropeHolder;
    }
}