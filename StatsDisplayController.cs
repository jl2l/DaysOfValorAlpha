using ListView;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatsDisplayController : AdvancedList
{

    public DoV_Vehicle DisplayVehicle;
  

    readonly Dictionary<string, ModelPool> m_Models = new Dictionary<string, ModelPool>();
    readonly Dictionary<string, Vector3> m_TemplateSizes = new Dictionary<string, Vector3>();
   
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    protected override void Setup()
    {
        base.Setup();
        foreach (var kvp in m_Templates)
        {
            m_TemplateSizes[kvp.Key] = GetObjectSize(kvp.Value.prefab);
        }

        TextAsset text = Resources.Load<TextAsset>(dataFile);
        if (text)
        {
            JSONObject obj = new JSONObject(text.text);
            data = new AdvancedListItemData[obj.Count];
            for (int i = 0; i < data.Length; i++)
            {
                data[i] = new AdvancedListItemData();
                data[i].FromJSON(obj[i], this);
            }
        }
        else data = new AdvancedListItemData[0];

        if (models.Length < 1)
        {
            Debug.LogError("No models!");
        }
        foreach (var model in models)
        {
            if (m_Models.ContainsKey(model.name))
                Debug.LogError("Two templates cannot have the same name");
            m_Models[model.name] = new ModelPool(model);
        }
    }
}
