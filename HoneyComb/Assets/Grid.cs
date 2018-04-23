using UnityEngine;

public class Grid : MonoBehaviour 
{
	public Transform hexPrefab;

	public int sq = 11;
	public int sideadd = 11;


	float hexWidth = 1.732f;
	float hexHeight = 2.0f;
	public float gap = 0.0f;

	Vector3 startPos;

	void Start()
	{
		AddGap();
		CalcStartPos();
		CreateGrid();
	}

	void AddGap()
	{
		hexWidth += hexWidth * gap;
		hexHeight += hexHeight * gap;
	}

	void CalcStartPos()
	{
		float offset = 0;
		if (sq / 2 % 2 != 0)
			offset = hexWidth / 2;

		float x = -hexWidth * (sq / 2) - offset;
		float z = hexHeight * 0.75f * (sq / 2);

		startPos = new Vector3(x, 0, z);
	}

	Vector3 CalcWorldPos(Vector2 gridPos)
	{
		float offset = 0;
		if (gridPos.y % 2 != 0)
			offset = hexWidth / 2;

		float x = startPos.x + gridPos.x * hexWidth + offset;
		float z = startPos.z - gridPos.y * hexHeight * 0.75f;

		return new Vector3(x, 0, z);
	}

	void CreateGrid()
	{
		for (int y = 0; y < sq; y++)
		{
			for (int x = 0; x < sq; x++)
			{
				Transform hex = Instantiate(hexPrefab) as Transform;
				Vector2 gridPos = new Vector2(x, y);
				hex.position = CalcWorldPos(gridPos);
				hex.parent = this.transform;
				hex.name = "Hexagon" + x + "|" + y;
			}
		}
		for (int y = sq; y < (sq+1); y++) {
			for (int x = 0; x < sideadd; x++) {
				Transform hex = Instantiate (hexPrefab) as Transform;
				Vector2 gridPos = new Vector2 (x, y);
				hex.position = CalcWorldPos (gridPos);
				hex.parent = this.transform;
				hex.name = "Hexagon" + x + "|" + y;
			}
		}
	}
}