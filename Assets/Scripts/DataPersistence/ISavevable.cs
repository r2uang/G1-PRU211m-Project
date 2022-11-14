using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISavevable
{
    object SaveState();

    void LoadState(object state);   
}
