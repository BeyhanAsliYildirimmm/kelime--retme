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
            string a = null; //parantez öncesi aa*(a+b) ve parantez sonrasý (a+b)*aa tutuðum deðiþken
            string b = null; //parantezin içini tutuðum deðiþlen
            string c = null; // parantrzin içindeki ifadeyi random seçip tutuðumuz deðiþken
            string d = null; // ifadeleri birleþtirdiðim deðiþken
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
                                // *' dan sonra geri kalan ifade '(' ile baþlýyor mu diye bakar aa*(a+b)
                                if (karakter[k] == '(')
                                {
                                    for (int l = k + 1; l < karakter.Length; l++)
                                    {
                                        if (karakter[l] == ')')
                                        {

                                            string[] ifade = b.Split('+');
                                            //eðer kural ')' bitiyorsa parantrz içindeki ifadelerden birini random olarak seçtiriyoruz. aa*(a+b)
                                            if (karakter[karakter.Length - 1] == ')')
                                            {
                                                //c deðiþkeninde parantez içinde seçilen ifadeyi tutuyoruz.
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
                                                //eðer parantezden sonra ifade * ile devam ediyorsa random sayý üretip seçilen ifsdeyi üretilen sayý kadar deðiþkene ekliyoruz. aa*(a+b)*
                                                if (karakter[l + 1] == '*')
                                                {
                                                    //c deðiþkeninde parantez içinde seçilen ifadeyi tutuyoruz.
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
                                            //parantezin içindeki ifadeyi b deðiþkeninde tutuyoruz.
                                            b = String.Concat(b, karakter[l]);
                                        }
                                    }
                                    for (int u = 0; u < istenesayi; u++)
                                    {         
                                        // a'ý a'ya eklememizin sebebi ifadenin önünde * olmasýndan kaynaklýdýr.
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
                                //kural parantez ile baþlamýyorsa *  görene kadar ki karakterleri a deðiþkeninde tutar
                                 a = String.Concat(a, karakter[j]);
                             }
                             else if (karakter[j] == '(')
                             {
                                //eðer ifade aa(a+b) vb ifadeler gibiyse
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
                                                 
                                     //eðer ifade * ile devam ediyor ifadeyi random üretilen deðer kadar art arda yazdýrýyoruz.
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
                                        // parantezin için tutuðumuz deðiþken
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
                //eðer kuralýmýz '(' ile baþlýyorsa
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
                                            // parantez kapandýysa ve yýldýz varsa sonra ki kalan ifadeye bakar.
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
                                        //parantezin içinden seçilen ifadeyi random deðer kadar art arda ekler -> * 
                                        break;
                                    }
                                    else if (karakter[m] != '*')           //(a+b)..... 
                                    {


                                        for (int f = m; f < karakter.Length; f++)
                                        {
                                            // parantez kapandýysa ve yýldýz yoksa sonra ki kalan ifadeye bakar.
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
                            //parantezin içini tutuumuz deðiþken
                            b = String.Concat(b, karakter[l]);
                        }
                    }
                }
                break;
            }
        }  
    }
}
