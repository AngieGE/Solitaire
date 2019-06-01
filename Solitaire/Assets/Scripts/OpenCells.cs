using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenCells : MonoBehaviour
{
    public static List<OpenCells> OpenCellsList = new List<OpenCells>();
    // Start is called before the first frame update
      private void OnEnable()
    {
        if(OpenCellsList.Contains(this)) return;
        OpenCellsList.Add(this);
    }

    private void OnDisable()
    {
        if(OpenCellsList.Contains(this) == false) return;
        OpenCellsList.Remove(this);
    }

}
