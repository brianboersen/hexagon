using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateHexagon : MonoBehaviour
{
    private Vector3[] newVertices;
    private int[] newTriangles;

    [SerializeField]
    private Material defaultMat;

    void Awake()
    {
        //creating triangles beforehand, because this 3d hexagon always has the same triangle pattern
        newTriangles = new int[] {0,1,2,0,2,3,0,3,4,0,4,5,0,5,6,0,6,1};//upper part 0,1,2,0,2,3,0,3,4,0,4,5,0,5,6,0,6,1

        //test
        //createNewHexagon(1);
    }

    //creating a 3d hexagon
    public GameObject createNewHexagon(float size, Material material = null)
    { 
        //creating and array of vertesices
        calcVertices(size);

        //greating hexagon object
        GameObject hexagon = new GameObject();

        //putting the nessesary components on the hexagon
        hexagon.AddComponent<MeshFilter>();
        hexagon.AddComponent<MeshRenderer>();  

        //getting the mesh an renderer of the hexagon
        Mesh mesh = hexagon.GetComponent<MeshFilter>().mesh;
        MeshRenderer renderer = hexagon.GetComponent<MeshRenderer>();

        //put material on object
        if(material == null)
            renderer.sharedMaterial = defaultMat;
        else
            renderer.sharedMaterial = material;

        //set mesh
        mesh.vertices = newVertices;
        mesh.triangles = newTriangles;

        //this is for lighting
        mesh.RecalculateNormals();

        return hexagon;
    }

    private void calcVertices(float size)
    {
        // get b lenght with pythagoras
        float halfSize = size * 0.5f;
        float bSize = Mathf.Sqrt((size*size) - (halfSize * halfSize));

        // set the vertices of the hexagon
        newVertices = new Vector3[] { new Vector3(0, halfSize, 0), new Vector3(0, halfSize, size), new Vector3(bSize, halfSize, halfSize),new Vector3(bSize, halfSize, -halfSize), new Vector3(0, halfSize, -size), new Vector3(-bSize, halfSize, -halfSize), new Vector3(-bSize, halfSize, halfSize), new Vector3(0, -halfSize, 0), new Vector3(0, -halfSize, size), new Vector3(bSize, -halfSize, halfSize), new Vector3(bSize, -halfSize, -halfSize), new Vector3(0, -halfSize, -size), new Vector3(-bSize, -halfSize, -halfSize), new Vector3(-bSize, -halfSize, halfSize) };
    }
}
