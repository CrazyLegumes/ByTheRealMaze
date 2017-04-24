using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstMap : MonoBehaviour {


    MazeMap map = new MazeMap();

    // Use this for initialization
    void Start ()
    {
        GenMaze();
    }
	
	// Update is called once per frame
	void Update ()
    {
		
	}


    public void GenMaze()
    {
        map.CreateMap(21, 21, 3212);

        map.DeleteWall(9, 0, "Top");
        map.DeleteWall(10, 0, "Top");
        map.DeleteWall(10, 0, "Left");
        map.DeleteWall(10, 0, "Right");
        map.DeleteWall(11, 0, "Top");
        map.DeleteWall(9, 1, "Top");
        map.DeleteWall(10, 1, "Top");
        map.DeleteWall(10, 1, "Left");
        map.DeleteWall(10, 1, "Right");
        map.DeleteWall(11, 1, "Top");
        map.DeleteWall(10, 2, "Top");
        map.DeleteWall(10, 2, "Left");
        map.DeleteWall(10, 2, "Right");
        map.DeleteWall(10, 3, "Left");
        //map.DeleteWall(10, 3, "Right");
        map.DeleteWall(11, 3, "Left");
        map.DeleteWall(12, 3, "Left");
        map.DeleteWall(12, 3, "Bottom");
        map.DeleteWall(12, 2, "Bottom");
        map.DeleteWall(12, 1, "Bottom");
        map.DeleteWall(12, 0, "Bottom");
        map.DeleteWall(12, 0, "Left");
        map.DeleteWall(13, 0, "Left");
        map.DeleteWall(14, 0, "Left");
        map.DeleteWall(14, 0, "Top");
        map.DeleteWall(15, 0, "Top");
        map.DeleteWall(14, 1, "Top");
        map.DeleteWall(14, 1, "Left");
        map.DeleteWall(15, 1, "Top");
        map.DeleteWall(14, 2, "Left");
        map.DeleteWall(14, 2, "Right");
        map.DeleteWall(13, 2, "Bottom");
        map.DeleteWall(15, 2, "Left");
        map.DeleteWall(16, 2, "Left");
        map.DeleteWall(17, 2, "Left");
        map.DeleteWall(17, 2, "Bottom");
        map.DeleteWall(17, 1, "Left");
        map.DeleteWall(17, 1, "Right");
        map.DeleteWall(16, 1, "Bottom");
        map.DeleteWall(16, 0, "Left");
        map.DeleteWall(17, 0, "Left");
        map.DeleteWall(18, 0, "Left");
        map.DeleteWall(19, 0, "Left");
        map.DeleteWall(20, 0, "Top");
        map.DeleteWall(18, 1, "Left");
        map.DeleteWall(19, 1, "Bottom");
        map.AddShiftableWall(20, 1, "Top");     //Shifting Wall
        map.DeleteWall(20, 2, "Top");
        map.DeleteWall(20, 3, "Top");
        map.DeleteWall(20, 4, "Top");
        map.DeleteWall(20, 5, "Top");
        map.DeleteWall(20, 6, "Top");
        map.DeleteWall(20, 6, "Right");
        map.DeleteWall(19, 6, "Right");
        map.DeleteWall(18, 6, "Right");
        map.DeleteWall(17, 6, "Top");
        map.DeleteWall(17, 6, "Right");
        map.DeleteWall(17, 7, "Right");
        map.DeleteWall(17, 5, "Right");
        map.DeleteWall(17, 6, "Bottom");
        map.DeleteWall(16, 6, "Top");
        map.DeleteWall(16, 6, "Right");
        map.DeleteWall(16, 7, "Right");
        map.DeleteWall(16, 5, "Right");
        map.DeleteWall(16, 6, "Bottom");
        map.DeleteWall(15, 6, "Top");
        map.DeleteWall(15, 6, "Right");
        map.DeleteWall(15, 7, "Right");
        map.DeleteWall(15, 5, "Right");
        map.DeleteWall(15, 6, "Bottom");
        map.DeleteWall(14, 6, "Bottom");
        map.DeleteWall(14, 6, "Top");
        map.DeleteWall(14, 6, "Right");
        map.DeleteWall(13, 6, "Bottom");
        map.DeleteWall(13, 5, "Bottom");
        map.DeleteWall(13, 4, "Left");
        map.DeleteWall(14, 4, "Left");
        map.DeleteWall(15, 4, "Left");
        map.DeleteWall(16, 4, "Bottom");
        map.AddShiftableWall(16, 3, "Bottom"); //Shifting wall
        map.DeleteWall(16, 3, "Right");
        map.DeleteWall(15, 3, "Right");
        map.DeleteWall(14, 3, "Right");
        map.AddShiftableWall(16, 3, "Left"); //Shifting Wall
        map.DeleteWall(17, 3, "Left");
        map.DeleteWall(18, 3, "Left");
        map.DeleteWall(19, 3, "Top");
        map.AddShiftableWall(19, 3, "Bottom"); //Shifting Wall
        map.DeleteWall(19, 4, "Top");
        map.DeleteWall(19, 5, "Right");
        map.DeleteWall(18, 5, "Bottom");
        map.DeleteWall(18, 4, "Right");
        map.DeleteWall(17, 4, "Right");
        map.DeleteWall(20, 7, "Top");
        map.DeleteWall(20, 8, "Top");
        map.DeleteWall(20, 9, "Top");
        map.DeleteWall(20, 8, "Right");
        map.DeleteWall(19, 8, "Bottom");
        map.DeleteWall(19, 7, "Right");
        map.DeleteWall(18, 7, "Top");
        map.DeleteWall(18, 8, "Right");
        map.DeleteWall(20, 10, "Right");
        map.DeleteWall(19, 10, "Right");
        map.DeleteWall(18, 10, "Right");
        map.DeleteWall(18, 10, "Bottom");
        map.DeleteWall(18, 9, "Left");
        map.DeleteWall(18, 9, "Right");
        map.DeleteWall(17, 10, "Top");
        map.DeleteWall(17, 11, "Left");
        map.DeleteWall(18, 11, "Top");
        map.DeleteWall(18, 12, "Left");
        map.DeleteWall(19, 12, "Left");
        map.DeleteWall(20, 11, "Top");
        map.DeleteWall(20, 11, "Right");
        //map.DeleteWall(10, 20, "Top"); Opens when boss defeat
        map.DeleteWall(10, 20, "Bottom");
        map.DeleteWall(11, 20, "Bottom");
        map.DeleteWall(12, 20, "Bottom");
        map.DeleteWall(13, 20, "Bottom");
        map.DeleteWall(9, 20, "Bottom");
        map.DeleteWall(8, 20, "Bottom");
        map.DeleteWall(7, 20, "Bottom");
        map.DeleteWall(10, 20, "Left");
        map.DeleteWall(10, 20, "Right");
        map.DeleteWall(11, 20, "Left");
        map.DeleteWall(12, 20, "Left");
        map.DeleteWall(11, 19, "Left");
        map.DeleteWall(12, 19, "Left");
        map.DeleteWall(11, 18, "Left");
        map.DeleteWall(12, 18, "Left");
        map.DeleteWall(11, 17, "Left");
        map.DeleteWall(12, 17, "Left");
        map.DeleteWall(11, 16, "Left");
        map.DeleteWall(12, 16, "Left");
        map.DeleteWall(11, 15, "Left");
        map.DeleteWall(12, 15, "Left");
        map.DeleteWall(9, 20, "Right");
        map.DeleteWall(8, 20, "Right");
        map.DeleteWall(9, 19, "Right");
        map.DeleteWall(8, 19, "Right");
        map.DeleteWall(9, 18, "Right");
        map.DeleteWall(8, 18, "Right");
        map.DeleteWall(9, 17, "Right");
        map.DeleteWall(8, 17, "Right");
        map.DeleteWall(9, 16, "Right");
        map.DeleteWall(8, 16, "Right");
        map.DeleteWall(9, 15, "Right");
        map.DeleteWall(8, 15, "Right");
        map.DeleteWall(7, 20, "Right");
        map.DeleteWall(7, 19, "Right");
        map.DeleteWall(7, 17, "Right");
        map.DeleteWall(7, 16, "Right");
        map.DeleteWall(7, 18, "Right");
        map.DeleteWall(7, 15, "Right");
        map.DeleteWall(6, 20, "Bottom");
        map.DeleteWall(6, 19, "Bottom");
        map.DeleteWall(6, 18, "Bottom");
        map.DeleteWall(6, 17, "Bottom");
        map.DeleteWall(6, 16, "Bottom");
        map.DeleteWall(10, 19, "Bottom");
        map.DeleteWall(10, 19, "Left");
        map.DeleteWall(10, 19, "Right");
        map.DeleteWall(11, 19, "Bottom");
        map.DeleteWall(12, 19, "Bottom");
        map.DeleteWall(13, 19, "Bottom");
        map.DeleteWall(9, 19, "Bottom");
        map.DeleteWall(8, 19, "Bottom");
        map.DeleteWall(7, 19, "Bottom");
        map.DeleteWall(11, 18, "Bottom");
        map.DeleteWall(12, 18, "Bottom");
        map.DeleteWall(13, 18, "Bottom");
        map.DeleteWall(9, 18, "Bottom");
        map.DeleteWall(8, 18, "Bottom");
        map.DeleteWall(7, 18, "Bottom");
        map.DeleteWall(11, 17, "Bottom");
        map.DeleteWall(12, 17, "Bottom");
        map.DeleteWall(13, 17, "Bottom");
        map.DeleteWall(9, 17, "Bottom");
        map.DeleteWall(8, 17, "Bottom");
        map.DeleteWall(7, 17, "Bottom");
        map.DeleteWall(11, 16, "Bottom");
        map.DeleteWall(12, 16, "Bottom");
        map.DeleteWall(13, 16, "Bottom");
        map.DeleteWall(9, 16, "Bottom");
        map.DeleteWall(8, 16, "Bottom");
        map.DeleteWall(7, 16, "Bottom");
        map.DeleteWall(10, 18, "Bottom");
        map.DeleteWall(10, 18, "Left");
        map.DeleteWall(10, 18, "Right");
        map.DeleteWall(10, 17, "Bottom");
        map.DeleteWall(10, 17, "Left");
        map.DeleteWall(10, 17, "Right");
        map.DeleteWall(10, 16, "Bottom");
        map.DeleteWall(10, 16, "Left");
        map.DeleteWall(10, 16, "Right");
        map.DeleteWall(10, 15, "Bottom");
        map.DeleteWall(10, 15, "Left");
        map.DeleteWall(10, 15, "Right");
        map.DeleteWall(12, 13, "Left");
        map.DeleteWall(11, 13, "Left");
        map.DeleteWall(10, 13, "Left");
        map.DeleteWall(9, 13, "Left");
        map.DeleteWall(8, 13, "Left");
        map.DeleteWall(7, 13, "Left");
        map.DeleteWall(6, 13, "Left");
        map.DeleteWall(12, 14, "Left");
        map.DeleteWall(11, 14, "Left");
        map.DeleteWall(10, 14, "Left");
        map.DeleteWall(9, 14, "Left");
        map.DeleteWall(8, 14, "Left");
        map.DeleteWall(7, 14, "Left");
        map.DeleteWall(6, 14, "Left");
        map.DeleteWall(13, 15, "Bottom");
        map.DeleteWall(12, 15, "Bottom");
        map.DeleteWall(11, 15, "Bottom");
        map.DeleteWall(9, 15, "Bottom");
        map.DeleteWall(8, 15, "Bottom");
        map.DeleteWall(7, 15, "Bottom");
        map.DeleteWall(6, 15, "Bottom");
        map.DeleteWall(13, 14, "Bottom");
        map.DeleteWall(12, 14, "Bottom");
        map.DeleteWall(11, 14, "Bottom");
        map.DeleteWall(10, 14, "Bottom");
        map.DeleteWall(9, 14, "Bottom");
        map.DeleteWall(8, 14, "Bottom");
        map.DeleteWall(7, 14, "Bottom");
        map.DeleteWall(6, 14, "Bottom");
        //End boss tiles
        map.DeleteWall(6, 13, "Right");
        map.DeleteWall(5, 13, "Right");
        map.DeleteWall(13, 13, "Left");
        map.DeleteWall(14, 13, "Left");
        map.DeleteWall(14, 13, "Bottom");
        map.DeleteWall(5, 13, "Bottom");
        map.DeleteWall(14, 12, "Right");
        map.DeleteWall(13, 12, "Right");
        map.DeleteWall(12, 12, "Right");
        map.DeleteWall(11, 12, "Bottom");
        map.DeleteWall(11, 11, "Bottom");
        map.DeleteWall(11, 10, "Bottom");
        map.DeleteWall(11, 9, "Left");
        map.DeleteWall(12, 9, "Left");
        map.DeleteWall(13, 9, "Left");
        map.DeleteWall(13, 9, "Bottom");
        map.DeleteWall(13, 8, "Left");
        map.DeleteWall(14, 8, "Left");
        map.DeleteWall(15, 8, "Top");
        map.DeleteWall(15, 9, "Top");
        map.DeleteWall(15, 10, "Top");
        map.DeleteWall(14, 9, "Top");
        map.DeleteWall(14, 10, "Top");
        map.DeleteWall(14, 11, "Right");
        map.DeleteWall(13, 11, "Right");
        map.DeleteWall(12, 11, "Bottom");
        map.DeleteWall(12, 10, "Left");
        map.AddShiftableWall(17, 8, "Right"); //Shiftable wall
        map.DeleteWall(17, 9, "Right");
        map.DeleteWall(16, 9, "Bottom");
        map.DeleteWall(16, 9, "Top");
        map.DeleteWall(16, 10, "Top");
        map.DeleteWall(16, 11, "Top");
        map.DeleteWall(16, 12, "Left");
        map.DeleteWall(17, 12, "Top");
        map.DeleteWall(17, 13, "Left");
        map.DeleteWall(18, 13, "Left");
        map.DeleteWall(19, 13, "Left");
        map.DeleteWall(19, 13, "Top");
        map.DeleteWall(20, 13, "Top");
        map.DeleteWall(20, 14, "Top");
        map.DeleteWall(20, 15, "Top");
        map.DeleteWall(20, 16, "Top");
        map.DeleteWall(20, 17, "Top");
        map.DeleteWall(20, 18, "Top");
        map.DeleteWall(20, 19, "Top");
        map.DeleteWall(20, 20, "Right");
        map.DeleteWall(19, 20, "Right");
        map.DeleteWall(18, 20, "Right");
        map.DeleteWall(17, 20, "Right");
        map.DeleteWall(16, 20, "Right");
        map.DeleteWall(15, 20, "Right");
        map.DeleteWall(14, 20, "Bottom");
        map.DeleteWall(14, 19, "Bottom");
        map.DeleteWall(14, 18, "Bottom");
        map.DeleteWall(14, 17, "Bottom");
        map.DeleteWall(14, 16, "Left");
        map.DeleteWall(15, 16, "Left");
        map.DeleteWall(16, 16, "Top");
        map.DeleteWall(16, 17, "Top");
        map.DeleteWall(16, 18, "Top");
        map.DeleteWall(16, 19, "Right");
        map.DeleteWall(15, 19, "Bottom");
        map.DeleteWall(15, 18, "Bottom");
        map.AddShiftableWall(15, 16, "Top"); //Shiftable wall
        map.DeleteWall(16, 19, "Left");
        map.DeleteWall(17, 19, "Left");
        map.DeleteWall(18, 19, "Left");
        map.DeleteWall(19, 19, "Bottom");
        map.DeleteWall(19, 18, "Right");
        map.DeleteWall(18, 18, "Right");
        map.DeleteWall(17, 18, "Bottom");
        map.DeleteWall(19, 17, "Right");
        map.DeleteWall(20, 17, "Right");
        map.DeleteWall(18, 17, "Right");
        map.AddShiftableWall(14, 15, "Top"); //shiftable wall
        map.DeleteWall(14, 15, "Bottom");
        map.DeleteWall(14, 14, "Bottom");
        map.AddShiftableWall(15, 12, "Right"); //shiftable wall
        map.DeleteWall(15, 13, "Left");
        map.DeleteWall(16, 13, "Top");
        map.DeleteWall(16, 14, "Right");
        map.DeleteWall(15, 14, "Top");
        map.DeleteWall(15, 15, "Left");
        map.DeleteWall(16, 15, "Left");
        map.DeleteWall(17, 15, "Top");
        map.DeleteWall(17, 15, "Bottom");
        map.DeleteWall(17, 16, "Left");
        map.AddShiftableWall(17, 14, "Left"); //Shifable wall
        map.DeleteWall(18, 14, "Top");
        map.DeleteWall(18, 15, "Left");
        map.DeleteWall(19, 15, "Top");
        map.DeleteWall(19, 14, "Top");















    }


}
