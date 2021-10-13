using System;
using System.Collections.Generic;
using System.Text;

namespace Task4
{
    interface IMap
    {
        int FieldHeight { get; }
        int FieldWidth { get; }

        Point GetPoint(int row, int col);
        void SetPoint(int row, int col, Point point);

        void CreateEmptyField(int fieldWidth, int fieldHeight);
    }

    interface ISpawnEntities
    {
        void AddPlayer(Player player);
        void GenerateEnemies(int numEnemies);
        void GenerateObstacles(int numObstacles);
        void GenerateBonuses(int numBonuses);
    }

    interface IMovableEntity
    {
        Point CurrPosition { get; }
        int MovingSpeed { get; set; }
    }

    interface IEnemyMoving : IMovableEntity
    {
        void SetMovingAlgorythm();
    }

    interface IPlayerMoving : IMovableEntity
    {
        void GoLeft();
        void GoRight();
        void GoForward();
        void GoBackward();
    }

    interface IStaticEntity
    {
        void Place(int x, int y);
        void Remove(int x, int y);
        void IsObstacle(bool obstacle);
    }

    interface IBasicStats
    {
        int Health { get; set; }
    }

    interface IPlayerStats : IBasicStats
    {
        int Armor { get; set; }
        int Mana { get; set; }
    }
}
