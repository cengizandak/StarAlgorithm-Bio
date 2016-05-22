using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text;
using System.Collections;

namespace ConsoleApplication1
{
   
    class Program
    {
        static ArrayList skor = new ArrayList();
        static ArrayList diziler = new ArrayList();
        static ArrayList hizali = new ArrayList();
        static ArrayList slerin_puani= new ArrayList();
        static void Hesapla(string ilk, string iki, int matchh, int missmatchh, int gapp)
        {

            int refSeqCnt = ilk.Length+1;
         
            int buyuk = 0;
           
            int alineSeqCnt = iki.Length+1;
            int maxScore = 0;

            int[,] scoringMatrix = new int[alineSeqCnt, refSeqCnt];
            scoringMatrix[0, 0] = 0;
            //Initialization Step - filled with 0 for the first row and the first column of matrix
            for (int i = 1; i < alineSeqCnt; i++)
            {
                scoringMatrix[i, 0] = scoringMatrix[i-1, 0]+gapp;
            }

            for (int j = 1; j < refSeqCnt; j++)
            {
                scoringMatrix[0, j] = scoringMatrix[0,j-1] + gapp;
            }

            for (int i = 1; i < alineSeqCnt; i++)
            {
                for (int j = 1; j < refSeqCnt; j++)
                {
                    int scroeDiag = 0;
                    if (ilk.Substring(j - 1, 1) == iki.Substring(i - 1, 1))
                        scroeDiag = scoringMatrix[i - 1, j - 1] + matchh;
                    else
                        scroeDiag = scoringMatrix[i - 1, j - 1] + missmatchh;

                    int scroeLeft = scoringMatrix[i, j - 1] + gapp;
                    int scroeUp = scoringMatrix[i - 1, j] + gapp;

                    maxScore = Math.Max(Math.Max(scroeDiag, scroeLeft), scroeUp);

                    scoringMatrix[i, j] = maxScore;
                    if(maxScore>buyuk)buyuk=maxScore;



                }
               
             
            }
            skor.Add(scoringMatrix[alineSeqCnt-1,refSeqCnt-1]);
            char[] alineSeqArray = iki.ToCharArray();
            char[] refSeqArray = ilk.ToCharArray();

            string AlignmentA = string.Empty;
            string AlignmentB = string.Empty;
            int m = alineSeqCnt - 1;
            int n = refSeqCnt - 1;
            int buyukk=1;
           
          
            while (m>0 && n>0)
            {
                int scroeDiag = 0;
                if (m > n) buyukk = m;
                else buyukk = n;

                //Remembering that the scoring scheme is +2 for a match, -1 for a mismatch and -2 for a gap
             
                    if (alineSeqArray[m - 1] == refSeqArray[n - 1])
                        scroeDiag = matchh;
                    else
                        scroeDiag = missmatchh;

                    if (scoringMatrix[m, n] == scoringMatrix[m - 1, n - 1] + scroeDiag)
                    {
                        AlignmentA = refSeqArray[n - 1] + AlignmentA;
                        AlignmentB = alineSeqArray[m - 1] + AlignmentB;
                        buyukk = buyukk - 1;

                        m = m - 1;
                        n = n - 1;
                    }
                    else if (scoringMatrix[m, n] == scoringMatrix[m, n - 1] + gapp)
                    {
                        AlignmentA = refSeqArray[n - 1] + AlignmentA;
                        AlignmentB = "-" + AlignmentB;

                       
                         n = n - 1; 

                    }


                    else if (scoringMatrix[m, n] == scoringMatrix[m - 1, n] + gapp)
                    {
                        AlignmentA = "-" + AlignmentA;
                        AlignmentB = alineSeqArray[m - 1] + AlignmentB;



                         m = m - 1;
                    }
                    if(n>0 && m==0)for(int a=n;a>0; a--)
                    {
                        AlignmentA = refSeqArray[n - 1] + AlignmentA;
                        AlignmentB = "-" + AlignmentB;
                        n = n - 1;
                      
                    }
                    if(m>0&&n==0)
                    for (int a = m; a > 0; a--)
                    {
                        AlignmentA = "-" + AlignmentA;
                        AlignmentB = alineSeqArray[m - 1] + AlignmentB;
                        m = m - 1;

                    }
          
            

            }
                
            hizali.Add(AlignmentA);
            hizali.Add(AlignmentB);


        }
        static void StarBul(int []a,int s_sayisi)
        {
          
            int[] sler = new int[s_sayisi];
            
            for (int i = 0; i < s_sayisi; i++)

       {

                for (int j = ((a.Length / s_sayisi) * i); j < (((a.Length / s_sayisi) * i) + s_sayisi)-1; j=j+1)
                {

                   
                    sler[i] = sler[i] + a[j];
                    

                }

               
                slerin_puani.Add(sler[i]);

          }
            int numara = 1;
            int bykk = 0;
            foreach (int asd in slerin_puani)
            {
                Console.WriteLine("\nS" + numara + "Puanı: " + asd);
                numara++;
            }
            
        }
        static void StarHizala(int star_no)
        {

            int kac_tane = -1;
            int dizii=0;
            int sss = 0;
            
           string ayirici;
            foreach(string b in hizali)
            { kac_tane++; }
            foreach (string b in diziler)
            { dizii++; }
            string[] sslerr = new string[kac_tane+1];
            string[] dizi = new string[dizii-1];
            string[] sonuc = new string[dizii - 1];
            
        
            foreach (string aab in hizali)
            {
                sslerr[sss] = aab;
                sss++;
            }
            int i = 1;
          
            dizi[0] = sslerr[((sslerr.Length / (dizii - 1)) * star_no)];
            sonuc[0]= dizi[0];
         

            for (int j = ((sslerr.Length / (dizii-1)) * star_no)+1; j <= (((sslerr.Length / (dizii-1)) * star_no) + (sslerr.Length / (dizii - 1)) -1); j = j + 2)
                {
              
                dizi[i] = sslerr[j];
                
                i++;
                }
           
            Console.WriteLine((dizii-1)+" lu parca olarak :\n");
            foreach(String m in dizi)
            { Console.WriteLine(m); }

        }
        static void Main(string[] args)
        {
            StreamReader oku;

            int sayac = 0;
            int sss = 0;
            string okuduk;
            oku = File.OpenText(@"C:\biyo.txt");
            okuduk = oku.ReadLine();
     
                       
            char ayirici = ' ';
            string[] isimler = okuduk.Split(ayirici);
            int match = Convert.ToInt32(isimler[0]);
            int missmatch= Convert.ToInt32(isimler[1]);
            int gap = Convert.ToInt32(isimler[2]);
           
            while (okuduk!=null)
            {
                
                okuduk = oku.ReadLine();
                diziler.Add(okuduk);
                sss++;
            }

          foreach(string icinde in diziler)
            {
                sayac++;
                Console.WriteLine(icinde);
            }
           
            int say = 0;
            Console.WriteLine("sayac : " + sayac);
            for (int j = 0; j < sayac - 1; j++)
            {
                for (int i = 0; i < sayac - 1; i++)
                {
                    if (diziler[j] == diziler[i]) continue;
                    Hesapla(diziler[j].ToString(), diziler[i].ToString(), match, missmatch, gap);
                }
            }
            int bak = 1, bakma = 1;
            foreach (string show in hizali)
            {

                if ((bak - 2) % 2 == 0)

                { Console.WriteLine( "\t: " + show + "\n");bakma++; }
                else Console.WriteLine(bakma+"\t: " + show); bak++;

            }
            foreach (int a in skor)
            {
                say++;
                Console.WriteLine(say+"eşleşme puanı : " + a);
            }
            int baslamak = 0;
           foreach(int kac_tane in skor)
            {
                baslamak++;
            }
            int[] buyuk = new int[baslamak];
            int byk = 0;
            int kucuk = 0;
            int ij = 0;
            foreach(int degerr in skor)
            {
                buyuk[ij] = degerr;
                ij++;

            }
            byk = 0;
            sayac = 0;
        
            StarBul(buyuk, sss - 1);

            ij = 0;
            int[] Skor = new int[sss - 1];
            foreach(int asal in slerin_puani)
            {
                Skor[ij] = asal;
                ij++;
            }
            byk = Skor[0];
            sayac = 0;
           for(int i=0;i<Skor.Length-1;i++)
            {
                if (Skor[i + 1] > byk)
                {
                    byk = Skor[i + 1];sayac = i + 1;
                }

                }
        
            Console.WriteLine("\nStar olarak S"+(sayac+1)+" Secilmiştir Puanı:  "+Skor[sayac]);
            StarHizala(sayac);
            Console.ReadLine();
        }

       
    }
}
