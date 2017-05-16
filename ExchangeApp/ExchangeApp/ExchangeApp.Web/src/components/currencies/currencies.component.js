class CurrenciesController {
    constructor() {

    }
}

export let CurrenciesComponent = {
    bindings: {
        currencies: '<'
    },
    controller: CurrenciesController,
    template: require('currencies.component.html')
}