using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeMap : MonoBehaviour{

    private class Tile
    {

        //Default Tile Prefab
        GameObject TileObject;
        GameObject reference;

        //Keeps track of whether or not tiles are on the corners of the map
        string CornerWallLeftRight = "";
        string CornerWallTopBottom = "";

        //Left/Right/Top/Bottom Fields
        bool CanMoveLeft = false;          //Positive Z Direction
        bool CanMoveRight = false;         //Negative Z Direction
        bool CanMoveUp = false;            //Positive X Direction
        bool CanMoveDown = false;          //Negative X Direction

        //Contains Enemy
        int EnemyCount = 0;

        //Contains Player
        bool ContainsPlayer = false;
        
        public Tile(GameObject TileObject)
        {
            this.TileObject = TileObject;
        }

        /// <summary>
        /// Sets the Corner Fields of the tile, used to ensure the corners of the map are not deleted.
        /// </summary>
        /// <param name="side">The side that is a corner. Valid values are "Top", "Bottom", "Left", "Right"</param>
        public void setCornerField(string side)
        {
            switch (side)
            {
                case "Top":
                    CornerWallTopBottom = side;
                    return;
                case "Bottom":
                    CornerWallTopBottom = side;
                    return;
                case "Left":
                    CornerWallLeftRight = side;
                    return;
                case "Right":
                    CornerWallLeftRight = side;
                    return;
            }
        }

        /// <summary>
        /// Creates a gamebject in world space at coordinates x,y,z.
        /// </summary>
        /// <param name="x">X Coordinate</param>
        /// <param name="y">Y Coordinate</param>
        /// <param name="z">Z Coordinate</param>
        public void CreateObject(float x, float y, float z)
        {
            if(reference == null)
            {
                Vector3 position = new Vector3(x,y,z);
                Quaternion Rotation = new Quaternion();
                reference = Instantiate(TileObject, position, Rotation);
            }
        }

        /// <summary>
        /// Disables a specific wall if it exists for the tile.
        /// </summary>
        /// <param name="side">The wall to delete. Valid values are "Top", "Bottom", "Left", "Right"</param>
        public void DeleteWall(string side)
        {
            try
            {
                foreach (Transform child in reference.transform)
                {
                    if (child.gameObject.name == "Walls")
                        foreach (Transform walls in child.gameObject.transform)
                        {
                            if(walls.gameObject.name == side + "Wall")
                            {
                                switch (side)
                                {
                                    case "Top":
                                        if(CornerWallTopBottom != "Top")
                                        {
                                            walls.gameObject.SetActive(false);
                                            CanMoveUp = true;
                                        }
                                        return;
                                    case "Bottom":
                                        if (CornerWallTopBottom != "Bottom")
                                        {
                                            walls.gameObject.SetActive(false);
                                            CanMoveDown = true;
                                        }
                                        return;
                                    case "Left":
                                        if(CornerWallLeftRight != "Left")
                                        {
                                            walls.gameObject.SetActive(false);
                                            CanMoveLeft = true;
                                        }
                                        return;
                                    case "Right":
                                        if(CornerWallLeftRight != "Right")
                                        {
                                            walls.gameObject.SetActive(false);
                                            CanMoveRight = true;
                                        }
                                        return;
                                }
                                return;
                            }
                        }
                }
            }
            catch
            {

            }
        }

        /// <summary>
        /// Raises a specific wall for the tile.
        /// </summary>
        /// <param name="side">The wall to raise. Valid values are "Top", "Bottom", "Left", "Right"</param>
        public void RaiseWall(string side)
        {
            try
            {
                foreach (Transform child in reference.transform)
                {
                    if (child.gameObject.name == "Walls")
                        foreach (Transform walls in child.gameObject.transform)
                        {
                            if (walls.gameObject.name == side + "Wall")
                            {
                                switch (side)
                                {
                                    case "Top":
                                        if (CornerWallTopBottom != "Top")
                                        {
                                            CanMoveUp = false;
                                        }
                                        return;
                                    case "Bottom":
                                        if (CornerWallTopBottom != "Bottom")
                                        {
                                            CanMoveDown = false;
                                        }
                                        return;
                                    case "Left":
                                        if (CornerWallLeftRight != "Left")
                                        {
                                            CanMoveLeft = false;
                                        }
                                        return;
                                    case "Right":
                                        if (CornerWallLeftRight != "Right")
                                        {
                                            CanMoveRight = false;
                                        }
                                        return;
                                }
                                return;
                            }
                        }
                }
            }
            catch
            {

            }
        }

        /// <summary>
        /// Lowers a specific wall for the tile.
        /// </summary>
        /// <param name="side">The wall to lower. Valid values are "Top", "Bottom", "Left", "Right"</param>
        public void LowerWall(string side)
        {
            try
            {
                foreach (Transform child in reference.transform)
                {
                    if (child.gameObject.name == "Walls")
                        foreach (Transform walls in child.gameObject.transform)
                        {
                            if (walls.gameObject.name == side + "Wall")
                            {
                                switch (side)
                                {
                                    case "Top":
                                        if (CornerWallTopBottom != "Top")
                                        {
                                            CanMoveUp = true;
                                        }
                                        return;
                                    case "Bottom":
                                        if (CornerWallTopBottom != "Bottom")
                                        {
                                            CanMoveDown = true;
                                        }
                                        return;
                                    case "Left":
                                        if (CornerWallLeftRight != "Left")
                                        {
                                            CanMoveLeft = true;
                                        }
                                        return;
                                    case "Right":
                                        if (CornerWallLeftRight != "Right")
                                        {
                                            CanMoveRight = true;
                                        }
                                        return;
                                }
                                return;
                            }
                        }
                }
            }
            catch
            {

            }
        }

        /// <summary>
        /// Determines whether or not an object can move in a certain direction.
        /// </summary>
        /// <param name="direction">The direction to move in. Valid values are "Up", "Down", "Left", "Right"</param>
        /// <returns>Returns true if you can move in a direction and false if not.</returns>
        public bool CanMove(string direction)
        {
            switch (direction)
            {
                case "Up":
                    return CanMoveUp;
                case "Down":
                    return CanMoveDown;
                case "Left":
                    return CanMoveLeft;
                case "Right":
                    return CanMoveRight;
            }

            Debug.Log("ERROR: MazeMap, CanMove: Attempting to use direction \"" + direction + "\" is invalid. Valid values are \"Up\", \"Down\", \"Left\", \"Right\"");
            return false;
        }

        public void RemovePlayer()
        {
            ContainsPlayer = false;
        }

        public void RecievePlayer()
        {
            ContainsPlayer = true;
        }

        public bool HasPlayer()
        {
            return ContainsPlayer;
        }

        public void RemoveEnemy()
        {
            EnemyCount--;
            if (EnemyCount < 0)
                EnemyCount = 0;
        }

        public void RecieveEnemy()
        {
            EnemyCount++;
        }

        public bool HasEnemy()
        {
            if (EnemyCount > 0)
                return true;
            return false;
        }

    }

    //Represents the player's position
    private class Player
    {
        public int x;
        public int y;

        public Player(int x, int y)
        {
            this.x = x;
            this.y = y;
        }


    }

    //Reperents the enemy's position and type
    private class Enemy
    {
        public int x;
        public int y;
        public string ID;

        public Enemy(int x, int y, string ID)
        {
            this.x = x;
            this.y = y;
            this.ID = ID;
        }



    }

    private Player player;

    private List<Enemy> Enemies = new List<Enemy>();

    //Default values for the tile gameobject
    private const string DefaultTile = "Prefabs/DefaultTile";
    private const double DefaultTileHeight = 1;
    private const double DefaultTileWidth = 1;

    //Individual Tile's Heights and Widths
    private double TileHeight = 1;
    private double TileWidth = 1;

    //Height and Width of map in tile units
    private int height = 20;
    private int width = 20;

    private System.Random Random;

    /// <summary>
    /// The array list of tile objects.
    /// Note: 2-Dimensional
    /// </summary>
    private List<List<Tile>> TileMap = new List<List<Tile>>();

    /// <summary>
    /// Creates a map of of the specified height and width.
    /// </summary>
    /// <param name="height">The height of the map in tiles.</param>
    /// <param name="width">The width of the map in tiles.</param>
    ///  <param name="TileResource">Path to game object in Resource folder.</param>
    public void CreateMap(int height = 20, int width = 20, string TileResource = DefaultTile, double TileHeight = DefaultTileHeight, double TileWidth = DefaultTileWidth, int seed = 312)
    {
        this.height = height;
        this.width = width;
        this.TileHeight = TileHeight;
        this.TileWidth = TileWidth;
        this.Random = new System.Random(seed);

        //Loads tile object from resources
        GameObject TileObject;
        try
        {
            TileObject = Resources.Load(TileResource) as GameObject;
        }
        catch
        {
            Debug.Log("Failed to load tile resource for map! Using Empty Object!");
            TileObject = new GameObject();
        }


        //Creates lists for default tile objects
        for (int h = 0; h < height; h++)
        {
            List<Tile> TileRow = new List<Tile>();
            for (int w = 0; w < width; w++)
            {
                Tile temp = new Tile(TileObject);

                //Sets the corner values if a tile is on the corner
                if (w == 0)
                    temp.setCornerField("Right");
                if (w == width - 1)
                    temp.setCornerField("Left");
                if (h == 0)
                    temp.setCornerField("Bottom");
                if(h == height - 1)
                    temp.setCornerField("Top");


                TileRow.Add(temp);
            }
            TileMap.Add(TileRow);
        }

        //Instantiates gameobjects in the world and sets them in proper locations
        for(int h = 0; h < height; h++)
        {
            for(int w = 0; w < width; w++)
            {
                TileMap[h][w].CreateObject((float)(h * TileWidth), 0, (float)(w * TileHeight));
            }
        }
    }

    /// <summary>
    /// Creates a map of of the specified height and width.
    /// </summary>
    /// <param name="height">The height of the map in tiles.</param>
    /// <param name="width">The width of the map in tiles.</param>
    public void CreateMap(int height = 20, int width = 20, int seed = 312)
    {
        CreateMap(height, width, DefaultTile, DefaultTileHeight, DefaultTileWidth, seed);
    }

    /// <summary>
    /// Creates the player object within the maze.
    /// </summary>
    /// <param name="x">The position of the player in the width (x) spectrum.</param>
    /// <param name="y">The position of the player in the height (y) spectrum.</param>
    public bool CreatePlayer(int x = 0, int y = 0)
    {
        if (x < 0 || x >= width || y < 0 || y >= height)
        {
            Debug.Log("ERROR: MazeMap, CreatePlayer: Index (x: " + x + ", y: " + y + ") is out of range!");
            return false;
        }

        if (player != null)
        {
            Debug.Log("ERROR: MazeMap, CreatePlayer: Player already exists!");
            return false;
        }
            


        try
        {
            player = new Player(x, y);
            TileMap[y][x].RecievePlayer();
            return true;
        }
        catch
        {
            Debug.Log("ERROR: MazeMap, CreatePlayer: Failed to create player!");
            return false;
        }
    }

    /// <summary>
    /// Spawns an enemy object within the maze.
    /// </summary>
    /// <param name="x">The position of the enemy in the width (x) spectrum.</param>
    /// <param name="y">The position of the enemy in the height (y) spectrum.</param>
    /// <param name="EnemyType">The type of the enemy.</param>
    /// <returns>Whether or not spawn was successful</returns>
    public bool SpawnEnemy(string EnemyID, int x = 0, int y = 0)
    {
        if (x < 0 || x >= width || y < 0 || y >= height)
        {
            Debug.Log("ERROR: MazeMap, SpawnEnemy: Index (x: " + x + ", y: " + y + ") is out of range!");
            return false;
        }

        foreach(Enemy enemy in Enemies)
            if(enemy.ID == EnemyID)
            {
                Debug.Log("ERROR: MazeMap, SpawnEnemy: Enemy with ID \"" + EnemyID + "\" already exists!");
                return false;
            }


        try
        {
            Enemy enemy = new Enemy(x, y, EnemyID);
            TileMap[y][x].RecieveEnemy();
            Enemies.Add(enemy);
            return true;
        }
        catch
        {
            Debug.Log("ERROR: MazeMap, SpawnEnemy: Failed to create enemy!");
            return false;
        }
    }

    /// <summary>
    /// Testing purposes
    /// </summary>
    public void ExampleTestMethod()
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

        int x = 1; int y = 1;

        ///These calls will delete the walls of a specific tile, opening up paths.
        ///------------------------------------------------------------------------------------------------------
        ///DeleteWall(x, y, "Top");
        ///DeleteWall(x, y, "Bottom");
        ///DeleteWall(x, y, "Left");
        ///DeleteWall(x, y, "Right");

        ///These calls will determine whether you can move in a specific direction from the specified tile.
        ///------------------------------------------------------------------------------------------------------
        ///Debug.Log("Can move up from (x: " + x + ", y: " + y + "): " + CanMove(x, y, "Up"));
        ///Debug.Log("Can move down from (x: " + x + ", y: " + y + "): " + CanMove(x, y, "Down"));
        ///Debug.Log("Can move left from (x: " + x + ", y: " + y + "): " + CanMove(x, y, "Left"));
        ///Debug.Log("Can move right from (x: " + x + ", y: " + y + "): " + CanMove(x, y, "Right"));

        ///These calls demonstrate how to move the player object and other related functions.
        ///Note: CreatePlayer() method must be called for these to work!
        ///------------------------------------------------------------------------------------------------------
        ///CreatePlayer(x, y);
        ///Debug.Log("Player position: (x: " + GetPlayerX() +", y: " + GetPlayerY() + ")");
        ///Debug.Log("Attemting to move player down. Successful: " + MovePlayer("Down"));
        ///Debug.Log("Attemting to move player up. Successful: " + MovePlayer("Up"));
        ///Debug.Log("Attemting to move player right. Successful: " + MovePlayer("Right"));
        ///Debug.Log("Attemting to move player left. Successful: " + MovePlayer("Left"));
        ///Debug.Log("Player position: (x: " + GetPlayerX() + ", y: " + GetPlayerY() + ")");

        ///These calls demonsrate how to detect whether or not the player exist on a tile.
        ///CreatePlayer(1, 1);
        ///Debug.Log("Player exists on this tile: " + HasPlayer(1, 1));
        ///Debug.Log("Player exists to the left: " + HasPlayer(0, 1, "Left"));
        ///Debug.Log("Player exists to the right: " + HasPlayer(2, 1, "Right"));
        ///Debug.Log("Player exists to the north: " + HasPlayer(1, 0, "Up"));
        ///Debug.Log("Player exists to the south: " + HasPlayer(1, 2, "Down"));

        ///These calls demonstrate how to move enemy objects and other related functions.
        ///------------------------------------------------------------------------------------------------------
        ///SpawnEnemy("Enemy01", 1, 1);
        ///Debug.Log("Enemy position: (x: " + GetEnemyX("Enemy01") +", y: " + GetEnemyY("Enemy01") + ")");
        ///Debug.Log("Attemting to move enemy down. Successful: " + MoveEnemy("Down", "Enemy01"));
        ///Debug.Log("Attemting to move enemy up. Successful: " + MoveEnemy("Up", "Enemy01"));
        ///Debug.Log("Attemting to move enemy right. Successful: " + MoveEnemy("Right", "Enemy01"));
        ///Debug.Log("Attemting to move enemy left. Successful: " + MoveEnemy("Left", "Enemy01"));
        ///Debug.Log("Enemy position: (x: " + GetEnemyX("Enemy01") + ", y: " + GetEnemyY("Enemy01") + ")");

        ///These calls demonstrate how to detect whether or not an enemy exist on a tile.
        ///------------------------------------------------------------------------------------------------------
        ///SpawnEnemy("Enemy01", 1, 1);
        ///Debug.Log("Enemy exists on this tile: " + HasEnemy(1, 1));
        ///Debug.Log("Enemy exists to the left: " + HasEnemy(0, 1, "Left"));
        ///Debug.Log("Enemy exists to the right: " + HasEnemy(2, 1, "Right"));
        ///Debug.Log("Enemy exists to the north: " + HasEnemy(1, 0, "Up"));
        ///Debug.Log("Enemy exists to the south: " + HasEnemy(1, 2, "Down"));

        ///These calls demonstrate how to lower and raise walls.
        ///LowerSide(1, 1, "Top");
        ///LowerSide(1, 1, "Bottom");
        ///LowerSide(1, 1, "Left");
        ///LowerSide(1, 1, "Right");
        ///Debug.Log("Can move up: " + CanMove(1, 1, "Up"));
        ///Debug.Log("Can move down: " + CanMove(1, 1, "Down"));
        ///Debug.Log("Can move left: " + CanMove(1, 1, "Left"));
        ///Debug.Log("Can move right: " + CanMove(1, 1, "Right"));
        ///RaiseSide(1, 1, "Top");
        ///RaiseSide(1, 1, "Bottom");
        ///RaiseSide(1, 1, "Left");
        ///RaiseSide(1, 1, "Right");
        ///Debug.Log("Can move up: " + CanMove(1, 1, "Up"));
        ///Debug.Log("Can move down: " + CanMove(1, 1, "Down"));
        ///Debug.Log("Can move left: " + CanMove(1, 1, "Left"));
        ///Debug.Log("Can move right: " + CanMove(1, 1, "Right"));
        ///Debug.Log("Can move up: " + CanMove(1, 0, "Up"));
        ///Debug.Log("Can move down: " + CanMove(1, 2, "Down"));
        ///Debug.Log("Can move left: " + CanMove(0, 1, "Left"));
        ///Debug.Log("Can move right: " + CanMove(2, 1, "Right"));



    }

    /// <summary>
    /// Deletes the wall on the specified side as well as the connecting wall of adjacent tiles (if they exist)
    /// </summary>
    /// <param name="x">The position of the tile in the width (x) spectrum.</param>
    /// <param name="y">The position of the tile in the height (y) spectrum.</param>
    /// <param name="side">The side to delete. Valid values are "Top", "Bottom", "Left", "Right"</param>
    public void DeleteWall(int x, int y, string side)
    {
        if (x < 0 || x >= width || y < 0 || y >= height)
        {
            Debug.Log("ERROR: MazeMap, DeleteWall: Index (x: " + x + ", y: " + y + ") is out of range!");
            return;
        }

        if(side != "Top" && side != "Bottom" && side != "Right" && side != "Left")
            Debug.Log("ERROR: MazeMap, DeleteWall: Attempting to delete side \"" + side + "\" is invalid. Valid values are \"Top\", \"Bottom\", \"Left\", \"Right\"");

        TileMap[y][x].DeleteWall(side);   

        
        switch (side)
        {
            case "Top":
                if(y + 1 < height)
                    TileMap[y + 1][x].DeleteWall("Bottom");
                return;
            case "Bottom":
                if(y - 1 >= 0)
                    TileMap[y - 1][x].DeleteWall("Top");
                return;
            case "Left":
                if (x + 1 < width)
                    TileMap[y][x + 1].DeleteWall("Right");
                return;
            case "Right":
                if (x - 1 >= 0)
                    TileMap[y][x - 1].DeleteWall("Left");
                return;
        }
    }

    /// <summary>
    /// Determines whether or not an object can move in a certain direction due to wall restrictions.
    /// </summary>
    /// <param name="x">The position of the object in the width (x) spectrum.</param>
    /// <param name="y">The position of the object in the height (y) spectrum.</param>
    /// <param name="direction">The direction to test. Valid values are "Up", "Down", "Left", "Right"</param>
    /// <returns></returns>
    public bool CanMove(int x, int y, string direction)
    {
        if (x < 0 || x >= width || y < 0 || y >= height)
        {
            Debug.Log("ERROR: MazeMap, CanMove: Index (x: " + x + ", y: " + y + ") is out of range!");
            return false;
        }

        Tile tile = TileMap[y][x];
        return tile.CanMove(direction);
    }

    /// <summary>
    /// Attempts to move the player in specified direction.
    /// </summary>
    /// <param name="direction">The direction to move. Valid values are "Up", "Down", "Left", "Right"</param>
    /// <returns>Wheher or not the player was successfully moved.</returns>
    public bool MovePlayer(string direction)
    {
        if (player == null)
        {
            Debug.Log("ERROR: MazeMap, MovePlayer: Player object is null! Use method \"CreatePlayer\" to create the player.");
            return false;
        }
            

        if(CanMove(player.x, player.y, direction))
        {
            switch (direction)
            {
                case "Up":
                    TileMap[player.y][player.x].RemovePlayer();
                    TileMap[player.y + 1][player.x].RecievePlayer();
                    player.y = player.y + 1;
                    return true;
                case "Down":
                    TileMap[player.y][player.x].RemovePlayer();
                    TileMap[player.y - 1][player.x].RecievePlayer();
                    player.y = player.y - 1;
                    return true;
                case "Left":
                    TileMap[player.y][player.x].RemovePlayer();
                    TileMap[player.y][player.x + 1].RecievePlayer();
                    player.x = player.x + 1;
                    return true;
                case "Right":
                    TileMap[player.y][player.x].RemovePlayer();
                    TileMap[player.y][player.x - 1].RecievePlayer();
                    player.x = player.x - 1;
                    return true;
            }
        }

        return false;
    }

    /// <summary>
    /// Gets the player's position in the width (x) spectrum. 
    /// </summary>
    /// <returns>The player's position in the width (x) spectrum.</returns>
    public int GetPlayerX()
    {
        if (player == null)
        {
            Debug.Log("ERROR: MazeMap, GetPlayerX: Player object is null! Use method \"CreatePlayer\" to create the player.");
            return -1;
        }
        return player.x;
    }

    /// <summary>
    /// Gets the player's position in the height (y) spectrum. 
    /// </summary>
    /// <returns>The player's position in the height (y) spectrum.</returns>
    public int GetPlayerY()
    {
        if (player == null)
        {
            Debug.Log("ERROR: MazeMap, GetPlayerY: Player object is null! Use method \"CreatePlayer\" to create the player.");
            return -1;
        }
        return player.y;
    }

    /// <summary>
    /// Determines whether or not a tile has the player.
    /// </summary>
    /// <param name="x">The position of the tile in the width (x) spectrum.</param>
    /// <param name="y">he position of the tile in the height (y) spectrum.</param>
    /// <returns>Whether or not the tile contains the player.</returns>
    public bool HasPlayer(int x, int y)
    {
        if (x < 0 || x >= width || y < 0 || y >= height)
        {
            Debug.Log("ERROR: MazeMap, HasPlayer: Index (x: " + x + ", y: " + y + ") is out of range!");
            return false;
        }

        return TileMap[y][x].HasPlayer();
    }

    /// <summary>
    /// Determines whether or not a tile in a certain direction has the player.
    /// </summary>
    /// <param name="x">The position of the tile in the width (x) spectrum.</param>
    /// <param name="y">he position of the tile in the height (y) spectrum.</param>
    /// <param name="direction">The direction to test. Valid values are "Up", "Down", "Left", "Right"</param>
    /// <returns>Whether or not the tile in the direction contains the player.</returns>
    public bool HasPlayer(int x, int y, string direction)
    {
        if (x < 0 || x >= width || y < 0 || y >= height)
        {
            Debug.Log("ERROR: MazeMap, HasPlayer: Index (x: " + x + ", y: " + y + ") is out of range!");
            return false;
        }

        switch (direction)
        {
            case "Up":
                if (y + 1 < height)
                    return TileMap[y + 1][x].HasPlayer();
                else return false;
            case "Down":
                if (y - 1 >= 0)
                    return TileMap[y - 1][x].HasPlayer();
                else return false;
            case "Left":
                if (x + 1 < width)
                    return TileMap[y][x + 1].HasPlayer();
                return false;
            case "Right":
                if (x - 1 >= 0)
                    return TileMap[y][x - 1].HasPlayer();
                else return false;
        }

        Debug.Log("ERROR: MazeMap, HasPlayer: Attempting to use direction \"" + direction + "\" is invalid. Valid values are \"Up\", \"Down\", \"Left\", \"Right\"");
        return false;
    }

    /// <summary>
    /// Attempts to move the enemy in specified direction.
    /// </summary>
    /// <param name="direction">The direction to move. Valid values are "Up", "Down", "Left", "Right"</param>
    /// <param name="EnemyID">The enemy's unique ID.</param>
    /// <returns>Wheher or not the enemy was successfully moved.</returns>
    public bool MoveEnemy(string direction, string EnemyID)
    {
        int count = 0;
        foreach (Enemy enemy in Enemies)
        {
            if (enemy.ID == EnemyID)
            {
                count++;
                if (!CanMove(enemy.x, enemy.y, direction))
                    continue;

                switch (direction)
                {
                    case "Up":
                        TileMap[enemy.y][enemy.x].RemoveEnemy();
                        TileMap[enemy.y + 1][enemy.x].RecieveEnemy();
                        enemy.y = enemy.y + 1;
                        return true;
                    case "Down":
                        TileMap[enemy.y][enemy.x].RemoveEnemy();
                        TileMap[enemy.y - 1][enemy.x].RecieveEnemy();
                        enemy.y = enemy.y - 1;
                        return true;
                    case "Left":
                        TileMap[enemy.y][enemy.x].RemoveEnemy();
                        TileMap[enemy.y][enemy.x + 1].RecieveEnemy();
                        enemy.x = enemy.x + 1;
                        return true;
                    case "Right":
                        TileMap[enemy.y][enemy.x].RemoveEnemy();
                        TileMap[enemy.y][enemy.x - 1].RecieveEnemy();
                        enemy.x = enemy.x - 1;
                        return true;
                }
            }
        }

        if (count == 0)
        {
            Debug.Log("ERROR: MazeMap, MoveEnemy: Enemy with ID \"" + EnemyID + "\" could not be found!");
        }

        return false;
    }

    /// <summary>
    /// Gets the enemy's position in the width (x) spectrum. 
    /// </summary>
    /// <returns>The enemy's position in the width (x) spectrum.</returns>
    public int GetEnemyX(string EnemyID)
    {
        foreach (Enemy enemy in Enemies)
        {
            if (enemy.ID == EnemyID)
            {
                return enemy.x;
            }
        }

        Debug.Log("ERROR: MazeMap, GetEnemyX: Enemy with ID \"" + EnemyID + "\" could not be found!");
        return -1;
    }

    /// <summary>
    /// Gets the enemy's position in the height (y) spectrum. 
    /// </summary>
    /// <returns>The enemy's position in the height (y) spectrum.</returns>
    public int GetEnemyY(string EnemyID)
    {
        foreach (Enemy enemy in Enemies)
        {
            if (enemy.ID == EnemyID)
            {
                return enemy.y;
            }
        }

        Debug.Log("ERROR: MazeMap, GetEnemyY: Enemy with ID \"" + EnemyID + "\" could not be found!");
        return -1;
    }

    /// <summary>
    /// Determines whether or not a tile has an enemy.
    /// </summary>
    /// <param name="x">The position of the tile in the width (x) spectrum.</param>
    /// <param name="y">he position of the tile in the height (y) spectrum.</param>
    /// <returns>Whether or not the tile contains an enemy.</returns>
    public bool HasEnemy(int x, int y)
    {
        if (x < 0 || x >= width || y < 0 || y >= height)
        {
            Debug.Log("ERROR: MazeMap, HasEnemy: Index (x: " + x + ", y: " + y + ") is out of range!");
            return false;
        }

        return TileMap[y][x].HasEnemy();
    }

    /// <summary>
    /// Determines whether or not a tile in a certain direction has an enemy.
    /// </summary>
    /// <param name="x">The position of the tile in the width (x) spectrum.</param>
    /// <param name="y">he position of the tile in the height (y) spectrum.</param>
    /// <param name="direction">The direction to test. Valid values are "Up", "Down", "Left", "Right"</param>
    /// <returns>Whether or not the tile in the direction contains an enemy.</returns>
    public bool HasEnemy(int x, int y, string direction)
    {
        if (x < 0 || x >= width || y < 0 || y >= height)
        {
            Debug.Log("ERROR: MazeMap, HasEnemy: Index (x: " + x + ", y: " + y + ") is out of range!");
            return false;
        }

        switch (direction)
        {
            case "Up":
                if (y + 1 < height)
                    return TileMap[y + 1][x].HasEnemy();
                else return false;
            case "Down":
                if (y - 1 >= 0)
                    return TileMap[y - 1][x].HasEnemy();
                else return false;
            case "Left":
                if (x + 1 < width)
                    return TileMap[y][x + 1].HasEnemy();
                return false;
            case "Right":
                if (x - 1 >= 0)
                    return TileMap[y][x - 1].HasEnemy();
                else return false;
        }

        Debug.Log("ERROR: MazeMap, HasEnemy: Attempting to use direction \"" + direction + "\" is invalid. Valid values are \"Up\", \"Down\", \"Left\", \"Right\"");
        return false;
    }

    /// <summary>
    /// Raises the side of a specific tile, blocking movement.
    /// </summary>
    /// <param name="x">The position of the tile in the width (x) spectrum.</param>
    /// <param name="y">The position of the tile in the height (y) spectrum.</param>
    /// <param name="side">The side to raise. Valid values are "Top", "Bottom", "Left", "Right"</param>
    public void RaiseSide(int x, int y, string side)
    {
        if (x < 0 || x >= width || y < 0 || y >= height)
        {
            Debug.Log("ERROR: MazeMap, RaiseSide: Index (x: " + x + ", y: " + y + ") is out of range!");
            return;
        }

        if (side != "Top" && side != "Bottom" && side != "Right" && side != "Left")
            Debug.Log("ERROR: MazeMap, RaiseSide: Attempting to raise side \"" + side + "\" is invalid. Valid values are \"Top\", \"Bottom\", \"Left\", \"Right\"");

        TileMap[y][x].RaiseWall(side);

        switch (side)
        {
            case "Top":
                if (y + 1 < height)
                    TileMap[y + 1][x].RaiseWall("Bottom");
                return;
            case "Bottom":
                if (y - 1 >= 0)
                    TileMap[y - 1][x].RaiseWall("Top");
                return;
            case "Left":
                if (x + 1 < width)
                    TileMap[y][x + 1].RaiseWall("Right");
                return;
            case "Right":
                if (x - 1 >= 0)
                    TileMap[y][x - 1].RaiseWall("Left");
                return;
        }
    }

    /// <summary>
    /// Lowers the side of a specific tile, allowing movement.
    /// </summary>
    /// <param name="x">The position of the tile in the width (x) spectrum.</param>
    /// <param name="y">The position of the tile in the height (y) spectrum.</param>
    /// <param name="side">The side to lower. Valid values are "Top", "Bottom", "Left", "Right"</param>
    public void LowerSide(int x, int y, string side)
    {
        if (x < 0 || x >= width || y < 0 || y >= height)
        {
            Debug.Log("ERROR: MazeMap, LowerSide: Index (x: " + x + ", y: " + y + ") is out of range!");
            return;
        }

        if (side != "Top" && side != "Bottom" && side != "Right" && side != "Left")
            Debug.Log("ERROR: MazeMap, LowerSide: Attempting to raise side \"" + side + "\" is invalid. Valid values are \"Top\", \"Bottom\", \"Left\", \"Right\"");

        TileMap[y][x].LowerWall(side);

        switch (side)
        {
            case "Top":
                if (y + 1 < height)
                    TileMap[y + 1][x].LowerWall("Bottom");
                return;
            case "Bottom":
                if (y - 1 >= 0)
                    TileMap[y - 1][x].LowerWall("Top");
                return;
            case "Left":
                if (x + 1 < width)
                    TileMap[y][x + 1].LowerWall("Right");
                return;
            case "Right":
                if (x - 1 >= 0)
                    TileMap[y][x - 1].LowerWall("Left");
                return;
        }
    }

}





