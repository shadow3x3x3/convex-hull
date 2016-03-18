using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace convex_hull_problem
{
    public partial class Form1 : Form
    {
        public Form1()
        {   
            /* 初始化 */
            
            angle_Num = 2;
            //建立Windows Form            
            InitializeComponent();

            //清除panel
            Graphics g = graphPanel.CreateGraphics();
            g.Clear(Color.White);

            //步驟控制初始化
            first_Step = true;
            second_Step = false;

            //禁止連接、清除按鈕
            connectBtn.Enabled = false;
            clearBtn.Enabled = false;
        }

        //產生按鈕處理
        private void creatBtn_Click(object sender, EventArgs e)
        {
            //引入點的數量
            pointNum = pointUpDown.Value;              
            //將點存入隨機座標並繪製
            for (int i = 0; i < pointNum; i++) {
                Random rd = new Random(Guid.NewGuid().GetHashCode());
                coords[i].X = rd.Next(10, 700);
                coords[i].Y = rd.Next(10, 650);
                draw_Point(coords[i], Color.Red);
            }
            //按鈕控制
            creatBtn.Enabled = false;
            connectBtn.Enabled = true;
            clearBtn.Enabled = true;
           
                
        }
        
        //連接按鈕處理
        private void connectBtn_Click(object sender, EventArgs e)
        {
            if (first_Step == true) {
                //步驟一 找出convex hull 的一條邊
                /* 找第一個點 */
                find_First(ref coords, pointNum);
                
                //畫第一個點為藍色
                draw_Point(coords[0], Color.Blue);
                
                /* 找第二個點 */
                //找一點Y = 第一點Y座標的直線
                Point temp = new Point { X = 999, Y = coords[0].Y };

                //用這條線找到角度最大的點
                angle_Calc = 1;

                //儲存角度
                for (int i = 1; i < pointNum; i++) {
                    angle[i] = calc_Angle(coords[0], temp, coords[i]); 
                }

                //將角度最大的點移到coords[1]
                for (int i = 2; i < pointNum; i++) {
                    if (angle[i] > angle[1]) {
                        float angleTemp;
                        //交換角度位置
                        angleTemp = angle[1];
                        angle[1] = angle[i];
                        angle[i] = angleTemp;
                        //交換點
                        pointSwap(ref coords[1] ,ref coords[i]);
                    }

                }
                //連接兩點完成第一條邊
                draw_Point(coords[1], Color.Blue);
                draw_Line(coords[0], coords[1]);
               

                //步驟控制
                first_Step = false;
                second_Step = true;


            } else if (second_Step == true) {
                 
                //步驟二 依序找出下一條邊
                angle_Calc = 0;

                //判斷是否全部完成
                if (coords[angle_Num-1] == coords[0]) {
                    MessageBox.Show("已經全部完成了");
                } else {
                    //因為要看情況加入第一個點的判斷，所以分成第二點前後方法兩種處理
                    if (angle_Num > 2) {
                        coords[(int)pointNum] = coords[0];
                        //第二點後方法
                        second_After(sender, e);
                    } else {
                        //第二點前方法
                        second_Before(sender, e);
                    }
                }
                    

                
            }
   
        }

        //清除按鈕處理
        private void clearBtn_Click(object sender, EventArgs e) {
            //清掉panel
            Graphics g = graphPanel.CreateGraphics();
            g.Clear(Color.White);

            //清掉所有陣列裡的點
            coords = new Point[100];
            angle_Num = 2;

            //步驟控制初始化
            first_Step = true;
            second_Step = false;

            //按鈕控制
            creatBtn.Enabled = true;
            connectBtn.Enabled = false;
            clearBtn.Enabled = false;
        }



        /**************   
                    自行撰寫的函式
                              **************/
        //畫點方法
        private void draw_Point(Point p, Color draw) {
            Graphics g = graphPanel.CreateGraphics();
            Rectangle rect = new Rectangle(p.X-3, p.Y-3, 6, 6);

            g.FillEllipse(new SolidBrush(draw), rect);
        }


        //畫線方法
        private void draw_Line(Point p1, Point p2) {
            Pen pen = new Pen(Color.Blue, Width);
            Graphics g = graphPanel.CreateGraphics();

            pen.Width = 1.5F;
            g.DrawLine(pen, p1, p2);
        }


        //找第一個點 (x最小)
        private void find_First(ref Point[] a, decimal max) {
            //將X最小移至Point[1]
            for (int i = 0; i < max; i++) {
                if (a[i].X < a[0].X) {
                    //交換位置
                    pointSwap(ref a[0], ref a[i]);
                }

            } 
          
        }


        //找最小斜率
        private void slope_Min(ref Point[] a, decimal max) {

            decimal[] slope = new decimal[100];
            //計算斜率
            for (int i = 0; i <= (int)max ; i++) {
                slope[i] = (a[i + 1].Y - a[0].Y) / (a[i + 1].X - a[0].X);
                
            }
           
            //將斜率小的移到陣列 a[1]
            for (int i = 1; i < max; i++) {
                if(slope[i] == slope.Min() && i != 1){
                    //交換位置
                    pointSwap(ref a[1], ref a[i]);
                }            
            }
            
        }


        //三點求角度
        private float calc_Angle(Point mid, Point p1, Point p2) {
            //利用acos算出角度
            float dx1, dx2, dy1, dy2;
            float angle;

            //先求向量
            dx1 = p1.X - mid.X;
            dy1 = p1.Y - mid.Y;

            dx2 = p2.X - mid.X;
            dy2 = p2.Y - mid.Y;

            float c = (float)Math.Sqrt(dx1 * dx1 + dy1 * dy1) * (float)Math.Sqrt(dx2 * dx2 + dy2 * dy2);

            //例外發生
            if (c == 0) {
                return -1;
            }

            angle = (float)Math.Acos((dx1 * dx2 + dy1 * dy2) / c);

            return angle;
        }


        //兩點交換
        private void pointSwap(ref Point p1,ref Point p2) {
            Point temp;
            temp = p1;
            p1 = p2;
            p2 = temp;
        }


        //第二點前連線演算法
        private void second_Before(object sender, EventArgs e) {
            //前兩點到其他點的每個角度
            while (angle_Calc < pointNum) {
                angle[angle_Calc] = calc_Angle(coords[angle_Num - 1], coords[angle_Num - 2], coords[angle_Calc]);
                angle_Calc++;
            }


            //將角度最大的點移到coords[angle_Num]
            for (int i = angle_Num + 1; i < pointNum; i++) {
                if (angle[i] > angle[angle_Num]) {
                    float angleTemp;
                    //交換角度位置
                    angleTemp = angle[angle_Num];
                    angle[angle_Num] = angle[i];
                    angle[i] = angleTemp;
                    //交換點
                    pointSwap(ref coords[angle_Num], ref coords[i]);
                }
            }

            //連接兩點
            draw_Point(coords[angle_Num], Color.Blue);
            draw_Line(coords[angle_Num - 1], coords[angle_Num]);

            //換下一個點
            angle_Num++;

         
        }


        //第二點後連線演算法
        private void second_After(object sender, EventArgs e) {
            //前兩點到其他點的每個角度
            while (angle_Calc <= pointNum) {
                angle[angle_Calc] = calc_Angle(coords[angle_Num - 1], coords[angle_Num - 2], coords[angle_Calc]);
                angle_Calc++;
            }


            //將角度最大的點移到coords[angle_Num]
            for (int i = angle_Num + 1; i <= pointNum; i++) {
                if (angle[i] > angle[angle_Num]) {
                    float angleTemp;
                    //交換角度位置
                    angleTemp = angle[angle_Num];
                    angle[angle_Num] = angle[i];
                    angle[i] = angleTemp;
                    //交換點
                    pointSwap(ref coords[angle_Num], ref coords[i]);
                }
            }

            //連接兩點
            draw_Point(coords[angle_Num], Color.Blue);
            draw_Line(coords[angle_Num - 1], coords[angle_Num]);

            //換下一個點
            angle_Num++;        
        }
    }
}


