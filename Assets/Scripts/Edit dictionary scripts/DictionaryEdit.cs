using UnityEngine;

public class DictionaryEdit : MonoBehaviour
{
    public DictionaryEditor editor;

    public void Loading(string key)
    {
        if (string.IsNullOrEmpty(key))
            Debug.Log("The 'Key' field is empty!");
        else
        {
            if (!editor.imgList.Exists(x => x.key == key))
            {
                editor.imgList.Add(new DictionaryEditor.DictList() { key = key });
                Debug.Log("Added!");
            }
            else
                Debug.Log("The Key already exists!");
        }
    }

    public void Deleting(string key)
    {
        if (string.IsNullOrEmpty(key))
            Debug.Log("The 'Key' field is empty!");
        else
        {
            if (editor.imgList.Exists(x => x.key == key))
            {
                int keyId = editor.imgList.FindIndex(x => x.key == key);
                editor.imgList.RemoveAt(keyId);
                Debug.Log("Deleted!");
            } 
            else
                Debug.Log("The Key doesn't exist!");
        }
    }
}