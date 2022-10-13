// See https://aka.ms/new-console-template for more information
// Console.WriteLine("Hello, World!");

string zamianaZPlikuNaGolyString(string nazwaPliku){

    nazwaPliku = nazwaPliku+".txt";
    string niesformatowanyString = File.ReadAllText(nazwaPliku);
    string gotowyLancuchZnakow = niesformatowanyString.Replace("\n", "").Replace("\n", "");

    return gotowyLancuchZnakow;
}

string przeliczenieWartosciLiczbowychCss(string surowyKodCss, float minWidth, float maxWidth){
    string wynik = "";


    // Zamiana stringu na tablice `charow`, gdzie kazdy element niebedacy cyfra zostal
    // zamieniony na wartosc 'a'.
    char[] tabOfCharValues = new char[surowyKodCss.Length];
    int indexOfCharTab = 0;
    int indexOfIntTab = 0;
    for(int i=0; i<surowyKodCss.Length; i++){
        if(((int)(surowyKodCss[i]) <= 57) && ((int)(surowyKodCss[i]) >= 48)){
            tabOfCharValues[indexOfCharTab] = surowyKodCss[i];
            indexOfCharTab += 1;
            indexOfIntTab += 1;
        }
        else{
            tabOfCharValues[indexOfCharTab] = 'a';
            indexOfCharTab += 1;
        }
    }
    

    // Wyznaczenie indeksow dla miejsc,
    // ktore sa zajmowane przez cyfry.
    int[] tabOfIntValues = new int[indexOfIntTab];
    indexOfIntTab = 0;
    
    for(int i=0; i<tabOfCharValues.Length; i++){
        if(tabOfCharValues[i] != 'a'){
            // Console.Write(tabOfCharValues[i]);
            tabOfIntValues[indexOfIntTab] = i;
            // Console.Write(tabOfIntValues[indexOfIntTab]);
            indexOfIntTab += 1;
        }
    }

    
    // Zamiana pojedynczego znaku `a` na `.`.
    //Console.WriteLine();
    int sssCounter = 0;
    for(int i=0; i<tabOfIntValues.Length-1; i++){
        if((tabOfIntValues[i+1] - tabOfIntValues[i]) < 3){
            //Console.Write(tabOfIntValues[i]);
            if((tabOfIntValues[i+1] - tabOfIntValues[i]) >= 2){
            //Console.Write("a("+(tabOfIntValues[i]+1)+")");
            // Odnalezienie indeksu dla tablicy charow i podmiana
            tabOfCharValues[tabOfIntValues[i]+1] = '.';
            }
        }
        else {
            //Console.Write(tabOfIntValues[i]);
            //Console.Write("sss");
            sssCounter += 1;
        }
    }
    //Console.Write(tabOfIntValues[tabOfIntValues.Length-1]);


    // Zapisanie sobie ciagow liczb, na ktorych bedziemy operowac.
    string[] tabOfStringValues = new string[sssCounter+1];
    float[] tabOfFloatValues = new float[sssCounter+1];
    sssCounter = 0;

    int changeOperator = 0;
    int indexA = 0;
    int indexB = 0;

    float mnoznik = minWidth / maxWidth;
    //Console.WriteLine("mnoznik: "+ mnoznik);

    wynik = surowyKodCss;
    //Console.WriteLine(wynik);

    //Console.WriteLine();
    for(int i=0; i<tabOfIntValues.Length-1; i++){
        if((tabOfIntValues[i+1] - tabOfIntValues[i]) < 3){
            if(changeOperator == 0){
                indexA = tabOfIntValues[i];
                //Console.Write(indexA);
                changeOperator = 1;
            }
        }
        else {
            indexB = tabOfIntValues[i];
            //Console.Write(indexB);
            changeOperator = 0;
            //Console.Write("sss");

            // Console.WriteLine(surowyKodCss.Substring(indexA, (indexB-indexA+1)));

            // Przypisanie lancucha znakow w tabeli stringow, 
            // Zapisanie czystych wartosci float do drugiej tablicy.
            tabOfStringValues[sssCounter] = surowyKodCss.Substring(indexA, (indexB-indexA+1));
            tabOfFloatValues[sssCounter] = float.Parse(surowyKodCss.Substring(indexA, (indexB-indexA+1)));
            //Console.Write(tabOfStringValues[sssCounter] + " float: " + tabOfFloatValues[sssCounter]);
            if(sssCounter == 0){
                tabOfFloatValues[sssCounter] = 2;
                //Console.WriteLine(" pierwsza zmiana: "+tabOfFloatValues[sssCounter]);

                // Zmiana textu, ktory ostatecznie zostanie wygenerowany
                wynik = wynik.Replace(string.Format("{0:0}", tabOfStringValues[sssCounter]), string.Format("{0:F2}", tabOfFloatValues[sssCounter]));
                // Console.WriteLine(wynik);
            }
            else if(sssCounter == 1){
                tabOfFloatValues[sssCounter] = minWidth-1;
                //Console.WriteLine(" druga zmiana: "+tabOfFloatValues[sssCounter]);

                // Zmiana textu, ktory ostatecznie zostanie wygenerowany

                // Testy
                /*
                string test = "1110 pierwsza zmiana: 2";
                float textValue = float.Parse(string.Format("{0:0}", maxWidth));
                // textValue = textValue + 1;
                
                Console.WriteLine();
                Console.WriteLine("textValue: " + string.Format("{0:0)}", textValue));
                Console.WriteLine("Test1: " + test);
                Console.WriteLine("max-width: " + textValue);
                //Console.WriteLine("Wartosc z tabeli string: "+ string.Format("{0:0}", textValue));
                Console.WriteLine("Wartosc float: "+ string.Format("{0:F2}", tabOfFloatValues[sssCounter]));
                string test2 = test.Replace(string.Format("{0:0}", textValue), string.Format("{0:F2}", tabOfFloatValues[sssCounter]));
                //string test2 = test.Replace(string.Format("{0:0}", textValue), string.Format("{0:F2}", tabOfFloatValues[sssCounter]));
                
                Console.WriteLine("Test2: " + test2);
                Console.WriteLine();
                */
                // Koniec testow

                wynik = wynik.Replace(string.Format("{0:0}", tabOfStringValues[sssCounter]), string.Format("{0:F2}", tabOfFloatValues[sssCounter]));
            }

            // Zamiana wartosci w tabeli floatow, na te juz podzielobe.
            else{
                tabOfFloatValues[sssCounter] = tabOfFloatValues[sssCounter] * mnoznik;

                // Zmiana textu, ktory ostatecznie zostanie wygenerowany
                wynik = wynik.Replace(string.Format("{0:0}", tabOfStringValues[sssCounter]), string.Format("{0:F2}", tabOfFloatValues[sssCounter]));
            }

            sssCounter += 1;
        }
    }
    if(changeOperator != 0){
        indexB = tabOfIntValues[tabOfIntValues.Length-1];

        tabOfStringValues[sssCounter] = surowyKodCss.Substring(indexA, (indexB-indexA+1));
        tabOfFloatValues[sssCounter] = float.Parse(surowyKodCss.Substring(indexA, (indexB-indexA+1)));

        // Zamiana wartosci w tabeli floatow, na te juz podzielobe.
        tabOfFloatValues[sssCounter] = tabOfFloatValues[sssCounter] * mnoznik;

        // Zmiana textu, ktory ostatecznie zostanie wygenerowany
        wynik = wynik.Replace(string.Format("{0:0}", tabOfStringValues[sssCounter]), string.Format("{0:F2}", tabOfFloatValues[sssCounter]));
    }
    

    
    
    
    // Testy do wylowienia indeksow
    int l = 0;
    int lw = 0;
    for(int i=0; i<tabOfCharValues.Length; i++){
        if(l == 0){
            if(tabOfCharValues[i] != 'a'){
                lw += 1;
                l = 1;
            }
        } else{
            if(tabOfCharValues[i] == 'a'){
                lw += 1;
                l = 0;
            }
        }
    }

    int[] tabelaIndexowDoWyciecia = new int[lw];
    l = 0;
    lw=0;
    for(int i=0; i<tabOfCharValues.Length; i++){
        if(l == 0){
            if(tabOfCharValues[i] != 'a'){
                tabelaIndexowDoWyciecia[lw] = i-1;
                l = 1;
                lw += 1;
            }
        } else{
            if(tabOfCharValues[i] == 'a'){
                tabelaIndexowDoWyciecia[lw] = i;
                lw += 1;
                l = 0;
            }
        }
    }


    wynik = "";
    int j = 3;
    // Miejsce na sklecenie tego lancuchu do porzadku
    for(int i=0; i<tabOfFloatValues.Length; i++){
        if(i==0){
            string pomocniczy = surowyKodCss.Substring(0, tabelaIndexowDoWyciecia[i]);
            pomocniczy = pomocniczy + string.Format("{0:F2}", tabOfFloatValues[i]);
            wynik = wynik + pomocniczy;
        }
        else if(i==1) {
            string pomocniczy = surowyKodCss.Substring(tabelaIndexowDoWyciecia[i], (tabelaIndexowDoWyciecia[i+1]-tabelaIndexowDoWyciecia[i]));
            pomocniczy = pomocniczy + string.Format("{0:F2}", tabOfFloatValues[i]);
            wynik = wynik + pomocniczy;
        }
        else {
            string pomocniczy = surowyKodCss.Substring(tabelaIndexowDoWyciecia[j], tabelaIndexowDoWyciecia[j+1]-tabelaIndexowDoWyciecia[j]);
            pomocniczy = pomocniczy + string.Format("{0:F2}", tabOfFloatValues[i]);
            wynik = wynik + pomocniczy;
            j+=2;
        }   
    }
    
    string pomocniczyaa = surowyKodCss.Substring(tabelaIndexowDoWyciecia[j], surowyKodCss.Length-tabelaIndexowDoWyciecia[j]);
    wynik = wynik + pomocniczyaa;

    File.WriteAllText("result.css", wynik);
    return wynik;
}

string surowyKodCss = zamianaZPlikuNaGolyString("style2");
// Console.WriteLine(surowyKodCss);
Console.WriteLine("wynil: "+przeliczenieWartosciLiczbowychCss(surowyKodCss, 1782, 1920));