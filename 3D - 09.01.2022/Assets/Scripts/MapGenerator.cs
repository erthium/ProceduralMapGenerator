using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    [Header("Main Requirements")]
    public GameObject land;
    public LayerMask land_layer_mask;
    public GameObject parent_objects;

    Vector3 land_position;
    float width;
    float height;
    float max_height;

    [Header("Map Objects")]
    public GameObject camp;
    public int camp_amount = 1;
    public float camp_radius_for_camps = 12f;
    public float camp_radius_for_env = 6f;

    [Space]

    public GameObject tree;
    public int tree_amount = 1;
    public float tree_radius = 2f;

    GameObject[] all_camps;
    GameObject[] all_trees;

    int max_while_loop = 2000;


    public void Clear()
    {
        for (int i = 0; i < parent_objects.transform.childCount; i++)
        {
            Destroy(parent_objects.transform.GetChild(i).gameObject);
        }
    }

    public void First()
    {
        all_camps = new GameObject[camp_amount];
        all_trees = new GameObject[tree_amount];
    }


    public void Initiate()
    {
        for (int i = 0; i < parent_objects.transform.childCount; i++)
        {
            Destroy(parent_objects.transform.GetChild(i).gameObject);
        }

        land_position = land.transform.position;
        width = land.GetComponent<MeshGenerator>().widht;
        height = land.GetComponent<MeshGenerator>().height;

        max_height = land.GetComponent<MeshGenerator>().sensitivity + 5;

        //camp_amount = Random.Range(2, 4);
        //tree_amount = Random.Range(5, 10);

    }

    public void Generate()
    {
        foreach (GameObject item in all_camps)
        {
            if (item)
            {
                Destroy(item);
            }
        }
        foreach (GameObject item in all_trees)
        {
            if (item)
            {
                Destroy(item);
            }
        }

        all_camps = new GameObject[camp_amount];
        all_trees = new GameObject[tree_amount];

        int number_of_times_max_loop_was_reached = 0;

        for (int i = 0; i < camp_amount; i++)
        {
            float camp_width = camp.transform.localScale.x; //assuming that it is a squre, no need to get "y" scale
            int while_counter = 0;
            while (true)
            {
                if (while_counter > max_while_loop)
                {
                    number_of_times_max_loop_was_reached++;
                    break;
                }
                while_counter++;
                bool continue_true = false;

                Vector3 new_position = new Vector3(Random.Range(land_position.x + camp_width / 2, land_position.x + width - camp_width / 2),
                    max_height,
                    Random.Range(land_position.y + camp_width / 2, land_position.y + height - camp_width / 2));

                foreach (GameObject item in all_camps)
                {
                    if (item)
                    {
                        if (IsPointInCircle(new_position, item.transform.position, camp_radius_for_camps))
                        {
                            continue_true = true;
                        }
                    }
                }

                foreach (GameObject item in all_trees)
                {
                    if (item)
                    {
                        if (IsPointInCircle(new_position, item.transform.position, tree_radius))
                        {
                            continue_true = true;
                        }
                    }
                }
                if (continue_true)
                {
                    continue;
                }


                GameObject new_camp = Instantiate(camp, parent_objects.transform);
                new_camp.transform.position = new_position;



                Ray ray = new Ray(new_camp.transform.GetChild(0).position, Vector3.down);

                if (Physics.Raycast(ray, out RaycastHit hit, 100, land_layer_mask))
                {
                    new_camp.transform.position -= Vector3.up * (hit.distance);
                    all_camps[i] = new_camp;
                }
                else 
                {
                    Destroy(new_camp);
                    continue; 
                }
                break;
            }
        }

        for (int i = 0; i < tree_amount; i++)
        {
            float tree_width = tree.transform.localScale.x;
            int while_counter = 0;
            while (true)
            {
                if (while_counter > max_while_loop)
                {
                    number_of_times_max_loop_was_reached++;
                    break;
                }
                while_counter++;
                bool continue_true = false;

                Vector3 new_position = new Vector3(Random.Range(land_position.x + tree_width / 2, land_position.x + width - tree_width / 2),
                    max_height,
                    Random.Range(land_position.y + tree_width / 2, land_position.y + height - tree_width / 2));

                foreach (GameObject item in all_camps)
                {
                    if (item)
                    {
                        if (IsPointInCircle(new_position, item.transform.position, camp_radius_for_env))
                        {
                            continue_true = true;
                        }
                    }
                }

                foreach (GameObject item in all_trees)
                {
                    if (item)
                    {
                        if (IsPointInCircle(new_position, item.transform.position, tree_radius))
                        {
                            continue_true = true;
                        }
                    }
                }
                if (continue_true)
                {
                    continue;
                }


                GameObject new_tree = Instantiate(tree, parent_objects.transform);
                new_tree.transform.position = new_position;



                Ray ray = new Ray(new_tree.transform.GetChild(0).position, Vector3.down);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit, land_layer_mask))
                {
                    new_tree.transform.position -= Vector3.up * (hit.distance);
                    all_trees[i] = new_tree;
                }
                else 
                {
                    Destroy(new_tree);
                    continue; 
                }
                break;
            }
        }

        print(string.Format("Max loop was reached {0} times", number_of_times_max_loop_was_reached));
    }

    bool IsPointInCircle(Vector3 point, Vector3 target, float radius)
    {
        float distance = Mathf.Sqrt(Mathf.Pow(target.x - point.x, 2) + Mathf.Pow(target.z - point.z, 2));
        return (radius >= distance);
    }

}
