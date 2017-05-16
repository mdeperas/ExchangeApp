import { APIURL } from "../config/api.config";

export class CurrenciesService {
    constructor($http) {
        this.http = $http;
    }

    //1a Przerob na obiekt http.
    getCurrenciesList() {
        return this.http.get(APIURL + 'api/account');
    }
}