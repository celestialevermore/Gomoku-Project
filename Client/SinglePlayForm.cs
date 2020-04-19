using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
    public partial class SinglePlayForm : Form
    {
        private const int rectSize = 33; //오목판의 하나의 셀크기
        private const int edgeCount = 19; // 오목판의 선의 개수
        private const int flowerSize = 10; //오목판의 화점의 크기
        private enum Horse { none = 0, BLACK, WHITE };
        private Horse[,] board = new Horse[edgeCount, edgeCount]; //돌이 놓였을 때 위치 19 19크기의 이차원 배열
        private Horse nowPlayer = Horse.BLACK; //먼저 흑이 착수하기 때문에

        private bool isplaying = false;


        private Timer htimer = new Timer();
        



        public SinglePlayForm()
        {
            InitializeComponent();
        }
        
        //승리 판정 함수
        private bool Judge()
        {
            //가로로 다섯 개의 돌을 완성한 경우
            for(int i = 0; i<edgeCount - 4; i++)
            {
               for(int j = 0; j < edgeCount; j++)
                {
                    if (board[i, j] == nowPlayer && board[i + 1, j] == nowPlayer && board[i + 2, j] == nowPlayer &&
                        board[i + 3, j] == nowPlayer && board[i + 4, j] == nowPlayer) return true;
                }
            }
            //세로로 다섯 개의 돌을 완성한 경우
            for(int i = 0; i < edgeCount; i++)
            {
                for(int j = 4; j < edgeCount; j++)
                {
                    if (board[i, j] == nowPlayer && board[i, j - 1] == nowPlayer && board[i, j - 2] == nowPlayer &&
                        board[i, j - 3] == nowPlayer && board[i, j - 4] == nowPlayer) return true;
                }
            }

            //대각선 위 방향으로 다섯개의 돌을 완성한 경우
            for(int i = 0; i < edgeCount - 4; i++)
            {
                for(int j = 0; j < edgeCount - 4; j++)
                {
                    if (board[i, j] == nowPlayer && board[i + 1, j + 1] == nowPlayer && board[i + 2, j + 2] == nowPlayer &&
                        board[i + 3, j + 3] == nowPlayer && board[i + 4, j + 4] == nowPlayer) return true;
                }
            }
            //대각선 아래 방향으로 다섯개의 돌을 완성한 경우
            for(int i = 4; i < edgeCount; i++)
            {
                for(int j = 0; j < edgeCount - 4; j++)
                {
                    if (board[i, j] == nowPlayer && board[i - 1, j + 1] == nowPlayer && board[i - 2, j + 2] == nowPlayer &&
                        board[i - 3, j + 3] == nowPlayer && board[i - 4, j + 4] == nowPlayer) return true;
                }
            }
            return false;
        }

        //게임이 끝난 경우 초기화하는 함수
        private void refresh()
        {
            this.pictureBox1.Refresh();
            for(int i = 0; i<edgeCount; i++)
            {
                for(int j = 0; j<edgeCount; j++)
                {
                    board[i, j] = Horse.none;
                }
            }
        }






        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            Graphics g = this.pictureBox1.CreateGraphics(); //그림을 그리기 위해 만듬
            int x = e.X / rectSize;
            int y = e.Y / rectSize;
            // 0부터 18까지의 범위를 갖는다.
            if(x<0 || y<0 || x>=edgeCount || y>=edgeCount)
            {
                MessageBox.Show("바둑판 바깥에는 착수할 수 없습니다");
                return;
            }
            if (board[x, y] != Horse.none) { return; }
            board[x, y] = nowPlayer;
            //MessageBox.Show(x + "," + y);
            if(nowPlayer == Horse.BLACK)
            {
                SolidBrush brush = new SolidBrush(Color.Black);
                g.FillEllipse(brush, x * rectSize, y * rectSize, rectSize, rectSize); //검은 바둑돌의 크기
               // Bitmap bmp = new Bitmap
            
            
            }
            else
            {
                SolidBrush brush = new SolidBrush(Color.White);
                g.FillEllipse(brush, x * rectSize, y * rectSize, rectSize, rectSize); //흰 바둑돌의 크기만큼 x,y위치에 가로세로만큼의 원을 그려라.
            }

            //새로 판정부분을 만든다.
            if (Judge())
            {
              Status.Text = nowPlayer.ToString() + " win this game.";
                isplaying = false;
                PlayButton.Text = "Game Start";
            }
            else //오목이 만들어지지 않았다면 다음 플레이어에게 넘어갈 수 있도록 만듬.
            {
                nowPlayer = ((nowPlayer == Horse.BLACK) ? Horse.WHITE : Horse.BLACK);
                Status.Text = nowPlayer.ToString() + " 's turn.";
            }


        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            Graphics gp = e.Graphics;
            Color lineColor = Color.Black; //바둑판의 선 색
            Pen p = new Pen(lineColor, 2); //선의 굵기를 2로 설정
            SolidBrush brush_for_flower = new SolidBrush(Color.Black);
            //위아래 상하좌우에 선을 그렺준다.
            gp.DrawLine(p, rectSize / 2, rectSize / 2,rectSize/2, rectSize * edgeCount - rectSize / 2);
            gp.DrawLine(p, rectSize / 2, rectSize / 2,rectSize * edgeCount - rectSize / 2,rectSize/2);
            gp.DrawLine(p, rectSize / 2, rectSize * edgeCount - rectSize / 2, rectSize * edgeCount-rectSize/2, rectSize * edgeCount-rectSize/2);
            gp.DrawLine(p, rectSize * edgeCount - rectSize / 2, rectSize / 2,  rectSize * edgeCount - rectSize / 2, rectSize * edgeCount - rectSize / 2);
            p = new Pen(lineColor, 1);

            //대각선방향으로 이동하면서 그리기 
            for(int i = rectSize+rectSize / 2; i<rectSize*edgeCount - rectSize / 2; i += rectSize)
            {
                gp.DrawLine(p, rectSize / 2, i, rectSize * edgeCount - rectSize / 2, i);
                gp.DrawLine(p, i, rectSize / 2, i, rectSize * edgeCount - rectSize / 2);
            }

            for(int x= 3; x<=15; x += 6)
            {
                for(int y = 3; y <= 15; y += 6)
                {
                    gp.FillEllipse(brush_for_flower, x*rectSize+11, y*rectSize+11, flowerSize, flowerSize);
                }
            }
        }

        private void SinglePlayForm_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (!isplaying)
            {
                refresh();
                isplaying = true;
                PlayButton.Text = "Restart";
                Status.Text = nowPlayer.ToString() + "It is now your turn.";
            }
            else
            {
                refresh();
                Status.Text = "The game is restarted.";
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
