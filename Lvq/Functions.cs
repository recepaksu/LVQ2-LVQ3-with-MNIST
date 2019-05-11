using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using OfficeOpenXml;

namespace Lvq
{
    class Functions
    {
        Random r = new Random();
        List<Sample> traindata = new List<Sample>();
        List<Sample> testdata = new List<Sample>();
        List<Sample> codebooks = new List<Sample>();

        int classCount = 10, trainCount, testCount, codebookCount, tourCount,mk;
        double w, alfa, eps;
        bool flag, cb;
        ProgressBar pb;

        //Dosyaların okunduğu bölüm
        private void takeData()
        {
            //Fotoğrafları bitmap olarak alıp işlenmeye hazır şekilde testdata ve traindata listelerine aktarılması
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                string[] path = Directory.GetDirectories(fbd.SelectedPath);
                string[] path2 = Directory.GetDirectories(path[0]);
                for (int j = 0; j < path2.Length; j++)
                {
                    string[] path3 = Directory.GetFiles(path2[j]);
                    for (int k = 0; k < path3.Length; k++)
                    {
                        Bitmap temporary = new Bitmap(path3[k]);
                        Sample axs = new Sample(j);
                        for (int m = 0; m < 28; m++)
                        {
                            for (int n = 0; n < 28; n++)
                            {
                                axs.data[m * 28 + n] = (int)temporary.GetPixel(m, n).R / 255.0;
                            }
                        }
                        testdata.Add(axs);
                    }
                }

                path2 = Directory.GetDirectories(path[1]);
                for (int j = 0; j < path2.Length; j++)
                {
                    string[] path3 = Directory.GetFiles(path2[j]);
                    for (int k = 0; k < path3.Length; k++)
                    {
                        Bitmap temporary = new Bitmap(path3[k]);
                        Sample axs = new Sample(j);
                        for (int m = 0; m < 28; m++)
                        {
                            for (int n = 0; n < 28; n++)
                            {
                                axs.data[m * 28 + n] = (int)temporary.GetPixel(m, n).R / 255.0;
                            }
                        }
                        traindata.Add(axs);
                    }
                }
            }
        }
        //Codebook vektörlerin seçilmesi sırasında kullanılacak rastgele sayıların oluşturulması
        private int[] takeRandoms(int x, int max)
        {
            int[] temp = new int[x];
            int tempC = 0;
            while (tempC < x)
            {
                int t = r.Next(max);
                if (Array.IndexOf(temp, t) == -1)
                {
                    temp[tempC] = t;
                    tempC++;
                }
            }
            return temp;
        }
        //Codebook vektörlerin seçilmesi
        private void chooseCodeBooks(int x)
        {
            this.codebookCount = x;
            for (int i = 0; i < classCount; i++)
            {
                int[] cbIndex = takeRandoms(x, trainCount);
                for (int j = 0; j < x; j++)
                {
                    cbIndex[j] += i * trainCount;
                }
                for (int j = 0; j < x; j++)
                {
                    Sample axs = new Sample(i);
                    for (int k = 0; k < 784; k++)
                    {
                        axs.data[k] = traindata[cbIndex[j]].data[k];
                    }
                    codebooks.Add(axs);
                }
            }
        }
        //Codebook vektörlerin ortalama ile seçilmesi
        private void chooseCodeBooks(int x, bool temp)
        {
            this.codebookCount = x;
            for (int i = 0; i < classCount; i++)
            {
                Sample axs = new Sample(i);
                for (int j = 0; j < trainCount; j++)
                {                  
                    for (int k = 0; k < 784; k++)
                    {
                        axs.data[k] += traindata[i*trainCount + j].data[k];
                    }                   
                }

                for (int k = 0; k < 784; k++)
                {
                    axs.data[k] /= trainCount;
                }

                for (int j = 0; j < x; j++)
                {
                    codebooks.Add(axs);
                }
            }
        }
        //Verilerin karıştırılması
        private void shuffle()
        {
            Sample x;
            for (int i = 0; i < classCount * trainCount - 1; i++)
            {
                x = traindata[i];
                int temp = r.Next(i + 1, classCount * trainCount - 1);
                traindata[i] = traindata[temp];
                traindata[temp] = x;
            }
        }
        //Herhangi iki kayıt arasındaki mesafenin hesaplanması
        private double distance(Sample x, Sample y)
        {
            double temp = 0;
            for (int i = 0; i < 784; i++)
            {
                temp += Math.Abs(Math.Pow(x.data[i] - y.data[i], mk));
            }
            return temp;
        }
        //Window işleminin gerçekleştirilmesi
        private bool window(List<Node> x)
        {
            double d1 = x[0].uzaklık, d2 = x[1].uzaklık;
            if (d1 / d2 > (1 - w) / (1 + w)) return true;
            else return false;
        }

        //LVQ 2 algoritması
        private void lvq2()
        {
            for (int i = 0; i < tourCount; i++)
            {
                Console.WriteLine(i);
                for (int j = 0; j < classCount * trainCount; j++)
                {
                    List<Node> cbIndex = find2Nearest(traindata[j]);

                    if (window(cbIndex))
                    {
                        update(j, cbIndex);
                    }
                }
                pb.Value = i + 1;
                Application.DoEvents();
            }
        }
        //Her class için en yakın kayıtların bulunması
        private List<Node> find2Nearest(Sample x)
        {
            List<Node> tempo = new List<Node>();
            double dist;

            for (int i = 0; i < classCount; i++)
            {
                Node temp = new Node(0, i, Double.MaxValue);
                for (int j = 0; j < codebookCount; j++)
                {
                    dist = distance(x, codebooks[i * codebookCount + j]);
                    if (dist < temp.uzaklık)
                    {
                        temp.y = j;
                        temp.uzaklık = dist;
                    }
                }
                tempo.Add(temp);
            }

            return tempo.OrderBy(a => a.uzaklık).ToList();
        }
        //Codebook vektörlerinin güncellenmesi
        private void update(int j, List<Node> cbIndex)
        {
            for (int c = 0; c < 2; c++)
            {
                if (traindata[j].sinif == cbIndex[c].sınıf)
                {
                    for (int i = 0; i < 784; i++)
                    {
                        codebooks[cbIndex[c].sınıf * codebookCount + cbIndex[c].y].data[i] = codebooks[cbIndex[c].sınıf * codebookCount + cbIndex[c].y].data[i] + alfa * (traindata[j].data[i] - codebooks[cbIndex[c].sınıf * codebookCount + cbIndex[c].y].data[i]);
                    }
                }
                else
                {
                    for (int i = 0; i < 784; i++)
                    {
                        codebooks[cbIndex[c].sınıf * codebookCount + cbIndex[c].y].data[i] = codebooks[cbIndex[c].sınıf * codebookCount + cbIndex[c].y].data[i] - alfa * (traindata[j].data[i] - codebooks[cbIndex[c].sınıf * codebookCount + cbIndex[c].y].data[i]);
                    }
                }
            }
        }

        //LVQ 3 algoritması
        private void lvq3()
        {
            for (int i = 0; i < tourCount; i++)
            {
                Console.WriteLine(i);
                for (int j = 0; j < classCount * trainCount; j++)
                {
                    List<Node> cbIndex = find2Nearest2(traindata[j]);
                    if (window(cbIndex))
                    {
                        update2(j, cbIndex);
                    }
                }
                pb.Value = i + 1;
                Application.DoEvents();
            }
        }
        //Class ayrımı yapmaksızın en yakın iki kaydın bulunması
        private List<Node> find2Nearest2(Sample x)
        {
            List<Node> tempo = new List<Node>();
            double dist;
            tempo.Add(new Node(0, 0, Double.MaxValue));
            tempo.Add(new Node(0, 0, Double.MaxValue));

            for (int i = 0; i < classCount; i++)
            {
                for (int j = 0; j < codebookCount; j++)
                {
                    dist = distance(x, codebooks[i * codebookCount + j]);
                    if (dist < tempo[0].uzaklık)
                    {
                        tempo[1].sınıf = tempo[0].sınıf;
                        tempo[1].uzaklık = tempo[0].uzaklık;
                        tempo[1].y = tempo[0].y;

                        tempo[0].sınıf = i;
                        tempo[0].y = j;
                        tempo[0].uzaklık = dist;
                    }
                    else if (dist < tempo[1].uzaklık)
                    {
                        tempo[1].sınıf = i;
                        tempo[1].y = j;
                        tempo[1].uzaklık = dist;
                    }
                }
            }

            return tempo;
        }
        //Codebook vektörlerinin güncellenmesi
        private void update2(int j, List<Node> cbIndex)
        {
            if (!(traindata[j].sinif == cbIndex[0].sınıf && traindata[j].sinif == cbIndex[1].sınıf))
            {
                for (int c = 0; c < 2; c++)
                {
                    if (traindata[j].sinif == cbIndex[c].sınıf)
                    {
                        for (int i = 0; i < 784; i++)
                        {
                            codebooks[cbIndex[c].sınıf * codebookCount + cbIndex[c].y].data[i] = codebooks[cbIndex[c].sınıf * codebookCount + cbIndex[c].y].data[i] + alfa * (traindata[j].data[i] - codebooks[cbIndex[c].sınıf * codebookCount + cbIndex[c].y].data[i]);
                        }
                    }
                    else
                    {
                        for (int i = 0; i < 784; i++)
                        {
                            codebooks[cbIndex[c].sınıf * codebookCount + cbIndex[c].y].data[i] = codebooks[cbIndex[c].sınıf * codebookCount + cbIndex[c].y].data[i] - alfa * (traindata[j].data[i] - codebooks[cbIndex[c].sınıf * codebookCount + cbIndex[c].y].data[i]);
                        }
                    }
                }
            }
            else
            {
                for (int c = 0; c < 2; c++)
                {
                    for (int i = 0; i < 784; i++)
                    {
                        codebooks[cbIndex[c].sınıf * codebookCount + cbIndex[c].y].data[i] = codebooks[cbIndex[c].sınıf * codebookCount + cbIndex[c].y].data[i] + alfa * eps * (traindata[j].data[i] - codebooks[cbIndex[c].sınıf * codebookCount + cbIndex[c].y].data[i]);
                    }
                }
            }


        }

        //Test verilerinin en yakın codebook vektörlerine göre doğru classa atanması
        private void test()
        {
            double[] result = new double[classCount + 1];
            for (int i = 0; i < classCount; i++)
            {
                Console.WriteLine("t" + i.ToString());
                for (int j = 0; j < testCount; j++)
                {
                    if (testdata[i * testCount + j].sinif == findNearest(testdata[i * testCount + j])) result[testdata[i * testCount + j].sinif]++;
                }
            }
            double ortalama = 0.0;
            string sonuc = "";
            for (int i = 0; i < classCount + 1; i++)
            {
                result[i] = result[i] / testCount;
                ortalama += result[i];
                sonuc += result[i].ToString() + "  ";
            }
            result[classCount] = ortalama / classCount;
            sonuc += result[classCount].ToString();
            excelCreator(result);

        }
        //Her test verisi için en yakın codebook vektörünün bulunması
        private int findNearest(Sample x)
        {
            int indis = 0;
            double dist, minDist = Double.MaxValue;
            for (int i = 0; i < classCount * codebookCount; i++)
            {
                dist = distance(x, codebooks[i]);
                if (dist < minDist)
                {
                    indis = i / codebookCount;
                    minDist = dist;
                }
            }
            return indis;          
        }
        //Sonuçları istenilen formatta excele yazılması
        private void excelCreator(double[] result)
        {
            if (File.Exists("sonuclar.xlsx"))
            {
                closeOpenFile("sonuclar.xlsx");
                using (var p = new ExcelPackage(new FileInfo("sonuclar.xlsx")))
                {
                    string[] row1 = { "Rakam Sınıfı", "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "Ortalama" };
                    string[] row2 = { "Accuracy değeri", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0" };
                    int index = 0;
                    for (int i = 0; i < 11; i++)
                    {
                        row2[i + 1] = result[i].ToString();
                    }
                    var ws = p.Workbook.Worksheets.Add((p.Workbook.Worksheets.Count + 1).ToString());
                    char indexA = 'A', indexB = 'B';
                    for (int i = 0; i < 12; i++)
                    {
                        ws.Cells[indexA.ToString() + "1"].Value = row1[i];
                        ws.Cells[indexA.ToString() + "2"].Value = row2[i];
                        indexA++;
                    }
                    indexA = 'A';
                    indexB = 'B';
                    index = 4;
                    ws.Cells[indexA.ToString() + index.ToString()].Value = "LVQ 2";
                    if (flag)
                        ws.Cells[indexA.ToString() + index.ToString()].Value = "LVQ 3";

                    index++;
                    ws.Cells[indexA.ToString() + index.ToString()].Value = "Class Count";
                    ws.Cells[indexB.ToString() + index.ToString()].Value = classCount;
                    index++;
                    ws.Cells[indexA.ToString() + index.ToString()].Value = "Train Count";
                    ws.Cells[indexB.ToString() + index.ToString()].Value = trainCount;
                    index++;
                    ws.Cells[indexA.ToString() + index.ToString()].Value = "Test Count";
                    ws.Cells[indexB.ToString() + index.ToString()].Value = testCount;
                    index++;
                    ws.Cells[indexA.ToString() + index.ToString()].Value = "Codebook Count";
                    ws.Cells[indexB.ToString() + index.ToString()].Value = codebookCount;
                    index++;
                    ws.Cells[indexA.ToString() + index.ToString()].Value = "Tour Count";
                    ws.Cells[indexB.ToString() + index.ToString()].Value = tourCount;
                    index++;
                    ws.Cells[indexA.ToString() + index.ToString()].Value = "W";
                    ws.Cells[indexB.ToString() + index.ToString()].Value = w;
                    index++;
                    ws.Cells[indexA.ToString() + index.ToString()].Value = "Alfa";
                    ws.Cells[indexB.ToString() + index.ToString()].Value = alfa;
                    index++;
                    ws.Cells[indexA.ToString() + index.ToString()].Value = "Epsilon";
                    ws.Cells[indexB.ToString() + index.ToString()].Value = eps;

                    p.Save();
                }
            }
            else
            {
                using (var p = new ExcelPackage())
                {
                    string[] row1 = { "Rakam Sınıfı", "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "Ortalama" };
                    string[] row2 = { "Accuracy değeri", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0" };
                    int index = 0;
                    for (int i = 0; i < 11; i++)
                    {
                        row2[i + 1] = result[i].ToString();
                    }
                    var ws = p.Workbook.Worksheets.Add("1");
                    char indexA = 'A', indexB = 'B';
                    for (int i = 0; i < 12; i++)
                    {
                        ws.Cells[indexA.ToString() + "1"].Value = row1[i];
                        ws.Cells[indexA.ToString() + "2"].Value = row2[i];
                        indexA++;
                    }
                    indexA = 'A';
                    indexB = 'B';
                    index = 4;
                    ws.Cells[indexA.ToString() + index.ToString()].Value = "LVQ 2";
                    if (flag)
                        ws.Cells[indexA.ToString() + index.ToString()].Value = "LVQ 3";

                    index++;
                    ws.Cells[indexA.ToString() + index.ToString()].Value = "Class Count";
                    ws.Cells[indexB.ToString() + index.ToString()].Value = classCount;
                    index++;
                    ws.Cells[indexA.ToString() + index.ToString()].Value = "Train Count";
                    ws.Cells[indexB.ToString() + index.ToString()].Value = trainCount;
                    index++;
                    ws.Cells[indexA.ToString() + index.ToString()].Value = "Test Count";
                    ws.Cells[indexB.ToString() + index.ToString()].Value = testCount;
                    index++;
                    ws.Cells[indexA.ToString() + index.ToString()].Value = "Codebook Count";
                    ws.Cells[indexB.ToString() + index.ToString()].Value = codebookCount;
                    index++;
                    ws.Cells[indexA.ToString() + index.ToString()].Value = "Tour Count";
                    ws.Cells[indexB.ToString() + index.ToString()].Value = tourCount;
                    index++;
                    ws.Cells[indexA.ToString() + index.ToString()].Value = "W";
                    ws.Cells[indexB.ToString() + index.ToString()].Value = w;
                    index++;
                    ws.Cells[indexA.ToString() + index.ToString()].Value = "Alfa";
                    ws.Cells[indexB.ToString() + index.ToString()].Value = alfa;
                    index++;
                    ws.Cells[indexA.ToString() + index.ToString()].Value = "Epsilon";
                    ws.Cells[indexB.ToString() + index.ToString()].Value = eps;

                    p.SaveAs(new FileInfo("sonuclar.xlsx"));
                }
            }
        }

        //Verilen değerlere göre fonksiyon seçimi ve çalıştırılması
        public void Run(int trainCount, int testCount, int codebookCount, int tourCount, double w, double alfa, double eps, bool flag, ProgressBar pb, bool cb,int mk)
        {
            this.trainCount = trainCount;
            this.testCount = testCount;
            this.codebookCount = codebookCount;
            this.tourCount = tourCount;
            this.w = w;
            this.alfa = alfa;
            this.eps = eps;
            this.flag = flag;
            this.pb = pb;
            this.cb = cb;
            this.mk = mk;
            pb.Maximum = tourCount + 1;
            takeData();
            if (traindata.Count > 0 && testdata.Count > 0)
            {
                
                if(cb)
                    chooseCodeBooks(codebookCount,cb);
                else
                    chooseCodeBooks(codebookCount);
                shuffle();

                if (flag)
                {
                    lvq3();
                }
                else
                {
                    lvq2();
                }

                test();
                pb.Value++;
                MessageBox.Show("İşlem tamamlandı.");
            }
        }
        //Sonuçlar.xlsx dosyası açıksa dosyaya ekleme yapabilmek için dosyayı kapatıyor
        void closeOpenFile(string dosya)
        {
            bool sonuc = false;
            try
            {
                FileStream fs = File.Open(dosya, FileMode.Open, FileAccess.Read, FileShare.None);
                fs.Close();
            }
            catch (Exception)
            {
                sonuc = true;
            }

            if (sonuc)
            {
                foreach (var process in Process.GetProcesses())
                {
                    if (process.MainWindowTitle.Contains("sonuclar.xlsx"))
                    {
                        process.Kill();
                        closeOpenFile(dosya);
                        break;
                    }
                }
            }
        }
    }

    //Kayıtların tutulması için veri yapısı
    public class Node
    {
        public int y;
        public int sınıf;
        public double uzaklık;
        public Node(int y, int sınıf, double uzaklık)
        {
            this.y = y;
            this.sınıf = sınıf;
            this.uzaklık = uzaklık;
        }
    }  
    public class Sample
    {
        public double[] data = new double[784];
        public int sinif;
        public Sample(int sinif)
        {
            this.sinif = sinif;
        }
    }
}
