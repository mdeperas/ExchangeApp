class HomeController {
    constructor($state) {
        this.currenciesList = { connected: false };
        this.state = $state;
    }

    async $onInit() {
        await this.initCurrenciesList();
        this.connectWithWebSocket();
    }

    async initCurrenciesList() {
       await this.currencies.$promise;
        this.currencies.forEach(currency => {
            this.currenciesList[currency.code] = currency;
        });
    }

    connectWithWebSocket() {
        // Create a new WebSocket.
        var socket = new WebSocket('ws://webtask.future-processing.com:8068/ws/currencies');

        //Open connection set connected.
        socket.onopen = (event) => {
            this.currenciesList.connected = true;
        };

        // Handle any errors that occur.
        socket.onerror = (error) => {
            this.currenciesList.connected = false;

            //TODO: put some toast here.
            console.log('WebSocket Error: ' + error);
            console.log(error);

        };

        socket.onmessage = (event) => {
            let data = JSON.parse(event.data);
            this.currenciesList.PublicationDate = data.PublicationDate;
            data.Items.forEach(currency => {
                this.currenciesList[currency.Code].PurchasePrice = currency.PurchasePrice;
                this.currenciesList[currency.Code].SellPrice = currency.SellPrice;
                this.currenciesList[currency.Code].AveragePrice = currency.AveragePrice;
            });
            this.refreshScope();
        }
    }

    refreshScope() {
        this.state.go(this.state.current);
    }
}

export let HomeComponent = {
    bindings: {
        currencies: '<'
    },
    controller: HomeController,
    template: require('./home.component.html')
}