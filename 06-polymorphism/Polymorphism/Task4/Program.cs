using System;

namespace Task4
{
    class Program
    {
        static void Main(string[] args)
        {

            var game = new GameMap(20, 20);
            var player = new Player(game.Field[0, 0], 1, 100, 100, 100);

            game.AddPlayer(player);
            game.GenerateObstacles(50);
            game.GenerateBonuses(20);
            game.GenerateEnemies(10);


        }
    }



    public struct Point
    {
        public Point(int x, int y, int idx, bool obstacle = false)
        {
            X = x;
            Y = y;
            Idx = idx;
            Obstacle = obstacle;
        }

        public int X { get; set; }
        public int Y { get; set; }
        public int Idx { get; set; }
        public bool Obstacle { get; set; }
    }


    public class GameMap : IMap, ISpawnEntities
    {
        private int _fieldWidth;
        private int _fieldHeight;
        public Point[,] Field;

        public GameMap() { }
        public GameMap(int fieldWidth, int fieldHeight)
        {
            _fieldWidth = fieldWidth;
            _fieldHeight = fieldHeight;

            Field = new Point[fieldWidth, fieldHeight];

            CreateEmptyField(_fieldWidth, _fieldHeight);
        }

        public int FieldHeight
        {
            get { return _fieldHeight; }
        }
        public int FieldWidth
        {
            get { return _fieldWidth; }
        }

        public Point GetPoint(int row, int col)
        {
            return Field[row, col];
        }
        public void SetPoint(int row, int col, Point point)
        {
            Field[row, col] = point;
        }
        public void CreateEmptyField(int fieldWidth, int fieldHeight)
        {
            for (int i = 0; i < fieldHeight; i++)
            {
                for (int j = 0; j < fieldWidth; j++)
                {
                    int idx = j + i * fieldWidth;

                    Point point = new Point(i, j, idx);
                    Field[i, j] = point;
                }
            }
        }
        public void AddPlayer(Player player)
        {
            Field[player.CurrPosition.X, player.CurrPosition.Y] = player.CurrPosition;
        }
        public void GenerateEnemies(int numEnemies)
        {
            for(int i = 0; i < numEnemies; i++)
            {
                // random generation code

                

                Point p = new Point(/* ... */);

                if (!p.Obstacle)
                { 
                    Enemy enemy = new Enemy(p, 0, 1, 100); 
                }
            }
        }
        public void GenerateObstacles(int numObstacles)
        {
            for (int i = 0; i < numObstacles; i++)
            {
                // random generation code


                Point p = new Point(/* ... */);
                Obstacle obstacle = new Obstacle(p, 0);
            }
        }
        public void GenerateBonuses(int numBonuses)
        {
            for (int i = 0; i < numBonuses; i++)
            {
                // random generation code


                Point p = new Point(/* ... */);
                Bonus bonus = new Bonus(p, 0, 20);
            }
        }
    }




    public class Player : GameMap, IPlayerMoving, IPlayerStats
    {
        Point _currentPosition;
        int _movingSpeed;
        int _health;
        int _armor;
        int _mana;

        public Player(Point spawnPoint, int movingSpeed, int health, int armor, int mana)
        {
            if (spawnPoint.X <= 0 || spawnPoint.X >= FieldWidth || spawnPoint.Y <= 0 || spawnPoint.Y >= FieldHeight)
                _currentPosition = spawnPoint;
            else
                throw new ArgumentOutOfRangeException("");

            _movingSpeed = movingSpeed;
            _health = health;
            _armor = armor;
            _mana = mana;
        }

        public Point CurrPosition 
        {
            get { return _currentPosition; } 
        }
        public int MovingSpeed 
        {
            get { return _movingSpeed; }
            set { _movingSpeed = value; }
        }
        public int Health
        {
            get { return _health; }
            set { _health = value; }
        }
        public int Armor
        {
            get { return _armor; }
            set { _armor = value; }
        }
        public int Mana
        {
            get { return _mana; }
            set { _mana = value; }
        }

        public void GetBonus(Bonus bonus)
        {
            if (bonus.Type == 0) { Health += bonus.EffectValue; }
            //else if (Type == 1) { player.Armor += EffectValue; }
            //else if (Type == 2) { player.Mana += EffectValue; }
        }

        public void GoLeft() { }
        public void GoRight() { }
        public void GoForward() { }
        public void GoBackward() { }
    }



    public class Enemy : GameMap, IEnemyMoving, IBasicStats
    {
        Point _currentPosition;
        int _movingSpeed;
        int _health;
        int _type;

        public Enemy(Point spawnPoint, int type, int movingSpeed, int health)
        {
            if (spawnPoint.X <= 0 || spawnPoint.X >= FieldWidth || spawnPoint.Y <= 0 || spawnPoint.Y >= FieldHeight)
                _currentPosition = spawnPoint;
            else
                throw new ArgumentOutOfRangeException("");

            _movingSpeed = movingSpeed;
            _health = health;
            _type = type;
        }

        public Point CurrPosition
        {
            get { return _currentPosition; }
        }
        public int MovingSpeed
        {
            get { return _movingSpeed; }
            set { _movingSpeed = value; }
        }
        public int Health
        {
            get { return _health; }
            set { _health = value; }
        }
        public int Type
        {
            get { return _type; }
            set { _type = value; }
        }

        public void SetMovingAlgorythm() { /*  */ }
    }



    public class Obstacle : GameMap, IStaticEntity
    {
        Point _spawnPoint;
        int _type;

        public Obstacle(Point spawnPoint, int type)
        {
            if (spawnPoint.X <= 0 || spawnPoint.X >= FieldWidth || spawnPoint.Y <= 0 || spawnPoint.Y >= FieldHeight)
                _spawnPoint = spawnPoint;
            else
                throw new ArgumentOutOfRangeException("");

            _type = type;
        }

        public Point SpawnPoint
        {
            get { return _spawnPoint; }
            set { _spawnPoint = value; }
        }
        public int Type
        {
            get { return _type; }
            set { _type = value; }
        }

        public void Place(int x, int y) { }
        public void Remove(int x, int y) { }
        public void IsObstacle(bool obstacle) { }
    }



    public class Bonus : GameMap, IStaticEntity
    {
        Point _spawnPoint;
        int _type;
        int _effectValue;

        public Bonus(Point spawnPoint, int type, int effectValue)
        {
            if (spawnPoint.X <= 0 || spawnPoint.X >= FieldWidth || spawnPoint.Y <= 0 || spawnPoint.Y >= FieldHeight)
                _spawnPoint = spawnPoint;
            else
                throw new ArgumentOutOfRangeException("");
            
            _type = type;
            _effectValue = effectValue;
        }

        public Point SpawnPoint
        {
            get { return _spawnPoint; }
            set { _spawnPoint = value; }
        }
        public int Type
        {
            get { return _type; }
            set { _type = value; }
        }
        public int EffectValue
        {
            get { return _effectValue; }
            set { _effectValue = value; }
        }


        //public void SetEffect(Player player)
        //{
        //    if (Type == 0) { player.Health += EffectValue; }
        //    else if (Type == 1) { player.Armor += EffectValue; }
        //    else if (Type == 2) { player.Mana += EffectValue; }
        //}
        public void Place(int x, int y) { }
        public void Remove(int x, int y) { }
        public void IsObstacle(bool obstacle) { }
    }
}
