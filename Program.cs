// See https://aka.ms/new-console-template for more information
using System.Diagnostics.Contracts;

internal static class Program{

    public enum TankFüllstandLeuchte
    {
        GRUN,
        GELB,
        ROT    
    };
    public class PKW{
        public TankFüllstandLeuchte TankFüllstandLeuchte_leuchte= TankFüllstandLeuchte.GRUN;
        public event TankFüllstandBeobachter TankFüllstandBeobachter;
        public PKW(){

        }
        private  int tankfullstand = 15;
        internal object _fahrer;

        public void addTankfullstand(int fullstand){
            tankfullstand += fullstand;
            if(tankfullstand >= 15){
                TankFüllstandLeuchte_leuchte = TankFüllstandLeuchte.GRUN;
            }
        }

        public void Fahren(){
           

            while(tankfullstand > 0){
                Console.WriteLine("Brumm....");
                tankfullstand--;
                if(tankfullstand < 15){
                    TankFüllstandLeuchte_leuchte = TankFüllstandLeuchte.GELB;
                    TankFüllstandBeobachter?.Invoke(this);

                }else if(tankfullstand < 10){
                    TankFüllstandLeuchte_leuchte = TankFüllstandLeuchte.ROT;
                     TankFüllstandBeobachter?.Invoke(this);



                }
            }
        }    

    }
    public class Fahrer{
        public void Tanken(PKW pKW){
            pKW.addTankfullstand(15) ;
        }
        public void OnTankFüllstandNiedrig(PKW pkw){
        switch(pkw.TankFüllstandLeuchte_leuchte){
            case TankFüllstandLeuchte.GELB:
            Console.WriteLine("Ach noch Zeit");
            break;
            case TankFüllstandLeuchte.ROT:
            Console.WriteLine("Jetz aber dringend tanken...");
            Tanken(pkw);
            break;


        }

        }

    }
    public delegate void TankFüllstandBeobachter(PKW pkw);

     public static int quersumme(int zahl){
            int summe =0;
            while(zahl>0){
                summe+=zahl%10;
                zahl/=10;
            }
            return summe;
         }

         public class  Song{
            private string title;
            private string interpret;
            private int dauerSekunden;
            public Song(string title,string interpret, int dauerSekunden){
                this.title = title;
                this.interpret = interpret;
                this.dauerSekunden = dauerSekunden;
            }

            public string Title{
                get => title;
                set=> title=value;
            }
               public string Interpret
               {
                get => interpret;
                set=> interpret=value;
            }
               public int DauerSekundenauer{
                get => dauerSekunden;
                set => dauerSekunden =value;
            }

            public void Play(){
                Console.WriteLine("Title: {0}",title);
                Console.WriteLine("artist:{0}", interpret);
                Console.WriteLine("dauer : {0:00}:{1:00}",dauerSekunden/60,dauerSekunden%60);
            }
         }
            public class Artikel{
                private int id;
                private string bezeichnung;
                private double einkaufspreis;
                private double gewinnsatz;
                private double verkaufspreis;

                public Artikel(int id, string bezeichnung, double einkaufspreis, double gewinnsatz){
                    this.id=id; 
                    this.bezeichnung= bezeichnung;
                    this.einkaufspreis=einkaufspreis;
                    this.gewinnsatz=gewinnsatz;
                    verkaufspreis=einkaufspreis+ (einkaufspreis+gewinnsatz/100);
                }

                public int Id{
                    get=>id;
                    set=>id=value;
                }
                public string Bezeichnung{
                    get=>bezeichnung;
                    set=>bezeichnung=value;
                }

                public double Einkaufspreis{
                    get=>einkaufspreis;
                    set=>einkaufspreis=value;
                }

                public double Gewinnsatz{
                    get=>gewinnsatz;
                    set=>gewinnsatz=value;
                }

                public double Verkaufspreis{
                    get=>verkaufspreis;
                    set=>verkaufspreis=value;
                }

            }

            public class WarenkorbItem{
                private Artikel artikel;
                private int anzahl;


                public WarenkorbItem(Artikel artikel, int anzahl){
                    this.artikel= artikel;
                    this.anzahl= anzahl;
                }

                public Artikel Artikel{
                    get=>artikel;
                    set=>artikel=value;

                }
                public int Anzahl{
                    get=>anzahl;
                    set=>anzahl=value;

                }

                public double GesamtPreis{
                  get=>artikel.Verkaufspreis*anzahl;
                }
            }

            public class Warenkorb{
                private List<WarenkorbItem> warenkorbItems;

                public Warenkorb(){
                    warenkorbItems = new List<WarenkorbItem>();

                }

                public void ArtikelInWarenkorbAnlegen(Artikel artikel, int anzahl){
                    WarenkorbItem warenkorb = new WarenkorbItem(artikel,anzahl);
                    warenkorbItems.Add(warenkorb);
                }
                  public void ArtikelInWarenkorbEntwerfen(Artikel artikel){
                   warenkorbItems.RemoveAll(item=>item.Artikel==artikel);
                }

                public void ArtikelInWarenkorbAndern(Artikel artikel, int  anzahlNew){
                    WarenkorbItem warenkorbItem = warenkorbItems.FirstOrDefault(item=>item.Artikel==artikel);
                    if(warenkorbItem!=null){
                        warenkorbItem.Anzahl = anzahlNew;

                    }
                }

                public double GesamtePreisErmitteln(){
                    return warenkorbItems.Sum(item=>item.GesamtPreis);
                }
            
         }
    private static void Main(string[]args){
        PKW pkw = new PKW();
      Fahrer _fahrer = new Fahrer();
        pkw.TankFüllstandBeobachter += pkw._fahrer.OnTankFüllstandNiedrig(pkw);
    
        pkw.Fahren();        // Console.Write("Number insert:");
        // ConsoleKeyInfo consoleKeyInfo = Console.ReadKey(true);
        // int i= 4;
        // if(i%2==0){
        //     Console.WriteLine($"Nummeer paar");
        // }else{
        //     Console.WriteLine($"Nummeer impar");
        // }
        //      Console.Write("Number insert:");
        //  int eingabe = Console.ReadLine();
        //  int sum = 0;

        //  int b=eingabe%10;
        //  sum+=b;
        //  Console.WriteLine($"Result ist {sum} : ");
        
        // Console.WriteLine(quersumme(234)) ;
        // Random rnd = new Random();
        // int value = rnd.Next(1,100);
       
       
//         while(true){
//          Console.Write("Bitte wählen: "); 
//  string eingabe =Console.ReadLine();
 
//         int zahl = 0;
//         try{
//             zahl= int.Parse(eingabe);
//         }catch(Exception){
//             Console.WriteLine("Falsche eingabe...");
//             continue;
//         }

// //             if(zahl<value){
// //             Console.WriteLine($"Zu klein");
// //         }else if(zahl>value) {Console.WriteLine($"Zu groß");}
// //         else{Console.WriteLine($"RICHTIG");
// //         break;
// //         }
       
// //         }
       
//       Console.Write("Ziffer einfügen: ");   
//       string eingabe =Console.ReadLine();
//        int[] zahl = new int[eingabe.Length];
         
//         for(int i=0; i<eingabe.Length;i++){
//             zahl[i]= (int)(eingabe[i]);
//         }
//       int ziffer=0;
//       int summePaar=0;
//       int summeInpar =0;
//       int prufziffer=0;
//       for(int i=0; i<zahl.Length;i++){
//         if(i%2==0){
//         summePaar+= zahl[i];
//         }else{
//             summeInpar += zahl[i]*3;
//         }
//         ziffer = summePaar+summeInpar;
//          prufziffer = ziffer%10;

//       }
//       Console.WriteLine($"prufziffer {zahl}- {prufziffer}");
    //    Song s1 = new Song("Boniem", "Karl",60);
    //    s1.Play();

    // Artikel a1= new Artikel(1,"Adidas",10,20);
    
    // Artikel a2= new Artikel(2,"Pantofol",10,20);
    // Warenkorb warenkorb = new Warenkorb();
    // warenkorb.ArtikelInWarenkorbAnlegen(a1,2);
    // warenkorb.ArtikelInWarenkorbAnlegen(a2,1);
    // Console.WriteLine($"Gesamtpreis:{warenkorb.GesamtePreisErmitteln()}");

    Spellcaster spellcaster = new Spellcaster();
    spellcaster.CastSpell();
    Wizard wizard = new Wizard();
    wizard.CastSpell();
    }

     
  public class Spellcaster{

    public  virtual void CastSpell(){
        Console.WriteLine("Ich kann Zaubern");
    }
  } 
public class Sorcerer: Spellcaster{
    public override void CastSpell(){
            base.CastSpell();
        Console.WriteLine("Meine Zauberkraft ist mir angeboren");
    }
}

public class Wizard: Spellcaster{
    public override void CastSpell(){
        base.CastSpell();
        Console.WriteLine("Für meine Zauberkraft musste ich hart arbeiten");
    }
}
public class WildMagicSorcere:Sorcerer{
    public override  sealed void CastSpell(){
        base.CastSpell();
        Console.WriteLine("Meine Zauber sind unberechenbar");
    }
}
public class IlluusionWizard:Wizard{
    public override  sealed void CastSpell(){
        base.CastSpell();
        Console.WriteLine("Ich habe mich auf Illusionszauber spezialisiert.");
    }
}

}

