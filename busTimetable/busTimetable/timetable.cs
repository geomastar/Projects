using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace busTimetable
{
    class timetable
    {
        private StreamReader sr;
        private List<routeStruct> timeTableList;

        private struct routeStruct
        {
            string startPoint;
            string destination;
            List<string> times;
            
            public routeStruct(string newStartPoint, string newDestination, List<string> newTimes)
            {
                startPoint = newStartPoint;
                destination = newDestination;
                times = newTimes;
            }
        }

        public timetable(string path)
        {
            timeTableList = new List<routeStruct>();
            string newLine;
            string[] tempLineArray;
            string tempStartPoint;
            string tempDestination;
            List<string> tempTimes;

            sr = new StreamReader(path);        
            while(sr.Peek() > 0)
            {
                newLine = sr.ReadLine();
                tempLineArray = newLine.Split(' ');
                tempStartPoint = tempLineArray[0];
                tempDestination = tempLineArray[1];
                tempTimes = new List<string>();
                for(int i = 2; i <= tempLineArray.Length; i++)
                {
                    tempTimes.Add(tempLineArray[i]);
                }

                timeTableList.Add(new routeStruct(tempStartPoint, tempDestination, tempTimes));
            }
        }

        public temp(int i)
        {
            Console.WriteLine(timeTableList[i.startPoint]);
        }
    }
}
