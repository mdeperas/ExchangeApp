class RegisterController {
    constructor(AuthService, $state, CurrenciesService) {
        this.authService = AuthService;
        this.user = {
            wallet: {
                resources: []
            }
        };
        this.errorMessage = "";
        this.state = $state;
        this.currenciesService = CurrenciesService;
        this.currenciesList = {};
    }

    async $onInit() {
        this.initCurrenciesList();

        console.log(this.currenciesList);

        Object.entries(this.currenciesList).forEach(([key, val]) => {
            console.log(key);          // the name of the current key.
            console.log(val);          // the value of the current key.
            this.user.wallet.resources.push({ Currency: c, CurrencyId: c.id, Amount: 0 });
        });
        
        console.log(this.user);
    }

    initCurrenciesList() {
        this.currenciesService.getCurrenciesList().then(
            (response) => {
                this.response = response.data || response;
                this.response.forEach(currency => {
                    this.currenciesList[currency.code] = currency;
                });
            },
            (errorResponse) => {
            });
    }

    register(event) {
        this.authService.register(this.user).then((response) => {
            this.state.go('free.login');
        },
            (error) => {
                console.log(error);
                error = error.data || error;
                this.errorMessage = error.modelState[""][0];
            });
    }

    update(newUserData) {
        this.user = newUserData;
        console.log(newUserData);
    }
}

export let RegisterComponent = {
    controller: RegisterController,
    template: require('./register.component.html')
}