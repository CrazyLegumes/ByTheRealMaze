using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestMazeMap : MonoBehaviour {

    MazeMap map = new MazeMap();

	// Use this for initialization
	void Start ()
    {
        ExampleMethod();
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    public void ExampleMethod()
    {
        ///This method demonstrates various usabilities of the MazeMap class
        ///Uncomment sections of code to observe how they work.

        ///         Visualiztion of maze structure:
        ///         [1,0] is an example of a tile entry in the position of (x:1, y:0)
        ///         thus, as visualized, x values represent columns and the y values represent rows
        /// 
        ///         [4,3][3,3][2,3][1,3][0,3]
        ///         [4,2][3,2][2,2][1,2][0,2]
        ///         [4,1][3,1][2,1][1,1][0,1]
        ///         [4,0][3,0][2,0][1,0][0,0]
        ///         
        ///         Maze  displayed would be a height of 4 and a width of 5

        ///This call demonstrates how to create the map. This must be called first before any other calls.
        ///map.CreateMap(10, 5, 312);

        int x = 1; int y = 1;

        ///These calls will delete the walls of a specific tile, opening up paths.
        ///------------------------------------------------------------------------------------------------------
        ///map.DeleteWall(x, y, "Top");
        ///map.DeleteWall(x, y, "Bottom");
        ///map.DeleteWall(x, y, "Left");
        ///map.DeleteWall(x, y, "Right");

        ///These calls will determine whether you can move in a specific direction from the specified tile.
        ///------------------------------------------------------------------------------------------------------
        ///Debug.Log("Can move up from (x: " + x + ", y: " + y + "): " + map.CanMove(x, y, "Up"));
        ///Debug.Log("Can move down from (x: " + x + ", y: " + y + "): " + map.CanMove(x, y, "Down"));
        ///Debug.Log("Can move left from (x: " + x + ", y: " + y + "): " + map.CanMove(x, y, "Left"));
        ///Debug.Log("Can move right from (x: " + x + ", y: " + y + "): " + map.CanMove(x, y, "Right"));

        ///These calls demonstrate how to move the player object and other related functions.
        ///Note: CreatePlayer() method must be called for these to work!
        ///------------------------------------------------------------------------------------------------------
        ///map.CreatePlayer(x, y);
        ///Debug.Log("Player position: (x: " + map.GetPlayerX() +", y: " + map.GetPlayerY() + ")");
        ///Debug.Log("Attemting to move player down. Successful: " + map.MovePlayer("Down"));
        ///Debug.Log("Attemting to move player up. Successful: " + map.MovePlayer("Up"));
        ///Debug.Log("Attemting to move player right. Successful: " + map.MovePlayer("Right"));
        ///Debug.Log("Attemting to move player left. Successful: " + map.MovePlayer("Left"));
        ///Debug.Log("Player position: (x: " + map.GetPlayerX() + ", y: " + map.GetPlayerY() + ")");

        ///These calls demonsrate how to detect whether or not the player exist on a tile.
        ///map.CreatePlayer(1, 1);
        ///Debug.Log("Player exists on this tile: " + map.HasPlayer(1, 1));
        ///Debug.Log("Player exists to the left: " + map.HasPlayer(0, 1, "Left"));
        ///Debug.Log("Player exists to the right: " + map.HasPlayer(2, 1, "Right"));
        ///Debug.Log("Player exists to the north: " + map.HasPlayer(1, 0, "Up"));
        ///Debug.Log("Player exists to the south: " + map.HasPlayer(1, 2, "Down"));

        ///These calls demonstrate how to move enemy objects and other related functions.
        ///------------------------------------------------------------------------------------------------------
        ///map.SpawnEnemy("Enemy01", 1, 1);
        ///Debug.Log("Enemy position: (x: " + map.GetEnemyX("Enemy01") +", y: " + map.GetEnemyY("Enemy01") + ")");
        ///Debug.Log("Attemting to move enemy down. Successful: " + map.MoveEnemy("Down", "Enemy01"));
        ///Debug.Log("Attemting to move enemy up. Successful: " + map.MoveEnemy("Up", "Enemy01"));
        ///Debug.Log("Attemting to move enemy right. Successful: " + map.MoveEnemy("Right", "Enemy01"));
        ///Debug.Log("Attemting to move enemy left. Successful: " + map.MoveEnemy("Left", "Enemy01"));
        ///Debug.Log("Enemy position: (x: " + map.GetEnemyX("Enemy01") + ", y: " + map.GetEnemyY("Enemy01") + ")");

        ///These calls demonstrate how to detect whether or not an enemy exist on a tile.
        ///------------------------------------------------------------------------------------------------------
        ///map.SpawnEnemy("Enemy01", 1, 1);
        ///Debug.Log("Enemy exists on this tile: " + map.HasEnemy(1, 1));
        ///Debug.Log("Enemy exists to the left: " + map.HasEnemy(0, 1, "Left"));
        ///Debug.Log("Enemy exists to the right: " + map.HasEnemy(2, 1, "Right"));
        ///Debug.Log("Enemy exists to the north: " + map.HasEnemy(1, 0, "Up"));
        ///Debug.Log("Enemy exists to the south: " + map.HasEnemy(1, 2, "Down"));

        ///These calls demonstrate how to lower and raise walls.
        ///map.LowerSide(1, 1, "Top");
        ///map.LowerSide(1, 1, "Bottom");
        ///map.LowerSide(1, 1, "Left");
        ///map.LowerSide(1, 1, "Right");
        ///Debug.Log("Can move up: " + map.CanMove(1, 1, "Up"));
        ///Debug.Log("Can move down: " + map.CanMove(1, 1, "Down"));
        ///Debug.Log("Can move left: " + map.CanMove(1, 1, "Left"));
        ///Debug.Log("Can move right: " + map.CanMove(1, 1, "Right"));
        ///map.RaiseSide(1, 1, "Top");
        ///map.RaiseSide(1, 1, "Bottom");
        ///map.RaiseSide(1, 1, "Left");
        ///map.RaiseSide(1, 1, "Right");
        ///Debug.Log("Can move up: " + map.CanMove(1, 1, "Up"));
        ///Debug.Log("Can move down: " + map.CanMove(1, 1, "Down"));
        ///Debug.Log("Can move left: " + map.CanMove(1, 1, "Left"));
        ///Debug.Log("Can move right: " + map.CanMove(1, 1, "Right"));
        ///Debug.Log("Can move up: " + map.CanMove(1, 0, "Up"));
        ///Debug.Log("Can move down: " + map.CanMove(1, 2, "Down"));
        ///Debug.Log("Can move left: " + map.CanMove(0, 1, "Left"));
        ///Debug.Log("Can move right: " + map.CanMove(2, 1, "Right"));

    }


}
