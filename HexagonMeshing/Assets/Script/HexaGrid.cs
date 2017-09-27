using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HexaGrid : MonoBehaviour
{
    [SerializeField]
    private float hexagonSize = 1;

    [SerializeField]
    private int gridXSize = 11;

    [SerializeField]
    private int gridYSize = 3;

    public GameObject[,] hexagrid;

    private CreateHexagon createHex;

    void Start ()
    {
        hexagrid = new GameObject[gridXSize, gridYSize];
        createHex = GetComponent<CreateHexagon>();
        createGrid();
    }

    //zet hexagons in script
    public void createGrid()
    {
        //GameObject hexagon = createHex.createNewHexagon(hexagonSize);
        int gritXLenght = hexagrid.GetLength(0);

        float gridRowStep;

        //side step calculate
        float upStepSize = Mathf.Sqrt((hexagonSize * hexagonSize) - ((hexagonSize * 0.5f) * (hexagonSize * 0.5f)));

        for (int x = 0; x < gritXLenght; x++)//gritXLenght
        {
            if (x % 2 == 0)
            {
                gridRowStep = 0;
            }
            else
            {
                gridRowStep = hexagonSize * 1.5f;
            }

            for (int y = 0; y < hexagrid.GetLength(1); y++)
            {
                //create new hexagon
                GameObject newHexagon = createHex.createNewHexagon(hexagonSize); //Instantiate(hexagon, Vector3.zero, Quaternion.identity);

                newHexagon.name = "hexagon " + ((x * gritXLenght) + y);

                //put hexagon in the correct spot
                newHexagon.transform.localPosition = new Vector3(x * upStepSize,0, (y * (hexagonSize * 3)) + gridRowStep);

                //add hexagen to grid array
                hexagrid[x, y] = newHexagon;
            }
        }
    }
}
