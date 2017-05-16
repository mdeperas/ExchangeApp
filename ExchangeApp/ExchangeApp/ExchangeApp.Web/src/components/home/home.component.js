class HomeController {
    constructor() {
    }

    cuscus() {
        return new Promise((resolve, reject) => {
            setTimeout(function() {
                console.log('timeout');
                reject("zrobilem sie");
            }, 1500);
        });
    }

    async $onInit() {
        try {
        let message = this.cuscus();
        console.log(message);
        } catch (e) {
            console.log(e);
        }
    }

}

export let HomeComponent = {
    controller: HomeController,
    template: require('./home.component.html')
}