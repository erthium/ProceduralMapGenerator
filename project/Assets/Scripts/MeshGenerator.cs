using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshFilter))]
[RequireComponent(typeof(MeshCollider))]
public class MeshGenerator : MonoBehaviour
{
    Mesh generated_mesh;
    MeshCollider mesh_collider;

    Vector3[] vertices;
    int[] triangles;
    Vector2[] uvs;

    [Header("Map Settings")]
    public int widht = 20;
    public int height = 20;

    [Header("Perlin Noise Settings")]
    public float sensitivity = 3f;
    public float perlin_multiplier = .1f;



    void Start()
    {
        generated_mesh = new Mesh();
        mesh_collider = GetComponent<MeshCollider>();
        GetComponent<MeshFilter>().mesh = generated_mesh;
        CreateShape();
        Generate();
    }

    public void Initiate()
    {
        generated_mesh = new Mesh();
        mesh_collider = GetComponent<MeshCollider>();
        GetComponent<MeshFilter>().mesh = generated_mesh;
    }


    public void CreateShape()
    {
        int offset_x = Random.Range(0, 10000);
        int offset_z = Random.Range(0, 10000);

        if (widht == 0 || height == 0)
        {
            return;
        }

        vertices = new Vector3[(widht + 1) * (height + 1)];
        for(int i = 0, z = 0; z <= height; z++)
        {
            for (int x = 0; x <= widht; x++)
            {
                float y = Mathf.PerlinNoise((x + offset_x) * perlin_multiplier, (z + offset_z) * perlin_multiplier) * sensitivity;
                vertices[i] = new Vector3(x, y, z);
                i++;
            }
        }


        uvs = new Vector2[vertices.Length];

        for (int i = 0; i < uvs.Length; i++)
        {
            uvs[i] = new Vector2(vertices[i].x, vertices[i].z);
        }


        triangles = new int[widht * height * 6];

        int vert = 0;
        int tris = 0;

        for (int z = 0; z < height; z++)
        {
            for (int x = 0; x < widht; x++)
            {
                triangles[tris + 0] = vert + 0;
                triangles[tris + 1] = vert + widht + 1;
                triangles[tris + 2] = vert + 1;
                triangles[tris + 3] = vert + 1;
                triangles[tris + 4] = vert + widht + 1;
                triangles[tris + 5] = vert + widht + 2;

                vert++;
                tris += 6;
            }
            vert++;
        }


    }

    public void Generate()
    {
        generated_mesh.Clear();

        generated_mesh.vertices = vertices;
        generated_mesh.triangles = triangles;
        generated_mesh.uv = uvs;

        generated_mesh.RecalculateNormals();

        mesh_collider.sharedMesh = generated_mesh;
    }

}
