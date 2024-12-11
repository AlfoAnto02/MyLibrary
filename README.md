# **MY LIBRARY**

## *Che cos'è?*
My library è un'applicazione web composta da un backend in .NET e un frontend in Angular. Lo scopo di quesa applicazione è di permettere ad utenti 
verificati di poter aggiungere ed ottenere informazioni riguardanti libri in una sorta di biblioteca digitale.

## *Tecnologie utilizzate*

### *Lato Backend*

- .NET FRAMEWORK
-  Swagger UI per il testing degli endpoint lato backend
-  JWT Authentication per gli endpoint
-  My Sql Management Studio Database per immagazzinare i Dati

### *Lato frontend*
- NodeJS
- Angular
- Express JS
- NoDemon
- BootStrap


## *Funzionamento Backend*
Il lato backend di questa applicazione web è caratterizzato da una struttura divisa in 3 Moduli:

1. Module Layer => Strato di riferimento per l'impostazione e il popolamento del database. Qui vengono definiti tutti gli elementi di modello con le regole per l'immagazzinamento dei dati
2. Application Layer => Strato dei servizi. Qui vengono definiti tutti i servizi necessari per il funzionamento dell'applicativo lato backend. In particolar modo, BookService, CategoryService, BookCategoryService, UserService e TokenService
3. Web Layer => Strato web dove vengono definiti i controller e gli endpoint per poter poi permettere all'utente esterno di interagire con il nostro sistema.

Gli elementi di modello dell'applicativo sono 3: Gli utenti, i libri e le categorie. Ogni libro deve avere almeno una categoria per essere definito come tale. Un libro può avere più categorie. 

Nello strato applicativo vengono descritte anche regole rigide per il popolamento del database. Tra queste abbiamo: Verifica che l'indirizzo email sia valido attraverso regex, verifica della lunghezza della password di almeno 8 caratteri + carattere speciale + numero + Maiuscola.
Sono stati inseriti anche controlli per quanto riguarda l'inserimento di libri già esistenti o di cateogorie già esistenti.

### *Autenticazione*
Il lato web dell'applicativo impone un'ulteriore verifica per l'inserimento di dati nel database oppure per poter fare data retrieve. Attraverso un sistema di Login impone all'utente di loggarsi per poter generare un token Jwt valido per 30 minuti utilizzato come intestazione di Autorizzazione
per poter eseguire le chiamate negli endpoint definiti nel lato WEB

## *Funzionamento FrontEnd*

Il Frontend è stato sviluppato utilizzando Angular. Esso si presenta con una schermata Home di benvenuto dove sarà possibile eseguire un login. Il login è obbligatorio per poter accedere alle funzionalità attraverso il pulsante Services. 

### *Componenti e Servizi*

Le componenti principali utilizzate sono le seguenti: 
1. AppComponent => Utilizzata per descrivere un layout predefinito delle altre componenti; caratterizzato da una navigation bar superiore e da un footer. All'interno abbiamo un router-outlet utilizzato per accedere alle altre rotte
2. HomeComponent => Componente utilizzato come schermata home Principale. Esso invita l'utente a loggarsi e ad usufruire dei servizi dell'applicativo
3. LoginComponent => Component utilizzato per presentare una form di Login. Esso permette di inserire nome utente e password e attraverso il component.service.ts comunica con il backend per verificare che i dati inseriti siano valido. Se validi, ritorna il nome utente che apparirà
nella schermata home.
4. RegisterComponent => Collegato al Login component attraverso un bottone vi è il register component (nel caso in cui non is abbia un account). Qui viene presentata una form per la registrazione come nome, cognome, email e password. Il component.ts comunica con il backend
per effettuare la registrazione e, se eseguita con successo, ritorna alla schermata di login.
5. AppServiveComponent => Componente utilizzato per elencare i servizi resi disponibili dall'applicativo. Questi servizi sono la ricerca di un libro e l'aggiunta di un libro.
6. AddBookComponent => Componente per l'aggiunta di un libro. Qui viene presentata una form per l'inserimento di un libro corrispondente all'oggetto richiesto lato BackEnd quando si richiama l'endpoint con il submit.
Una parte importante di questo Component è la funzione OnInit() definita nel .ts utilizzata per presentare all'utente tutte le categorie selezionabili presenti nel database. Infatti, appena richiamata la pagina. La funzione OnInit comunica con il Backend per presentare all'utente
tutte le categorie attualmente selezionabili.
7. SearchComponent => Componente di ricerca in cui vengono presentati i possibili filtri applicabili per la ricerca dei libri. Qui l'utente deve decidere se vuole effettuare una ricerca per nome dell'Autore, titolo del libro o per genere.
8. SearchDetailsComponent => Componente di ricerca dettagliato in cui è possibile ricercare effettivamente il libro in base al filtro applicato. Qui si possono digitare dei caratteri nella barra di ricerca e vengono presentati dei libri corrispondenti ai caratteri inseriti.
Il component.ts esegue una chiamata di ricerca verso il database ogni volta che il contenuto della searchBar cambia. All'interno della finestra di ricerca vengono presentati i libri con le seguenti caratteristiche: Titolo, Autore e Generi.

I servizi utilizzati a sostegno della logica del frontend sono:
1. UserService.ts => Servizio richiamato quando si esegue il Login o il Logout dall'applicativo. Imposta il nome come il nome utente corrispondente all'account in caso di login e rimuove il token in caso di logout.
2. SearchCategoriesService.cs => Servizio utilizzato per eseguire la chiamata al Backend per fara data retrieve delle categorie disponibili.
3. SearchBookService.ts => Servizio utilizzato per eseguire la query di ricerca verso il backend e fare data retrieve dei libri corrispondenti.
4. AuthService.ts => Servizio utilizzato per eseguire login e register sulla piattaforma. Inoltre le richieste di login e register ai rispettivi endpoint.
5. Interceptor.ts => Interceptor collegato alla funzione di login. Esso intercetta il token jwt e lo inserisce come header di autorizzazione per le successive chiamate.
