CEX.io.API
==========

C# .Net wrapper for the CEX.io API

Usage examples (Ticker/TradeHistory/OrderBook):
    
	CEXAPI api = new CEXAPI();
	Ticker currentTicker = api.GetTicker();
	TradeHistoryList currentTradeHistory = api.GetTradeHistory(5585858);
	OrderBook currentOrderBook = api.GetOrderHistory(100);
	Console.WriteLine("Current Ticker:");
	Console.WriteLine(currentTicker.ToString());
	Console.ReadLine();
	Console.WriteLine("");
	Console.WriteLine("Current TradeHistory:");
	Console.WriteLine(currentTradeHistory.ToString());
	Console.ReadLine();
	Console.WriteLine("");
	Console.WriteLine("Current OrderBook:");
	Console.WriteLine(currentOrderBook.ToString());
	Console.ReadLine();

Known issues:

	Currently the GetHashRate and GetWorkerHashRate API calls return HTTP 404 errors
	Seems that CEX.io removed those two API calls without notification since they still appear on the API page
