namespace feladat
{
    internal class Program
    {

        struct Zeneszamok{
            public string eloadocim;
            public string kategoria;
            public int kiadasDatuma;
            public int szavazatok;
        }

        struct Mufaj{
            public string eloadocim;
            public string kategoria;
            public int kiadasDatuma;
            public int szavazatok;
        }

        static int n = 0;
        static Zeneszamok[] zeneszamok = new Zeneszamok[1000];
        static Mufaj[] mufajok = new Mufaj[1000];

        static void Main(string[] args)
        {
            StreamReader sr = new StreamReader("zeneszamok.txt");
            while (!sr.EndOfStream)
            {
                string row = sr.ReadLine();
                string[] data = row.Split(' ');
                ;
                

                zeneszamok[n].eloadocim = data[0];
                zeneszamok[n].kategoria = data[1];
                zeneszamok[n].kiadasDatuma = int.Parse(data[2]);
                zeneszamok[n].szavazatok = int.Parse(data[3]);



                n++;

            }
            sr.Close();


            Console.WriteLine("3. Feladat:");
            Console.WriteLine("Adja meg egy kategoria nevét:");
            string kategoria = Console.ReadLine();
            for (int i = 0; i < n; i++)
            {
                if (zeneszamok[i].kategoria == kategoria)
                {
                    Console.WriteLine(zeneszamok[i].eloadocim);
                    mufajok[i].eloadocim = zeneszamok[i].eloadocim;
                    mufajok[i].kategoria = zeneszamok[i].kategoria;
                    mufajok[i].kiadasDatuma = zeneszamok[i].kiadasDatuma;
                    mufajok[i].szavazatok = zeneszamok[i].szavazatok;


                }
            }

            List<Mufaj> mufaj_sort = mufajok.OrderBy(x => x.szavazatok).ToList();


            StreamWriter html = new StreamWriter("index.html");

            html.WriteLine(@"
                <html>
                    <head>
                        <link rel='stylesheet' type='text/css' href=' ./alap.css'/>
                    </head>
                    <body>");

            html.WriteLine(@"<h1>Számok a toplistán</h1>");
            html.WriteLine(@"
                     <table>
                        <tr class=""cim"">
                            <td>Előadó-Cím</td>
                            <td>Kiadás éve</td>
                        </tr>
            ");
            for (int i = 0; i < n; i++)
            {
                html.WriteLine($@"
                        <tr>
                            <td>{zeneszamok[i].eloadocim}</td>
                            <td>{zeneszamok[i].kiadasDatuma}</td>
                        </tr>
                     
            ");
            }
            html.WriteLine(@"
                    </table>
            ");


            html.WriteLine($@"
                        <h1>{kategoria}</h1>
                        <h2>Szavazatok szerint rendezve</h2>
                        <table border=""1px solid"" class=""tablazat"">
                            <tr class=""cim"">
                                <td>Előadó-Cím</td>
                                <td>Kiadás éve</td>
                                <td>Szavazatok</td>
                            </tr>
            ");
            for (int i = 0; i < n; i++)
            {
                html.WriteLine($@"
                            <tr>
                                <td>{mufaj_sort[i].eloadocim}</td>
                                <td>{mufaj_sort[i].kiadasDatuma}</td>
                                <td>{mufaj_sort[i].szavazatok}</td>
                            </tr>
                     
                ");
            }
            html.WriteLine(@"
                       <table>
            ");

            /*html.WriteLine(@"
                        <tr>
                            <td>Zámbó Jimmy-Bukott_diák</td>
                            <td>1996</td>
                            <td>85</td>
                        </tr>
                        <tr>
                            <td>MGMT-Kids</td>
                            <td>2007</td>
                            <td>53</td>
                        </tr>
                        <tr>
                            <td>Dzsúdló-Unom</td>
                            <td>2019</td>
                            <td>24</td>
                        </tr>
                        <tr>
                            <td>Datarock-Amarillon</td>
                            <td>2009</td>
                            <td>21</td>
                        </tr>
                        <tr>
                            <td>Ákos-Hello</td>
                            <td>1993</td>
                            <td>4</td>
                        </tr>
                    </table>
        ");*/

            int maxSzavazat = 0;
            for (int i = 0; i < n; i++)
            {
                if (mufajok[i].szavazatok > maxSzavazat)
                {
                    maxSzavazat = mufajok[i].szavazatok;
                }
            }
            for (int i = 0; i < n; i++)
            {
                if (mufajok[i].szavazatok == maxSzavazat)
                {
                    html.WriteLine($@"
                        <h3>Legtöbb szavazatot kapott szám:</h3>
                        <p></p>
            ");
                }
                
            }
            html.WriteLine(@"
                        <h3>Legtöbb szavazatot kapott szám:</h3>
                        <p></p>
            ");

            html.WriteLine(@"
                        <h3>Legrégibb szám:</h3>
                        <p></p>
            ");

            html.WriteLine(@"
                    </body>
                </html>
            ");

            html.Close();
            
        }
    }
}