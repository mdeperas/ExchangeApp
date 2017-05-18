import { APIURL } from "../config/api.config";

export class CurrenciesService {
    constructor($http) {
        this.http = $http;
    }

    getCurrenciesList() {
        return this.http.get(APIURL + 'api/currencies');
    }
}