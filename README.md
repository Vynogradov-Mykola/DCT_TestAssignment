# DCT_TestAssignment
Digital Cloud Technologies .NET Developer Test Assignment

Implemented functionality:
1. Functionality of the main window:
- Navigation between pages (ListPage_Click, DetaliedInfPage_Click, ConvertPage_Click);
- Set the default theme and language on start (public MainWindow());
- Change Dark/Light theme (Button_Click);
- Change localization of app (English, Ukrainian) (Local_Click).

2. Functionality of the page with currencies list:
- Set localization on open (ListPageVM(string Local));
- Search for top 10 currency (Search);
- Go to page with detailed information on change selected index (ListBox_SelectionChanged).

3. Functionality of the page with detailed information about currency:
- Set localization on open and information about currency, if redirect from list page (DetailedInfPage, DetailedInfViewModel);
- Open quote chart page for currency (DisplayChartsButton_Click;
- Search for information about currency (Search).
  
4. Functionality of the page with convertation:
- Set localization on open (ConvertCurrency(string Local));
- Сonverting one amount of currency to another (Convert);

5. Quote Chart page:
- Load and draw quote chart (LoadQuoteData).
