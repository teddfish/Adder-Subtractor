using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class City
    {
        string s;
        public float lat, lon;
        public City(string s1, float lat1, float lon1)
        {
            s = s1;
            lat = lat1;
            lon = lon1;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            City[] c = { new City("pune", 18.5f, 73.8f), new City("mumbai", 19.4f, 72.5f), new City("cochin", 9.9f, 76.2f), new City("shimla", 31.1f, 77.1f), new City("puducherry", 11.9f, 79.8f) };

            Console.WriteLine("Please enter any of these two city codes");
            Console.WriteLine("Pune - 0");
            Console.WriteLine("Mumbai - 1");
            Console.WriteLine("Cochin - 2");
            Console.WriteLine("Shimla - 3");
            Console.WriteLine("Puducherry - 4");

            int num1 = Int32.Parse(Console.ReadLine());
            int num2 = Int32.Parse(Console.ReadLine());

            double deg2Rad = (3.1415f / 180);

            double rad1Lat = c[num1].lat * deg2Rad;
            double rad1Lon = c[num1].lon * deg2Rad;

            double rad2Lat = c[num2].lat * deg2Rad;
            double rad2Lon = c[num2].lon * deg2Rad;

            double x1 = CartesianCooX(rad1Lat, rad1Lon);
            double y1 = CartesianCooY(rad1Lat, rad1Lon);
            double z1 = CartesianCooZ(rad1Lat, rad1Lon);

            double x2 = CartesianCooX(rad2Lat, rad2Lon);
            double y2 = CartesianCooY(rad2Lat, rad2Lon);
            double z2 = CartesianCooZ(rad2Lat, rad2Lon);

            double fin = Distance(x1, y1, z1, x2, y2, z2);

            //double distanceBetweenTwoCities = GetFinDist(fin);
            Console.WriteLine("The distance between those two cities is " + fin);
            Console.Read();
        }

        private static double Distance(double x1, double y1, double z1, double x2, double y2, double z2)
        {
            double temp1 = Math.Pow((x2 - x1), 2);
            double temp2 = Math.Pow((y2 - y1), 2);
            double temp3 = Math.Pow((z2 - z1), 2);
            double result = Math.Sqrt(temp1 + temp2 + temp3);

            double EarthRad = 6371;
            double a = result / 2;

            double r = 2 * (Math.Asin(a / EarthRad));
            double finDist = r * EarthRad;
            return finDist;
        }

        private static double CartesianCooX(double x1, double y1)
        {
            double EarthRad = 6371;

            double ans = EarthRad * Math.Cos(x1) * Math.Cos(y1);

            return ans;
        }

        private static double CartesianCooY(double x1, double y1)
        {
            double EarthRad = 6371;

            double ans = EarthRad * Math.Cos(x1) * Math.Sin(y1);

            return ans;
        }

        private static double CartesianCooZ(double x1, double y1)
        {
            double EarthRad = 6371;

            double ans = EarthRad * Math.Sin(x1);

            return ans;
        }

        /*private static double GetFinDist(double x)
        {
            double EarthRad = 6371;
            double a = x / 2;

            double result = 2 * (Math.Asin(a / EarthRad));
            double finDist = result * EarthRad;

            return finDist;
        }*/
    }


}
