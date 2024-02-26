using System.Reflection.Metadata.Ecma335;

namespace PointInTriangle
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double[] a, b, c, f = new double[2];

            // вводим координаты точек треугольника по часовой стрелке
            Console.WriteLine("Enter the coordinates of the points clockwise, separated by a space");
            Console.Write("A(x,y) = "); a = Console.ReadLine().Split().Select(double.Parse).ToArray();
            Console.Write("B(x,y) = "); b = Console.ReadLine().Split().Select(double.Parse).ToArray();
            Console.Write("C(x,y) = "); c = Console.ReadLine().Split().Select(double.Parse).ToArray();
            Console.Write("F(x,y) = "); f = Console.ReadLine().Split().Select(double.Parse).ToArray();

            //проверка на существование треугольника точки не лежат на одной прямой)
            if ((c[0] - a[0]) * (b[1] - a[1]) == (c[1] - a[1]) * (b[0] - a[0]))
            {
                Console.WriteLine("This is not a triangle but a line");
                return;
            }

            bool point_in_or_out(double[] a, double[] b, double[] f) 
            {
                // Расстоянием от точки до отрезка является либо перпендикуляр, опущенный из этой
                // точки на отрезок, либо минимальное расстояние от точки до одного из концов отрезка

                // Если relation < 0, то X оказалась перед B, и в этом случае точка отрезка, ближайшая к F это B
                // А если relation > 1, то X оказалась за A, и точка, ближайшая к F - это A
                double L = Math.Pow(a[0] - b[0], 2) + Math.Pow(a[1] - b[1], 2);
                double PR = (f[0] - a[0]) * (b[0] - a[0]) + (f[1] - a[1]) * (b[1] - a[1]);

                // relation - отношение проекции вектора BF на BA к самому вектору BA
                double relation = PR / L;
                if (relation < 0) { relation = 0; } // X оказалась перед B, и в этом случае точка отрезка, ближайшая к F это B
                if (relation > 1) { relation = 1; } // X оказалась за A, и точка, ближайшая к F это A

                // находим координаты точки опущенного перпендикуляра с точки F на отрезок AB
                // ИЛИ
                // расстояние от точки до одного из ближайших концов отрезка
                double[] res_p = new double[2];
                res_p[0] = a[0] + relation * (b[0] - a[0]);
                res_p[1] = a[1] + relation * (b[1] - a[1]);

                //Определять принадлежность точки треугольнику будем МЕТОДОМ ОТНОСИТЕЛЬНОСТИ:
                //Сначала выбирается ориентация движения по вершинам треугольника по часовой стрелке.
                //По данной ориентации проходим все стороны треугольника и рассчитываем по какую сторону
                //от текущей прямой лежит наша точка. Если точка для всех прямых, лежит с правой стороны,
                //то значит точка принадлежит, иначе условие принадлежности не выполняется

                //Таким образом, получается:
                //Если есть вектор |AB|, заданный координатами A(x,y) B(x,y) и точка F(x,y),
                //то для того чтобы узнать лежит ли она слева или справа, надо узнать знак
                //произведения: (bx - ax) * (fy - ay) - (by - ay) * (fx - ax)
                if (0 >= (b[0] - a[0]) * (f[1] - a[1]) - (b[1] - a[1]) * (f[0] - a[0]))
                {
                    return true;
                }
                // расстояние от точки до треугольника меньше 0,0001
                else if (0.0001 > Math.Sqrt(Math.Pow(f[0] - res_p[0], 2) + Math.Pow(f[1] - res_p[1], 2)))
                {
                    return true;
                }

                return false;
            }

            if (point_in_or_out(a, b, f) && point_in_or_out(b, c, f) && point_in_or_out(c, a, f))
            {
                Console.WriteLine("Point IN triangle");
            }
            else Console.WriteLine("Point OUT triangle");
        }
    }
}
