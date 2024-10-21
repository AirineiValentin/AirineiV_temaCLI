1. 
Viewport-ul este zona vizibila a unei pagini web. Aceasta variaza in functie de dispozitiv si poate creste sau scadea in functie de rezolutia ecranului dispozitivului.
2. 
Conceptul de frames per second (FPS) in contextul bibliotecii OpenGL se refera la numarul de cadre (imagini sau frame-uri) pe care aplicatia le poate reda pe ecran intr-o secunda.
3. 
Metoda onUpdateFrame() ruleaza atunci cand frame-ul se schimba.
4. 
In modul imediat, scena (modelul obiect complet al primitivelor de randare) este pastrata in spatiul de memorie al clientului, in loc de biblioteca grafica.
5. 
Ultima versiune de OpenGL care accepta modul immediat este 3.3.3
6. 
Metoda onRenderFrame() rulaeaza cand fereastra este gata de randare.
7.
Metoda onResize() ruleaza de obicei cel putin o data deoarece trebuie sa configureze starea initiala a ferestrei de vizualizare si a altor componente asociate. Acest lucru asigura ca totul este configurat corect inainte de inceperea randarii.
8. 
Parametri sunt: fieldOfView, aspectRatio, nearPlane, farPlane.  
Ele reprezinta, respectiv: Cat de larga este vizualizarea camerei, latimea ferestrei impartita la inaltimea acesteia, distanta de la camera la planul de taiere apropiat, si distanta dintre camera si planul de taiere indepartat.
Razele sunt: intre 0 si 180 de grade, ratii pozitive (dar de obicei 4:3 sau 16:9), valori pozitive (dar de obicei 0.01, 0.1 sau 1.0), si valori pozitive, cum ar fii 100, 1000, sau 10000 (dar neaparat mai mari decat nearPlane.)
