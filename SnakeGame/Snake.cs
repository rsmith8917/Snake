﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SnakeGame
{
    public class Snake
    {
        private List<Point> points = new List<Point>();
        private List<Point> lastPoints = new List<Point>();
        public Point item { get; }

        private int xVelocity;
        private int XVelocity
        {
            get { return xVelocity; }
            set
            {
                if (notCollided)
                    xVelocity = value;
                else
                    xVelocity = 0;
            }
        }

        private int yVelocity;
        private int YVelocity
        {
            get { return yVelocity; }
            set
            {
                if (notCollided)
                    yVelocity = value;
                else
                    yVelocity = 0;
            }
        }
        private int xLimit;
        private int yLimit;
        private int length = 25;
        private readonly int extension = 1;
        private bool notCollided = true;

        private bool NotCollided
        {
            get
            {
                if (notCollided)
                    notCollided = (points[0].x > 0 &&
                                   points[0].y > 0 &&
                                   points[0].x < (xLimit - 1) &&
                                   points[0].y < (yLimit - 1) &&
                                   !points.GroupBy(n => n).Any(c => c.Count() > 1));
                return notCollided;
            }
        }

        public bool Dead
        {
            get { return !notCollided; }
        }

        private Point generateItem()
        {
            Random r = new Random();
            item.x = r.Next(1, xLimit - 1);
            item.y = r.Next(1, yLimit - 1);
            return (Point)item.Clone();
        }

        private readonly int delay = 50;

        public Snake(int xLimit, int yLimit)
        {
            for (int i = 0; i < length; i++)
            {
                points.Add(new Point() { x = (length + 2 - i), y = 5 });
            }
            this.xLimit = xLimit;
            this.yLimit = yLimit;

            item = new Point();
            generateItem();

            XVelocity = 1;
            YVelocity = 0;
            lastPoints = ClonableList.CloneList(points);
        }

        public List<Point> Move()
        {

            points[0].x += XVelocity;
            points[0].y -= YVelocity; //Subtracting velocity so that "Up" is positive y

            if (points[0].Equals(item))
            {
                length = length + extension;
                generateItem();
            } 

            if (NotCollided)
            {
                for (int i = 1; i < length; i++)
                {
                    try
                    {
                        points[i].x = lastPoints[i - 1].x;
                        points[i].y = lastPoints[i - 1].y;
                    }
                    catch (Exception)
                    {
                        for (int k = 1; k <= extension; k++)
                        {
                            points.Add(new Point()
                            {
                                x = lastPoints[lastPoints.Count() - 1].x + k*(lastPoints[lastPoints.Count() - 1].x - lastPoints[lastPoints.Count() - 2].x),
                                y = lastPoints[lastPoints.Count() - 1].y + k*(lastPoints[lastPoints.Count() - 1].y - lastPoints[lastPoints.Count() - 2].y)
                            });
                        }


                    }

                }
            }
            else
            {
                //undo head move
                points[0].x -= XVelocity;
                points[0].y += YVelocity;
            }

            lastPoints = ClonableList.CloneList(points);

            if (YVelocity == 0)
                Thread.Sleep(delay);
            else
                Thread.Sleep(delay * 2);

            return ClonableList.CloneList(points);
        }

        public void Down()
        {
            if (YVelocity == 0)
            {
                XVelocity = 0;
                YVelocity = -1;
            }
        }

        public void Up()
        {
            if (YVelocity == 0)
            {
                XVelocity = 0;
                YVelocity = 1;
            }
        }

        public void Right()
        {
            if (XVelocity == 0)
            {
                XVelocity = 1;
                YVelocity = 0;
            }
        }

        public void Left()
        {
            if (XVelocity == 0)
            {
                XVelocity = -1;
                YVelocity = 0;
            }
        }

    }
}
