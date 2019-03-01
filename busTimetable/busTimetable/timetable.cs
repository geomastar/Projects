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
        StreamReader sr;

        struct routeStruct
        {
            private string startPoint;
            private string destination;
            private List<int> times;
            
            public routeStruct(string newStartPoint, string newDestination, List<int> newTimes)
            {
                startPoint = newStartPoint;
                destination = newDestination;
                times = newTimes;
            }
        }

        public timetable(string path)
        {
            string newLine;
            string[] tempLineArray;
            string tempStartPoint;
            string tempDestination;
            List<int> tempTimes;

            sr = new StreamReader(path);        
            while(sr.Peek() > 0)
            {
                newLine = sr.ReadLine();
                tempLineArray = newLine.Split(' ');
                tempStartPoint = tempLineArray[0];

            }
        }
    }
}
