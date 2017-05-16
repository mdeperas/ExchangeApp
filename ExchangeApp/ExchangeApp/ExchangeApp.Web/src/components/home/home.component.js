class HomeController {
    constructor($state) {
        this.$state = $state;
        this.currenciesList = { connected: false };
    }

    async $onInit() {
        await this.initCurrenciesList();
        this.connectWithWebSocket();
/*        if (this.userInfo.authenticated) {
            this.initWallet();
        }*/
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

    async initCurrenciesList() {
        await this.currencies.$promise;
        let currenciesList = this.currencies;
        currenciesList.forEach(currency => {
            this.currenciesList[currency.Code] = currency;
        });
    }

    /*async initWallet() {
        let wallet = await this.Wallet.get().$promise;
        if (!wallet.Id) {
            this.$state.go('app.home.setup');
            return;
        }
        wallet.Positions.forEach(position => {
            this.currenciesList[position.Currency.Code].Stock = position.Stock;
        });
        this.refreshScope();
    }*/

    refreshScope() {
        this.$state.go(this.$state.current);
    }
}

export let HomeComponent = {
    bindings: {
        currencies: '<'
    },
    controller: HomeController,
    template: require('./home.component.html')
}