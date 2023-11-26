using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadingFile 
{
    public float FileSize {  get; private set; }
    public float LoadedSize {  get; private set; }

    public EventHandler OnFileLoaded;
    public LoadingFile(float size)
    {
        FileSize = size;
        LoadedSize = 0f;
    }

    public void Load(double size)
    {
        if (LoadedSize + size > FileSize)
        {
            LoadedSize = FileSize;
            //start event
            OnFileLoaded?.Invoke(this, EventArgs.Empty);
        }
        else LoadedSize += (float) size;
        
    }
}
