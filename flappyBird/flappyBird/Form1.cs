using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace flappyBird
{
    public partial class Form1 : Form
    {
        // Boruların hareket hızı
        int pipeSpeed = 8;

        // Kuşun düşüş hızını belirleyen yer çekimi değeri
        int gravity = 7;

        // Oyuncunun puanı
        int score = 0;

        public Form1()
        {
            // Form ve bileşenleri başlatır
            InitializeComponent();
        }

        // Form yüklendiğinde tetiklenen olay (boş bırakılmış)
        private void FlappyBird_Load(object sender, EventArgs e)
        {

        }

        // Boş bırakılmış bir tıklama olayı
        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        // Flappy Bird'e tıklandığında tetiklenen olay (boş bırakılmış)
        private void flappyBird_Click(object sender, EventArgs e)
        {

        }

        // Oyun zamanlayıcısının her tick'inde gerçekleşen olay
        private void gameTimerEvent(object sender, EventArgs e)
        {
            // Kuşun yukarı/aşağı hareketini kontrol eder
            flappyBird.Top += gravity;

            // Alt borunun sola doğru hareketini sağlar
            pipeBottom.Left -= pipeSpeed;

            // Üst borunun sola doğru hareketini sağlar
            pipeTop.Left -= pipeSpeed;

            // Puanı günceller ve ekrana yazdırır
            scoreText.Text = "Score: " + score;

            // Eğer alt boru ekran dışına çıkarsa, boruyu geri getir ve puanı artır
            if (pipeBottom.Left < -50)
            {
                pipeBottom.Left = 500;
                score++;
            }

            // Eğer üst boru ekran dışına çıkarsa, boruyu geri getir ve puanı artır
            if (pipeTop.Left < -80)
            {
                pipeTop.Left = 650;
                score++;
            }

            // Eğer kuş herhangi bir boruya, yere veya yukarıya çarparsa oyunu bitir
            if (flappyBird.Bounds.IntersectsWith(pipeBottom.Bounds) ||
                flappyBird.Bounds.IntersectsWith(pipeTop.Bounds) ||
                flappyBird.Bounds.IntersectsWith(ground.Bounds) || flappyBird.Top < -25
                )
            {
                endGame();
            }

            // Puan 8'den büyükse boruların hızını artır
            if (score > 8)
            {
                pipeSpeed = 13;
            }

            /* Eğer kuş ekranın üst sınırını geçerse oyunu bitir
             if(flappyBird.Top < -25)
             {
                 endGame();
             } */
        }

        // Boşluk tuşuna basıldığında tetiklenen olay
        private void gamekeysdown(object sender, KeyEventArgs e)
        {
            // Eğer boşluk tuşuna basıldıysa kuşu yukarı hareket ettir
            if (e.KeyCode == Keys.Space)
            {
                gravity = -7;
            }

        }

        // Boşluk tuşu bırakıldığında tetiklenen olay
        private void gamekeysup(object sender, KeyEventArgs e)
        {
            // Eğer boşluk tuşu bırakıldıysa kuşu aşağı hareket ettir
            if (e.KeyCode == Keys.Space)
            {
                gravity = 7;
            }

        }

        // Oyunu bitiren fonksiyon
        private void endGame()
        {
            // Zamanlayıcıyı durdurur ve oyun bitti mesajını ekrana yazar
            gameTimer.Stop();
            scoreText.Text += " Game Over !!!";
        }
    }
}
