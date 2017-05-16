import { APIURL } from "../config/api.config";

export class UserInfoService {
    constructor($http) {
        this.http = $http;
    }

    //1a Przerob na obiekt http.
    getUserInfo() {
        return this.http.get(APIURL + 'api/account');
    }
}