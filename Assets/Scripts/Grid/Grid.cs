using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.XR;

public class Grid : Singletone<Grid>
{
    [SerializeField] private Cell cellSample;

    [SerializeField] private Map<int, Map<int, Map<int, Cell>>> cells = new Map<int, Map<int, Map<int, Cell>>>(
        () => new Map<int, Map<int, Cell>>(
            () => new Map<int, Cell>()
        )
    );

    public void SwitchCell(IntVector3 c) {
        if (cells[c.x][c.y][c.z] == null) {
            CellOn(c.x, c.y, c.z);
        } else {
            CellOff(c.x, c.y, c.z);
        }
    }

    public void CellOn(int x, int y, int z) {
        var cell = cells[x][y][z] = Instantiate(cellSample);
        cell.transform.SetParent(transform, worldPositionStays: false);
        cell.transform.localPosition = new Vector3(x, y, z);
    }

    public void CellOff(int x, int y, int z) {
        Extensions.Destroy(cells[x][y][z].gameObject);
        cells[x][y][z] = null;
    }
}
