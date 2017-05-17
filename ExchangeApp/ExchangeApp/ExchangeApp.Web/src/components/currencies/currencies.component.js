class CurrenciesController {
    constructor() {
        
    }

    $onChanges(valueObject) {
        if(valueObject.currencies) {
            this.currencies = valueObject.currencies.currentValue;
            console.log(this.currencies);
        }
    }
}

export let CurrenciesComponent = {
    bindings: {
        currencies: '<'
    },
    controller: CurrenciesController,
    template: require('./currencies.component.html')
}