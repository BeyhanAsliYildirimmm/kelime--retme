using System;
using System.Security.Policy;

namespace OvizeProjesi
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public void alfabe_yazdir()
        {
            string Alfabe = Convert.ToString(alfabe.Text);
            string[] harf = Alfabe.Split(',');
            for (int i = 0; i < harf.Length; i++)
            {
                listBox2.Items.Add(harf[i]);
            }

        }
        private void button1_Click(object sender, EventArgs e)
        {
            alfabe_yazdir();
            Random rastgele = new Random();
            int sayi = rastgele.Next(0, 2);
            int sayi2 = rastgele.Next(1,5);
            int istenesayi = Convert.ToInt32(uretilecekKelimeSayisi.Text);
            string Kural = Convert.ToString(kural.Text);
            char[] karakter = Kural.ToCharArray();
            string a = null; //parantez �ncesi aa*(a+b) ve parantez sonras� (a+b)*aa tutu�um de�i�ken
            string b = null; //parantezin i�ini tutu�um de�i�len
            string c = null; // parantrzin i�indeki ifadeyi random se�ip tutu�umuz de�i�ken
            string d = null; // ifadeleri birle�tirdi�im de�i�ken
            for (int i = 0; i < karakter.Length; i++)
            {
                if (karakter[i] != '(')
                {
                    for (int j = 0; j < karakter.Length; j++)
                    {
                      
                         if (karakter[j] == '*')
                         {
                            
                            for (int k = j + 1; k < karakter.Length; k++)
                            {
                                // *' dan sonra geri kalan ifade '(' ile ba�l�yor mu diye bakar aa*(a+b)
                                if (karakter[k] == '(')
                                {
                                    for (int l = k + 1; l < karakter.Length; l++)
                                    {
                                        if (karakter[l] == ')')
                                        {

                                            string[] ifade = b.Split('+');
                                            //e�er kural ')' bitiyorsa parantrz i�indeki ifadelerden birini random olarak se�tiriyoruz. aa*(a+b)
                                            if (karakter[karakter.Length - 1] == ')')
                                            {
                                                //c de�i�keninde parantez i�inde se�ilen ifadeyi tutuyoruz.
                                                if (sayi == 0)
                                                {
                                                 
                                                    c = String.Concat(c, ifade[sayi]);
                                                }
                                                if (sayi == 1)
                                                {
                                                    c = String.Concat(c, ifade[sayi]);
                                                }
                                            }
                                            else
                                            {
                                                //e�er parantezden sonra ifade * ile devam ediyorsa random say� �retip se�ilen ifsdeyi �retilen say� kadar de�i�kene ekliyoruz. aa*(a+b)*
                                                if (karakter[l + 1] == '*')
                                                {
                                                    //c de�i�keninde parantez i�inde se�ilen ifadeyi tutuyoruz.
                                                    for (int z = 0; z < sayi2; z++)
                                                    {
                                                        if (sayi == 0)
                                                        {
                                                            c = String.Concat(c, ifade[sayi]);
                                                        }
                                                        if (sayi == 1)
                                                        {
                                                            c = String.Concat(c, ifade[sayi]);
                                                        }
                                                    }
                                                }
                                            }                                          
                                        }
                                        else
                                        {
                                            //parantezin i�indeki ifadeyi b de�i�keninde tutuyoruz.
                                            b = String.Concat(b, karakter[l]);
                                        }
                                    }
                                    for (int u = 0; u < istenesayi; u++)
                                    {         
                                        // a'� a'ya eklememizin sebebi ifadenin �n�nde * olmas�ndan kaynakl�d�r.
                                        a = String.Concat(a, a);
                                        d = String.Concat(a, c);
                                       listBox1.Items.Add(d);
                                    }
                                }
                                break;
                            }
                            break;
                        }                    
                        else
                        {
                             if (karakter[j] != '(')
                             {
                                //kural parantez ile ba�lam�yorsa *  g�rene kadar ki karakterleri a de�i�keninde tutar
                                 a = String.Concat(a, karakter[j]);
                             }
                             else if (karakter[j] == '(')
                             {
                                //e�er ifade aa(a+b) vb ifadeler gibiyse
                                 for (int l = j + 1; l < karakter.Length; l++)
                                 {
                                     if (karakter[l] == ')')
                                     {
                                                                          //aa(a+b)
                                         string[] ifade = b.Split('+');
                                        if (karakter[karakter.Length - 1] == ')')
                                        {
                                            if (sayi == 0)
                                            {
                                                c = String.Concat(c, ifade[sayi]);
                                            }
                                            if (sayi == 1)
                                            {
                                                c = String.Concat(c, ifade[sayi]);
                                            }
                                        }
                                        else
                                        {
                                            if (karakter[l + 1] == '*')
                                            {           
                                                                         //aa(a+b)*
                                                 
                                     //e�er ifade * ile devam ediyor ifadeyi random �retilen de�er kadar art arda yazd�r�yoruz.
                                                for (int m = 0; m < sayi2; m++)
                                                {

                                                    if (sayi == 0)
                                                    {
                                                        c = String.Concat(c, ifade[sayi]);
                                                    }
                                                    if (sayi == 1)
                                                    {
                                                        c = String.Concat(c, ifade[sayi]);
                                                    }
                                                }
                                            }
                                        }
                                        for (int h = 0; h < istenesayi; h++)
                                        {
                                            d = String.Concat(a, c);
                                            listBox1.Items.Add(d);
                                        }
                                      
                                     }
                                     else
                                     {
                                        // parantezin i�in tutu�umuz de�i�ken
                                         b = String.Concat(b, karakter[l]);
                                     }
                                 }
                                
                             }
                             else
                             {
                                 break;
                             }
                        }                  
                    }
                }
                //e�er kural�m�z '(' ile ba�l�yorsa
                else if (karakter[i] == '(')
                {
                    for (int l = i + 1; l < karakter.Length; l++)
                    {
                        if (karakter[l] == ')')
                        {
                            string[] ifade = b.Split('+');
                                                           //(a+b)  
                            if (karakter[karakter.Length - 1] == ')')
                            {
                                if (sayi == 0)
                                {
                                    c = String.Concat(c, ifade[sayi]);


                                }
                                if (sayi == 1)
                                {
                                    c = String.Concat(c, ifade[sayi]);


                                }
                            }
                            else
                            {
                                for (int m = l + 1; m < karakter.Length; m++)
                                {                                                                     //(a+b)*.....      
                                    if (karakter[m] == '*')
                                    {
                                        for (int f = m + 1; f < karakter.Length; f++)
                                        {
                                            // parantez kapand�ysa ve y�ld�z varsa sonra ki kalan ifadeye bakar.
                                            if (karakter[f] == '*')
                                            {
                                                                            //(a+b)*aa*
                                                for (int o = 0; o < sayi2; o++)
                                                {

                                                    a = String.Concat(a, a);
                                                }

                                            }
                                            else
                                            {                               //(a+b)*aa
                                                a = String.Concat(a, karakter[f]);

                                            }

                                        }
                                        for (int o = 0; o < sayi2; o++)
                                        {
                                            if (sayi == 0)
                                            {
                                                c = String.Concat(c, ifade[sayi]);


                                            }
                                            if (sayi == 1)
                                            {
                                                c = String.Concat(c, ifade[sayi]);


                                            }

                                        }
                                        //parantezin i�inden se�ilen ifadeyi random de�er kadar art arda ekler -> * 
                                        break;
                                    }
                                    else if (karakter[m] != '*')           //(a+b)..... 
                                    {


                                        for (int f = m; f < karakter.Length; f++)
                                        {
                                            // parantez kapand�ysa ve y�ld�z yoksa sonra ki kalan ifadeye bakar.
                                            if (karakter[f] == '*')
                                            {

                                                                          //(a+b)aa*
                                                for (int o = 0; o < sayi2; o++)
                                                {

                                                    a = String.Concat(a, a);

                                                }
                                            }
                                            else
                                            {                              //(a+b)aa
                                                a = String.Concat(a, karakter[f]);

                                            }

                                        }

                                        if (sayi == 0)
                                        {
                                            c = String.Concat(c, ifade[sayi]);

                                        }
                                        if (sayi == 1)
                                        {
                                            c = String.Concat(c, ifade[sayi]);

                                        }
                                        break;

                                    }
                                    else
                                    {
                                        break;
                                    }

                                }
                            }
                          
                            for (int h = 0; h < istenesayi; h++)
                            {
                                d = String.Concat(c, a);
                                listBox1.Items.Add(d);
                            }
                        }
                        else
                        {
                            //parantezin i�ini tutuumuz de�i�ken
                            b = String.Concat(b, karakter[l]);
                        }
                    }
                }
                break;
            }
        }  
    }
}
